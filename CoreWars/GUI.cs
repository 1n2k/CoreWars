using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWars
{
	namespace GUI
	{
		public partial class GUI : Form
		{
			//Testfarben
			public List<Color> lightColors = new List<Color>();
			public List<Color> colors = new List<Color>();
			public List<int> lastCell = new List<int>();
			//.....

			PlayerForm myPlayerForm;
			NoGraphicForm myNoGraphicForm;
			int firstActivePlayer;
			int activePlayer;
			bool noPlayer = true;
			ThisIsNotAForm myThisIsNotAForm;
			bool pausiert = false;
			public Engine.IO.Compiler.Standard standard;
			public List<Engine.Simulator.Player> players = new List<Engine.Simulator.Player>();
			public List<int> alivePlayers;
			int refreshLenght;
			int tempRefreshIndex;

			public GUI()
			{
				InitializeComponent();
				listBox1.DrawMode = DrawMode.OwnerDrawFixed;
				firstActivePlayer = -1;
				colors.Add(Color.DarkBlue);
				colors.Add(Color.DarkRed);
				colors.Add(Color.DarkGreen);
				colors.Add(Color.DarkOrange);
				colors.Add(Color.DarkTurquoise);
				colors.Add(Color.DarkMagenta);
				colors.Add(Color.DarkOrchid);
				colors.Add(Color.DarkKhaki);
				lightColors.Add(Color.Blue);
				lightColors.Add(Color.Red);
				lightColors.Add(Color.Green);
				lightColors.Add(Color.Orange);
				lightColors.Add(Color.Turquoise);
				lightColors.Add(Color.Magenta);
				lightColors.Add(Color.Orchid);
				lightColors.Add(Color.Khaki);
			}

			private void GUI_Load(object sender, EventArgs e)
			{
				this.listBox1.DrawItem += new DrawItemEventHandler(GUI_DrawItem);
				Engine.Simulator.Game.GetGame.TurnStarted += new Engine.Simulator.TurnStartedEventHandler(Engine_Game_GetGame_TurnStarted);
				Engine.Simulator.Game.GetGame.PlayerDied += new Engine.Simulator.PlayerDiedEventHandler(playerDied);
				Engine.Simulator.Game.GetGame.MemoryCellChanged += new Engine.Simulator.MemoryCellChangedEventHandler(memoryCellChanged);
				toolStripProgressBar1.Maximum = Engine.Simulator.Settings.MAXCYCLES;
				toolStripStatusLabel1.Text = "0";
				toolStripStatusLabel3.Text = "" + Engine.Simulator.Settings.MAXCYCLES;
				timer.Tick += new EventHandler(timer_Tick);
				timer.Period = 1000 / trackBar1.Value;
				pausiert = false;
				startGameButton.Enabled = true;
				stopGameButton.Enabled = false;
				singleStepButton.Enabled = false;
				pauseGameButton.Enabled = false;
				standard = Engine.IO.Compiler.Standard._88;
				refreshLenght = 1;
				tempRefreshIndex = 0;
			}

			void GUI_DrawItem(object sender, DrawItemEventArgs e)
			{
				listBox1.DrawMode = DrawMode.OwnerDrawFixed;
				e.DrawBackground();
				Brush myBrush = Brushes.Aqua;
				switch (e.Index)
				{
					case 0:
						myBrush = Brushes.DarkBlue;
						break;
					case 1:
						myBrush = Brushes.DarkRed;
						break;
					case 2:
						myBrush = Brushes.DarkGreen;
						break;
					case 3:
						myBrush = Brushes.DarkOrange;
						break;
					case 4:
						myBrush = Brushes.DarkTurquoise;
						break;
					case 5:
						myBrush = Brushes.DarkMagenta;
						break;
					case 6:
						myBrush = Brushes.DarkOrchid;
						break;
					case 7:
						myBrush = Brushes.DarkKhaki;
						break;
				}
				e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), new Font(e.Font, FontStyle.Bold), myBrush,e.Bounds,StringFormat.GenericDefault);
				e.DrawFocusRectangle();
			}

			void Engine_Game_GetGame_TurnStarted(object sender, Engine.Simulator.TurnStartedEventArgs e)
			{
				noPlayer = false;
				activePlayer = (activePlayer + 1) % alivePlayers.Count;
			}

			public void playerDied(object sender, Engine.Simulator.ObjectDiedEventArgs<Engine.Simulator.Player> e)
			{
				myThisIsNotAForm.Refresh();
				if (e.Object.Name.ToLower().StartsWith("spieler"))
				{
					MessageBox.Show("Der Spieler " + e.Object.Name.Substring(7,e.Object.Name.Length-7) + " ist gestorben.", "Spieler ist gestorben", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Der Spieler " + e.Object.Name + " ist gestorben.", "Spieler ist gestorben", MessageBoxButtons.OK);
				}
				List<string> names = new List<string>();
				for (int i = 0; i < players.Count; i++)
				{
					names.Add(players[i].Name);
				}
				alivePlayers.Remove(names.IndexOf(e.Object.Name));
				activePlayer--;
				if (alivePlayers.Count == 1)
				{
					timer.Stop();
					if (players[alivePlayers[0]].Name.ToLower().StartsWith("spieler"))
					{
						MessageBox.Show("Der Spieler " + players[alivePlayers[0]].Name.Substring(7, players[alivePlayers[0]].Name.Length) + " hat gewonnen.", "Spieler hat gewonnen", MessageBoxButtons.OK);
					}
					else
					{
						MessageBox.Show("Der Spieler " + players[alivePlayers[0]].Name + " hat gewonnen.", "Spieler hat gewonnen", MessageBoxButtons.OK);
					}
					startGameButton.Enabled = true;
					stopGameButton.Enabled = false;
					singleStepButton.Enabled = false;
					pauseGameButton.Enabled = false;
					pausiert = false;
				}
			}

			public delegate void DrawRectangleEventHandler(object sender, DrawRectangleEventArgs e);
			public class DrawRectangleEventArgs : EventArgs
			{
				public readonly int x;
				public readonly int y;
				public readonly Color color;
				public readonly bool refresh;

				internal DrawRectangleEventArgs(int _x, int _y, Color _color, bool _refresh)
				{
					x = _x;
					y = _y;
					color = _color;
					refresh = _refresh;
				}
			}
			public event DrawRectangleEventHandler DrawRectangle;
			protected virtual void OnDrawRectangle(DrawRectangleEventArgs e)
			{
				if (this.DrawRectangle != null)
					this.DrawRectangle(this, e);
			}

			public void memoryCellChanged(object sender, Engine.Simulator.MemoryCellChangedEventArgs e)
			{
				if (noPlayer)
				{
					//System.Diagnostics.Debug.WriteLine(e.CellIndex + "    "+ Engine.Simulator.Game.GetGame[e.CellIndex].ToString());
					bool isStarterCell = false;
					for (int i = 0; i < players.Count; i++)
					{
						for (int j = 0; j < players[i].Code.Count; j++)
						{
							if (e.CellIndex == j + Engine.Simulator.Settings.GetInitialPosition(i))
							{
								OnDrawRectangle(new GUI.DrawRectangleEventArgs((e.CellIndex % myThisIsNotAForm.xRectangles) * 7 + 5,
								                                               (((e.CellIndex - e.CellIndex % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, colors[i], false));
								isStarterCell = true;
							}
						}
					}
					if (!isStarterCell)
					{
						OnDrawRectangle(new DrawRectangleEventArgs((e.CellIndex % myThisIsNotAForm.xRectangles) * 7 + 5,
						                                           (((e.CellIndex - e.CellIndex % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, Color.Gray, false));
					}
					Application.DoEvents();
				}
				else
				{
					//System.Diagnostics.Debug.WriteLine(e.CellIndex + "    "+ Engine.Simulator.Game.GetGame[e.CellIndex].ToString());
					if (tempRefreshIndex % refreshLenght == 0)
					{
						OnDrawRectangle(new DrawRectangleEventArgs((e.CellIndex % myThisIsNotAForm.xRectangles) * 7 + 5,
						                                           (((e.CellIndex - e.CellIndex % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, lightColors[alivePlayers[activePlayer]], false));
						OnDrawRectangle(new DrawRectangleEventArgs((lastCell[alivePlayers[activePlayer]] % myThisIsNotAForm.xRectangles) * 7 + 5,
						                                           (((lastCell[alivePlayers[activePlayer]] - lastCell[alivePlayers[activePlayer]] % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, colors[alivePlayers[activePlayer]], true));
						lastCell[alivePlayers[activePlayer]] = e.CellIndex;
					}
					else
					{
						OnDrawRectangle(new DrawRectangleEventArgs((e.CellIndex % myThisIsNotAForm.xRectangles) * 7 + 5,
						                                           (((e.CellIndex - e.CellIndex % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, lightColors[alivePlayers[activePlayer]], false));
						OnDrawRectangle(new DrawRectangleEventArgs((lastCell[alivePlayers[activePlayer]] % myThisIsNotAForm.xRectangles) * 7 + 5,
						                                           (((lastCell[alivePlayers[activePlayer]] - lastCell[alivePlayers[activePlayer]] % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, colors[alivePlayers[activePlayer]], false));
						lastCell[alivePlayers[activePlayer]] = e.CellIndex;
					}
					tempRefreshIndex++;
					Application.DoEvents();
				}
			}

			#region Buttons

			private void editPlayerButton_Click(object sender, EventArgs e) //Spieler bearbeiten
			{
				if (listBox1.SelectedItem == null)
				{
					MessageBox.Show("Es ist kein Spieler zum Bearbeiten ausgewählt.", "Kein Spieler ausgewählt", MessageBoxButtons.OK);
				}
				else
				{
					changePlayer(listBox1.SelectedIndex);
				}
			}

			private void newPlayerButton_Click(object sender, EventArgs e) //Spieler hinzufügen
			{
				myPlayerForm = new PlayerForm(this);
				myPlayerForm.ShowDialog();
			}

			private void deletePlayerButton_Click(object sender, EventArgs e) //Spieler löschen
			{
				if (listBox1.SelectedItem == null)
				{
					MessageBox.Show("Es ist kein Spieler zum Löschen ausgewählt.", "Kein Spieler ausgewählt", MessageBoxButtons.OK);
				}
				else
				{
					deletePlayer(listBox1.SelectedIndex);
				}
			}

			private void startGameButton_Click(object sender, EventArgs e) //Spiel starten
			{
				if (players.Count == 0)
				{
					MessageBox.Show("Es gibt noch keine Spieler.", "Keine Spieler verfügbar", MessageBoxButtons.OK);
				}
				else if (players.Count == 1)
				{
					MessageBox.Show("Ein Spiel mit nur einem Spieler ist sinnlos.", "Nur ein Spieler vorhanden", MessageBoxButtons.OK);
				}
				else
				{
					try
					{
						myThisIsNotAForm.Close();
						myNoGraphicForm.Close();
					}
					catch (Exception) { }
					alivePlayers = new List<int>();
					lastCell = new List<int>();
					for (int i = 0; i < players.Count; i++)
					{
						alivePlayers.Add(i);
						lastCell.Add(Engine.Simulator.Settings.GetInitialPosition(i));
					}
					activePlayer = firstActivePlayer;
					noPlayer = true;
					myNoGraphicForm = new NoGraphicForm(this);
					myThisIsNotAForm = new ThisIsNotAForm(this);
					List<Engine.Simulator.Player> tempPlayers = new List<Engine.Simulator.Player>();
					for (int i = 0; i < players.Count; ++i )
						tempPlayers.Add( new Engine.Simulator.Player(players[i]) );
					if (standard == Engine.IO.Compiler.Standard._88)
					{
						Engine.Simulator.Game.GetGame.Initialize(tempPlayers, false);
					}
					else
					{
						Engine.Simulator.Game.GetGame.Initialize(tempPlayers, true);
					}
					timer.Start();
					toolStripProgressBar1.Value = 0;
					toolStripProgressBar1.Maximum = Engine.Simulator.Settings.MAXCYCLES;
					toolStripStatusLabel1.Text = "0";
					toolStripStatusLabel3.Text = "" + Engine.Simulator.Settings.MAXCYCLES;
					startGameButton.Enabled = false;
					stopGameButton.Enabled = true;
					singleStepButton.Enabled = false;
					pauseGameButton.Enabled = true;
					pausiert = false;
					myThisIsNotAForm.Show();
					myNoGraphicForm.Show();
				}
			}

			private void stopGameButton_Click(object sender, EventArgs e) //Spiel stoppen
			{
				myThisIsNotAForm.Refresh();
				timer.Stop();
				startGameButton.Enabled = true;
				stopGameButton.Enabled = false;
				singleStepButton.Enabled = false;
				pauseGameButton.Enabled = false;
				pausiert = false;
			}

			private void singleStepButton_Click(object sender, EventArgs e) //Einzelschritt
			{
				if (this.InvokeRequired)
				{
					this.Invoke((Action<object, EventArgs>)singleStepButton_Click, sender, e);
				}
				else
				{
					tempRefreshIndex = 0;
					if (Engine.Simulator.Game.GetGame.SimulateNextTurn())
					{
						toolStripStatusLabel1.Text = Convert.ToInt32(toolStripStatusLabel1.Text) + 1 + "";
						toolStripProgressBar1.Value++;
					}
					else
					{
						timer.Stop();
						startGameButton.Enabled = true;
						stopGameButton.Enabled = false;
						singleStepButton.Enabled = false;
						pauseGameButton.Enabled = false;
						pausiert = false;
						myThisIsNotAForm.Close();
					}
				}
			}

			private void pauseGameButton_Click(object sender, EventArgs e) //Spiel pausieren
			{
				myThisIsNotAForm.Refresh();
				pausiert = !pausiert;
				if (!pausiert)
				{
					timer.Start();
					singleStepButton.Enabled = false;
					pauseGameButton.Text = "Pause";
				}
				else
				{
					timer.Stop();
					singleStepButton.Enabled = true;
					pauseGameButton.Text = "Weiter";
				}
				startGameButton.Enabled = false;
				stopGameButton.Enabled = true;
				pauseGameButton.Enabled = true;
			}

			private void openSettingsButton_Click(object sender, EventArgs e) //Einstellungen öffnen
			{
				timer.Stop();
				startGameButton.Enabled = true;
				stopGameButton.Enabled = false;
				singleStepButton.Enabled = false;
				pauseGameButton.Enabled = false;
				pausiert = false;
				SettingsForm settingsForm = new SettingsForm(this);
				settingsForm.ShowDialog();
			}

			#endregion

			public bool listboxContains(string text)
			{
				return (listBox1.Items.Contains(text));
			}

			public void changePlayer(int index)
			{
				myPlayerForm.Hide();
				myPlayerForm.Dispose();
				if (index == -1)
				{
					myPlayerForm = new PlayerForm(this);
				}
				else
				{
					myPlayerForm = new PlayerForm(this, index, players[index]);
				}
				myPlayerForm.ShowDialog();
			}

			public void deletePlayer(int index)
			{
				players.RemoveAt(index);
				listBox1.Items.RemoveAt(index);
				firstActivePlayer--;
			}

			public void newPlayer(bool isNewPlayer, Engine.Simulator.Player player, int index = -1)
			{
				if (isNewPlayer)
				{
					if (index == -1)
					{
						players.Add(player);
						listBox1.Items.Add(player.Name);
						firstActivePlayer++;
					}
					else
					{
						players.Insert(index, player);
						listBox1.Items.Insert(index, player.Name);
						firstActivePlayer++;
					}
				}
				else
				{
					newPlayer(true, player, index);
					deletePlayer(index + 1);
				}
			}

			private void timer_Tick(object sender, EventArgs e) //Schritt (per Timer)
			{
				if (this.InvokeRequired)
				{
					this.Invoke((Action<object, EventArgs>)timer_Tick, sender, e);
				}
				else
				{
					try
					{
						if (Engine.Simulator.Game.GetGame.SimulateNextTurn())
						{
							toolStripStatusLabel1.Text = Convert.ToInt32(toolStripStatusLabel1.Text) + 1 + "";
							toolStripProgressBar1.Value++;
						}
						else
						{
							myThisIsNotAForm.Refresh();
							timer.Stop();
							startGameButton.Enabled = true;
							stopGameButton.Enabled = false;
							singleStepButton.Enabled = false;
							pauseGameButton.Enabled = false;
							pausiert = false;
							MessageBox.Show("Das Spiel hat keinen eindeutigen Gewinner.", "Unentschieden", MessageBoxButtons.OK);
						}
					}
					catch (Exception) { }
				}
			}

			public void changedSettings()
			{
				toolStripProgressBar1.Value = 0;
				toolStripProgressBar1.Maximum = Engine.Simulator.Settings.MAXCYCLES;
				toolStripStatusLabel1.Text = "0";
				toolStripStatusLabel3.Text = "" + Engine.Simulator.Settings.MAXCYCLES;
			}

			private void trackBar1_Scroll(object sender, EventArgs e)
			{
				timer.Period = 1000 / trackBar1.Value;
				refreshLenght = 1 + (trackBar1.Value / 225);
			}

			private void GUI_FormClosing(object sender, FormClosingEventArgs e)
			{
				if (timer.IsRunning)
				{
					timer.Stop();
				}
			}
		}
	}
}

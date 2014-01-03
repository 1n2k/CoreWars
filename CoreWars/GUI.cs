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
			public List<Color> colors = new List<Color>();
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

			public GUI()
			{
				InitializeComponent();
				firstActivePlayer = -1;
				colors.Add(Color.Blue);
				colors.Add(Color.Red);
				colors.Add(Color.Green);
				colors.Add(Color.Orange);
				colors.Add(Color.Magenta);
			}

			private void GUI_Load(object sender, EventArgs e)
			{
				Engine.Simulator.Game.GetGame.TurnStarted += new Engine.Simulator.TurnStartedEventHandler(Engine_Game_GetGame_TurnStarted);
				Engine.Simulator.Game.GetGame.PlayerDied += new Engine.Simulator.PlayerDiedEventHandler(playerDied);
				Engine.Simulator.Game.GetGame.MemoryCellChanged += new Engine.Simulator.MemoryCellChangedEventHandler(memoryCellChanged);
				toolStripProgressBar1.Maximum = Engine.Simulator.Settings.MAXCYCLES;
				toolStripStatusLabel1.Text = "0";
				toolStripStatusLabel3.Text = "" + Engine.Simulator.Settings.MAXCYCLES;
				timer.Tick += new EventHandler(timer_Tick);
				timer.Period = 1000 / trackBar1.Value;
				pausiert = false;
				button4.Enabled = true;
				button5.Enabled = false;
				button6.Enabled = false;
				button7.Enabled = false;
				standard = Engine.IO.Compiler.Standard._88;
			}

			void Engine_Game_GetGame_TurnStarted(object sender, Engine.Simulator.TurnStartedEventArgs e)
			{
				noPlayer = false;
				activePlayer = (activePlayer+1)%alivePlayers.Count;
			}
			
			public void playerDied(object sender, Engine.Simulator.ObjectDiedEventArgs<Engine.Simulator.Player> e)
			{
				MessageBox.Show("Der Spieler " + e.Object.Name + " ist gestorben.", "Spieler ist gestorben", MessageBoxButtons.OK);
                alivePlayers.Remove(players.IndexOf(e.Object));
			}

			#region test
			public delegate void DrawRectangleEventHandler(object sender, DrawRectangleEventArgs e);
			public class DrawRectangleEventArgs : EventArgs
			{
				public readonly int x;
				public readonly int y;
				public readonly Color color;

				internal DrawRectangleEventArgs(int _x, int _y, Color _color)
				{
					x = _x;
					y = _y;
					color = _color;
				}
			}
			public event DrawRectangleEventHandler DrawRectangle;
			protected virtual void OnDrawRectangle(DrawRectangleEventArgs e)
			{
				if (this.DrawRectangle != null)
					this.DrawRectangle(this, e);
			}
			#endregion

			public void memoryCellChanged(object sender, Engine.Simulator.MemoryCellChangedEventArgs e)
			{
				if(noPlayer){
					//System.Diagnostics.Debug.WriteLine(e.CellIndex + "    "+ Engine.Simulator.Game.GetGame[e.CellIndex].ToString());
					OnDrawRectangle(new DrawRectangleEventArgs((e.CellIndex % myThisIsNotAForm.xRectangles) * 7 + 5,
					                                           (((e.CellIndex - e.CellIndex % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, Color.Black));
					/*if (e.CellIndex == Engine.Simulator.Settings.MEMORYSIZE - 1)
					{
						for (int i = 0; i < players.Count; i++)
						{
							int t = Engine.Simulator.Settings.GetInitialPosition(i);
							OnDrawRectangle(new DrawRectangleEventArgs((t % myThisIsNotAForm.xRectangles) * 7 + 5,
							                                           (((t - t % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, colors[i]));
						}
					}*/
					Application.DoEvents();
				}else{
					//System.Diagnostics.Debug.WriteLine(e.CellIndex + "    "+ Engine.Simulator.Game.GetGame[e.CellIndex].ToString());
					OnDrawRectangle(new DrawRectangleEventArgs((e.CellIndex % myThisIsNotAForm.xRectangles) * 7 + 5,
					                                           (((e.CellIndex - e.CellIndex % myThisIsNotAForm.xRectangles) / myThisIsNotAForm.xRectangles)) * 7 + 5, colors[activePlayer]));
					Application.DoEvents();
				}
			}

			#region Buttons

			private void button1_Click(object sender, EventArgs e) //Spieler bearbeiten
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

			private void button2_Click(object sender, EventArgs e) //Spieler hinzufügen
			{
				myPlayerForm = new PlayerForm(this);
				myPlayerForm.ShowDialog();
			}

			private void button3_Click(object sender, EventArgs e) //Spieler löschen
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

			private void button4_Click(object sender, EventArgs e) //Spiel starten
			{
				if (players.Count == 0)
				{
					MessageBox.Show("Es gibt noch keine Spieler.", "Keine Spieler verfügbar", MessageBoxButtons.OK);
				}
				else
				{
                    alivePlayers = new List<int>();
                    for (int i = 0; i < players.Count; i++)
                    {
                        alivePlayers.Add(i);
                    }
                    activePlayer = firstActivePlayer;
                    noPlayer = true;
					myNoGraphicForm = new NoGraphicForm();
					myThisIsNotAForm = new ThisIsNotAForm(this);
					List<Engine.Simulator.Player> tempPlayers = new List<Engine.Simulator.Player>(players);
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
					button4.Enabled = false;
					button5.Enabled = true;
					button6.Enabled = false;
					button7.Enabled = true;
					pausiert = false;
					myThisIsNotAForm.Show();
					myNoGraphicForm.Show();
				}
			}

			private void button5_Click(object sender, EventArgs e) //Spiel stoppen
			{
				timer.Stop();
				myThisIsNotAForm.Close();
				myNoGraphicForm.Close();
				button4.Enabled = true;
				button5.Enabled = false;
				button6.Enabled = false;
				button7.Enabled = false;
				pausiert = false;
			}

			private void button6_Click(object sender, EventArgs e) //Einzelschritt
			{
				if (this.InvokeRequired)
				{
					this.Invoke((Action<object, EventArgs>)button6_Click, sender, e);
				}
				else
				{
					if (Engine.Simulator.Game.GetGame.SimulateNextTurn())
					{
						toolStripStatusLabel1.Text = Convert.ToInt32(toolStripStatusLabel1.Text) + 1 + "";
						toolStripProgressBar1.Value++;
					}
					else
					{
						timer.Stop();
						button4.Enabled = true;
						button5.Enabled = false;
						button6.Enabled = false;
						button7.Enabled = false;
						pausiert = false;
						myThisIsNotAForm.Close();
					}
				}
			}

			private void button7_Click(object sender, EventArgs e) //Spiel pausieren
			{
				if (!pausiert)
				{
					timer.Stop();
					button6.Enabled = true;
				}
				else
				{
					timer.Start();
					button6.Enabled = false;
				}
				pausiert = !pausiert;
				button4.Enabled = false;
				button5.Enabled = true;
				button7.Enabled = true;
			}

			private void button8_Click(object sender, EventArgs e) //Einstellungen öffnen
			{
				timer.Stop();
				button4.Enabled = true;
				button5.Enabled = false;
				button6.Enabled = false;
				button7.Enabled = false;
				pausiert = false;
				SettingsForm settingsForm = new SettingsForm(this);
				settingsForm.ShowDialog();
			}

			#endregion

			public void changePlayer(int index){
                myPlayerForm.Close();
				myPlayerForm = new PlayerForm(this, index, players[index]);
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
					if(index == -1){
						players.Add(player);
						listBox1.Items.Add(player.Name);
                        firstActivePlayer++;
					}else{
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
							timer.Stop();
							button4.Enabled = true;
							button5.Enabled = false;
							button6.Enabled = false;
							button7.Enabled = false;
							pausiert = false;
							myThisIsNotAForm.Close();
							myNoGraphicForm.Close();
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
			}
		}
	}
}

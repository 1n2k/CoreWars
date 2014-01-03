using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoreWars
{
	namespace GUI
	{
		public partial class PlayerForm : Form
		{
			bool isNewPlayer;
			int index;
			GUI myGUI;
			Engine.Simulator.Player myPlayer;

			public PlayerForm(GUI GUI, int _index = -1, Engine.Simulator.Player player = null)
			{
				this.FormClosed += new FormClosedEventHandler(PlayerForm_FormClosed);
				myGUI = GUI;
				isNewPlayer = (player == null);
				if (player == null)
				{
					player = new Engine.Simulator.Player("", new System.Collections.Generic.List<Engine.Simulator.Cell>());
					this.Text = "Spieler erstellen";
				}
				index = _index;
				myPlayer = player;
				InitializeComponent();
			}

			void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
			{
			}

			private void PlayerForm_Load(object sender, EventArgs e)
			{
				textBox1.Text = myPlayer.Name;
				foreach (Engine.Simulator.Cell cell in myPlayer.Code)
				{
					textBox2.Text += cell.ToString() + "\r\n";
				}
			}
			
			private void button1_Click(object sender, EventArgs e)
			{
				try
				{
					myGUI.newPlayer(isNewPlayer, CoreWars.Engine.IO.Compiler.ParseCodeFile(textBox2.Text.Split('\n'), myGUI.standard, textBox1.Text), index);
				}
				catch (InvalidOperationException ex){
					MessageBox.Show("Der Code des Spielers " + myPlayer.Name + " ist nicht mit dem ausgewählten Standard kompatibel. Bitte korrigieren sie den Code dieses Spielers.", "Fehler beim Erstellen eines neuen Spielers", MessageBoxButtons.OK);
                    myGUI.changePlayer(index);
                }
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Es ist ein Fehler aufgetreten", MessageBoxButtons.OK);
                    myGUI.changePlayer(index);
				}
				this.Close();
			}

			private void button2_Click(object sender, EventArgs e)
			{
				this.Close();
			}
		}
	}
}
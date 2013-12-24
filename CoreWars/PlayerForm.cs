using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoreWars
{
    namespace GUI
    {
        public partial class PlayerForm : Form
        {
            bool save = true;
            bool neu = false;
            GUI myGUI;
            Engine.Simulator.Player myPlayer;

            public PlayerForm(GUI GUI, Engine.Simulator.Player player = null)
            {
                myGUI = GUI;
                if (player == null)
                {
                    player = new Engine.Simulator.Player("", new System.Collections.Generic.List<Engine.Simulator.Cell>());
                    this.Text = "Spieler erstellen";
                    neu = true;
                }
                myPlayer = player;
                InitializeComponent();
            }

            private void PlayerForm_Load(object sender, EventArgs e)
            {
                textBox1.Text = myPlayer.Name;
                foreach (Engine.Simulator.Cell cell in myPlayer.Code)
                {
                    textBox2.Text += cell.ToString() + "\n";
                }
            }

            private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (save)
                {
                    try
                    {
                        if (!myGUI.neunundvierzig)
                        {
                            myGUI.newPlayer(neu, CoreWars.Engine.IO.Compiler.ParseCodeFile(textBox2.Text.Split('\n'), Engine.IO.Compiler.Standard._88, textBox1.Text));
                        }
                        else
                        {
                            myGUI.newPlayer(neu, CoreWars.Engine.IO.Compiler.ParseCodeFile(textBox2.Text.Split('\n'), Engine.IO.Compiler.Standard._94, textBox1.Text));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Es ist ein Fehler aufgetreten", MessageBoxButtons.OK);
                    }
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void button2_Click(object sender, EventArgs e)
            {
                save = false;
                this.Close();
            }
        }
    }
}
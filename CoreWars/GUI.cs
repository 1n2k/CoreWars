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
            bool pausiert = false;
            List<Engine.Player> players = new List<Engine.Player>();

            public GUI()
            {
                InitializeComponent();
            }

            private void GUI_Load(object sender, EventArgs e)
            {
                toolStripProgressBar1.Maximum = Engine.Settings.MAXCYCLES;
                toolStripStatusLabel1.Text = "0";
                toolStripStatusLabel3.Text = ""+Engine.Settings.MAXCYCLES;
                pausiert = false;
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }

            private void button1_Click(object sender, EventArgs e) //Spieler bearbeiten
            {

            }

            private void button2_Click(object sender, EventArgs e) //Spieler hinzufügen
            {

            }

            private void button3_Click(object sender, EventArgs e) //Spieler löschen
            {
                if (listBox1.SelectedIndex != null)
                {
                    players.RemoveAt(listBox1.SelectedIndex);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }

            private void button4_Click(object sender, EventArgs e) //Spiel starten
            {
                Engine.Game.GetGame.Initialize(players, false);
                timer1.Start();
                button4.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = true;
                pausiert = false;
            }

            private void button5_Click(object sender, EventArgs e) //Spiel stoppen
            {
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                pausiert = false;
            }

            private void button6_Click(object sender, EventArgs e) //Einzelschritt
            {
                Engine.Game.GetGame.SimulateNextTurn();
                toolStripStatusLabel1.Text = Convert.ToInt32(toolStripStatusLabel1.Text) + 1 + "";
                pausiert = true;
            }

            private void timer1_Tick(object sender, EventArgs e) //Schritt (per Timer)
            {
                Engine.Game.GetGame.SimulateNextTurn();
                toolStripStatusLabel1.Text = Convert.ToInt32(toolStripStatusLabel1.Text) + 1 + "";
            }

            private void button7_Click(object sender, EventArgs e) //Spiel pausieren
            {
                if (!pausiert)
                {
                    timer1.Stop();
                }
                else
                {
                    timer1.Start();
                }
                pausiert = !pausiert;
                button4.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }

            private void button8_Click(object sender, EventArgs e) //Einstellungen öffnen
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.Show();
            }

            private void trackBar1_Scroll(object sender, EventArgs e)
            {
                timer1.Interval = 1000 / trackBar1.Value;
            }
        }
    }
}

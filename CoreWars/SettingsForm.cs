using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoreWars
{
    namespace GUI
    {
        public partial class SettingsForm : Form
        {
            private GUI myGUI;
            public SettingsForm(GUI _myGUI)
            {
                this.myGUI = _myGUI;
                InitializeComponent();
            }

            void SettingsFormLoad(object sender, EventArgs e)
            {
                textBox1.Text = "" + Engine.Simulator.Settings.MEMORYSIZE;
                textBox2.Text = "" + Engine.Simulator.Settings.MAXCORESPERPLAYER;
                textBox3.Text = "" + Engine.Simulator.Settings.MAXLENGTH;
                textBox4.Text = "" + Engine.Simulator.Settings.MAXCYCLES;
                textBox5.Text = "" + Engine.Simulator.Settings.CODEDISTANCE;
                if (myGUI.neunundvierzig)
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
                if (myGUI.players.Count != 0)
                {
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                }
            }

            void TextBox1TextChanged(object sender, EventArgs e)
            {
                try
                {
                    Engine.Simulator.Settings.MEMORYSIZE = Convert.ToInt32(textBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                    textBox1.Text = "" + Engine.Simulator.Settings.MEMORYSIZE;
                }
            }

            void TextBox2TextChanged(object sender, EventArgs e)
            {
                try
                {
                    Engine.Simulator.Settings.MAXCORESPERPLAYER = Convert.ToInt32(textBox2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                    textBox2.Text = "" + Engine.Simulator.Settings.MAXCORESPERPLAYER;
                }
            }

            void TextBox3TextChanged(object sender, EventArgs e)
            {
                try
                {
                    Engine.Simulator.Settings.MAXLENGTH = Convert.ToInt32(textBox3.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                    textBox3.Text = "" + Engine.Simulator.Settings.MAXLENGTH;
                }
            }

            void TextBox4TextChanged(object sender, EventArgs e)
            {
                try
                {
                    Engine.Simulator.Settings.MAXCYCLES = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                    textBox4.Text = "" + Engine.Simulator.Settings.MAXCYCLES;
                }

            }

            private void TextBox5TextChanged(object sender, EventArgs e)
            {
                try
                {
                    Engine.Simulator.Settings.CODEDISTANCE = Convert.ToInt32(textBox5.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                    textBox5.Text = "" + Engine.Simulator.Settings.CODEDISTANCE;
                }
            }

            void SettingsFormFormClosed(object sender, FormClosedEventArgs e)
            {
                myGUI.changedSettings();
            }

            private void radioButton1_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButton1.Checked)
                {
                    radioButton2.Checked = false;
                    myGUI.neunundvierzig = false;
                }
            }

            private void radioButton2_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButton2.Checked)
                {
                    radioButton1.Checked = false;
                    myGUI.neunundvierzig = true;
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
}
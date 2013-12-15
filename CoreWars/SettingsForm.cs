using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoreWars
{
	public partial class SettingsForm : Form
	{
		private GUI.GUI myGUI;
		public SettingsForm(GUI.GUI _myGUI)
		{
			this.myGUI = _myGUI;
			InitializeComponent();
		}
		
		void SettingsFormLoad(object sender, EventArgs e)
		{
			textBox1.Text = "" + Engine.Settings.MEMORYSIZE;
			textBox2.Text = "" + Engine.Settings.MAXCORESPERPLAYER;
			textBox3.Text = "" + Engine.Settings.MAXLENGTH;
			textBox4.Text = "" + Engine.Settings.MAXCYCLES;
            textBox5.Text = "" + Engine.Settings.CODEDISTANCE;
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
			try{
				Engine.Settings.MEMORYSIZE = Convert.ToInt32(textBox1.Text);
			}catch(Exception){
				MessageBox.Show("Die Eingabe hat das falsche Format!","Falsches Format",MessageBoxButtons.OK);
				textBox1.Text = "" + Engine.Settings.MEMORYSIZE;
			}
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			try{
				Engine.Settings.MAXCORESPERPLAYER = Convert.ToInt32(textBox2.Text);
			}catch(Exception){
				MessageBox.Show("Die Eingabe hat das falsche Format!","Falsches Format",MessageBoxButtons.OK);
				textBox2.Text = "" + Engine.Settings.MAXCORESPERPLAYER;
			}
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			try{
				Engine.Settings.MAXLENGTH = Convert.ToInt32(textBox3.Text);
			}catch(Exception){
				MessageBox.Show("Die Eingabe hat das falsche Format!","Falsches Format",MessageBoxButtons.OK);
				textBox3.Text = "" + Engine.Settings.MAXLENGTH;
			}
		}
        
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			try{
				Engine.Settings.MAXCYCLES = Convert.ToInt32(textBox4.Text);
			}catch(Exception){
				MessageBox.Show("Die Eingabe hat das falsche Format!","Falsches Format",MessageBoxButtons.OK);
				textBox4.Text = "" + Engine.Settings.MAXCYCLES;
			}
			
		}

        private void TextBox5TextChanged(object sender, EventArgs e)
        {
            try
            {
                Engine.Settings.CODEDISTANCE = Convert.ToInt32(textBox5.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                textBox5.Text = "" + Engine.Settings.CODEDISTANCE;
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

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
		
		void SettingsFormFormClosed(object sender, FormClosedEventArgs e)
		{
			myGUI.changedSettings();
		}
	}
}

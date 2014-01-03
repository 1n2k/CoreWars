using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CoreWars
{
	namespace GUI
	{
		public partial class SettingsForm : Form
		{
			bool initializing = true;
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
				if (myGUI.standard == Engine.IO.Compiler.Standard._94)
				{
					radioButton2.Checked = true;
				}
				else
				{
					radioButton1.Checked = true;
				}
				initializing = false;
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
				if (radioButton1.Checked && !initializing)
				{
					radioButton2.Checked = false;
					myGUI.standard = Engine.IO.Compiler.Standard._88;
					if(myGUI.players.Count != 0){
						List<int> oldNotWorkingPlayerIndices = new List<int>();
						List<Engine.Simulator.Player> oldNotWorkingPlayers = new List<CoreWars.Engine.Simulator.Player>();
						List<Engine.Simulator.Player> oldPlayers = new List<CoreWars.Engine.Simulator.Player>(myGUI.players);
						List<Engine.Simulator.Player> tempPlayers = new List<CoreWars.Engine.Simulator.Player>();
						for (int i = 0; i < oldPlayers.Count; i++) {
							try
							{
								string[] code = new string[oldPlayers[i].Code.Count];
								for (int j = 0; j < code.Length; j++) {
									code[j] = oldPlayers[i].Code[j].ToString();
								}
								myGUI.newPlayer(false, CoreWars.Engine.IO.Compiler.ParseCodeFile(code, myGUI.standard, oldPlayers[i].Name), i);
							}
							catch(InvalidOperationException ex){
								oldNotWorkingPlayers.Add(oldPlayers[i]);
								oldNotWorkingPlayerIndices.Add(i);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, "Es ist ein Fehler aufgetreten", MessageBoxButtons.OK);
								oldNotWorkingPlayers.Add(oldPlayers[i]);
								oldNotWorkingPlayerIndices.Add(i);
							}
						}
						if(oldNotWorkingPlayers.Count == 1){
							MessageBox.Show("Der Code des Spielers " + oldNotWorkingPlayers[0].Name + " konnte nicht in den neuen Standard übersetzt werden. Bitte korrigieren sie den Code dieses Spielers.", "Fehler beim Wechsel des Standards", MessageBoxButtons.OK);
						}
						if(oldNotWorkingPlayers.Count > 1){
							string playerNames = "";
							playerNames += oldNotWorkingPlayers[0].Name;
							for (int i = 1; i < oldNotWorkingPlayers.Count; i++) {
								playerNames += ", " + oldNotWorkingPlayers[i];
							}
							MessageBox.Show("Der Code der Spieler " + playerNames + " konnte nicht in den neuen Standard übersetzt werden. Bitte korrigieren sie den Code dieser Spieler.", "Fehler beim Wechsel des Standards", MessageBoxButtons.OK);
						}
						for (int i = 0; i < oldNotWorkingPlayers.Count; i++) {
							PlayerForm playerForm = new PlayerForm(myGUI, oldNotWorkingPlayerIndices[i], oldNotWorkingPlayers[i]);
							playerForm.ShowDialog();
						}
					}
				}
			}

			private void radioButton2_CheckedChanged(object sender, EventArgs e)
			{
				if (radioButton2.Checked && !initializing)
				{
					radioButton1.Checked = false;
					myGUI.standard = Engine.IO.Compiler.Standard._94;
					if(myGUI.players.Count != 0){
						List<int> oldNotWorkingPlayerIndices = new List<int>();
						List<Engine.Simulator.Player> oldNotWorkingPlayers = new List<CoreWars.Engine.Simulator.Player>();
						List<Engine.Simulator.Player> oldPlayers = new List<CoreWars.Engine.Simulator.Player>(myGUI.players);
						List<Engine.Simulator.Player> tempPlayers = new List<CoreWars.Engine.Simulator.Player>();
						for (int i = 0; i < oldPlayers.Count; i++) {
							try
							{
								string[] code = new string[oldPlayers[i].Code.Count];
								for (int j = 0; j < code.Length; j++) {
									code[j] = oldPlayers[i].Code[j].ToString();
								}
								myGUI.newPlayer(false, CoreWars.Engine.IO.Compiler.ParseCodeFile(code, myGUI.standard, oldPlayers[i].Name), i);
							}
							catch(InvalidOperationException ex){
								oldNotWorkingPlayers.Add(oldPlayers[i]);
								oldNotWorkingPlayerIndices.Add(i);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, "Es ist ein Fehler aufgetreten", MessageBoxButtons.OK);
								oldNotWorkingPlayers.Add(oldPlayers[i]);
								oldNotWorkingPlayerIndices.Add(i);
							}
						}
						if(oldNotWorkingPlayers.Count == 1){
							MessageBox.Show("Der Code des Spielers " + oldNotWorkingPlayers[0].Name + " konnte nicht in den neuen Standard übersetzt werden. Bitte korrigieren sie den Code dieses Spielers.", "Fehler beim Wechsel des Standards", MessageBoxButtons.OK);
						}
						if(oldNotWorkingPlayers.Count > 1){
							string playerNames = "";
							playerNames += oldNotWorkingPlayers[0].Name;
							for (int i = 1; i < oldNotWorkingPlayers.Count; i++) {
								playerNames += ", " + oldNotWorkingPlayers[i];
							}
							MessageBox.Show("Der Code der Spieler " + playerNames + " konnte nicht in den neuen Standard übersetzt werden. Bitte korrigieren sie den Code dieser Spieler.", "Fehler beim Wechsel des Standards", MessageBoxButtons.OK);
						}
						for (int i = 0; i < oldNotWorkingPlayers.Count; i++) {
							PlayerForm playerForm = new PlayerForm(myGUI, oldNotWorkingPlayerIndices[i], oldNotWorkingPlayers[i]);
							playerForm.ShowDialog();
						}
					}
				}
			}

			private void button1_Click(object sender, EventArgs e)
			{
				this.Close();
			}
		}
	}
}
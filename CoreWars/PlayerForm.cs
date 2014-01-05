﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

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

            private void button1_Click(object sender, EventArgs e)      //Ok
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Bitte geben sie einen Namen für den Spieler ein.", "Kein Name vorhanden", MessageBoxButtons.OK);
                }
                else if (textBox2.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "") == "")
                {
                    MessageBox.Show("Bitte geben sie den Code für den Spieler ein.", "Kein Code vorhanden", MessageBoxButtons.OK);
                }
                else if (myGUI.listboxContains(textBox1.Text))
                {
                    MessageBox.Show("Dieser Spielername wird schon verwendet. Bitte geben sie einen anderen Namen für den Spieler ein.", "Name schon verwendet", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        myGUI.newPlayer(isNewPlayer, CoreWars.Engine.IO.Compiler.ParseCodeFile(textBox2.Text.Split('\n'), myGUI.standard, textBox1.Text), index);
                    }
                    catch (InvalidOperationException)
                    {
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
            }

            private void button2_Click(object sender, EventArgs e)      //Abbrechen
            {
                this.Close();
            }

            private void button3_Click(object sender, EventArgs e)      //Code speichern
            {
                try
                {
                    saveFileDialog1.FileName = Path.Combine(saveFileDialog1.InitialDirectory, textBox1.Text + ".txt");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                        streamWriter.WriteLine(textBox1.Text);
                        streamWriter.Write(textBox2.Text);
                        streamWriter.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Es ist ein Fehler aufgetreten", MessageBoxButtons.OK);
                }
            }

            private void button4_Click(object sender, EventArgs e)      //Code laden
            {
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                            textBox1.Text = streamReader.ReadLine();
                            textBox2.Text = streamReader.ReadToEnd();
                            streamReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Es ist ein Fehler aufgetreten", MessageBoxButtons.OK);
                }
            }
        }
    }
}
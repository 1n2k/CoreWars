using System;
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
            bool needCorrection;

            public PlayerForm(GUI GUI, int _index = -1, Engine.Simulator.Player player = null)
            {
                this.FormClosed += new FormClosedEventHandler(PlayerForm_FormClosed);
                myGUI = GUI;
                this.Icon = myGUI.Icon;
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
                if (needCorrection)
                {
                    myGUI.changePlayer(index);
                }
            }

            private void PlayerForm_Load(object sender, EventArgs e)
            {
                needCorrection = false;
                foreach (Engine.Simulator.Cell cell in myPlayer.Code)
                {
                    textbox2.Text += cell.ToString() + "\r\n";
                }
                textbox1.Text = myPlayer.Name;
            }

            private void button1_Click(object sender, EventArgs e)      //Ok
            {
                if (textbox1.Text == "")
                {
                    if (!Engine.Simulator.Settings.Tan)
                        MessageBox.Show("Bitte geben sie einen Namen für den Spieler ein.", "Kein Name vorhanden", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Don't wanna have a name, little fish?", "Hey! I need to name you...", MessageBoxButtons.OK);
                }
                else if (textbox2.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "") == "")
                {
                    if (!Engine.Simulator.Settings.Tan)
                        MessageBox.Show("Bitte geben sie den Code für den Spieler ein.", "Kein Code vorhanden", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Huh? No work for me?", "EMPTY?!", MessageBoxButtons.OK);
                }
                else if (isNewPlayer && myGUI.listboxContains(textbox1.Text))
                {
                    if (!Engine.Simulator.Settings.Tan)
                        MessageBox.Show("Dieser Spielername wird schon verwendet. Bitte geben sie einen anderen Namen für den Spieler ein.",
                            "Name schon verwendet", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("Hm. I already know about him. Did ya mean somethin' else?",
                            "Every fish is unique...", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        myGUI.newPlayer(isNewPlayer, CoreWars.Engine.IO.Compiler.ParseCodeFile(textbox2.Text.Split('\n'), myGUI.standard, textbox1.Text), index);
                    }
                    catch (InvalidOperationException ex)
                    {
                        if(!Engine.Simulator.Settings.Tan)
                            MessageBox.Show("Der Code des Spielers " + myPlayer.Name
                                + " ist nicht mit dem ausgewählten Standard kompatibel.\nBitte korrigieren sie den Code dieses Spielers.",
                                "Fehler beim Erstellen eines neuen Spielers", MessageBoxButtons.OK);
                        else
                            MessageBox.Show(ex.Message, "Ooops. She crashed!", MessageBoxButtons.OK);
                        //myGUI.changePlayer(index);
                        needCorrection = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ihr Programm ist fehlerhaft:\n" + ex.Message, "Ooops. She crashed!", MessageBoxButtons.OK);
                        //myGUI.changePlayer(index);
                        needCorrection = true;
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
                    saveFileDialog1.FileName = Path.Combine(saveFileDialog1.InitialDirectory, textbox1.Text);
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                        bool containsname = false;
                        foreach (var item in textbox2.Lines)
                        {
                            if(item.StartsWith(";name"))
                                containsname = true;
                        }
                        if(!containsname)
                            streamWriter.WriteLine(";name="+textbox1.Text);
                        streamWriter.Write(textbox2.Text);
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
                            textbox2.Text = streamReader.ReadToEnd();
                            foreach (var item in textbox2.Lines)
                            {
                                if (item.StartsWith(";author") && item.Contains("="))
                                {
                                    textbox1.Text = item.Split('=')[1];
                                    break;
                                }
                                else if (item.StartsWith(";author"))
                                {
                                    textbox1.Text = item.Replace(";author","").TrimStart(' ');
                                    break;
                                }
                            }
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
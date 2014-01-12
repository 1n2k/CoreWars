using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoreWars
{
    namespace GUI
    {
        public partial class NoGraphicForm : Form
        {
            private GUI myGUI;
            int currentValue;
            public NoGraphicForm(GUI _GUI)
            {
                myGUI = _GUI;
                this.Icon = myGUI.Icon;
                InitializeComponent();
            }

            private void NoGraphicForm_Load(object sender, EventArgs e)
            {
            	Engine.Simulator.Game.GetGame.MemoryCellChanged += new Engine.Simulator.MemoryCellChangedEventHandler(Engine_Simulator_MemoryCellChangedEventHandler);
                trackBar1.Maximum = Engine.Simulator.Settings.MEMORYSIZE - 1;
                trackBar1.Minimum = 0;
                trackBar1.Value = Engine.Simulator.Settings.MEMORYSIZE - 1;
                textBox1.Text = 0 + "";
                currentValue = 0;
            }

            void Engine_Simulator_MemoryCellChangedEventHandler(object sender, Engine.Simulator.MemoryCellChangedEventArgs e)
            {
            	changeLabels();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    currentValue = Convert.ToInt32(textBox1.Text);
                    changeLabels();
                }
                catch (Exception)
                {
                    MessageBox.Show("Die Eingabe hat das falsche Format!", "Falsches Format", MessageBoxButtons.OK);
                    textBox1.Text = currentValue + "";
                }
            }

            private void trackBar1_ValueChanged(object sender, EventArgs e)
            {
                currentValue = Engine.Simulator.Settings.MEMORYSIZE - 1 - trackBar1.Value;
                changeLabels();
            }

            private void changeLabels()
            {
                label1.Text = (currentValue - 4 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + Engine.Simulator.Settings.MEMORYSIZE - 4) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label2.Text = (currentValue - 3 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue - 3 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label3.Text = (currentValue - 2 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue - 2 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label4.Text = (currentValue - 1 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue - 1 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label5.Text = (currentValue + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label6.Text = (currentValue + 1 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + 1 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label7.Text = (currentValue + 2 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + 2 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label8.Text = (currentValue + 3 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + 3 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label9.Text = (currentValue + 4 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + 4 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
                label10.Text = (currentValue + 5 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE + ": " + Engine.Simulator.Game.GetGame[(currentValue + 5 + Engine.Simulator.Settings.MEMORYSIZE) % Engine.Simulator.Settings.MEMORYSIZE].ToString();
            }
        }
    }
}

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
    public partial class NoGraphicForm : Form
    {
        int currentValue;
        public NoGraphicForm()
        {
            InitializeComponent();
        }

        private void NoGraphicForm_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = Engine.Settings.MEMORYSIZE - 1;
            trackBar1.Minimum = 0;
            trackBar1.Value = Engine.Settings.MEMORYSIZE - 1;
            textBox1.Text = 0 + "";
            currentValue = 0;
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
            currentValue = Engine.Settings.MEMORYSIZE - 1 - trackBar1.Value;
            changeLabels();
        }

        private void changeLabels()
        {
            label1.Text = (currentValue - 4+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": "+ Engine.Game.GetGame[(currentValue + Engine.Settings.MEMORYSIZE - 4)%Engine.Settings.MEMORYSIZE].ToString();
            label2.Text = (currentValue - 3+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue - 3 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label3.Text = (currentValue - 2+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue - 2 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label4.Text = (currentValue - 1+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue - 1 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label5.Text = (currentValue + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label6.Text = (currentValue + 1+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue + 1 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label7.Text = (currentValue + 2+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue + 2 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label8.Text = (currentValue + 3+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue + 3 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label9.Text = (currentValue + 4+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue + 4 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
            label10.Text = (currentValue + 5+ Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE + ": " + Engine.Game.GetGame[(currentValue + 5 + Engine.Settings.MEMORYSIZE) % Engine.Settings.MEMORYSIZE].ToString();
        }
    }
}

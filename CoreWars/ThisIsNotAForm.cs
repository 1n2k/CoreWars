using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace CoreWars
{
    namespace GUI
    {
        public partial class ThisIsNotAForm : Form
        {
            GUI myGUI;
            public int xRectangles;
            public int yRectangles;
            public int restXRectangles;
            Graphics G;

            public ThisIsNotAForm(GUI _GUI)
            {
                InitializeComponent();
                myGUI = _GUI;
                myGUI.DrawRectangle += new GUI.DrawRectangleEventHandler(myGUI_DrawRectangle);

                DoubleBuffered = true;
                xRectangles = (int)Math.Round(Math.Sqrt(Engine.Settings.MEMORYSIZE));
                yRectangles = (int)Math.Round((double)(Engine.Settings.MEMORYSIZE / xRectangles));
                restXRectangles = Engine.Settings.MEMORYSIZE - (xRectangles * yRectangles);
                if (restXRectangles == 0)
                {
                    Size = new System.Drawing.Size(15 + 7 * xRectangles, 30 + 7 * yRectangles);
                }
                else
                {
                    Size = new System.Drawing.Size(15 + 7 * xRectangles, 30 + 7 * (yRectangles + 1));
                }
                pictureBox1.Image = new Bitmap(15 + 7 * xRectangles, 30 + 7 * yRectangles);
                G = Graphics.FromImage(pictureBox1.Image);
            }

            void myGUI_DrawRectangle(object sender, GUI.DrawRectangleEventArgs e)
            {
                G.DrawRectangle(new Pen(e.color, 3), e.x, e.y, 3, 3);
                //drawRectangle(e.x, e.y, e.color);
            }

            private void ThisIsNotAForm_Load(object sender, EventArgs e)
            {
            }
        }
    }
}
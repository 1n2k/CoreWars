namespace CoreWars
{
    namespace GUI
    {
        partial class GUI
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.button4 = new System.Windows.Forms.Button();
                this.button5 = new System.Windows.Forms.Button();
                this.button6 = new System.Windows.Forms.Button();
                this.trackBar1 = new System.Windows.Forms.TrackBar();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.button7 = new System.Windows.Forms.Button();
                this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
                this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
                this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
                this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
                this.timer = new Multimedia.Timer();
                this.button8 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
                this.statusStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // listBox1
                // 
                this.listBox1.FormattingEnabled = true;
                this.listBox1.Location = new System.Drawing.Point(7, 260);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(107, 82);
                this.listBox1.TabIndex = 1;
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(120, 290);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(131, 23);
                this.button1.TabIndex = 2;
                this.button1.Text = "Spieler bearbeiten";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(120, 261);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(131, 23);
                this.button2.TabIndex = 3;
                this.button2.Text = "Spieler hinzufügen";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(120, 319);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(131, 23);
                this.button3.TabIndex = 4;
                this.button3.Text = "Spieler löschen";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // button4
                // 
                this.button4.Location = new System.Drawing.Point(7, 202);
                this.button4.Name = "button4";
                this.button4.Size = new System.Drawing.Size(48, 23);
                this.button4.TabIndex = 5;
                this.button4.Text = "Start";
                this.button4.UseVisualStyleBackColor = true;
                this.button4.Click += new System.EventHandler(this.button4_Click);
                // 
                // button5
                // 
                this.button5.Location = new System.Drawing.Point(115, 202);
                this.button5.Name = "button5";
                this.button5.Size = new System.Drawing.Size(48, 23);
                this.button5.TabIndex = 6;
                this.button5.Text = "Stopp";
                this.button5.UseVisualStyleBackColor = true;
                this.button5.Click += new System.EventHandler(this.button5_Click);
                // 
                // button6
                // 
                this.button6.Location = new System.Drawing.Point(7, 231);
                this.button6.Name = "button6";
                this.button6.Size = new System.Drawing.Size(156, 23);
                this.button6.TabIndex = 7;
                this.button6.Text = "Einzelner Schritt";
                this.button6.UseVisualStyleBackColor = true;
                this.button6.Click += new System.EventHandler(this.button6_Click);
                // 
                // trackBar1
                // 
                this.trackBar1.AccessibleDescription = "";
                this.trackBar1.AccessibleName = "";
                this.trackBar1.Location = new System.Drawing.Point(257, 208);
                this.trackBar1.Minimum = 1;
                this.trackBar1.Maximum = 1000;
                this.trackBar1.Name = "trackBar1";
                this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
                this.trackBar1.Size = new System.Drawing.Size(34, 140);
                this.trackBar1.TabIndex = 8;
                this.trackBar1.Value = 1;
                this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(287, 213);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(40, 13);
                this.label1.TabIndex = 9;
                this.label1.Text = "schnell";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(287, 325);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(46, 13);
                this.label2.TabIndex = 10;
                this.label2.Text = "langsam";
                // 
                // button7
                // 
                this.button7.Location = new System.Drawing.Point(61, 202);
                this.button7.Name = "button7";
                this.button7.Size = new System.Drawing.Size(48, 23);
                this.button7.TabIndex = 11;
                this.button7.Text = "Pause";
                this.button7.UseVisualStyleBackColor = true;
                this.button7.Click += new System.EventHandler(this.button7_Click);
                // 
                // statusStrip1
                // 
                this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
                this.statusStrip1.Location = new System.Drawing.Point(0, 351);
                this.statusStrip1.Name = "statusStrip1";
                this.statusStrip1.Size = new System.Drawing.Size(339, 22);
                this.statusStrip1.TabIndex = 12;
                this.statusStrip1.Text = "statusStrip1";
                // 
                // toolStripProgressBar1
                // 
                this.toolStripProgressBar1.Name = "toolStripProgressBar1";
                this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
                // 
                // toolStripStatusLabel1
                // 
                this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
                this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 17);
                this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
                // 
                // toolStripStatusLabel2
                // 
                this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
                this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 17);
                this.toolStripStatusLabel2.Text = "/";
                // 
                // toolStripStatusLabel3
                // 
                this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
                this.toolStripStatusLabel3.Size = new System.Drawing.Size(107, 13);
                this.toolStripStatusLabel3.Text = "toolStripStatusLabel1";
                // 
                // timer
                // 
                this.timer.Tick += new System.EventHandler(timer_Tick);
                // 
                // button8
                // 
                this.button8.Location = new System.Drawing.Point(169, 202);
                this.button8.Name = "button8";
                this.button8.Size = new System.Drawing.Size(82, 52);
                this.button8.TabIndex = 13;
                this.button8.Text = "Einstellungen";
                this.button8.UseVisualStyleBackColor = true;
                this.button8.Click += new System.EventHandler(this.button8_Click);
                // 
                // GUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(339, 373);
                this.Controls.Add(this.button8);
                this.Controls.Add(this.statusStrip1);
                this.Controls.Add(this.button7);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.trackBar1);
                this.Controls.Add(this.button6);
                this.Controls.Add(this.button5);
                this.Controls.Add(this.button4);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.listBox1);
                this.Name = "GUI";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.GUI_Load);
                ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
                this.statusStrip1.ResumeLayout(false);
                this.statusStrip1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.ListBox listBox1;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button3;
            private System.Windows.Forms.Button button4;
            private System.Windows.Forms.Button button5;
            private System.Windows.Forms.Button button6;
            private System.Windows.Forms.TrackBar trackBar1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Button button7;
            private System.Windows.Forms.StatusStrip statusStrip1;
            private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
            private System.Windows.Forms.Button button8;
            private Multimedia.Timer timer;
        }
    }
}


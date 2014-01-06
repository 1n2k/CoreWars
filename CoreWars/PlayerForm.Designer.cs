/*
 * Erstellt mit SharpDevelop.
 * Benutzer: robert
 * Datum: 09.12.2013
 * Zeit: 15:30
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace CoreWars
{
    namespace GUI
    {
        partial class PlayerForm
        {
            /// <summary>
            /// Designer variable used to keep track of non-visual components.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Disposes resources used by the form.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

            /// <summary>
            /// This method is required for Windows Forms designer support.
            /// Do not change the method contents inside the source code editor. The Forms designer might
            /// not be able to load this method if it was changed manually.
            /// </summary>
            private void InitializeComponent()
            {
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.textBox2 = new System.Windows.Forms.TextBox();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.button4 = new System.Windows.Forms.Button();
                this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.splitContainer1 = new System.Windows.Forms.SplitContainer();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.groupBox1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
                this.splitContainer1.Panel1.SuspendLayout();
                this.splitContainer1.Panel2.SuspendLayout();
                this.splitContainer1.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.SuspendLayout();
                // 
                // textBox1
                // 
                this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.textBox1.Location = new System.Drawing.Point(3, 16);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(271, 20);
                this.textBox1.TabIndex = 1;
                // 
                // textBox2
                // 
                this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.textBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                this.textBox2.Location = new System.Drawing.Point(3, 16);
                this.textBox2.Multiline = true;
                this.textBox2.Name = "textBox2";
                this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                this.textBox2.Size = new System.Drawing.Size(271, 281);
                this.textBox2.TabIndex = 2;
                // 
                // button1
                // 
                this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.button1.Location = new System.Drawing.Point(0, 0);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(137, 28);
                this.button1.TabIndex = 5;
                this.button1.Text = "OK";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.button2.Location = new System.Drawing.Point(0, 0);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(136, 28);
                this.button2.TabIndex = 6;
                this.button2.Text = "Abbrechen";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button3
                // 
                this.button3.AutoSize = true;
                this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.button3.Location = new System.Drawing.Point(3, 320);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(271, 23);
                this.button3.TabIndex = 4;
                this.button3.Text = "Programm speichern";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // button4
                // 
                this.button4.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.button4.Location = new System.Drawing.Point(3, 297);
                this.button4.Name = "button4";
                this.button4.Size = new System.Drawing.Size(271, 23);
                this.button4.TabIndex = 3;
                this.button4.Text = "Programm laden";
                this.button4.UseVisualStyleBackColor = true;
                this.button4.Click += new System.EventHandler(this.button4_Click);
                // 
                // openFileDialog1
                // 
                this.openFileDialog1.Filter = "RedCode-Dateien|*.red|Text-Dateien|*.txt|Alle Dateien|*.*";
                // 
                // saveFileDialog1
                // 
                this.saveFileDialog1.Filter = "RedCode-Dateien|*.red";
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.textBox2);
                this.groupBox1.Controls.Add(this.button4);
                this.groupBox1.Controls.Add(this.button3);
                this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.groupBox1.Location = new System.Drawing.Point(0, 46);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(277, 346);
                this.groupBox1.TabIndex = 7;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "Code";
                // 
                // splitContainer1
                // 
                this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.splitContainer1.IsSplitterFixed = true;
                this.splitContainer1.Location = new System.Drawing.Point(0, 392);
                this.splitContainer1.Name = "splitContainer1";
                // 
                // splitContainer1.Panel1
                // 
                this.splitContainer1.Panel1.Controls.Add(this.button1);
                // 
                // splitContainer1.Panel2
                // 
                this.splitContainer1.Panel2.Controls.Add(this.button2);
                this.splitContainer1.Size = new System.Drawing.Size(277, 28);
                this.splitContainer1.SplitterDistance = 137;
                this.splitContainer1.TabIndex = 10;
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.textBox1);
                this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
                this.groupBox2.Location = new System.Drawing.Point(0, 0);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(277, 46);
                this.groupBox2.TabIndex = 11;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "Name des Spielers";
                // 
                // PlayerForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(277, 420);
                this.ControlBox = false;
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.splitContainer1);
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "PlayerForm";
                this.Text = "Spieler bearbeiten";
                this.Load += new System.EventHandler(this.PlayerForm_Load);
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.splitContainer1.Panel1.ResumeLayout(false);
                this.splitContainer1.Panel2.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
                this.splitContainer1.ResumeLayout(false);
                this.groupBox2.ResumeLayout(false);
                this.groupBox2.PerformLayout();
                this.ResumeLayout(false);

            }
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.TextBox textBox2;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button3;
            private System.Windows.Forms.Button button4;
            private System.Windows.Forms.OpenFileDialog openFileDialog1;
            private System.Windows.Forms.SaveFileDialog saveFileDialog1;
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.SplitContainer splitContainer1;
            private System.Windows.Forms.GroupBox groupBox2;
        }
    }
}
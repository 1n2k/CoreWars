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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.editPlayerButton = new System.Windows.Forms.Button();
                this.newPlayerButton = new System.Windows.Forms.Button();
                this.deletePlayerButton = new System.Windows.Forms.Button();
                this.startGameButton = new System.Windows.Forms.Button();
                this.stopGameButton = new System.Windows.Forms.Button();
                this.singleStepButton = new System.Windows.Forms.Button();
                this.trackBar1 = new System.Windows.Forms.TrackBar();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.pauseGameButton = new System.Windows.Forms.Button();
                this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
                this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
                this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
                this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
                this.openSettingsButton = new System.Windows.Forms.Button();
                this.timer = new Multimedia.Timer(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
                this.statusStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // listBox1
                // 
                this.listBox1.FormattingEnabled = true;
                this.listBox1.Location = new System.Drawing.Point(11, 70);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(107, 82);
                this.listBox1.TabIndex = 0;
                this.listBox1.TabStop = false;
                // 
                // editPlayerButton
                // 
                this.editPlayerButton.Location = new System.Drawing.Point(124, 100);
                this.editPlayerButton.Name = "editPlayerButton";
                this.editPlayerButton.Size = new System.Drawing.Size(131, 23);
                this.editPlayerButton.TabIndex = 7;
                this.editPlayerButton.Text = "Spieler bearbeiten";
                this.editPlayerButton.UseVisualStyleBackColor = true;
                this.editPlayerButton.Click += new System.EventHandler(this.editPlayerButton_Click);
                // 
                // newPlayerButton
                // 
                this.newPlayerButton.Location = new System.Drawing.Point(124, 71);
                this.newPlayerButton.Name = "newPlayerButton";
                this.newPlayerButton.Size = new System.Drawing.Size(131, 23);
                this.newPlayerButton.TabIndex = 6;
                this.newPlayerButton.Text = "Spieler hinzufügen";
                this.newPlayerButton.UseVisualStyleBackColor = true;
                this.newPlayerButton.Click += new System.EventHandler(this.newPlayerButton_Click);
                // 
                // deletePlayerButton
                // 
                this.deletePlayerButton.Location = new System.Drawing.Point(124, 129);
                this.deletePlayerButton.Name = "deletePlayerButton";
                this.deletePlayerButton.Size = new System.Drawing.Size(131, 23);
                this.deletePlayerButton.TabIndex = 8;
                this.deletePlayerButton.Text = "Spieler löschen";
                this.deletePlayerButton.UseVisualStyleBackColor = true;
                this.deletePlayerButton.Click += new System.EventHandler(this.deletePlayerButton_Click);
                // 
                // startGameButton
                // 
                this.startGameButton.Location = new System.Drawing.Point(11, 12);
                this.startGameButton.Name = "startGameButton";
                this.startGameButton.Size = new System.Drawing.Size(48, 23);
                this.startGameButton.TabIndex = 1;
                this.startGameButton.Text = "Start";
                this.startGameButton.UseVisualStyleBackColor = true;
                this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
                // 
                // stopGameButton
                // 
                this.stopGameButton.Location = new System.Drawing.Point(119, 12);
                this.stopGameButton.Name = "stopGameButton";
                this.stopGameButton.Size = new System.Drawing.Size(48, 23);
                this.stopGameButton.TabIndex = 3;
                this.stopGameButton.Text = "Stopp";
                this.stopGameButton.UseVisualStyleBackColor = true;
                this.stopGameButton.Click += new System.EventHandler(this.stopGameButton_Click);
                // 
                // singleStepButton
                // 
                this.singleStepButton.Location = new System.Drawing.Point(11, 41);
                this.singleStepButton.Name = "singleStepButton";
                this.singleStepButton.Size = new System.Drawing.Size(156, 23);
                this.singleStepButton.TabIndex = 4;
                this.singleStepButton.Text = "Einzelner Schritt";
                this.singleStepButton.UseVisualStyleBackColor = true;
                this.singleStepButton.Click += new System.EventHandler(this.singleStepButton_Click);
                // 
                // trackBar1
                // 
                this.trackBar1.AccessibleDescription = "";
                this.trackBar1.AccessibleName = "";
                this.trackBar1.Location = new System.Drawing.Point(261, 12);
                this.trackBar1.Maximum = 1000;
                this.trackBar1.Minimum = 1;
                this.trackBar1.Name = "trackBar1";
                this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
                this.trackBar1.Size = new System.Drawing.Size(45, 146);
                this.trackBar1.TabIndex = 0;
                this.trackBar1.TabStop = false;
                this.trackBar1.Value = 1;
                this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(291, 17);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(40, 13);
                this.label1.TabIndex = 9;
                this.label1.Text = "schnell";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(291, 135);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(46, 13);
                this.label2.TabIndex = 10;
                this.label2.Text = "langsam";
                // 
                // pauseGameButton
                // 
                this.pauseGameButton.Location = new System.Drawing.Point(65, 12);
                this.pauseGameButton.Name = "pauseGameButton";
                this.pauseGameButton.Size = new System.Drawing.Size(48, 23);
                this.pauseGameButton.TabIndex = 2;
                this.pauseGameButton.Text = "Pause";
                this.pauseGameButton.UseVisualStyleBackColor = true;
                this.pauseGameButton.Click += new System.EventHandler(this.pauseGameButton_Click);
                // 
                // statusStrip1
                // 
                this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
                this.statusStrip1.Location = new System.Drawing.Point(0, 159);
                this.statusStrip1.Name = "statusStrip1";
                this.statusStrip1.Size = new System.Drawing.Size(339, 22);
                this.statusStrip1.SizingGrip = false;
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
                this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
                this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
                // 
                // toolStripStatusLabel2
                // 
                this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
                this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
                this.toolStripStatusLabel2.Text = "/";
                // 
                // toolStripStatusLabel3
                // 
                this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
                this.toolStripStatusLabel3.Size = new System.Drawing.Size(109, 17);
                this.toolStripStatusLabel3.Text = "toolStripStatusLabel1";
                // 
                // openSettingsButton
                // 
                this.openSettingsButton.Location = new System.Drawing.Point(173, 12);
                this.openSettingsButton.Name = "openSettingsButton";
                this.openSettingsButton.Size = new System.Drawing.Size(82, 52);
                this.openSettingsButton.TabIndex = 5;
                this.openSettingsButton.Text = "Einstellungen";
                this.openSettingsButton.UseVisualStyleBackColor = true;
                this.openSettingsButton.Click += new System.EventHandler(this.openSettingsButton_Click);
                // 
                // timer
                // 
                this.timer.Mode = Multimedia.TimerMode.Periodic;
                this.timer.Period = 1;
                this.timer.Resolution = 1;
                this.timer.SynchronizingObject = null;
                // 
                // GUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(339, 181);
                this.Controls.Add(this.openSettingsButton);
                this.Controls.Add(this.statusStrip1);
                this.Controls.Add(this.pauseGameButton);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.trackBar1);
                this.Controls.Add(this.singleStepButton);
                this.Controls.Add(this.stopGameButton);
                this.Controls.Add(this.startGameButton);
                this.Controls.Add(this.deletePlayerButton);
                this.Controls.Add(this.newPlayerButton);
                this.Controls.Add(this.editPlayerButton);
                this.Controls.Add(this.listBox1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MaximumSize = new System.Drawing.Size(345, 213);
                this.Name = "GUI";
                this.Text = "Core War";
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
                this.Load += new System.EventHandler(this.GUI_Load);
                ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
                this.statusStrip1.ResumeLayout(false);
                this.statusStrip1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.ListBox listBox1;
            private System.Windows.Forms.Button editPlayerButton;
            private System.Windows.Forms.Button newPlayerButton;
            private System.Windows.Forms.Button deletePlayerButton;
            private System.Windows.Forms.Button startGameButton;
            private System.Windows.Forms.Button stopGameButton;
            private System.Windows.Forms.Button singleStepButton;
            private System.Windows.Forms.TrackBar trackBar1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Button pauseGameButton;
            private System.Windows.Forms.StatusStrip statusStrip1;
            private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
            private System.Windows.Forms.Button openSettingsButton;
            private Multimedia.Timer timer;
        }
    }
}


namespace ConnectFour
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.gameStepBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.runBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.loopsCb = new System.Windows.Forms.ToolStripComboBox();
            this.gameClearBtn = new System.Windows.Forms.ToolStripButton();
            this.stopBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.player1Lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.player2Lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.roundProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.playWorker = new System.ComponentModel.BackgroundWorker();
            this.playground1 = new ConnectFour.Gamefield();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStepBtn,
            this.toolStripSeparator1,
            this.runBtn,
            this.gameClearBtn,
            this.stopBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(307, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // gameStepBtn
            // 
            this.gameStepBtn.Image = global::ConnectFour.Properties.Resources.arrow_right;
            this.gameStepBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gameStepBtn.Name = "gameStepBtn";
            this.gameStepBtn.Size = new System.Drawing.Size(79, 22);
            this.gameStepBtn.Text = "Next move";
            this.gameStepBtn.Click += new System.EventHandler(this.gameStepBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // runBtn
            // 
            this.runBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loopsCb});
            this.runBtn.Image = global::ConnectFour.Properties.Resources.play;
            this.runBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(78, 22);
            this.runBtn.Text = "Autorun";
            this.runBtn.ButtonClick += new System.EventHandler(this.runBtn_ButtonClick);
            // 
            // loopsCb
            // 
            this.loopsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loopsCb.Items.AddRange(new object[] {
            "1",
            "10",
            "100",
            "500",
            "1000",
            "5000",
            "10000"});
            this.loopsCb.Name = "loopsCb";
            this.loopsCb.Size = new System.Drawing.Size(121, 21);
            this.loopsCb.SelectedIndexChanged += new System.EventHandler(this.loopsCb_SelectedIndexChanged);
            // 
            // gameClearBtn
            // 
            this.gameClearBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.gameClearBtn.Image = global::ConnectFour.Properties.Resources.arrow_refresh;
            this.gameClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gameClearBtn.Name = "gameClearBtn";
            this.gameClearBtn.Size = new System.Drawing.Size(77, 22);
            this.gameClearBtn.Text = "Clear Field";
            this.gameClearBtn.Click += new System.EventHandler(this.gameClearBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopBtn.Enabled = false;
            this.stopBtn.Image = global::ConnectFour.Properties.Resources.stop;
            this.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(23, 22);
            this.stopBtn.Text = "Stop";
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.player1Lbl,
            this.player2Lbl,
            this.roundProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(307, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // player1Lbl
            // 
            this.player1Lbl.BackColor = System.Drawing.Color.LightCoral;
            this.player1Lbl.Name = "player1Lbl";
            this.player1Lbl.Size = new System.Drawing.Size(65, 17);
            this.player1Lbl.Spring = true;
            this.player1Lbl.Text = "0";
            // 
            // player2Lbl
            // 
            this.player2Lbl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.player2Lbl.Name = "player2Lbl";
            this.player2Lbl.Size = new System.Drawing.Size(65, 17);
            this.player2Lbl.Spring = true;
            this.player2Lbl.Text = "0";
            // 
            // roundProgress
            // 
            this.roundProgress.Name = "roundProgress";
            this.roundProgress.Size = new System.Drawing.Size(160, 16);
            this.roundProgress.Step = 1;
            this.roundProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // playWorker
            // 
            this.playWorker.WorkerReportsProgress = true;
            this.playWorker.WorkerSupportsCancellation = true;
            this.playWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.playWorker_DoWork);
            this.playWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.playWorker_RunWorkerCompleted);
            this.playWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.playWorker_ProgressChanged);
            // 
            // playground1
            // 
            this.playground1.AntiAlias = true;
            this.playground1.BackColor = System.Drawing.Color.Transparent;
            this.playground1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground1.Location = new System.Drawing.Point(0, 25);
            this.playground1.Name = "playground1";
            this.playground1.Size = new System.Drawing.Size(307, 276);
            this.playground1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 323);
            this.Controls.Add(this.playground1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Connect Four - Simulation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gamefield playground1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton gameStepBtn;
        private System.Windows.Forms.ToolStripButton gameClearBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel player1Lbl;
        private System.Windows.Forms.ToolStripStatusLabel player2Lbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton runBtn;
        private System.Windows.Forms.ToolStripComboBox loopsCb;
        private System.Windows.Forms.ToolStripButton stopBtn;
        private System.ComponentModel.BackgroundWorker playWorker;
        private System.Windows.Forms.ToolStripProgressBar roundProgress;
    }
}


namespace SlotMachine {
    partial class SlotMachineScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
            xmlReader.updateJackpot(jackpotChance);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.backButton = new System.Windows.Forms.Button();
            this.spinButton = new System.Windows.Forms.Button();
            this.moreBet = new System.Windows.Forms.Button();
            this.lessBet = new System.Windows.Forms.Button();
            this.gambleButton = new System.Windows.Forms.Button();
            this.BetLabel = new System.Windows.Forms.Label();
            this.PaytableButton = new System.Windows.Forms.Button();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.WinLabel = new System.Windows.Forms.Label();
            this.SlotsColumns = new System.Windows.Forms.PictureBox();
            this.BackgroundImage = new System.Windows.Forms.PictureBox();
            this.muteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SlotsColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.Location = new System.Drawing.Point(535, 337);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(56, 19);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "button1";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // spinButton
            // 
            this.spinButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinButton.AutoSize = true;
            this.spinButton.BackColor = System.Drawing.Color.Red;
            this.spinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.spinButton.Location = new System.Drawing.Point(256, 313);
            this.spinButton.Margin = new System.Windows.Forms.Padding(2);
            this.spinButton.Name = "spinButton";
            this.spinButton.Size = new System.Drawing.Size(112, 43);
            this.spinButton.TabIndex = 3;
            this.spinButton.Text = "SPIN";
            this.spinButton.UseVisualStyleBackColor = false;
            this.spinButton.Click += new System.EventHandler(this.spinButton_Click);
            // 
            // moreBet
            // 
            this.moreBet.FlatAppearance.BorderSize = 0;
            this.moreBet.Location = new System.Drawing.Point(116, 340);
            this.moreBet.Margin = new System.Windows.Forms.Padding(2);
            this.moreBet.Name = "moreBet";
            this.moreBet.Size = new System.Drawing.Size(56, 19);
            this.moreBet.TabIndex = 4;
            this.moreBet.Text = "button1";
            this.moreBet.UseVisualStyleBackColor = true;
            this.moreBet.Click += new System.EventHandler(this.moreBet_Click);
            // 
            // lessBet
            // 
            this.lessBet.FlatAppearance.BorderSize = 0;
            this.lessBet.Location = new System.Drawing.Point(9, 337);
            this.lessBet.Margin = new System.Windows.Forms.Padding(2);
            this.lessBet.Name = "lessBet";
            this.lessBet.Size = new System.Drawing.Size(56, 19);
            this.lessBet.TabIndex = 5;
            this.lessBet.Text = "button1";
            this.lessBet.UseVisualStyleBackColor = true;
            this.lessBet.Click += new System.EventHandler(this.lessBet_Click);
            // 
            // gambleButton
            // 
            this.gambleButton.Location = new System.Drawing.Point(416, 337);
            this.gambleButton.Margin = new System.Windows.Forms.Padding(2);
            this.gambleButton.Name = "gambleButton";
            this.gambleButton.Size = new System.Drawing.Size(56, 19);
            this.gambleButton.TabIndex = 6;
            this.gambleButton.Text = "button1";
            this.gambleButton.UseVisualStyleBackColor = true;
            this.gambleButton.Click += new System.EventHandler(this.gambleButton_Click);
            // 
            // BetLabel
            // 
            this.BetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BetLabel.AutoSize = true;
            this.BetLabel.Location = new System.Drawing.Point(70, 342);
            this.BetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BetLabel.Name = "BetLabel";
            this.BetLabel.Size = new System.Drawing.Size(25, 13);
            this.BetLabel.TabIndex = 7;
            this.BetLabel.Text = "aaa";
            // 
            // PaytableButton
            // 
            this.PaytableButton.FlatAppearance.BorderSize = 0;
            this.PaytableButton.Location = new System.Drawing.Point(10, 29);
            this.PaytableButton.Margin = new System.Windows.Forms.Padding(2);
            this.PaytableButton.Name = "PaytableButton";
            this.PaytableButton.Size = new System.Drawing.Size(56, 19);
            this.PaytableButton.TabIndex = 8;
            this.PaytableButton.Text = "button1";
            this.PaytableButton.UseVisualStyleBackColor = true;
            this.PaytableButton.Click += new System.EventHandler(this.PaytableButton_Click);
            // 
            // CreditsLabel
            // 
            this.CreditsLabel.AutoSize = true;
            this.CreditsLabel.Location = new System.Drawing.Point(10, 106);
            this.CreditsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(35, 13);
            this.CreditsLabel.TabIndex = 9;
            this.CreditsLabel.Text = "label1";
            // 
            // WinLabel
            // 
            this.WinLabel.AutoSize = true;
            this.WinLabel.Location = new System.Drawing.Point(9, 158);
            this.WinLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WinLabel.Name = "WinLabel";
            this.WinLabel.Size = new System.Drawing.Size(35, 13);
            this.WinLabel.TabIndex = 10;
            this.WinLabel.Text = "label1";
            // 
            // SlotsColumns
            // 
            this.SlotsColumns.Image = global::SlotMachine.Properties.Resources.sluts;
            this.SlotsColumns.Location = new System.Drawing.Point(316, 9);
            this.SlotsColumns.Margin = new System.Windows.Forms.Padding(2);
            this.SlotsColumns.Name = "SlotsColumns";
            this.SlotsColumns.Size = new System.Drawing.Size(83, 81);
            this.SlotsColumns.TabIndex = 1;
            this.SlotsColumns.TabStop = false;
            this.SlotsColumns.Paint += new System.Windows.Forms.PaintEventHandler(this.SlotsColumns_Paint);
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.BackgroundImage.Location = new System.Drawing.Point(0, 0);
            this.BackgroundImage.Margin = new System.Windows.Forms.Padding(2);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(602, 370);
            this.BackgroundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackgroundImage.TabIndex = 0;
            this.BackgroundImage.TabStop = false;
            // 
            // muteButton
            // 
            this.muteButton.Location = new System.Drawing.Point(516, 25);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(75, 23);
            this.muteButton.TabIndex = 11;
            this.muteButton.Text = "Mute";
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // SlotMachineScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 366);
            this.Controls.Add(this.muteButton);
            this.Controls.Add(this.WinLabel);
            this.Controls.Add(this.CreditsLabel);
            this.Controls.Add(this.PaytableButton);
            this.Controls.Add(this.BetLabel);
            this.Controls.Add(this.gambleButton);
            this.Controls.Add(this.lessBet);
            this.Controls.Add(this.moreBet);
            this.Controls.Add(this.spinButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.SlotsColumns);
            this.Controls.Add(this.BackgroundImage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SlotMachineScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SlotsColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundImage;
        private System.Windows.Forms.PictureBox SlotsColumns;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button spinButton;
        private System.Windows.Forms.Button moreBet;
        private System.Windows.Forms.Button lessBet;
        private System.Windows.Forms.Button gambleButton;
        private System.Windows.Forms.Label BetLabel;
        private System.Windows.Forms.Button PaytableButton;
        private System.Windows.Forms.Label CreditsLabel;
        private System.Windows.Forms.Label WinLabel;
        private System.Windows.Forms.Button muteButton;
    }
}


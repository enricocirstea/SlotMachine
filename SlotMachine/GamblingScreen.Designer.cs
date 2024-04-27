namespace SlotMachine {
    partial class GamblingScreen {
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.BackgroundImage = new System.Windows.Forms.PictureBox();
            this.RedButton = new System.Windows.Forms.Button();
            this.BlackButton = new System.Windows.Forms.Button();
            this.CollectButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.WinLabel = new System.Windows.Forms.Label();
            this.casinoLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.BackgroundImage.Location = new System.Drawing.Point(127, 78);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(100, 50);
            this.BackgroundImage.TabIndex = 0;
            this.BackgroundImage.TabStop = false;
            // 
            // RedButton
            // 
            this.RedButton.Location = new System.Drawing.Point(95, 213);
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(75, 23);
            this.RedButton.TabIndex = 1;
            this.RedButton.Text = "button1";
            this.RedButton.UseVisualStyleBackColor = true;
            this.RedButton.Click += new System.EventHandler(this.RedButton_Click);
            // 
            // BlackButton
            // 
            this.BlackButton.Location = new System.Drawing.Point(663, 212);
            this.BlackButton.Name = "BlackButton";
            this.BlackButton.Size = new System.Drawing.Size(75, 23);
            this.BlackButton.TabIndex = 2;
            this.BlackButton.Text = "button2";
            this.BlackButton.UseVisualStyleBackColor = true;
            this.BlackButton.Click += new System.EventHandler(this.BlackButton_Click);
            // 
            // CollectButton
            // 
            this.CollectButton.Location = new System.Drawing.Point(480, 415);
            this.CollectButton.Name = "CollectButton";
            this.CollectButton.Size = new System.Drawing.Size(75, 23);
            this.CollectButton.TabIndex = 3;
            this.CollectButton.Text = "button3";
            this.CollectButton.UseVisualStyleBackColor = true;
            this.CollectButton.Click += new System.EventHandler(this.CollectButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(662, 414);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "button1";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // WinLabel
            // 
            this.WinLabel.AutoSize = true;
            this.WinLabel.Location = new System.Drawing.Point(383, 218);
            this.WinLabel.Name = "WinLabel";
            this.WinLabel.Size = new System.Drawing.Size(45, 16);
            this.WinLabel.TabIndex = 5;
            this.WinLabel.Text = "label1";
            // 
            // casinoLogo
            // 
            this.casinoLogo.Image = global::SlotMachine.Properties.Resources.vegascasino_logo;
            this.casinoLogo.Location = new System.Drawing.Point(354, 91);
            this.casinoLogo.Name = "casinoLogo";
            this.casinoLogo.Size = new System.Drawing.Size(100, 50);
            this.casinoLogo.TabIndex = 6;
            this.casinoLogo.TabStop = false;
            // 
            // GamblingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.casinoLogo);
            this.Controls.Add(this.WinLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CollectButton);
            this.Controls.Add(this.BlackButton);
            this.Controls.Add(this.RedButton);
            this.Controls.Add(this.BackgroundImage);
            this.Name = "GamblingScreen";
            this.Text = "GamblingScreen";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundImage;
        private System.Windows.Forms.Button RedButton;
        private System.Windows.Forms.Button BlackButton;
        private System.Windows.Forms.Button CollectButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label WinLabel;
        private System.Windows.Forms.PictureBox casinoLogo;
    }
}
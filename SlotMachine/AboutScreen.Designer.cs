namespace SlotMachine {
    partial class AboutScreen {
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
            this.casinoLogo = new System.Windows.Forms.PictureBox();
            this.DevelopersLabel = new System.Windows.Forms.Label();
            this.developer1 = new System.Windows.Forms.Label();
            this.developer2 = new System.Windows.Forms.Label();
            this.developer3 = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.releaseDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.BackgroundImage.Location = new System.Drawing.Point(0, 1);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(1306, 672);
            this.BackgroundImage.TabIndex = 0;
            this.BackgroundImage.TabStop = false;
            // 
            // casinoLogo
            // 
            this.casinoLogo.Image = global::SlotMachine.Properties.Resources.vegascasino_logo;
            this.casinoLogo.Location = new System.Drawing.Point(359, 45);
            this.casinoLogo.Name = "casinoLogo";
            this.casinoLogo.Size = new System.Drawing.Size(522, 143);
            this.casinoLogo.TabIndex = 1;
            this.casinoLogo.TabStop = false;
            // 
            // DevelopersLabel
            // 
            this.DevelopersLabel.AutoSize = true;
            this.DevelopersLabel.Location = new System.Drawing.Point(571, 258);
            this.DevelopersLabel.Name = "DevelopersLabel";
            this.DevelopersLabel.Size = new System.Drawing.Size(35, 13);
            this.DevelopersLabel.TabIndex = 2;
            this.DevelopersLabel.Text = "label1";
            // 
            // developer1
            // 
            this.developer1.AutoSize = true;
            this.developer1.Location = new System.Drawing.Point(574, 332);
            this.developer1.Name = "developer1";
            this.developer1.Size = new System.Drawing.Size(35, 13);
            this.developer1.TabIndex = 3;
            this.developer1.Text = "label2";
            // 
            // developer2
            // 
            this.developer2.AutoSize = true;
            this.developer2.Location = new System.Drawing.Point(574, 392);
            this.developer2.Name = "developer2";
            this.developer2.Size = new System.Drawing.Size(35, 13);
            this.developer2.TabIndex = 4;
            this.developer2.Text = "label3";
            // 
            // developer3
            // 
            this.developer3.AutoSize = true;
            this.developer3.Location = new System.Drawing.Point(574, 467);
            this.developer3.Name = "developer3";
            this.developer3.Size = new System.Drawing.Size(35, 13);
            this.developer3.TabIndex = 5;
            this.developer3.Text = "label4";
            // 
            // QuitButton
            // 
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.Location = new System.Drawing.Point(805, 545);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(146, 48);
            this.QuitButton.TabIndex = 6;
            this.QuitButton.Text = "button1";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // releaseDateLabel
            // 
            this.releaseDateLabel.AutoSize = true;
            this.releaseDateLabel.Location = new System.Drawing.Point(418, 564);
            this.releaseDateLabel.Name = "releaseDateLabel";
            this.releaseDateLabel.Size = new System.Drawing.Size(35, 13);
            this.releaseDateLabel.TabIndex = 7;
            this.releaseDateLabel.Text = "label1";
            // 
            // AboutScreen
            // 
            this.ClientSize = new System.Drawing.Size(1281, 651);
            this.Controls.Add(this.releaseDateLabel);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.developer3);
            this.Controls.Add(this.developer2);
            this.Controls.Add(this.developer1);
            this.Controls.Add(this.DevelopersLabel);
            this.Controls.Add(this.casinoLogo);
            this.Controls.Add(this.BackgroundImage);
            this.Name = "AboutScreen";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox BackgroundImage;
        private System.Windows.Forms.PictureBox casinoLogo;
        private System.Windows.Forms.Label DevelopersLabel;
        private System.Windows.Forms.Label developer1;
        private System.Windows.Forms.Label developer2;
        private System.Windows.Forms.Label developer3;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label releaseDateLabel;
    }
}


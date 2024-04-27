namespace SlotMachine {
    partial class MainMenuScreen {
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
            this.playButton = new System.Windows.Forms.Button();
            this.addcreditButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.leaderboardButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.backgroundPicture = new System.Windows.Forms.PictureBox();
            this.muteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.Location = new System.Drawing.Point(246, 78);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "button1";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // addcreditButton
            // 
            this.addcreditButton.FlatAppearance.BorderSize = 0;
            this.addcreditButton.Location = new System.Drawing.Point(246, 159);
            this.addcreditButton.Name = "addcreditButton";
            this.addcreditButton.Size = new System.Drawing.Size(75, 23);
            this.addcreditButton.TabIndex = 2;
            this.addcreditButton.Text = "button2";
            this.addcreditButton.UseVisualStyleBackColor = true;
            this.addcreditButton.Click += new System.EventHandler(this.addcreditButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.Location = new System.Drawing.Point(665, 307);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // leaderboardButton
            // 
            this.leaderboardButton.FlatAppearance.BorderSize = 0;
            this.leaderboardButton.Location = new System.Drawing.Point(246, 251);
            this.leaderboardButton.Name = "leaderboardButton";
            this.leaderboardButton.Size = new System.Drawing.Size(75, 23);
            this.leaderboardButton.TabIndex = 4;
            this.leaderboardButton.Text = "button4";
            this.leaderboardButton.UseVisualStyleBackColor = true;
            this.leaderboardButton.Click += new System.EventHandler(this.leaderboardButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.Location = new System.Drawing.Point(246, 322);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.Location = new System.Drawing.Point(665, 389);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // logoPicture
            // 
            this.logoPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoPicture.Image = global::SlotMachine.Properties.Resources.vegascasino_logo;
            this.logoPicture.Location = new System.Drawing.Point(451, 4);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(512, 196);
            this.logoPicture.TabIndex = 7;
            this.logoPicture.TabStop = false;
            // 
            // backgroundPicture
            // 
            this.backgroundPicture.Image = global::SlotMachine.Properties.Resources.background_image;
            this.backgroundPicture.Location = new System.Drawing.Point(12, 4);
            this.backgroundPicture.Name = "backgroundPicture";
            this.backgroundPicture.Size = new System.Drawing.Size(774, 434);
            this.backgroundPicture.TabIndex = 0;
            this.backgroundPicture.TabStop = false;
            // 
            // muteButton
            // 
            this.muteButton.FlatAppearance.BorderSize = 0;
            this.muteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.muteButton.Location = new System.Drawing.Point(44, 27);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(75, 23);
            this.muteButton.TabIndex = 8;
            this.muteButton.Text = "Mute";
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 799);
            this.Controls.Add(this.muteButton);
            this.Controls.Add(this.logoPicture);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.leaderboardButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.addcreditButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.backgroundPicture);
            this.Name = "MainMenuScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundPicture;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button addcreditButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button leaderboardButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Button muteButton;
    }
}


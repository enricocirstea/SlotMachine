namespace SlotMachine {
    partial class JackpotScreen {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JackpotScreen));
            this.BackgroundImage = new System.Windows.Forms.PictureBox();
            this.JackpotWin = new System.Windows.Forms.PictureBox();
            this.CollectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JackpotWin)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundImage
            // 
            this.BackgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.BackgroundImage.Location = new System.Drawing.Point(135, 78);
            this.BackgroundImage.Name = "BackgroundImage";
            this.BackgroundImage.Size = new System.Drawing.Size(100, 50);
            this.BackgroundImage.TabIndex = 0;
            this.BackgroundImage.TabStop = false;
            // 
            // JackpotWin
            // 
            this.JackpotWin.Image = ((System.Drawing.Image)(resources.GetObject("JackpotWin.Image")));
            this.JackpotWin.Location = new System.Drawing.Point(67, -6);
            this.JackpotWin.Name = "JackpotWin";
            this.JackpotWin.Size = new System.Drawing.Size(671, 412);
            this.JackpotWin.TabIndex = 1;
            this.JackpotWin.TabStop = false;
            // 
            // CollectButton
            // 
            this.CollectButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.CollectButton.FlatAppearance.BorderSize = 0;
            this.CollectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollectButton.Location = new System.Drawing.Point(713, 412);
            this.CollectButton.Name = "CollectButton";
            this.CollectButton.Size = new System.Drawing.Size(75, 23);
            this.CollectButton.TabIndex = 2;
            this.CollectButton.Text = "button1";
            this.CollectButton.UseVisualStyleBackColor = true;
            this.CollectButton.Click += new System.EventHandler(this.CollectButton_Click);
            // 
            // JackpotScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CollectButton);
            this.Controls.Add(this.JackpotWin);
            this.Controls.Add(this.BackgroundImage);
            this.Name = "JackpotScreen";
            this.Text = "JackpotScreen";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JackpotWin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundImage;
        private System.Windows.Forms.PictureBox JackpotWin;
        private System.Windows.Forms.Button CollectButton;
    }
}
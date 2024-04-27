namespace SlotMachine {
    partial class AddCreditScreen {
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
            this.creditCardNumberTextbox = new System.Windows.Forms.TextBox();
            this.cvcTextbox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextbox = new System.Windows.Forms.TextBox();
            this.creditAmountTextbox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.casinoLogo = new System.Windows.Forms.PictureBox();
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // creditCardNumberTextbox
            // 
            this.creditCardNumberTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creditCardNumberTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditCardNumberTextbox.Location = new System.Drawing.Point(621, 135);
            this.creditCardNumberTextbox.Name = "creditCardNumberTextbox";
            this.creditCardNumberTextbox.Size = new System.Drawing.Size(100, 36);
            this.creditCardNumberTextbox.TabIndex = 2;
            // 
            // cvcTextbox
            // 
            this.cvcTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cvcTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvcTextbox.Location = new System.Drawing.Point(350, 215);
            this.cvcTextbox.Name = "cvcTextbox";
            this.cvcTextbox.Size = new System.Drawing.Size(100, 36);
            this.cvcTextbox.TabIndex = 3;
            // 
            // confirmPasswordTextbox
            // 
            this.confirmPasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.confirmPasswordTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextbox.Location = new System.Drawing.Point(459, 252);
            this.confirmPasswordTextbox.Name = "confirmPasswordTextbox";
            this.confirmPasswordTextbox.Size = new System.Drawing.Size(100, 36);
            this.confirmPasswordTextbox.TabIndex = 4;
            // 
            // creditAmountTextbox
            // 
            this.creditAmountTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creditAmountTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditAmountTextbox.Location = new System.Drawing.Point(649, 262);
            this.creditAmountTextbox.Name = "creditAmountTextbox";
            this.creditAmountTextbox.Size = new System.Drawing.Size(100, 36);
            this.creditAmountTextbox.TabIndex = 5;
            // 
            // confirmButton
            // 
            this.confirmButton.FlatAppearance.BorderSize = 0;
            this.confirmButton.Location = new System.Drawing.Point(209, 135);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "button1";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.Location = new System.Drawing.Point(285, 187);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "button1";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // casinoLogo
            // 
            this.casinoLogo.Image = global::SlotMachine.Properties.Resources.vegascasino_logo;
            this.casinoLogo.Location = new System.Drawing.Point(199, 233);
            this.casinoLogo.Name = "casinoLogo";
            this.casinoLogo.Size = new System.Drawing.Size(513, 140);
            this.casinoLogo.TabIndex = 1;
            this.casinoLogo.TabStop = false;
            // 
            // backgroundImage
            // 
            this.backgroundImage.Image = global::SlotMachine.Properties.Resources.background_image;
            this.backgroundImage.Location = new System.Drawing.Point(401, 106);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(100, 50);
            this.backgroundImage.TabIndex = 0;
            this.backgroundImage.TabStop = false;
            // 
            // nameTextbox
            // 
            this.nameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextbox.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextbox.Location = new System.Drawing.Point(317, 84);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(100, 36);
            this.nameTextbox.TabIndex = 8;
            // 
            // AddCreditScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.creditAmountTextbox);
            this.Controls.Add(this.confirmPasswordTextbox);
            this.Controls.Add(this.cvcTextbox);
            this.Controls.Add(this.creditCardNumberTextbox);
            this.Controls.Add(this.casinoLogo);
            this.Controls.Add(this.backgroundImage);
            this.Name = "AddCreditScreen";
            this.Text = "AddCreditScreen";
            ((System.ComponentModel.ISupportInitialize)(this.casinoLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backgroundImage;
        private System.Windows.Forms.PictureBox casinoLogo;
        private System.Windows.Forms.TextBox creditCardNumberTextbox;
        private System.Windows.Forms.TextBox cvcTextbox;
        private System.Windows.Forms.TextBox confirmPasswordTextbox;
        private System.Windows.Forms.TextBox creditAmountTextbox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nameTextbox;
    }
}
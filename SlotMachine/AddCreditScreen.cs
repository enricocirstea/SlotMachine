using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine {
    public partial class AddCreditScreen : Form {
        Assembly dataBase;
        dynamic db;
        Assembly MACEncryptor;
        dynamic mac;
        private PrivateFontCollection egyptFont;
        public AddCreditScreen() {

            InitializeComponent();
            setupScreen();
        }

        public void setupScreen() {
            dataBase = Assembly.Load("Database");
            db = dataBase.CreateInstance("Database.Database");
            MACEncryptor = Assembly.Load("MACEncryptor");
            mac = MACEncryptor.CreateInstance("MACEncryptor.MACEncryptor");
            try {
                db.Init();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
            setupFont();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            backgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            casinoLogo.Location = new Point(x + 300, y - 200);
            casinoLogo.Parent = backgroundImage;
            casinoLogo.BackColor = Color.Transparent;

            setupLabel("Full name:", x - 500, y - 300, 35, 460, 50);
            setupLabel("Credit card number:", x - 500, y - 200, 35, 460, 50);
            setupLabel("CVC:", x - 500, y - 100, 30, 460, 50);
            setupLabel("Confirm password:", x - 500, y, 30, 460, 50);
            setupLabel("Credit amount:", x - 500, y + 100, 30, 460, 50);
            setupTextbox(nameTextbox, x, y - 300, false);
            setupTextbox(creditCardNumberTextbox, x, y - 200, false);
            creditCardNumberTextbox.MaxLength = 16;
            setupTextbox(cvcTextbox, x, y - 100, false);
            cvcTextbox.MaxLength = 3;
            setupTextbox(confirmPasswordTextbox, x, y, true);
            setupTextbox(creditAmountTextbox, x, y + 100, false);
            setupButton(confirmButton, "Confirm", x - 100, y + 200);
            setupButton(cancelButton, "Cancel", x + 690, y + 420);
        }

        private void setupLabel(String text, int x, int y, int fontSize, int width, int height) {
            Label label = new Label();
            label.Parent = backgroundImage;
            label.BackColor = Color.Transparent;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Size = new Size(width, height);
            label.Anchor = AnchorStyles.None;
            label.Location = new Point(x, y);
            label.TextAlign = ContentAlignment.MiddleRight;
            label.ForeColor = Color.White;
        }

        private void setupTextbox(TextBox textbox, int x, int y, bool isPassword) {
            textbox.Parent = backgroundImage;
            textbox.BackColor = Color.Yellow;
            textbox.Anchor = AnchorStyles.None;
            textbox.Location = new Point(x, y);
            textbox.Width = 500;
            if (isPassword == true) {
                textbox.PasswordChar = '*';
            }
            textbox.TextAlign = HorizontalAlignment.Center;
        }
        private void setupButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 30);
            button.BackColor = Color.Orange;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Yellow;
            button.Text = text;
            button.Location = new Point(x, y);
            button.Anchor = AnchorStyles.None;
            button.Width = 180;
            button.Height = 60;
            button.UseCompatibleTextRendering = true;
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void confirmButton_Click(object sender, EventArgs e) {
            int result = 0;
            if (creditCardNumberTextbox.Text.Length != 16) {
                MessageBox.Show("Credit card number is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cvcTextbox.Text.Length != 3) {
                MessageBox.Show("CVC is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                result = Int32.Parse(cvcTextbox.Text);
            }
            catch (FormatException) {
                MessageBox.Show("CVC field must contain a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CurrentPlayer currentPlayer = CurrentPlayer.getInstance();
            if (db.AuthenticateUser(currentPlayer.getUsername(), confirmPasswordTextbox.Text) != true) {
                MessageBox.Show("Wrong password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                result = Int32.Parse(creditAmountTextbox.Text);
            }
            catch (FormatException) {
                MessageBox.Show("Credit amount field must contain a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double balance = result + db.GetBalance(currentPlayer.getUsername());
            db.UpdateBalance(currentPlayer.getUsername(), balance);
            MessageBox.Show("Succes!");
            System.IO.File.WriteAllText("carddata.txt", nameTextbox.Text + "\n" + creditCardNumberTextbox.Text + "\n" + cvcTextbox.Text);
            System.IO.File.WriteAllText("encryptedcarddata.txt", mac.Encrypt("carddata.txt"));
            System.IO.File.Delete("carddata.txt");
            this.Dispose();
        }
    }
}

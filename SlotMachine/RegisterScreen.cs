using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;

namespace SlotMachine {
    public partial class RegisterScreen : Form {
        Assembly databaseDLL;
        dynamic db;

        public static SlotMachine.RegisterScreen registerInstance = null;
        PrivateFontCollection egyptFont;
        public RegisterScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            setupFont();
            InitializeComponent();
            setupScreen();
            databaseDLL = Assembly.Load("Database");
            if (databaseDLL == null) {
               // MessageBox.Show("Could not load database assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tCould not load database assembly");
                System.Environment.Exit(1);
            }
            db = databaseDLL.CreateInstance("Database.Database");
            db.Init();
        }
        private void setupScreen() {
            backgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupLabel(usernameLabel, "Enter username:", 35, x - 300, y - 150);
            setupLabel(passwordLabel, "Enter password:", 35, x - 300, y - 50);
            setupLabel(confirmPasswordLabel, "Confirm password:", 35, x - 300, y + 50);

            setupTextbox(usernameTextbox, x+100, y - 150, false);
            setupTextbox(passwordTextbox, x+100, y - 50, true);
            setupTextbox(confirmPasswordTextbox, x+100, y + 50, true);

            setupButton(registerButton, "Register", x - 100, y + 250);
            setupButton(cancelButton, "Cancel", x + 700, y + 430);

            setupCheckbox(over18Check, x - 180, y + 150);
            logoPicturebox.Location = new Point(x - 250, y - 400);
            logoPicturebox.Parent = backgroundImage;
            logoPicturebox.BackColor = Color.Transparent;
            logoPicturebox.Anchor = AnchorStyles.None;
        }

        private void setupLabel(Label label, String text, int fontSize, int x, int y) {
            label.Parent = backgroundImage;
            label.ForeColor = Color.White;
            label.BackColor = Color.Transparent;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Anchor = AnchorStyles.None;
            label.Location = new Point(x, y);
        }

        private void setupTextbox(TextBox textbox, int x, int y, bool isPassword) {
            textbox.Parent = backgroundImage;
            textbox.BackColor = Color.Yellow;
            textbox.Anchor = AnchorStyles.None;
            textbox.Location = new Point(x, y);
            textbox.Width = 300;
            textbox.TextAlign = HorizontalAlignment.Center;
            if (isPassword == true) {
                textbox.PasswordChar = '*';
            }
        }
        private void setupButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 22);
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

        private void setupCheckbox(CheckBox checkbox, int x, int y) {
            checkbox.Font = new Font(egyptFont.Families[0], 35);
            checkbox.ForeColor = Color.Crimson;
            checkbox.UseCompatibleTextRendering = true;
            checkbox.Text = "Are you over 18?";
            checkbox.Parent = backgroundImage;
            checkbox.BackColor = Color.Transparent;
            checkbox.Location = new Point(x, y);
            checkbox.Anchor = AnchorStyles.None;
        }

        private void registerButton_Click(object sender, EventArgs e) {
            if (!over18Check.Checked) {
                MessageBox.Show("You have to be over 18 to create an account.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
            else if (passwordTextbox.Text != confirmPasswordTextbox.Text) {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tError creating account: Passwords do not match");

            }
            else {
                if (db.FindUser(usernameTextbox.Text)) {
                    MessageBox.Show("Username taken.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tError creating account - username taken: " + usernameTextbox.Text);

                }
                else {
                    db.InsertUser(usernameTextbox.Text, passwordTextbox.Text);
                    MessageBox.Show("Succesfully registered!", "Merry Christmas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tRegistered new account: " + usernameTextbox.Text);
                    this.Dispose();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}

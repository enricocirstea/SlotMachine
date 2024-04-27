using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine {
    public partial class AboutScreen : Form {
        PrivateFontCollection egyptFont;
        public AboutScreen() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            setupFont();
            InitializeComponent();
            setupScreen();
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupButton(QuitButton, "Back");
            QuitButton.Location = new Point(x + 970, y + 650);

            setupLabel(DevelopersLabel, "DEVELOPERS:", 55);
            DevelopersLabel.Location = new Point(casinoLogo.Location.X + 400, casinoLogo.Location.Y + 300);

            setupLabel(developer1, "Butu Sergiu", 40);
            developer1.Location = new Point(DevelopersLabel.Location.X + 30, DevelopersLabel.Location.Y + 180);

            setupLabel(developer2, "Cimpean Adrian", 40);
            developer2.Location = new Point(developer1.Location.X, developer1.Location.Y + 90);

            setupLabel(developer3, "Cirstea Enrico", 40);
            developer3.Location = new Point(developer1.Location.X, developer2.Location.Y + 90);

            setupLabel(releaseDateLabel, "Current version: BETA v1\nReleased on: 06/01/2020", 30);
            releaseDateLabel.Location = new Point(developer1.Location.X-700, developer3.Location.Y + 250);
            casinoLogo.Location = new Point(x + 50, y - 250);
            casinoLogo.Parent = BackgroundImage;
            casinoLogo.BackColor = Color.Transparent;
        }
        private void setupLabel(Label label, String text, int fontSize) {
            label.Parent = BackgroundImage;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.ForeColor = Color.White;
            label.UseCompatibleTextRendering = true;
        }

        private void setupButton(Button button, String text) {
            button.Font = new Font(egyptFont.Families[0], 30);
            button.BackColor = Color.Orange;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Yellow;
            button.Text = text;
            button.UseCompatibleTextRendering = true;
        }

        private void QuitButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}

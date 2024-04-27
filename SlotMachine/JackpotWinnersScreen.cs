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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SlotMachine {
    public partial class JackpotWinnersScreen : Form {
        Assembly databaseDLL;
        dynamic db;
        private PrivateFontCollection egyptFont;
        string data = "";
        string[] lines;
       
        public JackpotWinnersScreen() {
            InitializeComponent();
            databaseDLL = Assembly.Load("Database");
            if (databaseDLL == null) {
                MessageBox.Show("Could not load database assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            db = databaseDLL.CreateInstance("Database.Database");
            db.Init();
            setupScreen();
        }

        private void setupScreen() {
            setupFont();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            backgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            casinoLogo.Location = new Point(x + 300, y - 200);
            casinoLogo.Parent = backgroundImage;
            casinoLogo.BackColor = Color.Transparent;

            int i = 1;
            getData(data);
            foreach (string line in lines) {
                setupLabel(line, x - 400, (y - 275) + (i * 75), 40, 900, 60);
                ++i;
                if (i > 10) {
                    break;
                }
            }
            setupLabel("Place", x - 410, y - 325, 40, 200, 80);
            setupLabel("Name", x - 135, y - 325, 40, 200, 80);
            setupLabel("Winnings", x + 225, y - 325, 40, 300, 80);
            setupButton(cancelButton, "Cancel", x + 690, y + 420);
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
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
            label.ForeColor = Color.White;
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

        private void getData(string data) {
            data = db.SelectWinners();
            Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tSelected Jackpot winners from database");

            lines = Regex.Split(data, "\n");
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}

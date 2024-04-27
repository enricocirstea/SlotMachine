using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SlotMachine {
    public partial class MainMenuScreen : Form {
        Assembly xmlReader;
        dynamic xml;
        PrivateFontCollection egyptFont;
        int c = 1;
        SoundPlayer menuMusic;
        
        public MainMenuScreen(SoundPlayer menuMusic) {
            this.menuMusic = menuMusic;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            setupFont();
            setupScreen();
            xmlReader = Assembly.Load("XmlReader");
            xml = xmlReader.CreateInstance("XmlReader.XmlReader");
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = SlotMachine.Properties.Resources.ISIS.Length;
            byte[] fontData = SlotMachine.Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupScreen() {
            //background and logo locations and appearence

            backgroundPicture.Dock = DockStyle.Fill;
            int x = this.Height / 2;
            int y = this.Width / 2;
            logoPicture.Location = new Point(x, y - 750);
            logoPicture.Parent = backgroundPicture;
            logoPicture.BackColor = Color.Transparent;

            //button setup
            setupButton(quitButton, "Quit", x + 950, y + 150);
            setupButton(logoutButton, "Logout", x + 950, y + 50);
            setupButton(aboutButton, "About", x + 200, y - 50);
            setupButton(leaderboardButton, "Leaderboard", x + 200, y - 180);
            setupButton(addcreditButton, "Add Credit", x + 200, y - 310);
            setupButton(playButton, "Play", x + 200, y - 440);
            setupButton(muteButton, "Mute", x + 950, y -45);

        }

        private void setupButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 20);
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

        private void quitButton_Click(object sender, EventArgs e) {
            File.Delete("chances.xml");
            System.Environment.Exit(1);
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void aboutButton_Click(object sender, EventArgs e) {
            this.Hide();
            SlotMachine.AboutScreen about = new SlotMachine.AboutScreen();
            about.ShowDialog();
            this.Show();
        }

        private void leaderboardButton_Click(object sender, EventArgs e) {
            this.Hide();
            SlotMachine.JackpotWinnersScreen jackpotWinners = new SlotMachine.JackpotWinnersScreen();
            jackpotWinners.ShowDialog();
            this.Show();
        }

        private void playButton_Click(object sender, EventArgs e) {
            this.Hide();
            SlotMachine.SlotMachineScreen slotMachine = new SlotMachine.SlotMachineScreen(menuMusic);
            slotMachine.ShowDialog();
            this.Show();
        }

        private void addcreditButton_Click(object sender, EventArgs e) {
            this.Hide();
            SlotMachine.AddCreditScreen addCreditScreen = new SlotMachine.AddCreditScreen();
            addCreditScreen.ShowDialog();
            this.Show();
        }

        private void muteButton_Click(object sender, EventArgs e)
        {

            c++;
            if (c % 2 == 1)
            {
                menuMusic.PlayLooping();
                muteButton.Text = "Mute";
            }
            else if (c % 2 == 0)
            {
                menuMusic.Stop();
                muteButton.Text = "Unmute";
            }
        }
    }
}

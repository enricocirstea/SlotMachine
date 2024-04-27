using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Media;


namespace SlotMachine {
    public partial class GamblingScreen : Form {
        PrivateFontCollection egyptFont;
        Random random = new Random();
        int randomNumber;
        int counter;
        SoundPlayer gambleWin;
        SoundPlayer gambleFail;
        SoundPlayer fiveGamble;
       
        public double win { get; set; }
       
        public GamblingScreen(double win) {

            gambleWin = new SoundPlayer();
            gambleFail = new SoundPlayer();
            fiveGamble = new SoundPlayer();
            gambleWin.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "gamble.wav";
            gambleFail.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "failGamble.wav";
            fiveGamble.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "fiveGamble.wav";


            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
            this.win = win;

            InitializeComponent();
            setupFont();
            setupScreen();
        }

        private void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupButton(BlackButton, "Black", x - 700, y-120, 40);
            BlackButton.BackColor = Color.Black;
            BlackButton.ForeColor = Color.White;
            BlackButton.FlatAppearance.BorderColor = Color.Black;
           
            setupButton(RedButton, "Red", x + 400, y-120,40);
            RedButton.BackColor = Color.Red;
            RedButton.FlatAppearance.BorderColor = Color.Red;

            setupButton(BackButton, "Back", x + 700, y + 430, 20);
            BackButton.BackColor = Color.Orange;
            BackButton.Width = 180;
            BackButton.Height = 60;

            setupButton(CollectButton, "Collect", x-130, y + 320, 40);
            CollectButton.BackColor = Color.Green;

            setupLabel(WinLabel, "Winnings:\n" + win, 70);
            WinLabel.Location = new Point(x-160, y-120);


            casinoLogo.Location = new Point(x + 300, y - 400);
            casinoLogo.Parent = BackgroundImage;
            casinoLogo.BackColor = Color.Transparent;
        }

        private void setupButton(Button button, String text, int x, int y, int fontSize) {
            button.Font = new Font(egyptFont.Families[0], fontSize);
            button.FlatStyle = FlatStyle.Flat;
            button.Text = text;
            button.Location = new Point(x, y);
            button.Anchor = AnchorStyles.None;
            button.Width = 360;
            button.Height = 200;
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

        private void setupLabel(Label label, String text, int fontSize) {
            label.Parent = BackgroundImage;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Anchor = AnchorStyles.None;
        }

        private void backButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RedButton_Click(object sender, EventArgs e) {
            randomNumber = random.Next(0, 100);
            if (randomNumber < 49) {
                gambleWin.Play();
                win *= 2;
                WinLabel.Text = "Winnings:\n" + win;
                counter++;

                if (counter == 5) {
                    fiveGamble.Play();
                   // MessageBox.Show("I see that you're a man of culture as well!");
                    this.Dispose();
                }
            }
            else {
                // MessageBox.Show("Good luck next time!", randomNumber.ToString());
                gambleFail.Play();
                win = 0;
                this.Dispose();
            }
        }

        private void BlackButton_Click(object sender, EventArgs e) {
            randomNumber = random.Next(0, 100);
            if (randomNumber > 50) {
                gambleWin.Play();
                win *= 2;
                WinLabel.Text = "Winnings:\n" + win;
                counter++;

                if (counter == 5) {
                    // MessageBox.Show("I see that you're a man of culture as well!");
                    fiveGamble.Play();
                    this.Dispose();
                }
            }
            else {
                //MessageBox.Show("Good luck next time!", randomNumber.ToString());
                gambleFail.Play();
                win = 0;
                this.Dispose();
            }
        }


        private void BackButton_Click_1(object sender, EventArgs e) {
            this.Dispose();
        }

        private void CollectButton_Click(object sender, EventArgs e) {
            fiveGamble.Play();
           // MessageBox.Show("Congratulations! You have earned: " + win);
            this.Dispose();
        }
    }
}

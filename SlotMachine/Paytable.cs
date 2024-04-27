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
    public partial class Paytable : Form {
        PrivateFontCollection egyptFont;

        public Paytable() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            setupFont();
            setupScreen();
        }

        private void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupButton(BackButton, "Back", x + 170, y + 430);
           
            setupPictureBox(Watermelon, x-920, y-520);
            setupPictureBox(Plum, x-920, y-140);
            setupPictureBox(Lemon, x-920, y+250);

            setupPictureBox(Grapes, x+680, y-520); 
            setupPictureBox(Orange, x+680, y-110);
            setupPictureBox(Cherry, x+680, y+250);

            setupPictureBox(Seven, x-100, y-520);
            setupPictureBox(Star, x-100, y+250);

            setupLabel(WatermelonLabel, "x5------40 \nx4------16 \nx3------4", 45);
            WatermelonLabel.Location = new Point(Watermelon.Location.X+300,Watermelon.Location.Y+100);

            setupLabel(PlumLabel, "x5------16 \nx4------4 \nx3------1,6", 45);
            PlumLabel.Location = new Point(Plum.Location.X + 300, Plum.Location.Y + 100);

            setupLabel(LemonLabel, "x5------16 \nx4------4 \nx3------1,6", 45);
            LemonLabel.Location = new Point(Lemon.Location.X + 300, Lemon.Location.Y + 80);

            setupLabel(GrapesLabel, "x5------40 \nx4------16 \nx3------4", 45);
            GrapesLabel.Location = new Point(Grapes.Location.X - 300, Grapes.Location.Y + 100);

            setupLabel(OrangeLabel, "x5------16 \nx4------4 \nx3------1,6", 45);
            OrangeLabel.Location = new Point(Orange.Location.X - 300, Orange.Location.Y + 80);

            setupLabel(CherryLabel, "x5------16 \nx4------4 \nx3------1,6 \nx2------0,4", 45);
            CherryLabel.Location = new Point(Cherry.Location.X - 300, Cherry.Location.Y + 40);
           
            setupLabel(SevenLabel, "x5------400 \nx4------80 \nx3------8", 45);
            SevenLabel.Location = new Point(Seven.Location.X, Seven.Location.Y + 330); 
            
            setupLabel(StarLabel, "x5------16 \nx4------4 \nx3------1,6", 45);
            StarLabel.Location = new Point(Star.Location.X, Star.Location.Y-180);
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = SlotMachine.Properties.Resources.ISIS.Length;
            byte[] fontData = SlotMachine.Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void setupButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 25);
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
        private void setupLabel(Label label, String text, int fontSize) {
            label.Parent = BackgroundImage;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Anchor = AnchorStyles.None;
            label.ForeColor = Color.White;
        }

        private void setupPictureBox(PictureBox pictureBox, int x, int y) {
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.Size = new Size(286, 286);
            pictureBox.Parent = BackgroundImage;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Location = new Point(x, y);
        }

        private void BackButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}

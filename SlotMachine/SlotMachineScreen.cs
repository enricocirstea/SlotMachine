using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;

namespace SlotMachine {
    public partial class SlotMachineScreen : Form {
        Assembly xml;
        dynamic xmlReader;
        Assembly winningsCalc;
        dynamic winningsCalculator;
        Assembly database;
        dynamic db;
        int c = 1;

        private double[] chances = new double[9];
        private double jackpotChance;
        PrivateFontCollection egyptFont;
        CurrentPlayer currentPlayer;
        SoundPlayer menuMusic;
        SoundPlayer winWait;
        SoundPlayer changeBet;

        private int[] bets = new int[6];
        int bet_pos_in_vector;

        WinningsCalculator.WinType[] winTypes;
        Random random = new Random();
        WinningsCalculator.PictureMap[,] pictureMatrix = new WinningsCalculator.PictureMap[3, 5];
        PictureBox[,] borderMatrix = new PictureBox[3, 5];

        double userCredits;
        double win;

        Graphics graphics;
        public SlotMachineScreen(SoundPlayer menuMusic) {
            this.menuMusic = menuMusic;
            winWait = new SoundPlayer();
            winWait.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "winWait.wav";
            changeBet = new SoundPlayer();
            changeBet.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "changeBet.wav";
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            currentPlayer = SlotMachine.CurrentPlayer.getInstance();

            database = Assembly.Load("Database");
            db = database.CreateInstance("Database.Database");
            db.Init();

            InitializeComponent();
            setupFont();
            setupScreen();

            winningsCalc = Assembly.Load("WinningsCalculator");
            winningsCalculator = winningsCalc.CreateInstance("WinningsCalculator.WinningsCalculator");


            xml = Assembly.Load("XmlReader");
            xmlReader = xml.CreateInstance("XmlReader.XmlReader");

            chances = xmlReader.getChances();

            winTypes = new WinningsCalculator.WinType[15];

            jackpotChance = chances[8];

            bet_pos_in_vector = 0;

            setupMatrix();
        }

        private void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;
            SlotsColumns.Parent = BackgroundImage;
            SlotsColumns.Dock = DockStyle.Fill;
            SlotsColumns.BackColor = Color.Transparent;

            int x = this.Width / 2;
            int y = this.Height / 2;

            setupButton(backButton, "Back", x + 700, y + 430);
            setupButton(lessBet, "BET -", x - 860, y + 430);
            setupButton(moreBet, "BET +", lessBet.Location.X + 450, y + 430);
            setupSpinButton(spinButton, "SPIN", x - 100, y + 400);
            setupSpinButton(gambleButton, "GAMBLE", spinButton.Location.X + 350, y + 400);
            setupButton(PaytableButton, "Paytable", x - 953, y - 430);
            gambleButton.Hide();
            setupButton(muteButton, "Mute", x - 953, y - 340);

            createBets(bets);
            setupLabel(BetLabel, "BET: " + bets[bet_pos_in_vector], 35, x - 650, y + 440);

            userCredits = db.GetBalance(currentPlayer.getUsername());
            setupLabel(CreditsLabel, "Credits:\n" + userCredits, 28, PaytableButton.Location.X, PaytableButton.Location.Y + 300);

            setupLabel(WinLabel, "Win:\n", 28, CreditsLabel.Location.X, CreditsLabel.Location.Y + 200);
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

        private void setupSpinButton(Button button, String text, int x, int y) {
            button.Font = new Font(egyptFont.Families[0], 45);
            button.BackColor = Color.Red;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Red;
            button.Text = text;
            button.Location = new Point(x, y);
            button.Anchor = AnchorStyles.None;
            button.Width = 250;
            button.Height = 100;
            button.UseCompatibleTextRendering = true;
        }

        private void setupLabel(Label label, String text, int fontSize, int x, int y) {
            label.Parent = SlotsColumns;
            label.BackColor = Color.Orange;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.Anchor = AnchorStyles.None;
            label.Location = new Point(x, y);
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        private void createBets(int[] bets) {
            bets[0] = 50;
            bets[1] = 100;
            bets[2] = 500;
            bets[3] = 1000;
            bets[4] = 2500;
            bets[5] = 5000;
        }

        private void backButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }
        private void createPic(int i, int j)
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(286, 286);
            pic.Parent = SlotsColumns;
            pic.BackColor = Color.Transparent;
            int y = 25 + (286 * i);
            int x = 200 + (310 * j);
            pic.Location = new Point(x, y);
            pictureMatrix[i, j].PictureBox = pic;
            pictureMatrix[i, j].PictureBox.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void createBorders()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.BackgroundImageLayout = ImageLayout.Zoom;
                    pic.Parent = pictureMatrix[i, j].PictureBox;
                    pic.BackColor = Color.Transparent;
                    pic.Location = new Point(0, 0);
                    pic.Size = new Size(286, 286);
                    pic.Anchor = AnchorStyles.None;
                    borderMatrix[i, j] = pic;
                    borderMatrix[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
            
        }

        private int[] generatePic(int i, int j)
        {
            int[] checks = new int[2];
            checks[0] = 0;
            checks[1] = 0;
            int rnd = random.Next(1, 100);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[6]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.star;
                pictureMatrix[i, j].ImageId = "star";
                checks[0] = 1;
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[6] + chances[7]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.seven;
                pictureMatrix[i, j].ImageId = "seven";
                checks[1] = 1;
            }
            return checks;
        }

        private void generateNoSeven(int i, int j)
        {
            int rnd = random.Next(1, 95);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[6]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.star;
                pictureMatrix[i, j].ImageId = "star";
            }
        }

        private void generateNoStar(int i, int j)
        {
            int rnd = random.Next(1, 93);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5] + chances[7]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.seven;
                pictureMatrix[i, j].ImageId = "seven";
            }
        }

        private void generateBasicPic(int i, int j)
        {
            int rnd = random.Next(1, 88);
            if (rnd < chances[0])
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.cherry;
                pictureMatrix[i, j].ImageId = "cherry";
            }
            else if (rnd < (chances[0] + chances[1]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.orange;
                pictureMatrix[i, j].ImageId = "orange";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.lemon;
                pictureMatrix[i, j].ImageId = "lemon";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.plum;
                pictureMatrix[i, j].ImageId = "plum";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.grapes;
                pictureMatrix[i, j].ImageId = "grapes";
            }
            else if (rnd < (chances[0] + chances[1] + chances[2] + chances[3] + chances[4] + chances[5]))
            {
                pictureMatrix[i, j].PictureBox.Image = SlotMachine.Properties.Resources.watermelon;
                pictureMatrix[i, j].ImageId = "watermelon";
            }
        }

        private void setupMatrix()
        {
            
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    pictureMatrix[i, j] = new WinningsCalculator.PictureMap();
                }
            }
            for (int j = 0; j < 5; j++)
            {
                int[] checks = new int[2];
                checks[0] = 0;
                checks[1] = 0;
                for (int i = 0; i < 3; i++)
                {
                    createPic(i, j);
                    if (checks[0] == 0 && checks[1] == 0)
                    {
                        checks = generatePic(i, j);
                    }
                    else if (checks[0] == 1)
                    {
                        generateNoStar(i, j);
                    }
                    else if (checks[1] == 1)
                    {
                        generateNoSeven(i, j);
                    }
                    else
                    {
                        generateBasicPic(i, j);
                    }
                }
            }
            createBorders();
        }
        private void updateMatrix()
        {
            for (int j = 0; j < 5; j++)
            {
                int[] checks = new int[2];
                checks[0] = 0;
                checks[1] = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (checks[0] == 0 && checks[1] == 0)
                    {
                        checks = generatePic(i, j);
                    }
                    else if (checks[0] == 1)
                    {
                        generateNoStar(i, j);
                    }
                    else if (checks[1] == 1)
                    {
                        generateNoSeven(i, j);
                    }
                    else
                    {
                        generateBasicPic(i, j);
                    }
                }
            }
        }

        private void spinButton_Click(object sender, EventArgs e)
        {

            spin();
        }

        private void PaytableButton_Click(object sender, EventArgs e) {
            SlotMachine.Paytable paytable = new SlotMachine.Paytable();
            paytable.Show();
        }

        private void lessBet_Click(object sender, EventArgs e) {
            changeBet.Play();
            if (bet_pos_in_vector == 0)
                bet_pos_in_vector = 5; //daca ajunge la cel mai mic bet si se apasa butonul = > se pune pe bet cel mai mare
            else
                bet_pos_in_vector--;

            BetLabel.Text = "BET: " + bets[bet_pos_in_vector];
        }

        private void moreBet_Click(object sender, EventArgs e) {
            changeBet.Play();
            if (bet_pos_in_vector == 5)
                bet_pos_in_vector = 0;  //daca ajunge la cel mai mare bet si se apasa butonul = > se reseteaza bet ul
            else
                bet_pos_in_vector++;

            BetLabel.Text = "BET: " + bets[bet_pos_in_vector];
        }
        private double calculateWin(int bet, WinningsCalculator.WinType[] winTypes) {
            double win = 0;
            int c = 0;
            for (int i = 0; i < 15; ++i) {
                if (winTypes[i] != null) {
                    win += bet * winTypes[i].WinAmount;
                    makeLine(winTypes[i].WinLine, winTypes[i].IconAmount);
                }
            }
            return win;
        }

        private void gambleButton_Click(object sender, EventArgs e) {
            winWait.Stop();
            this.Hide();
            GamblingScreen gamblingScreen = new GamblingScreen(win);
            gamblingScreen.ShowDialog();
            userCredits -= win;//scade castigul curent

            userCredits += gamblingScreen.win; //adauga castigul de dupa gambling

            CreditsLabel.Text = "Credits:\n" + userCredits;
            WinLabel.Text = "Win:\n" + gamblingScreen.win;
            gambleButton.Hide();
            this.Show();
        }

        private void SlotsColumns_Paint(object sender, PaintEventArgs e) {
            graphics = Graphics.FromImage(SlotsColumns.Image);
            Pen bluePen = new Pen(Color.Blue, 7);
            Pen redPen = new Pen(Color.Red, 7);
            Pen greenPen = new Pen(Color.Green, 7);
            Pen yellowPen = new Pen(Color.Yellow, 7);
            Pen purplePen = new Pen(Color.Purple, 7);
            graphics.DrawLine(bluePen, 200, 454, 1720, 454);

            graphics.DrawLine(redPen, 200, 148, 1720, 148);

            graphics.DrawLine(greenPen, 200, 760, 1720, 760);

            graphics.DrawLine(yellowPen, 200, 168, 960, 760);
            graphics.DrawLine(yellowPen, 960, 760, 1720, 168);

            graphics.DrawLine(purplePen, 200, 740, 960, 168);
            graphics.DrawLine(purplePen, 960, 168, 1720, 760);

            graphics.Dispose();
        }

        private void makeBorder(String lineType, int i, int j)
        {
            Object matrixLock = new Object();

            lock(matrixLock){
                switch (lineType)
                {
                    case "red":
                        borderMatrix[i,j].Image = SlotMachine.Properties.Resources.red;
                        break;
                    case "blue":
                        borderMatrix[i, j].Image = SlotMachine.Properties.Resources.blue;
                        break;
                    case "green":
                        borderMatrix[i, j].Image = SlotMachine.Properties.Resources.green;
                        break;
                    case "yellow":
                        borderMatrix[i, j].Image = SlotMachine.Properties.Resources.yellow;
                        break;
                    case "purple":
                        borderMatrix[i, j].Image = SlotMachine.Properties.Resources.purple;
                        break;
                }
            }
        }
        private void makeLine(String lineType, int iconAmount)
        {
            Thread[] threads = new Thread[5];
            if (lineType == "red")
            {
                for (int i = 0; i < 5; i++)
                {
                    int localVar = i;
                    threads[i] = new Thread(() => makeBorder("red", 0, localVar));
                }
                switch (iconAmount)
                {
                    case 2:
                        /*makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 0, 1);*/
                        threads[0].Start();
                        threads[1].Start();
                        break;
                    case 3:
                        /*makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 0, 1);
                        makeBorder(lineType, 0, 2);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        break;
                    case 4:
                        /*makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 0, 1);
                        makeBorder(lineType, 0, 2);
                        makeBorder(lineType, 0, 3);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        break;
                    case 5:
                        /*makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 0, 1);
                        makeBorder(lineType, 0, 2);
                        makeBorder(lineType, 0, 3);
                        makeBorder(lineType, 0, 4);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        threads[4].Start();
                        break;
                }
            }
            else if (lineType == "blue")
            {
                for (int i = 0; i < 5; i++)
                {
                    int localVar = i;
                    threads[i] = new Thread(() => makeBorder("blue", 1, localVar));
                }
                switch (iconAmount)
                {
                    case 2:
                        /*makeBorder(lineType, 1, 0);
                        makeBorder(lineType, 1, 1);*/
                        threads[0].Start();
                        threads[1].Start();
                        break;
                    case 3:
                        /*makeBorder(lineType, 1, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 1, 2);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        break;
                    case 4:
                        /*makeBorder(lineType, 1, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 1, 2);
                        makeBorder(lineType, 1, 3);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        break;
                    case 5:
                        /*makeBorder(lineType, 1, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 1, 2);
                        makeBorder(lineType, 1, 3);
                        makeBorder(lineType, 1, 4);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        threads[4].Start();
                        break;
                }
            }
            else if (lineType == "green")
            {
                 for (int i = 0; i < 5; i++)
                {
                    int localVar = i;
                    threads[i] = new Thread(() => makeBorder("green", 2, localVar));
                }
                switch (iconAmount)
                {
                    case 2:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 2, 1);*/
                        threads[0].Start();
                        threads[1].Start();
                        break;
                    case 3:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 2, 1);
                        makeBorder(lineType, 2, 2);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        break;
                    case 4:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 2, 1);
                        makeBorder(lineType, 2, 2);
                        makeBorder(lineType, 2, 3);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        break;
                    case 5:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 2, 1);
                        makeBorder(lineType, 2, 2);
                        makeBorder(lineType, 2, 3);
                        makeBorder(lineType, 2, 4);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        threads[4].Start();
                        break;
                }
            }
            else if (lineType == "yellow")
            {
                threads[0] = new Thread(() => makeBorder("yellow", 0, 0));
                threads[1] = new Thread(() => makeBorder("yellow", 1, 1));
                threads[2] = new Thread(() => makeBorder("yellow", 2, 2));
                threads[3] = new Thread(() => makeBorder("yellow", 1, 3));
                threads[4] = new Thread(() => makeBorder("yellow", 0, 4));
                switch (iconAmount)
                {
                    case 2:
                       /* makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 1, 1);*/
                        threads[0].Start();
                        threads[1].Start();
                        break;
                    case 3:
                       /* makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 2, 2);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        break;
                    case 4:
                        /*makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 2, 2);
                        makeBorder(lineType, 1, 3);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        break;
                    case 5:
                       /* makeBorder(lineType, 0, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 2, 2);
                        makeBorder(lineType, 1, 3);
                        makeBorder(lineType, 0, 4);*/
                         threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        threads[4].Start();
                        break;
                }   
            }
             else if (lineType == "purple")
            {
                threads[0] = new Thread(() => makeBorder("purple", 2, 0));
                threads[1] = new Thread(() => makeBorder("purple", 1, 1));
                threads[2] = new Thread(() => makeBorder("purple", 0, 2));
                threads[3] = new Thread(() => makeBorder("purple", 1, 3));
                threads[4] = new Thread(() => makeBorder("purple", 2, 4));
                switch (iconAmount)
                {
                    case 2:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 1, 1);*/
                        threads[0].Start();
                        threads[1].Start();
                        break;
                    case 3:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 0, 2);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        break;
                    case 4:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 0, 2);
                        makeBorder(lineType, 1, 3);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        break;
                    case 5:
                        /*makeBorder(lineType, 2, 0);
                        makeBorder(lineType, 1, 1);
                        makeBorder(lineType, 0, 2);
                        makeBorder(lineType, 1, 3);
                        makeBorder(lineType, 2, 4);*/
                        threads[0].Start();
                        threads[1].Start();
                        threads[2].Start();
                        threads[3].Start();
                        threads[4].Start();
                        break;
                }
            }
        }

        private void spin()
        {
            winWait.Stop();
            System.Media.SoundPlayer spinSound = new SoundPlayer();
            spinSound.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "start.wav";
            spinSound.Play();
            Thread.Sleep(500);

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    borderMatrix[i, j].Image = null;
                }
            }
            int rnd = random.Next(0, 100);
            if (rnd < jackpotChance)
            {
                JackpotScreen jackpotScreen = new JackpotScreen(bets[bet_pos_in_vector]);
                jackpotScreen.ShowDialog();
                userCredits += bets[bet_pos_in_vector] * 500;
                db.UpdateBalance(currentPlayer.getUsername(), userCredits);
                CreditsLabel.Text = "Credits:\n" + userCredits;
                jackpotChance = 0;
            }
            else
            {
                win = 0;
                WinLabel.Text = "Win:\n" + win;
                if (userCredits >= bets[bet_pos_in_vector])
                {
                    gambleButton.Hide();
                    updateMatrix();

                    userCredits -= bets[bet_pos_in_vector];
                    db.UpdateBalance(currentPlayer.getUsername(), userCredits);
                    CreditsLabel.Text = "Credits:\n" + userCredits;

                    winTypes = winningsCalculator.findWins(pictureMatrix, winTypes);
                    if (winTypes[0] != null)
                    {
                        winWait.Play();
                        win = calculateWin(bets[bet_pos_in_vector], winTypes);
                        gambleButton.Show();
                        userCredits += win;
                        CreditsLabel.Text = "Credits:\n" + userCredits;
                        WinLabel.Text = "Win:\n" + win;
                        db.UpdateBalance(currentPlayer.getUsername(), userCredits);

                    }
                }
                else
                {
                    MessageBox.Show("Sorry. You don't have enough credits!");
                }
                jackpotChance += 0.01;
            }
            xmlReader.updateJackpot(jackpotChance);
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
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
using System.IO;
using System.Media;

namespace SlotMachine {
    public partial class LoginScreen : Form {
        System.Reflection.Assembly databaseDLL;
        dynamic db;
        PrivateFontCollection egyptFont;
        SlotMachine.CurrentPlayer currentPlayer;
        System.IO.FileStream LogFile;
        int c = 1;
        TextWriterTraceListener txtListener;
        SoundPlayer menuMusic;



        public LoginScreen() {
            LogFile = new FileStream(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString() + "\\Logs.txt", FileMode.OpenOrCreate);
            txtListener = new TextWriterTraceListener(LogFile);
            Trace.AutoFlush = true;
            Trace.Listeners.Add(txtListener);

            menuMusic = new SoundPlayer();
            menuMusic.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "menu-music.wav";
            menuMusic.Play();


            

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            setupFont();
            InitializeComponent();
            setupScreen();
            databaseDLL = System.Reflection.Assembly.Load("Database");
            if (databaseDLL == null) {
                //MessageBox.Show("Could not load database assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            db = databaseDLL.CreateInstance("Database.Database");
            try {
                db.Init();
            }catch(Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void setupFont() {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        public void setupScreen() {
            BackgroundImage.Dock = DockStyle.Fill;

            setupLabel(userLabel, "Username:", 30);
            setupLabel(passwordLabel, "Password:", 30);
            setupLabel(noAccountLabel, "Don't have an account?", 25);

            setupTextBox(usernameTextbox);
            setupTextBox(passwordTextbox);

            setupButton(loginButton, "Login");
            setupButton(registerButton, "Register");
            setupButton(quitButton, "Quit");
            setupButton(muteButton, "Mute");

            int x = this.Width / 2;
            int y = this.Height / 2;

            //locations
            userLabel.Location = new Point(x - 250, y - 100);
            passwordLabel.Location = new Point(userLabel.Location.X, y);

            usernameTextbox.Location = new Point(userLabel.Location.X + 240, y - 105);
            passwordTextbox.Location = new Point(passwordLabel.Location.X + 240, y - 4);

            loginButton.Location = new Point(passwordLabel.Location.X + 160, y + 100);
            loginButton.FlatStyle = FlatStyle.Flat;
            registerButton.Location = new Point(loginButton.Location.X, loginButton.Location.Y + 120);
            quitButton.Location = new Point(x + 1050, y + 619);
            muteButton.Location = new Point(x + 1050, y+519 );

            noAccountLabel.Location = new Point(loginButton.Location.X - 100, loginButton.Location.Y + 90);
            noAccountLabel.ForeColor = Color.Crimson;

            casinoLogo.Location = new Point(usernameTextbox.Location.X - 250, usernameTextbox.Location.Y - 230);
            casinoLogo.Parent = BackgroundImage;
            casinoLogo.BackColor = Color.Transparent;
        }
        private void setupLabel(Label label, String text, int fontSize) {
            label.Parent = BackgroundImage;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.UseCompatibleTextRendering = true;
            label.ForeColor = Color.White;
        }

        private void setupTextBox(TextBox textBox) {
            textBox.Parent = BackgroundImage;
            textBox.BackColor = Color.Yellow;
        }

        private void setupButton(Button button, String text) {
            button.Font = new Font(egyptFont.Families[0], 22);
            button.BackColor = Color.Orange;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Yellow;
            button.Text = text;
            button.UseCompatibleTextRendering = true;
        }

        private void loginButton_Click(object sender, EventArgs e) {
            if (db.AuthenticateUser(usernameTextbox.Text, passwordTextbox.Text) == true) {
                this.Hide();
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tLogged in succesfully");
                currentPlayer = SlotMachine.CurrentPlayer.getInstance();
                currentPlayer.setUsername(usernameTextbox.Text);
                currentPlayer.setBalance(db.GetBalance(usernameTextbox.Text));
                MainMenuScreen mainMenu = new MainMenuScreen(menuMusic);
                usernameTextbox.Text = "";
                passwordTextbox.Text = "";
                mainMenu.ShowDialog();
                this.Show();     
            }
            else {
               // MessageBox.Show("Incorrect username and/or password!");
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm-tt") + "\tLogin fail: incorrect username and/or password");

            }
        }

        private void registerButton_Click(object sender, EventArgs e) {

            if (SlotMachine.RegisterScreen.registerInstance == null) {
                SlotMachine.RegisterScreen.registerInstance = new SlotMachine.RegisterScreen();
                SlotMachine.RegisterScreen.registerInstance.Show();
            }
        }

        private void quitButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void muteMusic_Click(object sender, EventArgs e)
        {
            c++;   
            if (c % 2 == 1)
            {
                menuMusic.PlayLooping();
                setupButton(muteButton, "Mute");
            }
            else if (c % 2 == 0)
            {
                menuMusic.Stop();
                setupButton(muteButton, "Unmute");
            }
        }
    }
}

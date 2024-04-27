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


namespace SlotMachine
{
    public partial class GambleScreen : Form
    {
        PrivateFontCollection egyptFont;
        Random random = new Random();
        int randomNumber;
        int counter;
        public GambleScreen()
        {
            InitializeComponent();
            setupScreen();
        }
        private void setupFont()
        {
            egyptFont = new PrivateFontCollection();
            int fontLength = Properties.Resources.ISIS.Length;
            byte[] fontData = Properties.Resources.ISIS;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            egyptFont.AddMemoryFont(data, fontLength);
        }

        public void setupScreen()
        {
            backgroundImage.Dock = DockStyle.Fill;
           
        }

            private void gamble(int winnings)
        {
           
           
        }

        private void setupLabel(Label label, String text, int fontSize)
        {
            label.Parent = backgroundImage;
            label.Font = new Font(egyptFont.Families[0], fontSize);
            label.BackColor = Color.Transparent;
            label.Text = text;
            label.UseCompatibleTextRendering = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            randomNumber = random.Next(0, 100);
            if (randomNumber < 49)
            {
                MessageBox.Show("Rosu vtm bv", randomNumber.ToString());
                counter++;
                if (counter == 5)
                {
                    MessageBox.Show("5 dublaje esti boss");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Sinucidete", randomNumber.ToString());
           
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            randomNumber = random.Next(0, 100);
            if (randomNumber > 50)
            {
                MessageBox.Show("Negru vtm bv", randomNumber.ToString());
                counter++;
                if (counter == 5)
                {
                    MessageBox.Show("5 dublaje esti boss");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Sinucidete",randomNumber.ToString());
           
        }
    }
}

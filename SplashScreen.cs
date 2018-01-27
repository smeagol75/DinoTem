using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DinoTem
{
    public partial class SplashScreen : Form
    {
        public static SplashScreen _SplashScreen;
        public SplashScreen()
        {
            InitializeComponent();
            _SplashScreen = this;
        }

        public int timeLeft { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }
            else
            {
                timer1.Stop();
                new Form1().Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timeLeft = 16;
            timer1.Start();

            // Imposto il colore trasparente del form
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.BackColor = System.Drawing.Color.Lime;
        }
    }
}

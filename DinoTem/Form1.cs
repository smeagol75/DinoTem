using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DinoTem.ui;
using Team_Editor_Manager_New_Generation.update;

namespace DinoTem
{
    public partial class Form1 : Form
    {
        public static Form1 _Form1;
        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
        }

        private Controller controller;

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new Controller();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private FolderBrowserDialog fbd;
        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                //verifico aggiornamenti
                if (new Updated().verificoAssembler() != new Updated().verificoVersioneAggiornata())
                {
                    Update forma = new Update();
                    forma.Show();

                    forma.label3.Text = new Updated().verificoAssembler();
                    forma.label4.Text = new Updated().verificoVersioneAggiornata();
                }
            }
            catch { }

            fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                controller.openDatabase(fbd.SelectedPath, teamBox1, teamBox2, teamsBox, stadiumsBox, ballsBox, teamCountry, stadiumCountry, teamStadium, giocatoreView, Form1._Form1);

                //abilitare i controlli
                tabControl1.Enabled = true;
                //Menu a tendina
                save.Enabled = true;
                import.Enabled = true;
                export.Enabled = true;
                removeFakeTeam.Enabled = true;
                removeFakeClassicPlayer.Enabled = true;
                reload.Enabled = true;
                loadFootballManager.Enabled = true;
                openDB2.Enabled = true;
            }
        }
    }
}

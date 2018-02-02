using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using Team_Editor_Manager_New_Generation.ui;
using DinoTem.model;
using DinoTem.ui;
using Team_Editor_Manager_New_Generation.update;
using Team_Editor_Manager_New_Generation.persistence;

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
        private const char chACapo = (char)13;

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new Controller();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            //Stadium Tab
            stadiumLicense.Items.Add("Licensed");
            stadiumLicense.Items.Add("Unlicensed");
            stadiumZone.Items.Add("Europe");
            stadiumZone.Items.Add("Asia");
            stadiumZone.Items.Add("South America");
            stadiumZone.Items.Add("Africa");
            stadiumZone.Items.Add("North America");
            stadiumZone.Items.Add("Oceania America");
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
                controller.openDatabase(fbd.SelectedPath, Form1._Form1);

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.closeMemory();
            SplashScreen._SplashScreen.Close();
        }

        //ball
        private void ballsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ballsBox.SelectedIndices.Count <= 0)
                return;

            //pulire i campi
            palloneName.Text = "";
            palloneID.Text = "";
            palloneOrder.Text = "";
            palloneUnknowB1.Text = "";
            palloneUnknowB2.Text = "";
            palloneUnknowB3.Text = "";
            palloneUnknowB4.Text = "";
            palloneUnknowB1.Enabled = false;
            palloneUnknowB2.Enabled = false;
            palloneUnknowB3.Enabled = false;
            palloneUnknowB4.Enabled = false;

            int intselectedindex = ballsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Ball pallone = controller.leggiPallone(intselectedindex);
                palloneID.Text = pallone.getId().ToString();
                palloneName.Text = pallone.getName();
                palloneOrder.Text = pallone.getOrder().ToString();
            }
        }

        private void applyBall_Click(object sender, EventArgs e)
        {
            int intselectedindex = ballsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Ball pallone = new Ball(ushort.Parse(palloneID.Text));
                pallone.setName(palloneName.Text);
                pallone.setOrder(byte.Parse(palloneOrder.Text));
                controller.applyBallPersister(intselectedindex, pallone);

                //Update listbox
                ballsBox.Items[intselectedindex] = palloneName.Text;
            }
        }

        //glove
        private void glovesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (glovesBox.SelectedIndices.Count <= 0)
                return;

            //pulire i campi
            guantoName.Text = "";
            guantoID.Text = "";
            guantoOrder.Text = "";
            guantoColor.Text = "";

            int intselectedindex = glovesBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Glove guanto = controller.leggiGuanto(intselectedindex);
                guantoID.Text = guanto.getId().ToString();
                guantoName.Text = guanto.getName();
                guantoOrder.Text = guanto.getOrder().ToString();
                guantoColor.Text = guanto.getColor();
            }
        }

        private void applyGlove_Click(object sender, EventArgs e)
        {
            int intselectedindex = glovesBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Glove glove = new Glove(ushort.Parse(guantoID.Text));
                glove.setName(guantoName.Text);
                glove.setOrder(byte.Parse(guantoOrder.Text));
                glove.setColor(guantoColor.Text);
                controller.applyGlovePersister(intselectedindex, glove);

                //Update listbox
                glovesBox.Items[intselectedindex] = guantoName.Text;
            }
        }

        //boot
        private void bootsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bootsBox.SelectedIndices.Count <= 0)
                return;

            //pulire i campi
            scarpaName.Text = "";
            scarpaID.Text = "";
            scarpaOrder.Text = "";
            scarpaColor.Text = "";
            scarpaMaterial.Text = "";

            int intselectedindex = bootsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Boot scarpa = controller.leggiScarpa(intselectedindex);
                scarpaID.Text = scarpa.getId().ToString();
                scarpaName.Text = scarpa.getName();
                scarpaOrder.Text = scarpa.getOrder().ToString();
                scarpaColor.Text = scarpa.getColor();
                scarpaMaterial.Text = scarpa.getMaterial();
            }
        }

        private void bootApply_Click(object sender, EventArgs e)
        {
            int intselectedindex = bootsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Boot boot = new Boot(ushort.Parse(scarpaID.Text));
                boot.setName(scarpaName.Text);
                boot.setOrder(byte.Parse(scarpaOrder.Text));
                boot.setColor(scarpaColor.Text);
                boot.setMaterial(scarpaMaterial.Text);
                controller.applyBootPersister(intselectedindex, boot);

                //Update listbox
                bootsBox.Items[intselectedindex] = scarpaName.Text;
            }
        }

        //stadium
        private void stadiumsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stadiumsBox.SelectedIndices.Count <= 0)
                return;

            //pulire campi
            stadiumName.Text = "";
            stadiumId.Text = "";
            stadiumOrder.Text = "";
            stadiumJapanese.Text = "";
            stadiumCapacity.Text = "";
            stadiumNa.Text = "";

            int intselectedindex = stadiumsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Stadium stadio = controller.leggiStadium(intselectedindex);
                stadiumName.Text = stadio.getName();
                stadiumId.Text = stadio.getId().ToString();
                stadiumJapanese.Text = stadio.getJapaneseName();
                stadiumCapacity.Text = stadio.getCapacity().ToString();
                stadiumNa.Text = stadio.getNa().ToString();
                stadiumZone.Text = stadio.getStringZone();
                stadiumLicense.Text = stadio.getStringLicense();
                stadiumCountry.SelectedIndex = controller.findCountry(stadio.getCountry());
                stadiumKonami.Text = stadio.getKonamiName();
            }
        }

        private void applyStadium_Click(object sender, EventArgs e)
        {
            int intselectedindex = stadiumsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Stadium stadium = new Stadium(ushort.Parse(stadiumId.Text));
                stadium.setCapacity(uint.Parse(stadiumCapacity.Text));
                stadium.setCountry(controller.leggiPaese(stadiumCountry.SelectedIndex).getId());
                stadium.setJapaneseName(stadiumJapanese.Text);
                if (stadiumLicense.Text.Equals("Licensed"))
                    stadium.setLicense(0);
                stadium.setNa(ushort.Parse(stadiumNa.Text));
                stadium.setName(stadiumName.Text);
                stadium.setZone(byte.Parse((stadiumZone.SelectedIndex + 2).ToString()));
                stadium.setKonamiName(stadiumKonami.Text);
                controller.applyStadiumPersister(intselectedindex, stadium);

                //Update listbox
                stadiumsBox.Items[intselectedindex] = stadiumName.Text;
            }
        }

        //coach
        private void coachBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coachBox.SelectedIndices.Count <= 0)
                return;

            //pulire campi
            allenatoreId.Text = "";
            allenatoreName.Text = "";
            allenatoreJap.Text = "";
            allenatoreLic.Checked = false;

            int intselectedindex = coachBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Coach allenatore = controller.leggiCoach(intselectedindex);
                allenatoreId.Text = allenatore.getId().ToString();
                allenatoreName.Text = allenatore.getName();
                allenatoreJap.Text = allenatore.getJapName();
                allenatoreNationality.SelectedIndex = controller.findCountry(allenatore.getCountry());
                if (allenatore.getByteLic() != 0)
                    allenatoreLic.Visible = true;
                else
                    allenatoreLic.Visible = false;
                    
            }
        }

        private void applyCoach_Click(object sender, EventArgs e)
        {
            int intselectedindex = coachBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Coach coach = new Coach(uint.Parse(allenatoreId.Text));
                coach.setJapName(allenatoreJap.Text);
                coach.setCountry((ushort) controller.leggiPaese(allenatoreNationality.SelectedIndex).getId());
                coach.setName(allenatoreName.Text);
                if (allenatoreLic.Checked == true)
                    coach.setByteLic(0);
                else
                    coach.setByteLic(1);
                controller.applyCoachPersister(intselectedindex, coach);

                //Update listbox
                coachBox.Items[intselectedindex] = allenatoreName.Text;
            }
        }

        private void allenatoriLic_CheckedChanged(object sender, EventArgs e)
        {
            int intselectedindex = coachBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Coach allenatore = controller.leggiCoach(intselectedindex);
                allenatoreId.Text = allenatore.getCoachLicId().ToString();
            }
        }

        //save
        private void save_Click(object sender, EventArgs e)
        {
            controller.saveBallPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveGlovePersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveBootPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveStadiumPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveCoachPersister(fbd.SelectedPath, controller, controller.getBitRecognized());

            MessageBox.Show("Saved Data", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("All Files Saved at:" + Environment.NewLine + fbd.SelectedPath, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

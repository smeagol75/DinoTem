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
using UniDecode;

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
        private ControllerDB controllerDb;
        private ControllerFm controllerFm;
        private const char chACapo = (char)13;

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new Controller();
            controllerDb = new ControllerDB();
            controllerFm = new ControllerFm();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            //teams
            teamNotPlayableLeague.Items.Add("No League");
            teamNotPlayableLeague.Items.Add("Classic League");
            teamNotPlayableLeague.Items.Add("Other Europe League");
            teamNotPlayableLeague.Items.Add("Other Asian League");
            teamNotPlayableLeague.Items.Add("Hidden Fake European League");
            teamNotPlayableLeague.Items.Add("ML Hidden League");
            teamNotPlayableLeague.Items.Add("Other America League");
            teamNotPlayableLeague.Items.Add("Other Africa League");
            teamLicense.Items.Add("Unlicensed");
            teamLicense.Items.Add("Licensed");
            teamCoachLicense.Items.Add("Unlicensed");
            teamCoachLicense.Items.Add("Licensed");
            teamFake.Items.Add("No");
            teamFake.Items.Add("Yes");
            teamHasLicensedPlayers.Items.Add("No");
            teamHasLicensedPlayers.Items.Add("Yes");
            teamAnthem.Items.Add("No");
            teamAnthem.Items.Add("Yes");
            teamType.Items.Add("Club");
            teamType.Items.Add("National");
            //Stadium Tab
            stadiumLicense.Items.Add("Licensed");
            stadiumLicense.Items.Add("Unlicensed");
            stadiumZone.Items.Add("Europe");
            stadiumZone.Items.Add("Asia");
            stadiumZone.Items.Add("South America");
            stadiumZone.Items.Add("Africa");
            stadiumZone.Items.Add("North America");
            stadiumZone.Items.Add("Oceania America");
            //Caricamento Database
            databaseBox.Items.Add("Stadium");

            //ToolTip
            toolTip1.ToolTipTitle = "DinoTem Editor";
            toolTip1.SetToolTip(playersBox, "Click to select a player" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(searchPlayer, "Write a player name and click ENTER" + Environment.NewLine + Environment.NewLine + "If you don't see the player, click again ENTER" + Environment.NewLine + "" + "Note: You can also write a few letters of a player");
            toolTip1.SetToolTip(searchTeamAB, "Write a team name and click ENTER" + Environment.NewLine + Environment.NewLine + "If you don't see the team, click again ENTER" + Environment.NewLine + "" + "Note: You can also write a few letters of a team");
            toolTip1.SetToolTip(searchById, "Click if you want to search by id");
            toolTip1.SetToolTip(teamView1, "Click to select a player" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamView2, "Click to select a player" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamBox1, "Click to select a team");
            toolTip1.SetToolTip(teamBox2, "Click to select a team");
            toolTip1.SetToolTip(giocatoreName, "Change Player Name" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(giocatoreShirt, "Change Shirt Name" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(giocatoreNumber, "Change Player Number" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");

            toolTip1.SetToolTip(searchTeam, "Write a team name and click ENTER" + Environment.NewLine + Environment.NewLine + "If you don't see the team, click again ENTER" + Environment.NewLine + "" + "Note: You can also write a few letters of a team");
            toolTip1.SetToolTip(teamsBox, "Click to select a team" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamName, "Change team name" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamShort, "Change short name" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamFake, "Change if the team is a fake");
            toolTip1.SetToolTip(teamNotPlayableLeague, "Change league of team");
            toolTip1.SetToolTip(teamFake, "Change if the team is a fake");
            toolTip1.SetToolTip(teamLicense, "Change team's license");
            toolTip1.SetToolTip(teamCoachLicense, "Change coach's license");
            toolTip1.SetToolTip(teamType, "Change team's type");
            toolTip1.SetToolTip(teamCountry, "Change team's country");
            toolTip1.SetToolTip(teamStadium, "Change team's stadium");
            toolTip1.SetToolTip(teamCoach, "Change team's coach");
            toolTip1.SetToolTip(teamAnthem, "Change team's anthem");
            toolTip1.SetToolTip(teamHasLicensedPlayers, "Change if theam has licensed players");
            toolTip1.SetToolTip(unknown, "Change unknown value");
            toolTip1.SetToolTip(anthemStandingAngle, "Change anthem standing angle");
            toolTip1.SetToolTip(anthemPlayersSinging, "Change anthem players singing");
            toolTip1.SetToolTip(anthemStandingStyle, "anthem standing style");
            toolTip1.SetToolTip(teamJapanese, "Change team name (only Japanese language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamFrench, "Change team name (only French language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamDutch, "Change team name (only Dutch language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamSpanish, "Change team name (only Spanish language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamTurkish, "Change team name (only Turkish language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamSwedish, "Change team name (only Swedish language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamGreek, "Change team name (only Greek language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamPortuguese, "Change team name (only Portuguese language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamItalian, "Change team name (only Italian language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamEnglish, "Change team name (only English language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamGerman, "Change team name (only German language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamRussian, "Change team name (only Russian language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamSpanish2, "Change team name (only Spanish (Latin American) language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamPortuguese2, "Change team name (only Portuguese (Latin American) language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
            toolTip1.SetToolTip(teamEnglish2, "Change team name (only English (UK) language)" + Environment.NewLine + Environment.NewLine + "Press ENTER to save");
        }

        private void sfondoTeamView()
        {
            try
            {
                //colore sfondo
                int i5 = 0;
                int NumberOfRepetitions5 = Convert.ToInt32(10);
                for (i5 = 0; i5 <= NumberOfRepetitions5; i5++)
                {
                    teamView1.Items[i5].SubItems[0].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i5].SubItems[1].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i5].SubItems[2].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i5].SubItems[3].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[0].UseItemStyleForSubItems = false;
                }
            }
            catch { }

            try
            {
                //colore sfondo
                int i5 = 0;
                int NumberOfRepetitions5 = Convert.ToInt32(10);
                for (i5 = 0; i5 <= NumberOfRepetitions5; i5++)
                {
                    teamView2.Items[i5].SubItems[0].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView2.Items[i5].SubItems[1].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView2.Items[i5].SubItems[2].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView2.Items[i5].SubItems[3].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView2.Items[0].UseItemStyleForSubItems = false;
                }
            }
            catch { }

            try
            {
                //tutti in numeri in nero
                string numeri = "";
                int i6 = 0;
                int NumberOfRepetitions6 = Convert.ToInt32(teamView1.Items.Count);
                for (i6 = 1; i6 <= NumberOfRepetitions6; i6++)
                {
                    teamView1.Items[i6 - 1].SubItems[3].ForeColor = SystemColors.WindowText;

                    //vedere se ci sono numeri uguali
                    numeri = numeri + teamView1.Items[i6 - 1].SubItems[3].Text + ",";
                }

                //TeamA
                numeri = numeri.Substring(0, numeri.Length - 1);
                string[] words = numeri.Split(',');

                foreach (string word in words)
                {
                    int numero = 0;
                    int i4 = 0;
                    int NumberOfRepetitions4 = Convert.ToInt32(words.Length);
                    for (i4 = 1; i4 <= NumberOfRepetitions4; i4++)
                    {
                        if (word == words[i4 - 1])
                        {
                            numero = numero + 1;
                            if (numero > 1)
                            {
                                //cambiare il primo numero uguale
                                int i2 = 0;
                                int NumberOfRepetitions2 = Convert.ToInt32(teamView1.Items.Count);
                                for (i2 = 1; i2 <= NumberOfRepetitions2; i2++)
                                {
                                    if (word == teamView1.Items[i2 - 1].SubItems[3].Text)
                                    {
                                        teamView1.Items[i2 - 1].SubItems[3].ForeColor = System.Drawing.Color.Red;
                                        teamView1.Items[i2 - 1].UseItemStyleForSubItems = false;
                                    }
                                }
                                //numero
                                teamView1.Items[i4 - 1].SubItems[3].ForeColor = System.Drawing.Color.Red;
                                teamView1.Items[i4 - 1].UseItemStyleForSubItems = false;
                            }
                        }
                    }
                }
                //
            }
            catch { }

            try
            {
                //tutti in numeri in nero
                string numeri1 = "";
                int i7 = 0;
                int NumberOfRepetitions7 = Convert.ToInt32(teamView2.Items.Count);
                for (i7 = 1; i7 <= NumberOfRepetitions7; i7++)
                {
                    teamView2.Items[i7 - 1].SubItems[3].ForeColor = SystemColors.WindowText;

                    //vedere se ci sono numeri uguali
                    numeri1 = numeri1 + teamView2.Items[i7 - 1].SubItems[3].Text + ",";
                }

                //TeamB
                numeri1 = numeri1.Substring(0, numeri1.Length - 1);
                string[] words1 = numeri1.Split(',');

                foreach (string word in words1)
                {
                    int numero1 = 0;
                    int i4 = 0;
                    int NumberOfRepetitions4 = Convert.ToInt32(words1.Length);
                    for (i4 = 1; i4 <= NumberOfRepetitions4; i4++)
                    {
                        if (word == words1[i4 - 1])
                        {
                            numero1 = numero1 + 1;
                            if (numero1 > 1)
                            {
                                //cambiare il primo numero uguale
                                int i2 = 0;
                                int NumberOfRepetitions2 = Convert.ToInt32(teamView2.Items.Count);
                                for (i2 = 1; i2 <= NumberOfRepetitions2; i2++)
                                {
                                    if (word == teamView2.Items[i2 - 1].SubItems[3].Text)
                                    {
                                        teamView2.Items[i2 - 1].SubItems[3].ForeColor = System.Drawing.Color.Red;
                                        teamView2.Items[i2 - 1].UseItemStyleForSubItems = false;
                                    }
                                }
                                //numero
                                teamView2.Items[i4 - 1].SubItems[3].ForeColor = System.Drawing.Color.Red;
                                teamView2.Items[i4 - 1].UseItemStyleForSubItems = false;
                            }
                        }
                    }
                }
                //
            }
            catch { }
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
            }
        }

        //reload
        private void reload_Click(object sender, EventArgs e)
        {
            controller.openDatabase(fbd.SelectedPath, Form1._Form1);
        }

        //form che si sta chiudendo
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.No))
                e.Cancel = true;
            else
            {
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\Temp");
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
                e.Cancel = false;
                controller.closeMemory();
                SplashScreen._SplashScreen.Close();
            }
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

                List<BallCondition> ballCondition = controller.leggiCondizioniPalloni(pallone.getId());
                controller.getBallConditionById(ballCondition, palloneUnknowB1, palloneUnknowB2, palloneUnknowB3, palloneUnknowB4);
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
                List<BallCondition> ba = controller.leggiCondizioniPalloni(pallone.getId());
                if (ba.Count == 1)
                    controller.applyBallConditionPersister(byte.Parse(palloneUnknowB1.Text), 0, 0, 0, ba);
                else if (ba.Count == 2)
                    controller.applyBallConditionPersister(byte.Parse(palloneUnknowB1.Text), byte.Parse(palloneUnknowB2.Text), 0, 0, ba);
                else if (ba.Count == 3)
                    controller.applyBallConditionPersister(byte.Parse(palloneUnknowB1.Text), byte.Parse(palloneUnknowB2.Text), byte.Parse(palloneUnknowB3.Text), 0, ba);
                else if (ba.Count == 4)
                    controller.applyBallConditionPersister(byte.Parse(palloneUnknowB1.Text), byte.Parse(palloneUnknowB2.Text), byte.Parse(palloneUnknowB3.Text), byte.Parse(palloneUnknowB4.Text), ba);

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
                teamStadium.Items[intselectedindex] = stadiumName.Text;
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
                teamCoach.Items[intselectedindex] = allenatoreName.Text;
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

        //player
        private void leggereGiocatore(Player temp)
        {
            giocatoreNazionale.Text = "";
            giocatoreSquadra.Text = "";
            giocatoreNumber.Text = "";

            giocatoreName.Text = temp.getName();
            giocatoreShirt.Text = temp.getShirtName();
            giocatoreID.Text = temp.getId().ToString();
            giocatoreType.Text = temp.getStringFake();
            giocatoreAge.Text = temp.getAge().ToString();
            giocatoreWeight.Text = temp.getWeight().ToString();
            giocatoreHeight.Text = temp.getHeight().ToString();
            giocatoreForm.Text = temp.getForm().ToString();
            giocatoreAcc.Text = temp.getWeakFootAcc().ToString();
            giocatoreUse.Text = temp.getWcUsage().ToString();
            giocatoreInjury.Text = temp.getInjuryRes().ToString();

            attack.Text = temp.getAttack().ToString();
            ballControll.Text = temp.getBallControll().ToString();
            dribbling.Text = temp.getDribbling().ToString();
            lowPass.Text = temp.getLowPass().ToString();
            loftedPass.Text = temp.getLoftedPass().ToString();
            finishing.Text = temp.getFinishing().ToString();
            placeKick.Text = temp.getPlaceKick().ToString();
            swerve.Text = temp.getSwerve().ToString();
            header.Text = temp.getHeader().ToString();
            defense.Text = temp.getDefense().ToString();
            ballWinning.Text = temp.getBallWinning().ToString();
            kickingPower.Text = temp.getKickingPower().ToString();
            speed.Text = temp.getSpeed().ToString();
            explosivePower.Text = temp.getExplosiveP().ToString();
            bodyControll.Text = temp.getBodyControl().ToString();
            physical.Text = temp.getPhysical().ToString();
            jump.Text = temp.getJump().ToString();
            stamina.Text = temp.getStamina().ToString();
            goalkeeping.Text = temp.getGoalkeeping().ToString();
            cathing.Text = temp.getCathing().ToString();
            clearing.Text = temp.getClearing().ToString();
            reflexes.Text = temp.getReflexes().ToString();
            coverage.Text = temp.getCoverage().ToString();
            giocatoreFoot.Text = temp.getStringStrongerFoot();
            //giocatoreSquadra.Text = controller.getStringClubTeamOfPlayer(temp.getId(), 0);
            //giocatoreNazionale.Text = controller.getStringClubTeamOfPlayer(temp.getId(), 1);
            giocatoreNationality.SelectedIndex = controller.findCountry(temp.getNational());

            //controllerFm
            controllerFm.setPlayer(temp);
        }

        private void playersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playersBox.SelectedIndices.Count <= 0)
                return;

            int intselectedindex = playersBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                leggereGiocatore(controller.leggiGiocatore(intselectedindex));
                //
                team = 0;
            }
        }

        //team
        private void teamsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;

            //pulire campi
            teamDutch.Text = "";
            teamEnglish.Text = "";
            teamEnglish2.Text = "";
            teamFrench.Text = "";
            teamGerman.Text = "";
            teamGreek.Text = "";
            teamItalian.Text = "";
            teamPortuguese.Text = "";
            teamPortuguese2.Text = "";
            teamRussian.Text = "";
            teamSpanish.Text = "";
            teamSpanish2.Text = "";
            teamSwedish.Text = "";
            teamTurkish.Text = "";

            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team team = controller.leggiSquadra(intselectedindex);
                teamName.Text = team.getEnglish();
                teamJapanese.Text = team.getJapanese();
                teamID.Text = team.getId().ToString();
                teamShort.Text = team.getShortSquadra();
                
                teamLicense.Text = team.getStringLicensedTeam();
                teamType.Text = team.getStringNational();
                teamFake.Text = team.getStringFakeTeam();
                teamCoachLicense.Text = team.getStringLicensedCoach();
                teamCoach.SelectedIndex = controller.findCoach(team.getManagerId());
                teamNotPlayableLeague.Text = team.getStringNotPlayableLeague();
                teamStadium.SelectedIndex = controller.findStadium(team.getStadiumId());
                teamHasLicensedPlayers.Text = team.getStringHasLicensedPlayers();
                teamAnthem.Text = team.getStringHasAnthem();
                teamKonami.Text = team.getKonami();
                anthemStandingAngle.Value = team.getAnthemStandingAngle();
                anthemPlayersSinging.Value = team.getAnthemPlayersSinging();
                anthemStandingStyle.Value = team.getAnthemStandingStyle();

                if (team.getUnknown6() == 1)
                    unknown.Checked = true;
                else
                    unknown.Checked = false;

                if (team.getNational() == 1)
                {
                    National temp2 = (National)team;
                    teamDutch.Enabled = true;
                    teamEnglish.Enabled = true;
                    teamEnglish2.Enabled = true;
                    teamFrench.Enabled = true;
                    teamGerman.Enabled = true;
                    teamGreek.Enabled = true;
                    teamItalian.Enabled = true;
                    teamPortuguese.Enabled = true;
                    teamPortuguese2.Enabled = true;
                    teamRussian.Enabled = true;
                    teamSpanish.Enabled = true;
                    teamSpanish2.Enabled = true;
                    teamSwedish.Enabled = true;
                    teamTurkish.Enabled = true;
                    teamDutch.Text = temp2.getDutch();
                    teamEnglish.Text = temp2.getEnglish();
                    teamEnglish2.Text = temp2.getEnglishUS();
                    teamFrench.Text = temp2.getFrench();
                    teamGerman.Text = temp2.getGerman();
                    teamGreek.Text = temp2.getGreek();
                    teamItalian.Text = temp2.getItalian();
                    teamPortuguese.Text = temp2.getPortuguese();
                    teamPortuguese2.Text = temp2.getBrazilianPortuguese();
                    teamRussian.Text = temp2.getRussian();
                    teamSpanish.Text = temp2.getSpanish();
                    teamSpanish2.Text = temp2.getLatinAmericaSpanish();
                    teamSwedish.Text = temp2.getSwedish();
                    teamTurkish.Text = temp2.getTurkish();
                }
                else
                {
                    teamDutch.Enabled = false;
                    teamEnglish.Enabled = false;
                    teamEnglish2.Enabled = false;
                    teamFrench.Enabled = false;
                    teamGerman.Enabled = false;
                    teamGreek.Enabled = false;
                    teamItalian.Enabled = false;
                    teamPortuguese.Enabled = false;
                    teamPortuguese2.Enabled = false;
                    teamRussian.Enabled = false;
                    teamSpanish.Enabled = false;
                    teamSpanish2.Enabled = false;
                    teamSwedish.Enabled = false;
                    teamTurkish.Enabled = false;
                }
                teamCountry.SelectedIndex = controller.findCountry(team.getCountry());

            }
        }

        private void applyTeam_Click(object sender, EventArgs e)
        {
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team team = null;
                if (teamType.Text == "Club")
                    team = new Club(uint.Parse(teamID.Text));
                else
                    team = new National(uint.Parse(teamID.Text));
                team.setAnthemPlayersSinging(uint.Parse(anthemPlayersSinging.Value.ToString()));
                team.setAnthemStandingAngle(uint.Parse(anthemStandingAngle.Value.ToString()));
                team.setAnthemStandingStyle(uint.Parse(anthemStandingStyle.Value.ToString()));
                team.setCountry((ushort)controller.leggiPaese(teamCountry.SelectedIndex).getId());
                if (teamFake.Text == "Yes")
                    team.setFakeTeam(1);
                else
                    team.setFakeTeam(0);
                //team.setFeederTeamId();
                team.setHasAnthem(uint.Parse(teamAnthem.SelectedIndex.ToString()));
                team.setHasLicensedPlayers(uint.Parse(teamHasLicensedPlayers.SelectedIndex.ToString()));
                team.setLicensedCoach(uint.Parse(teamCoachLicense.SelectedIndex.ToString()));
                team.setLicensedCoach2(uint.Parse(teamCoachLicense.SelectedIndex.ToString()));
                team.setLicensedTeam(uint.Parse(teamLicense.SelectedIndex.ToString()));
                team.setNational(uint.Parse(teamType.SelectedIndex.ToString()));
                team.setManagerId(controller.leggiCoach(teamCoach.SelectedIndex).getId());
                team.setNotPlayableLeague(uint.Parse(teamNotPlayableLeague.SelectedIndex.ToString()));
                //team.setParentTeamId
                team.setShortSquadra(teamShort.Text);
                team.setStadiumId((ushort)controller.leggiStadium(teamStadium.SelectedIndex).getId());
                if (unknown.Checked == true)
                    team.setUnknown6(1);
                else
                    team.setUnknown6(0);
                if (team.getNational() == 1)
                {
                    if (teamName.Text != controller.leggiSquadra(intselectedindex).getEnglish())
                    {
                        teamJapanese.Text = teamName.Text;
                        teamDutch.Text = teamName.Text;
                        teamEnglish.Text = teamName.Text;
                        teamEnglish2.Text = teamName.Text;
                        teamFrench.Text = teamName.Text;
                        teamGerman.Text = teamName.Text;
                        teamGreek.Text = teamName.Text;
                        teamItalian.Text = teamName.Text;
                        teamPortuguese.Text = teamName.Text;
                        teamPortuguese2.Text = teamName.Text;
                        teamRussian.Text = teamName.Text;
                        teamSpanish.Text = teamName.Text;
                        teamSpanish2.Text = teamName.Text;
                        teamSwedish.Text = teamName.Text;
                        teamTurkish.Text = teamName.Text;
                    }

                    National temp2 = (National)team;
                    temp2.setDutch(teamDutch.Text);
                    team.setEnglish(teamEnglish.Text);
                    temp2.setEnglishUS(teamEnglish2.Text);
                    temp2.setFrench(teamFrench.Text);
                    temp2.setGerman(teamGerman.Text);
                    temp2.setGreek(teamGreek.Text);
                    temp2.setItalian(teamItalian.Text);
                    temp2.setPortuguese(teamPortuguese.Text);
                    temp2.setBrazilianPortuguese(teamPortuguese2.Text);
                    temp2.setRussian(teamRussian.Text);
                    temp2.setSpanish(teamSpanish.Text);
                    temp2.setLatinAmericaSpanish(teamSpanish2.Text);
                    temp2.setSwedish(teamSwedish.Text);
                    temp2.setTurkish(teamTurkish.Text);
                    team.setJapanese(teamJapanese.Text);
                }
                else
                {
                    if (teamName.Text != controller.leggiSquadra(intselectedindex).getEnglish())
                    {
                        teamJapanese.Text = teamName.Text;
                        teamEnglish.Text = teamName.Text;
                    }

                    team.setEnglish(teamName.Text);
                    team.setJapanese(teamJapanese.Text);
                }
                team.setKonami(teamKonami.Text);

                controller.applyTeamPersister(intselectedindex, team);

                //Update listbox
                teamsBox.Items[intselectedindex] = teamName.Text;
                teamBox1.Items[intselectedindex] = teamName.Text;
                teamBox2.Items[intselectedindex] = teamName.Text;
                derbyTeam1.Items[intselectedindex] = teamName.Text;
                derbyTeam2.Items[intselectedindex] = teamName.Text;
                for (int i1 = 0; i1 < Form1._Form1.DataGridView_derby.RowCount; i1++)
                {
                    if (Form1._Form1.DataGridView_derby.Rows[i1].Cells[0].Value.ToString() == team.getId().ToString())
                        Form1._Form1.DataGridView_derby.Rows[i1].Cells[1].Value = team.getEnglish();
                    if (Form1._Form1.DataGridView_derby.Rows[i1].Cells[2].Value.ToString() == team.getId().ToString())
                        Form1._Form1.DataGridView_derby.Rows[i1].Cells[3].Value = team.getEnglish();
                }

            }
        }

        //derby
        private void DataGridView_derby_SelectionChanged(object sender, EventArgs e)
        {
            derbyTeam1.Text = DataGridView_derby.CurrentRow.Cells[1].Value.ToString();
            derbyTeam2.Text = DataGridView_derby.CurrentRow.Cells[3].Value.ToString();
            derbyKind.Value = decimal.Parse(DataGridView_derby.CurrentRow.Cells[4].Value.ToString());
            derbySlot.Value = decimal.Parse(DataGridView_derby.CurrentRow.Cells[5].Value.ToString());
            derbyOrder.Value = decimal.Parse(DataGridView_derby.CurrentRow.Cells[6].Value.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Derby derby = new Derby();
            derby.setTeam1DerbyId(controller.leggiSquadra(derbyTeam1.SelectedIndex).getId());
            derby.setTeam2DerbyId(controller.leggiSquadra(derbyTeam2.SelectedIndex).getId());
            derby.setFragVal2((ushort)derbyKind.Value);
            derby.setFragVal3((ushort)derbySlot.Value);
            derby.setFragVal4((ushort)derbyOrder.Value);

            controller.applyDerbyPersister(DataGridView_derby.CurrentRow.Index, derby);

            DataGridView_derby.CurrentRow.Cells[1].Value = derbyTeam1.Text;
            DataGridView_derby.CurrentRow.Cells[3].Value = derbyTeam2.Text;
            DataGridView_derby.CurrentRow.Cells[4].Value = derbyKind.Value;
            DataGridView_derby.CurrentRow.Cells[5].Value = derbySlot.Value;
            DataGridView_derby.CurrentRow.Cells[6].Value = derbyOrder.Value;
        }

        //save
        private void save_Click(object sender, EventArgs e)
        {
            controller.saveBallPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveGlovePersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveBootPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveStadiumPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveCoachPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.savePlayerPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveTeamPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.savePlayerAssignmentPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveTacticsPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveTacticsFormationPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveBallConditionPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveDerbyPersister(fbd.SelectedPath, controller, controller.getBitRecognized());

            MessageBox.Show("Saved Data", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("All Files Saved at:" + Environment.NewLine + fbd.SelectedPath, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Colorare TextBox
        private void attack_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(attack);
        }

        private void ballControll_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(ballControll);
        }

        private void dribbling_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(dribbling);
        }

        private void lowPass_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(lowPass);
        }

        private void loftedPass_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(loftedPass);
        }

        private void finishing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(finishing);
        }

        private void placeKick_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(placeKick);
        }

        private void swerve_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(swerve);
        }

        private void header_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(header);
        }

        private void defense_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(defense);
        }

        private void ballWinning_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(ballWinning);
        }

        private void kickingPower_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(kickingPower);
        }

        private void speed_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(speed);
        }

        private void explosivePower_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(explosivePower);
        }

        private void bodyControll_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(bodyControll);
        }

        private void physical_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(physical);
        }

        private void jump_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(jump);
        }

        private void stamina_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(stamina);
        }

        private void goalkeeping_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(goalkeeping);
        }

        private void cathing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(cathing);
        }

        private void clearing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(clearing);
        }

        private void reflexes_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(reflexes);
        }

        private void coverage_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabel(coverage);
        }

        //ricerca squadre A/B
        private void searchTeamAB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if ((searchTeamAB.Text.StartsWith("A-") || searchTeamAB.Text.StartsWith("a-")) && searchTeamAB.Text.Length > 2)
                    UtilGUI.comboBoxSearch(teamBox1, searchTeamAB);
                else if ((searchTeamAB.Text.StartsWith("B-") || searchTeamAB.Text.StartsWith("b-")) && searchTeamAB.Text.Length > 2)
                    UtilGUI.comboBoxSearch(teamBox2, searchTeamAB);
                else
                    MessageBox.Show("Invalid syntax!" + chACapo + "Example: A-london for Team A" + chACapo + "Example: a-london for Team A" + chACapo + "Example 2: B-juve for Team B" + chACapo + "Example 2: b-juve for Team B", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchTeamAB_Click(object sender, EventArgs e)
        {
            searchTeamAB.SelectAll();
            searchTeamAB.Focus();
        }

        private void searchT_Click(object sender, EventArgs e)
        {
            if ((searchTeamAB.Text.StartsWith("A-") || searchTeamAB.Text.StartsWith("a-")) && searchTeamAB.Text.Length > 2)
                UtilGUI.comboBoxSearch(teamBox1, searchTeamAB);
            else if ((searchTeamAB.Text.StartsWith("B-") || searchTeamAB.Text.StartsWith("b-")) && searchTeamAB.Text.Length > 2)
                UtilGUI.comboBoxSearch(teamBox2, searchTeamAB);
            else
                MessageBox.Show("Invalid syntax!" + chACapo + "Example: A-london for Team A" + chACapo + "Example: a-london for Team A" + chACapo + "Example 2: B-juve for Team B" + chACapo + "Example 2: b-juve for Team B", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //ricerca giocatori (invio)
        private void searchPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(playersBox, searchPlayer);
            }
        }

        private void searchPlayer_Click(object sender, EventArgs e)
        {
            searchPlayer.SelectAll();
            searchPlayer.Focus();
        }

        private void searchP_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(playersBox, searchPlayer);
        }

        //ricerca squadre (invio)
        private void searchTeam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(teamsBox, searchTeam);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(teamsBox, searchTeam);
        }

        private void searchTeam_Click(object sender, EventArgs e)
        {
            searchTeam.SelectAll();
            searchTeam.Focus();
        }

        //ricerca stadi
        private void searchStadium_TextChanged(object sender, EventArgs e)
        {
            searchStadium.SelectAll();
            searchStadium.Focus();
        }

        private void searchStadium_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(stadiumsBox, searchStadium);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(stadiumsBox, searchStadium);
        }

        //ricerca palloni
        private void searchBall_TextChanged(object sender, EventArgs e)
        {
            searchBall.SelectAll();
            searchBall.Focus();
        }

        private void searchBall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(ballsBox, searchBall);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(ballsBox, searchBall);
        }

        //ricerca allenatori
        private void searchCoach_TextChanged(object sender, EventArgs e)
        {
            searchCoach.SelectAll();
            searchCoach.Focus();
        }

        private void searchCoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(coachBox, searchCoach);
            }
        }

        private void searchC_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(coachBox, searchCoach);
        }

        //ricerca boot
        private void searchBoot_TextChanged(object sender, EventArgs e)
        {
            searchBoot.SelectAll();
            searchBoot.Focus();
        }

        private void searchBoot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(bootsBox, searchBoot);
            }
        }

        private void searchB_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(bootsBox, searchBoot);
        }

        private void searchGlove_TextChanged(object sender, EventArgs e)
        {
            searchGlove.SelectAll();
            searchGlove.Focus();
        }

        private void searchGlove_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(glovesBox, searchGlove);
            }
        }

        private void searchG_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(glovesBox, searchGlove);
        }

        //Caratteri speciali
        private void characterS1_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Res\charmap.exe");
        }

        //selezionare Team
        private ListViewItem Leggere_GiocatoreSquadre(PlayerAssignment pAssignment)
        {
            ListViewItem item = new ListViewItem();
            Player temp2 = controller.leggiGiocatoreById(pAssignment.getPlayerId());

            item = new ListViewItem((pAssignment.getOrder() + 1).ToString());
            item.SubItems.Add(temp2.getStringPosition());
            item.SubItems.Add(temp2.getName());
            item.SubItems.Add(pAssignment.getShirtNumber().ToString());
            item.SubItems.Add(pAssignment.getEntryId().ToString());
            item.SubItems.Add(pAssignment.getCaptain().ToString());
            item.SubItems.Add(pAssignment.getLeftCkTk().ToString());
            item.SubItems.Add(pAssignment.getLongShotLk().ToString());
            item.SubItems.Add(pAssignment.getPenaltyKick().ToString());
            item.SubItems.Add(pAssignment.getRightCornerKick().ToString());
            item.SubItems.Add(pAssignment.getShortFoulFk().ToString());
            item.SubItems.Add(pAssignment.getPlayerId().ToString());

            return item;
        }

        private void LeggereFormazioni(List<TacticsFormation> position, ListView list)
        {
            int k = 0;
            foreach (TacticsFormation temp in position)
            {
                if (k <= 10)
                    list.Items[k].SubItems[1].Text = temp.getStringPosition();
                k++;
            }
        }

        //A
        private void teamBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamView1.Items.Clear();

            List<PlayerAssignment> list = controller.leggiGiocatoriSquadra(controller.leggiSquadra(teamBox1.SelectedIndex).getId());
            foreach (PlayerAssignment temp2 in list)
            {
                teamView1.Items.Add(Leggere_GiocatoreSquadre(temp2));
            }

            if (teamView1.Items.Count > 10)
            {
                List<Tactics> tactics = controller.leggiTattica(controller.leggiSquadra(teamBox1.SelectedIndex).getId());
                if (tactics.Count > 0)
                {
                    List<TacticsFormation> tacticsFormation = controller.leggiFormazione(tactics[0].getTacticsId());
                    if (tacticsFormation.Count > 0)
                        LeggereFormazioni(tacticsFormation, teamView1);
                }
            }

            sfondoTeamView();
        }

        //selezionare giocatore da teamView1
        private void teamView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamView1.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                UInt32 id = uint.Parse(teamView1.Items[intselectedindex].SubItems[11].Text);
                Player temp2 = controller.leggiGiocatoreById(id);
                leggereGiocatore(temp2);
                giocatoreNumber.Text = teamView1.Items[intselectedindex].SubItems[3].Text;
                //
                team = 1;
            }
        }

        //B
        private void teamBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamView2.Items.Clear();

            List<PlayerAssignment> list = controller.leggiGiocatoriSquadra(controller.leggiSquadra(teamBox2.SelectedIndex).getId());
            foreach (PlayerAssignment temp2 in list)
            {
                teamView2.Items.Add(Leggere_GiocatoreSquadre(temp2));
            }

            if (teamView2.Items.Count > 10)
            {
                List<Tactics> tactics = controller.leggiTattica(controller.leggiSquadra(teamBox2.SelectedIndex).getId());
                if (tactics.Count > 0)
                {
                    List<TacticsFormation> tacticsFormation = controller.leggiFormazione(tactics[0].getTacticsId());
                    if (tacticsFormation.Count > 0)
                        LeggereFormazioni(tacticsFormation, teamView2);
                }
            }
            sfondoTeamView();
        }

        //selezionare giocatore da teamView2
        private void teamView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamView2.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                UInt32 id = uint.Parse(teamView2.Items[intselectedindex].SubItems[11].Text);
                Player temp2 = controller.leggiGiocatoreById(id);
                leggereGiocatore(temp2);
                giocatoreNumber.Text = teamView2.Items[intselectedindex].SubItems[3].Text;
                //
                team = 2;
            }
        }

        //non far inserire lettere
        private void giocatoreNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) & (!char.IsNumber(e.KeyChar.ToString(), 0)))
                e.Handled = true;
        }

        //readme.txt
        private void readme_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "/readme.txt");
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkForUpdate_Click(object sender, EventArgs e)
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
            catch
            {
                MessageBox.Show("Control the internet access" + chACapo + chACapo + "Access impossible to internet", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cambiare nome giocatore
        private void giocatoreName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                controller.changePlayerName(ushort.Parse(giocatoreID.Text), giocatoreName.Text);
        }

        //cambiare nome tshirt
        private void giocatoreShirt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                controller.changeShirtPlayer(ushort.Parse(giocatoreID.Text), giocatoreShirt.Text);
        }

        //cambiare numero al giocatore
        int team = 1;
        private void giocatoreNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                controller.changePlayerNumber(uint.Parse(giocatoreID.Text), team, giocatoreNumber.Text);
        }

        private void teamView1_MouseDown(object sender, MouseEventArgs e)
        {
            //abilitare il tasto destro
            if (e.Button == MouseButtons.Right)
            {
                if (teamView1.SelectedIndices.Count <= 0)
                    return;
                if (teamView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    Team_AMenuStrip2.Show(Cursor.Position);
            }

            //Doppio clicco
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks >= 2)
                {
                    if (teamView1.SelectedIndices.Count <= 0)
                        return;
                    int intselectedindex = teamView1.SelectedIndices[0];
                    if (intselectedindex >= 0)
                    {
                        Giocatore P = new Giocatore(controller.leggiGiocatoreById(uint.Parse(giocatoreID.Text)), controller);
                        P.ShowDialog();
                    }
                }
            }

        }

        private void teamView2_MouseDown(object sender, MouseEventArgs e)
        {
            //abilitare il tasto destro
            if (e.Button == MouseButtons.Right)
            {
                if (teamView2.SelectedIndices.Count <= 0)
                    return;
                if (teamView2.FocusedItem.Bounds.Contains(e.Location) == true)
                    Team_BMenuStrip3.Show(Cursor.Position);
            }

            //Doppio clicco
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks >= 2)
                {
                    if (teamView2.SelectedIndices.Count <= 0)
                        return;
                    int intselectedindex = teamView2.SelectedIndices[0];
                    if (intselectedindex >= 0)
                    {
                        Giocatore P = new Giocatore(controller.leggiGiocatoreById(uint.Parse(giocatoreID.Text)), controller);
                        P.ShowDialog();
                    }
                }
            }

        }

        private void playersBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Doppio clicco
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks >= 2)
                {
                    if (playersBox.SelectedIndices.Count <= 0)
                        return;
                    Giocatore P = new Giocatore(controller.leggiGiocatoreById(uint.Parse(giocatoreID.Text)), controller);
                    P.ShowDialog();
                }
            }
        }

        private void teamsBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Doppio clicco
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks >= 2)
                {
                    List<Tactics> tactics = controller.leggiTattica(controller.leggiSquadra(teamsBox.SelectedIndex).getId());
                    if (tactics.Count > 0)
                    {
                        List<TacticsFormation> tacticsFormation = controller.leggiFormazione(tactics[0].getTacticsId());
                        if (tacticsFormation.Count < 11)
                            MessageBox.Show("Team hasn't 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            Formazione F = new Formazione(controller, controller.leggiSquadra(teamsBox.SelectedIndex));
                            F.ShowDialog();
                        }
                    }
                    else
                        MessageBox.Show("Formation not found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //tasto destro TeamView1
        private void editTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Tactics> tactics = controller.leggiTattica(controller.leggiSquadra(teamBox1.SelectedIndex).getId());
            if (tactics.Count > 0)
            {
                List<TacticsFormation> tacticsFormation = controller.leggiFormazione(tactics[0].getTacticsId());
                if (tacticsFormation.Count < 11)
                    MessageBox.Show("Team hasn't 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Formazione F = new Formazione(controller, controller.leggiSquadra(teamBox1.SelectedIndex));
                    F.ShowDialog();
                }
            }
            else
                MessageBox.Show("Formation not found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void editPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (teamView1.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Giocatore P = new Giocatore(controller.leggiGiocatoreById(uint.Parse(giocatoreID.Text)), controller);
                P.ShowDialog();
            }
        }

        //tasto destro TeamView2
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<Tactics> tactics = controller.leggiTattica(controller.leggiSquadra(teamBox2.SelectedIndex).getId());
            if (tactics.Count > 0)
            {
                List<TacticsFormation> tacticsFormation = controller.leggiFormazione(tactics[0].getTacticsId());
                if (tacticsFormation.Count < 11)
                    MessageBox.Show("Team hasn't 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Formazione F = new Formazione(controller, controller.leggiSquadra(teamBox2.SelectedIndex));
                    F.ShowDialog();
                }
            }
            else
                MessageBox.Show("Formation not found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (teamView2.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Giocatore P = new Giocatore(controller.leggiGiocatoreById(uint.Parse(giocatoreID.Text)), controller);
                P.ShowDialog();
            }
        }

        //tasto destro listBox
        private void editPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playersBox.SelectedIndices.Count <= 0)
                return;
            Giocatore P = new Giocatore(controller.leggiGiocatoreById(uint.Parse(giocatoreID.Text)), controller);
            P.ShowDialog();
        }

        //database
        private void databaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseBox.Text == "Stadium")
                controllerDb.loadStadium(databaseView);
        }

        private void databaseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseView.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = databaseView.SelectedIndices[0];
            if (intselectedindex >= 0)
                controllerDb.readStadium(db14, db15, db16, dbStadiumHome, dbStadiumRealName, dbIdStadium, dbStadiumName, dbStadiumJapanese, dbStadiumCapacity, dbStadiumKonami, dbStadiumLicensed, databaseView, intselectedindex);
        }

        //copy from database
        private void copyFromDb_Click(object sender, EventArgs e)
        {
            if (databaseBox.Text == "Stadium")
                controllerDb.setStadiumDatabase(dbStadiumName.Text);
        }

        //paste from database
        private void button2_Click(object sender, EventArgs e)
        {
            Stadium stadio = controllerDb.getStadiumDatabase();
            if (stadio == null)
                MessageBox.Show("Please select stadium from database tab", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
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

        //upper, lower teams
        private void globalFunctionTeam_Click(object sender, EventArgs e)
        {
            if (upperTeam.Checked == true)
                controller.upperTeams();
            else if (lowerTeam.Checked == true)
                controller.lowerTeams();
            else if (firstUpTeam.Checked == true)
                controller.firstUpTeams();
            MessageBox.Show("New teams names applied", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //upper, lower players
        private void globalFunctionPlayer_Click(object sender, EventArgs e)
        {
            if (upperPlayer.Checked == true)
                controller.upperPlayers();
            else if (lowerPlayer.Checked == true)
                controller.lowerPlayers();
            else if (firstUpPlayer.Checked == true)
                controller.firstUpPlayers();
            MessageBox.Show("New players names applied", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Competition
        private void competitionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (competitionsBox.SelectedIndices.Count <= 0)
                return;

            int intselectedindex = competitionsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Competition comp = controller.leggiCompetizione(intselectedindex);
                if ((comp.getCheck54() == 1))
                {
                    CheckBox54.Checked = true;
                }
                else
                {
                    CheckBox54.Checked = false;
                }

                if ((comp.getCheck55() == 1))
                {
                    CheckBox55.Checked = true;
                }
                else
                {
                    CheckBox55.Checked = false;
                }

                if ((comp.getCheck56() == 1))
                {
                    CheckBox56.Checked = true;
                }
                else
                {
                    CheckBox56.Checked = false;
                }

                if ((comp.getCheck57() == 1))
                {
                    CheckBox57.Checked = true;
                }
                else
                {
                    CheckBox57.Checked = false;
                }

                if ((comp.getCheck58() == 1))
                {
                    CheckBox58.Checked = true;
                }
                else
                {
                    CheckBox58.Checked = false;
                }

                if ((comp.getCheck59() == 1))
                {
                    CheckBox59.Checked = true;
                }
                else
                {
                    CheckBox59.Checked = false;
                }

                if ((comp.getCheck60() == 1))
                {
                    CheckBox60.Checked = true;
                }
                else
                {
                    CheckBox60.Checked = false;
                }

                if ((comp.getLicensed() == 1))
                {
                    CheckBox61.Checked = true;
                }
                else
                {
                    CheckBox61.Checked = false;
                }

                if ((comp.getSecondDivision() == 1))
                {
                    CheckBox62.Checked = true;
                }
                else
                {
                    CheckBox62.Checked = false;
                }

                UNK1_box.Value = comp.getType();
                switch (comp.getType())
                {
                    case 0:
                        label104.Text = "Club Team";
                        break;
                    case 1:
                        label104.Text = "National Team";
                        break;
                    case 2:
                        label104.Text = "Fake Team";
                        break;
                    default:
                        label104.Text = "Unknown";
                        break;
                }

                UNK2_box.Value = comp.getId();
                UNK3_box.Value = comp.getUnk3();
                UNK_4_BOX.Value = comp.getZone();
            }
        }

        private void applyCompetition_Click(object sender, EventArgs e)
        {
            int intselectedindex = competitionsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Competition competition = new Competition((uint) (UNK2_box.Value));
                if (CheckBox54.Checked)
                    competition.setCheck54(1);
                else
                    competition.setCheck54(0);
                if (CheckBox55.Checked)
                    competition.setCheck55(1);
                else
                    competition.setCheck55(0);
                if (CheckBox56.Checked)
                    competition.setCheck56(1);
                else
                    competition.setCheck56(0);
                if (CheckBox57.Checked)
                    competition.setCheck57(1);
                else
                    competition.setCheck57(0);
                if (CheckBox58.Checked)
                    competition.setCheck58(1);
                else
                    competition.setCheck58(0);
                if (CheckBox59.Checked)
                    competition.setCheck59(1);
                else
                    competition.setCheck59(0);
                if (CheckBox60.Checked)
                    competition.setCheck60(1);
                else
                    competition.setCheck60(0);
                if (CheckBox61.Checked)
                    competition.setLicensed(1);
                else
                    competition.setLicensed(0);
                if (CheckBox62.Checked)
                    competition.setSecondDivision(1);
                else
                    competition.setSecondDivision(0);
                competition.setType((uint)(UNK1_box.Value));
                competition.setUnk3((uint)(UNK3_box.Value));
                competition.setZone((uint)(UNK_4_BOX.Value));

                controller.applyCompetitionPersister(intselectedindex, competition);
            }
        }

        //CompetitionKind
        private void competitionsKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (competitionsKind.SelectedIndices.Count <= 0)
                return;

            int intselectedindex = competitionsKind.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                CompetitionKind comp = controller.leggiCompetizioneKind(intselectedindex);
                NumericUpDown19.Value = comp.getOrder();
                UNK1_KIND_BOX.Value = comp.getUnk1();
                UNK2_KIND_BOX.Value = comp.getUnk2();
                UNK3_KIND_BOX.Value = comp.getUnk3();
            }
        }

        private void applyCompetitionKind_Click(object sender, EventArgs e)
        {
            int intselectedindex = competitionsKind.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                CompetitionKind competition = new CompetitionKind();
                competition.setOrder((byte)NumericUpDown19.Value);
                competition.setUnk1((byte)UNK1_KIND_BOX.Value);
                competition.setUnk2((byte)UNK2_KIND_BOX.Value);
                competition.setUnk3((byte)UNK3_KIND_BOX.Value);

                controller.applyCompetitionKindPersister(intselectedindex, competition);
            }
        }

        //competitionRegulation
        private void ListBox_comp_reg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox_comp_reg.SelectedIndices.Count <= 0)
                return;

            int intselectedindex = ListBox_comp_reg.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                CompetitionRegulation comp = controller.leggiCompetizioneRegulation(intselectedindex);
                UNK1_COMP_REG_BOX.Value = comp.getUNK1();
                UNK2_COMP_REG_BOX.Value = comp.getUNK2();
                UNK3_COMP_REG_BOX.Value = comp.getUNK3();
                UNK4_COMP_REG_BOX.Value = comp.getUNK4();
                UNK5_COMP_REG_BOX.Value = comp.getUNK5();
                UNK6_COMP_REG_BOX.Value = comp.getUNK6();
                UNK7_COMP_REG_BOX.Value = comp.getUNK7();
                UNK8_COMP_REG_BOX.Value = comp.getUNK8();
                UNK9_COMP_REG_BOX.Value = comp.getUNK9();
                UNK10_COMP_REG_BOX.Value = comp.getUNK10();
                UNK11_COMP_REG_BOX.Value = comp.getUNK11();

                if ((comp.getCHECK63() == 1))
                {
                    CheckBox63.Checked = true;
                }
                else
                {
                    CheckBox63.Checked = false;
                }

                if ((comp.getCHECK64() == 1))
                {
                    CheckBox64.Checked = true;
                }
                else
                {
                    CheckBox64.Checked = false;
                }

                if ((comp.getCHECK65() == 1))
                {
                    CheckBox65.Checked = true;
                }
                else
                {
                    CheckBox65.Checked = false;
                }
                UNK12_COMP_REG_BOX.Value = comp.getUNK12();
                UNK13_COMP_REG_BOX.Value = comp.getUNK13();
                UNK14_COMP_REG_BOX.Value = comp.getUNK14();
                UNK15_COMP_REG_BOX.Value = comp.getUNK15();
                if ((comp.getCHECK66() == 1))
                {
                    CheckBox66.Checked = true;
                }
                else
                {
                    CheckBox66.Checked = false;
                }
                if ((comp.getCHECK67() == 1))
                {
                    CheckBox67.Checked = true;
                }
                else
                {
                    CheckBox67.Checked = false;
                }
                if ((comp.getCHECK68() == 1))
                {
                    CheckBox68.Checked = true;
                }
                else
                {
                    CheckBox68.Checked = false;
                }
                if ((comp.getCHECK69() == 1))
                {
                    CheckBox69.Checked = true;
                }
                else
                {
                    CheckBox69.Checked = false;
                }
                if ((comp.getCHECK70() == 1))
                {
                    CheckBox70.Checked = true;
                }
                else
                {
                    CheckBox70.Checked = false;
                }
                if ((comp.getCHECK71() == 1))
                {
                    CheckBox71.Checked = true;
                }
                else
                {
                    CheckBox71.Checked = false;
                }
                if ((comp.getCHECK72() == 1))
                {
                    CheckBox72.Checked = true;
                }
                else
                {
                    CheckBox72.Checked = false;
                }
                if ((comp.getCHECK73() == 1))
                {
                    CheckBox73.Checked = true;
                }
                else
                {
                    CheckBox73.Checked = false;
                }
                if ((comp.getCHECK74() == 1))
                {
                    CheckBox74.Checked = true;
                }
                else
                {
                    CheckBox74.Checked = false;
                }
                if ((comp.getCHECK75() == 1))
                {
                    CheckBox75.Checked = true;
                }
                else
                {
                    CheckBox75.Checked = false;
                }
                if ((comp.getCHECK76() == 1))
                {
                    CheckBox76.Checked = true;
                }
                else
                {
                    CheckBox76.Checked = false;
                }
                if ((comp.getCHECK77() == 1))
                {
                    CheckBox77.Checked = true;
                }
                else
                {
                    CheckBox77.Checked = false;
                }
                if ((comp.getCHECK78() == 1))
                {
                    CheckBox78.Checked = true;
                }
                else
                {
                    CheckBox78.Checked = false;
                }
                if ((comp.getCHECK79() == 1))
                {
                    CheckBox79.Checked = true;
                }
                else
                {
                    CheckBox79.Checked = false;
                }
                if ((comp.getCHECK80() == 1))
                {
                    CheckBox80.Checked = true;
                }
                else
                {
                    CheckBox80.Checked = false;
                }
                if ((comp.getCHECK81() == 1))
                {
                    CheckBox81.Checked = true;
                }
                else
                {
                    CheckBox81.Checked = false;
                }
            }
        }

        private void applyCompetitionRegulation_Click(object sender, EventArgs e)
        {
            int intselectedindex = ListBox_comp_reg.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                CompetitionRegulation competition = new CompetitionRegulation();
                competition.setUNK1((byte)UNK1_COMP_REG_BOX.Value);
                competition.setUNK2((byte)UNK2_COMP_REG_BOX.Value);
                competition.setUNK3((byte)UNK3_COMP_REG_BOX.Value);
                competition.setUNK4((byte)UNK4_COMP_REG_BOX.Value);
                competition.setUNK5((byte)UNK5_COMP_REG_BOX.Value);
                competition.setUNK6((byte)UNK6_COMP_REG_BOX.Value);
                competition.setUNK7((byte)UNK7_COMP_REG_BOX.Value);
                competition.setUNK8((byte)UNK8_COMP_REG_BOX.Value);
                competition.setUNK9((byte)UNK9_COMP_REG_BOX.Value);
                competition.setUNK10((byte)UNK10_COMP_REG_BOX.Value);
                competition.setUNK11((byte)UNK11_COMP_REG_BOX.Value);

                if (CheckBox63.Checked == true)
                {
                    competition.setCHECK63(1);
                }
                else
                {
                    competition.setCHECK63(0);
                }

                if (CheckBox64.Checked == true)
                {
                    competition.setCHECK64(1);
                }
                else
                {
                    competition.setCHECK64(0);
                }

                if (CheckBox65.Checked == true)
                {
                    competition.setCHECK65(1);
                }
                else
                {
                    competition.setCHECK65(0);
                }
                competition.setUNK12((byte)UNK12_COMP_REG_BOX.Value);
                competition.setUNK13((byte)UNK13_COMP_REG_BOX.Value);
                competition.setUNK14((byte)UNK14_COMP_REG_BOX.Value);
                competition.setUNK15((byte)UNK15_COMP_REG_BOX.Value);

                if (CheckBox66.Checked == true)
                {
                    competition.setCHECK66(1);
                }
                else
                {
                    competition.setCHECK66(0);
                }
                if (CheckBox67.Checked == true)
                {
                    competition.setCHECK67(1);
                }
                else
                {
                    competition.setCHECK67(0);
                }
                if (CheckBox68.Checked == true)
                {
                    competition.setCHECK68(1);
                }
                else
                {
                    competition.setCHECK68(0);
                }
                if (CheckBox69.Checked == true)
                {
                    competition.setCHECK69(1);
                }
                else
                {
                    competition.setCHECK69(0);
                }
                if (CheckBox70.Checked == true)
                {
                    competition.setCHECK70(1);
                }
                else
                {
                    competition.setCHECK70(0);
                }
                if (CheckBox71.Checked == true)
                {
                    competition.setCHECK71(1);
                }
                else
                {
                    competition.setCHECK71(0);
                }
                if (CheckBox72.Checked == true)
                {
                    competition.setCHECK72(1);
                }
                else
                {
                    competition.setCHECK72(0);
                }
                if (CheckBox73.Checked == true)
                {
                    competition.setCHECK73(1);
                }
                else
                {
                    competition.setCHECK73(0);
                }
                if (CheckBox74.Checked == true)
                {
                    competition.setCHECK74(1);
                }
                else
                {
                    competition.setCHECK74(0);
                }
                if (CheckBox75.Checked == true)
                {
                    competition.setCHECK75(1);
                }
                else
                {
                    competition.setCHECK75(0);
                }
                if (CheckBox76.Checked == true)
                {
                    competition.setCHECK76(1);
                }
                else
                {
                    competition.setCHECK76(0);
                }
                if (CheckBox77.Checked == true)
                {
                    competition.setCHECK77(1);
                }
                else
                {
                    competition.setCHECK77(0);
                }
                if (CheckBox78.Checked == true)
                {
                    competition.setCHECK78(1);
                }
                else
                {
                    competition.setCHECK78(0);
                }
                if (CheckBox79.Checked == true)
                {
                    competition.setCHECK79(1);
                }
                else
                {
                    competition.setCHECK79(0);
                }
                if (CheckBox80.Checked == true)
                {
                    competition.setCHECK80(1);
                }
                else
                {
                    competition.setCHECK80(0);
                }
                if (CheckBox81.Checked == true)
                {
                    competition.setCHECK81(1);
                }
                else
                {
                    competition.setCHECK81(0);
                }

                controller.applyCompetitionRegulationPersister(intselectedindex, competition);
            }
        }

        //fm stats
        private void loadFootballManager_Click(object sender, EventArgs e)
        {
            if (controllerFm.getFmList().Count == 0)
                controllerFm.readFmPersister();

            //abilito i comandi
            label122.Visible = true;
            nationalityBox.Visible = true;
            label121.Visible = true;
            clubBox.Visible = true;
            playerList.Visible = true;
            fmSearchPlayer.Visible = true;
            fmSearchTeam.Visible = true;
            searchPlayerFm.Visible = true;
            searchTeamFm.Visible = true;
            groupBox13.Visible = true;
            groupBox7.Visible = true;
            groupBox18.Visible = true;
            groupBox19.Visible = true;
            groupBox17.Visible = true;
            technicalGk.Visible = true;
            technical.Visible = true;
            groupBox20.Visible = true;
            applyFm.Visible = true;
            technical.Visible = true;
            label119.Visible = false;

            playerList.DataSource = controllerFm.getFmList();
            clubBox.DataSource = controllerFm.getClub();
            count.Text = playerList.Items.Count.ToString();
            clubBox.SelectedIndex = clubBox.Items.Count - 1;
            nationalityBox.SelectedIndex = nationalityBox.Items.Count - 1;
            playerList.SelectedIndex = 0;
        }

        //filtri
        private void nationalityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            playerList.DataSource = controllerFm.filter(clubBox.Text, nationalityBox.Text);
        }

        private void clubBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            playerList.DataSource = controllerFm.filter(clubBox.Text, nationalityBox.Text);
        }

        //selezionare giocatore
        private void playerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fm temp = (Fm)playerList.Items[playerList.SelectedIndex];
            //mental
            aggression.Text = temp.getAggression().ToString();
            anticipation.Text = temp.getAnticipation().ToString();
            bravery.Text = temp.getBravery().ToString();
            composure.Text = temp.getComposure().ToString();
            concentration.Text = temp.getConcentration().ToString();
            decisions.Text = temp.getDecisions().ToString();
            determination.Text = temp.getDetermination().ToString();
            frair.Text = temp.getFlair().ToString();
            leadership.Text = temp.getLeadership().ToString();
            offtheball.Text = temp.getOffTheBall().ToString();
            positioning.Text = temp.getPositioning().ToString();
            teamwork.Text = temp.getTeamwork().ToString();
            vision.Text = temp.getVision().ToString();
            workrate.Text = temp.getWorkRate().ToString();
            //physical
            acceleration.Text = temp.getAcceleration().ToString();
            agility.Text = temp.getAgility().ToString().ToString();
            balance.Text = temp.getBalance().ToString();
            jumpingReach.Text = temp.getJumping().ToString();
            naturalFitness.Text = temp.getNaturalFitness().ToString();
            pace.Text = temp.getPace().ToString();
            staminaFm.Text = temp.getStamina().ToString();
            strenght.Text = temp.getStrength().ToString();
            //basic info
            var today = DateTime.Today;
            var eta = today.Year - int.Parse(temp.getDateOfBirth().Substring(6));
            if (DateTime.Parse(temp.getDateOfBirth()) > today.AddYears(-eta)) eta--;
            age.Text = eta.ToString();
            //technical
            corners.Text = temp.getCorners().ToString();
            freeKickTaking.Text = temp.getFreeKicks().ToString();
            heading.Text = temp.getHeading().ToString();
            tackling.Text = temp.getTackling().ToString();
            crossing.Text = temp.getCrossing().ToString();
            driblingFm.Text = temp.getDribbling().ToString();
            finishingFm.Text = temp.getFinishing().ToString();
            marking.Text = temp.getMarking().ToString();
            passing.Text = temp.getPassing().ToString();
            penaltyTaking.Text = temp.getPenalties().ToString();
            longThrows.Text = temp.getLongThrows().ToString();
            technique.Text = temp.getTechnique().ToString();
            longShots.Text = temp.getLongShots().ToString();
            firstTouch.Text = temp.getFirstTouch().ToString();
            commandOfArea.Text = temp.getCommandOfArea().ToString();
            communication.Text = temp.getCommunication().ToString();
            eccentricity.Text = temp.getEccentricity().ToString();
            aerialAbility.Text = temp.getAerialAbility().ToString();
            handling.Text = temp.getHandling().ToString();
            tendencyToPunch.Text = temp.getTendancyToPunch().ToString();
            reflexesFm.Text = temp.getReflexes().ToString();
            passing2.Text = temp.getPassing().ToString();
            penaltyTaking2.Text = temp.getPenalties().ToString();
            throwing.Text = temp.getThrowing().ToString();
            kicking.Text = temp.getKicking().ToString();
            oneOnOnes.Text = temp.getOneOnOnes().ToString();
            rushingOut.Text = temp.getRushingOut().ToString();
            firstTouch2.Text = temp.getFirstTouch().ToString();
            //fm stats
            averageGk.Text = controllerFm.mediaGk(int.Parse(commandOfArea.Text), int.Parse(communication.Text), int.Parse(firstTouch2.Text), int.Parse(eccentricity.Text),
                int.Parse(aerialAbility.Text), int.Parse(passing2.Text)
                , int.Parse(handling.Text), int.Parse(tendencyToPunch.Text), int.Parse(reflexes.Text), int.Parse(penaltyTaking2.Text), int.Parse(throwing.Text),
                int.Parse(kicking.Text)
                , int.Parse(oneOnOnes.Text), int.Parse(rushingOut.Text), int.Parse(technique.Text), int.Parse(freeKickTaking.Text), int.Parse(aggression.Text),
                int.Parse(anticipation.Text), int.Parse(bravery.Text),
                int.Parse(composure.Text), int.Parse(concentration.Text), int.Parse(decisions.Text),
                int.Parse(determination.Text), int.Parse(frair.Text), int.Parse(leadership.Text),
                int.Parse(offtheball.Text), int.Parse(positioning.Text), int.Parse(teamwork.Text),
                int.Parse(vision.Text), int.Parse(workrate.Text), int.Parse(acceleration.Text),
                int.Parse(agility.Text), int.Parse(balance.Text), int.Parse(jumpingReach.Text),
                int.Parse(naturalFitness.Text), int.Parse(pace.Text), int.Parse(stamina.Text), int.Parse(strenght.Text)).ToString();
            average.Text = controllerFm.media(int.Parse(corners.Text), int.Parse(freeKickTaking.Text), int.Parse(heading.Text), int.Parse(tackling.Text),
                int.Parse(firstTouch.Text), int.Parse(crossing.Text)
                , int.Parse(dribbling.Text), int.Parse(finishing.Text), int.Parse(marking.Text), int.Parse(passing.Text),
                int.Parse(penaltyTaking.Text)
                , int.Parse(longThrows.Text), int.Parse(longShots.Text), int.Parse(technique.Text), int.Parse(aggression.Text), int.Parse(anticipation.Text),
                int.Parse(bravery.Text),
                int.Parse(composure.Text), int.Parse(concentration.Text), int.Parse(decisions.Text),
                int.Parse(determination.Text), int.Parse(frair.Text), int.Parse(leadership.Text),
                int.Parse(offtheball.Text), int.Parse(positioning.Text), int.Parse(teamwork.Text),
                int.Parse(vision.Text), int.Parse(workrate.Text), int.Parse(acceleration.Text),
                int.Parse(agility.Text), int.Parse(balance.Text), int.Parse(jumpingReach.Text),
                int.Parse(naturalFitness.Text), int.Parse(pace.Text), int.Parse(stamina.Text), int.Parse(strenght.Text)).ToString();
            //position
            gkrat.Text = temp.getGk().ToString();
            swrat.Text = temp.getSw().ToString();
            rbrat.Text = temp.getRb().ToString();
            lbrat.Text = temp.getLb().ToString();
            cbrat.Text = temp.getCb().ToString();
            wbrat.Text = temp.getWbr().ToString();
            wblrat.Text = temp.getWbl().ToString();
            dmrat.Text = temp.getDm().ToString();
            rmrat.Text = temp.getRm().ToString();
            lmrat.Text = temp.getLm().ToString();
            cmrat.Text = temp.getCm().ToString();
            amlrat.Text = temp.getAml().ToString();
            amrat.Text = temp.getAmr().ToString();
            amcrat.Text = temp.getAmc().ToString();
            strat.Text = temp.getSt().ToString();
            controllerFm.positionPlayer(gk, cb, lb, rb, dmf, cmf, lmf, amf, rmf, lwf, rwf, ss, cf, temp, int.Parse(average.Text), int.Parse(averageGk.Text));
        }

        private void commandOfArea_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(commandOfArea);
        }

        private void communication_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(communication);
        }

        private void firstTouch2_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(firstTouch2);
        }

        private void eccentricity_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(eccentricity);
        }

        private void aerialAbility_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(aerialAbility);
        }

        private void passing2_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(passing2);
        }

        private void handling_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(handling);
        }

        private void tendencyToPunch_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(tendencyToPunch);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(reflexesFm);
        }

        private void penaltyTaking2_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(penaltyTaking2);
        }

        private void throwing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(throwing);
        }

        private void kicking_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(kicking);
        }

        private void oneOnOnes_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(oneOnOnes);
        }

        private void rushingOut_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(rushingOut);
        }

        private void corners_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(corners);
        }

        private void freeKickTaking_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(freeKickTaking);
        }

        private void heading_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(heading);
        }

        private void tackling_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(tackling);
        }

        private void firstTouch_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(firstTouch);
        }

        private void crossing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(crossing);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(driblingFm);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(finishingFm);
        }

        private void marking_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(marking);
        }

        private void passing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(passing);
        }

        private void penaltyTaking_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(penaltyTaking);
        }

        private void longThrows_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(longThrows);
        }

        private void technique_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(technique);
        }

        private void longShots_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(longShots);
        }

        private void acceleration_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(acceleration);
        }

        private void agility_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(agility);
        }

        private void balance_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(balance);
        }

        private void jumpingReach_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(jumpingReach);
        }

        private void naturalFitness_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(naturalFitness);
        }

        private void pace_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(pace);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(staminaFm);
        }

        private void strenght_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(strenght);
        }

        private void workrate_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(workrate);
        }

        private void vision_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(vision);
        }

        private void teamwork_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(teamwork);
        }

        private void positioning_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(positioning);
        }

        private void offtheball_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(offtheball);
        }

        private void leadership_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(leadership);
        }

        private void frair_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(frair);
        }

        private void determination_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(determination);
        }

        private void decisions_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(decisions);
        }

        private void concentration_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(concentration);
        }

        private void composure_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(composure);
        }

        private void bravery_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(bravery);
        }

        private void anticipation_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(anticipation);
        }

        private void aggression_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorLabelFm(aggression);
        }

        //cercare un giocatore (INVIO)
        private void fmSearchPlayer_Click(object sender, EventArgs e)
        {
            fmSearchPlayer.SelectAll();
            fmSearchPlayer.Focus();
        }

        private void fmSearchPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(playerList, fmSearchPlayer);
            }
        }

        private void searchPlayerFm_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(playerList, fmSearchPlayer);
        }

        //cercare una squadra Invio
        private void fmSearchTeam_TextChanged(object sender, EventArgs e)
        {
            fmSearchTeam.SelectAll();
            fmSearchTeam.Focus();
        }

        private void fmSearchTeam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.comboBoxSearch(clubBox, fmSearchTeam);
            }
        }

        private void searchTeamFm_Click(object sender, EventArgs e)
        {
            UtilGUI.comboBoxSearch(clubBox, fmSearchTeam);
        }

        private void applyFm_Click(object sender, EventArgs e)
        {
            Fm temp2 = (Fm)playerList.Items[playerList.SelectedIndex];
            Player temp = controllerFm.getPlayer();
            //player name
            if (playerList.Text.Length <= 44)
                temp.setName(playerList.Text);
            else
                temp.setName(playerList.Text.Substring(0, 44));
            //shirt name
            string decode = Unidecoder.Unidecode(temp2.getSurname());
            if (temp2.getSurname().Length <= 44)
                temp.setShirtName(decode.ToUpper());
            else
                temp.setShirtName(decode.ToUpper().Substring(0, 44));
            //playing style
            temp.setPlayingStyle(0);

            int ind = controller.findCountryFm(temp2.getNation());
            temp.setNational((ushort)controller.leggiPaese(ind).getId());
            temp.setNational2(0);

            //position
            controllerFm.calculatePosition(temp2);
            controllerFm.registredPosition(gk, cb, lb, rb, dmf, cmf, lmf, amf, rmf, lwf, rwf, ss, cf);
            //basic info
            temp.setAge(uint.Parse(age.Text));
            temp.setStrongerFoot(controllerFm.calculateStrongFoot(temp2));
            temp.setInjuryRes(controllerFm.calculateInjuryRes(int.Parse(naturalFitness.Text)));
            temp.setForm(controllerFm.calculateForm(int.Parse(staminaFm.Text), int.Parse(naturalFitness.Text), int.Parse(balance.Text), controllerFm.getPlayer().getPosition()));
            temp.setWcUsage(controllerFm.calculateWcUsage(int.Parse(technique.Text), controllerFm.getPlayer().getPosition()));
            temp.setWeakFootAcc(controllerFm.calculateWcAcc(int.Parse(technique.Text), int.Parse(offtheball.Text), controllerFm.getPlayer().getPosition()));
            //ability
            temp.setStamina(controllerFm.calculateStamina(int.Parse(staminaFm.Text), int.Parse(average.Text), int.Parse(averageGk.Text), int.Parse(naturalFitness.Text), int.Parse(strenght.Text), int.Parse(workrate.Text), controllerFm.getPlayer().getPosition()));
            temp.setCoverage(controllerFm.calculateCoverage(int.Parse(commandOfArea.Text), int.Parse(communication.Text), int.Parse(positioning.Text), int.Parse(leadership.Text), int.Parse(gkrat.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setReflexes(controllerFm.calculateRflexes(int.Parse(reflexesFm.Text), int.Parse(gkrat.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setClearing(controllerFm.calculateClearing(int.Parse(tendencyToPunch.Text), int.Parse(gkrat.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setCathing(controllerFm.calculateCatching(int.Parse(handling.Text), int.Parse(gkrat.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setGoalkeeping(controllerFm.calculateGoalkeeping(int.Parse(commandOfArea.Text), int.Parse(communication.Text), int.Parse(aerialAbility.Text), int.Parse(handling.Text),
                int.Parse(throwing.Text), int.Parse(kicking.Text), int.Parse(oneOnOnes.Text), int.Parse(tendencyToPunch.Text), int.Parse(concentration.Text),
                int.Parse(leadership.Text), int.Parse(positioning.Text), int.Parse(gkrat.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setJump(controllerFm.calculateJump(int.Parse(jumpingReach.Text), int.Parse(agility.Text), int.Parse(strenght.Text), int.Parse(average.Text), controllerFm.getPlayer().getPosition()));
            temp.setPhysical(controllerFm.calculatePhysicalContact(int.Parse(positioning.Text), int.Parse(tackling.Text), int.Parse(eccentricity.Text), int.Parse(workrate.Text), int.Parse(naturalFitness.Text),
                int.Parse(staminaFm.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));

            temp.setBodyControl(controllerFm.calculateBodyControll(int.Parse(naturalFitness.Text), int.Parse(balance.Text), int.Parse(strenght.Text), int.Parse(average.Text), controllerFm.getPlayer().getPosition()));
            temp.setExplosiveP(controllerFm.calculateExplosivePower(int.Parse(naturalFitness.Text), int.Parse(agility.Text), int.Parse(acceleration.Text), int.Parse(strenght.Text), int.Parse(staminaFm.Text), int.Parse(determination.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setSpeed(controllerFm.calculateSpeed(int.Parse(pace.Text), int.Parse(acceleration.Text), int.Parse(naturalFitness.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setKickingPower(controllerFm.calculateKickingPower(int.Parse(passing.Text), int.Parse(eccentricity.Text), int.Parse(strenght.Text), int.Parse(freeKickTaking.Text), int.Parse(penaltyTaking.Text), int.Parse(longShots.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setBallWinning(controllerFm.calculateBallWinning(int.Parse(aggression.Text), int.Parse(eccentricity.Text), int.Parse(positioning.Text), int.Parse(marking.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setDefense(controllerFm.calculateDefensiveProwess(int.Parse(positioning.Text), int.Parse(aggression.Text), int.Parse(eccentricity.Text), int.Parse(concentration.Text), int.Parse(teamwork.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setHeader(controllerFm.calculateHeader(int.Parse(eccentricity.Text), int.Parse(rushingOut.Text), int.Parse(aerialAbility.Text), int.Parse(jumpingReach.Text), int.Parse(heading.Text), int.Parse(anticipation.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setSwerve(controllerFm.calculateSwerve(int.Parse(passing.Text), int.Parse(freeKickTaking.Text), int.Parse(technique.Text), int.Parse(corners.Text), int.Parse(firstTouch.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setPlaceKick(controllerFm.calculatePlaceKicking(int.Parse(composure.Text), int.Parse(determination.Text), int.Parse(technique.Text), int.Parse(freeKickTaking.Text), int.Parse(strenght.Text), int.Parse(leadership.Text), int.Parse(average.Text), controllerFm.getPlayer().getPosition()));
            temp.setFinishing(controllerFm.calculateFinishing(int.Parse(penaltyTaking.Text), int.Parse(freeKickTaking.Text), int.Parse(vision.Text), int.Parse(finishingFm.Text), int.Parse(longShots.Text), int.Parse(composure.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setLoftedPass(controllerFm.calculateLoftedPass(int.Parse(passing.Text), int.Parse(kicking.Text), int.Parse(eccentricity.Text), int.Parse(corners.Text), int.Parse(longThrows.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setLowPass(controllerFm.calculateLowPass(int.Parse(eccentricity.Text), int.Parse(firstTouch.Text), int.Parse(passing.Text), int.Parse(decisions.Text), int.Parse(vision.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setDribbling(controllerFm.calculateDribbling(int.Parse(frair.Text), int.Parse(eccentricity.Text), int.Parse(driblingFm.Text), int.Parse(firstTouch.Text), int.Parse(technique.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setBallControll(controllerFm.calculateBallControll(int.Parse(firstTouch.Text), int.Parse(eccentricity.Text), int.Parse(technique.Text), int.Parse(vision.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));
            temp.setAttack(controllerFm.calculateAttackingProwness(int.Parse(offtheball.Text), int.Parse(teamwork.Text), int.Parse(finishingFm.Text), int.Parse(firstTouch.Text), int.Parse(average.Text), int.Parse(averageGk.Text), controllerFm.getPlayer().getPosition()));

            temp.setEarlyCross(0);
            temp.setPinCrossing(0);
            temp.setSombrero(0);
            temp.setSpeedingBullet(0);
            temp.setSchotMove(0);
            temp.setGkLong(0);
            temp.setLongThrow(0);
            temp.setScissorFeint(0);
            temp.setTrackBack(0);
            temp.setSuperSub(0);
            temp.setRabona(0);
            temp.setAcrobatingFinishing(0);
            temp.setKnucleShot(0);
            temp.setFirstTimeShot(0);
            temp.setComIncisiveRun(0);
            /*unk3*/
            temp.setLongRange(0);
            temp.setOneTouchPass(0);
            temp.setHellTick(0);
            /*unk4*/
            temp.setManMarking(0);
            /*unk5*/
            temp.setMarseilleTurn(0);
            temp.setHeading(0);
            temp.setOutsideCurler(0);
            temp.setCaptaincy(0);
            temp.setMalicia(0);
            temp.setLowPuntTrajectory(0);
            temp.setComTrickster(0);
            temp.setLowLoftedPass(0);
            temp.setFightingSpirit(0);
            temp.setFlipFlap(0);
            temp.setWeightnessPass(0);
            /*unk6*/
            /*unk7*/
            /*unk8*/
            temp.setComMazingRun(0);
            temp.setAcrobatingClear(0);
            temp.setComBallExpert(0);
            temp.setCutBehind(0);
            temp.setComLongRanger(0);

            temp.setYouthPlayerId(0);
            temp.setLegendGoldenBall(0);
            temp.setHiddenPlayer(0);

            controller.applyPlayerPersister(controller.findPlayer(temp.getId()), temp);
            controller.UpdateTeamView(temp.getId(), temp.getName());
            controller.UpdateFormPlayer(controller.findPlayer(temp.getId()), temp.getName());
        }

        //CompetitionEntry
        private void competitionEntryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (competitionEntryBox.SelectedIndices.Count <= 0)
                return;

            int intselectedindex = competitionEntryBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                controller.findCompetition(intselectedindex);
            }
        }

        //remove fake team
        private void removeFakeTeam_Click(object sender, EventArgs e)
        {
            controller.removeFakeTeam();

            MessageBox.Show("Fake teams corrected!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void removeFakeClassicPlayer_Click(object sender, EventArgs e)
        {
            controller.removeFakePlayer();

            MessageBox.Show("Classic players fake names corrected!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //export Player
        private void csvToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportPlayer(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export PlayerAppareance
        private void csvToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportPlayerAppareance(controller));
                sw.Close();
                MessageBox.Show("Exported values are in hexadecimal", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export team
        private void csvToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportTeam(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export PlayerAssignment
        private void csvToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportPlayerAssignment(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export Coaches
        private void csvToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportCoach(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export Stadium
        private void csvToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportStadium(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export Ball
        private void csvToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportBall(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export BallCondition
        private void csvToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportBallCondition(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export Boots
        private void csvToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportBoot(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //export Gloves
        private void csvToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ControllerCSV csv = new ControllerCSV();
            StreamWriter sw = null;

            //Setup OpenFileDialog
            SaveFileDialog ofd = new SaveFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Save File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 EXPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(ofd.FileName, false);
                sw.Write(csv.exportGlove(controller));
                sw.Close();
                MessageBox.Show("CSV exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

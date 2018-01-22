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

        private const string TEAM_A = "Team A";
        private const string TEAM_B = "Team B";
        private const string PLAYER = "Player";

        private Controller controller;
        //private ControllerFm controllerFm;
        private const char chACapo = (char)13;

        private void Form1_Load(object sender, EventArgs e)
        {
            //controllerFm = new ControllerFm();
            controller = new Controller();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            //ToolTip
            toolTip1.ToolTipTitle = "DinoTem Editor";
            toolTip1.SetToolTip(giocatoreView, "Click to select a player" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(searchPlayer, "Write a player name and click ENTER" + Environment.NewLine + Environment.NewLine + "If you don't see the player, click again Enter" + Environment.NewLine + "" + "Note: You can also write a few letters of a player");
            toolTip1.SetToolTip(teamView1, "Click to select a player" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamView2, "Click to select a player" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamBox1, "Click to select a team" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamBox2, "Click to select a team" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(giocatoreName, "Change Player Name" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(giocatoreShirt, "Change Shirt Name" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(giocatoreNumber, "Change Player Number" + Environment.NewLine + Environment.NewLine + "Press Enter to save");

            toolTip1.SetToolTip(searchTeam, "Write a team name and click ENTER" + Environment.NewLine + Environment.NewLine + "If you don't see the team, click again Enter" + Environment.NewLine + "" + "Note: You can also write a few letters of a team");
            toolTip1.SetToolTip(teamsBox, "Click to select a team" + Environment.NewLine + "Also use double click or right click for more option");
            toolTip1.SetToolTip(teamName, "Change Team Name" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamShort, "Change Short Name" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamID, "Change ID Team" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamFake, "Change if the Team is a Fake");
            toolTip1.SetToolTip(teamNotPlayableLeague, "Change League of Team");
            toolTip1.SetToolTip(teamFake, "Change if the Team is a Fake");
            toolTip1.SetToolTip(teamLicense, "Change Team's License");
            toolTip1.SetToolTip(teamCoachLicense, "Change Coach's License");
            toolTip1.SetToolTip(teamJapanese, "Change Team Name (only Japanese language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamFrench, "Change Team Name (only French language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamDutch, "Change Team Name (only Dutch language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamSpanish, "Change Team Name (only Spanish language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamTurkish, "Change Team Name (only Turkish language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamSwedish, "Change Team Name (only Swedish language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamGreek, "Change Team Name (only Greek language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamPortuguese, "Change Team Name (only Portuguese language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamItalian, "Change Team Name (only Italian language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamEnglish, "Change Team Name (only English language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamGerman, "Change Team Name (only German language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamRussian, "Change Team Name (only Russian language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamSpanish2, "Change Team Name (only Spanish (Latin American) language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamPortuguese2, "Change Team Name (only Portuguese (Latin American) language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(teamEnglish2, "Change Team Name (only English (UK) language)" + Environment.NewLine + Environment.NewLine + "Press Enter to save");

            toolTip1.SetToolTip(searchBall, "Write a ball name and click ENTER" + Environment.NewLine + Environment.NewLine + "If you don't see the ball, click again Enter" + Environment.NewLine + "" + "Note: You can also write a few letters of a ball");
            toolTip1.SetToolTip(palloneID, "Change ID Ball" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(palloneName, "Change Ball Name" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(palloneOrder, "Change Order of the ball" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(palloneUnknowB1, "Change Unknow value" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(palloneUnknowB2, "Change Unknow value" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(palloneUnknowB3, "Change Unknow value" + Environment.NewLine + Environment.NewLine + "Press Enter to save");
            toolTip1.SetToolTip(palloneUnknowB4, "Change Unknow value" + Environment.NewLine + Environment.NewLine + "Press Enter to save");

            //Caricamento Database
            databaseBox.Items.Add("Stadium");
            //Team Tab
            teamType.Items.Add("National");
            teamType.Items.Add("Club");
            teamNotPlayableLeague.Items.Add("No League");
            teamNotPlayableLeague.Items.Add("Classic League");
            teamNotPlayableLeague.Items.Add("Other Europe League");
            teamNotPlayableLeague.Items.Add("Other Asian League");
            teamNotPlayableLeague.Items.Add("Hidden Fake European League");
            teamNotPlayableLeague.Items.Add("ML Hidden League");
            teamNotPlayableLeague.Items.Add("Other America League");
            teamNotPlayableLeague.Items.Add("Other Africa League");
            teamLicense.Items.Add("Licensed");
            teamLicense.Items.Add("Unlicensed");
            teamCoachLicense.Items.Add("Licensed");
            teamCoachLicense.Items.Add("Unlicensed");
            teamFake.Items.Add("Yes");
            teamFake.Items.Add("No");
            teamLicense.Items.Add("Licensed");
            teamLicense.Items.Add("Unlicensed");
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
            catch {}

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
            catch {}

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
            catch {}

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
            catch {}
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
                SplashScreen._SplashScreen.Close();
            }
        }

        //readme.txt
        private void readme_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "/readme.txt");
        }

        //close
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //update
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
            catch {
                MessageBox.Show("Control the internet access" + chACapo + chACapo + "Access impossible to internet", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //reload
        private void reload_Click(object sender, EventArgs e)
        {
            controller.openDatabase(fbd.SelectedPath, teamBox1, teamBox2, teamsBox, stadiumsBox, ballsBox, teamCountry, stadiumCountry, teamStadium, giocatoreView, Form1._Form1);
        }

        //ricerca giocatori (invio)
        private void giocatoreSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.giocatoreSearch(giocatoreView, searchPlayer);
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            UtilGUI.giocatoreSearch(giocatoreView, searchPlayer);
        }

        private void giocatoreSearch_Click(object sender, EventArgs e)
        {
            searchPlayer.SelectAll();
            searchPlayer.Focus();
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

        //ricerca squadre (invio)
        private void SearchSquadre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void SearchSquadre_Click(object sender, EventArgs e)
        {
            searchTeam.SelectAll();
            searchTeam.Focus();
        }

        //ricerca palloni
        private void textBox3_Click(object sender, EventArgs e)
        {
            searchBall.SelectAll();
            searchBall.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UtilGUI.listBoxSearch(ballsBox, searchBall);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UtilGUI.listBoxSearch(ballsBox, searchBall);
        }

        //ricerca stadi
        private void searchStadium_Click(object sender, EventArgs e)
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

        //non far inserire lettere
        private void giocatoreNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) & (!char.IsNumber(e.KeyChar.ToString(), 0)))
                e.Handled = true;
        }

        private ListViewItem Leggere_GiocatoreSquadre(PlayerAssignment pAssignment)
        {
            ListViewItem item = new ListViewItem();
            Player temp2 = (Player)controller.getPlayerById(pAssignment.getPlayerId());

            item = new ListViewItem((pAssignment.getOrder() + 1).ToString());
            item.SubItems.Add(temp2.getStringPosition());
            item.SubItems.Add(temp2.getPlayerName());
            item.SubItems.Add(pAssignment.getShirtNumber().ToString());

            return item;
        }

        private void Leggere_Formazioni(List<TacticsFormation> position, ListView list)
        {
            int k = 0;
            foreach (TacticsFormation temp in position) {
                if (k <= 10) {
                    list.Items[k].SubItems[1].Text = temp.getStringPosition();
                }
                k++;
            }
        }

        //selezionare Team A
        private void teamBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamView1.Items.Clear();

            //caricare giocatori nella squadra
            Team temp = (Team)teamBox1.SelectedItem;

            List<PlayerAssignment> SortedList = controller.getPlayersTeam(temp.getId());
            SortedList.Sort((x, y) => x.getOrder().CompareTo(y.getOrder()));
            controller.orderPlayerInTeam2(SortedList); //vedere se l'ordine è 1,2,3..
            foreach (PlayerAssignment temp2 in SortedList)
            {
                teamView1.Items.Add(Leggere_GiocatoreSquadre(temp2)); //Add this row to the ListView
            }

            //caricare posizioni giocatori
            if (teamView1.Items.Count > 10)
            {
                if (controller.getNumberFormation(temp.getId()).Count > 0)
                {
                    List<TacticsFormation> position = controller.getPositionTeam(controller.getNumberFormation(temp.getId())[0]);
                    Leggere_Formazioni(position, teamView1);
                }
            }

            sfondoTeamView();
        }

        //selezionare Team B
        private void teamBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamView2.Items.Clear();

            //caricare giocatori nella squadra
            Team temp = (Team)teamBox2.SelectedItem;

            List<PlayerAssignment> SortedList = controller.getPlayersTeam(temp.getId());
            SortedList.Sort((x, y) => x.getOrder().CompareTo(y.getOrder()));
            controller.orderPlayerInTeam2(SortedList); //vedere se l'ordine è 1,2,3..
            foreach (PlayerAssignment x in SortedList)
            {
                teamView2.Items.Add(Leggere_GiocatoreSquadre(x)); //Add this row to the ListView
            }

            //caricare posizioni giocatori
            if (teamView2.Items.Count > 10)
            {
                if (controller.getNumberFormation(temp.getId()).Count > 0)
                {
                    List<TacticsFormation> position = controller.getPositionTeam(controller.getNumberFormation(temp.getId())[0]);
                    Leggere_Formazioni(position, teamView2);
                }
            }

            sfondoTeamView();
        }

        private void Leggere_Giocatore(Player temp)
        {
            giocatoreNazionale.Text = "";
            giocatoreNazionalità.Text = "";
            giocatoreSquadra.Text = "";
            giocatoreNumber.Text = "";

            giocatoreName.Text = temp.getPlayerName();
            giocatoreShirt.Text = temp.getShirtName();
            giocatoreID.Text = temp.getId().ToString();
            giocatoreType.Text = temp.getStringFake();
            giocatoreAge.Text = temp.getAge().ToString();
            giocatoreWeight.Text = temp.getWeight().ToString();
            giocatoreHeight.Text = temp.getHeight().ToString();
            giocatoreNazionalità.Text = temp.getNational().ToString();

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
            bodyControll.Text = temp.getBodyControll().ToString();
            physical.Text = temp.getPhysical().ToString();
            jump.Text = temp.getJump().ToString();
            stamina.Text = temp.getStamina().ToString();
            goalkeeping.Text = temp.getGoalkeeping().ToString();
            cathing.Text = temp.getCathing().ToString();
            clearing.Text = temp.getClearing().ToString();
            reflexes.Text = temp.getReflexes().ToString();
            coverage.Text = temp.getCoverage().ToString();
            if (temp.getStrongerFoot())
                giocatoreFoot.Text = "Left";
            else
                giocatoreFoot.Text = "Right";
            giocatoreSquadra.Text = controller.getStringClubTeamOfPlayer(temp.getId(), 0);
            giocatoreNazionale.Text = controller.getStringClubTeamOfPlayer(temp.getId(), 1);
            controller.getCountryMap().GetType();
            Country value;
            if (!controller.getCountryMap().TryGetValue((long)temp.getNational(), out value))
                throw new ArgumentException("id country not found");

            giocatoreNazionalità.Text = value.getNationality();
        }

        //selezionare un giocatore da giocatoreView
        private void giocatoreView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (giocatoreView.SelectedIndices.Count <= 0)
                return;

            int intselectedindex = giocatoreView.SelectedIndices[0];
            if (intselectedindex >= 0)
                Leggere_Giocatore(controller.getPlayerById(intselectedindex)); //leggo giocatore
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

        //Caratteri speciali
        private void characterS1_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Res\charmap.exe");
        }

        //selezionare giocatore da teamView1
        private void teamView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamView1.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamBox1.SelectedItem;
                Leggere_Giocatore(controller.getPlayerById(intselectedindex, temp.getId()));
                //inserisco id in fmstats form
                //controllerFm.setPlayer(controller.getPlayerById(intselectedindex, temp.getId()));
                //numero giocatore
                giocatoreNumber.Text = teamView1.Items[intselectedindex].SubItems[3].Text;
                team = teamBox1.SelectedIndex;
            }
        }

        //selezionare giocatore da teamView2
        private void teamView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamView2.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamBox2.SelectedItem;
                Leggere_Giocatore(controller.getPlayerById(intselectedindex, temp.getId()));
                //inserisco id in fmstats form
                //controllerFm.setPlayer(controller.getPlayerById(intselectedindex, temp.getId()));
                //giocatorePunteggio();

                //numero giocatore
                giocatoreNumber.Text = teamView2.Items[intselectedindex].SubItems[3].Text;
                team = teamBox2.SelectedIndex;
            }
        }

        //cambiare nome shirt
        private void giocatoreShirt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controller.changeShirtPlayer(long.Parse(giocatoreID.Text), giocatoreShirt.Text);
            }
        }

        //cambiare nome giocatore
        private void giocatoreName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controller.changePlayerName(long.Parse(giocatoreID.Text), giocatoreName.Text);
                controller.UpdateForm(teamBox1, teamBox2);
                controller.UpdateFormPlayer(giocatoreView, controller.getPlayerById(long.Parse(giocatoreID.Text)));
            }
        }

        //cambiare numero al giocatore
        int team = 1;
        private void giocatoreNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                controller.changePlayerNumber(long.Parse(giocatoreID.Text), controller.getTeamById(team).getId(), int.Parse(giocatoreNumber.Text));
                controller.UpdateForm(teamBox1, teamBox2);
            }
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
                        Team temp = (Team)teamBox1.SelectedItem;
                        Giocatore P = new Giocatore(controller.getPlayerById(intselectedindex, temp.getId()), controller);
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
                        Team temp = (Team)teamBox2.SelectedItem;
                        Giocatore P = new Giocatore(controller.getPlayerById(intselectedindex, temp.getId()), controller);
                        P.ShowDialog();
                    }
                }
            }
        }

        private void giocatoreView_MouseDown(object sender, MouseEventArgs e)
        {
            //abilitare il tasto destro
            if (e.Button == MouseButtons.Right)
            {
                if (e.Clicks >= 1)
                {
                    if (giocatoreView.SelectedIndices.Count <= 0)
                        return;
                    if (giocatoreView.FocusedItem.Bounds.Contains(e.Location) == true)
                        PlayerMenuStrip1.Show(Cursor.Position);
                }
            }

            //Doppio clicco
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks >= 2)
                {
                    if (giocatoreView.SelectedIndices.Count <= 0)
                        return;
                    int intselectedindex = giocatoreView.SelectedIndices[0];
                    if (intselectedindex >= 0)
                    {
                        Giocatore P = new Giocatore(controller.getPlayerById(intselectedindex), controller);
                        P.ShowDialog();
                    }
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
                    Team temp = (Team)teamsBox.SelectedItem;
                    if (controller.getPlayersTeam(temp.getId()).Count < 11)
                        MessageBox.Show("Team hasn't 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (controller.getNumberFormation(temp.getId()).Count > 0)
                        {
                            Formazione F = new Formazione(controller, temp);
                            F.ShowDialog();
                        }
                        else
                            MessageBox.Show("Formation not found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //tasto destro TeamView1
        private void editTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (teamView1.Items.Count < 11)
                MessageBox.Show("Team hasn't 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Team temp = (Team)teamBox1.SelectedItem;
                if (controller.getNumberFormation(temp.getId()).Count > 0)
                {
                    Formazione F = new Formazione(controller, temp);
                    F.ShowDialog();
                }
                else
                    MessageBox.Show("Formation not found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (teamView1.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamBox1.SelectedItem;
                Giocatore P = new Giocatore(controller.getPlayerById(intselectedindex, temp.getId()), controller);
                P.ShowDialog();
            }
        }

        //tasto destro TeamView2
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (teamView2.Items.Count < 11)
                MessageBox.Show("Team hasn't 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Team temp = (Team)teamBox2.SelectedItem;
                if (controller.getNumberFormation(temp.getId()).Count > 0)
                {
                    Formazione F = new Formazione(controller, temp);
                    F.ShowDialog();
                }
                else
                    MessageBox.Show("Formation not found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (teamView2.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamBox2.SelectedItem;
                Giocatore P = new Giocatore(controller.getPlayerById(intselectedindex, temp.getId()), controller);
                P.ShowDialog();
            }
        }

        //tasto destro giocatoreView
        private void editPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (giocatoreView.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = giocatoreView.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Giocatore P = new Giocatore(controller.getPlayerById(intselectedindex), controller);
                P.ShowDialog();
            }
        }

        //ball
        private void ballBox_SelectedIndexChanged(object sender, EventArgs e)
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
                Ball temp = (Ball)ballsBox.SelectedItem;
                palloneOrder.Text = temp.getOrder().ToString();
                palloneID.Text = temp.getId().ToString();
                palloneName.Text = temp.getName();
                controller.getBallConditionById(temp.getId(), palloneUnknowB1, palloneUnknowB2, palloneUnknowB3, palloneUnknowB4);
            }
        }

        //quando si clicca invio //NOME PALLONE
        private void palloneName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ballsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = ballsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Ball temp = (Ball)ballsBox.SelectedItem;
                    controller.changeBallName(temp, palloneName.Text);
                    //aggiornare listBox
                    ballsBox.Items[intselectedindex] = temp;
                }
            }
        }

        //quando si clicca invio //ORDER
        private void palloneOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ballsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = ballsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Ball temp = (Ball)ballsBox.SelectedItem;
                    controller.changeBallOrder(temp, int.Parse(palloneOrder.Text));
                }
            }
        }

        //quando si clicca invio //UNKNOWN1
        private void palloneUnknowB1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ballsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = ballsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Ball temp = (Ball)ballsBox.SelectedItem;
                    controller.changeBallUnknown(temp, 0, int.Parse(palloneUnknowB1.Text));
                }
            }
        }

        //quando si clicca invio //UNKNOWN2
        private void palloneUnknowB2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ballsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = ballsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Ball temp = (Ball)ballsBox.SelectedItem;
                    controller.changeBallUnknown(temp, 1, int.Parse(palloneUnknowB2.Text));
                }
            }
        }

        //quando si clicca invio //UNKNOWN3
        private void palloneUnknowB3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ballsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = ballsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Ball temp = (Ball)ballsBox.SelectedItem;
                    controller.changeBallUnknown(temp, 2, int.Parse(palloneUnknowB3.Text));
                }
            }
        }

        //quando si clicca invio //UNKNOWN4
        private void palloneUnknowB4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ballsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = ballsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Ball temp = (Ball)ballsBox.SelectedItem;
                    controller.changeBallUnknown(temp, 3, int.Parse(palloneUnknowB4.Text));
                }
            }
        }

        //team
        private void teamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;

            //pulire campi
            squadraPanel5.Enabled = false;
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
                Team temp = (Team)teamsBox.SelectedItem;
                teamName.Text = temp.getEnglish();
                teamJapanese.Text = temp.getJapanese();
                teamID.Text = temp.getId().ToString();
                teamShort.Text = temp.getShortSquadra();

                if (temp.getLicensedTeam())
                    teamLicense.Text = "Licensed";
                else
                    teamLicense.Text = "Unlicensed";

                if (temp.getNational())
                    teamType.Text = "National";
                else
                    teamType.Text = "Club";

                if (temp.getFakeTeam())
                    teamFake.Text = "Yes";
                else
                    teamFake.Text = "No";

                if (temp.getLicensedCoach())
                    teamCoachLicense.Text = "Licensed";
                else
                    teamCoachLicense.Text = "Unlicensed";

                if (temp.getNotPlayableLeague() == 0)
                    teamNotPlayableLeague.Text = "No League";
                else if (temp.getNotPlayableLeague() == 1)
                    teamNotPlayableLeague.Text = "Classic League";
                else if (temp.getNotPlayableLeague() == 2)
                    teamNotPlayableLeague.Text = "Other Europe League";
                else if (temp.getNotPlayableLeague() == 3)
                    teamNotPlayableLeague.Text = "Other Asian League";
                else if (temp.getNotPlayableLeague() == 4)
                    teamNotPlayableLeague.Text = "Hidden Fake European League";
                else if (temp.getNotPlayableLeague() == 5)
                    teamNotPlayableLeague.Text = "ML Hidden League";
                else if (temp.getNotPlayableLeague() == 6)
                    teamNotPlayableLeague.Text = "Other America League";
                else if (temp.getNotPlayableLeague() == 7)
                    teamNotPlayableLeague.Text = "Other Africa League";

                teamStadium.SelectedItem = controller.getTeamStadium(temp);

                if (temp.getHasLicensedPlayers())
                    hasLicensedPlayers.Checked = true;
                else
                    hasLicensedPlayers.Checked = false;

                if (temp.getHasAnthem())
                    hasAnthem.Checked = true;
                else
                    hasAnthem.Checked = false;

                anthemStandingAngle.Value = temp.getAnthemStandingAngle();
                anthemPlayersSinging.Value = temp.getAnthemPlayersSinging();
                anthemStandingStyle.Value = temp.getAnthemStandingStyle();

                if (temp.getUnknown6())
                    unknown.Checked = true;
                else
                    unknown.Checked = false;

                if (temp.getNational())
                {
                    National temp2 = (National)temp;
                    squadraPanel5.Enabled = true;
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

                controller.getCountryMap().GetType();
                Country value;
                if (!controller.getCountryMap().TryGetValue((long)temp.getCountry(), out value))
                    throw new ArgumentException("id country not found");

                teamCountry.Text =  value.getName();

            }
        }

        //quando si clicca invio //NOME SQUADRA AIO
        private void squadraName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamName(temp, teamName.Text);

                    if (teamType.Text == "National")
                    {
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
                    teamJapanese.Text = teamName.Text;

                    //aggiornare nome squadra
                    teamBox1.Items[intselectedindex] = temp;
                    teamBox2.Items[intselectedindex] = temp;
                    teamsBox.Items[intselectedindex] = temp;
                }
            }
        }

        private void teamJapanese_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamJapaneseName(temp, teamJapanese.Text);
                }
            }
        }

        private void teamSpanish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamSpanishName(temp, teamSpanish.Text);
                }
            }
        }

        private void teamTurkish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamTurkishName(temp, teamTurkish.Text);
                }
            }
        }

        private void teamSwedish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamSwedishName(temp, teamSwedish.Text);
                }
            }
        }

        private void teamGreek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamGreekName(temp, teamGreek.Text);
                }
            }
        }

        private void teamPortuguese_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamPortugueseName(temp, teamPortuguese.Text);
                }
            }
        }

        private void teamItalian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamItalianName(temp, teamItalian.Text);
                }
            }
        }

        private void teamEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamEnglishName(temp, teamEnglish.Text);
                }
            }
        }

        private void teamGerman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamGermanName(temp, teamGerman.Text);
                }
            }
        }

        private void teamRussian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamRussianName(temp, teamRussian.Text);
                }
            }
        }

        private void teamSpanish2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamLatinAmericaSpanishName(temp, teamSpanish2.Text);
                }
            }
        }

        private void teamPortuguese2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamBrazilianPortugueseName(temp, teamPortuguese2.Text);
                }
            }
        }

        private void teamEnglish2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamEnglishUsName(temp, teamEnglish2.Text);
                }
            }
        }

        private void teamFrench_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamFrenchName(temp, teamFrench.Text);
                }
            }
        }

        private void teamDutch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamDutchName(temp, teamDutch.Text);
                }
            }
        }

        //quando si clicca invio //SHORT SQUADRA
        private void squadraShort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teamsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamsBox.SelectedItem;
                    controller.changeTeamShortName(temp, teamShort.Text);
                }
            }
        }

        //Fake Team
        private void squadraFake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeFakeTeam(temp, teamFake.Text == "Yes");
            }
        }

        //License Team
        private void squadraLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeLicensedTeam(temp, teamLicense.Text == "Licensed");
            }
        }

        //License Coach
        private void squadraCoachLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeLicensedCoach(temp, teamCoachLicense.Text == "Licensed");
            }
        }

        //Playable League
        private void squadraNotPlayableLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                if (teamNotPlayableLeague.Text == "No League")
                    controller.changeNotPlayableLeague(temp, 0);
                else if (teamNotPlayableLeague.Text == "Classic League")
                    controller.changeNotPlayableLeague(temp, 1);
                else if (teamNotPlayableLeague.Text == "Other Europe League")
                    controller.changeNotPlayableLeague(temp, 2);
                else if (teamNotPlayableLeague.Text == "Other Asian League")
                    controller.changeNotPlayableLeague(temp, 3);
                else if (teamNotPlayableLeague.Text == "Hidden Fake European League")
                    controller.changeNotPlayableLeague(temp, 4);
                else if (teamNotPlayableLeague.Text == "ML Hidden League")
                    controller.changeNotPlayableLeague(temp, 5);
                else if (teamNotPlayableLeague.Text == "Other America League")
                    controller.changeNotPlayableLeague(temp, 6);
                else if (teamNotPlayableLeague.Text == "Other Africa League")
                    controller.changeNotPlayableLeague(temp, 7);
            }
        }

        //paese di provenienza squadra
        private void squadraCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeCountryTeam(temp, teamCountry.SelectedIndex);
            }
        }

        private void teamStadium_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeStadiumTeam(temp, (Stadium)teamStadium.SelectedItem);
            }
        }

        private void hasLicensedPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeHasLicensedPlayers(temp, hasLicensedPlayers.Checked);
            }
        }

        private void hasAnthem_CheckedChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeHasAnthem(temp, hasAnthem.Checked);
            }
        }

        private void anthemStandingAngle_ValueChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeAnthemStandingAngle(temp, int.Parse(anthemStandingAngle.Value.ToString()));
            }
        }

        private void anthemPlayersSinging_ValueChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeAnthemPlayersSinging(temp, int.Parse(anthemPlayersSinging.Value.ToString()));
            }
        }

        private void anthemStandingStyle_ValueChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeAnthemStandingStyle(temp, int.Parse(anthemStandingStyle.Value.ToString()));
            }
        }

        private void unknown_CheckedChanged(object sender, EventArgs e)
        {
            if (teamsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Team temp = (Team)teamsBox.SelectedItem;
                controller.changeUnknown(temp, unknown.Checked == true);
            }
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

        //export ballCondition
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

        //database
        private void databaseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*ControllerDB controllerDb = new ControllerDB();
            if (databaseView.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = databaseView.SelectedIndices[0];
            if (intselectedindex >= 0)
                controllerDb.readStadium(db14, db15, db16, dbStadiumDlc, dbStadiumHome, dbStadiumRealName, dbIdStadium, dbStadiumName, dbStadiumJapanese, dbStadiumCapacity, dbStadiumKonami, dbStadiumLicensed, databaseView, intselectedindex);*/
        }

        private void databaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*ControllerDB controllerDb = new ControllerDB();
            if (databaseBox.Text == "Stadium")
                controllerDb.loadStadium(databaseView, dbStadiumDlc);*/
        }

        //teamView1 drag&drop
        private void teamView1_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            Point cp = teamView1.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = teamView1.GetItemAt(cp.X, cp.Y);
            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (ListViewItem moveItem in teamView1.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }
            String text = (String)e.Data.GetData(TEAM_A.GetType());
            String text1 = (String)e.Data.GetData(TEAM_B.GetType());
            String text2 = (String)e.Data.GetData(PLAYER.GetType());
            if (text.CompareTo(TEAM_A) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else if (text1.CompareTo(TEAM_B) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else if (text2.CompareTo(PLAYER) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void teamView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            teamView1.DoDragDrop(TEAM_A, DragDropEffects.Move);
        }

        private void teamView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void teamView1_DragDrop(object sender, DragEventArgs e)
        {
            string text = (string)e.Data.GetData(TEAM_A.GetType());
            string text1 = (string)e.Data.GetData(TEAM_B.GetType());
            string text2 = (string)e.Data.GetData(PLAYER.GetType());
            if (text.CompareTo(TEAM_A) == 0)
            {
                if (teamView1.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamView1.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Point cp = teamView1.PointToClient(new Point(e.X, e.Y));
                    ListViewItem dragToItem = teamView1.GetItemAt(cp.X, cp.Y);
                    int dropIndex = dragToItem.Index;
                    Team temp = (Team)teamBox1.SelectedItem;
                    controller.transferPlayerAtoA(intselectedindex, dropIndex, temp.getId(), teamBox1, teamBox2);
                }
            }
            else if (text.CompareTo(TEAM_B) == 0)
            {
                if (teamView2.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamView2.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team teamA = (Team)teamBox1.SelectedItem;
                    Team teamB = (Team)teamBox2.SelectedItem;

                    if (teamView2.Items.Count > 11)
                    {
                        if (teamA.getNational())
                        {
                            if (teamView1.Items.Count < 23 && teamBox1.SelectedIndex != teamBox2.SelectedIndex)
                                controller.transferPlayerBtoA(intselectedindex, teamA, teamB, teamView1.Items.Count, teamBox1, teamBox2);
                            else
                                MessageBox.Show("National is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (teamView1.Items.Count < 32 && teamBox1.SelectedIndex != teamBox2.SelectedIndex)
                                controller.transferPlayerBtoA(intselectedindex, teamA, teamB, teamView1.Items.Count, teamBox1, teamBox2);
                            else
                                MessageBox.Show("Club is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("There are only 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (text2.CompareTo(PLAYER) == 0)
            {
                if (giocatoreView.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = giocatoreView.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team teamA = (Team)teamBox1.SelectedItem;

                    if (teamA.getNational())
                    {
                        if (teamView1.Items.Count < 23)
                            controller.playerFromPlayerList(controller.getPlayerById(intselectedindex).getId(), teamA.getId(), teamBox1, teamBox2);
                        else
                            MessageBox.Show("National is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (teamView1.Items.Count < 32)
                            controller.playerFromPlayerList(controller.getPlayerById(intselectedindex).getId(), teamA.getId(), teamBox1, teamBox2);
                        else
                            MessageBox.Show("Club is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        //teamView2 drag&drop
        private void teamView2_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            Point cp = teamView2.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = teamView2.GetItemAt(cp.X, cp.Y);
            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (ListViewItem moveItem in teamView2.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }
            String text = (String)e.Data.GetData(TEAM_A.GetType());
            String text1 = (String)e.Data.GetData(TEAM_B.GetType());
            String text2 = (String)e.Data.GetData(PLAYER.GetType());
            if (text.CompareTo(TEAM_A) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else if (text1.CompareTo(TEAM_B) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else if (text2.CompareTo(PLAYER) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void teamView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            teamView2.DoDragDrop(TEAM_B, DragDropEffects.Move);
        }

        private void teamView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void teamView2_DragDrop(object sender, DragEventArgs e)
        {
            string text = (string)e.Data.GetData(TEAM_A.GetType());
            string text1 = (string)e.Data.GetData(TEAM_B.GetType());
            string text2 = (string)e.Data.GetData(PLAYER.GetType());
            if (text.CompareTo(TEAM_B) == 0)
            {
                if (teamView2.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamView2.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Point cp = teamView2.PointToClient(new Point(e.X, e.Y));
                    ListViewItem dragToItem = teamView2.GetItemAt(cp.X, cp.Y);
                    int dropIndex = dragToItem.Index;
                    Team temp = (Team)teamBox2.SelectedItem;
                    controller.transferPlayerAtoA(intselectedindex, dropIndex, temp.getId(), teamBox1, teamBox2);
                }
            }
            else if (text.CompareTo(TEAM_A) == 0)
            {
                if (teamView1.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamView1.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team teamA = (Team)teamBox1.SelectedItem;
                    Team teamB = (Team)teamBox2.SelectedItem;

                    if (teamView1.Items.Count > 11)
                    {
                        if (teamB.getNational())
                        {
                            if (teamView2.Items.Count < 23 && teamBox1.SelectedIndex != teamBox2.SelectedIndex)
                                controller.transferPlayerBtoA(intselectedindex, teamB, teamA, teamView2.Items.Count, teamBox1, teamBox2);
                            else
                                MessageBox.Show("National is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (teamView2.Items.Count < 32 && teamBox1.SelectedIndex != teamBox2.SelectedIndex)
                                controller.transferPlayerBtoA(intselectedindex, teamB, teamA, teamView2.Items.Count, teamBox1, teamBox2);
                            else
                                MessageBox.Show("Club is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("There are only 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if (text2.CompareTo(PLAYER) == 0)
            {
                if (giocatoreView.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = giocatoreView.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team teamA = (Team)teamBox2.SelectedItem;

                    if (teamA.getNational())
                    {
                        if (teamView2.Items.Count < 23)
                            controller.playerFromPlayerList(controller.getPlayerById(intselectedindex).getId(), controller.getTeamById(teamBox2.SelectedIndex).getId(), teamBox1, teamBox2);
                        else
                            MessageBox.Show("National is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (teamView2.Items.Count < 32)
                            controller.playerFromPlayerList(controller.getPlayerById(intselectedindex).getId(), controller.getTeamById(teamBox2.SelectedIndex).getId(), teamBox1, teamBox2);
                        else
                            MessageBox.Show("Club is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        //giocatoreView
        private void giocatoreView_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            Point cp = giocatoreView.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = giocatoreView.GetItemAt(cp.X, cp.Y);
            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (ListViewItem moveItem in giocatoreView.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }
            String text = (String)e.Data.GetData(TEAM_A.GetType());
            String text1 = (String)e.Data.GetData(TEAM_B.GetType());
            if (text.CompareTo(TEAM_A) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else if (text1.CompareTo(TEAM_B) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void giocatoreView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            giocatoreView.DoDragDrop(PLAYER, DragDropEffects.Move);
        }

        private void giocatoreView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void giocatoreView_DragDrop(object sender, DragEventArgs e)
        {
            string text = (string)e.Data.GetData(TEAM_A.GetType());
            string text1 = (string)e.Data.GetData(TEAM_B.GetType());
            if (text.CompareTo(TEAM_A) == 0)
            {
                if (teamView1.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamView1.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamBox1.SelectedItem;
                    if (teamView1.Items.Count > 11)
                        controller.deletePlayerTeam(intselectedindex, temp.getId(), teamBox1, teamBox2);
                    else
                        MessageBox.Show("There are only 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (text.CompareTo(TEAM_B) == 0)
            {
                if (teamView2.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = teamView2.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Team temp = (Team)teamBox2.SelectedItem;
                    if (teamView2.Items.Count > 11)
                        controller.deletePlayerTeam(intselectedindex, temp.getId(), teamBox1, teamBox2);
                    else
                        MessageBox.Show("There are only 11 players", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Save
        private void save_Click(object sender, EventArgs e)
        {
            controller.saveBallConditionPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.savePlayerAssignmentPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.savePlayerAppearancePersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveTacticsFormationPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveBallPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.savePlayerPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveTeamPersister(fbd.SelectedPath, controller, controller.getBitRecognized());
            controller.saveStadiumPersister(fbd.SelectedPath, controller, controller.getBitRecognized());

            MessageBox.Show("Saved Data", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("All Files Saved at:" + Environment.NewLine + fbd.SelectedPath, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //remove fake teams
        private void removeFakeTeam_Click(object sender, EventArgs e)
        {
            controller.removeFakeTeam();

            teamsBox.Items.Clear();
            teamBox1.Items.Clear();
            teamBox2.Items.Clear();

            foreach (Team temp in controller.getListTeam())
            {
                teamsBox.Items.Add(temp);
                teamBox1.Items.Add(temp);
                teamBox2.Items.Add(temp);
            }

            //selezionare 2 squadre default
            teamBox1.SelectedIndex = 0;
            teamBox2.SelectedIndex = 0;
            teamsBox.SelectedIndex = 0;

            MessageBox.Show("Fake teams corrected!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //remove fake players
        private void removeFakeClassicPlayer_Click(object sender, EventArgs e)
        {
            controller.removeFakePlayer();

            MessageBox.Show("Classic players fake names corrected!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //import BallCondition
        private void csvToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            //Setup OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Open File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 IMPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControllerCSV csv = new ControllerCSV();
                csv.importBallCondition(controller, ofd.FileName, ballsBox);
                MessageBox.Show("CSV imported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //import Ball
        private void csvToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Setup OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Open File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 IMPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControllerCSV csv = new ControllerCSV();
                csv.importBall(controller, ofd.FileName, ballsBox);
                MessageBox.Show("CSV imported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //import PlayerAppareance
        private void csvToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            //Setup OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Open File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 IMPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControllerCSV csv = new ControllerCSV();
                csv.importPlayerAppareance(controller, ofd.FileName);
                MessageBox.Show("CSV imported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //import Team
        private void csvToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Setup OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Open File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 IMPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControllerCSV csv = new ControllerCSV();
                csv.importTeam(controller, ofd.FileName, teamsBox, teamBox1, teamBox2);
                MessageBox.Show("CSV imported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //import Player
        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Setup OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            //Title of OPENFILEDIALOG
            ofd.Title = "Open File";
            //Set Filter for only .bin files
            ofd.Filter = "PES 2018 IMPORT (*.csv)|*.csv";
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ControllerCSV csv = new ControllerCSV();
                csv.importPlayer(controller, ofd.FileName, giocatoreView, teamBox1, teamBox2);
                MessageBox.Show("CSV imported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //upper, lower teams
        private void globalFunctionTeam_Click(object sender, EventArgs e)
        {
            if (upperTeam.Checked == true)
                controller.upperTeams(teamsBox, teamBox1, teamBox2);
            else if (lowerTeam.Checked == true)
                controller.lowerTeams(teamsBox, teamBox1, teamBox2);
            else if (firstUpTeam.Checked == true)
                controller.firstUpTeams(teamsBox, teamBox1, teamBox2);
            MessageBox.Show("New teams names applied", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //upper, lower players
        private void globalFunctionPlayer_Click(object sender, EventArgs e)
        {
            if (upperPlayer.Checked == true)
                controller.upperPlayers(giocatoreView, teamBox1, teamBox2);
            else if (lowerPlayer.Checked == true)
                controller.lowerPlayers(giocatoreView, teamBox1, teamBox2);
            else if (firstUpPlayer.Checked == true)
                controller.firstUpPlayers(giocatoreView, teamBox1, teamBox2);
            MessageBox.Show("New players names applied", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //load Football Manager stats
        private void loadFootballManager_Click(object sender, EventArgs e)
        {
            //FMStats a = new FMStats(controllerFm, controller);
            //a.Show();
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
            stadiumKonami.Text = "";
            stadiumCapacity.Text = "";
            stadiumNa.Text = "";

            int intselectedindex = stadiumsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                stadiumName.Text = temp.getName();
                stadiumId.Text = temp.getId().ToString();
                stadiumJapanese.Text = temp.getJapaneseName();
                stadiumKonami.Text = temp.getKonamiName();
                stadiumCapacity.Text = temp.getCapacity().ToString();
                stadiumNa.Text = temp.getNa().ToString();
                stadiumZone.Text = temp.getStringZone();
                if (temp.getLicense())
                    stadiumLicense.Text = "Licensed";
                else
                    stadiumLicense.Text = "Unlicensed";

                controller.getCountryMap().GetType();
                Country value;
                if (!controller.getCountryMap().TryGetValue((long)temp.getCountry(), out value))
                    throw new ArgumentException("id country not found");
                stadiumCountry.Text = value.getName();
            }
        }

        //stadium name
        private void stadiumName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (stadiumsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = stadiumsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                    controller.changeStadiumName(temp, stadiumName.Text);

                    //selezionare il nome stadio interessato
                    stadiumsBox.SelectedIndex = intselectedindex;
                    stadiumsBox.Select();

                    //aggiornare nome stadi
                    teamStadium.Items[intselectedindex] = temp;
                    stadiumsBox.Items[intselectedindex] = temp;
                }
            }
        }

        //stadium japanese
        private void stadiumJapanese_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (stadiumsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = stadiumsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                    controller.changeStadiumJapaneseName(temp, stadiumJapanese.Text);

                    //selezionare il nome stadio interessato
                    stadiumsBox.SelectedIndex = intselectedindex;
                    stadiumsBox.Select();
                }
            }
        }

        //stadium konami
        private void stadiumKonami_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (stadiumsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = stadiumsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                    controller.changeStadiumKonamiName(temp, stadiumKonami.Text);

                    //selezionare il nome stadio interessato
                    stadiumsBox.SelectedIndex = intselectedindex;
                    stadiumsBox.Select();
                }
            }
        }

        //stadium capacity
        private void stadiumCapacity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (stadiumsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = stadiumsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                    controller.changeStadiumCapacity(temp, int.Parse(stadiumCapacity.Text));

                    //selezionare il nome stadio interessato
                    stadiumsBox.SelectedIndex = intselectedindex;
                    stadiumsBox.Select();
                }
            }
        }

        //stadium na
        private void StadiumNa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (stadiumsBox.SelectedIndices.Count <= 0)
                    return;
                int intselectedindex = stadiumsBox.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                    controller.changeStadiumNa(temp, int.Parse(stadiumNa.Text));

                    //selezionare il nome stadio interessato
                    stadiumsBox.SelectedIndex = intselectedindex;
                    stadiumsBox.Select();
                }
            }
        }

        //stadium country
        private void stadiumCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stadiumsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = stadiumsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                controller.changeCountryStadium(temp, stadiumCountry.SelectedIndex);
                //selezionare il nome squadra interessata
                stadiumsBox.SelectedIndex = intselectedindex;
                stadiumsBox.Select();
            }
        }

        //stadium zone
        private void stadiumZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stadiumsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = stadiumsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                controller.changeZoneStadium(temp, stadiumZone.SelectedIndex);
                //selezionare il nome squadra interessata
                stadiumsBox.SelectedIndex = intselectedindex;
                stadiumsBox.Select();
            }
        }

        //stadium licensed
        private void stadiumLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stadiumsBox.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = stadiumsBox.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                Stadium temp = (Stadium)stadiumsBox.SelectedItem;
                controller.changeLicensedStadium(temp, stadiumLicense.Text == "Licensed");
                //selezionare il nome squadra interessata
                stadiumsBox.SelectedIndex = intselectedindex;
                stadiumsBox.Select();
            }
        }

        //Copy From DB
        private void accept_Click(object sender, EventArgs e)
        {

        }

        private FolderBrowserDialog fbd2;
        private void pes18ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbd2 = new FolderBrowserDialog();
            DialogResult result = fbd2.ShowDialog();
            if (result == DialogResult.OK)
            {
                typeDB.Text = "Type DB: 18";
                path.Text = "Path: " + fbd2.RootFolder;

                controller.openDb2(fbd2.SelectedPath);

                tot.Text = "PLAYERS: " + controller.getListPlayer2().Count + " - TEAMS: " + controller.getListTeam2().Count + " - STADIUMS: " + controller.getListStadium2().Count + " - TACTICSFORMATIONS: " + controller.getListTacticsFormationList2().Count
                    + " - BALLS: " + controller.getListBall2().Count + " - BALLCONDITION: " + controller.getListBallCondition2().Count;

                groupBox4.Visible = true;
                groupBox7.Visible = true;
                groupBox11.Visible = true;
                groupBox13.Visible = true;

                db2FromPlayers.Value = controller.getListPlayer()[0].getId();
                db2ToPlayers.Value = controller.getListPlayer()[controller.getListPlayer().Count - 1].getId();
                db2FromTextBoxPlayers.Text = controller.getListPlayer()[0].getPlayerName();
                db2FromTeams.Maximum = controller.getListTeam().Count;
                db2FromTextBoxTeams.Text = controller.getListTeam()[0].getEnglish();
                db2ToTeams.Maximum = controller.getListTeam().Count;
                db2ToTeams.Value = controller.getListTeam().Count;
                db2ToTextBoxTeams.Text = controller.getListTeam()[controller.getListTeam().Count - 1].getEnglish();
            }
        }

        private void db2AllBalls_Click(object sender, EventArgs e)
        {
            controller.importDb2AllBalls();

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2OrderBalls_Click(object sender, EventArgs e)
        {
            controller.importDb2OrderBalls();

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2NamesBalls_Click(object sender, EventArgs e)
        {
            controller.importDb2NamesBalls();

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2AllTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2AllTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2NamesTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2NamesTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2ShortNamesTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2ShortNamesTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2HomeStadiumsTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2HomeStadiumsTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2OtherDetailsTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2OtherDetailsTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2CountryTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2CountryTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2FakeTeamTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2FakeTeamTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2NonPlayaLeagueTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2NotPlayableLeagueTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2LicenseTeams_Click(object sender, EventArgs e)
        {
            controller.importDb2LicenseTeamTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            controller.importDb2LicenseCoachTeams(int.Parse(db2FromTeams.Value.ToString()), int.Parse(db2ToTeams.Value.ToString()));

            MessageBox.Show("Operation complete!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void db2FromTeams_ValueChanged(object sender, EventArgs e)
        {
            db2FromTextBoxTeams.Text = controller.getTeamById(int.Parse(db2FromTeams.Value.ToString()) - 1).getEnglish();
        }

        private void db2ToTeams_ValueChanged(object sender, EventArgs e)
        {
            db2ToTextBoxTeams.Text = controller.getTeamById(int.Parse(db2ToTeams.Value.ToString()) - 1).getEnglish();
        }
    }
}

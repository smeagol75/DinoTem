using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DinoTem.ui;
using DinoTem.model;

namespace DinoTem
{
    public partial class Formazione : Form
    {
        private const string TEAM_A = "Team A";

        private Controller controller;
        private Team team;
        public Formazione(Controller controller, Team team)
        {
            InitializeComponent();
            this.controller = controller;
            this.team = team;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //tattiche se sono selezionate o no
        private void buildUp_CheckedChanged(object sender, EventArgs e)
        {
            if (buildUp.Checked == true)
                buildUp.Text = "Build up - Short Pass";
            else
                buildUp.Text = "Build up - Long Pass";
        }

        private void defensiveStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (defensiveStyle.Checked == true)
                defensiveStyle.Text = "Defensive Style - All Out Deffence";
            else
                defensiveStyle.Text = "Defensive Style - Front Line Pressure";
        }

        private void attackingArea_CheckedChanged(object sender, EventArgs e)
        {
            if (attackingArea.Checked == true)
                attackingArea.Text = "Attacking Area - Centre";
            else
                attackingArea.Text = "Attacking Area - Wide";
        }

        private void containmentArea_CheckedChanged(object sender, EventArgs e)
        {
            if (containmentArea.Checked == true)
                containmentArea.Text = "Containment Area - Wide";
            else
                containmentArea.Text = "Attacking Area - Middle";
        }

        private void pressuring_CheckedChanged(object sender, EventArgs e)
        {
            if (pressuring.Checked == true)
                pressuring.Text = "Pressuring - Conservative";
            else
                pressuring.Text = "Pressuring - Aggresive";
        }

        private void attackingStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (attackingStyle.Checked == true)
                attackingStyle.Text = "Attacking Style - Possesion game";
            else
                attackingStyle.Text = "Attacking Style - Counter Attack";
        }

        private void positioning_CheckedChanged(object sender, EventArgs e)
        {
            if (positioning.Checked == true)
                positioning.Text = "Positioning - Flexible";
            else
                positioning.Text = "Fluid Formation - Mantain Formation";
        }

        private void fuildFormation_CheckedChanged(object sender, EventArgs e)
        {
            if (fuildFormation.Checked == true)
                fuildFormation.Text = "Fluid Formation - ON";
            else
                fuildFormation.Text = "Fluid Formation - OFF";
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
                    teamView1.Items[i5].SubItems[4].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i5].SubItems[5].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[0].UseItemStyleForSubItems = false;
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
                    teamView1.Items[i6 - 1].SubItems[5].ForeColor = SystemColors.WindowText;

                    //vedere se ci sono numeri uguali
                    numeri = numeri + teamView1.Items[i6 - 1].SubItems[5].Text + ",";
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
                                    if (word == teamView1.Items[i2 - 1].SubItems[5].Text)
                                    {
                                        teamView1.Items[i2 - 1].SubItems[3].ForeColor = System.Drawing.Color.Red;
                                        teamView1.Items[i2 - 1].UseItemStyleForSubItems = false;
                                    }
                                }
                                //numero
                                teamView1.Items[i4 - 1].SubItems[5].ForeColor = System.Drawing.Color.Red;
                                teamView1.Items[i4 - 1].UseItemStyleForSubItems = false;
                            }
                        }
                    }
                }
                //tab selezionato (CUSTOM)
                int i6a = 0;
                int NumberOfRepetitions6a = Convert.ToInt32(10);
                for (i6a = 0; i6a <= NumberOfRepetitions6a; i6a++)
                {
                    teamView1.Items[i6a].SubItems[1].BackColor = System.Drawing.Color.FromArgb(93, 156, 233);
                    teamView1.Items[i6a].UseItemStyleForSubItems = false;
                }

                //selezionare primo giocatore
                teamView1.Items[0].Selected = true;
                teamView1.Select();
                //selezionare schiemi
                schemes.SelectedIndex = 0;
            }
            catch { }
        }

        //Caricare Campi
        private void Caricare_Campi()
        {
            //aggiungere schemi
            schemes.Items.Add("Default");
            schemes.Items.Add("4-5-1");
            schemes.Items.Add("4-4-2");
            schemes.Items.Add("4-3-3");
            schemes.Items.Add("3-5-2");
            schemes.Items.Add("3-4-3");
            schemes.Items.Add("5-4-1");
            schemes.Items.Add("5-3-2");

            //aggiungere posizioni
            position.Items.Add("GK");
            position.Items.Add("CB");
            position.Items.Add("RB");
            position.Items.Add("LB");
            position.Items.Add("DMF");
            position.Items.Add("CMF");
            position.Items.Add("LMF");
            position.Items.Add("RMF");
            position.Items.Add("AMF");
            position.Items.Add("LWF");
            position.Items.Add("RWF");
            position.Items.Add("SS");
            position.Items.Add("CF");

            attackFewMedMany.Items.Add("0");
            attackFewMedMany.Items.Add("1");
            attackFewMedMany.Items.Add("2");

            defenseFewMedMany.Items.Add("0");
            defenseFewMedMany.Items.Add("1");
            defenseFewMedMany.Items.Add("2");

            defensiveLine.Items.Add("0");
            defensiveLine.Items.Add("1");
            defensiveLine.Items.Add("2");
            defensiveLine.Items.Add("3");
            defensiveLine.Items.Add("4");
            defensiveLine.Items.Add("5");
            defensiveLine.Items.Add("6");
            defensiveLine.Items.Add("7");
            defensiveLine.Items.Add("8");
            defensiveLine.Items.Add("9");
            defensiveLine.Items.Add("10");

            supportRange.Items.Add("0");
            supportRange.Items.Add("1");
            supportRange.Items.Add("2");
            supportRange.Items.Add("3");
            supportRange.Items.Add("4");
            supportRange.Items.Add("5");
            supportRange.Items.Add("6");
            supportRange.Items.Add("7");
            supportRange.Items.Add("8");
            supportRange.Items.Add("9");
            supportRange.Items.Add("10");

            compactness.Items.Add("0");
            compactness.Items.Add("1");
            compactness.Items.Add("2");
            compactness.Items.Add("3");
            compactness.Items.Add("4");
            compactness.Items.Add("5");
            compactness.Items.Add("6");
            compactness.Items.Add("7");
            compactness.Items.Add("8");
            compactness.Items.Add("9");
            compactness.Items.Add("10");
        }

        private ListViewItem Leggere_GiocatoreSquadre(PlayerAssignment pAssignment)
        {
            ListViewItem item = new ListViewItem();
            Player temp2 = controller.leggiGiocatoreById(pAssignment.getPlayerId());

            item = new ListViewItem((pAssignment.getOrder() + 1).ToString());
            item.SubItems.Add(temp2.getStringPosition());
            item.SubItems.Add(temp2.getStringPosition());
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

            if (pAssignment.getOrder() <= 10)
            {
                capitain.Items.Add(temp2.getName());
                penaltyKT.Items.Add(temp2.getName());
                longFT.Items.Add(temp2.getName());
                leftCK.Items.Add(temp2.getName());
                shortFT.Items.Add(temp2.getName());
                rightCK.Items.Add(temp2.getName());
            }

            if (pAssignment.getRightCornerKick() == 1)
                rightCK.SelectedIndex = pAssignment.getOrder();

            if (pAssignment.getPenaltyKick() == 1)
                penaltyKT.SelectedIndex = pAssignment.getOrder();

            if (pAssignment.getLongShotLk() == 1)
                longFT.SelectedIndex = pAssignment.getOrder();

            if (pAssignment.getLeftCkTk() == 1)
                leftCK.SelectedIndex = pAssignment.getOrder();

            if (pAssignment.getShortFoulFk() == 1)
                shortFT.SelectedIndex = pAssignment.getOrder();

            if (pAssignment.getCaptain() == 1)
                capitain.SelectedIndex = pAssignment.getOrder();

            return item;
        }

        private void LeggereFormazioni(List<TacticsFormation> position, ListView list)
        {
            int k = 0;
            foreach (TacticsFormation temp in position)
            {
                if (k <= 10)
                {
                    list.Items[k].SubItems[1].Text = temp.getStringPosition();
                }
                if (k > 10 & k <= 21)
                {
                    list.Items[k - 11].SubItems[2].Text = temp.getStringPosition();
                }
                if (k > 21 & k <= 32)
                {
                    list.Items[k - 22].SubItems[3].Text = temp.getStringPosition();
                }
                k++;
            }
        }

        private void loadTactics(Tactics t)
        {
            if (t.getBuildUp() == 1)
                buildUp.Checked = true;
            else
                buildUp.Checked = false;

            if (t.getDefensiveStyle() == 1)
                defensiveStyle.Checked = true;
            else
                defensiveStyle.Checked = false;

            if (t.getAttackingArea() == 1)
                attackingArea.Checked = true;
            else
                attackingArea.Checked = false;

            if (t.getContainmentArea() == 1)
                containmentArea.Checked = true;
            else
                containmentArea.Checked = false;

            if (t.getPressuring() == 1)
                pressuring.Checked = true;
            else
                pressuring.Checked = false;

            if (t.getAttackingStyle() == 1)
                attackingStyle.Checked = true;
            else
                attackingStyle.Checked = false;

            if (t.getFluidFormation() == 1)
                fuildFormation.Checked = true;
            else
                fuildFormation.Checked = false;

            if (t.getPositioning() == 1)
                positioning.Checked = true;
            else
                positioning.Checked = false;

            attackFewMedMany.SelectedIndex = t.getAttackingNumbers();
            defenseFewMedMany.SelectedIndex = t.getDefendingNumbers();
            defensiveLine.SelectedIndex = t.getDefensiveLine();
            supportRange.SelectedIndex = t.getSupportRange();
            compactness.SelectedIndex = t.getCompactness();
        }

        private void Formazione_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            Caricare_Campi();

            teamView1.Items.Clear();

            List<PlayerAssignment> list = controller.leggiGiocatoriSquadra(team.getId());
            foreach (PlayerAssignment temp2 in list)
            {
                teamView1.Items.Add(Leggere_GiocatoreSquadre(temp2));
            }

            List<Tactics> tactics = controller.leggiTattica(team.getId());
            foreach (Tactics x in tactics)
            {
                numberFormation.Items.Add(x.getTacticsId());
            }
            loadTactics(tactics[0]);

            List<TacticsFormation> tacticsFormation = controller.leggiFormazione(tactics[0].getTacticsId());
            LeggereFormazioni(tacticsFormation, teamView1);

            //selezionare numero tattica
            schemes.SelectedIndex = 0;
            numberFormation.SelectedIndex = 0;

            sfondoTeamView();
        }

        //Selezionare Player su Gameplan
        public void changeColorGamePlan(int i, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            teamView1.Items[i].Selected = true;
            teamView1.Select();

            player1.ForeColor = System.Drawing.Color.Yellow;
            player2.ForeColor = System.Drawing.Color.White;
            player3.ForeColor = System.Drawing.Color.White;
            player4.ForeColor = System.Drawing.Color.White;
            player5.ForeColor = System.Drawing.Color.White;
            player6.ForeColor = System.Drawing.Color.White;
            player7.ForeColor = System.Drawing.Color.White;
            player8.ForeColor = System.Drawing.Color.White;
            player9.ForeColor = System.Drawing.Color.White;
            player10.ForeColor = System.Drawing.Color.White;
            player11.ForeColor = System.Drawing.Color.White;
        }

        private void player11_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(10, player11, player2, player3, player4, player5, player6, player7, player8, player9, player10, player1);
        }

        private void player1_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(0, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
        }

        private void player2_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(1, player2, player1, player3, player4, player5, player6, player7, player8, player9, player10, player11);
        }

        private void player3_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(2, player3, player2, player1, player4, player5, player6, player7, player8, player9, player10, player11);
        }

        private void player4_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(3, player4, player2, player3, player1, player5, player6, player7, player8, player9, player10, player11);
        }

        private void player5_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(4, player5, player2, player3, player4, player1, player6, player7, player8, player9, player10, player11);
        }

        private void player6_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(5, player6, player2, player3, player4, player5, player1, player7, player8, player9, player10, player11);
        }

        private void player7_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(6, player7, player2, player3, player4, player5, player6, player1, player8, player9, player10, player11);
        }

        private void player8_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(7, player8, player2, player3, player4, player5, player6, player7, player1, player9, player10, player11);
        }

        private void player9_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(8, player9, player2, player3, player4, player5, player6, player7, player8, player1, player10, player11);
        }

        private void player10_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(9, player10, player2, player3, player4, player5, player6, player7, player8, player9, player1, player11);
        }

        private void player12_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(0, player12, player13, player14, player15, player16, player17, player18, player19, player20, player21, player22);
        }

        private void player13_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(1, player13, player12, player14, player15, player16, player17, player18, player19, player20, player21, player22);
        }

        private void player14_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(2, player14, player13, player12, player15, player16, player17, player18, player19, player20, player21, player22);
        }

        private void player15_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(3, player15, player13, player14, player12, player16, player17, player18, player19, player20, player21, player22);
        }

        private void player16_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(4, player16, player13, player14, player15, player12, player17, player18, player19, player20, player21, player22);
        }

        private void player17_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(5, player17, player13, player14, player15, player16, player12, player18, player19, player20, player21, player22);
        }

        private void player18_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(6, player18, player13, player14, player15, player16, player17, player12, player19, player20, player21, player22);
        }

        private void player19_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(7, player19, player13, player14, player15, player16, player17, player18, player12, player20, player21, player22);
        }

        private void player20_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(8, player20, player13, player14, player15, player16, player17, player18, player19, player12, player21, player22);
        }

        private void player21_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(9, player21, player13, player14, player15, player16, player17, player18, player19, player20, player12, player22);
        }

        private void player22_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(10, player22, player13, player14, player15, player16, player17, player18, player19, player20, player21, player12);
        }

        private void player23_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(0, player23, player24, player25, player26, player27, player28, player29, player30, player31, player32, player33);
        }

        private void player24_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(1, player24, player23, player25, player26, player27, player28, player29, player30, player31, player32, player33);
        }

        private void player25_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(2, player25, player24, player23, player26, player27, player28, player29, player30, player31, player32, player33);
        }

        private void player26_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(3, player26, player24, player25, player23, player27, player28, player29, player30, player31, player32, player33);
        }

        private void player27_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(4, player27, player24, player25, player26, player23, player28, player29, player30, player31, player32, player33);
        }

        private void player28_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(5, player28, player24, player25, player26, player27, player23, player29, player30, player31, player32, player33);
        }

        private void player29_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(6, player29, player24, player25, player26, player27, player28, player23, player30, player31, player32, player33);
        }

        private void player30_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(7, player30, player24, player25, player26, player27, player28, player29, player23, player31, player32, player33);
        }

        private void player31_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(8, player31, player24, player25, player26, player27, player28, player29, player30, player23, player32, player33);
        }

        private void player32_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(9, player32, player24, player25, player26, player27, player28, player29, player30, player31, player23, player33);
        }

        private void player33_Click(object sender, EventArgs e)
        {
            changeColorGamePlan(10, player33, player24, player25, player26, player27, player28, player29, player30, player31, player32, player23);
        }

        private void Formazione_FormClosed(object sender, FormClosedEventArgs e)
        {
            //controller.UpdateForm(Form1._Form1.teamBox1, Form1._Form1.teamBox2);
        }

        //spostare giocatori con un click
        private Point MouseDownLocation;
        private void mouseMove(Button player, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                player.Left = e.X + player.Left - MouseDownLocation.X;
                player.Top = e.Y + player.Top - MouseDownLocation.Y;
            }
        }

        private void player11_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player11, e);
        }

        private void player11_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player10_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player10, e);
        }

        private void player10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player13_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player13, e);
        }

        private void player13_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player14_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player14, e);
        }

        private void player14_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player15_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player15, e);
        }

        private void player15_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player16_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player16, e);
        }

        private void player16_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player17_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player17_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player17, e);
        }

        private void player18_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player18_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player18, e);
        }

        private void player19_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player19_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player19, e);
        }

        private void player2_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player2, e);
        }

        private void player2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player20_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player20_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player20, e);
        }

        private void player21_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player21_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player21, e);
        }

        private void player22_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void player22_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player22, e);
        }

        private void player24_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player24, e);
        }

        private void player24_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player25_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player25, e);
        }

        private void player25_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player26_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player26_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player26, e);
        }

        private void player27_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player27, e);
        }

        private void player27_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player28_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player28_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player28, e);
        }

        private void player29_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player29_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player29, e);
        }

        private void player3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player3_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player3, e);
        }

        private void player30_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player30, e);
        }

        private void player30_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player31_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player31, e);
        }

        private void player31_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player32_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player32, e);
        }

        private void player32_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player33_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player33_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player33, e);
        }

        private void player4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player4_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player4, e);
        }

        private void player5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player5_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player5, e);
        }

        private void player6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player6_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player6, e);
        }

        private void player7_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player7, e);
        }

        private void player7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player8_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player8, e);
        }

        private void player9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void player9_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMove(player9, e);
        }

        //gameplan
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["Custom"])//your specific tabname
            {
                player1.ForeColor = System.Drawing.Color.Yellow;
                int i6 = 0;
                int NumberOfRepetitions6 = Convert.ToInt32(10);
                for (i6 = 0; i6 <= NumberOfRepetitions6; i6++)
                {
                    teamView1.Items[i6].SubItems[1].BackColor = System.Drawing.Color.FromArgb(93, 156, 233);
                    teamView1.Items[i6].SubItems[2].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i6].SubItems[3].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i6].UseItemStyleForSubItems = false;
                }
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["Offensive"])//your specific tabname
            {
                player12.ForeColor = System.Drawing.Color.Yellow;
                int i6 = 0;
                int NumberOfRepetitions6 = Convert.ToInt32(10);
                for (i6 = 0; i6 <= NumberOfRepetitions6; i6++)
                {
                    teamView1.Items[i6].SubItems[2].BackColor = System.Drawing.Color.FromArgb(93, 156, 233);
                    teamView1.Items[i6].SubItems[1].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i6].SubItems[3].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i6].UseItemStyleForSubItems = false;
                }
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["Defensive"])//your specific tabname
            {
                player23.ForeColor = System.Drawing.Color.Yellow;
                int i6 = 0;
                int NumberOfRepetitions6 = Convert.ToInt32(10);
                for (i6 = 0; i6 <= NumberOfRepetitions6; i6++)
                {
                    teamView1.Items[i6].SubItems[3].BackColor = System.Drawing.Color.FromArgb(93, 156, 233);
                    teamView1.Items[i6].SubItems[2].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i6].SubItems[1].BackColor = System.Drawing.Color.FromArgb(183, 215, 254);
                    teamView1.Items[i6].UseItemStyleForSubItems = false;
                }
            }
            //resettare altri tabpages
            player1.ForeColor = System.Drawing.Color.White;
            player2.ForeColor = System.Drawing.Color.White;
            player3.ForeColor = System.Drawing.Color.White;
            player4.ForeColor = System.Drawing.Color.White;
            player5.ForeColor = System.Drawing.Color.White;
            player6.ForeColor = System.Drawing.Color.White;
            player7.ForeColor = System.Drawing.Color.White;
            player8.ForeColor = System.Drawing.Color.White;
            player9.ForeColor = System.Drawing.Color.White;
            player10.ForeColor = System.Drawing.Color.White;
            player11.ForeColor = System.Drawing.Color.White;

            player12.ForeColor = System.Drawing.Color.White;
            player13.ForeColor = System.Drawing.Color.White;
            player14.ForeColor = System.Drawing.Color.White;
            player15.ForeColor = System.Drawing.Color.White;
            player16.ForeColor = System.Drawing.Color.White;
            player17.ForeColor = System.Drawing.Color.White;
            player18.ForeColor = System.Drawing.Color.White;
            player19.ForeColor = System.Drawing.Color.White;
            player20.ForeColor = System.Drawing.Color.White;
            player21.ForeColor = System.Drawing.Color.White;
            player22.ForeColor = System.Drawing.Color.White;

            player23.ForeColor = System.Drawing.Color.White;
            player24.ForeColor = System.Drawing.Color.White;
            player25.ForeColor = System.Drawing.Color.White;
            player26.ForeColor = System.Drawing.Color.White;
            player27.ForeColor = System.Drawing.Color.White;
            player28.ForeColor = System.Drawing.Color.White;
            player29.ForeColor = System.Drawing.Color.White;
            player30.ForeColor = System.Drawing.Color.White;
            player31.ForeColor = System.Drawing.Color.White;
            player32.ForeColor = System.Drawing.Color.White;
            player33.ForeColor = System.Drawing.Color.White;

            teamView1.Items[0].Selected = true;
            teamView1.Select();
        }

        //cambiare posizione giocatori
        private void Position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamView1.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["Custom"])//your specific tabname
                    teamView1.Items[intselectedindex].SubItems[1].Text = position.Text;
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Offensive"])//your specific tabname
                    teamView1.Items[intselectedindex].SubItems[2].Text = position.Text;
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Defensive"])//your specific tabname
                    teamView1.Items[intselectedindex].SubItems[3].Text = position.Text;
            }
        }

        public void leggiSchemi()
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["Custom"])
            {
                controller.schemiPitch(ushort.Parse(numberFormation.Text), schemes.Text, 0, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                controller.numeriMagliaPitch(teamView1, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["Offensive"])
            {
                controller.schemiPitch(ushort.Parse(numberFormation.Text), schemes.Text, 1, player12, player13, player14, player15, player16, player17, player18, player19, player20, player21, player22);
                controller.numeriMagliaPitch(teamView1, player12, player13, player14, player15, player16, player17, player18, player19, player20, player21, player22);
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["Defensive"])
            {
                controller.schemiPitch(ushort.Parse(numberFormation.Text), schemes.Text, 2, player23, player24, player25, player26, player27, player28, player29, player30, player31, player32, player33);
                controller.numeriMagliaPitch(teamView1, player23, player24, player25, player26, player27, player28, player29, player30, player31, player32, player33);
            }
        }

        //Schemi
        private void schemi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numberFormation.SelectedIndex != -1)
                leggiSchemi();
        }

        private void teamView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamView1.SelectedIndices.Count <= 0)
                return;
            int intselectedindex = teamView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                //selezionare la posizione del giocatore
                if (tabControl1.SelectedTab == tabControl1.TabPages["Custom"])//your specific tabname
                {
                    position.Text = teamView1.Items[intselectedindex].SubItems[1].Text;

                    if (intselectedindex == 0)
                    {
                        player1.ForeColor = System.Drawing.Color.Yellow;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 1)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.Yellow;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 2)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.Yellow;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 3)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.Yellow;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 4)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.Yellow;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 5)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.Yellow;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 6)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.Yellow;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 7)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.Yellow;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 8)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.Yellow;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 9)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.Yellow;
                        player11.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 10)
                    {
                        player1.ForeColor = System.Drawing.Color.White;
                        player2.ForeColor = System.Drawing.Color.White;
                        player3.ForeColor = System.Drawing.Color.White;
                        player4.ForeColor = System.Drawing.Color.White;
                        player5.ForeColor = System.Drawing.Color.White;
                        player6.ForeColor = System.Drawing.Color.White;
                        player7.ForeColor = System.Drawing.Color.White;
                        player8.ForeColor = System.Drawing.Color.White;
                        player9.ForeColor = System.Drawing.Color.White;
                        player10.ForeColor = System.Drawing.Color.White;
                        player11.ForeColor = System.Drawing.Color.Yellow;
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Offensive"])//your specific tabname
                {
                    position.Text = teamView1.Items[intselectedindex].SubItems[2].Text;

                    if (intselectedindex == 0)
                    {
                        player12.ForeColor = System.Drawing.Color.Yellow;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 1)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.Yellow;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 2)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.Yellow;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 3)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.Yellow;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 4)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.Yellow;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 5)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.Yellow;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 6)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.Yellow;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 7)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.Yellow;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 8)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.Yellow;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 9)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.Yellow;
                        player22.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 10)
                    {
                        player12.ForeColor = System.Drawing.Color.White;
                        player13.ForeColor = System.Drawing.Color.White;
                        player14.ForeColor = System.Drawing.Color.White;
                        player15.ForeColor = System.Drawing.Color.White;
                        player16.ForeColor = System.Drawing.Color.White;
                        player17.ForeColor = System.Drawing.Color.White;
                        player18.ForeColor = System.Drawing.Color.White;
                        player19.ForeColor = System.Drawing.Color.White;
                        player20.ForeColor = System.Drawing.Color.White;
                        player21.ForeColor = System.Drawing.Color.White;
                        player22.ForeColor = System.Drawing.Color.Yellow;
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["Defensive"])//your specific tabname
                {
                    position.Text = teamView1.Items[intselectedindex].SubItems[3].Text;

                    if (intselectedindex == 0)
                    {
                        player23.ForeColor = System.Drawing.Color.Yellow;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 1)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.Yellow;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 2)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.Yellow;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 3)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.Yellow;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 4)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.Yellow;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 5)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.Yellow;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 6)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.Yellow;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 7)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.Yellow;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 8)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.Yellow;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 9)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.Yellow;
                        player33.ForeColor = System.Drawing.Color.White;
                    }
                    else if (intselectedindex == 10)
                    {
                        player23.ForeColor = System.Drawing.Color.White;
                        player24.ForeColor = System.Drawing.Color.White;
                        player25.ForeColor = System.Drawing.Color.White;
                        player26.ForeColor = System.Drawing.Color.White;
                        player27.ForeColor = System.Drawing.Color.White;
                        player28.ForeColor = System.Drawing.Color.White;
                        player29.ForeColor = System.Drawing.Color.White;
                        player30.ForeColor = System.Drawing.Color.White;
                        player31.ForeColor = System.Drawing.Color.White;
                        player32.ForeColor = System.Drawing.Color.White;
                        player33.ForeColor = System.Drawing.Color.Yellow;
                    }
                }
            }
        }

        private void numberFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            schemes.SelectedIndex = 0;
            for (int i = 2; i >= 0; i--)
            {
                TabPage t = tabControl1.TabPages[i];
                tabControl1.SelectedTab = t;
                leggiSchemi();
            }
            loadTactics(controller.leggiTattica(team.getId())[numberFormation.SelectedIndex]);

            List<TacticsFormation> tacticsFormation = controller.leggiFormazione(ushort.Parse(numberFormation.Text));
            LeggereFormazioni(tacticsFormation, teamView1);
        }

        //Accept (Save)
        private void button1_Click(object sender, EventArgs e)
        {
            //apply formation
            controller.changeFormation(ushort.Parse(numberFormation.Text), 0, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11,
            player13, player14, player15, player16, player17, player18, player19, player20, player21, player22,
            player24, player25, player26, player27, player28, player29, player30, player31, player32, player33, teamView1);

            controller.changeFormation(ushort.Parse(numberFormation.Text), 1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11,
            player13, player14, player15, player16, player17, player18, player19, player20, player21, player22,
            player24, player25, player26, player27, player28, player29, player30, player31, player32, player33, teamView1);

            controller.changeFormation(ushort.Parse(numberFormation.Text), 2, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11,
            player13, player14, player15, player16, player17, player18, player19, player20, player21, player22,
            player24, player25, player26, player27, player28, player29, player30, player31, player32, player33, teamView1);

            Tactics tac = new Tactics(team.getId(), ushort.Parse(numberFormation.Text));
            if (attackingArea.Checked == true)
                tac.setAttackingArea(1);
            else
                tac.setAttackingArea(0);
            tac.setAttackingNumbers(ushort.Parse(attackFewMedMany.Text));
            if (attackingStyle.Checked == true)
                tac.setAttackingStyle(1);
            else
                tac.setAttackingStyle(0);
            if (buildUp.Checked == true)
                tac.setBuildUp(1);
            else
                tac.setBuildUp(0);
            tac.setCompactness(ushort.Parse(compactness.Text));
            if (containmentArea.Checked == true)
                tac.setContainmentArea(1);
            else
                tac.setContainmentArea(0);
            tac.setDefendingNumbers(ushort.Parse(defenseFewMedMany.Text));
            tac.setDefensiveLine(ushort.Parse(defensiveLine.Text));
            if (defensiveStyle.Checked == true)
                tac.setDefensiveStyle(1);
            else
                tac.setDefensiveStyle(0);
            if (fuildFormation.Checked == true)
                tac.setFluidFormation(1);
            else
                tac.setFluidFormation(0);
            if (positioning.Checked == true)
                tac.setPositioning(1);
            else
                tac.setPositioning(0);
            if (pressuring.Checked == true)
                tac.setPressuring(1);
            else
                tac.setPressuring(0);
            tac.setSupportRange(ushort.Parse(supportRange.Text));

            controller.applyTacticsPersister(tac);
        }

        //accept
        private void button4_Click(object sender, EventArgs e)
        {
            controller.transferPlayerFormatione(teamView1, team.getId());
            controller.UpdateForm();

            this.Close();
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
            if (text.CompareTo(TEAM_A) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void teamView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            teamView1.DoDragDrop(TEAM_A, DragDropEffects.Move);
        }

        private void teamView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public void updateKickers()
        {
            capitain.Items.Clear();
            penaltyKT.Items.Clear();
            longFT.Items.Clear();
            leftCK.Items.Clear();
            shortFT.Items.Clear();
            rightCK.Items.Clear();
            for (int i = 0; i <= 10; i++)
            {
                capitain.Items.Add(teamView1.Items[i].SubItems[4].Text);
                penaltyKT.Items.Add(teamView1.Items[i].SubItems[4].Text);
                longFT.Items.Add(teamView1.Items[i].SubItems[4].Text);
                leftCK.Items.Add(teamView1.Items[i].SubItems[4].Text);
                shortFT.Items.Add(teamView1.Items[i].SubItems[4].Text);
                rightCK.Items.Add(teamView1.Items[i].SubItems[4].Text);

                if (teamView1.Items[i].SubItems[10].Text == "1")
                    rightCK.Text = teamView1.Items[i].SubItems[4].Text;

                if (teamView1.Items[i].SubItems[9].Text == "1")
                    penaltyKT.Text = teamView1.Items[i].SubItems[4].Text;

                if (teamView1.Items[i].SubItems[12].Text == "1")
                    longFT.Text = teamView1.Items[i].SubItems[4].Text;

                if (teamView1.Items[i].SubItems[8].Text == "1")
                    leftCK.Text = teamView1.Items[i].SubItems[4].Text;

                if (teamView1.Items[i].SubItems[11].Text == "1")
                    shortFT.Text = teamView1.Items[i].SubItems[4].Text;

                if (teamView1.Items[i].SubItems[7].Text == "1")
                    capitain.Text = teamView1.Items[i].SubItems[4].Text;
            }
        }

        private void teamView1_DragDrop(object sender, DragEventArgs e)
        {
            string text = (string)e.Data.GetData(TEAM_A.GetType());
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

                    string player1 = teamView1.Items[intselectedindex].SubItems[4].Text;
                    string player2 = teamView1.Items[dropIndex].SubItems[4].Text;
                    string number1 = teamView1.Items[intselectedindex].SubItems[5].Text;
                    string number2 = teamView1.Items[dropIndex].SubItems[5].Text;
                    string id1 = teamView1.Items[intselectedindex].SubItems[13].Text;
                    string id2 = teamView1.Items[dropIndex].SubItems[13].Text;
                    teamView1.Items[intselectedindex].SubItems[4].Text = player2;
                    teamView1.Items[dropIndex].SubItems[4].Text = player1;
                    teamView1.Items[intselectedindex].SubItems[5].Text = number2;
                    teamView1.Items[dropIndex].SubItems[5].Text = number1;
                    teamView1.Items[intselectedindex].SubItems[13].Text = id2;
                    teamView1.Items[dropIndex].SubItems[13].Text = id1;

                    updateKickers();
                }
            }
        }
        
    }
}

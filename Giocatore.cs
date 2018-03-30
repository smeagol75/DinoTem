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
using System.Diagnostics;
using Team_Editor_Manager_New_Generation.ui;
using Team_Editor_Manager_New_Generation.psd;

namespace DinoTem
{
    public partial class Giocatore : Form
    {
        private Controller controller;
        private Player temp;

        public Giocatore(Player temp, Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.temp = temp;
        }

        private void campi()
        {
            //pulire campi
            playerName.Text = "";
            shirtName.Text = "";
            playerId.Text = "";
            age.Text = "";
            weight.Text = "";
            height.Text = "";
            attack.Text = "";
            ballControll.Text = "";
            dribbling.Text = "";
            lowPass.Text = "";
            loftedPass.Text = "";
            finishing.Text = "";
            placeKick.Text = "";
            swerve.Text = "";
            header.Text = "";
            defense.Text = "";
            ballWinning.Text = "";
            kickingPower.Text = "";
            speed.Text = "";
            explosivePower.Text = "";
            BodyControl.Text = "";
            physical.Text = "";
            jump.Text = "";
            stamina.Text = "";
            goalkeeping.Text = "";
            cathing.Text = "";
            clearing.Text = "";
            reflexes.Text = "";
            coverage.Text = "";

            //Aggiungere campi
            playerType.Items.Add("Real");
            playerType.Items.Add("Fake");
            //Playing Style
            playingStyle.Items.Add("N/A");
            playingStyle.Items.Add("Goal Poacher");
            playingStyle.Items.Add("Dummy Runner");
            playingStyle.Items.Add("Fox in the Box");
            playingStyle.Items.Add("Prolific Winger");
            playingStyle.Items.Add("Classic No. 10");
            playingStyle.Items.Add("Hole Player");
            playingStyle.Items.Add("Box-To-Box");
            playingStyle.Items.Add("Anchor Man");
            playingStyle.Items.Add("The Destroyer");
            playingStyle.Items.Add("Extra Frontman");
            playingStyle.Items.Add("Offensive Full-Back");
            playingStyle.Items.Add("Defensive Full-Back");
            playingStyle.Items.Add("Target Man");
            playingStyle.Items.Add("Creative Playmaker");
            playingStyle.Items.Add("Build Up");
            playingStyle.Items.Add("Offensive Goalkeeper");
            playingStyle.Items.Add("Defensive Goalkeeper");
            //aggiungere posizioni preferita
            position.Items.Add("GK");
            position.Items.Add("CB");
            position.Items.Add("LB");
            position.Items.Add("RB");
            position.Items.Add("DMF");
            position.Items.Add("CMF");
            position.Items.Add("LMF");
            position.Items.Add("RMF");
            position.Items.Add("AMF");
            position.Items.Add("LWF");
            position.Items.Add("RWF");
            position.Items.Add("SS");
            position.Items.Add("CF");
            //piede preferito
            strongerFoot.Items.Add("Left");
            strongerFoot.Items.Add("Right");
            //forma
            form.Items.Add("1");
            form.Items.Add("2");
            form.Items.Add("3");
            form.Items.Add("4");
            form.Items.Add("5");
            form.Items.Add("6");
            form.Items.Add("7");
            form.Items.Add("8");
            //resistenza infortuni
            InjuryRes.Items.Add("1");
            InjuryRes.Items.Add("2");
            InjuryRes.Items.Add("3");
            InjuryRes.Items.Add("4");
            //we acc/freq
            weAcc.Items.Add("1");
            weAcc.Items.Add("2");
            weAcc.Items.Add("3");
            weAcc.Items.Add("4");
            weUsage.Items.Add("1");
            weUsage.Items.Add("2");
            weUsage.Items.Add("3");
            weUsage.Items.Add("4");
            //posizione
            GK.Items.Add("C");
            GK.Items.Add("B");
            GK.Items.Add("A");
            CB.Items.Add("C");
            CB.Items.Add("B");
            CB.Items.Add("A");
            LB.Items.Add("C");
            LB.Items.Add("B");
            LB.Items.Add("A");
            RB.Items.Add("C");
            RB.Items.Add("B");
            RB.Items.Add("A");
            DMF.Items.Add("C");
            DMF.Items.Add("B");
            DMF.Items.Add("A");
            CMF.Items.Add("C");
            CMF.Items.Add("B");
            CMF.Items.Add("A");
            LMF.Items.Add("C");
            LMF.Items.Add("B");
            LMF.Items.Add("A");
            AMF.Items.Add("C");
            AMF.Items.Add("B");
            AMF.Items.Add("A");
            RMF.Items.Add("C");
            RMF.Items.Add("B");
            RMF.Items.Add("A");
            LWF.Items.Add("C");
            LWF.Items.Add("B");
            LWF.Items.Add("A");
            RWF.Items.Add("C");
            RWF.Items.Add("B");
            RWF.Items.Add("A");
            SS.Items.Add("C");
            SS.Items.Add("B");
            SS.Items.Add("A");
            CF.Items.Add("C");
            CF.Items.Add("B");
            CF.Items.Add("A");
            //adjust stats
            adjust.Text = "1";
            //motion
            //free kick
            fkMotion.Items.Add("1");
            fkMotion.Items.Add("2");
            fkMotion.Items.Add("3");
            fkMotion.Items.Add("4");
            fkMotion.Items.Add("5");
            fkMotion.Items.Add("6");
            fkMotion.Items.Add("7");
            fkMotion.Items.Add("8");
            fkMotion.Items.Add("9");
            fkMotion.Items.Add("10");
            fkMotion.Items.Add("11");
            fkMotion.Items.Add("12");
            fkMotion.Items.Add("13");
            fkMotion.Items.Add("14");
            fkMotion.Items.Add("15");
            fkMotion.Items.Add("16");
            //drib hunch
            DribHunch.Items.Add("1");
            DribHunch.Items.Add("2");
            DribHunch.Items.Add("3");
            //drib arm move
            DribArmMove.Items.Add("1");
            DribArmMove.Items.Add("2");
            DribArmMove.Items.Add("3");
            DribArmMove.Items.Add("4");
            DribArmMove.Items.Add("5");
            DribArmMove.Items.Add("6");
            DribArmMove.Items.Add("7");
            DribArmMove.Items.Add("8");
            //run hunch
            RunHunch.Items.Add("1");
            RunHunch.Items.Add("2");
            RunHunch.Items.Add("3");
            //run arm move
            RunArmMove.Items.Add("1");
            RunArmMove.Items.Add("2");
            RunArmMove.Items.Add("3");
            RunArmMove.Items.Add("4");
            RunArmMove.Items.Add("5");
            RunArmMove.Items.Add("6");
            RunArmMove.Items.Add("7");
            RunArmMove.Items.Add("8");
            //penalty
            pkMotion.Items.Add("1");
            pkMotion.Items.Add("2");
            pkMotion.Items.Add("3");
            pkMotion.Items.Add("4");
            //corner
            ckMotion.Items.Add("1");
            ckMotion.Items.Add("2");
            ckMotion.Items.Add("3");
            ckMotion.Items.Add("4");
            ckMotion.Items.Add("5");
            ckMotion.Items.Add("6");
            //goal celebrate
            goalCeleb.Items.Add("0");
            goalCeleb.Items.Add("1");
            goalCeleb.Items.Add("2");
            goalCeleb.Items.Add("3");
            goalCeleb.Items.Add("4");
            goalCeleb.Items.Add("5");
            goalCeleb.Items.Add("6");
            goalCeleb.Items.Add("7");
            goalCeleb.Items.Add("8");
            goalCeleb.Items.Add("9");
            goalCeleb.Items.Add("10");
            goalCeleb.Items.Add("11");
            goalCeleb.Items.Add("12");
            goalCeleb.Items.Add("13");
            goalCeleb.Items.Add("14");
            goalCeleb.Items.Add("15");
            goalCeleb.Items.Add("16");
            goalCeleb.Items.Add("17");
            goalCeleb.Items.Add("18");
            goalCeleb.Items.Add("19");
            goalCeleb.Items.Add("20");
            goalCeleb.Items.Add("21");
            goalCeleb.Items.Add("22");
            goalCeleb.Items.Add("23");
            goalCeleb.Items.Add("24");
            goalCeleb.Items.Add("25");
            goalCeleb.Items.Add("26");
            goalCeleb.Items.Add("27");
            goalCeleb.Items.Add("28");
            goalCeleb.Items.Add("29");
            goalCeleb.Items.Add("30");
            goalCeleb.Items.Add("31");
            goalCeleb.Items.Add("32");
            goalCeleb.Items.Add("33");
            goalCeleb.Items.Add("34");
            goalCeleb.Items.Add("35");
            goalCeleb.Items.Add("36");
            goalCeleb.Items.Add("37");
            goalCeleb.Items.Add("38");
            goalCeleb.Items.Add("39");
            goalCeleb.Items.Add("40");
            goalCeleb.Items.Add("41");
            goalCeleb.Items.Add("42");
            goalCeleb.Items.Add("43");
            goalCeleb.Items.Add("44");
            goalCeleb.Items.Add("45");
            goalCeleb.Items.Add("46");
            goalCeleb.Items.Add("47");
            goalCeleb.Items.Add("48");
            goalCeleb.Items.Add("49");
            goalCeleb.Items.Add("50");
            goalCeleb.Items.Add("51");
            goalCeleb.Items.Add("52");
            goalCeleb.Items.Add("53");
            goalCeleb.Items.Add("54");
            goalCeleb.Items.Add("55");
            goalCeleb.Items.Add("56");
            goalCeleb.Items.Add("57");
            goalCeleb.Items.Add("58");
            goalCeleb.Items.Add("59");
            goalCeleb.Items.Add("60");
            goalCeleb.Items.Add("61");
            goalCeleb.Items.Add("62");
            goalCeleb.Items.Add("63");
            goalCeleb.Items.Add("64");
            goalCeleb.Items.Add("65");
            goalCeleb.Items.Add("66");
            goalCeleb.Items.Add("67");
            goalCeleb.Items.Add("68");
            goalCeleb.Items.Add("69");
            goalCeleb.Items.Add("70");
            goalCeleb.Items.Add("71");
            goalCeleb.Items.Add("72");
            goalCeleb.Items.Add("73");
            goalCeleb.Items.Add("74");
            goalCeleb.Items.Add("75");
            goalCeleb.Items.Add("76");
            goalCeleb.Items.Add("77");
            goalCeleb.Items.Add("78");
            goalCeleb.Items.Add("79");
            goalCeleb.Items.Add("80");
            goalCeleb.Items.Add("81");
            goalCeleb.Items.Add("82");
            goalCeleb.Items.Add("83");
            goalCeleb.Items.Add("84");
            goalCeleb.Items.Add("85");
            goalCeleb.Items.Add("86");
            goalCeleb.Items.Add("87");
            goalCeleb.Items.Add("88");
            goalCeleb.Items.Add("89");
            goalCeleb.Items.Add("90");
            goalCeleb.Items.Add("91");
            goalCeleb.Items.Add("92");
            goalCeleb.Items.Add("93");
            goalCeleb.Items.Add("94");
            goalCeleb.Items.Add("95");
            goalCeleb.Items.Add("96");
            goalCeleb.Items.Add("97");
            goalCeleb.Items.Add("98");
            goalCeleb.Items.Add("99");
            goalCeleb.Items.Add("100");
            goalCeleb.Items.Add("101");
            goalCeleb.Items.Add("102");
            goalCeleb.Items.Add("103");
            goalCeleb.Items.Add("104");
            goalCeleb.Items.Add("105");
            goalCeleb.Items.Add("106");
            goalCeleb.Items.Add("107");
            goalCeleb.Items.Add("108");
            goalCeleb.Items.Add("109");
            goalCeleb.Items.Add("110");
            goalCeleb.Items.Add("111");
            goalCeleb.Items.Add("112");
            goalCeleb.Items.Add("113");
            goalCeleb.Items.Add("114");
            goalCeleb.Items.Add("115");
            goalCeleb.Items.Add("116");
            goalCeleb.Items.Add("117");
            goalCeleb.Items.Add("118");
            goalCeleb.Items.Add("119");
            goalCeleb.Items.Add("120");
            goalCeleb.Items.Add("121");
            goalCeleb.Items.Add("122");

            nationality.Items.Clear();
            sndNationality.Items.Clear();
            foreach (string x in Form1._Form1.teamCountry.Items)
            {
                nationality.Items.Add(x);
                sndNationality.Items.Add(x);
            }
            Country nul = new Country(99999);
            nul.setName("No National");
            sndNationality.Items.Add(nul);

            //Youth Club ID
            youthClub.Items.Clear();
            foreach (string x in Form1._Form1.teamBox1.Items)
            {
                youthClub.Items.Add(x);
            }
            Team nullo = new Club(99999);
            nullo.setEnglish("No Team");
            youthClub.Items.Add(nullo);

            //Glove List
            glovesRelink.Items.Clear();
            foreach (string x in Form1._Form1.glovesBox.Items)
            {
                glovesRelink.Items.Add(x);
            }
            Glove nullo2 = new Glove(9999);
            nullo2.setName("No Glove");
            glovesRelink.Items.Add(nullo2);

            //Boot List
            bootsRelink.Items.Clear();
            foreach (string x in Form1._Form1.bootsBox.Items)
            {
                bootsRelink.Items.Add(x);
            }
            Boot nullo3 = new Boot(9999);
            nullo3.setName("No Boot");
            bootsRelink.Items.Add(nullo3);
        }

        //non far inserire lettere
        private void Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) & (!char.IsNumber(e.KeyChar.ToString(), 0)))
                e.Handled = true;
        }

        //LOAD
        private void Giocatore_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //caricare + pulire campi
            campi();

            this.Text = "Player: " + temp.getName();
            playerName.Text = temp.getName();
            japaneseName.Text = temp.getJapanese();
            shirtName.Text = temp.getShirtName();
            playerId.Text = temp.getId().ToString();
            playerType.Text = temp.getStringFake();
            age.Text = temp.getAge().ToString();
            weight.Text = temp.getWeight().ToString();
            height.Text = temp.getHeight().ToString();
            strongerFoot.Text = temp.getStringStrongerFoot();
            playingStyle.Text = temp.getStringPlayingStyle();

            if (playerType.Text == "Fake")
                fakeButton.Enabled = true;
            else
                fakeButton.Enabled = false;

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
            BodyControl.Text = temp.getBodyControl().ToString();
            physical.Text = temp.getPhysical().ToString();
            jump.Text = temp.getJump().ToString();
            stamina.Text = temp.getStamina().ToString();
            goalkeeping.Text = temp.getGoalkeeping().ToString();
            cathing.Text = temp.getCathing().ToString();
            clearing.Text = temp.getClearing().ToString();
            reflexes.Text = temp.getReflexes().ToString();
            coverage.Text = temp.getCoverage().ToString();

            form.Text = temp.getForm().ToString();
            weAcc.Text = temp.getWeakFootAcc().ToString();
            weUsage.Text = temp.getWcUsage().ToString();
            InjuryRes.Text = temp.getInjuryRes().ToString();

            if (temp.getHiddenPlayer() == 1)
                hiddenPlayer.Checked = true;
            else
                hiddenPlayer.Checked = false;
            if (temp.getLegendGoldenBall() == 1)
                wonGoldenBall.Checked = true;
            else
                wonGoldenBall.Checked = false;
            DribHunch.Text = temp.getDriblingH().ToString();
            DribArmMove.Text = temp.getDriblingArm().ToString();
            RunHunch.Text = temp.getRunningH().ToString();
            RunArmMove.Text = temp.getRunningArm().ToString();
            ckMotion.Text = temp.getCornerKick().ToString();
            fkMotion.Text = temp.getFreeKick().ToString();
            pkMotion.Text = temp.getPenaltyKick().ToString();
            goalCeleb.Text = temp.getGoalCelebrate().ToString();

            position.Text = temp.getStringPosition();
            GK.Text = temp.getStringGK();
            CB.Text = temp.getStringGB();
            LB.Text = temp.getStringLB();
            RB.Text = temp.getStringRB();
            DMF.Text = temp.getStringDMF();
            CMF.Text = temp.getStringCMF();
            LMF.Text = temp.getStringLMF();
            AMF.Text = temp.getStringAMF();
            RMF.Text = temp.getStringRMF();
            LWF.Text = temp.getStringLWF();
            RWF.Text = temp.getStringRWF();
            SS.Text = temp.getStringSS();
            CF.Text = temp.getStringCF();

            //skills
            if (temp.getFightingSpirit() == 1)
                fightingSpirit.Checked = true;
            else
                fightingSpirit.Checked = false;

            if (temp.getAcrobatingClear() == 1)
                acrobaticClear.Checked = true;
            else
                acrobaticClear.Checked = false;

            if (temp.getKnucleShot() == 1)
                knucleShot.Checked = true;
            else
                knucleShot.Checked = false;

            if (temp.getFirstTimeShot() == 1)
                firstTimeShot.Checked = true;
            else
                firstTimeShot.Checked = false;

            if (temp.getLongThrow() == 1)
                longThrow.Checked = true;
            else
                longThrow.Checked = false;

            if (temp.getManMarking() == 1)
                manMarking.Checked = true;
            else
                manMarking.Checked = false;

            if (temp.getOutsideCurler() == 1)
                outsideCurler.Checked = true;
            else
                outsideCurler.Checked = false;

            if (temp.getMarseilleTurn() == 1)
                marseilleTurn.Checked = true;
            else
                marseilleTurn.Checked = false;

            if (temp.getSchotMove() == 1)
                scothMove.Checked = true;
            else
                scothMove.Checked = false;

            if (temp.getGkLong() == 1)
                gkLongThrow.Checked = true;
            else
                gkLongThrow.Checked = false;

            if (temp.getCutBehind() == 1)
                cutBehindTurn.Checked = true;
            else
                cutBehindTurn.Checked = false;

            if (temp.getScissorFeint() == 1)
                scissorsFeint.Checked = true;
            else
                scissorsFeint.Checked = false;

            if (temp.getLowLoftedPass() == 1)
                lowLoftedPass.Checked = true;
            else
                lowLoftedPass.Checked = false;

            if (temp.getOneTouchPass() == 1)
                oneTouchPass.Checked = true;
            else
                oneTouchPass.Checked = false;

            if (temp.getWeightnessPass() == 1)
                weightedPass.Checked = true;
            else
                weightedPass.Checked = false;

            if (temp.getAcrobatingFinishing() == 1)
                acrobaticFinishing.Checked = true;
            else
                acrobaticFinishing.Checked = false;

            if (temp.getPinCrossing() == 1)
                pinpointCrossing.Checked = true;
            else
                pinpointCrossing.Checked = false;

            if (temp.getLowPuntTrajectory() == 1)
                lowPuntTrajectory.Checked = true;
            else
                lowPuntTrajectory.Checked = false;

            if (temp.getLongRange() == 1)
                longRangeDrive.Checked = true;
            else
                longRangeDrive.Checked = false;

            if (temp.getFlipFlap() == 1)
                flipFlap.Checked = true;
            else
                flipFlap.Checked = false;

            if (temp.getRabona() == 1)
                rabona.Checked = true;
            else
                rabona.Checked = false;

            if (temp.getMalicia() == 1)
                malicia.Checked = true;
            else
                malicia.Checked = false;

            if (temp.getSombrero() == 1)
                sombrero.Checked = true;
            else
                sombrero.Checked = false;

            if (temp.getHeading() == 1)
                heading.Checked = true;
            else
                heading.Checked = false;

            if (temp.getHellTick() == 1)
                hellTrick.Checked = true;
            else
                hellTrick.Checked = false;

            if (temp.getTrackBack() == 1)
                trackBack.Checked = true;
            else
                trackBack.Checked = false;

            if (temp.getSuperSub() == 1)
                superSub.Checked = true;
            else
                superSub.Checked = false;

            if (temp.getCaptaincy() == 1)
                captaincy.Checked = true;
            else
                captaincy.Checked = false;

            if (temp.getComTrickster() == 1)
                trickster.Checked = true;
            else
                trickster.Checked = false;

            if (temp.getComMazingRun() == 1)
                mazingRun.Checked = true;
            else
                mazingRun.Checked = false;

            if (temp.getComBallExpert() == 1)
                longBallExpert.Checked = true;
            else
                longBallExpert.Checked = false;

            if (temp.getComLongRanger() == 1)
                longRanger.Checked = true;
            else
                longRanger.Checked = false;

            if (temp.getComIncisiveRun() == 1)
                incisiveRun.Checked = true;
            else
                incisiveRun.Checked = false;

            if (temp.getSpeedingBullet() == 1)
                speedingBullet.Checked = true;
            else
                speedingBullet.Checked = false;

            if (temp.getEarlyCross() == 1)
                earlyCross.Checked = true;
            else
                earlyCross.Checked = false;

            int skin = controller.getSkinColour(temp.getId());
            if (skin > 0) {
                skinColour.Value = skin;
                skin1.Visible = true;
            }
            else
            {
                skinColour.Visible = false;
                skinNull.Visible = true;
            }

            starIndicator.Value = temp.getStarPlayerIndicator();

            nationality.SelectedIndex = controller.findCountry(temp.getNational());
            sndNationality.SelectedIndex = controller.findCountry(temp.getNational2());

            youthClub.SelectedIndex = controller.findTeam(temp.getYouthPlayerId());

            glovesRelink.SelectedIndex = controller.findGloveList(temp.getId());
            if (controller.leggiGuantiLista(temp.getId()) == null)
                addGloveRelink.Visible = true;
            else
                addGloveRelink.Visible = false;
            bootsRelink.SelectedIndex = controller.findBootList(temp.getId());
            if (controller.leggiScarpeLista(temp.getId()) == null)
                addBootRelink.Visible = true;
            else
                addBootRelink.Visible = false;
        }

        //ADJUST STATS
        private void adjust_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(adjust.Text) < 75)
                    this.adjust.BackColor = Color.White;
                else if (int.Parse(adjust.Text) >= 75 & int.Parse(adjust.Text) < 80)
                    this.adjust.BackColor = Color.GreenYellow;
                else if (int.Parse(adjust.Text) >= 80 & int.Parse(adjust.Text) < 90)
                    this.adjust.BackColor = Color.Yellow;
                else if (int.Parse(adjust.Text) >= 90 & int.Parse(adjust.Text) < 95)
                    this.adjust.BackColor = Color.Orange;
                else if (int.Parse(adjust.Text) >= 95)
                    this.adjust.BackColor = Color.Red;
            }
            catch
            {
                this.adjust.BackColor = Color.White;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            attack.Text = "40";
            ballControll.Text = "40";
            dribbling.Text = "40";
            lowPass.Text = "40";
            loftedPass.Text = "40";
            finishing.Text = "40";
            placeKick.Text = "40";
            swerve.Text = "40";
            header.Text = "40";
            defense.Text = "40";
            ballWinning.Text = "40";
            kickingPower.Text = "40";
            speed.Text = "40";
            explosivePower.Text = "40";
            BodyControl.Text = "40";
            physical.Text = "40";
            jump.Text = "40";
            stamina.Text = "40";
            goalkeeping.Text = "40";
            cathing.Text = "40";
            clearing.Text = "40";
            reflexes.Text = "40";
            coverage.Text = "40";
        }

        public void checkField()
        {
            if (int.Parse(attack.Text) < 40)
                attack.Text = "40";
            if (int.Parse(ballControll.Text) < 40)
                ballControll.Text = "40";
            if (int.Parse(dribbling.Text) < 40)
                dribbling.Text = "40";
            if (int.Parse(lowPass.Text) < 40)
                lowPass.Text = "40";
            if (int.Parse(loftedPass.Text) < 40)
                loftedPass.Text = "40";
            if (int.Parse(finishing.Text) < 40)
                finishing.Text = "40";
            if (int.Parse(placeKick.Text) < 40)
                placeKick.Text = "40";
            if (int.Parse(swerve.Text) < 40)
                swerve.Text = "40";
            if (int.Parse(header.Text) < 40)
                header.Text = "40";
            if (int.Parse(defense.Text) < 40)
                defense.Text = "40";
            if (int.Parse(ballWinning.Text) < 40)
                ballWinning.Text = "40";
            if (int.Parse(kickingPower.Text) < 40)
                kickingPower.Text = "40";
            if (int.Parse(speed.Text) < 40)
                speed.Text = "40";
            if (int.Parse(explosivePower.Text) < 40)
                explosivePower.Text = "40";
            if (int.Parse(BodyControl.Text) < 40)
                BodyControl.Text = "40";
            if (int.Parse(physical.Text) < 40)
                physical.Text = "40";
            if (int.Parse(jump.Text) < 40)
                jump.Text = "40";
            if (int.Parse(stamina.Text) < 40)
                stamina.Text = "40";
            if (int.Parse(goalkeeping.Text) < 40)
                goalkeeping.Text = "40";
            if (int.Parse(cathing.Text) < 40)
                cathing.Text = "40";
            if (int.Parse(clearing.Text) < 40)
                clearing.Text = "40";
            if (int.Parse(reflexes.Text) < 40)
                reflexes.Text = "40";
            if (int.Parse(coverage.Text) < 40)
                coverage.Text = "40";

            if (int.Parse(attack.Text) > 99)
                attack.Text = "99";
            if (int.Parse(ballControll.Text) > 99)
                ballControll.Text = "99";
            if (int.Parse(dribbling.Text) > 99)
                dribbling.Text = "99";
            if (int.Parse(lowPass.Text) > 99)
                lowPass.Text = "99";
            if (int.Parse(loftedPass.Text) > 99)
                loftedPass.Text = "99";
            if (int.Parse(finishing.Text) > 99)
                finishing.Text = "99";
            if (int.Parse(placeKick.Text) > 99)
                placeKick.Text = "99";
            if (int.Parse(swerve.Text) > 99)
                swerve.Text = "99";
            if (int.Parse(header.Text) > 99)
                header.Text = "99";
            if (int.Parse(defense.Text) > 99)
                defense.Text = "99";
            if (int.Parse(ballWinning.Text) > 99)
                ballWinning.Text = "99";
            if (int.Parse(kickingPower.Text) > 99)
                kickingPower.Text = "99";
            if (int.Parse(speed.Text) > 99)
                speed.Text = "99";
            if (int.Parse(explosivePower.Text) > 99)
                explosivePower.Text = "99";
            if (int.Parse(BodyControl.Text) > 99)
                BodyControl.Text = "99";
            if (int.Parse(physical.Text) > 99)
                physical.Text = "99";
            if (int.Parse(jump.Text) > 99)
                jump.Text = "99";
            if (int.Parse(stamina.Text) > 99)
                stamina.Text = "99";
            if (int.Parse(goalkeeping.Text) > 99)
                goalkeeping.Text = "99";
            if (int.Parse(cathing.Text) > 99)
                cathing.Text = "99";
            if (int.Parse(clearing.Text) > 99)
                clearing.Text = "99";
            if (int.Parse(reflexes.Text) > 99)
                reflexes.Text = "99";
            if (int.Parse(coverage.Text) > 99)
                coverage.Text = "99";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //attacco
            attack.Text = (int.Parse(attack.Text) + int.Parse(adjust.Text)).ToString();
            //ball controll
            ballControll.Text = (int.Parse(ballControll.Text) + int.Parse(adjust.Text)).ToString();
            //dribbling
            dribbling.Text = (int.Parse(dribbling.Text) + int.Parse(adjust.Text)).ToString();
            //low pass
            lowPass.Text = (int.Parse(lowPass.Text) + int.Parse(adjust.Text)).ToString();
            //lofted pass
            loftedPass.Text = (int.Parse(loftedPass.Text) + int.Parse(adjust.Text)).ToString();
            //finishing
            finishing.Text = (int.Parse(finishing.Text) + int.Parse(adjust.Text)).ToString();
            //place kicking
            placeKick.Text = (int.Parse(placeKick.Text) + int.Parse(adjust.Text)).ToString();
            //swerve
            swerve.Text = (int.Parse(swerve.Text) + int.Parse(adjust.Text)).ToString();
            //header
            header.Text = (int.Parse(header.Text) + int.Parse(adjust.Text)).ToString();
            //defense
            defense.Text = (int.Parse(defense.Text) + int.Parse(adjust.Text)).ToString();
            //ball winning
            ballWinning.Text = (int.Parse(ballWinning.Text) + int.Parse(adjust.Text)).ToString();
            //kicking power
            kickingPower.Text = (int.Parse(kickingPower.Text) + int.Parse(adjust.Text)).ToString();
            //speed
            speed.Text = (int.Parse(speed.Text) + int.Parse(adjust.Text)).ToString();
            //explosive power
            explosivePower.Text = (int.Parse(explosivePower.Text) + int.Parse(adjust.Text)).ToString();
            //body controll
            BodyControl.Text = (int.Parse(BodyControl.Text) + int.Parse(adjust.Text)).ToString();
            //physical
            physical.Text = (int.Parse(physical.Text) + int.Parse(adjust.Text)).ToString();
            //jump
            jump.Text = (int.Parse(jump.Text) + int.Parse(adjust.Text)).ToString();
            //stamina
            stamina.Text = (int.Parse(stamina.Text) + int.Parse(adjust.Text)).ToString();
            //goalkeeping
            goalkeeping.Text = (int.Parse(goalkeeping.Text) + int.Parse(adjust.Text)).ToString();
            //cathing
            cathing.Text = (int.Parse(cathing.Text) + int.Parse(adjust.Text)).ToString();
            //clearing
            clearing.Text = (int.Parse(clearing.Text) + int.Parse(adjust.Text)).ToString();
            //reflexes
            reflexes.Text = (int.Parse(reflexes.Text) + int.Parse(adjust.Text)).ToString();
            //coverage
            coverage.Text = (int.Parse(coverage.Text) + int.Parse(adjust.Text)).ToString();

            checkField();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //attacco
            attack.Text = (int.Parse(attack.Text) - int.Parse(adjust.Text)).ToString();
            //ball controll
            ballControll.Text = (int.Parse(ballControll.Text) - int.Parse(adjust.Text)).ToString();
            //dribbling
            dribbling.Text = (int.Parse(dribbling.Text) - int.Parse(adjust.Text)).ToString();
            //low pass
            lowPass.Text = (int.Parse(lowPass.Text) - int.Parse(adjust.Text)).ToString();
            //lofted pass
            loftedPass.Text = (int.Parse(loftedPass.Text) - int.Parse(adjust.Text)).ToString();
            //finishing
            finishing.Text = (int.Parse(finishing.Text) - int.Parse(adjust.Text)).ToString();
            //place kicking
            placeKick.Text = (int.Parse(placeKick.Text) - int.Parse(adjust.Text)).ToString();
            //swerve
            swerve.Text = (int.Parse(swerve.Text) - int.Parse(adjust.Text)).ToString();
            //header
            header.Text = (int.Parse(header.Text) - int.Parse(adjust.Text)).ToString();
            //defense
            defense.Text = (int.Parse(defense.Text) - int.Parse(adjust.Text)).ToString();
            //ball winning
            ballWinning.Text = (int.Parse(ballWinning.Text) - int.Parse(adjust.Text)).ToString();
            //kicking power
            kickingPower.Text = (int.Parse(kickingPower.Text) - int.Parse(adjust.Text)).ToString();
            //speed
            speed.Text = (int.Parse(speed.Text) - int.Parse(adjust.Text)).ToString();
            //explosive power
            explosivePower.Text = (int.Parse(explosivePower.Text) - int.Parse(adjust.Text)).ToString();
            //body controll
            BodyControl.Text = (int.Parse(BodyControl.Text) - int.Parse(adjust.Text)).ToString();
            //physical
            physical.Text = (int.Parse(physical.Text) - int.Parse(adjust.Text)).ToString();
            //jump
            jump.Text = (int.Parse(jump.Text) - int.Parse(adjust.Text)).ToString();
            //stamina
            stamina.Text = (int.Parse(stamina.Text) - int.Parse(adjust.Text)).ToString();
            //goalkeeping
            goalkeeping.Text = (int.Parse(goalkeeping.Text) - int.Parse(adjust.Text)).ToString();
            //cathing
            cathing.Text = (int.Parse(cathing.Text) - int.Parse(adjust.Text)).ToString();
            //clearing
            clearing.Text = (int.Parse(clearing.Text) - int.Parse(adjust.Text)).ToString();
            //reflexes
            reflexes.Text = (int.Parse(reflexes.Text) - int.Parse(adjust.Text)).ToString();
            //coverage
            coverage.Text = (int.Parse(coverage.Text) - int.Parse(adjust.Text)).ToString();

            checkField();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //attacco
            decimal primo = Math.Round((decimal)((int.Parse(attack.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo1 = (decimal)int.Parse(attack.Text) + primo;
            attack.Text = primo1.ToString();
            //ball controll
            decimal primo2 = Math.Round((decimal)((int.Parse(ballControll.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo3 = (decimal)int.Parse(ballControll.Text) + primo2;
            ballControll.Text = primo3.ToString();
            //dribbling
            decimal primo4 = Math.Round((decimal)((int.Parse(dribbling.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo5 = (decimal)int.Parse(dribbling.Text) + primo4;
            dribbling.Text = primo5.ToString();
            //low pass
            decimal primo6 = Math.Round((decimal)((int.Parse(lowPass.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo7 = (decimal)int.Parse(lowPass.Text) + primo6;
            lowPass.Text = primo7.ToString();
            //lofted pass
            decimal primo8 = Math.Round((decimal)((int.Parse(loftedPass.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo9 = (decimal)int.Parse(loftedPass.Text) + primo8;
            loftedPass.Text = primo9.ToString();
            //finishing
            decimal primo10 = Math.Round((decimal)((int.Parse(finishing.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo11 = (decimal)int.Parse(finishing.Text) + primo10;
            finishing.Text = primo11.ToString();
            //place kicking
            decimal primo12 = Math.Round((decimal)((int.Parse(placeKick.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo13 = (decimal)int.Parse(placeKick.Text) + primo12;
            placeKick.Text = primo13.ToString();
            //swerve
            decimal primo14 = Math.Round((decimal)((int.Parse(swerve.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo15 = (decimal)int.Parse(swerve.Text) + primo14;
            swerve.Text = primo15.ToString();
            //header
            decimal primo16 = Math.Round((decimal)((int.Parse(header.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo17 = (decimal)int.Parse(header.Text) + primo16;
            header.Text = primo17.ToString();
            //defense
            decimal primo18 = Math.Round((decimal)((int.Parse(defense.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo19 = (decimal)int.Parse(defense.Text) + primo18;
            defense.Text = primo19.ToString();
            //ball winning
            decimal primo20 = Math.Round((decimal)((int.Parse(ballWinning.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo21 = (decimal)int.Parse(ballWinning.Text) + primo20;
            ballWinning.Text = primo21.ToString();
            //kicking power
            decimal primo22 = Math.Round((decimal)((int.Parse(kickingPower.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo23 = (decimal)int.Parse(kickingPower.Text) + primo22;
            kickingPower.Text = primo23.ToString();
            //speed
            decimal primo24 = Math.Round((decimal)((int.Parse(speed.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo25 = (decimal)int.Parse(speed.Text) + primo24;
            speed.Text = primo25.ToString();
            //explosive power
            decimal primo26 = Math.Round((decimal)((int.Parse(explosivePower.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo27 = (decimal)int.Parse(explosivePower.Text) + primo26;
            explosivePower.Text = primo27.ToString();
            //body controll
            decimal primo28 = Math.Round((decimal)((int.Parse(BodyControl.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo29 = (decimal)int.Parse(BodyControl.Text) + primo28;
            BodyControl.Text = primo29.ToString();
            //physical
            decimal primo44 = Math.Round((decimal)((int.Parse(physical.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo45 = (decimal)int.Parse(physical.Text) + primo44;
            physical.Text = primo45.ToString();
            //jump
            decimal primo30 = Math.Round((decimal)((int.Parse(jump.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo31 = (decimal)int.Parse(jump.Text) + primo30;
            jump.Text = primo31.ToString();
            //stamina
            decimal primo32 = Math.Round((decimal)((int.Parse(stamina.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo33 = (decimal)int.Parse(stamina.Text) + primo32;
            stamina.Text = primo33.ToString();
            //GK
            decimal primo34 = Math.Round((decimal)((int.Parse(goalkeeping.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo35 = (decimal)int.Parse(goalkeeping.Text) + primo34;
            goalkeeping.Text = primo35.ToString();
            //catching
            decimal primo36 = Math.Round((decimal)((int.Parse(cathing.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo37 = (decimal)int.Parse(cathing.Text) + primo36;
            cathing.Text = primo37.ToString();
            //clearing
            decimal primo38 = Math.Round((decimal)((int.Parse(clearing.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo39 = (decimal)int.Parse(clearing.Text) + primo38;
            clearing.Text = primo39.ToString();
            //reflex
            decimal primo40 = Math.Round((decimal)((int.Parse(reflexes.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo41 = (decimal)int.Parse(reflexes.Text) + primo40;
            reflexes.Text = primo41.ToString();
            //coverage
            decimal primo42 = Math.Round((decimal)((int.Parse(coverage.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo43 = (decimal)int.Parse(coverage.Text) + primo42;
            coverage.Text = primo43.ToString();

            checkField();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //attacco
            decimal primo = Math.Round((decimal)((int.Parse(attack.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo1 = (decimal)int.Parse(attack.Text) - primo;
            attack.Text = primo1.ToString();
            //ball controll
            decimal primo2 = Math.Round((decimal)((int.Parse(ballControll.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo3 = (decimal)int.Parse(ballControll.Text) - primo2;
            ballControll.Text = primo3.ToString();
            //dribbling
            decimal primo4 = Math.Round((decimal)((int.Parse(dribbling.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo5 = (decimal)int.Parse(dribbling.Text) - primo4;
            dribbling.Text = primo5.ToString();
            //low pass
            decimal primo6 = Math.Round((decimal)((int.Parse(lowPass.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo7 = (decimal)int.Parse(lowPass.Text) - primo6;
            lowPass.Text = primo7.ToString();
            //lofted pass
            decimal primo8 = Math.Round((decimal)((int.Parse(loftedPass.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo9 = (decimal)int.Parse(loftedPass.Text) - primo8;
            loftedPass.Text = primo9.ToString();
            //finishing
            decimal primo10 = Math.Round((decimal)((int.Parse(finishing.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo11 = (decimal)int.Parse(finishing.Text) - primo10;
            finishing.Text = primo11.ToString();
            //place kicking
            decimal primo12 = Math.Round((decimal)((int.Parse(placeKick.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo13 = (decimal)int.Parse(placeKick.Text) - primo12;
            placeKick.Text = primo13.ToString();
            //swerve
            decimal primo14 = Math.Round((decimal)((int.Parse(swerve.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo15 = (decimal)int.Parse(swerve.Text) - primo14;
            swerve.Text = primo15.ToString();
            //header
            decimal primo16 = Math.Round((decimal)((int.Parse(header.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo17 = (decimal)int.Parse(header.Text) - primo16;
            header.Text = primo17.ToString();
            //defense
            decimal primo18 = Math.Round((decimal)((int.Parse(defense.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo19 = (decimal)int.Parse(defense.Text) - primo18;
            defense.Text = primo19.ToString();
            //ball winning
            decimal primo20 = Math.Round((decimal)((int.Parse(ballWinning.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo21 = (decimal)int.Parse(ballWinning.Text) - primo20;
            ballWinning.Text = primo21.ToString();
            //kicking power
            decimal primo22 = Math.Round((decimal)((int.Parse(kickingPower.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo23 = (decimal)int.Parse(kickingPower.Text) - primo22;
            kickingPower.Text = primo23.ToString();
            //speed
            decimal primo24 = Math.Round((decimal)((int.Parse(speed.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo25 = (decimal)int.Parse(speed.Text) - primo24;
            speed.Text = primo25.ToString();
            //explosive power
            decimal primo26 = Math.Round((decimal)((int.Parse(explosivePower.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo27 = (decimal)int.Parse(explosivePower.Text) - primo26;
            explosivePower.Text = primo27.ToString();
            //body controll
            decimal primo28 = Math.Round((decimal)((int.Parse(BodyControl.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo29 = (decimal)int.Parse(BodyControl.Text) - primo28;
            BodyControl.Text = primo29.ToString();
            //physical
            decimal primo44 = Math.Round((decimal)((int.Parse(physical.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo45 = (decimal)int.Parse(physical.Text) - primo44;
            physical.Text = primo45.ToString();
            //jump
            decimal primo30 = Math.Round((decimal)((int.Parse(jump.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo31 = (decimal)int.Parse(jump.Text) - primo30;
            jump.Text = primo31.ToString();
            //stamina
            decimal primo32 = Math.Round((decimal)((int.Parse(stamina.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo33 = (decimal)int.Parse(stamina.Text) - primo32;
            stamina.Text = primo33.ToString();
            //GK
            decimal primo34 = Math.Round((decimal)((int.Parse(goalkeeping.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo35 = (decimal)int.Parse(goalkeeping.Text) - primo34;
            goalkeeping.Text = primo35.ToString();
            //catching
            decimal primo36 = Math.Round((decimal)((int.Parse(cathing.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo37 = (decimal)int.Parse(cathing.Text) - primo36;
            cathing.Text = primo37.ToString();
            //clearing
            decimal primo38 = Math.Round((decimal)((int.Parse(clearing.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo39 = (decimal)int.Parse(clearing.Text) - primo38;
            clearing.Text = primo39.ToString();
            //reflex
            decimal primo40 = Math.Round((decimal)((int.Parse(reflexes.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo41 = (decimal)int.Parse(reflexes.Text) - primo40;
            reflexes.Text = primo41.ToString();
            //coverage
            decimal primo42 = Math.Round((decimal)((int.Parse(coverage.Text) * int.Parse(adjust.Text)) / 100));
            decimal primo43 = (decimal)int.Parse(coverage.Text) - primo42;
            coverage.Text = primo43.ToString();

            checkField();
        }

        //Tasto Cancel
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //cambio colore star Indicator
        private void starIndicator_ValueChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorNumericUpDown(starIndicator);
        }

        //cambio colore abilità
        private void attack_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(attack);
        }

        private void ballControll_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(ballControll);
        }

        private void dribbling_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(dribbling);
        }

        private void lowPass_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(lowPass);
        }

        private void loftedPass_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(loftedPass);
        }

        private void finishing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(finishing);
        }

        private void placeKick_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(placeKick);
        }

        private void swerve_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(swerve);
        }

        private void header_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(header);
        }

        private void defense_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(defense);
        }

        private void ballWinning_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(ballWinning);
        }

        private void kickingPower_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(kickingPower);
        }

        private void speed_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(speed);
        }

        private void explosivePower_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(explosivePower);
        }

        private void BodyControll_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(BodyControl);
        }

        private void physical_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(physical);
        }

        private void jump_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(jump);
        }

        private void stamina_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(stamina);
        }

        private void goalkeeping_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(goalkeeping);
        }

        private void cathing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(cathing);
        }

        private void clearing_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(clearing);
        }

        private void reflexes_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(reflexes);
        }

        private void coverage_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.changeColorTextBox(coverage);
        }

        //search on PSD
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://pesstatsdatabase.com/PSD/Search.php?q=" + shirtName.Text + "&Submit=Search");
        }

        //Paste PSD Stats
        private void psdPaste_Click(object sender, EventArgs e)
        {
            Psd temp = new Psd();
            temp.generatePSD(playerName, shirtName, playingStyle, nationality, sndNationality, age, weight, height, strongerFoot, position, GK, CB, LB, RB, DMF, CMF, LMF, AMF, RMF, LWF, RWF, SS, CF, 
            attack, ballControll, dribbling, lowPass, loftedPass, finishing, placeKick, swerve, 
            header, defense, ballWinning, kickingPower, speed, explosivePower, BodyControl, physical, jump, goalkeeping, cathing, clearing, reflexes, coverage, stamina, weAcc, weUsage, form,  InjuryRes, fightingSpirit, acrobaticClear, knucleShot,
            firstTimeShot, longThrow, manMarking, outsideCurler, marseilleTurn, scothMove, gkLongThrow, cutBehindTurn, scissorsFeint, lowLoftedPass, oneTouchPass, weightedPass, 
            acrobaticFinishing, pinpointCrossing, lowPuntTrajectory, longRangeDrive, flipFlap, rabona, malicia, sombrero, heading, hellTrick, trackBack, superSub, captaincy, trickster, mazingRun, longBallExpert, incisiveRun, speedingBullet, earlyCross, longRanger);
        }

		//save
        private void button4_Click(object sender, EventArgs e)
        {
            int index = controller.findPlayer(temp.getId());

            temp.setName(playerName.Text);
            temp.setJapanese(japaneseName.Text);
            temp.setShirtName(shirtName.Text);
            temp.setWeight(uint.Parse(weight.Text));
            temp.setHeight(uint.Parse(height.Text));
            if (earlyCross.Checked)
                temp.setEarlyCross(1);
            else
                temp.setEarlyCross(0);
            temp.setDefense(uint.Parse(defense.Text));
            temp.setClearing(uint.Parse(clearing.Text));
            temp.setLowPass(uint.Parse(lowPass.Text));
            temp.setNational(controller.leggiPaese(nationality.SelectedIndex).getId());
            temp.setNational2(controller.leggiPaese(sndNationality.SelectedIndex).getId());
            temp.setPlaceKick(uint.Parse(placeKick.Text));
            temp.setGoalCelebrate(uint.Parse(goalCeleb.Text));
            temp.setLb((uint)LB.SelectedIndex);
            temp.setCoverage(uint.Parse(coverage.Text));
            temp.setCathing(uint.Parse(cathing.Text));
            temp.setJump(uint.Parse(jump.Text));
            temp.setHeader(uint.Parse(header.Text));
            temp.setBallControll(uint.Parse(ballControll.Text));
            temp.setGk((uint)GK.SelectedIndex);
            temp.setGoalkeeping(uint.Parse(goalkeeping.Text));
            temp.setReflexes(uint.Parse(reflexes.Text));
            temp.setFinishing(uint.Parse(finishing.Text));
            temp.setBallWinning(uint.Parse(ballWinning.Text));
            temp.setSpeed(uint.Parse(speed.Text));
            temp.setPenaltyKick(uint.Parse(pkMotion.Text));
            temp.setKickingPower(uint.Parse(kickingPower.Text));
            temp.setDribbling(uint.Parse(dribbling.Text));
            temp.setExplosiveP(uint.Parse(explosivePower.Text));
            temp.setStamina(uint.Parse(stamina.Text));
            temp.setSwerve(uint.Parse(swerve.Text));
            /*unk*/
            temp.setAge(uint.Parse(age.Text));
            temp.setLoftedPass(uint.Parse(loftedPass.Text));
            temp.setPhysical(uint.Parse(physical.Text));
            temp.setBodyControl(uint.Parse(BodyControl.Text));
            temp.setAttack(uint.Parse(attack.Text));
            temp.setWcUsage(uint.Parse(weUsage.Text));
            temp.setDmf((uint)DMF.SelectedIndex);
            temp.setStarPlayerIndicator(uint.Parse(starIndicator.Value.ToString()));
            temp.setRunningArm(uint.Parse(RunArmMove.Text));
            temp.setDriblingArm(uint.Parse(DribArmMove.Text));
            temp.setCornerKick(uint.Parse(ckMotion.Text));
            temp.setForm(uint.Parse(form.Text));
            temp.setPosition((uint)position.SelectedIndex);
            temp.setFreeKick(uint.Parse(fkMotion.Text));
            temp.setPlayingStyle((uint)playingStyle.SelectedIndex);
            if (pinpointCrossing.Checked)
                temp.setPinCrossing(1);
            else
                temp.setPinCrossing(0);
            if (sombrero.Checked)
                temp.setSombrero(1);
            else
                temp.setSombrero(0);
            temp.setRunningH(uint.Parse(RunHunch.Text));
            temp.setSs((uint)SS.SelectedIndex);
            /*unk2*/
            temp.setRwf((uint)RWF.SelectedIndex);
            temp.setLmf((uint)LMF.SelectedIndex);
            temp.setLwf((uint)LWF.SelectedIndex);
            temp.setCf((uint)CF.SelectedIndex);
            temp.setCb((uint)CB.SelectedIndex);
            temp.setRb((uint)RB.SelectedIndex);
            temp.setDriblingH(uint.Parse(DribHunch.Text));
            temp.setAmf((uint)AMF.SelectedIndex);
            temp.setInjuryRes(uint.Parse(InjuryRes.Text));
            temp.setRmf((uint)RMF.SelectedIndex);
            temp.setWeakFootAcc(uint.Parse(weAcc.Text));
            temp.setCmf((uint)CMF.SelectedIndex);
            if (speedingBullet.Checked)
                temp.setSpeedingBullet(1);
            else
                temp.setSpeedingBullet(0);
            if (scothMove.Checked)
                temp.setSchotMove(1);
            else
                temp.setSchotMove(0);
            if (gkLongThrow.Checked)
                temp.setGkLong(1);
            else
                temp.setGkLong(0);
            if (longThrow.Checked)
                temp.setLongThrow(1);
            else
                temp.setLongThrow(0);
            if (scissorsFeint.Checked)
                temp.setScissorFeint(1);
            else
                temp.setScissorFeint(0);
            if (trackBack.Checked)
                temp.setTrackBack(1);
            else
                temp.setTrackBack(0);
            if (superSub.Checked)
                temp.setSuperSub(1);
            else
                temp.setSuperSub(0);
            if (rabona.Checked)
                temp.setRabona(1);
            else
                temp.setRabona(0);
            if (acrobaticFinishing.Checked)
                temp.setAcrobatingFinishing(1);
            else
                temp.setAcrobatingFinishing(0);
            if (strongerFoot.SelectedIndex == 0)
                temp.setStrongerFoot(1);
            else
                temp.setStrongerFoot(0);
            if (knucleShot.Checked)
                temp.setKnucleShot(1);
            else
                temp.setKnucleShot(0);
            if (firstTimeShot.Checked)
                temp.setFirstTimeShot(1);
            else
                temp.setFirstTimeShot(0);
            if (incisiveRun.Checked)
                temp.setComIncisiveRun(1);
            else
                temp.setComIncisiveRun(0);
            /*unk3*/
            if (hiddenPlayer.Checked)
                temp.setHiddenPlayer(1);
            else
                temp.setHiddenPlayer(0);
            if (longRangeDrive.Checked)
                temp.setLongRange(1);
            else
                temp.setLongRange(0);
            if (oneTouchPass.Checked)
                temp.setOneTouchPass(1);
            else
                temp.setOneTouchPass(0);
            if (hellTrick.Checked)
                temp.setHellTick(1);
            else
                temp.setHellTick(0);
            /*unk4*/
            if (manMarking.Checked)
                temp.setManMarking(1);
            else
                temp.setManMarking(0);
            if (wonGoldenBall.Checked)
                temp.setLegendGoldenBall(1);
            else
                temp.setLegendGoldenBall(0);
            if (marseilleTurn.Checked)
                temp.setMarseilleTurn(1);
            else
                temp.setMarseilleTurn(0);
            if (heading.Checked)
                temp.setHeading(1);
            else
                temp.setHeading(0);
            if (outsideCurler.Checked)
                temp.setOutsideCurler(1);
            else
                temp.setOutsideCurler(0);
            if (captaincy.Checked)
                temp.setCaptaincy(1);
            else
                temp.setCaptaincy(0);
            if (malicia.Checked)
                temp.setMalicia(1);
            else
                temp.setMalicia(0);
            if (lowPuntTrajectory.Checked)
                temp.setLowPuntTrajectory(1);
            else
                temp.setLowPuntTrajectory(0);
            if (trickster.Checked)
                temp.setComTrickster(1);
            else
                temp.setComTrickster(0);
            if (lowLoftedPass.Checked)
                temp.setLowLoftedPass(1);
            else
                temp.setLowLoftedPass(0);
            if (fightingSpirit.Checked)
                temp.setFightingSpirit(1);
            else
                temp.setFightingSpirit(0);
            if (flipFlap.Checked)
                temp.setFlipFlap(1);
            else
                temp.setFlipFlap(0);
            if (weightedPass.Checked)
                temp.setWeightnessPass(1);
            else
                temp.setWeightnessPass(0);
            /*unk6*/
            /*unk7*/
            /*unk8*/
            if (mazingRun.Checked)
                temp.setComMazingRun(1);
            else
                temp.setComMazingRun(0);
            if (acrobaticClear.Checked)
                temp.setAcrobatingClear(1);
            else
                temp.setAcrobatingClear(0);
            if (longBallExpert.Checked)
                temp.setComBallExpert(1);
            else
                temp.setComBallExpert(0);
            if (cutBehindTurn.Checked)
                temp.setCutBehind(1);
            else
                temp.setCutBehind(0);
            if (longRanger.Checked)
                temp.setComLongRanger(1);
            else
                temp.setComLongRanger(0);

            temp.setYouthPlayerId(controller.leggiSquadra(youthClub.SelectedIndex).getId());

            if (skinNull.Visible == false)
                controller.changeSkinColour(temp.getId(), int.Parse(skinColour.Value.ToString()));

            controller.applyPlayerPersister(index, temp);

            GloveList glove = new GloveList(temp.getId());
            glove.setGloveId(controller.leggiGuanto(glovesRelink.SelectedIndex).getId());
            controller.applyGloveListPersister(glove);

            BootList boot = new BootList(temp.getId());
            boot.setBootId(controller.leggiScarpa(bootsRelink.SelectedIndex).getId());
            controller.applyBootListPersister(boot);

            controller.UpdateTeamView(temp.getId(), temp.getName());
            controller.UpdateFormPlayer(index, temp.getName());
            this.Close();
        }

        //Skin Value
        private void skin_c_ValueChanged(object sender, EventArgs e)
        {
            if (skinColour.Value == 1)
            {
                skin1.Visible = true;
                skin2.Visible = false;
                skin3.Visible = false;
                skin4.Visible = false;
                skin5.Visible = false;
                skin6.Visible = false;
            }
            else if (skinColour.Value == 2)
            {
                skin1.Visible = false;
                skin2.Visible = true;
                skin3.Visible = false;
                skin4.Visible = false;
                skin5.Visible = false;
                skin6.Visible = false;
            }
            else if (skinColour.Value == 3)
            {
                skin1.Visible = false;
                skin2.Visible = false;
                skin3.Visible = true;
                skin4.Visible = false;
                skin5.Visible = false;
                skin6.Visible = false;
            }
            else if (skinColour.Value == 4)
            {
                skin1.Visible = false;
                skin2.Visible = false;
                skin3.Visible = false;
                skin4.Visible = true;
                skin5.Visible = false;
                skin6.Visible = false;
            }
            else if (skinColour.Value == 5)
            {
                skin1.Visible = false;
                skin2.Visible = false;
                skin3.Visible = false;
                skin4.Visible = false;
                skin5.Visible = true;
                skin6.Visible = false;
            }
            else if (skinColour.Value == 6)
            {
                skin1.Visible = false;
                skin2.Visible = false;
                skin3.Visible = false;
                skin4.Visible = false;
                skin5.Visible = false;
                skin6.Visible = true;
            }
        }

        //Fake Button
        private void fakeButton_Click(object sender, EventArgs e)
        {
        }

        private void characterS1_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Res\charmap.exe");
        }

        //add boot relink
        private void addBootRelink_Click(object sender, EventArgs e)
        {
            controller.addBootListPersister(temp.getId());

            bootsRelink.SelectedIndex = 0;

            addBootRelink.Enabled = false;
        }

        //add glove relink
        private void addGloveRelink_Click(object sender, EventArgs e)
        {
            controller.addGloveListPersister(temp.getId());

            glovesRelink.SelectedIndex = 0;

            addGloveRelink.Enabled = false;
        }

        //add new skin
        private void skinNull_Click(object sender, EventArgs e)
        {
            controller.addPlayerAppearancePersister(temp.getId());

            skinNull.Visible = false;
            skin1.Visible = true;
            skinColour.Visible = true;

            if (skinNull.Visible == false)
                controller.changeSkinColour(temp.getId(), int.Parse(skinColour.Value.ToString()));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using UniDecode;
using DinoTem.ui;
using DinoTem.model;
using DinoTem;

namespace Team_Editor_Manager_New_Generation.ui
{
    //pes 18, pes 17
    public class ControllerCSV
    {
        public string exportPlayer(Controller controller) {
		    StringBuilder sb = new StringBuilder();
		    sb.Append("Id;Name;Shirt_Name;Weight;Height;Nationality;second_Nationality;Early_cross;def_prowess;Clearing;Low_pass;place_kicking;Goal_celeb;LB;coverage;catching;Jump;Header;Ball_control;GK;GoalKeeping;Reflexes;Finishing;Ball_winning;Speed;Penalty_kick;Kicking_power;Dribling;Explosive_power;Stamina;Swerve;playingAttitude;Age;Lofted_pass;Physical_Contact;Body_Controll;Attacking_Prowess;Weak_foot_use;DMF;");
		    sb.Append("starPlayerIndicator;Running_arm_mov;Dribling_arm_mov;Corner_kick;FORM;Position;Free_kick;Playing_Style;Pinpoint_Crossing;Sombrero;Runing_Hutching;SS;unk2;RWF;LMF;RB;LWF;CF;CB;Dribling_hutching;AMF;Weak_foot_acc;RMF;Injury_res;CMF;COM_Speeding Bullet;Scotch_Move;GK_long;Long_Throw;Scissors_Feint;Track Back;Super-sub;Rabona;Acrobatic_Finishing;Stronger_Foot;Knuckle_Shot;First-time_Shot;COM_Incisive_Run;Stronger_Hand;Hidden_Player;");
		    sb.Append("COM_Long_Ranger;One-touch_Pass;Heel_Trick;UNK4;Man_Marking;legendGoldenBall;Marseille_Turn;Heading;Outside_Curler;Captaincy;Malicia;Low_Punt_Trajectory;COM_Trickster;Low_Lofted_Pass;Fighting_Spirit;Flip_Flap;Weightness_Pass;unk6;UNK7;UNK8;comMazingRun;acrobatingClear;comBallExpert;cutBehind;longRange");
		    sb.Append("\n");
            //foreach (Player temp in controller.getListPlayer())
            //{
			    /*sb.Append(temp.getId() + ";");
                string decode = Unidecoder.Unidecode(temp.getName());
                sb.Append(decode + ";");
			    sb.Append(temp.getShirtName() + ";");
			    sb.Append(temp.getWeight() + ";");
			    sb.Append(temp.getHeight() + ";");
			    sb.Append(temp.getNational() + ";");
			    sb.Append(temp.getNational2() + ";");
			    sb.Append(booleanstring(temp.getEarlyCross()) + ";");
			    sb.Append(temp.getDefense() + ";");
			    sb.Append(temp.getClearing() + ";");
			    sb.Append(temp.getLowPass() + ";");
			    sb.Append(temp.getPlaceKick() + ";");
			    sb.Append(temp.getGoalCelebrate() + ";");
			    sb.Append(temp.getLb() + ";");
			    sb.Append(temp.getCoverage() + ";");
			    sb.Append(temp.getCathing() + ";");
			    sb.Append(temp.getJump() + ";");
			    sb.Append(temp.getHeader() + ";");
			    sb.Append(temp.getBallControll() + ";");
			    sb.Append(temp.getGk() + ";");
			    sb.Append(temp.getGoalkeeping() + ";");
			    sb.Append(temp.getReflexes() + ";");
			    sb.Append(temp.getFinishing() + ";");
			    sb.Append(temp.getBallWinning() + ";");
			    sb.Append(temp.getSpeed() + ";");
			    sb.Append(temp.getPenaltyKick() + ";");
			    sb.Append(temp.getKickingPower() + ";");
			    sb.Append(temp.getDribbling() + ";");
			    sb.Append(temp.getExplosiveP() + ";");
			    sb.Append(temp.getStamina() + ";");
			    sb.Append(temp.getSwerve() + ";");
			    sb.Append(temp.getPlayingAttitude() + ";");
			    sb.Append(temp.getAge() + ";");
			    sb.Append(temp.getLoftedPass() + ";");
			    sb.Append(temp.getPhysical() + ";");
			    sb.Append(temp.getBodyControll() + ";");
			    sb.Append(temp.getAttack() + ";");
			    sb.Append(temp.getWcUsage() + ";");
			    sb.Append(temp.getDmf() + ";");
			    sb.Append(temp.getStarPlayerIndicator() + ";");
			    sb.Append(temp.getRunningArm() + ";");
			    sb.Append(temp.getDriblingArm() + ";");
			    sb.Append(temp.getCornerKick() + ";");
			    sb.Append(temp.getForm() + ";");
			    sb.Append(temp.getPosition() + ";");
			    sb.Append(temp.getFreeKick() + ";");
			    sb.Append(temp.getPlayingStyle() + ";");
			    sb.Append(booleanstring(temp.getPinCrossing()) + ";");
			    sb.Append(booleanstring(temp.getSombrero()) + ";");
			    sb.Append(temp.getRunningH() + ";");
			    sb.Append(temp.getSs() + ";");
			    sb.Append(temp.getUnk2() + ";");
			    sb.Append(temp.getRwf() + ";");
			    sb.Append(temp.getLmf() + ";");
			    sb.Append(temp.getRb() + ";");
			    sb.Append(temp.getLwf() + ";");
			    sb.Append(temp.getCf() + ";");
			    sb.Append(temp.getCb() + ";");
			    sb.Append(temp.getDriblingH() + ";");
			    sb.Append(temp.getAmf() + ";");
			    sb.Append(temp.getWeakFootAcc() + ";");
			    sb.Append(temp.getRmf() + ";");
			    sb.Append(temp.getInjuryRes() + ";");
			    sb.Append(temp.getCmf() + ";");
			    sb.Append(booleanstring(temp.getSpeedingBullet()) + ";");
			    sb.Append(booleanstring(temp.getSchotMove()) + ";");
			    sb.Append(booleanstring(temp.getGkLong()) + ";");
			    sb.Append(booleanstring(temp.getLongThrow()) + ";");
			    sb.Append(booleanstring(temp.getScissorFeint()) + ";");
			    sb.Append(booleanstring(temp.getTrackBack()) + ";");
			    sb.Append(booleanstring(temp.getSuperSub()) + ";");
			    sb.Append(booleanstring(temp.getRabona()) + ";");
			    sb.Append(booleanstring(temp.getAcrobatingFinishing()) + ";");
			    sb.Append(booleanstring(temp.getStrongerFoot()) + ";");
			    sb.Append(booleanstring(temp.getKnucleShot()) + ";");
			    sb.Append(booleanstring(temp.getFirstTimeShot()) + ";");
			    sb.Append(booleanstring(temp.getComIncisiveRun()) + ";");
			    sb.Append(booleanstring(temp.getStrongerHand()) + ";");
			    sb.Append(booleanstring(temp.getHiddenPlayer()) + ";");
			    sb.Append(booleanstring(temp.getLongRange()) + ";");
			    sb.Append(booleanstring(temp.getOneTouchPass()) + ";");
			    sb.Append(booleanstring(temp.getHellTick()) + ";");
			    sb.Append(booleanstring(temp.getUnk4()) + ";");
			    sb.Append(booleanstring(temp.getManMarking()) + ";");
			    sb.Append(booleanstring(temp.getLegendGoldenBall()) + ";");
			    sb.Append(booleanstring(temp.getMarseilleTurn()) + ";");
			    sb.Append(booleanstring(temp.getHeading()) + ";");
			    sb.Append(booleanstring(temp.getOutsideCurler()) + ";");
			    sb.Append(booleanstring(temp.getCaptaincy()) + ";");
			    sb.Append(booleanstring(temp.getMalicia()) + ";");
			    sb.Append(booleanstring(temp.getLowPuntTrajectory()) + ";");
			    sb.Append(booleanstring(temp.getComTrickster()) + ";");
			    sb.Append(booleanstring(temp.getLowLoftedPass()) + ";");
			    sb.Append(booleanstring(temp.getFightingSpirit()) + ";");
			    sb.Append(booleanstring(temp.getFlipFlap()) + ";");
			    sb.Append(booleanstring(temp.getWeightnessPass()) + ";");
			    sb.Append(booleanstring(temp.getUnk6()) + ";");
			    sb.Append(booleanstring(temp.getUnk7()) + ";");
			    sb.Append(booleanstring(temp.getUnk8()) + ";");
			    sb.Append(booleanstring(temp.getComMazingRun()) + ";");
			    sb.Append(booleanstring(temp.getAcrobatingClear()) + ";");
			    sb.Append(booleanstring(temp.getComBallExpert()) + ";");
			    sb.Append(booleanstring(temp.getCutBehind()) + ";");
			    sb.Append(booleanstring(temp.getLongRange()));
			    sb.Append("\n");*/
		    //}
		    return sb.ToString();
	    }

        public string exportPlayerAppareance(Controller controller) {
		    StringBuilder sb = new StringBuilder();
            sb.Append("Id;UNK1;UNK2;UNK3;UNK4;UNK5;UNK6;UNK7;UNK8;UNK9;UNK10;UNK11;UNK12;UNK13;UNK14;UNK15;UNK16;UNK17;UNK18;UNK19;UNK20;UNK21;UNK22;UNK23;UNK24;UNK25;UNK26;UNK27;UNK28;UNK29;UNK30;UNK31;UNK32;UNK33;UNK34;UNK35;UNK36;Eyes_Skin_Color;38;UNK39;UNK40;UNK41;UNK42;UNK43;UNK44;UNK45;UNK46;UNK47;UNK48;UNK49;UNK50;UNK51;UNK52;UNK53;UNK54;UNK55;UNK56");
		    sb.Append("\n");
            foreach (PlayerAppearance temp in controller.getPlayerAppearanceList())
            {
			    sb.Append(temp.getId() + ";");
                sb.Append(string.Format("{0:X2}", temp.getUnknown1()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown2()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown3()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown4()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown5()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown6()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown7()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown8()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown9()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown10()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown11()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown12()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown13()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown14()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown15()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown16()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown17()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown18()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown19()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown20()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown21()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown22()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown23()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown24()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown25()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown26()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown27()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown28()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown29()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown30()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown31()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown32()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown33()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown34()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown35()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown36()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getEyeskinColor()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown38()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown39()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown40()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown41()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown42()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown43()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown44()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown45()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown46()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown47()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown48()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown49()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown50()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown51()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown52()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown53()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown54()) + ";");
			    sb.Append(string.Format("{0:X2}", temp.getUnknown55()) + ";");
                sb.Append(string.Format("{0:X2}", temp.getUnknown56()) + ";");
			    sb.Append("\n");
		    }
            return sb.ToString();
	    }

        public string exportTeam(Controller controller)
        {
		    StringBuilder sb = new StringBuilder();
            sb.Append("Id;teamName;shortSquadra;hasLicensedPlayers;licensedTeam;national;fakeTeam;licensedCoach;hasAnthem;anthemStandingAngle;anthemPlayersSinging;anthemStandingStyle;UNK6;notPlayableLeague;country");
		    sb.Append("\n");
            foreach (Team temp in controller.getListTeam())
            {
			    sb.Append(temp.getId() + ";");
                string decode = Unidecoder.Unidecode(temp.getEnglish());
                /*sb.Append(decode + ";");
			    sb.Append(temp.getShortSquadra() + ";");
                sb.Append(booleanstring(temp.getHasLicensedPlayers()) + ";");
			    sb.Append(booleanstring(temp.getLicensedTeam()) + ";");
			    sb.Append(booleanstring(temp.getNational()) + ";");
			    sb.Append(booleanstring(temp.getFakeTeam()) + ";");
			    sb.Append(booleanstring(temp.getLicensedCoach()) + ";");
                sb.Append(booleanstring(temp.getHasAnthem()) + ";");
                sb.Append(temp.getAnthemStandingAngle() + ";");
                sb.Append(temp.getAnthemPlayersSinging() + ";");
                sb.Append(temp.getAnthemStandingStyle() + ";");
                sb.Append(booleanstring(temp.getUnknown6()) + ";");
			    sb.Append(temp.getNotPlayableLeague() + ";");
			    sb.Append(temp.getCountry() + ";");
			    sb.Append("\n");*/
		    }
            return sb.ToString();
	    }

        public string exportBall(Controller controller)
        {
		    StringBuilder sb = new StringBuilder();
		    sb.Append("Id;BallName;Order");
		    sb.Append("\n");
            for (int i = 0; i < Form1._Form1.ballsBox.Items.Count; i++)
            {
                Ball temp = controller.leggiPallone(i);
			    sb.Append(temp.getId() + ";");
			    sb.Append(temp.getName() + ";");
			    sb.Append(temp.getOrder() + ";");
			    sb.Append("\n");
		    }
		    return sb.ToString();
	    }

        public string exportBallCondition(Controller controller)
        {
		    StringBuilder sb = new StringBuilder();
		    sb.Append("Id;unknow");
		    sb.Append("\n");
            for (int i = 0; i < Form1._Form1.ballsBox.Items.Count; i++)
            {
                Ball temp1 = controller.leggiPallone(i);
                List<BallCondition> temp = controller.leggiCondizioniPalloni(temp1.getId());
                foreach (BallCondition bC in temp)
                {
                    sb.Append(bC.getId() + ";");
                    sb.Append(bC.getUnknown() + ";");
                    sb.Append("\n");
                }
            }
		    return sb.ToString();
	    }

        public string exportPlayerAssignment(Controller controller)
        {
		    StringBuilder sb = new StringBuilder();
		    sb.Append("Id_player;player_name;id_team;team_name");
		    sb.Append("\n");
            for (int i = 0; i < Form1._Form1.teamBox1.Items.Count; i++)
            {
                Team t = controller.leggiSquadra(i);
                foreach (PlayerAssignment pA in controller.leggiGiocatoriSquadra(t.getId()))
                {
                    sb.Append(pA.getPlayerId() + ";");
                    Player pa = controller.leggiGiocatoreById(pA.getPlayerId());
                    sb.Append(pa.getName() + ";");
                    sb.Append(t.getId() + ";");
                    sb.Append(t.getEnglish());
                    sb.Append("\n");
                }
		    }
		    return sb.ToString();
	    }

        private string booleanstring(bool value)
        {
            if (value)
                return "1";

            return "0";
        }

        public void importBallCondition(Controller controller, string file, ListBox ballBox)
        {
            int lineCount = File.ReadLines(file).Count();
            //if (lineCount - 1 != controller.getBallConditionList().Count)
                //throw new Exception("number of line is different " + lineCount + " " + controller.getBallConditionList().Count);

            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                string line;
                if (sr.ReadLine() != "Id;unknow")
                    throw new Exception("unrecognized file");

                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(';');
                    if (temp.Length!= 3)
                        throw new Exception("format line unrecognized");
                    //BallCondition ballCondition = (BallCondition) controller.getBallConditionList()[i];
                    //ballCondition.setId(parseInt(temp[0]));
                    //ballCondition.setUnknown(parseInt(temp[1]));
                    i++;
                }
            }
            //controller.UpdateBallList(ballBox);
        }

        private int parseInt(string s)
        {
		    try {
			    return int.Parse(s);
		    }
            catch (FormatException e)
            {
                throw new FormatException("Error parsing int - " + s, e);
		    }
        }
        /*
        public void importBall(Controller controller, string file, ListBox ballBox)
        {
            int lineCount = File.ReadLines(file).Count();
            if (lineCount - 1 != controller.getListBall().Count)
                throw new Exception("number of line is different " + lineCount + " " + controller.getListBall().Count);

            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                string line;
                if (sr.ReadLine() != "Id;BallName;Order")
                    throw new Exception("unrecognized file");

                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(';');
                    if (temp.Length != 4)
                        throw new Exception("format line unrecognized");
                    Ball ball = (Ball)controller.getListBall()[i];
                    ball.setId(parseInt(temp[0]));
                    ball.setName(temp[1]);
                    ball.setId(parseInt(temp[2]));
                    i++;
                }
            }
            controller.UpdateBallList(ballBox);
        }
        */
        public void importPlayerAppareance(Controller controller, string file)
        {
            int lineCount = File.ReadLines(file).Count();
            if (lineCount - 1 != controller.getPlayerAppearanceList().Count)
                throw new Exception("number of line is different " + lineCount + " " + controller.getPlayerAppearanceList().Count);

            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                string line;
                if (sr.ReadLine() != "Id;UNK1;UNK2;UNK3;UNK4;UNK5;UNK6;UNK7;UNK8;UNK9;UNK10;UNK11;UNK12;UNK13;UNK14;UNK15;UNK16;UNK17;UNK18;UNK19;UNK20;UNK21;UNK22;UNK23;UNK24;UNK25;UNK26;UNK27;UNK28;UNK29;UNK30;UNK31;UNK32;UNK33;UNK34;UNK35;UNK36;Eyes_Skin_Color;38;UNK39;UNK40;UNK41;UNK42;UNK43;UNK44;UNK45;UNK46;UNK47;UNK48;UNK49;UNK50;UNK51;UNK52;UNK53;UNK54;UNK55;UNK56")
                    throw new Exception("unrecognized file");

                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(';');
                    if (temp.Length != 58)
                        throw new Exception("format line unrecognized");
                    PlayerAppearance playerA = (PlayerAppearance)controller.getPlayerAppearanceList()[i];
                    playerA.setId(parseLong(temp[0]));
                    playerA.setUnknown1(parseByte(temp[1]));
                    playerA.setUnknown2(parseByte(temp[2]));
                    playerA.setUnknown3(parseByte(temp[3]));
                    playerA.setUnknown4(parseByte(temp[4]));
                    playerA.setUnknown5(parseByte(temp[5]));
                    playerA.setUnknown6(parseByte(temp[6]));
                    playerA.setUnknown7(parseByte(temp[7]));
                    playerA.setUnknown8(parseByte(temp[8]));
                    playerA.setUnknown9(parseByte(temp[9]));
                    playerA.setUnknown10(parseByte(temp[10]));
                    playerA.setUnknown11(parseByte(temp[11]));
                    playerA.setUnknown12(parseByte(temp[12]));
                    playerA.setUnknown13(parseByte(temp[13]));
                    playerA.setUnknown14(parseByte(temp[14]));
                    playerA.setUnknown15(parseByte(temp[15]));
                    playerA.setUnknown16(parseByte(temp[16]));
                    playerA.setUnknown17(parseByte(temp[17]));
                    playerA.setUnknown18(parseByte(temp[18]));
                    playerA.setUnknown19(parseByte(temp[19]));
                    playerA.setUnknown20(parseByte(temp[20]));
                    playerA.setUnknown21(parseByte(temp[21]));
                    playerA.setUnknown22(parseByte(temp[22]));
                    playerA.setUnknown23(parseByte(temp[23]));
                    playerA.setUnknown24(parseByte(temp[24]));
                    playerA.setUnknown25(parseByte(temp[25]));
                    playerA.setUnknown26(parseByte(temp[26]));
                    playerA.setUnknown27(parseByte(temp[27]));
                    playerA.setUnknown28(parseByte(temp[28]));
                    playerA.setUnknown29(parseByte(temp[29]));
                    playerA.setUnknown30(parseByte(temp[30]));
                    playerA.setUnknown31(parseByte(temp[31]));
                    playerA.setUnknown32(parseByte(temp[32]));
                    playerA.setUnknown33(parseByte(temp[33]));
                    playerA.setUnknown34(parseByte(temp[34]));
                    playerA.setUnknown35(parseByte(temp[35]));
                    playerA.setUnknown36(parseByte(temp[36]));
                    playerA.setEyeskinColor(parseByte(temp[37]));
                    playerA.setUnknown38(parseByte(temp[38]));
                    playerA.setUnknown39(parseByte(temp[39]));
                    playerA.setUnknown40(parseByte(temp[40]));
                    playerA.setUnknown41(parseByte(temp[41]));
                    playerA.setUnknown42(parseByte(temp[42]));
                    playerA.setUnknown43(parseByte(temp[43]));
                    playerA.setUnknown44(parseByte(temp[44]));
                    playerA.setUnknown45(parseByte(temp[45]));
                    playerA.setUnknown46(parseByte(temp[46]));
                    playerA.setUnknown47(parseByte(temp[47]));
                    playerA.setUnknown48(parseByte(temp[48]));
                    playerA.setUnknown49(parseByte(temp[49]));
                    playerA.setUnknown50(parseByte(temp[50]));
                    playerA.setUnknown51(parseByte(temp[51]));
                    playerA.setUnknown52(parseByte(temp[52]));
                    playerA.setUnknown53(parseByte(temp[53]));
                    playerA.setUnknown54(parseByte(temp[54]));
                    playerA.setUnknown55(parseByte(temp[55]));
                    playerA.setUnknown56(parseByte(temp[56]));
                    i++;
                }
            }
        }

        private long parseLong(string s)
        {
            try
            {
                return long.Parse(s);
            }
            catch (FormatException e)
            {
                throw new FormatException("Error parsing long - " + s, e);
            }
        }

        private byte parseByte(string s)
        {
            try
            {
                int b = int.Parse(s, System.Globalization.NumberStyles.HexNumber);
                return Byte.Parse(b.ToString());
            }
            catch (FormatException e)
            {
                throw new FormatException("Error parsing byte - " + s, e);
            }
        }

        /*public void importTeam(Controller controller, string file, ListBox teamsBox, ComboBox t1, ComboBox t2)
        {
            int lineCount = File.ReadLines(file).Count();
            if (lineCount - 1 != controller.getListTeam().Count)
                throw new Exception("number of line is different " + lineCount + " " + controller.getListTeam().Count);

            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                string line;
                if (sr.ReadLine() != "Id;teamName;shortSquadra;hasLicensedPlayers;licensedTeam;national;fakeTeam;licensedCoach;hasAnthem;anthemStandingAngle;anthemPlayersSinging;anthemStandingStyle;UNK6;notPlayableLeague;country")
                    throw new Exception("unrecognized file");

                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(';');
                    if (temp.Length != 16)
                        throw new Exception("format line unrecognized");
                    Team team = (Team)controller.getListTeam()[i];
                    team.setId(parseInt(temp[0]));
                    team.setEnglish(temp[1]);
                    team.setShortSquadra(temp[2]);
                    team.setHasLicensedPlayers(parseBoolean(temp[3], "1", "0"));
                    team.setLicensedTeam(parseBoolean(temp[4], "1", "0"));
                    team.setNational(parseBoolean(temp[5], "1", "0"));
                    team.setFakeTeam(parseBoolean(temp[6], "1", "0"));
                    team.setLicensedCoach(parseBoolean(temp[7], "1", "0"));
                    team.setHasAnthem(parseBoolean(temp[8], "1", "0"));
                    team.setAnthemStandingAngle(parseInt(temp[9]));
                    team.setAnthemPlayersSinging(parseInt(temp[10]));
                    team.setAnthemStandingStyle(parseInt(temp[11]));
                    team.setUnknown6(parseBoolean(temp[12], "1", "0"));
                    team.setNotPlayableLeague(parseInt(temp[13]));
                    team.setCountry(parseInt(temp[14]));
                    i++;
                }
            }
            controller.UpdateTeamList(teamsBox, t1, t2);
        }
        */
        private bool parseBoolean(string s, string trueValue, string falseValue)
        {
            if (s.Trim().ToUpper().Equals(trueValue))
            {
                return true;
            }
            if (s.Trim().ToUpper().Equals(falseValue))
            {
                return false;
            }
            throw new Exception("reading error!" + s);
        }

        /*
        public void importPlayer(Controller controller, string file, ListView giocatoreView, ComboBox t1, ComboBox t2)
        {
            int lineCount = File.ReadLines(file).Count();
            if (lineCount - 1 != controller.getListPlayer().Count)
                throw new Exception("number of line is different " + lineCount + " " + controller.getListPlayer().Count);

            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                string line;
                if (sr.ReadLine() != "Id;Name;Shirt_Name;Weight;Height;Nationality;second_Nationality;Early_cross;def_prowess;Clearing;Low_pass;place_kicking;Goal_celeb;LB;coverage;catching;Jump;Header;Ball_control;GK;GoalKeeping;Reflexes;Finishing;Ball_winning;Speed;Penalty_kick;Kicking_power;Dribling;Explosive_power;Stamina;Swerve;playingAttitude;Age;Lofted_pass;Physical_Contact;Body_Controll;Attacking_Prowess;Weak_foot_use;DMF;starPlayerIndicator;Running_arm_mov;Dribling_arm_mov;Corner_kick;FORM;Position;Free_kick;Playing_Style;Pinpoint_Crossing;Sombrero;Runing_Hutching;SS;unk2;RWF;LMF;RB;LWF;CF;CB;Dribling_hutching;AMF;Weak_foot_acc;RMF;Injury_res;CMF;COM_Speeding Bullet;Scotch_Move;GK_long;Long_Throw;Scissors_Feint;Track Back;Super-sub;Rabona;Acrobatic_Finishing;Stronger_Foot;Knuckle_Shot;First-time_Shot;COM_Incisive_Run;Stronger_Hand;Hidden_Player;COM_Long_Ranger;One-touch_Pass;Heel_Trick;UNK4;Man_Marking;legendGoldenBall;Marseille_Turn;Heading;Outside_Curler;Captaincy;Malicia;Low_Punt_Trajectory;COM_Trickster;Low_Lofted_Pass;Fighting_Spirit;Flip_Flap;Weightness_Pass;unk6;UNK7;UNK8;comMazingRun;acrobatingClear;comBallExpert;cutBehind;longRange")
                    throw new Exception("unrecognized file");

                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] temp = line.Split(';');
                    if (temp.Length != 104)
                        throw new Exception("format line unrecognized");
                    Player player = (Player)controller.getListPlayer()[i];
                    player.setId(parseLong(temp[0]));
                    player.setName(temp[1]);
                    player.setShirtName(temp[2]);
                    player.setWeight(parseInt(temp[3]));
                    player.setHeight(parseInt(temp[4]));
                    player.setNational(parseInt(temp[5]));
                    player.setNational2(parseInt(temp[6]));
                    player.setEarlyCross(parseBoolean(temp[7], "1", "0"));
                    player.setDefense(parseInt(temp[8]));
                    player.setClearing(parseInt(temp[9]));
                    player.setLowPass(parseInt(temp[10]));
                    player.setPlaceKick(parseInt(temp[11]));
                    player.setGoalCelebrate(parseInt(temp[12]));
                    player.setLb(parseInt(temp[13]));
                    player.setCoverage(parseInt(temp[14]));
                    player.setCathing(parseInt(temp[15]));
                    player.setJump(parseInt(temp[16]));
                    player.setHeader(parseInt(temp[17]));
                    player.setBallControll(parseInt(temp[18]));
                    player.setGk(parseInt(temp[19]));
                    player.setGoalkeeping(parseInt(temp[20]));
                    player.setReflexes(parseInt(temp[21]));
                    player.setFinishing(parseInt(temp[22]));
                    player.setBallWinning(parseInt(temp[23]));
                    player.setSpeed(parseInt(temp[24]));
                    player.setPenaltyKick(parseInt(temp[25]));
                    player.setKickingPower(parseInt(temp[26]));
                    player.setDribbling(parseInt(temp[27]));
                    player.setExplosiveP(parseInt(temp[28]));
                    player.setStamina(parseInt(temp[29]));
                    player.setSwerve(parseInt(temp[30]));
                    player.setPlayingAttitude(parseInt(temp[31]));
                    player.setAge(parseInt(temp[32]));
                    player.setLoftedPass(parseInt(temp[33]));
                    player.setPhysical(parseInt(temp[34]));
                    player.setBodyControll(parseInt(temp[35]));
                    player.setAttack(parseInt(temp[36]));
                    player.setWcUsage(parseInt(temp[37]));
                    player.setDmf(parseInt(temp[38]));
                    player.setStarPlayerIndicator(parseInt(temp[39]));
                    player.setRunningArm(parseInt(temp[40]));
                    player.setDriblingArm(parseInt(temp[41]));
                    player.setCornerKick(parseInt(temp[42]));
                    player.setForm(parseInt(temp[43]));
                    player.setPosition(parseInt(temp[44]));
                    player.setFreeKick(parseInt(temp[45]));
                    player.setPlayingStyle(parseInt(temp[46]));
                    player.setPinCrossing(parseBoolean(temp[47], "1", "0"));
                    player.setSombrero(parseBoolean(temp[48], "1", "0"));
                    player.setRunningH(parseInt(temp[49]));
                    player.setSs(parseInt(temp[50]));
                    player.setUnk2(parseInt(temp[51]));
                    player.setRwf(parseInt(temp[52]));
                    player.setLmf(parseInt(temp[53]));
                    player.setRb(parseInt(temp[54]));
                    player.setLwf(parseInt(temp[55]));
                    player.setCf(parseInt(temp[56]));
                    player.setCb(parseInt(temp[57]));
                    player.setDriblingH(parseInt(temp[58]));
                    player.setAmf(parseInt(temp[59]));
                    player.setWeakFootAcc(parseInt(temp[60]));
                    player.setRmf(parseInt(temp[61]));
                    player.setInjuryRes(parseInt(temp[62]));
                    player.setCmf(parseInt(temp[63]));
                    player.setSpeedingBullet(parseBoolean(temp[64], "1", "0"));
                    player.setSchotMove(parseBoolean(temp[65], "1", "0"));
                    player.setGkLong(parseBoolean(temp[66], "1", "0"));
                    player.setLongThrow(parseBoolean(temp[67], "1", "0"));
                    player.setScissorFeint(parseBoolean(temp[68], "1", "0"));
                    player.setTrackBack(parseBoolean(temp[69], "1", "0"));
                    player.setSuperSub(parseBoolean(temp[70], "1", "0"));
                    player.setRabona(parseBoolean(temp[71], "1", "0"));
                    player.setAcrobatingFinishing(parseBoolean(temp[72], "1", "0"));
                    player.setStrongerFoot(parseBoolean(temp[73], "1", "0"));
                    player.setKnucleShot(parseBoolean(temp[74], "1", "0"));
                    player.setFirstTimeShot(parseBoolean(temp[75], "1", "0"));
                    player.setComIncisiveRun(parseBoolean(temp[76], "1", "0"));
                    player.setStrongerHand(parseBoolean(temp[77], "1", "0"));
                    player.setHiddenPlayer(parseBoolean(temp[78], "1", "0"));
                    player.setLongRange(parseBoolean(temp[79], "1", "0"));
                    player.setOneTouchPass(parseBoolean(temp[80], "1", "0"));
                    player.setHellTick(parseBoolean(temp[81], "1", "0"));
                    player.setUnk4(parseBoolean(temp[82], "1", "0"));
                    player.setManMarking(parseBoolean(temp[83], "1", "0"));
                    player.setLegendGoldenBall(parseBoolean(temp[84], "1", "0"));
                    player.setMarseilleTurn(parseBoolean(temp[85], "1", "0"));
                    player.setHeading(parseBoolean(temp[86], "1", "0"));
                    player.setOutsideCurler(parseBoolean(temp[87], "1", "0"));
                    player.setCaptaincy(parseBoolean(temp[88], "1", "0"));
                    player.setMalicia(parseBoolean(temp[89], "1", "0"));
                    player.setLowPuntTrajectory(parseBoolean(temp[90], "1", "0"));
                    player.setComTrickster(parseBoolean(temp[91], "1", "0"));
                    player.setLowLoftedPass(parseBoolean(temp[92], "1", "0"));
                    player.setFightingSpirit(parseBoolean(temp[93], "1", "0"));
                    player.setFlipFlap(parseBoolean(temp[94], "1", "0"));
                    player.setWeightnessPass(parseBoolean(temp[95], "1", "0"));
                    player.setUnk6(parseBoolean(temp[96], "1", "0"));
                    player.setUnk7(parseBoolean(temp[97], "1", "0"));
                    player.setUnk8(parseBoolean(temp[98], "1", "0"));
                    player.setComMazingRun(parseBoolean(temp[99], "1", "0"));
                    player.setAcrobatingClear(parseBoolean(temp[100], "1", "0"));
                    player.setComBallExpert(parseBoolean(temp[101], "1", "0"));
                    player.setCutBehind(parseBoolean(temp[102], "1", "0"));
                    player.setLongRange(parseBoolean(temp[103], "1", "0"));
                    i++;
                }
            }
            controller.updatePlayerList(giocatoreView);
            controller.UpdateForm(t1, t2);
        }
        */
    }
}

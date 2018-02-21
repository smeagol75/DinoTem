using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DinoTem.model;
using DinoTem.persistence;

namespace DinoTem.ui
{
    public class ControllerFm
    {
        private List<Fm> fmList = new List<Fm>();
        private Player player;

        public ControllerFm()
        {
        }

        public List<Fm> getFmList()
        {
            return fmList;
        }

        public Player getPlayer()
        {
            return player;
        }

        public void setPlayer(Player player)
        {
            this.player = player;
        }

        public void readFmPersister()
        {
            MyFmPersister fmReader = new MyFmPersister();
            
            try
            {
                fmList = fmReader.load("FM2017 Players.csv");
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> getClub()
        {
            List<string> result = new List<string>();
            foreach (Fm temp in fmList)
            {
                result.Add(temp.getClub());
            }
            result.Add("All");

            return result.Distinct().ToList();
        }

        public List<Fm> filter(string club, string nation)
        {
            List<Fm> result = new List<Fm>();

            foreach (Fm temp in fmList)
            {
                if (club == "All" && nation == "All")
                    return getFmList();
                else if (club == "All")
                {
                    if (nation == temp.getNation())
                        result.Add(temp);
                }
                else if (nation == "All")
                {
                    if (club == temp.getClub())
                        result.Add(temp);
                }
                else
                {
                    if (club == temp.getClub() && nation == temp.getNation())
                        result.Add(temp);
                }
                    
            }

            return result;
        }

        private void posPlayer(RadioButton gk, RadioButton cb, RadioButton lb, RadioButton rb, RadioButton dmf, RadioButton cmf,
            RadioButton lmf, RadioButton amf, RadioButton rmf, RadioButton lwf, RadioButton rwf, RadioButton ss, RadioButton cf, UInt32 position)
        {
            switch (position)
            {
                case 0: gk.Checked = true;
                    break;
                case 1: cb.Checked = true;
                    break;
                case 2: lb.Checked = true;
                    break;
                case 3: rb.Checked = true;
                    break;
                case 4: dmf.Checked = true;
                    break;
                case 5: cmf.Checked = true;
                    break;
                case 6: lmf.Checked = true;
                    break;
                case 7: amf.Checked = true;
                    break;
                case 8: rmf.Checked = true;
                    break;
                case 9: lwf.Checked = true;
                    break;
                case 10: rwf.Checked = true;
                    break;
                case 11: ss.Checked = true;
                    break;
                case 12: cf.Checked = true;
                    break;
            }
        }

        public void positionPlayer(RadioButton gk, RadioButton cb, RadioButton lb, RadioButton rb, RadioButton dmf, RadioButton cmf,
            RadioButton lmf, RadioButton amf, RadioButton rmf, RadioButton lwf, RadioButton rwf, RadioButton ss, RadioButton cf, Fm temp,
            int average, int averageGk)
        {
            string[] words = temp.getPosition().Split(' ');
            List<UInt32> positions = new List<UInt32>();

            if (temp.getPosition().Contains("GK"))
                positions.Add(0);
            if (temp.getPosition().Contains("SW") || temp.getPosition().Contains("SW/"))
                positions.Add(1);
            if ((temp.getPosition().Contains("D") && words[0].Length == 1) || temp.getPosition().Contains("D/"))
                positions.Add(1);
            if (temp.getPosition().Contains("WB") && temp.getPosition().Contains("L"))
                positions.Add(2);
            if (temp.getPosition().Contains("WB") && temp.getPosition().Contains("R"))
                positions.Add(3);
            if (temp.getPosition().Contains("DM"))
                positions.Add(4);
            if (((temp.getPosition().Contains("M") && words[0].Length == 1) || temp.getPosition().Contains("/M")) && temp.getPosition().Contains("C"))
                positions.Add(5);
            if (((temp.getPosition().Contains("M") && words[0].Length == 1) || temp.getPosition().Contains("/M")) && temp.getPosition().Contains("L"))
                positions.Add(6);
            if (((temp.getPosition().Contains("M") && words[0].Length == 1) || temp.getPosition().Contains("/M")) && temp.getPosition().Contains("R"))
                positions.Add(8);
            if (temp.getPosition().Contains("AM") && temp.getPosition().Contains("C"))
                positions.Add(11);
            if (temp.getPosition().Contains("AM") && temp.getPosition().Contains("L"))
                positions.Add(9);
            if (temp.getPosition().Contains("AM") && temp.getPosition().Contains("R"))
                positions.Add(10);
            if (temp.getPosition().Contains("ST"))
                positions.Add(12);

            UInt32 position = 0;
            double mediaMag = 0;
            foreach (UInt32 i in positions)
            {
                UInt32 stamina = calculateStamina(temp.getStamina(), average, averageGk, temp.getNaturalFitness(), temp.getStrength(), temp.getWorkRate(), i);
                UInt32 coverage = calculateCoverage(temp.getCommandOfArea(), temp.getCommunication(), temp.getPositioning(), temp.getLeadership(), temp.getGk(), average, averageGk, i);
                UInt32 reflexes = calculateRflexes(temp.getReflexes(), temp.getGk(), average, averageGk, i);
                UInt32 clearing = calculateClearing(temp.getTendancyToPunch(), temp.getGk(), average, averageGk, i);
                UInt32 catching = calculateCatching(temp.getHandling(), temp.getGk(), average, averageGk, i);
                UInt32 goalkeeping = calculateGoalkeeping(temp.getCommandOfArea(), temp.getCommunication(), temp.getAerialAbility(), temp.getHandling(),
                    temp.getThrowing(), temp.getKicking(), temp.getOneOnOnes(), temp.getTendancyToPunch(), temp.getConcentration(),
                    temp.getLeadership(), temp.getPositioning(), temp.getGk(), average, averageGk, i);
                UInt32 jump = calculateJump(temp.getJumping(), temp.getAgility(), temp.getStrength(), average, i);
                UInt32 physicalContact = calculatePhysicalContact(temp.getPositioning(), temp.getTackling(), temp.getEccentricity(), temp.getWorkRate(), temp.getNaturalFitness(),
                    temp.getStamina(), average, averageGk, i);
                UInt32 bodyControll = calculateBodyControll(temp.getNaturalFitness(), temp.getBalance(), temp.getStrength(), average, i);
                UInt32 explosivePower = calculateExplosivePower(temp.getNaturalFitness(), temp.getAgility(), temp.getAcceleration(), temp.getStrength(), temp.getStamina(),
                    temp.getDetermination(), average, averageGk, i);
                UInt32 speed = calculateSpeed(temp.getPace(), temp.getAcceleration(), temp.getNaturalFitness(), average, averageGk, i);
                UInt32 kickingPower = calculateKickingPower(temp.getPassing(), temp.getEccentricity(), temp.getStrength(), temp.getFreeKicks(),
                    temp.getPenalties(), temp.getLongShots(), average, averageGk, i);
                UInt32 ballWinning = calculateBallWinning(temp.getAggression(), temp.getEccentricity(), temp.getPositioning(), temp.getMarking(), average, averageGk, i);
                UInt32 defensiveProwess = calculateDefensiveProwess(temp.getPositioning(), temp.getAggression(), temp.getEccentricity(), temp.getConcentration(), temp.getTeamwork(), average, averageGk, i);
                UInt32 header = calculateHeader(temp.getEccentricity(), temp.getRushingOut(), temp.getAerialAbility(), temp.getJumping(),
                    temp.getHeading(), temp.getAnticipation(), average, averageGk, i);
                UInt32 swerve = calculateSwerve(temp.getPassing(), temp.getFreeKicks(), temp.getTechnique(), temp.getCorners(), temp.getFirstTouch(), average, averageGk, i);
                UInt32 placekiking = calculatePlaceKicking(temp.getComposure(), temp.getDetermination(), temp.getTechnique(), temp.getFreeKicks(),
                    temp.getStrength(), temp.getLeadership(), average, i);
                UInt32 finishing = calculateFinishing(temp.getPenalties(), temp.getFreeKicks(), temp.getVision(), temp.getFinishing(),
                    temp.getLongShots(), temp.getComposure(), average, averageGk, i);
                UInt32 loftedPass = calculateLoftedPass(temp.getPassing(), temp.getKicking(), temp.getEccentricity(), temp.getCorners(), temp.getLongThrows(),
                    average, averageGk, i);
                UInt32 lowPass = calculateLowPass(temp.getEccentricity(), temp.getFirstTouch(), temp.getPassing(), temp.getDecisions(),
                    temp.getVision(), average, averageGk, i);
                UInt32 dribbling = calculateDribbling(temp.getFlair(), temp.getEccentricity(), temp.getDribbling(), temp.getFirstTouch(),
                    temp.getTechnique(), average, averageGk, i);
                UInt32 ballControl = calculateBallControll(temp.getFirstTouch(), temp.getEccentricity(), temp.getTechnique(), temp.getVision(),
                    average, averageGk, i);
                UInt32 attackingProwess = calculateAttackingProwness(temp.getOffTheBall(), temp.getTeamwork(), temp.getFinishing(),
                    temp.getFirstTouch(), average, averageGk, i);

                UInt32 media = skills.calculateMaxRaking(i, goalkeeping, catching, clearing, reflexes, coverage, physicalContact, bodyControll, jump,
        header, defensiveProwess, ballWinning, speed, stamina, attackingProwess, ballControl, dribbling, loftedPass, explosivePower,
        lowPass, swerve, finishing, kickingPower);
                //MessageBox.Show(media.ToString());
                if (mediaMag < media)
                {
                    position = i;
                    mediaMag = media;
                }
            }
                
            posPlayer(gk, cb, lb, rb, dmf, cmf, lmf, amf, rmf, lwf, rwf, ss, cf, position);
        }

        public void calculatePosition(Fm temp)
        {
            Player player = getPlayer();

            if (temp.getGk() > 15)
                player.setGk(2);
            else if (temp.getGk() < 10)
                player.setGk(0);
            else
                player.setGk(1);

            //sw
            if (temp.getSw() > 15)
                player.setCb(2);
            else if (temp.getSw() < 10)
                player.setCb(0);
            else
                player.setCb(1);

            /*if (temp.getLb() > 15)
                player.setLb(2);
            else if (temp.getLb() < 10)
                player.setLb(0);
            else
                player.setLb(1);

            if (temp.getRb() > 15)
                player.setRb(2);
            else if (temp.getRb() < 10)
                player.setRb(0);
            else
                player.setRb(1);*/

            if (temp.getCb() > 15)
                player.setCb(2);
            else if (temp.getCb() < 10)
                player.setCb(0);
            else
                player.setCb(1);

            //wbl
            if (temp.getWbl() > 15)
                player.setLb(2);
            else if (temp.getLb() < 10)
                player.setLb(0);
            else
                player.setLb(1);

            //wbr
            if (temp.getWbr() > 15)
                player.setRb(2);
            else if (temp.getRb() < 10)
                player.setRb(0);
            else
                player.setRb(1);

            if (temp.getDm() > 15)
                player.setDmf(2);
            else if (temp.getDm() < 10)
                player.setDmf(0);
            else
                player.setDmf(1);

            if (temp.getRm() > 15)
                player.setRmf(2);
            else if (temp.getRm() < 10)
                player.setRmf(0);
            else
                player.setRmf(1);

            if (temp.getLm() > 15)
                player.setLmf(2);
            else if (temp.getLm() < 10)
                player.setLmf(0);
            else
                player.setLmf(1);

            if (temp.getCm() > 15)
                player.setCmf(2);
            else if (temp.getLm() < 10)
                player.setCmf(0);
            else
                player.setCmf(1);

            if (temp.getAml() > 15)
                player.setLwf(2);
            else if (temp.getAml() < 10)
                player.setLwf(0);
            else
                player.setLwf(1);

            if (temp.getAmr() > 15)
                player.setRwf(2);
            else if (temp.getAmr() < 10)
                player.setRwf(0);
            else
                player.setRwf(1);

            if (temp.getAmc() > 15)
                player.setAmf(2);
            else if (temp.getAmc() < 10)
                player.setAmf(0);
            else
                player.setAmf(1);

            if (temp.getSt() > 17)
                player.setSs(2);
            else if (temp.getSt() < 12)
                player.setSs(0);
            else
                player.setSs(1);

            if (temp.getSt() > 15)
                player.setCf(2);
            else if (temp.getSt() < 10)
                player.setCf(0);
            else
                player.setCf(1);
        }

        public void registredPosition(RadioButton gk, RadioButton cb, RadioButton lb, RadioButton rb, RadioButton dmf, RadioButton cmf,
            RadioButton lmf, RadioButton amf, RadioButton rmf, RadioButton lwf, RadioButton rwf, RadioButton ss, RadioButton cf)
        {
            Player player = getPlayer();
            if (gk.Checked == true)
                player.setPosition(0);
            else if (cb.Checked == true)
                player.setPosition(1);
            else if (lb.Checked == true)
                player.setPosition(2);
            else if (rb.Checked == true)
                player.setPosition(3);
            else if (dmf.Checked == true)
                player.setPosition(4);
            else if (cmf.Checked == true)
                player.setPosition(5);
            else if (lmf.Checked == true)
                player.setPosition(6);
            else if (amf.Checked == true)
                player.setPosition(7);
            else if (rmf.Checked == true)
                player.setPosition(8);
            else if (lwf.Checked == true)
                player.setPosition(9);
            else if (rwf.Checked == true)
                player.setPosition(10);
            else if (ss.Checked == true)
                player.setPosition(11);
            else if (cf.Checked == true)
                player.setPosition(12);
        }

        public UInt32 calculateStrongFoot(Fm player)
        {
            if (player.getLeftFoot() > player.getRightFoot())
                return 1;
            else
                return 0;
        }

        public UInt32 calculateInjuryRes(int naturalFitness) {
            if (naturalFitness > 11)
                return 3;
            if (naturalFitness < 5)
                return 1;

            return 2;
        }

        public UInt32 calculateForm(int stamina, int naturalFitness, int balance, UInt32 position)
        {
            //PORT
            if (position == 0)
                if ((1 + (naturalFitness * 0.15) + (stamina * 0.15) + (balance * 0.1008)) < 8)
                    return (uint)Math.Round((1 + (naturalFitness * 0.15) + (stamina * 0.15) + (balance * 0.1008)));
                else 
                    return 8;
            //DC//DL//MED
            else if (position == 1 || position == 2 || position == 3 || position == 4)
                return (uint)Math.Round((1 + (stamina + naturalFitness) / 2 * 0.3));
            //CC//CL//TRQ//EA//SP//P
            else
                return (uint)Math.Round((1 + (stamina * 0.2505 + naturalFitness * 0.505) * 0.3));
        }

        public UInt32 calculateWcUsage(int technique, UInt32 position)
        {
            //PORT
            if (position == 0)
                return (uint)Math.Round((1 + (technique * 0.15)));
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)Math.Round((1 + (technique * 0.1008)));
        }

        public UInt32 calculateWcAcc(int technique, int offTheBall, UInt32 position)
        {
            //PORT
            if (position == 0)
            {
                if ((1 + (offTheBall * 0.1 + technique * 0.1008)) < 4)
                    return (uint)Math.Round((1 + (technique * 0.1 + offTheBall * 0.1008)));
                else
                    return 4;
            }
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)Math.Round((1 + (offTheBall * 0.1008)));
        }

        public UInt32 calculateStamina(int stamina, int media, int mediaGk, int naturalFitness, int strenght, int workRate, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0) 
            {
                s = 36 + (stamina*59/19.0);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//DL//MED//CC//TRQ
            if (position == 1 || position == 2 || position == 3 || position == 4 || position == 5 || position == 7)
            {
                s = (37 + (workRate * 0.505)) + (naturalFitness * 0.505) + (strenght * 1.005) + (stamina * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL//EA
            if (position == 6 || position == 8 || position == 9 || position == 10)
            {
                s = 35 + (workRate * 0.505) + (naturalFitness * 0.505) + (strenght * 1.205) + (stamina * 1.205);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            if (position == 11)
            {
                s = 37 + (workRate * 0.505) + (naturalFitness * 0.705) + (strenght * 0.505) + (stamina * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P
            if (position == 12)
            {
                s = 37 + (workRate * 0.505) + (naturalFitness * 0.505) + (strenght * 0.7505) + (stamina * 1.25);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;

            return (uint)Math.Round(s);
        }

        public UInt32 calculateCoverage(int commandOfArea, int comunication, int positiong, int leadership, int gkRat, int media, int mediaGk, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 36;
                s += (commandOfArea * 0.7) + (comunication * 0.7) + (leadership  * 0.7) + (positiong * 0.7);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
                return (uint)Math.Round(s);
            }
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)(40);
            //(gkRat * 3.008)
        }

        public UInt32 calculateRflexes(int reflexes, int gkRat, int media, int mediaGk, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 36 + (reflexes * 59/19.0);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
                return (uint)Math.Round(s);
            }
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)(40);
            // + (gkRat * 3.008)
        }

        public UInt32 calculateClearing(int tendencyToPunch, int gkRat, int media, int mediaGk, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 37;
                s += (tendencyToPunch * 59 / 19.0);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
                return (uint)Math.Round(s);
            }
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)(40);
            // + (gkRat * 3.008)
        }

        public UInt32 calculateCatching(int handling, int gkRat, int media, int mediaGk, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 37;
                s += (handling * 59 / 19.0);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
                return (uint)Math.Round(s);
            }
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)(40);
            // + (gkRat * 3.008)
        }

        public UInt32 calculateGoalkeeping(int commandOfArea, int communication, int aerealAbility, int handling, 
            int throwing, int kicking, int oneOnOne, int tendencyToPunch, int concentration,
            int leadership, int positioning, int gkRat, int media, int mediaGk, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 44;
                s += (commandOfArea * 0.2505) + (communication * 0.2505) + (aerealAbility * 0.2505) + + (handling * 0.2505)
                     + (throwing * 0.2505) + (kicking * 0.2505) + (oneOnOne * 0.2505) + (tendencyToPunch * 0.2505) + (concentration * 0.2505)
                      + (leadership * 0.2505) + (positioning * 0.2505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
                return (uint)Math.Round(s);
            }
            //DC//DL//MED//CC//CL//TRQ//EA//SP//P
            else
                return (uint)(40);
            // + (gkRat * 3.008)
        }

        public UInt32 calculateJump(int jumpingReach, int agility, int strenght, int media, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 37;
                s += (jumpingReach * 59 / 19.0);
                return (uint)Math.Round(s);
            }
            //DC//TRQ//EA
            if (position == 1 || position == 7 || position == 9 || position == 10)
            {
                s = 37;
                s += (agility * 0.505) + (strenght * 0.505) + (jumpingReach * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                return (uint)Math.Round(s);
            }
            //DL
            else if (position == 2 || position == 3)
            {
                s = 35;
                s += (agility * 0.505) + (strenght * 0.505) + (jumpingReach * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                return (uint)Math.Round(s);
            }
            //MED//CC
            else if (position == 4 || position == 5)
            {
                s = 40;
                s += (agility * 0.505) + (strenght * 0.505) + (jumpingReach * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                return (uint)Math.Round(s);
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 33;
                s += (agility * 0.505) + (strenght * 0.505) + (jumpingReach * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                return (uint)Math.Round(s);
            }
            //SP//P
            else if (position == 11 || position == 12)
            {
                s = 37;
                s += (agility * 1.005) + (strenght * 0.505) + (jumpingReach * 1.5);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                return (uint)Math.Round(s);
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculatePhysicalContact(int positioning, int tackling, int excentricy, int workRate, int naturalFitness, int stamina, int media, int mediaGk, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 39 + (positioning * 0.5) + (excentricy * 0.2505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
                double s1 = 37 + (workRate * 0.5) + (naturalFitness * 0.5) + (stamina * 1.005);
                if (mediaGk >= 13)
                    s1 += 2;
                s = (s1 + s) * 0.7;
            }
            //DC//DL//MED
            else if (position == 1 || position == 2 || position == 3 || position == 4)
            {
                s = 39 + (positioning * 0.505) + (tackling * 0.2505);
                if (media >= 12)
                    s++;
                if (media >= 13)
                    s++;
                double s1 = 37 + (workRate * 0.505) + (naturalFitness * 0.505) + (stamina * 1.005);
                if (media >= 13)
                    s1 += 2;
                s = (s1 + s) * 0.65;
            }
            //CC//CL//TRQ
            else if (position == 5 || position == 6 || position == 7 || position == 8)
            {
                s = 39 + (positioning * 0.505) + (tackling * 0.2505);
                if (media >= 12)
                    s++;
                if (media >= 13)
                    s++;
                double s1 = 37 + (workRate * 0.505) + (naturalFitness * 0.505) + (stamina * 1.005);
                if (media >= 13)
                    s1 += 2;
                s = (s1 + s) * 0.6 ;
            }
            //EA//SP//P
            else if (position == 9 || position == 10 || position == 11 || position == 12)
            {
                s = 39 + (positioning * 0.505) + (tackling * 0.505);
                if (media >= 12)
                    s++;
                if (media >= 13)
                    s++;
                double s1 = 37 + (workRate * 0.505) + (naturalFitness * 0.505) + (stamina * 1.005);
                if (media >= 13)
                    s1 += 2;
                s = (s1 + s) * 0.60;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateBodyControll(int naturalFitness, int balance, int strenght, int media, UInt32 position)
        {
            //PORT
            double s = 0;
            if (position == 0)
            {
                s = 44 + (naturalFitness * 0.505) + (balance * 0.705) + (strenght * 0.505);
            }
            //CD//DL//MED
            else if (position == 1 || position == 2 || position == 3 || position == 4)
            {
                s = 37 + (naturalFitness * 1.005) + (balance * 1.005) + (strenght * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 37 + (naturalFitness * 1.005) + (balance * 0.7505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA//CL
            else if (position == 9 || position == 10 || position == 6 || position == 8)
            {
                s = 37 + (naturalFitness * 0.705) + (balance * 1.005) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P//SP//CC
            else if (position == 5 || position == 11 || position == 12)
            {
                s = 37 + (naturalFitness * 1.005) + (balance * 1.005) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateExplosivePower(int naturalFitness, int agility, int acceleration, int strenght, int stamina, int determination, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 37 + (acceleration * 1.005) + (agility * 0.505) + (strenght * 0.505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC
            else if (position == 1)
            {
                s = 37 + (acceleration * 0.505) + (naturalFitness * 0.505) + (strenght * 0.505) + (stamina * 0.205) + (determination * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC//MED//DL
            else if (position == 2 || position == 3 || position == 4 || position == 5)
            {
                s = 39 + (acceleration * 0.505) + (naturalFitness * 0.505) + (strenght * 0.505) + (stamina * 0.505) + (determination * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 39 + (acceleration * 0.7505) + (naturalFitness * 0.7505) + (strenght * 0.7505) + (stamina * 0.7505) + (determination * 0.2505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 39 + (acceleration * 0.505) + (naturalFitness * 0.7505) + (strenght * 0.505) + (stamina * 0.505) + (determination * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 40 + (acceleration * 0.705) + (naturalFitness * 0.505) + (strenght * 0.505) + (stamina * 0.705) + (determination * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 37 + (acceleration * 0.2505) + (naturalFitness * 0.7505) + (strenght * 0.7505) + (stamina * 1.005) + (determination * 0.2505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P
            else if (position == 12)
            {
                s = 37 + (acceleration * 0.7505) + (naturalFitness * 0.7505) + (strenght * 0.7505) + (stamina * 0.505) + (determination * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateSpeed(int pace, int acceleration, int naturalFitness, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 37 + (pace * 59 / 19.0);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//CC//CL
            else if (position == 1 || position == 5)
            {
                s = 37 + (acceleration * 0.505) + (naturalFitness * 0.505) + (pace * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //DL//MED
            else if (position == 2 || position == 3 || position == 4)
            {
                s = 33 + (acceleration * 0.505) + (naturalFitness * 0.505) + (pace * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ//EA
            else if (position == 7 || position == 9 || position == 10)
            {
                s = 37 + (acceleration * 0.505) + (naturalFitness * 0.2505) + (pace * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 37 + (acceleration * 0.505) + (naturalFitness * 0.505) + (pace * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 37 + (acceleration * 0.505) + (naturalFitness * 0.505) + (pace * 1.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P
            else if (position == 12)
            {
                s = 37 + (acceleration * 0.505) + (naturalFitness * 0.505) + (pace * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateKickingPower(int passing, int eccentricity, int strenght, int freeKickTaking, int penaltyTaking,
            int longShots, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 38 + (passing * 1.005) + (eccentricity * 1.005) + (strenght * 1.005);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC
            else if (position == 1)
            {
                s = 37 + (freeKickTaking * 0.7505) + (penaltyTaking * 1.005) + (longShots * 0.7505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //DL
            else if (position == 2 || position == 3)
            {
                s = 37 + (freeKickTaking * 1.005) + (penaltyTaking * 1.005) + (longShots * 1.005) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED
            else if (position == 4)
            {
                s = 33 + (freeKickTaking * 1.005) + (penaltyTaking * 1.005) + (longShots * 1.005) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC
            else if (position == 5)
            {
                s = 40 + (freeKickTaking * 0.7505) + (penaltyTaking * 0.505) + (longShots * 0.505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 40 + (freeKickTaking * 1.005) + (penaltyTaking * 0.505) + (longShots * 0.505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 40 + (freeKickTaking * 0.7505) + (penaltyTaking * 0.7505) + (longShots * 0.7505) + (strenght * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 37 + (freeKickTaking * 0.7505) + (penaltyTaking * 0.7505) + (longShots * 0.7505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 35 + (freeKickTaking * 1.005) + (penaltyTaking * 1.005) + (longShots * 0.505) + (strenght * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P
            else if (position == 12)
            {
                s = 37 + (freeKickTaking * 1.005) + (penaltyTaking * 1.005) + (longShots * 0.505) + (strenght * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateBallWinning(int aggression, int eccentricity, int positioning, int marking, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 39 + (aggression * 0.2505) + (eccentricity * 0.2505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//DL
            else if (position == 1)
            {
                s = 37 + (aggression * 0.505) + (marking * 1.005) + (positioning * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //DL
            else if (position == 2 || position == 3)
            {
                s = 35 + (aggression * 0.505) + (marking * 1.005) + (positioning * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED
            else if (position == 4)
            {
                s = 36 + (aggression * 0.505) + (marking * 1.005) + (positioning * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC
            else if (position == 5)
            {
                s = 36 + (aggression * 0.2505) + (marking * 1.005) + (positioning * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 39 + (aggression * 0.2505) + (marking * 0.7505) + (positioning * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 39 + (aggression * 1.005) + (marking * 0.7505) + (positioning * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 39 + (aggression * 0.7505) + (marking * 0.2505) + (positioning * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 37 + (aggression * 0.7505) + (marking * 0.2505) + (positioning * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P
            else if (position == 12)
            {
                s = 37 + (aggression * 0.505) + (marking * 0.505) + (positioning * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateDefensiveProwess(int positioning, int aggression, int eccentricity, int concentration, int teamwork, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 39 + (positioning * 0.2505) + (aggression * 0.2505) + (eccentricity * 0.2505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC
            else if (position == 1)
            {
                s = 37 + (aggression * 0.7505) + (concentration * 0.7505) + (positioning * 0.7505) + (teamwork * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED
            else if (position == 4)
            {
                s = 37 + (aggression * 0.505) + (concentration * 0.7505) + (positioning * 0.7505) + (teamwork * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //DL
            else if (position == 2 || position == 3)
            {
                s = 30 + (aggression * 0.505) + (concentration * 0.7505) + (positioning * 0.7505) + (teamwork * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC
            else if (position == 5)
            {
                s = 35 + (aggression * 0.2505) + (concentration * 0.7505) + (positioning * 0.7505) + (teamwork * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 39 + (aggression * 0.2505) + (concentration * 0.505) + (positioning * 0.505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 39 + (aggression * 1.005) + (concentration * 0.505) + (positioning * 0.505) + (teamwork * 0.2505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 37 + (aggression * 0.2505) + (concentration * 0.2505) + (positioning * 0.2505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP//P
            else if (position == 11 || position == 12)
            {
                s = 37 + (aggression * 0.2505) + (concentration * 0.2505) + (positioning * 0.2505) + (teamwork * 0.2505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateHeader(int eccentricity, int rushingOut, int aerialAbility, int jumpingReach, int heading,
            int anticipation, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 38 + (rushingOut * 0.7505) + (eccentricity * 0.2505) + (aerialAbility * 0.2505) + (jumpingReach * 0.505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//CL
            else if (position == 1 || position == 6 || position == 8)
            {
                s = 37 + (heading * 2.005) + (anticipation * 0.2505) + (jumpingReach * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED//DL
            else if (position == 2 || position == 3 ||position == 4)
            {
                s = 34 + (heading * 2.005) + (anticipation * 0.2505) + (jumpingReach * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC
            else if (position == 5)
            {
                s = 40 + (heading * 2.005) + (anticipation * 0.2505) + (jumpingReach * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 37 + (heading * 2.005) + (anticipation * 0.2505) + (jumpingReach * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 39 + (heading * 2.005) + (anticipation * 0.2505) + (jumpingReach * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 37 + (heading * 2.005) + (anticipation * 0.505) + (jumpingReach * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //P
            else if (position == 12)
            {
                s = 37 + (heading * 1.5) + (anticipation * 0.505) + (jumpingReach * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateSwerve(int passing, int freeKickTaking, int technique, int corners, int firstTouch, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 38 + (passing * 0.505) + (freeKickTaking * 0.505) + (technique * 0.505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//DL//MED//CC//CL
            else if (position == 1 || position == 2 || position == 3 || position == 4 || position == 5 || position == 6 || position == 8)
            {
                s = 37 + (freeKickTaking * 1.005) + (corners * 1.005) + (technique * 0.505) + (firstTouch * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ//P
            else if (position == 7 || position == 12)
            {
                s = 40 + (freeKickTaking * 0.7505) + (corners * 0.7505) + (technique * 0.505) + (firstTouch * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 40 + (freeKickTaking * 0.7505) + (corners * 0.7505) + (technique * 0.505) + (firstTouch * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 37 + (freeKickTaking * 0.7505) + (corners * 0.7505) + (technique * 0.505) + (firstTouch * 0.7505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculatePlaceKicking(int composure, int determination, int technique, int freeKickTaking, int strenght,
            int leadership, int media, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 44 + (composure * 0.2505) + (determination * 0.2505) + (technique * 0.2505) + (freeKickTaking * 0.2505) + (strenght * 0.2505);
            }
            //DC
            else if (position == 1)
            {
                s = 37 + (freeKickTaking * 1.005) + (composure * 0.2505) + (leadership * 0.505) + (strenght * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED//DL
            else if (position == 4 || position == 2 || position == 3)
            {
                s = 39 + (freeKickTaking * 1.005) + (composure * 0.2505) + (leadership * 0.505) + (strenght * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC
            else if (position == 5)
            {
                s = 39 + (freeKickTaking * 1.005) + (composure * 0.505) + (leadership * 0.505) + (strenght * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 37 + (freeKickTaking * 1.005) + (composure * 0.505) + (leadership * 0.505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 37 + (freeKickTaking * 1.5) + (composure * 0.505) + (leadership * 0.505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA//P
            else if (position == 9 || position == 10 || position == 12)
            {
                s = 39 + (freeKickTaking * 1.005) + (composure * 0.2505) + (leadership * 0.505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP
            else if (position == 11)
            {
                s = 37 + (freeKickTaking * 1.5) + (composure * 0.505) + (leadership * 0.505) + (strenght * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateLoftedPass(int passing, int kicking, int eccentricity, int corners, int longThrows, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 38 + (passing * 1.005) + (kicking * 1.005) + (eccentricity * 0.505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC
            else if (position == 1)
            {
                s = 39 + (corners * 0.505) + (longThrows * 2.005) + (passing * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //DL
            else if (position == 2 || position == 3)
            {
                s = 39 + (corners * 0.505) + (longThrows * 2.005) + (passing * 0.705);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED//CC
            else if (position == 4 || position == 5)
            {
                s = 42 + (corners * 0.705) + (longThrows * 2.005) + (passing * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL//TRQ
            else if (position == 6 || position == 8 || position == 7)
            {
                s = 37 + (corners * 0.505) + (longThrows * 0.505) + (passing * 2.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA
            else if (position == 9 || position == 10)
            {
                s = 39 + (corners * 0.705) + (longThrows * 0.7505) + (passing * 1.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP//P
            else if (position == 11 || position == 12)
            {
                s = 37 + (corners * 0.505) + (longThrows * 0.7505) + (passing * 1.705);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateLowPass(int eccentricity, int firstTouch, int passing, int decisions, int vision, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 38 + (firstTouch * 1.005) + (eccentricity * 1.005);
                if (mediaGk >= 13)
                    s++;
                if (mediaGk >= 14)
                    s++;
            }
            //DC
            else if (position == 1)
            {
                s = 39 + (passing * 1.005) + (decisions * 0.505) + (vision * 0.705);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //MED//DL//CC
            else if (position == 4 || position == 2 || position == 3 || position == 5)
            {
                s = 35 + (passing * 2.005) + (decisions * 0.505) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 36 + (passing * 2.005) + (decisions * 0.505) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 37 + (passing * 2.005) + (decisions * 0.505) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA//SP//P
            else if (position == 9 || position == 10 || position == 11 || position == 12)
            {
                s = 37 + (passing * 1.205) + (decisions * 0.505) + (vision * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateDribbling(int frair, int eccentricity, int dribbling, int firstTouch, int technique, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 38 + (frair * 1.005) + (eccentricity * 0.7505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//DL////MED//CC//CL
            else if (position == 1 || position == 2 || position == 3 || position == 4 || position == 5 || position == 6 || position == 8)
            {
                s = 37 + (dribbling * 2.005) + (firstTouch * 0.505) + (technique * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ//EA
            else if (position == 7 || position == 9 || position == 10)
            {
                s = 37 + (dribbling * 2.005) + (firstTouch * 0.505) + (technique * 0.2505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP//P
            else if (position == 11 || position == 12)
            {
                s = 37 + (dribbling * 1.75) + (firstTouch * 0.505) + (technique * 0.2505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateBallControll(int firstTouch, int eccentricity, int technique, int vision, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 36 + (firstTouch * 1.005) + (eccentricity * 1.005);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//MED
            else if (position == 1 || position == 4)
            {
                s = 37 + (firstTouch * 0.505) + (technique * 2.005) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //DL
            else if (position == 2 || position == 3)
            {
                s = 37 + (firstTouch * 1.005) + (technique * 1.005) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CC
            else if (position == 5)
            {
                s = 37 + (firstTouch * 1.25) + (technique * 1.005) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 38 + (firstTouch * 1.25) + (technique * 1.005) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 40 + (firstTouch * 1.25) + (technique * 0.505) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //EA//SP//P
            else if (position == 9 || position == 10 || position == 11 || position == 12)
            {
                s = 40 + (firstTouch * 1.005) + (technique * 1.005) + (vision * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateAttackingProwness(int offTheBall, int teamwork, int finishing, int firstTouch, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 37 + (offTheBall * 0.2505) + (teamwork * 0.2505);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC
            else if (position == 1)
            {
                s = 37 + (finishing * 0.7505) + (firstTouch * 0.505) + (offTheBall * 0.7505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 19)
                    s += 4;
            }
            //MED//DL
            else if (position == 4 || position == 2 || position == 3)
            {
                s = 39 + (finishing * 0.7505) + (firstTouch * 0.505) + (offTheBall * 0.7505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 19)
                    s += 4;
            }
            //CC
            else if (position == 5)
            {
                s = 37 + (finishing * 0.7505) + (firstTouch * 0.7505) + (offTheBall * 0.7505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 19)
                    s += 4;
            }
            //CL
            else if (position == 6 || position == 8)
            {
                s = 38 + (finishing * 0.7505) + (firstTouch * 0.7505) + (offTheBall * 0.7505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 19)
                    s += 4;
            }
            //TRQ//EA//SP//P
            else if (position == 7 || position == 9 || position == 10 || position == 11 || position == 12)
            {
                s = 40 + (finishing * 0.7505) + (firstTouch * 0.505) + (offTheBall * 0.7505) + (teamwork * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + offTheBall + teamwork) / 3.0) >= 19)
                    s += 4;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public UInt32 calculateFinishing(int penaltyTaking, int freeKickTaking, int vision, int finishing, int longShots, int composure, int media, int mediaGk, UInt32 position)
        {
            double s = 0;
            //POR
            if (position == 0)
            {
                s = 37 + (penaltyTaking * 0.505) + (freeKickTaking * 0.505) + (vision * 1.005);
                if (mediaGk >= 12)
                    s++;
                if (mediaGk >= 13)
                    s++;
            }
            //DC//CC
            else if (position == 1)
            {
                s = 37 + (finishing * 0.505) + (longShots * 0.505) + (composure * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 19)
                    s += 4;
            }
            //CC
            else if (position == 5)
            {
                s = 40 + (finishing * 0.505) + (longShots * 0.505) + (composure * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 15)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 16)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 17)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 18)
                    s += 4;
                if (Math.Round((finishing + longShots + composure) / 3.0) >= 19)
                    s += 4;
            }
            //MED//DL//CL//EA
            else if (position == 4 || position == 2 || position == 3 || position == 6 || position == 8 || position == 9 || position == 10)
            {
                s = 37 + (finishing * 2.005) + (longShots * 0.505) + (composure * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //TRQ
            else if (position == 7)
            {
                s = 37 + (finishing * 1.005) + (longShots * 0.7505) + (composure * 1.005);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }
            //SP//P
            else if (position == 11 || position == 12)
            {
                s = 37 + (finishing * 1.75) + (longShots * 0.7505) + (composure * 0.505);
                if (media >= 13)
                    s++;
                if (media >= 14)
                    s++;
            }

            if (s < 40)
                s = 40;
            return (uint)Math.Round(s);
        }

        public double media(int uno, int due, int quattro, int xinque, int sei, int sette, int otto, int nove, int dieci,
            int undici, int dodoci, int tredici, int quattordici, int quindici, int sedici, int diciasette, int diciotto, int diciannove,
            int venti, int ventuno, int ventidue, int ventitre, int ventiquattro, int venticinque, int ventisei, int ventisette, int ventotto
            , int ventinove, int trenta, int trentuno, int trentadue, int trentatre, int trentaquattro, int trentacinque, int trentasei,
            int trentasette)
        {
            return (uno + due + quattro + xinque + sei + sette + otto + nove + dieci +
             undici + dodoci + tredici + quattordici + quindici + sedici + diciasette + diciotto + diciannove +
             venti + ventuno + ventidue + ventitre + ventiquattro + venticinque + ventisei + ventisette + ventotto
             + ventinove + trenta + trentuno + trentadue + trentatre + trentaquattro + trentacinque + trentasei +
             trentasette) / 36;
        }

        public double mediaGk(int uno, int due, int quattro, int xinque, int sei, int sette, int otto, int nove, int dieci,
            int undici, int dodoci, int tredici, int quattordici, int quindici, int sedici, int diciasette, int diciotto, int diciannove,
            int venti, int ventuno, int ventidue, int ventitre, int ventiquattro, int venticinque, int ventisei, int ventisette, int ventotto
            , int ventinove, int trenta, int trentuno, int trentadue, int trentatre, int trentaquattro, int trentacinque, int trentasei,
            int trentasette, int trentotto, int trentanove)
        {
            return (uno + due + quattro + xinque + sei + sette + otto + nove + dieci +
             undici + dodoci + tredici + quattordici + quindici + sedici + diciasette + diciotto + diciannove +
             venti + ventuno + ventidue + ventitre + ventiquattro + venticinque + ventisei + ventisette + ventotto
             + ventinove + trenta + trentuno + trentadue + trentatre + trentaquattro + trentacinque + trentasei +
             trentasette + trentotto + trentanove) / 38;
        }

    }
}

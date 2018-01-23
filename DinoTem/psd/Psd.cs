using System.Windows.Forms;
using System;
using Ini;
using System.IO;

namespace Team_Editor_Manager_New_Generation.psd
{
    //pes 18, 17
    public class Psd
    {
        private string a;

        public Psd()
        {
            this.a = "";
        }

        private string unidecodeCopyPaste()
        {
            a = Clipboard.GetText();
            //vocali
            a = a.Replace("á", "a");
            a = a.Replace("ö", "o");
            a = a.Replace("ø", "o");
            a = a.Replace("ě", "e");
            a = a.Replace("ë", "e");
            //consonanti
            a = a.Replace("ć", "c");
            a = a.Replace("ř", "r");
            a = a.Replace("Š", "S");
            a = a.Replace("š", "s");
            a = a.Replace("ý", "y");
            a = a.Replace("ž", "z");

            return a;
        }

        private string createPSD()
        {
            string a = unidecodeCopyPaste();
            a = a.Trim();
            a = a.Replace("Name: ", "Name:");
            a = a.Replace("Shirt Name:", Environment.NewLine + "Shirt Name:");
            a = a.Replace("Shirt Number ", Environment.NewLine + "Shirt Number");
            a = a.Replace("Nationality: ", Environment.NewLine + "Nationality:");
            a = a.Replace("Player Styles: ", Environment.NewLine + "Player Styles:");
            a = a.Replace("Height: ", Environment.NewLine + "Height:");
            a = a.Replace("Weight: ", Environment.NewLine + "Weight:");
            a = a.Replace("Foot: ", Environment.NewLine + "Foot:");
            a = a.Replace("Age: ", Environment.NewLine + "Age:");
            a = a.Replace("Registered Position: ", Environment.NewLine + "Registered Position:");
            a = a.Replace("Playable Positions: ", Environment.NewLine + "Playable Positions:");
            a = a.Replace("Ability Settings", Environment.NewLine + "Ability Settings");
            a = a.Replace("Attacking Prowess: ", Environment.NewLine + "Attacking Prowess:");
            a = a.Replace("Ball Control: ", Environment.NewLine + "Ball Control:");
            a = a.Replace("Dribbling: ", Environment.NewLine + "Dribbling:");
            a = a.Replace("Low Pass: ", Environment.NewLine + "Low Pass:");
            a = a.Replace("Lofted Pass: ", Environment.NewLine + "Lofted Pass:");
            a = a.Replace("Finishing: ", Environment.NewLine + "Finishing:");
            a = a.Replace("Place Kicking: ", Environment.NewLine + "Place Kicking:");
            a = a.Replace("Swerve: ", Environment.NewLine + "Swerve:");
            a = a.Replace("Header: ", Environment.NewLine + "Header:");
            a = a.Replace("Defence Prowess: ", Environment.NewLine + "Defence Prowess:");
            a = a.Replace("Ball Winning: ", Environment.NewLine + "Ball Winning:");
            a = a.Replace("Kicking Power: ", Environment.NewLine + "Kicking Power:");
            a = a.Replace("Speed: ", Environment.NewLine + "Speed:");
            a = a.Replace("Explosive Power: ", Environment.NewLine + "Explosive Power:");
            a = a.Replace("Body Control: ", Environment.NewLine + "Body Control:");
            a = a.Replace("Physical Contact: ", Environment.NewLine + "Physical Contact:");
            a = a.Replace("Jump: ", Environment.NewLine + "Jump:");
            a = a.Replace("Goalkeeping: ", Environment.NewLine + "Goalkeeping:");
            a = a.Replace("Catching: ", Environment.NewLine + "Catching:");
            a = a.Replace("Clearing: ", Environment.NewLine + "Clearing:");
            a = a.Replace("Reflexes: ", Environment.NewLine + "Reflexes:");
            a = a.Replace("Coverage: ", Environment.NewLine + "Coverage:");
            a = a.Replace("Stamina: ", Environment.NewLine + "Stamina:");
            a = a.Replace("Weak Foot Usage: ", Environment.NewLine + "Weak Foot Usage:");
            a = a.Replace("Weak Foot Accuracy: ", Environment.NewLine + "Weak Foot Accuracy:");
            a = a.Replace("Form: ", Environment.NewLine + "Form:");
            a = a.Replace("Injury Tolerance: ", Environment.NewLine + "Injury Tolerance:");
            a = a.Replace(":", "=");

            a = a.Replace("*", "");
            a = a.Replace(" kg", "");
            a = a.Replace(" cm", "");
            a = a.Replace("<Player Skills>", "[Player Skills]");
            a = a.Replace("<COM Playing Styles>", "[COM Playing Styles]");

            a = a.Replace("01 - ", "01=");
            a = a.Replace("02 - ", "02=");
            a = a.Replace("03 - ", "03=");
            a = a.Replace("04 - ", "04=");
            a = a.Replace("05 - ", "05=");
            a = a.Replace("06 - ", "06=");
            a = a.Replace("07 - ", "07=");
            a = a.Replace("08 - ", "08=");
            a = a.Replace("09 - ", "09=");
            a = a.Replace("10 - ", "10=");
            a = a.Replace("11 - ", "11=");
            a = a.Replace("12 - ", "12=");
            a = a.Replace("13 - ", "13=");
            a = a.Replace("14 - ", "14=");
            a = a.Replace("15 - ", "15=");
            a = a.Replace("16 - ", "16=");
            a = a.Replace("17 - ", "17=");
            a = a.Replace("18 - ", "18=");
            a = a.Replace("19 - ", "19=");
            a = a.Replace("20 - ", "20=");
            a = a.Replace("21 - ", "21=");
            a = a.Replace("22 - ", "22=");
            a = a.Replace("23 - ", "23=");
            a = a.Replace("24 - ", "24=");
            a = a.Replace("25 - ", "25=");
            a = a.Replace("26 - ", "26=");
            a = a.Replace("27 - ", "27=");
            a = a.Replace("28 - ", "28=");

            a = "[PLAYER]" + Environment.NewLine + a;

            return a;
        }

        public void generatePSD(TextBox giocatoreName, TextBox giocatoreShirt, ComboBox Playing_Style, ComboBox giocatoreNazionalità, ComboBox Nazionalità_2, TextBox giocatoreAge, TextBox giocatoreWeight, TextBox giocatoreHeight, ComboBox giocatoreFoot, ComboBox position, ComboBox GK, ComboBox CB, ComboBox LB, ComboBox RB, ComboBox DMF, ComboBox CMF, ComboBox LMF, ComboBox AMF, ComboBox RMF, ComboBox LWF, ComboBox RWF, ComboBox SS, ComboBox CF, 
            TextBox attack, TextBox ballControll, TextBox dribbling, TextBox lowPass, TextBox loftedPass, TextBox finishing, TextBox placeKick, TextBox swerve,
            TextBox header, TextBox defense, TextBox ballWinning, TextBox kickingPower, TextBox speed, TextBox explosivePower, TextBox BodyControll, TextBox physical, TextBox jump, TextBox goalkeeping, TextBox cathing, TextBox clearing, TextBox reflexes, TextBox coverage, TextBox stamina, ComboBox We_acc, ComboBox We_usage, ComboBox Forma, ComboBox Injury, CheckBox fighting_spirit, CheckBox acrobatic_clear, CheckBox knucle_shot,
            CheckBox first_time_shot, CheckBox long_throw, CheckBox man_marking, CheckBox outside_curler, CheckBox marseille_turn, CheckBox scoth_move, CheckBox gk_long_throw, CheckBox cut_behind_turn, CheckBox scissors_feint, CheckBox low_lofted_pass, CheckBox one_touch_pass, CheckBox weighted_pass, 
            CheckBox acrobatic_finishing, CheckBox pinpoint_crossing, CheckBox low_punt_trajectory, CheckBox long_range_drive, CheckBox flip_flap, CheckBox rabona, CheckBox malicia, CheckBox sombrero, CheckBox heading, CheckBox hell_trick, CheckBox track_back, CheckBox super_sub, CheckBox captaincy, CheckBox trickster, CheckBox mazing_run, CheckBox long_ball_expert, CheckBox incisive_run, CheckBox speeding_bullet, CheckBox early_cross, CheckBox long_ranger)
        {
            string a = createPSD();

            using (StreamWriter writer = new StreamWriter(Application.StartupPath + @"\Temp\p.temp"))
            {
                writer.Write(a);
            }

            IniFile ini = new IniFile(Application.StartupPath + @"\Temp\p.temp");

            //general
            giocatoreName.Text = ini.IniReadValue("PLAYER", "Name");
            giocatoreShirt.Text = ini.IniReadValue("PLAYER", "Shirt Name");
            if (ini.IniReadValue("PLAYER", "Player Styles") == "-")
                Playing_Style.Text = "N/A";
            else
                Playing_Style.Text = ini.IniReadValue("PLAYER", "Player Styles");

            string n = ini.IniReadValue("PLAYER", "Nationality");
            n = n.Substring(0, n.Length - 2);
            giocatoreNazionalità.Text = n.ToUpper();
            Nazionalità_2.Text = "No second National";
            giocatoreAge.Text = ini.IniReadValue("PLAYER", "Age");
            giocatoreWeight.Text = ini.IniReadValue("PLAYER", "Weight");
            giocatoreHeight.Text = ini.IniReadValue("PLAYER", "Height");
            if (ini.IniReadValue("PLAYER", "Foot") == "L")
                giocatoreFoot.Text = "Left";
            else
                giocatoreFoot.Text = "Right";

            position.Text = ini.IniReadValue("PLAYER", "Registered Position");
            if (ini.IniReadValue("PLAYER", "Registered Position") == "WF")
                if (giocatoreFoot.Text == "Left")
                    position.Text = "LWF";
                else if (giocatoreFoot.Text == "Right")
                    position.Text = "RWF";

            if (ini.IniReadValue("PLAYER", "Registered Position") == "SB")
                if (giocatoreFoot.Text == "Left")
                    position.Text = "LB";
                else if (giocatoreFoot.Text == "Right")
                    position.Text = "RB";

            if (ini.IniReadValue("PLAYER", "Registered Position") == "SW")
                position.Text = "CB";

            if (ini.IniReadValue("PLAYER", "Registered Position") == "WB")
                if (giocatoreFoot.Text == "Left")
                    position.Text = "LMF";
                else if (giocatoreFoot.Text == "Right")
                    position.Text = "RMF";
            
            //playable position
            GK.Text = "C";
            CB.Text = "C";
            LB.Text = "C";
            RB.Text = "C";
            DMF.Text = "C";
            CMF.Text = "C";
            LMF.Text = "C";
            AMF.Text = "C";
            RMF.Text = "C";
            LWF.Text = "C";
            RWF.Text = "C";
            SS.Text = "C";
            CF.Text = "C";
            string p = ini.IniReadValue("PLAYER", "Playable Positions");
            string[] words = p.Split(',');
            //if player hasn't position
            if (words[0] == "")
                if (ini.IniReadValue("PLAYER", "Registered Position") == "GK")
                {
                    GK.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "CB")
                {
                    CB.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "SW")
                {
                    CB.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "SB")
                {
                    if (giocatoreFoot.Text == "Left")
                        LB.Text = "A";
                    else if (giocatoreFoot.Text == "Right")
                        RB.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "LB")
                {
                    LB.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "RB")
                {
                    RB.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "DMF")
                {
                    DMF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "CMF")
                {
                    CMF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "WB")
                {
                    if (giocatoreFoot.Text == "Left")
                        LMF.Text = "A";
                    else if (giocatoreFoot.Text == "Right")
                        RMF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "LMF")
                {
                    LMF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "AMF")
                {
                    AMF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "RMF")
                {
                    RMF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "WF")
                {
                    if (giocatoreFoot.Text == "Left")
                        LWF.Text = "A";
                    else if (giocatoreFoot.Text == "Right")
                        RWF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "LWF")
                {
                    LWF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "RWF")
                {
                    RWF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "SS")
                {
                    SS.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "CF")
                {
                    CF.Text = "A";
                }
                else if (ini.IniReadValue("PLAYER", "Registered Position") == "")
                {
                }

            foreach (string word in words)
            {
                string b = word.Trim(new Char[] { ' ' });

                if (b == "GK")
                {
                    GK.Text = "A";
                }
                else if (b == "CB")
                {
                    CB.Text = "A";
                }
                else if (b == "SW")
                {
                    CB.Text = "A";
                }
                else if (b == "SB")
                {
                    if (giocatoreFoot.Text == "Left")
                        LB.Text = "A";
                    else if (giocatoreFoot.Text == "Right")
                        RB.Text = "A";
                }
                else if (b == "LB")
                {
                    LB.Text = "A";
                }
                else if (b == "RB")
                {
                    RB.Text = "A";
                }
                else if (b == "DMF")
                {
                    DMF.Text = "A";
                }
                else if (b == "CMF")
                {
                    CMF.Text = "A";
                }
                else if (b == "WB")
                {
                    if (giocatoreFoot.Text == "Left")
                        LMF.Text = "A";
                    else if (giocatoreFoot.Text == "Right")
                        RMF.Text = "A";
                }
                else if (b == "LMF")
                {
                    LMF.Text = "A";
                }
                else if (b == "AMF")
                {
                    AMF.Text = "A";
                }
                else if (b == "RMF")
                {
                    RMF.Text = "A";
                }
                else if (b == "WF")
                {
                    if (giocatoreFoot.Text == "Left")
                        LWF.Text = "A";
                    else if (giocatoreFoot.Text == "Right")
                        RWF.Text = "A";
                }
                else if (b == "LWF")
                {
                    LWF.Text = "A";
                }
                else if (b == "RWF")
                {
                    RWF.Text = "A";
                }
                else if (b == "SS")
                {
                    SS.Text = "A";
                }
                else if (b == "CF")
                {
                    CF.Text = "A";
                }
                else if (b == "")
                {
                }
            }
            
            attack.Text = ini.IniReadValue("PLAYER", "Attacking Prowess");
            ballControll.Text = ini.IniReadValue("PLAYER", "Ball Control");
            dribbling.Text = ini.IniReadValue("PLAYER", "Dribbling");
            lowPass.Text = ini.IniReadValue("PLAYER", "Low Pass");
            loftedPass.Text = ini.IniReadValue("PLAYER", "Lofted Pass");
            finishing.Text = ini.IniReadValue("PLAYER", "Finishing");
            placeKick.Text = ini.IniReadValue("PLAYER", "Place Kicking");
            swerve.Text = ini.IniReadValue("PLAYER", "Swerve");
            header.Text = ini.IniReadValue("PLAYER", "Header");
            defense.Text = ini.IniReadValue("PLAYER", "Defence Prowess");
            ballWinning.Text = ini.IniReadValue("PLAYER", "Ball Winning");
            kickingPower.Text = ini.IniReadValue("PLAYER", "Kicking Power");
            speed.Text = ini.IniReadValue("PLAYER", "Speed");
            explosivePower.Text = ini.IniReadValue("PLAYER", "Explosive Power");
            BodyControll.Text = ini.IniReadValue("PLAYER", "Body Control");
            physical.Text = ini.IniReadValue("PLAYER", "Physical Contact");
            jump.Text = ini.IniReadValue("PLAYER", "Jump");
            goalkeeping.Text = ini.IniReadValue("PLAYER", "Goalkeeping");
            cathing.Text = ini.IniReadValue("PLAYER", "Catching");
            clearing.Text = ini.IniReadValue("PLAYER", "Clearing");
            reflexes.Text = ini.IniReadValue("PLAYER", "Reflexes");
            coverage.Text = ini.IniReadValue("PLAYER", "Coverage");
            stamina.Text = ini.IniReadValue("PLAYER", "Stamina");
            We_acc.Text = ini.IniReadValue("PLAYER", "Weak Foot Usage");
            We_usage.Text = ini.IniReadValue("PLAYER", "Weak Foot Accuracy");
            Forma.Text = ini.IniReadValue("PLAYER", "Form");
            Injury.Text = ini.IniReadValue("PLAYER", "Injury Tolerance");
            
            //player skills
            fighting_spirit.Checked = false;
            acrobatic_clear.Checked = false;
            knucle_shot.Checked = false;
            first_time_shot.Checked = false;
            long_throw.Checked = false;
            man_marking.Checked = false;
            outside_curler.Checked = false;
            marseille_turn.Checked = false;
            scoth_move.Checked = false;
            gk_long_throw.Checked = false;
            cut_behind_turn.Checked = false;
            scissors_feint.Checked = false;
            low_lofted_pass.Checked = false;
            one_touch_pass.Checked = false;
            weighted_pass.Checked = false;
            acrobatic_finishing.Checked = false;
            pinpoint_crossing.Checked = false;
            low_punt_trajectory.Checked = false;
            long_range_drive.Checked = false;
            flip_flap.Checked = false;
            rabona.Checked = false;
            malicia.Checked = false;
            sombrero.Checked = false;
            heading.Checked = false;
            hell_trick.Checked = false;
            track_back.Checked = false;
            super_sub.Checked = false;
            captaincy.Checked = false;
            trickster.Checked = false;
            mazing_run.Checked = false;
            long_ball_expert.Checked = false;
            incisive_run.Checked = false;
            speeding_bullet.Checked = false;
            early_cross.Checked = false;
            long_ranger.Checked = false;

            //player skills
            if (ini.IniReadValue("Player Skills", "01") == "Scissor Feint")
            {
                scissors_feint.Checked = true;
            }
            else
            {
                scissors_feint.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "02") == "Flip Flap")
            {
                flip_flap.Checked = true;
            }
            else
            {
                flip_flap.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "03") == "Marseille Turn")
            {
                marseille_turn.Checked = true;
            }
            else
            {
                marseille_turn.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "04") == "Sombrero")
            {
                sombrero.Checked = true;
            }
            else
            {
                sombrero.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "05") == "Cut Behind & Turn")
            {
                cut_behind_turn.Checked = true;
            }
            else
            {
                cut_behind_turn.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "08") == "Long Range Drive")
            {
                long_range_drive.Checked = true;
            }
            else
            {
                long_range_drive.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "09") == "Knuckle Shot")
            {
                knucle_shot.Checked = true;
            }
            else
            {
                knucle_shot.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "10") == "Acrobatic Finish")
            {
                acrobatic_finishing.Checked = true;
            }
            else
            {
                acrobatic_finishing.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "11") == "Heel Trick")
            {
                hell_trick.Checked = true;
            }
            else
            {
                hell_trick.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "12") == "First-time Shot")
            {
                first_time_shot.Checked = true;
            }
            else
            {
                first_time_shot.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "14") == "Weighted Pass")
            {
                weighted_pass.Checked = true;
            }
            else
            {
                weighted_pass.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "15") == "Pinpoint Crossing")
            {
                pinpoint_crossing.Checked = true;
            }
            else
            {
                pinpoint_crossing.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "16") == "Outside Curler")
            {
                outside_curler.Checked = true;
            }
            else
            {
                outside_curler.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "19") == "Low Punt Trajectory")
            {
                low_punt_trajectory.Checked = true;
            }
            else
            {
                low_punt_trajectory.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "20") == "Long Throw")
            {
                long_throw.Checked = true;
            }
            else
            {
                long_throw.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "21") == "GK Long Throw")
            {
                gk_long_throw.Checked = true;
            }
            else
            {
                gk_long_throw.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "22") == "Malicia")
            {
                malicia.Checked = true;
            }
            else
            {
                malicia.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "23") == "Man Marking")
            {
                man_marking.Checked = true;
            }
            else
            {
                man_marking.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "24") == "Track Back")
            {
                track_back.Checked = true;
            }
            else
            {
                track_back.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "26") == "Captaincy")
            {
                captaincy.Checked = true;
            }
            else
            {
                captaincy.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "27") == "Super-Sub")
            {
                super_sub.Checked = true;
            }
            else
            {
                super_sub.Checked = false;
            }

            if (ini.IniReadValue("Player Skills", "28") == "Fighting Spirit")
            {
                fighting_spirit.Checked = true;
            }
            else
            {
                fighting_spirit.Checked = false;
            }

            //rabona
            //heading
            //Acrobatic_Clear
            //Scotch_Move
            //Low_Lofted_Pass
            //One_Touch_Pass

            //COM
            if (ini.IniReadValue("COM Playing Styles", "01") == "Trickster")
            {
                trickster.Checked = true;
            }
            else
            {
                trickster.Checked = false;
            }

            if (ini.IniReadValue("COM Playing Styles", "02") == "Mazing Run")
            {
                mazing_run.Checked = true;
            }
            else
            {
                mazing_run.Checked = false;
            }

            if (ini.IniReadValue("COM Playing Styles", "03") == "Speeding Bullet")
            {
                speeding_bullet.Checked = true;
            }
            else
            {
                speeding_bullet.Checked = false;
            }

            if (ini.IniReadValue("COM Playing Styles", "04") == "Incisive Run")
            {
                incisive_run.Checked = true;
            }
            else
            {
                incisive_run.Checked = false;
            }

            if (ini.IniReadValue("COM Playing Styles", "05") == "Long-Ball Expert")
            {
                long_ball_expert.Checked = true;
            }
            else
            {
                long_ball_expert.Checked = false;
            }

            if (ini.IniReadValue("COM Playing Styles", "06") == "Early Cross")
            {
                early_cross.Checked = true;
            }
            else
            {
                early_cross.Checked = false;
            }

            if (ini.IniReadValue("COM Playing Styles", "07") == "Long Ranger")
            {
                long_ranger.Checked = true;
            }
            else
            {
                long_ranger.Checked = false;
            }
        }

    }
}

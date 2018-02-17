using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using DinoTem.ui;
using Team_Editor_Manager_New_Generation.persistence;

namespace DinoTem.persistence
{
    //pes 18
    public class MyPlayerPersister
    {
        private static string PATH = "/Player.bin";
        private static int block = 192;

        private MemoryStream unzlib(string patch, int bitRecognized)
        {
            MemoryStream memory1 = null;
            if (bitRecognized == 0)
            {
                byte[] file = File.ReadAllBytes(patch + PATH);
                byte[] ss1 = Unzlib.unZLIBFilePC(file);
                memory1 = new MemoryStream(ss1);
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                FileStream writeStream = new FileStream(patch + PATH, FileMode.Open);
                memory1 = UnzlibZlibConsole.UnzlibZlibConsole.unzlibconsole_to_MemStream(writeStream);
                UnzlibZlibConsole.UnzlibZlibConsole.Player_toPc(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo giocatori
            int bytesPlayer = (int)memory1.Length;
            int player = bytesPlayer / block;

            string playerName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -48;

                int NumberOfRepetitions1 = Convert.ToInt32(player);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    playerName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(44)).TrimEnd('\0');

                    Form1._Form1.playersBox.Items.Add(playerName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Player loadPlayer(int index, BinaryReader reader)
        {
            Player player = null;

            string name;
            string japName;
            string shirtName;
            UInt32 youthId;
            UInt32 playerId;
            UInt32 weight;
            UInt32 height;
            UInt32 secondNational;
            UInt32 national;
            UInt32 defProwess;
            UInt32 clearing;
            UInt32 lowPass;
            UInt32 placeKicking;
            UInt32 goalCeleb;
            UInt32 LB;
            UInt32 coverage;
            UInt32 catching;
            UInt32 jump;
            UInt32 header;
            UInt32 ballControl;
            UInt32 GK;
            UInt32 goalKeeping;
            UInt32 reflexes;
            UInt32 finishing;
            UInt32 ballWinning;
            UInt32 speed;
            UInt32 penaltyKick;
            UInt32 kickingPower;
            UInt32 dribling;
            UInt32 explosivePower;
            UInt32 stamina;
            UInt32 swerve;
            UInt32 form;
            UInt32 playingStyle;
            UInt32 age;
            UInt32 loftedPass;
            UInt32 physicalContact;
            UInt32 bodyControl;
            UInt32 attackingProwess;
            UInt32 RMF;
            UInt32 injuryRes;
            UInt32 CMF;
            UInt32 weakFootUse;
            UInt32 DMF;
            UInt32 playingAttitude;
            UInt32 runningArmMov;
            UInt32 driblingArmMov;
            UInt32 cornerKick;
            UInt32 position;
            UInt32 freeKick;
            UInt32 original_32_8th_val;
            UInt32 CHECK1;
            UInt32 CHECK2;
            UInt32 CHECK3;
            UInt32 CHECK4;
            UInt32 CHECK5;
            UInt32 CHECK6;
            UInt32 CHECK7;
            UInt32 CHECK8;
            UInt32 Blue_2;
            UInt32 SS;
            UInt32 runingHutching;
            UInt32 RWF;
            UInt32 LMF;
            UInt32 RB;
            UInt32 LWF;
            UInt32 CF;
            UInt32 CB;
            UInt32 driblingHutching;
            UInt32 AMF;
            UInt32 weakFootAcc;
            UInt32 starPlayerIndicator;
            UInt32 CHECK9;
            UInt32 CHECK10;
            UInt32 CHECK11;
            UInt32 CHECK12;
            UInt32 CHECK13;
            UInt32 CHECK14;
            UInt32 CHECK15;
            UInt32 CHECK16;
            UInt32 CHECK17;
            UInt32 CHECK18;
            UInt32 CHECK19;
            UInt32 CHECK20;
            UInt32 CHECK21;
            UInt32 CHECK22;
            UInt32 CHECK23;
            UInt32 CHECK24;
            UInt32 CHECK25;
            UInt32 CHECK26;
            UInt32 CHECK27;
            UInt32 CHECK28;
            UInt32 CHECK29;
            UInt32 CHECK30;
            UInt32 CHECK31;
            UInt32 CHECK32;
            UInt32 CHECK33;
            UInt32 CHECK34;
            UInt32 CHECK35;
            UInt32 CHECK36;
            UInt32 CHECK37;
            UInt32 CHECK38;
            UInt32 CHECK39;
            UInt32 CHECK40;
            UInt32 CHECK141;
            UInt32 CHECK142;
            try
            {
                index = index * block;

                reader.BaseStream.Position = (index + 0);
                youthId = reader.ReadUInt32();

                reader.BaseStream.Position = (index + 8);
                playerId = reader.ReadUInt32();

                reader.BaseStream.Position = (index + 12);
                UInt32 original_32_first_val = reader.ReadUInt32();
                placeKicking = original_32_first_val >> 26;
                height = original_32_first_val << 6;
                height = height >> 24;
                secondNational = original_32_first_val << 14;
                secondNational = secondNational >> 23;
                national = original_32_first_val << 23;
                national = national >> 23;

                reader.BaseStream.Position = (index + 16);
                UInt32 original_32_second_val = reader.ReadUInt32();
                defProwess = original_32_second_val >> 26;
                clearing = original_32_second_val << 6;
                clearing = clearing >> 26;
                lowPass = original_32_second_val << 12;
                lowPass = lowPass >> 26;
                goalCeleb = original_32_second_val << 18;
                goalCeleb = goalCeleb >> 25;
                weight = original_32_second_val << 25;
                weight = weight >> 25;

                reader.BaseStream.Position = (index + 20);
                UInt32 original_32_3rd_val = reader.ReadUInt32();
                LB = original_32_3rd_val >> 30;
                coverage = original_32_3rd_val << 2;
                coverage = coverage >> 26;
                catching = original_32_3rd_val << 8;
                catching = catching >> 26;
                jump = original_32_3rd_val << 14;
                jump = jump >> 26;
                header = original_32_3rd_val << 20;
                header = header >> 26;
                ballControl = original_32_3rd_val << 26;
                ballControl = ballControl >> 26;

                reader.BaseStream.Position = (index + 24);
                UInt32 original_32_4th_val = reader.ReadUInt32();
                GK = original_32_4th_val >> 30;
                goalKeeping = original_32_4th_val << 2;
                goalKeeping = goalKeeping >> 26;
                reflexes = original_32_4th_val << 8;
                reflexes = reflexes >> 26;
                finishing = original_32_4th_val << 14;
                finishing = finishing >> 26;
                ballWinning = original_32_4th_val << 20;
                ballWinning = ballWinning >> 26;
                speed = original_32_4th_val << 26;
                speed = speed >> 26;

                reader.BaseStream.Position = (index + 28);
                UInt32 original_32_5th_val = reader.ReadUInt32();
                penaltyKick = original_32_5th_val >> 30;
                kickingPower = original_32_5th_val << 2;
                kickingPower = kickingPower >> 26;
                dribling = original_32_5th_val << 8;
                dribling = dribling >> 26;
                explosivePower = original_32_5th_val << 14;
                explosivePower = explosivePower >> 26;
                stamina = original_32_5th_val << 20;
                stamina = stamina >> 26;
                swerve = original_32_5th_val << 26;
                swerve = swerve >> 26;

                reader.BaseStream.Position = (index + 32);
                UInt32 original_32_6th_val = reader.ReadUInt32();
                playingAttitude = original_32_6th_val >> 30;
                age = original_32_6th_val << 2;
                age = age >> 26;
                loftedPass = original_32_6th_val << 8;
                loftedPass = loftedPass >> 26;
                physicalContact = original_32_6th_val << 14;
                physicalContact = physicalContact >> 26;
                bodyControl = original_32_6th_val << 20;
                bodyControl = bodyControl >> 26;
                attackingProwess = original_32_6th_val << 26;
                attackingProwess = attackingProwess >> 26;

                reader.BaseStream.Position = (index + 36);
                UInt32 original_32_7th_val = reader.ReadUInt32();
                weakFootUse = original_32_7th_val >> 30;
                DMF = original_32_7th_val << 2;
                DMF = DMF >> 30;
                starPlayerIndicator = original_32_7th_val << 4;
                starPlayerIndicator = starPlayerIndicator >> 29;
                runningArmMov = original_32_7th_val << 7;
                runningArmMov = runningArmMov >> 29;
                driblingArmMov = original_32_7th_val << 10;
                driblingArmMov = driblingArmMov >> 29;
                cornerKick = original_32_7th_val << 13;
                cornerKick = cornerKick >> 29;
                form = original_32_7th_val << 16;
                form = form >> 29;
                position = original_32_7th_val << 19;
                position = position >> 28;
                freeKick = original_32_7th_val << 23;
                freeKick = freeKick >> 28;
                playingStyle = original_32_7th_val << 27;
                playingStyle = playingStyle >> 27;

                reader.BaseStream.Position = (index + 40);
                original_32_8th_val = reader.ReadUInt32();
                CHECK1 = original_32_8th_val >> 31;
                CHECK2 = original_32_8th_val << 1;
                CHECK2 = CHECK2 >> 31;
                runingHutching = original_32_8th_val << 2;
                runingHutching = runingHutching >> 30;
                SS = original_32_8th_val << 4;
                SS = SS >> 30;
                Blue_2 = original_32_8th_val << 6;
                Blue_2 = Blue_2 >> 30;
                RWF = original_32_8th_val << 8;
                RWF = RWF >> 30;
                LMF = original_32_8th_val << 10;
                LMF = LMF >> 30;
                RB = original_32_8th_val << 12;
                RB = RB >> 30;
                LWF = original_32_8th_val << 14;
                LWF = LWF >> 30;
                CF = original_32_8th_val << 16;
                CF = CF >> 30;
                CB = original_32_8th_val << 18;
                CB = CB >> 30;
                driblingHutching = original_32_8th_val << 20;
                driblingHutching = driblingHutching >> 30;
                AMF = original_32_8th_val << 22;
                AMF = AMF >> 30;
                weakFootAcc = original_32_8th_val << 24;
                weakFootAcc = weakFootAcc >> 30;
                RMF = original_32_8th_val << 26;
                RMF = RMF >> 30;
                injuryRes = original_32_8th_val << 28;
                injuryRes = injuryRes >> 30;
                CMF = original_32_8th_val << 30;
                CMF = CMF >> 30;

                reader.BaseStream.Position = (index + 44);
                UInt32 original_32_9th_val = reader.ReadUInt32();
                CHECK9 = original_32_9th_val >> 31;
                CHECK10 = original_32_9th_val << 1;
                CHECK10 = CHECK10 >> 31;
                CHECK11 = original_32_9th_val << 2;
                CHECK11 = CHECK11 >> 31;
                CHECK12 = original_32_9th_val << 3;
                CHECK12 = CHECK12 >> 31;
                CHECK13 = original_32_9th_val << 4;
                CHECK13 = CHECK13 >> 31;
                CHECK14 = original_32_9th_val << 5;
                CHECK14 = CHECK14 >> 31;
                CHECK15 = original_32_9th_val << 6;
                CHECK15 = CHECK15 >> 31;
                CHECK16 = original_32_9th_val << 7;
                CHECK16 = CHECK16 >> 31;
                CHECK25 = original_32_9th_val << 8;
                CHECK25 = CHECK25 >> 31;
                CHECK17 = original_32_9th_val << 9;
                CHECK17 = CHECK17 >> 31;
                CHECK19 = original_32_9th_val << 10;
                CHECK19 = CHECK19 >> 31;
                CHECK20 = original_32_9th_val << 11;
                CHECK20 = CHECK20 >> 31;
                CHECK21 = original_32_9th_val << 12;
                CHECK21 = CHECK21 >> 31;
                CHECK22 = original_32_9th_val << 13;
                CHECK22 = CHECK22 >> 31;
                CHECK23 = original_32_9th_val << 14;
                CHECK23 = CHECK23 >> 31;
                CHECK24 = original_32_9th_val << 15;
                CHECK24 = CHECK24 >> 31;
                CHECK18 = original_32_9th_val << 16;
                CHECK18 = CHECK18 >> 31;
                CHECK26 = original_32_9th_val << 17;
                CHECK26 = CHECK26 >> 31;
                CHECK27 = original_32_9th_val << 18;
                CHECK27 = CHECK27 >> 31;
                CHECK28 = original_32_9th_val << 19;
                CHECK28 = CHECK28 >> 31;
                CHECK29 = original_32_9th_val << 20;
                CHECK29 = CHECK29 >> 31;
                CHECK30 = original_32_9th_val << 21;
                CHECK30 = CHECK30 >> 31;
                CHECK31 = original_32_9th_val << 22;
                CHECK31 = CHECK31 >> 31;
                CHECK32 = original_32_9th_val << 23;
                CHECK32 = CHECK32 >> 31;
                CHECK33 = original_32_9th_val << 24;
                CHECK33 = CHECK33 >> 31;
                CHECK34 = original_32_9th_val << 25;
                CHECK34 = CHECK34 >> 31;
                CHECK35 = original_32_9th_val << 26;
                CHECK35 = CHECK35 >> 31;
                CHECK36 = original_32_9th_val << 27;
                CHECK36 = CHECK36 >> 31;
                CHECK37 = original_32_9th_val << 28;
                CHECK37 = CHECK37 >> 31;
                CHECK38 = original_32_9th_val << 29;
                CHECK38 = CHECK38 >> 31;
                CHECK39 = original_32_9th_val << 30;
                CHECK39 = CHECK39 >> 31;
                CHECK40 = original_32_9th_val << 31;
                CHECK40 = CHECK40 >> 31;

                reader.BaseStream.Position = (index + 48);
                byte byte_nuevo = reader.ReadByte();
                CHECK3 = (uint) byte_nuevo >> 7;
                CHECK4 = (uint) byte_nuevo << 1;
                CHECK4 = CHECK4 >> 7;
                CHECK5 = (uint) byte_nuevo << 2;
                CHECK5 = CHECK5 >> 7;
                CHECK6 = (uint) byte_nuevo << 3;
                CHECK6 = CHECK6 >> 7;
                CHECK7 = (uint) byte_nuevo << 4;
                CHECK7 = CHECK7 >> 7;
                CHECK8 = (uint) byte_nuevo << 5;
                CHECK8 = CHECK8 >> 7;
                CHECK141 = (uint) byte_nuevo << 6;
                CHECK141 = CHECK141 >> 7;
                CHECK142 = (uint) byte_nuevo << 7;
                CHECK142 = CHECK142 >> 7;

                reader.BaseStream.Position = index + 52;
                japName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(44)).TrimEnd('\0');

                reader.BaseStream.Position = index + 98;
                shirtName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(44)).TrimEnd('\0');

                reader.BaseStream.Position = index + 144;
                name = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(44)).TrimEnd('\0');

                player = new Player(playerId);
                player.setYouthPlayerId(youthId);
                player.setPlaceKick(placeKicking + 40);
                player.setHeight(height + 100);
                player.setNational2(secondNational);
                player.setNational(national);
                player.setDefense(defProwess + 40);
                player.setLowPass(clearing + 40);
                player.setLowPass(lowPass + 40);
                player.setGoalCelebrate(goalCeleb);
                player.setWeight(weight + 30);
                player.setLb(LB);
                player.setCoverage(coverage + 40);
                player.setCathing(catching + 40);
                player.setJump(jump + 40);
                player.setHeader(header + 40);
                player.setBallControll(ballControl + 40);
                player.setGk(GK);
                player.setGoalkeeping(goalKeeping + 40);
                player.setReflexes(reflexes + 40);
                player.setFinishing(finishing + 40);
                player.setBallWinning(ballWinning + 40);
                player.setSpeed(speed + 40);
                player.setPenaltyKick(penaltyKick + 1);
                player.setKickingPower(kickingPower + 40);
                player.setDribbling(dribling + 40);
                player.setExplosiveP(explosivePower + 40);
                player.setStamina(stamina + 40);
                player.setSwerve(swerve + 40);
                player.setPlayingAttitude(playingAttitude);
                player.setAge(age + 15);
                player.setLoftedPass(loftedPass + 40);
                player.setPhysical(physicalContact + 40);
                player.setBodyControl(bodyControl + 40);
                player.setAttack(attackingProwess + 40);
                player.setWcUsage(weakFootUse + 1);
                player.setDmf(DMF);
                player.setStarPlayerIndicator(starPlayerIndicator);
                player.setRunningArm(runningArmMov + 1);
                player.setDriblingArm(driblingArmMov + 1);
                player.setCornerKick(cornerKick + 1);
                player.setForm(form);
                player.setPosition(position);
                player.setFreeKick(freeKick + 1);
                player.setPlayingStyle(playingStyle);
                player.setSombrero(CHECK1);
                player.setEarlyCross(CHECK2);
                player.setRunningH(runingHutching + 1);
                player.setSs(SS);
                player.setUnk2(Blue_2);
                player.setRwf(RWF);
                player.setLmf(LMF);
                player.setRb(RB);
                player.setLwf(LWF);
                player.setCf(CF);
                player.setCb(CB);
                player.setDriblingH(driblingHutching + 1);
                player.setAmf(AMF);
                player.setWeakFootAcc(weakFootAcc + 1);
                player.setRmf(RMF);
                player.setInjuryRes(injuryRes + 1);
                player.setCmf(CMF);
                player.setSchotMove(CHECK9);
                player.setGkLong(CHECK10);
                player.setLongThrow(CHECK11);
                player.setScissorFeint(CHECK12);
                player.setTrackBack(CHECK13);
                player.setSuperSub(CHECK14);
                player.setRabona(CHECK15);
                player.setAcrobatingFinishing(CHECK16);
                player.setStrongerFoot(CHECK25);
                player.setKnucleShot(CHECK17);
                player.setFirstTimeShot(CHECK19);
                player.setComIncisiveRun(CHECK20);
                player.setStrongerHand(CHECK21);
                player.setHiddenPlayer(CHECK22);
                player.setComLongRanger(CHECK23);
                player.setOneTouchPass(CHECK24);
                player.setHellTick(CHECK18);
                player.setUnk4(CHECK26);
                player.setManMarking(CHECK27);
                player.setLegendGoldenBall(CHECK28);
                player.setMarseilleTurn(CHECK29);
                player.setHeading(CHECK30);
                player.setOutsideCurler(CHECK31);
                player.setCaptaincy(CHECK32);
                player.setMalicia(CHECK33);
                player.setLowPuntTrajectory(CHECK34);
                player.setComTrickster(CHECK35);
                player.setLowLoftedPass(CHECK36);
                player.setFightingSpirit(CHECK37);
                player.setFlipFlap(CHECK38);
                player.setWeightnessPass(CHECK39);
                player.setPinCrossing(CHECK40);
                player.setUnk6(CHECK3);
                player.setUnk7(CHECK4);
                player.setComMazingRun(CHECK5);
                player.setAcrobatingClear(CHECK6);
                player.setComBallExpert(CHECK7);
                player.setCutBehind(CHECK8);
                player.setLongRange(CHECK141);
                player.setSpeedingBullet(CHECK142);
                player.setShirtName(shirtName);
                player.setName(name);
                player.setJapanese(japName);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return player;
        }

        public Player loadPlayerById(UInt32 id, MemoryStream memory1, BinaryReader reader)
        {
            Player player = null;

            //Calcolo giocatori
            int bytesPlayer = (int)memory1.Length;
            int nplayer = bytesPlayer / block;

            reader.BaseStream.Position = 0;
            try
            {
                int i1 = 0;
                long START2 = -184;

                int NumberOfRepetitions1 = Convert.ToInt32(nplayer);
                for (i1 = 0; i1 <= NumberOfRepetitions1 - 1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    UInt32 playerId = reader.ReadUInt32();
                    if (playerId == id)
                    {
                        player = loadPlayer(i1, reader);
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return player;
        }

        public int loadIndexPlayerById(UInt32 id, MemoryStream memory1, BinaryReader reader)
        {
            int index = 0;

            //Calcolo giocatori
            int bytesPlayer = (int)memory1.Length;
            int nplayer = bytesPlayer / block;

            reader.BaseStream.Position = 0;
            try
            {
                int i1 = 0;
                long START2 = -184;

                int NumberOfRepetitions1 = Convert.ToInt32(nplayer);
                for (i1 = 0; i1 <= NumberOfRepetitions1 - 1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    UInt32 playerId = reader.ReadUInt32();
                    if (playerId == id)
                    {
                        index = i1;
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return index;
        }

        public void applyPlayer(int selectedIndex, ref MemoryStream unzlib, Player giocatore, ref BinaryWriter writer)
        {
            int Index = selectedIndex * block;
            writer.BaseStream.Position = Index;
            UInt32 Num_nuevo_32 = Form1.Valor_nuevo32_box.Value;
            writer.Write(swaps.swap32(Num_nuevo_32));
            UInt32 Num_nuevo_32_2 = Form1.Valor_nuevo32_2_box.Value;
            writer.Write(swaps.swap32(Num_nuevo_32_2));
            UInt32 Player_ID = Form1.Player_num.Value;
            writer.Write(swaps.swap32(Player_ID));
            UInt32 Nuevo_val_32_first;
            UInt32 Height = (Form1.height_box.Value - 100);
            UInt32 Nacionalizado = Form1.Nationalized_box.Value;
            UInt32 Nacion = Form1.Nation_box.Value;
            UInt32 place_kicking = (Form1.Set_piece_taking_box.Value - 40);
            UInt32 Aux;
            Aux = place_kicking;
            Aux = Aux << 26;
            Nuevo_val_32_first = (Aux | Nuevo_val_32_first);
            Aux = Height;
            Aux = Aux << 18;
            Nuevo_val_32_first = (Aux | Nuevo_val_32_first);
            Aux = Nacionalizado;
            Aux = Aux << 9;
            Nuevo_val_32_first = (Aux | Nuevo_val_32_first);
            Aux = Nacion;
            Nuevo_val_32_first = (Aux | Nuevo_val_32_first);

            UInt32 Nuevo_val_32_2nd;
            UInt32 def_prowess = (Form1.def_prowess_box.Value - 40);
            UInt32 Clearing = (Form1.Clearing_box.Value - 40);
            UInt32 Low_pass = (Form1.Low_pass_box.Value - 40);
            UInt32 weight = (Form1.weight_box.Value - 30);
            UInt32 Goal_celeb = Form1.Goal_celeb_box.Value;
            Aux = def_prowess;
            Aux = Aux << 26;
            Nuevo_val_32_2nd = (Aux | Nuevo_val_32_2nd);
            Aux = Clearing;
            Aux = Aux << 20;
            Nuevo_val_32_2nd = (Aux | Nuevo_val_32_2nd);
            Aux = Low_pass;
            Aux = ShiftLeft(Aux, 14);
            Nuevo_val_32_2nd = (Aux | Nuevo_val_32_2nd);
            Aux = Goal_celeb;
            Aux = ShiftLeft(Aux, 7);
            Nuevo_val_32_2nd = (Aux | Nuevo_val_32_2nd);
            Aux = weight;
            Nuevo_val_32_2nd = (Aux | Nuevo_val_32_2nd);

            UInt32 Nuevo_val_32_3rd;
            UInt32 LB = Form1.LB_box.Value;
            UInt32 coverage = (Form1.coverage_box.Value - 40);
            UInt32 catching = (Form1.catching_box.Value - 40);
            UInt32 Jump = (Form1.Jump_box.Value - 40);
            UInt32 Header = (Form1.Header_box.Value - 40);
            UInt32 Ball_control = (Form1.Ball_control_box.Value - 40);
            Aux = LB;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_3rd = (Aux || Nuevo_val_32_3rd);
            Aux = coverage;
            Aux = ShiftLeft(Aux, 24);
            Nuevo_val_32_3rd = (Aux || Nuevo_val_32_3rd);
            Aux = catching;
            Aux = ShiftLeft(Aux, 18);
            Nuevo_val_32_3rd = (Aux || Nuevo_val_32_3rd);
            Aux = Jump;
            Aux = ShiftLeft(Aux, 12);
            Nuevo_val_32_3rd = (Aux || Nuevo_val_32_3rd);
            Aux = Header;
            Aux = ShiftLeft(Aux, 6);
            Nuevo_val_32_3rd = (Aux || Nuevo_val_32_3rd);
            Aux = Ball_control;
            // Aux = Aux << 7
            Nuevo_val_32_3rd = (Aux || Nuevo_val_32_3rd);
            UInt32 Nuevo_val_32_4th;
            UInt32 GK = Form1.GK_box.Value;
            UInt32 GoalKeeping = (Form1.GoalKeeping_box.Value - 40);
            UInt32 Reflexes = (Form1.Reflexes_Box.Value - 40);
            UInt32 Finishing = (Form1.Finishing_box.Value - 40);
            UInt32 Ball_winning = (Form1.Ball_winning_box.Value - 40);
            UInt32 Speed = (Form1.Speed_box.Value - 40);
            Aux = GK;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_4th = (Aux || Nuevo_val_32_4th);
            Aux = GoalKeeping;
            Aux = ShiftLeft(Aux, 24);
            Nuevo_val_32_4th = (Aux || Nuevo_val_32_4th);
            Aux = Reflexes;
            Aux = ShiftLeft(Aux, 18);
            Nuevo_val_32_4th = (Aux || Nuevo_val_32_4th);
            Aux = Finishing;
            Aux = ShiftLeft(Aux, 12);
            Nuevo_val_32_4th = (Aux || Nuevo_val_32_4th);
            Aux = Ball_winning;
            Aux = ShiftLeft(Aux, 6);
            Nuevo_val_32_4th = (Aux || Nuevo_val_32_4th);
            Aux = Speed;
            // Aux = Aux << 7
            Nuevo_val_32_4th = (Aux || Nuevo_val_32_4th);
            UInt32 Nuevo_val_32_5th;
            UInt32 Penalty_kick = (Form1.Penalty_kick_box.Value - 1);
            UInt32 Kicking_power = (Form1.Kicking_power_box.Value - 40);
            UInt32 Dribling = (Form1.Dribling_box.Value - 40);
            UInt32 Explosive_power = (Form1.Explosive_power_box.Value - 40);
            UInt32 Stamina = (Form1.Stamina_box.Value - 40);
            UInt32 Swerve = (Form1.Swerve_box.Value - 40);
            Aux = Penalty_kick;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_5th = (Aux || Nuevo_val_32_5th);
            Aux = Kicking_power;
            Aux = ShiftLeft(Aux, 24);
            Nuevo_val_32_5th = (Aux || Nuevo_val_32_5th);
            Aux = Dribling;
            Aux = ShiftLeft(Aux, 18);
            Nuevo_val_32_5th = (Aux || Nuevo_val_32_5th);
            Aux = Explosive_power;
            Aux = ShiftLeft(Aux, 12);
            Nuevo_val_32_5th = (Aux || Nuevo_val_32_5th);
            Aux = Stamina;
            Aux = ShiftLeft(Aux, 6);
            Nuevo_val_32_5th = (Aux || Nuevo_val_32_5th);
            Aux = Swerve;
            // Aux = Aux << 7
            Nuevo_val_32_5th = (Aux || Nuevo_val_32_5th);
            UInt32 Nuevo_val_32_6th;
            UInt32 Unk = Form1.Pink_2_box.Value;
            UInt32 Age = (Form1.Age_box.Value - 15);
            UInt32 Lofted_pass = (Form1.Lofted_pass_box.Value - 40);
            UInt32 Physical_contact = (Form1.Physical_Contact_box.Value - 40);
            UInt32 Body_Balance = (Form1.Body_Balance_box.Value - 40);
            UInt32 Attacking_Prowess = (Form1.Attacking_Prowess_box.Value - 40);
            Aux = Unk;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_6th = (Aux || Nuevo_val_32_6th);
            Aux = Age;
            Aux = ShiftLeft(Aux, 24);
            Nuevo_val_32_6th = (Aux || Nuevo_val_32_6th);
            Aux = Lofted_pass;
            Aux = ShiftLeft(Aux, 18);
            Nuevo_val_32_6th = (Aux || Nuevo_val_32_6th);
            Aux = Physical_contact;
            Aux = ShiftLeft(Aux, 12);
            Nuevo_val_32_6th = (Aux || Nuevo_val_32_6th);
            Aux = Body_Balance;
            Aux = ShiftLeft(Aux, 6);
            Nuevo_val_32_6th = (Aux || Nuevo_val_32_6th);
            Aux = Attacking_Prowess;
            // Aux = Aux << 7
            Nuevo_val_32_6th = (Aux || Nuevo_val_32_6th);
            UInt32 Nuevo_val_32_7th;
            UInt32 Weak_foot_use = (Form1.Weak_foot_use_box.Value - 1);
            UInt32 DMF = Form1.DMF_box.Value;
            UInt32 ulti_nuevo = Form1.ulti_nuevo_box.Value;
            UInt32 Running_arm_mov = (Form1.Running_arm_mov_box.Value - 1);
            UInt32 Dribling_arm_mov = (Form1.Dribling_arm_mov_box.Value - 1);
            UInt32 Corner_kick = (Form1.Corner_kick_box.Value - 1);
            UInt32 FORM = (Form1.FORM_box.Value - 1);
            UInt32 Position = Form1.Position_box.Value;
            UInt32 Free_kick = (Form1.Free_kick_box.Value - 1);
            UInt32 Playing_Style = Form1.Playing_Style_box.Value;
            Aux = Weak_foot_use;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = DMF;
            Aux = ShiftLeft(Aux, 28);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = ulti_nuevo;
            Aux = ShiftLeft(Aux, 25);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = Running_arm_mov;
            Aux = ShiftLeft(Aux, 22);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = Dribling_arm_mov;
            Aux = ShiftLeft(Aux, 19);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = Corner_kick;
            Aux = ShiftLeft(Aux, 16);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = FORM;
            Aux = ShiftLeft(Aux, 13);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = Position;
            Aux = ShiftLeft(Aux, 9);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = Free_kick;
            Aux = ShiftLeft(Aux, 5);
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            Aux = Playing_Style;
            // Aux = Aux << 20
            Nuevo_val_32_7th = (Aux || Nuevo_val_32_7th);
            UInt32 Nuevo_val_32_8th;
            UInt32 Pinpoint_Crossing;
            if ((Form1.CheckBox1.Checked == true))
            {
                Pinpoint_Crossing = 1;
            }
            else
            {
                Pinpoint_Crossing = 0;
            }

            UInt32 Sombrero;
            if ((Form1.CheckBox2.Checked == true))
            {
                Sombrero = 1;
            }
            else
            {
                Sombrero = 0;
            }

            UInt32 Runing_Hutching = (Form1.Runing_Hutching_box.Value - 1);
            UInt32 ss = Form1.SS_box.Value;
            UInt32 Blue_2 = Form1.blue_2_box.Value;
            UInt32 RWF = Form1.RWF_box.Value;
            UInt32 LMF = Form1.LMF_box.Value;
            UInt32 RB = Form1.RB_box.Value;
            UInt32 LWF = Form1.LWF_box.Value;
            UInt32 CF = Form1.CF_box.Value;
            UInt32 CB = Form1.CB_box.Value;
            UInt32 Dribling_hutching = (Form1.Dribling_hutching_box.Value - 1);
            UInt32 AMF = Form1.AMF_box.Value;
            UInt32 injury_res = (Form1.Injury_res__box.Value - 1);
            UInt32 RMF = Form1.RMF_box.Value;
            UInt32 Weak_foot_acc = (Form1.Weak_foot_acc_box.Value - 1);
            UInt32 CMF = Form1.CMF_box.Value;
            Aux = Pinpoint_Crossing;
            Aux = ShiftLeft(Aux, 31);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = Sombrero;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = Runing_Hutching;
            Aux = ShiftLeft(Aux, 28);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = ss;
            Aux = ShiftLeft(Aux, 26);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = Blue_2;
            Aux = ShiftLeft(Aux, 24);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = RWF;
            Aux = ShiftLeft(Aux, 22);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = LMF;
            Aux = ShiftLeft(Aux, 20);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = RB;
            Aux = ShiftLeft(Aux, 18);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = LWF;
            Aux = ShiftLeft(Aux, 16);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = CF;
            Aux = ShiftLeft(Aux, 14);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = CB;
            Aux = ShiftLeft(Aux, 12);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = Dribling_hutching;
            Aux = ShiftLeft(Aux, 10);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = AMF;
            Aux = ShiftLeft(Aux, 8);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = Weak_foot_acc;
            Aux = ShiftLeft(Aux, 6);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = RMF;
            Aux = ShiftLeft(Aux, 4);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = injury_res;
            Aux = ShiftLeft(Aux, 2);
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            Aux = CMF;
            // Aux = Aux << 20
            Nuevo_val_32_8th = (Aux || Nuevo_val_32_8th);
            UInt32 Nuevo_val_32_9th;
            UInt32 CHECK9;
            if ((Form1.CheckBox9.Checked == true))
            {
                CHECK9 = 1;
            }
            else
            {
                CHECK9 = 0;
            }

            UInt32 CHECK10;
            if ((Form1.CheckBox10.Checked == true))
            {
                CHECK10 = 1;
            }
            else
            {
                CHECK10 = 0;
            }

            UInt32 CHECK11;
            if ((Form1.CheckBox11.Checked == true))
            {
                CHECK11 = 1;
            }
            else
            {
                CHECK11 = 0;
            }

            UInt32 CHECK12;
            if ((Form1.CheckBox12.Checked == true))
            {
                CHECK12 = 1;
            }
            else
            {
                CHECK12 = 0;
            }

            UInt32 CHECK13;
            if ((Form1.CheckBox13.Checked == true))
            {
                CHECK13 = 1;
            }
            else
            {
                CHECK13 = 0;
            }

            UInt32 CHECK14;
            if ((Form1.CheckBox14.Checked == true))
            {
                CHECK14 = 1;
            }
            else
            {
                CHECK14 = 0;
            }

            UInt32 CHECK15;
            if ((Form1.CheckBox15.Checked == true))
            {
                CHECK15 = 1;
            }
            else
            {
                CHECK15 = 0;
            }

            UInt32 CHECK16;
            if ((Form1.CheckBox16.Checked == true))
            {
                CHECK16 = 1;
            }
            else
            {
                CHECK16 = 0;
            }

            UInt32 CHECK17;
            if ((Form1.CheckBox25.Checked == true))
            {
                CHECK17 = 1;
            }
            else
            {
                CHECK17 = 0;
            }

            UInt32 CHECK18;
            if ((Form1.CheckBox17.Checked == true))
            {
                CHECK18 = 1;
            }
            else
            {
                CHECK18 = 0;
            }

            UInt32 CHECK19;
            if ((Form1.CheckBox19.Checked == true))
            {
                CHECK19 = 1;
            }
            else
            {
                CHECK19 = 0;
            }

            UInt32 CHECK20;
            if ((Form1.CheckBox20.Checked == true))
            {
                CHECK20 = 1;
            }
            else
            {
                CHECK20 = 0;
            }

            UInt32 CHECK21;
            if ((Form1.CheckBox21.Checked == true))
            {
                CHECK21 = 1;
            }
            else
            {
                CHECK21 = 0;
            }

            UInt32 CHECK22;
            if ((Form1.CheckBox22.Checked == true))
            {
                CHECK22 = 1;
            }
            else
            {
                CHECK22 = 0;
            }

            UInt32 CHECK23;
            if ((Form1.CheckBox23.Checked == true))
            {
                CHECK23 = 1;
            }
            else
            {
                CHECK23 = 0;
            }

            UInt32 CHECK24;
            if ((Form1.CheckBox24.Checked == true))
            {
                CHECK24 = 1;
            }
            else
            {
                CHECK24 = 0;
            }

            UInt32 CHECK25;
            if ((Form1.CheckBox18.Checked == true))
            {
                CHECK25 = 1;
            }
            else
            {
                CHECK25 = 0;
            }

            UInt32 CHECK26;
            if ((Form1.CheckBox26.Checked == true))
            {
                CHECK26 = 1;
            }
            else
            {
                CHECK26 = 0;
            }

            UInt32 CHECK27;
            if ((Form1.CheckBox27.Checked == true))
            {
                CHECK27 = 1;
            }
            else
            {
                CHECK27 = 0;
            }

            UInt32 CHECK28;
            if ((Form1.CheckBox28.Checked == true))
            {
                CHECK28 = 1;
            }
            else
            {
                CHECK28 = 0;
            }

            UInt32 CHECK29;
            if ((Form1.CheckBox29.Checked == true))
            {
                CHECK29 = 1;
            }
            else
            {
                CHECK29 = 0;
            }

            UInt32 CHECK30;
            if ((Form1.CheckBox30.Checked == true))
            {
                CHECK30 = 1;
            }
            else
            {
                CHECK30 = 0;
            }

            UInt32 CHECK31;
            if ((Form1.CheckBox31.Checked == true))
            {
                CHECK31 = 1;
            }
            else
            {
                CHECK31 = 0;
            }

            UInt32 CHECK32;
            if ((Form1.CheckBox32.Checked == true))
            {
                CHECK32 = 1;
            }
            else
            {
                CHECK32 = 0;
            }

            UInt32 CHECK33;
            if ((Form1.CheckBox33.Checked == true))
            {
                CHECK33 = 1;
            }
            else
            {
                CHECK33 = 0;
            }

            UInt32 CHECK34;
            if ((Form1.CheckBox34.Checked == true))
            {
                CHECK34 = 1;
            }
            else
            {
                CHECK34 = 0;
            }

            UInt32 CHECK35;
            if ((Form1.CheckBox35.Checked == true))
            {
                CHECK35 = 1;
            }
            else
            {
                CHECK35 = 0;
            }

            UInt32 CHECK36;
            if ((Form1.CheckBox36.Checked == true))
            {
                CHECK36 = 1;
            }
            else
            {
                CHECK36 = 0;
            }

            UInt32 CHECK37;
            if ((Form1.CheckBox37.Checked == true))
            {
                CHECK37 = 1;
            }
            else
            {
                CHECK37 = 0;
            }

            UInt32 CHECK38;
            if ((Form1.CheckBox38.Checked == true))
            {
                CHECK38 = 1;
            }
            else
            {
                CHECK38 = 0;
            }

            UInt32 CHECK39;
            if ((Form1.CheckBox39.Checked == true))
            {
                CHECK39 = 1;
            }
            else
            {
                CHECK39 = 0;
            }

            UInt32 CHECK40;
            if ((Form1.CheckBox40.Checked == true))
            {
                CHECK40 = 1;
            }
            else
            {
                CHECK40 = 0;
            }

            Aux = CHECK9;
            Aux = ShiftLeft(Aux, 31);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK10;
            Aux = ShiftLeft(Aux, 30);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK11;
            Aux = ShiftLeft(Aux, 29);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK12;
            Aux = ShiftLeft(Aux, 28);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK13;
            Aux = ShiftLeft(Aux, 27);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK14;
            Aux = ShiftLeft(Aux, 26);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK15;
            Aux = ShiftLeft(Aux, 25);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK16;
            Aux = ShiftLeft(Aux, 24);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK17;
            Aux = ShiftLeft(Aux, 23);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK18;
            Aux = ShiftLeft(Aux, 22);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK19;
            Aux = ShiftLeft(Aux, 21);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK20;
            Aux = ShiftLeft(Aux, 20);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK21;
            Aux = ShiftLeft(Aux, 19);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK22;
            Aux = ShiftLeft(Aux, 18);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK23;
            Aux = ShiftLeft(Aux, 17);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK24;
            Aux = ShiftLeft(Aux, 16);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK25;
            Aux = ShiftLeft(Aux, 15);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK26;
            Aux = ShiftLeft(Aux, 14);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK27;
            Aux = ShiftLeft(Aux, 13);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK28;
            Aux = ShiftLeft(Aux, 12);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK29;
            Aux = ShiftLeft(Aux, 11);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK30;
            Aux = ShiftLeft(Aux, 10);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK31;
            Aux = ShiftLeft(Aux, 9);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK32;
            Aux = ShiftLeft(Aux, 8);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK33;
            Aux = ShiftLeft(Aux, 7);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK34;
            Aux = ShiftLeft(Aux, 6);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK35;
            Aux = ShiftLeft(Aux, 5);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK36;
            Aux = ShiftLeft(Aux, 4);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK37;
            Aux = ShiftLeft(Aux, 3);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK38;
            Aux = ShiftLeft(Aux, 2);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK39;
            Aux = ShiftLeft(Aux, 1);
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            Aux = CHECK40;
            // Aux = Aux << 24
            Nuevo_val_32_9th = (Aux || Nuevo_val_32_9th);
            byte Aux_byte;
            byte Nuevo_val_byte_10th;
            byte CHECK3;
            if ((Form1.CheckBox3.Checked == true))
            {
                CHECK3 = 1;
            }
            else
            {
                CHECK3 = 0;
            }

            byte CHECK4;
            if ((Form1.CheckBox4.Checked == true))
            {
                CHECK4 = 1;
            }
            else
            {
                CHECK4 = 0;
            }

            byte CHECK5;
            if ((Form1.CheckBox5.Checked == true))
            {
                CHECK5 = 1;
            }
            else
            {
                CHECK5 = 0;
            }

            byte CHECK6;
            if ((Form1.CheckBox6.Checked == true))
            {
                CHECK6 = 1;
            }
            else
            {
                CHECK6 = 0;
            }

            byte CHECK7;
            if ((Form1.CheckBox7.Checked == true))
            {
                CHECK7 = 1;
            }
            else
            {
                CHECK7 = 0;
            }

            byte CHECK8;
            if ((Form1.CheckBox8.Checked == true))
            {
                CHECK8 = 1;
            }
            else
            {
                CHECK8 = 0;
            }

            byte CHECK141;
            if ((Form1.CheckBox111.Checked == true))
            {
                CHECK141 = 1;
            }
            else
            {
                CHECK141 = 0;
            }

            byte CHECK142;
            if ((Form1.CheckBox112.Checked == true))
            {
                CHECK142 = 1;
            }
            else
            {
                CHECK142 = 0;
            }

            Aux_byte = CHECK3;
            Aux_byte = ShiftLeft(Aux_byte, 7);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK4;
            Aux_byte = ShiftLeft(Aux_byte, 6);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK5;
            Aux_byte = ShiftLeft(Aux_byte, 5);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK6;
            Aux_byte = ShiftLeft(Aux_byte, 4);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK7;
            Aux_byte = ShiftLeft(Aux_byte, 3);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK8;
            Aux_byte = ShiftLeft(Aux_byte, 2);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK141;
            Aux_byte = ShiftLeft(Aux_byte, 1);
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            Aux_byte = CHECK142;
            // Aux_byte = Aux_byte << 7
            Nuevo_val_byte_10th = (Aux_byte || Nuevo_val_byte_10th);
            if (((Form1.Tipo_consola == 1)
                        || (Form1.Tipo_consola == 2)))
            {
                Nuevo_val_32_first = converter.bitworking_Player32_1_toConsole(Nuevo_val_32_first);
                Nuevo_val_32_2nd = converter.bitworking_Player32_14_toConsole(Nuevo_val_32_2nd);
                Nuevo_val_32_3rd = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_3rd);
                Nuevo_val_32_4th = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_4th);
                Nuevo_val_32_5th = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_5th);
                Nuevo_val_32_6th = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_6th);
                Nuevo_val_32_7th = converter.bitworking_Player32_12_toConsole(Nuevo_val_32_7th);
                Nuevo_val_32_8th = converter.bitworking_Player32_13_toConsole(Nuevo_val_32_8th);
                Nuevo_val_32_9th = swaps.swap32(converter.Reverse_int32(Nuevo_val_32_9th));
                Nuevo_val_byte_10th = converter.Reverse_byte(Nuevo_val_byte_10th);
            }

            Form1.Grabar_player.Write(Nuevo_val_32_first);
            Form1.Grabar_player.Write(Nuevo_val_32_2nd);
            Form1.Grabar_player.Write(Nuevo_val_32_3rd);
            Form1.Grabar_player.Write(Nuevo_val_32_4th);
            Form1.Grabar_player.Write(Nuevo_val_32_5th);
            Form1.Grabar_player.Write(Nuevo_val_32_6th);
            Form1.Grabar_player.Write(Nuevo_val_32_7th);
            Form1.Grabar_player.Write(Nuevo_val_32_8th);
            Form1.Grabar_player.Write(Nuevo_val_32_9th);
            Form1.Grabar_player.Write(Nuevo_val_byte_10th);
            // Grabar nombres
            Form1.Leer_Player.BaseStream.Position = (Index + Nombre_camiseta_pos);
            System.UInt32 Posicion_paraNombres = Form1.Leer_Player.BaseStream.Position;
            byte cero_cero = 0;
            for (i = 0; (i <= 91); i++)
            {
                Form1.Grabar_player.Write(cero_cero);
            }

            Form1.Leer_Player.BaseStream.Position = Posicion_paraNombres;
            string Nom_Jugador_shirt = Form1.Shirt_name.Text;
            Form1.Grabar_player.Write(Nom_Jugador_shirt.ToCharArray);
            Form1.Leer_Player.BaseStream.Position = (Posicion_paraNombres + 46);
            string Nom_Jugador = Form1.Name_box.Text;
            Form1.Grabar_player.Write(Nom_Jugador.ToCharArray);
        }

        public void save(string patch, ref MemoryStream memoryGicotori, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryGicotori.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Player_toConsole(ref memoryGicotori);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryGicotori, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Player_toConsole(ref memoryGicotori);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryGicotori, patch + PATH);
            }
        }

    }
}

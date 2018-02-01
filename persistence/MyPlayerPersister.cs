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

        public List<Player> load(string patch, int bitRecognized)
        {
            List<Player> playerList = new List<Player>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            UInt32 youthClubId;
            UInt32 playerId;
            byte[] Blocco;
            try
            {
                //calcolo giocatori
                // Create new FileInfo object and get the Length.
                int bytes_player = (int)memory1.Length;
                int calcolo_player = bytes_player / 192;

                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                long START5 = -192; //youth club id
                long START4 = -184; //id
                long START3 = -180; //Blocco
                long START6 = -140; //japanese name
                long START = -48; //player name
                long START2 = -94; //shirt name

                int i2 = 0;
                int NumberOfRepetitions = Convert.ToInt32(calcolo_player);
                for (i2 = 1; i2 <= NumberOfRepetitions; i2++)
                {
                    //id
                    START4 += 192;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    playerId = reader.ReadUInt32();

                    Player temp = new Player(playerId);

                    //youth player id
                    START5 += 192;
                    memory1.Seek(START5, SeekOrigin.Begin);
                    youthClubId = reader.ReadUInt32();
                    temp.setYouthPlayerId(youthClubId);

                    //Player Name
                    START += 192;
                    memory1.Seek(START, SeekOrigin.Begin);
                    temp.setPlayerName(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(46)).TrimEnd('\0'));

                    START2 += 192;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    //Shirt Name
                    temp.setShirtName(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(46)).TrimEnd('\0'));

                    START6 += 192;
                    memory1.Seek(START6, SeekOrigin.Begin);
                    //Japanese Name
                    temp.setJapanese(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(46)).TrimEnd('\0'));

                    //Blocco
                    START3 += 192;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    Blocco = reader.ReadBytes(37);
                    StringBuilder sba2 = new StringBuilder();
                    foreach (byte read2 in Blocco)
                        sba2.Append(read2.ToString("X2"));
                    string hexStringm2 = sba2.ToString();

                    //Weight (BYTE 15)
                    string blocco = hexStringm2.Substring(0, 8);
                    blocco = blocco.Substring(6, 2) + blocco.Substring(4, 2) + blocco.Substring(2, 2) + blocco.Substring(0, 2);
                    blocco = Convert.ToString(Convert.ToInt64(blocco, 16), 2).PadLeft(32, '0');

                    temp.setPlaceKick(MyBinary.BinaryToInt(blocco.Substring(0, 6)) + 40);
                    temp.setHeight(MyBinary.BinaryToInt(blocco.Substring(6, 8)) + 100);
                    temp.setNational2(MyBinary.BinaryToInt(blocco.Substring(14, 9)));
                    temp.setNational(MyBinary.BinaryToInt(blocco.Substring(23, 9)));

                    //(BYTE 19-18-17-16)
                    string blocco2 = hexStringm2.Substring(8, 8);
                    blocco2 = blocco2.Substring(6, 2) + blocco2.Substring(4, 2) + blocco2.Substring(2, 2) + blocco2.Substring(0, 2);
                    blocco2 = Convert.ToString(Convert.ToInt64(blocco2, 16), 2).PadLeft(32, '0');

                    temp.setDefense(MyBinary.BinaryToInt(blocco2.Substring(0, 6)) + 40);
                    temp.setClearing(MyBinary.BinaryToInt(blocco2.Substring(6, 6)) + 40);
                    temp.setLowPass(MyBinary.BinaryToInt(blocco2.Substring(12, 6)) + 40);
                    temp.setGoalCelebrate(MyBinary.BinaryToInt(blocco2.Substring(18, 7)));
                    temp.setWeight(MyBinary.BinaryToInt(blocco2.Substring(25, 7)) + 30);

                    //(BYTE 23-22-21-20)
                    string blocco3 = hexStringm2.Substring(16, 8);
                    blocco3 = blocco3.Substring(6, 2) + blocco3.Substring(4, 2) + blocco3.Substring(2, 2) + blocco3.Substring(0, 2);
                    blocco3 = Convert.ToString(Convert.ToInt64(blocco3, 16), 2).PadLeft(32, '0');

                    temp.setLb(MyBinary.BinaryToInt(blocco3.Substring(0, 2)));
                    temp.setCoverage(MyBinary.BinaryToInt(blocco3.Substring(2, 6)) + 40);
                    temp.setCathing(MyBinary.BinaryToInt(blocco3.Substring(8, 6)) + 40);
                    temp.setJump(MyBinary.BinaryToInt(blocco3.Substring(14, 6)) + 40);
                    temp.setHeader(MyBinary.BinaryToInt(blocco3.Substring(20, 6)) + 40);
                    temp.setBallControll(MyBinary.BinaryToInt(blocco3.Substring(26, 6)) + 40);

                    //(BYTE 27-26-25-24)
                    string blocco4 = hexStringm2.Substring(24, 8);
                    blocco4 = blocco4.Substring(6, 2) + blocco4.Substring(4, 2) + blocco4.Substring(2, 2) + blocco4.Substring(0, 2);
                    blocco4 = Convert.ToString(Convert.ToInt64(blocco4, 16), 2).PadLeft(32, '0');

                    temp.setGk(MyBinary.BinaryToInt(blocco4.Substring(0, 2)));
                    temp.setGoalkeeping(MyBinary.BinaryToInt(blocco4.Substring(2, 6)) + 40);
                    temp.setReflexes(MyBinary.BinaryToInt(blocco4.Substring(8, 6)) + 40);
                    temp.setFinishing(MyBinary.BinaryToInt(blocco4.Substring(14, 6)) + 40);
                    temp.setBallWinning(MyBinary.BinaryToInt(blocco4.Substring(20, 6)) + 40);
                    temp.setSpeed(MyBinary.BinaryToInt(blocco4.Substring(26, 6)) + 40);

                    //(BYTE 31-30-29-28)
                    string blocco5 = hexStringm2.Substring(32, 8);
                    blocco5 = blocco5.Substring(6, 2) + blocco5.Substring(4, 2) + blocco5.Substring(2, 2) + blocco5.Substring(0, 2);
                    blocco5 = Convert.ToString(Convert.ToInt64(blocco5, 16), 2).PadLeft(32, '0');

                    temp.setPenaltyKick(MyBinary.BinaryToInt(blocco5.Substring(0, 2)) + 1);
                    temp.setKickingPower(MyBinary.BinaryToInt(blocco5.Substring(2, 6)) + 40);
                    temp.setDribbling(MyBinary.BinaryToInt(blocco5.Substring(8, 6)) + 40);
                    temp.setExplosiveP(MyBinary.BinaryToInt(blocco5.Substring(14, 6)) + 40);
                    temp.setStamina(MyBinary.BinaryToInt(blocco5.Substring(20, 6)) + 40);
                    temp.setSwerve(MyBinary.BinaryToInt(blocco5.Substring(26, 6)) + 40);

                    //(BYTE 35-34-33-32)
                    string blocco6 = hexStringm2.Substring(40, 8);
                    blocco6 = blocco6.Substring(6, 2) + blocco6.Substring(4, 2) + blocco6.Substring(2, 2) + blocco6.Substring(0, 2);
                    blocco6 = Convert.ToString(Convert.ToInt64(blocco6, 16), 2).PadLeft(32, '0');

                    temp.setPlayingAttitude(MyBinary.BinaryToInt(blocco6.Substring(0, 2)));
                    temp.setAge(MyBinary.BinaryToInt(blocco6.Substring(2, 6)) + 15);
                    temp.setLoftedPass(MyBinary.BinaryToInt(blocco6.Substring(8, 6)) + 40);
                    temp.setPhysical(MyBinary.BinaryToInt(blocco6.Substring(14, 6)) + 40);
                    temp.setBodyControll(MyBinary.BinaryToInt(blocco6.Substring(20, 6)) + 40);
                    temp.setAttack(MyBinary.BinaryToInt(blocco6.Substring(26, 6)) + 40);

                    //(BYTE 39-38-37-36)
                    string blocco7 = hexStringm2.Substring(48, 8);
                    blocco7 = blocco7.Substring(6, 2) + blocco7.Substring(4, 2) + blocco7.Substring(2, 2) + blocco7.Substring(0, 2);
                    blocco7 = Convert.ToString(Convert.ToInt64(blocco7, 16), 2).PadLeft(32, '0');

                    temp.setWcUsage(MyBinary.BinaryToInt(blocco7.Substring(0, 2)) + 1);
                    temp.setDmf(MyBinary.BinaryToInt(blocco7.Substring(2, 2)));
                    temp.setStarPlayerIndicator(MyBinary.BinaryToInt(blocco7.Substring(4, 3)) + 1);
                    temp.setRunningArm(MyBinary.BinaryToInt(blocco7.Substring(7, 3)) + 1);
                    temp.setDriblingArm(MyBinary.BinaryToInt(blocco7.Substring(10, 3)) + 1);
                    temp.setCornerKick(MyBinary.BinaryToInt(blocco7.Substring(13, 3)) + 1);
                    temp.setForm(MyBinary.BinaryToInt(blocco7.Substring(16, 3)) + 1);
                    temp.setPosition(MyBinary.BinaryToInt(blocco7.Substring(19, 4)));
                    temp.setFreeKick(MyBinary.BinaryToInt(blocco7.Substring(23, 4)) + 1);
                    temp.setPlayingStyle(MyBinary.BinaryToInt(blocco7.Substring(27, 5)));

                    //(BYTE 43-42-41-40)
                    string blocco8 = hexStringm2.Substring(56, 8);
                    blocco8 = blocco8.Substring(6, 2) + blocco8.Substring(4, 2) + blocco8.Substring(2, 2) + blocco8.Substring(0, 2);
                    blocco8 = Convert.ToString(Convert.ToInt64(blocco8, 16), 2).PadLeft(32, '0');

                    if (blocco8.Substring(0, 1).Equals("1"))
                        temp.setSombrero(true);
                    else
                        temp.setSombrero(false);
                    if (blocco8.Substring(1, 1).Equals("1"))
                        temp.setEarlyCross(true);
                    else
                        temp.setEarlyCross(false);
                    temp.setUnk2(MyBinary.BinaryToInt(blocco8.Substring(2, 2))); //dribling motion
                    temp.setSs(MyBinary.BinaryToInt(blocco8.Substring(4, 2)));
                    temp.setRunningH(MyBinary.BinaryToInt(blocco8.Substring(6, 2)) + 1);
                    temp.setRwf(MyBinary.BinaryToInt(blocco8.Substring(8, 2)));
                    temp.setLmf(MyBinary.BinaryToInt(blocco8.Substring(10, 2)));
                    temp.setRb(MyBinary.BinaryToInt(blocco8.Substring(12, 2)));
                    temp.setLwf(MyBinary.BinaryToInt(blocco8.Substring(14, 2)));
                    temp.setCf(MyBinary.BinaryToInt(blocco8.Substring(16, 2)));
                    temp.setCb(MyBinary.BinaryToInt(blocco8.Substring(18, 2)));
                    temp.setDriblingH(MyBinary.BinaryToInt(blocco8.Substring(20, 2)) + 1);
                    temp.setAmf(MyBinary.BinaryToInt(blocco8.Substring(22, 2)));
                    temp.setWeakFootAcc(MyBinary.BinaryToInt(blocco8.Substring(24, 2)) + 1);
                    temp.setRmf(MyBinary.BinaryToInt(blocco8.Substring(26, 2)));
                    temp.setInjuryRes(MyBinary.BinaryToInt(blocco8.Substring(28, 2)) + 1);
                    temp.setCmf(MyBinary.BinaryToInt(blocco8.Substring(30, 2)));

                    //(BYTE 47-46-45-44)
                    string blocco9 = hexStringm2.Substring(64, 8);
                    blocco9 = blocco9.Substring(6, 2) + blocco9.Substring(4, 2) + blocco9.Substring(2, 2) + blocco9.Substring(0, 2);
                    blocco9 = Convert.ToString(Convert.ToInt64(blocco9, 16), 2).PadLeft(32, '0');

                    if (blocco9.Substring(0, 1).Equals("1"))
                        temp.setSchotMove(true);
                    else
                        temp.setSchotMove(false);
                    if (blocco9.Substring(1, 1).Equals("1"))
                        temp.setGkLong(true);
                    else
                        temp.setGkLong(false);

                    if (blocco9.Substring(2, 1).Equals("1"))
                        temp.setLongThrow(true);
                    else
                        temp.setLongThrow(false);
                    if (blocco9.Substring(3, 1).Equals("1"))
                        temp.setScissorFeint(true);
                    else
                        temp.setScissorFeint(false);
                    if (blocco9.Substring(4, 1).Equals("1"))
                        temp.setTrackBack(true);
                    else
                        temp.setTrackBack(false);
                    if (blocco9.Substring(5, 1).Equals("1"))
                        temp.setSuperSub(true);
                    else
                        temp.setSuperSub(false);
                    if (blocco9.Substring(6, 1).Equals("1"))
                        temp.setRabona(true);
                    else
                        temp.setRabona(false);
                    if (blocco9.Substring(7, 1).Equals("1"))
                        temp.setAcrobatingFinishing(true);
                    else
                        temp.setAcrobatingFinishing(false);
                    if (blocco9.Substring(8, 1).Equals("1"))
                        temp.setStrongerFoot(true);
                    else
                        temp.setStrongerFoot(false);
                    if (blocco9.Substring(9, 1).Equals("1"))
                        temp.setKnucleShot(true);
                    else
                        temp.setKnucleShot(false);
                    if (blocco9.Substring(10, 1).Equals("1"))
                        temp.setFirstTimeShot(true);
                    else
                        temp.setFirstTimeShot(false);
                    if (blocco9.Substring(11, 1).Equals("1"))
                        temp.setComIncisiveRun(true);
                    else
                        temp.setComIncisiveRun(false);
                    if (blocco9.Substring(12, 1).Equals("1"))
                        temp.setStrongerHand(true);
                    else
                        temp.setStrongerHand(false);
                    if (blocco9.Substring(13, 1).Equals("1"))
                        temp.setHiddenPlayer(true);
                    else
                        temp.setHiddenPlayer(false);
                    if (blocco9.Substring(14, 1).Equals("1"))
                        temp.setComLongRanger(true);
                    else
                        temp.setComLongRanger(false);
                    if (blocco9.Substring(15, 1).Equals("1"))
                        temp.setOneTouchPass(true);
                    else
                        temp.setOneTouchPass(false);
                    if (blocco9.Substring(16, 1).Equals("1"))
                        temp.setHellTick(true);
                    else
                        temp.setHellTick(false);
                    if (blocco9.Substring(17, 1).Equals("1"))
                        temp.setUnk4(true);
                    else
                        temp.setUnk4(false);
                    if (blocco9.Substring(18, 1).Equals("1"))
                        temp.setManMarking(true);
                    else
                        temp.setManMarking(false);
                    if (blocco9.Substring(19, 1).Equals("1"))
                        temp.setLegendGoldenBall(true);
                    else
                        temp.setLegendGoldenBall(false);
                    if (blocco9.Substring(20, 1).Equals("1"))
                        temp.setMarseilleTurn(true);
                    else
                        temp.setMarseilleTurn(false);
                    if (blocco9.Substring(21, 1).Equals("1"))
                        temp.setHeading(true);
                    else
                        temp.setHeading(false);
                    if (blocco9.Substring(22, 1).Equals("1"))
                        temp.setOutsideCurler(true);
                    else
                        temp.setOutsideCurler(false);
                    if (blocco9.Substring(23, 1).Equals("1"))
                        temp.setCaptaincy(true);
                    else
                        temp.setCaptaincy(false);
                    if (blocco9.Substring(24, 1).Equals("1"))
                        temp.setMalicia(true);
                    else
                        temp.setMalicia(false);
                    if (blocco9.Substring(25, 1).Equals("1"))
                        temp.setLowPuntTrajectory(true);
                    else
                        temp.setLowPuntTrajectory(false);
                    if (blocco9.Substring(26, 1).Equals("1"))
                        temp.setComTrickster(true);
                    else
                        temp.setComTrickster(false);
                    if (blocco9.Substring(27, 1).Equals("1"))
                        temp.setLowLoftedPass(true);
                    else
                        temp.setLowLoftedPass(false);
                    if (blocco9.Substring(28, 1).Equals("1"))
                        temp.setFightingSpirit(true);
                    else
                        temp.setFightingSpirit(false);
                    if (blocco9.Substring(29, 1).Equals("1"))
                        temp.setFlipFlap(true);
                    else
                        temp.setFlipFlap(false);
                    if (blocco9.Substring(30, 1).Equals("1"))
                        temp.setWeightnessPass(true);
                    else
                        temp.setWeightnessPass(false);
                    if (blocco9.Substring(31, 1).Equals("1"))
                        temp.setPinCrossing(true);
                    else
                        temp.setPinCrossing(false);

                    //(BYTE 48)
                    string blocco10 = hexStringm2.Substring(72, 2);
                    blocco10 = Convert.ToString(Convert.ToInt64(blocco10, 16), 2).PadLeft(8, '0');

                    if (blocco10.Substring(0, 1).Equals("1"))
                        temp.setUnk6(true);
                    else
                        temp.setUnk6(false);
                    if (blocco10.Substring(1, 1).Equals("1"))
                        temp.setUnk7(true);
                    else
                        temp.setUnk7(false);
                    if (blocco10.Substring(2, 1).Equals("1"))
                        temp.setComMazingRun(true);
                    else
                        temp.setComMazingRun(false);
                    if (blocco10.Substring(3, 1).Equals("1"))
                        temp.setAcrobatingClear(true);
                    else
                        temp.setAcrobatingClear(false);
                    if (blocco10.Substring(4, 1).Equals("1"))
                        temp.setComBallExpert(true);
                    else
                        temp.setComBallExpert(false);
                    if (blocco10.Substring(5, 1).Equals("1"))
                        temp.setCutBehind(true);
                    else
                        temp.setCutBehind(false);
                    if (blocco10.Substring(6, 1).Equals("1"))
                        temp.setLongRange(true);
                    else
                        temp.setLongRange(false);
                    if (blocco10.Substring(7, 1).Equals("1"))
                        temp.setSpeedingBullet(true);
                    else
                        temp.setSpeedingBullet(false);

                    playerList.Add(temp);

                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return playerList;
        }

        private void saveHex00(long value, BinaryWriter b)
        {
            string hex2klkoa6 = value.ToString("X8").Substring(6, 2) + " " + value.ToString("X8").Substring(4, 2) + " " + value.ToString("X8").Substring(2, 2) + " " + value.ToString("X8").Substring(0, 2);  // La tua stringa contenente i valori esadecimali
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        private void saveHex0(int value, BinaryWriter b)
        {
            string hex2klkoa6 = value.ToString("X8").Substring(6, 2) + " " + value.ToString("X8").Substring(4, 2) + " " + value.ToString("X8").Substring(2, 2) + " " + value.ToString("X8").Substring(0, 2);  // La tua stringa contenente i valori esadecimali
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        private void saveHex(int value, BinaryWriter b)
        {
            string hex2klkoa6 = MyBinary.IntToHex(value);  // La tua stringa contenente i valori esadecimali
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        private void saveHexText(int value, BinaryWriter b)
        {
            string hex2klkoa6 = "00";  // La tua stringa contenente i valori esadecimali
            for (int i = value; i < 45; i++)
            {
                hex2klkoa6 += " 00";
            }
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        public void save(string patch, Controller controller, int bitRecognized)
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(patch + PATH, FileMode.Create)))
            {
                // Use foreach and write all 12 integers.
                foreach (Player temp in controller.getListPlayer())
                {
                    saveHex00(temp.getYouthPlayerId(), b);
                    saveHex00(0, b);
                    saveHex00(temp.getId(), b);

                    //blocco 12/15
                    string unire1 = MyBinary.ToBinaryX(temp.getPlaceKick() - 40, 6) + MyBinary.ToBinaryX(temp.getHeight() - 100, 8) + MyBinary.ToBinaryX(temp.getNational2(), 9) + MyBinary.ToBinaryX(temp.getNational(), 9);
                    saveHex0(MyBinary.BinaryToInt(unire1), b);
                    //blocco 16/19
                    string unire2 = MyBinary.ToBinaryX(temp.getDefense() - 40, 6) + MyBinary.ToBinaryX(temp.getClearing() - 40, 6) + MyBinary.ToBinaryX(temp.getLowPass() - 40, 6) + MyBinary.ToBinaryX(temp.getGoalCelebrate(), 7) + MyBinary.ToBinaryX(temp.getWeight() - 30, 7);
                    saveHex0(MyBinary.BinaryToInt(unire2), b);
                    //blocco 20/23
                    string unire3 = MyBinary.ToBinaryX(temp.getLb(), 2) + MyBinary.ToBinaryX(temp.getCoverage() - 40, 6) + MyBinary.ToBinaryX(temp.getCathing() - 40, 6) + MyBinary.ToBinaryX(temp.getJump() - 40, 6) + MyBinary.ToBinaryX(temp.getHeader() - 40, 6) + MyBinary.ToBinaryX(temp.getBallControll() - 40, 6);
                    saveHex0(MyBinary.BinaryToInt(unire3), b);
                    //blocco 24/27
                    string unire4 = MyBinary.ToBinaryX(temp.getGk(), 2) + MyBinary.ToBinaryX(temp.getGoalkeeping() - 40, 6) + MyBinary.ToBinaryX(temp.getReflexes() - 40, 6) + MyBinary.ToBinaryX(temp.getFinishing() - 40, 6) + MyBinary.ToBinaryX(temp.getBallWinning() - 40, 6) + MyBinary.ToBinaryX(temp.getSpeed() - 40, 6);
                    saveHex0(MyBinary.BinaryToInt(unire4), b);
                    //blocco 28/31
                    string unire5 = MyBinary.ToBinaryX(temp.getPenaltyKick() - 1, 2) + MyBinary.ToBinaryX(temp.getKickingPower() - 40, 6) + MyBinary.ToBinaryX(temp.getDribbling() - 40, 6) + MyBinary.ToBinaryX(temp.getExplosiveP() - 40, 6) + MyBinary.ToBinaryX(temp.getStamina() - 40, 6) + MyBinary.ToBinaryX(temp.getSwerve() - 40, 6);
                    saveHex0(MyBinary.BinaryToInt(unire5), b);
                    //blocco 32/35
                    string unire6 = MyBinary.ToBinaryX(temp.getPlayingAttitude(), 2) + MyBinary.ToBinaryX(temp.getAge() - 15, 6) + MyBinary.ToBinaryX(temp.getLoftedPass() - 40, 6) + MyBinary.ToBinaryX(temp.getPhysical() - 40, 6) + MyBinary.ToBinaryX(temp.getBodyControll() - 40, 6) + MyBinary.ToBinaryX(temp.getAttack() - 40, 6);
                    saveHex0(MyBinary.BinaryToInt(unire6), b);
                    //blocco 36/39
                    string unire7 = MyBinary.ToBinaryX(temp.getWcUsage() - 1, 2) + MyBinary.ToBinaryX(temp.getDmf(), 2) + MyBinary.ToBinaryX(temp.getStarPlayerIndicator() - 1, 3) + MyBinary.ToBinaryX(temp.getRunningArm() - 1, 3) + MyBinary.ToBinaryX(temp.getDriblingArm() - 1, 3) + MyBinary.ToBinaryX(temp.getCornerKick() - 1, 3) + MyBinary.ToBinaryX(temp.getForm() - 1, 3) + MyBinary.ToBinaryX(temp.getPosition(), 4) + MyBinary.ToBinaryX(temp.getFreeKick() - 1, 4) + MyBinary.ToBinaryX(temp.getPlayingStyle(), 5);
                    saveHex0(MyBinary.BinaryToInt(unire7), b);
                    //blocco 40/43
                    string sombrero = "0";
                    if (temp.getSombrero())
                        sombrero = "1";

                    string early_cross = "0";
                    if (temp.getEarlyCross())
                        early_cross = "1";

                    string unire8 = sombrero + early_cross + MyBinary.ToBinaryX(temp.getUnk2(), 2) + MyBinary.ToBinaryX(temp.getSs(), 2) + MyBinary.ToBinaryX(temp.getRunningH() - 1, 2) + MyBinary.ToBinaryX(temp.getRwf(), 2) + MyBinary.ToBinaryX(temp.getLmf(), 2) + MyBinary.ToBinaryX(temp.getRb(), 2) + MyBinary.ToBinaryX(temp.getLwf(), 2) + MyBinary.ToBinaryX(temp.getCf(), 2) + MyBinary.ToBinaryX(temp.getCb(), 2) + MyBinary.ToBinaryX(temp.getDriblingH() - 1, 2) + MyBinary.ToBinaryX(temp.getAmf(), 2) + MyBinary.ToBinaryX(temp.getWeakFootAcc() - 1, 2) + MyBinary.ToBinaryX(temp.getRmf(), 2) + MyBinary.ToBinaryX(temp.getInjuryRes() - 1, 2) + MyBinary.ToBinaryX(temp.getCmf(), 2);
                    saveHex0(MyBinary.BinaryToInt(unire8), b);
                    //blocco 44/47
                    string schot_move = "0";
                    if (temp.getSchotMove())
                        schot_move = "1";

                    string gk_long = "0";
                    if (temp.getGkLong())
                        gk_long = "1";

                    string long_throw = "0";
                    if (temp.getLongThrow())
                        long_throw = "1";

                    string scissor_feint = "0";
                    if (temp.getScissorFeint())
                        scissor_feint = "1";

                    string track_back = "0";
                    if (temp.getTrackBack())
                        track_back = "1";

                    string super_sub = "0";
                    if (temp.getSuperSub())
                        super_sub = "1";

                    string rabona = "0";
                    if (temp.getRabona())
                        rabona = "1";

                    string acrobating_finishing = "0";
                    if (temp.getAcrobatingFinishing())
                        acrobating_finishing = "1";

                    string stronger_foot = "0";
                    if (temp.getStrongerFoot())
                        stronger_foot = "1";

                    string knucle_shot = "0";
                    if (temp.getKnucleShot())
                        knucle_shot = "1";

                    string first_time_shot = "0";
                    if (temp.getFirstTimeShot())
                        first_time_shot = "1";

                    string COM_incisive_run = "0";
                    if (temp.getComIncisiveRun())
                        COM_incisive_run = "1";

                    string strongerHand = "0";
                    if (temp.getStrongerHand())
                        strongerHand = "1";

                    string hidden_player = "0";
                    if (temp.getHiddenPlayer())
                        hidden_player = "1";

                    string COM_long_ranger = "0";
                    if (temp.getComLongRanger())
                        COM_long_ranger = "1";

                    string one_touch_pass = "0";
                    if (temp.getOneTouchPass())
                        one_touch_pass = "1";

                    string hell_tick = "0";
                    if (temp.getHellTick())
                        hell_tick = "1";

                    string unk4 = "0";
                    if (temp.getUnk4())
                        unk4 = "1";

                    string man_marking = "0";
                    if (temp.getManMarking())
                        man_marking = "1";

                    string legendGoldenBall = "0";
                    if (temp.getLegendGoldenBall())
                        legendGoldenBall = "1";

                    string marseille_turn = "0";
                    if (temp.getMarseilleTurn())
                        marseille_turn = "1";

                    string heading = "0";
                    if (temp.getHeading())
                        heading = "1";

                    string outside_curler = "0";
                    if (temp.getOutsideCurler())
                        outside_curler = "1";

                    string captaincy = "0";
                    if (temp.getCaptaincy())
                        captaincy = "1";

                    string malicia = "0";
                    if (temp.getMalicia())
                        malicia = "1";

                    string low_punt_trajectory = "0";
                    if (temp.getLowPuntTrajectory())
                        low_punt_trajectory = "1";

                    string com_trickster = "0";
                    if (temp.getComTrickster())
                        com_trickster = "1";

                    string low_lofted_pass = "0";
                    if (temp.getLowLoftedPass())
                        low_lofted_pass = "1";

                    string fighting_spirit = "0";
                    if (temp.getFightingSpirit())
                        fighting_spirit = "1";

                    string flip_flap = "0";
                    if (temp.getFlipFlap())
                        flip_flap = "1";

                    string weightness_pass = "0";
                    if (temp.getWeightnessPass())
                        weightness_pass = "1";

                    string pinpoint_crossing = "0";
                    if (temp.getPinCrossing())
                        pinpoint_crossing = "1";

                    //convertire in hex
                    string unire9 = schot_move + gk_long + long_throw + scissor_feint + track_back + super_sub + rabona + acrobating_finishing + stronger_foot + knucle_shot + first_time_shot + COM_incisive_run + strongerHand + hidden_player + COM_long_ranger + one_touch_pass + hell_tick + unk4 + man_marking + legendGoldenBall + marseille_turn + heading + outside_curler + captaincy + malicia + low_punt_trajectory + com_trickster + low_lofted_pass + fighting_spirit + flip_flap + weightness_pass + pinpoint_crossing;
                    saveHex0(MyBinary.BinaryToInt(unire9), b);
                    //blocco 48
                    string unk6 = "0";
                    if (temp.getUnk6())
                        unk6 = "1";

                    string unk7 = "0";
                    if (temp.getUnk7())
                        unk7 = "1";

                    string COM_mazing_run = "0";
                    if (temp.getComMazingRun())
                        COM_mazing_run = "1";

                    string acrobating_clear = "0";
                    if (temp.getAcrobatingClear())
                        acrobating_clear = "1";

                    string COM_ball_expert = "0";
                    if (temp.getComBallExpert())
                        COM_ball_expert = "1";

                    string cut_behind = "0";
                    if (temp.getCutBehind())
                        cut_behind = "1";

                    string long_range = "0";
                    if (temp.getLongRange())
                        long_range = "1";

                    string speeding_bullet = "0";
                    if (temp.getSpeedingBullet())
                        speeding_bullet = "1";

                    //convertire in hex
                    string unire10 = unk6 + unk7 + COM_mazing_run + acrobating_clear + COM_ball_expert + cut_behind + long_range + speeding_bullet;
                    saveHex0(MyBinary.BinaryToInt(unire10), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getJapanese()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getJapanese()).Count(), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getShirtName()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getShirtName()).Count(), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getPlayerName()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getPlayerName()).Count(), b);
                    saveHex(0, b);
                }
            }

            if (bitRecognized == 0)
            {
                //save zlib
                byte[] inputData = File.ReadAllBytes(patch + PATH);
                byte[] ss11 = Zlib18.ZLIBFile(inputData);
                File.WriteAllBytes(patch + PATH, ss11);
            }
            else if (bitRecognized == 1)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.Player_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.Player_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
        }

    }
}

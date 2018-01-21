using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;
using Team_Editor_Manager_New_Generation.persistence;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18
    public class MyPlayerAssignmentPersister
    {
        private static string PATH = "/PlayerAssignment.bin";

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
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAssignment_toPc(ref memory1);
            }

            return memory1;
        }

        public List<PlayerAssignment> load(string patch, int bitRecognized)
        {
            List<PlayerAssignment> playerAssignmentList = new List<PlayerAssignment>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //calcolo player assigment
            // Create new FileInfo object and get the Length.
            int bytes_pA = (int)memory1.Length;
            int calcolo_pA = bytes_pA / 16;

            UInt32 playerId;
            UInt16 teamId;
            UInt16 entryID;
            byte shirtNumber;
            UInt16 block;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader1 = new BinaryReader(memory1);

                long START6 = -16; // entryID
                long START2 = -12; // ID player
                long START1 = -8; // ID team
                long START3 = -4; // Number_Shirt
                long START4 = -3; // Order_player, Captain, Penalty Kick, Long shot lk, Left ck tk, Short foul fk, right corner kick

                int i1 = 0;
                for (i1 = 0; i1 < calcolo_pA; i1++)
                {
                    START6 += 16;
                    memory1.Seek(START6, SeekOrigin.Begin);
                    entryID = reader1.ReadUInt16();

                    START1 += 16;
                    memory1.Seek(START1, SeekOrigin.Begin);
                    teamId = reader1.ReadUInt16();

                    START2 += 16;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    playerId = reader1.ReadUInt32();

                    START3 += 16;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    shirtNumber = reader1.ReadByte();

                    START4 += 16;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    block = reader1.ReadUInt16();

                    PlayerAssignment temp = new PlayerAssignment(playerId, teamId);
                    temp.setEntryId(entryID);
                    temp.setShirtNumber(shirtNumber);
                    temp.setCaptain(parseBoolean(MyBinary.ToBinary16(block).Substring(4, 1), "1", "0"));
                    temp.setPenaltyKick(parseBoolean(MyBinary.ToBinary16(block).Substring(5, 1), "1", "0"));
                    temp.setLongShotLk(parseBoolean(MyBinary.ToBinary16(block).Substring(6, 1), "1", "0"));
                    temp.setLeftCkTk(parseBoolean(MyBinary.ToBinary16(block).Substring(7, 1), "1", "0"));
                    temp.setShortFoulFk(parseBoolean(MyBinary.ToBinary16(block).Substring(8, 1), "1", "0"));
                    temp.setRightCornerKick(parseBoolean(MyBinary.ToBinary16(block).Substring(9, 1), "1", "0"));
                    temp.setOrder(MyBinary.BinaryToInt(MyBinary.ToBinary16(block).Substring(10, 6)));

                    playerAssignmentList.Add(temp);
                }
                //
                memory1.Close();
                reader1.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }


            return playerAssignmentList;
        }

        private bool parseBoolean(string s, string trueValue, string falseValue)
        {
		    if (s.Trim().ToUpper().Equals(trueValue)) {
			    return true;
		    }
            if (s.Trim().ToUpper().Equals(falseValue))
            {
			    return false;
		    }
            throw new Exception("reading error!" + s);
        }

        private void saveHex0(long value, BinaryWriter b)
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

        private void saveHex2(int value, BinaryWriter b)
        {
            string hex2klkoa6 = value.ToString("X2");  // La tua stringa contenente i valori esadecimali
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
            // TODO Auto-generated method stub
            using (BinaryWriter b = new BinaryWriter(File.Open(patch + PATH, FileMode.Create)))
            {
                // Use foreach and write all 12 integers.
                foreach (PlayerAssignment temp in controller.getPlayerAssignmentList())
                {
                    saveHex(temp.getEntryId(), b);
                    saveHex(0, b);
                    saveHex0(temp.getPlayerId(), b);
                    saveHex(temp.getTeamId(), b);
                    saveHex(0, b);
                    saveHex2(temp.getShirtNumber(), b);

                    string playerOrder = temp.getOrder().ToString("X2");
                    playerOrder = Convert.ToString(Convert.ToInt64(playerOrder, 16), 2).PadLeft(6, '0');

                    int captain = 0;
                    if (temp.getCaptain())
                        captain = 1;

                    int penalty = 0;
                    if (temp.getPenaltyKick())
                        penalty = 1;

                    int longShot = 0;
                    if (temp.getLongShotLk())
                        longShot = 1;

                    int leftCkTk = 0;
                    if (temp.getLeftCkTk())
                        leftCkTk = 1;

                    int shortFoulFk = 0;
                    if (temp.getShortFoulFk())
                        shortFoulFk = 1;

                    int rightCornerKick = 0;
                    if (temp.getRightCornerKick())
                        rightCornerKick = 1;

                    saveHex(MyBinary.BinaryToInt(captain.ToString() + penalty.ToString() + longShot.ToString() + leftCkTk.ToString() + shortFoulFk.ToString() + rightCornerKick.ToString() + playerOrder.ToString()), b);
                    saveHex2(0, b);
                }
            }

            if (bitRecognized == 0)
            {
                //save zlib
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                byte[] ss13 = Zlib18.ZLIBFile(inputData13);
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAssignment_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAssignment_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
        }
    }
}

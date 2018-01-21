using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DinoTem.model;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18, pes 17
    public class MyPlayerAppearancePersister
    {
        private static string PATH = "/PlayerAppearance.bin";

        private MemoryStream unzlib(string patch, int bitRecognized)
        {
            MemoryStream memory1 = null;
            if (bitRecognized == 0)
            {
                byte[] file = File.ReadAllBytes(patch + PATH);
                memory1 = new MemoryStream(file);
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                byte[] file = File.ReadAllBytes(patch + PATH);
                memory1 = new MemoryStream(file);
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAppearance(ref memory1);
            }

            return memory1;
        }

        public List<PlayerAppearance> load(string patch, int bitRecognized)
        {
            List<PlayerAppearance> playerAppearanceList = new List<PlayerAppearance>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //calcolo giocatori
            // Create new FileInfo object and get the Length.
            int bytes_player = (int)memory1.Length;
            int calcolo_player = bytes_player / 60;

            UInt32 IdPlayer;
            byte unknown1;
            byte unknown2;
            byte unknown3;
            byte unknown4;
            byte unknown5;
            byte unknown6;
            byte unknown7;
            byte unknown8;
            byte unknown9;
            byte unknown10;
            byte unknown11;
            byte unknown12;
            byte unknown13;
            byte unknown14;
            byte unknown15;
            byte unknown16;
            byte unknown17;
            byte unknown18;
            byte unknown19;
            byte unknown20;
            byte unknown21;
            byte unknown22;
            byte unknown23;
            byte unknown24;
            byte unknown25;
            byte unknown26;
            byte unknown27;
            byte unknown28;
            byte unknown29;
            byte unknown30;
            byte unknown31;
            byte unknown32;
            byte unknown33;
            byte unknown34;
            byte unknown35;
            byte unknown36;
            byte eyeSkinColor;
            byte unknown38;
            byte unknown39;
            byte unknown40;
            byte unknown41;
            byte unknown42;
            byte unknown43;
            byte unknown44;
            byte unknown45;
            byte unknown46;
            byte unknown47;
            byte unknown48;
            byte unknown49;
            byte unknown50;
            byte unknown51;
            byte unknown52;
            byte unknown53;
            byte unknown54;
            byte unknown55;
            byte unknown56;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i = 0;

                long START1 = -60; //ID
                long START2 = -56;
                long START3 = -55;
                long START4 = -54;
                long START5 = -53;
                long START6 = -52;
                long START7 = -51;
                long START8 = -50;
                long START9 = -49;
                long START10 = -48;
                long START11 = -47;
                long START12 = -46;
                long START13 = -45;
                long START14 = -44;
                long START15 = -43;
                long START16 = -42;
                long START17 = -41;
                long START18 = -40;
                long START19 = -39;
                long START20 = -38;
                long START21 = -37;
                long START22 = -36;
                long START23 = -35;
                long START24 = -34;
                long START25 = -33;
                long START26 = -32;
                long START27 = -31;
                long START28 = -30;
                long START29 = -29;
                long START30 = -28;
                long START31 = -27;
                long START32 = -26;
                long START33 = -25;
                long START34 = -24;
                long START35 = -23;
                long START36 = -22;
                long START37 = -21;
                long START38 = -20;
                long START39 = -19;
                long START40 = -18;
                long START41 = -17;
                long START42 = -16;
                long START43 = -15;
                long START44 = -14;
                long START45 = -13;
                long START46 = -12;
                long START47 = -11;
                long START48 = -10;
                long START49 = -9;
                long START50 = -8;
                long START51 = -7;
                long START52 = -6;
                long START53 = -5;
                long START54 = -4;
                long START55 = -3;
                long START56 = -2;
                long START57 = -1;

                int NumberOfRepetitions = Convert.ToInt32(calcolo_player);
                for (i = 1; i <= NumberOfRepetitions; i++)
                {
                    START1 += 60;
                    memory1.Seek(START1, SeekOrigin.Begin);
                    IdPlayer = reader.ReadUInt32();

                    START2 += 60;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    unknown1 = reader.ReadByte();

                    START3 += 60;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    unknown2 = reader.ReadByte();

                    START4 += 60;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    unknown3 = reader.ReadByte();

                    START5 += 60;
                    memory1.Seek(START5, SeekOrigin.Begin);
                    unknown4 = reader.ReadByte();

                    START6 += 60;
                    memory1.Seek(START6, SeekOrigin.Begin);
                    unknown5 = reader.ReadByte();

                    START7 += 60;
                    memory1.Seek(START7, SeekOrigin.Begin);
                    unknown6 = reader.ReadByte();

                    START8 += 60;
                    memory1.Seek(START8, SeekOrigin.Begin);
                    unknown7 = reader.ReadByte();

                    START9 += 60;
                    memory1.Seek(START9, SeekOrigin.Begin);
                    unknown8 = reader.ReadByte();

                    START10 += 60;
                    memory1.Seek(START10, SeekOrigin.Begin);
                    unknown9 = reader.ReadByte();

                    START11 += 60;
                    memory1.Seek(START11, SeekOrigin.Begin);
                    unknown10 = reader.ReadByte();

                    START12 += 60;
                    memory1.Seek(START12, SeekOrigin.Begin);
                    unknown11 = reader.ReadByte();

                    START13 += 60;
                    memory1.Seek(START13, SeekOrigin.Begin);
                    unknown12 = reader.ReadByte();

                    START14 += 60;
                    memory1.Seek(START14, SeekOrigin.Begin);
                    unknown13 = reader.ReadByte();

                    START15 += 60;
                    memory1.Seek(START15, SeekOrigin.Begin);
                    unknown14 = reader.ReadByte();

                    START16 += 60;
                    memory1.Seek(START16, SeekOrigin.Begin);
                    unknown15 = reader.ReadByte();

                    START17 += 60;
                    memory1.Seek(START17, SeekOrigin.Begin);
                    unknown16 = reader.ReadByte();

                    START18 += 60;
                    memory1.Seek(START18, SeekOrigin.Begin);
                    unknown17 = reader.ReadByte();

                    START19 += 60;
                    memory1.Seek(START19, SeekOrigin.Begin);
                    unknown18 = reader.ReadByte();

                    START20 += 60;
                    memory1.Seek(START20, SeekOrigin.Begin);
                    unknown19 = reader.ReadByte();

                    START21 += 60;
                    memory1.Seek(START21, SeekOrigin.Begin);
                    unknown20 = reader.ReadByte();

                    START22 += 60;
                    memory1.Seek(START22, SeekOrigin.Begin);
                    unknown21 = reader.ReadByte();

                    START23 += 60;
                    memory1.Seek(START23, SeekOrigin.Begin);
                    unknown22 = reader.ReadByte();

                    START24 += 60;
                    memory1.Seek(START24, SeekOrigin.Begin);
                    unknown23 = reader.ReadByte();

                    START25 += 60;
                    memory1.Seek(START25, SeekOrigin.Begin);
                    unknown24 = reader.ReadByte();

                    START26 += 60;
                    memory1.Seek(START26, SeekOrigin.Begin);
                    unknown25 = reader.ReadByte();

                    START27 += 60;
                    memory1.Seek(START27, SeekOrigin.Begin);
                    unknown26 = reader.ReadByte();

                    START28 += 60;
                    memory1.Seek(START28, SeekOrigin.Begin);
                    unknown27 = reader.ReadByte();

                    START29 += 60;
                    memory1.Seek(START29, SeekOrigin.Begin);
                    unknown28 = reader.ReadByte();

                    START30 += 60;
                    memory1.Seek(START30, SeekOrigin.Begin);
                    unknown29 = reader.ReadByte();

                    START31 += 60;
                    memory1.Seek(START31, SeekOrigin.Begin);
                    unknown30 = reader.ReadByte();

                    START32 += 60;
                    memory1.Seek(START32, SeekOrigin.Begin);
                    unknown31 = reader.ReadByte();

                    START33 += 60;
                    memory1.Seek(START33, SeekOrigin.Begin);
                    unknown32 = reader.ReadByte();

                    START34 += 60;
                    memory1.Seek(START34, SeekOrigin.Begin);
                    unknown33 = reader.ReadByte();

                    START35 += 60;
                    memory1.Seek(START35, SeekOrigin.Begin);
                    eyeSkinColor = reader.ReadByte();

                    START36 += 60;
                    memory1.Seek(START36, SeekOrigin.Begin);
                    unknown34 = reader.ReadByte();

                    START37 += 60;
                    memory1.Seek(START37, SeekOrigin.Begin);
                    unknown35 = reader.ReadByte();

                    START38 += 60;
                    memory1.Seek(START38, SeekOrigin.Begin);
                    unknown36 = reader.ReadByte();

                    START39 += 60;
                    memory1.Seek(START39, SeekOrigin.Begin);
                    unknown38 = reader.ReadByte();

                    START40 += 60;
                    memory1.Seek(START40, SeekOrigin.Begin);
                    unknown39 = reader.ReadByte();

                    START41 += 60;
                    memory1.Seek(START41, SeekOrigin.Begin);
                    unknown40 = reader.ReadByte();

                    START42 += 60;
                    memory1.Seek(START42, SeekOrigin.Begin);
                    unknown41 = reader.ReadByte();

                    START43 += 60;
                    memory1.Seek(START43, SeekOrigin.Begin);
                    unknown42 = reader.ReadByte();

                    START44 += 60;
                    memory1.Seek(START44, SeekOrigin.Begin);
                    unknown43 = reader.ReadByte();

                    START45 += 60;
                    memory1.Seek(START45, SeekOrigin.Begin);
                    unknown44 = reader.ReadByte();

                    START46 += 60;
                    memory1.Seek(START46, SeekOrigin.Begin);
                    unknown45 = reader.ReadByte();

                    START47 += 60;
                    memory1.Seek(START47, SeekOrigin.Begin);
                    unknown46 = reader.ReadByte();

                    START48 += 60;
                    memory1.Seek(START48, SeekOrigin.Begin);
                    unknown47 = reader.ReadByte();

                    START49 += 60;
                    memory1.Seek(START49, SeekOrigin.Begin);
                    unknown48 = reader.ReadByte();

                    START50 += 60;
                    memory1.Seek(START50, SeekOrigin.Begin);
                    unknown49 = reader.ReadByte();

                    START51 += 60;
                    memory1.Seek(START51, SeekOrigin.Begin);
                    unknown50 = reader.ReadByte();

                    START52 += 60;
                    memory1.Seek(START52, SeekOrigin.Begin);
                    unknown51 = reader.ReadByte();

                    START53 += 60;
                    memory1.Seek(START53, SeekOrigin.Begin);
                    unknown52 = reader.ReadByte();

                    START54 += 60;
                    memory1.Seek(START54, SeekOrigin.Begin);
                    unknown53 = reader.ReadByte();

                    START55 += 60;
                    memory1.Seek(START55, SeekOrigin.Begin);
                    unknown54 = reader.ReadByte();

                    START56 += 60;
                    memory1.Seek(START56, SeekOrigin.Begin);
                    unknown55 = reader.ReadByte();

                    START57 += 60;
                    memory1.Seek(START57, SeekOrigin.Begin);
                    unknown56 = reader.ReadByte();

                    PlayerAppearance temp = new PlayerAppearance(IdPlayer);
                    temp.setUnknown1(unknown1);
                    temp.setUnknown2(unknown2);
                    temp.setUnknown3(unknown3);
                    temp.setUnknown4(unknown4);
                    temp.setUnknown5(unknown5);
                    temp.setUnknown6(unknown6);
                    temp.setUnknown7(unknown7);
                    temp.setUnknown8(unknown8);
                    temp.setUnknown9(unknown9);
                    temp.setUnknown10(unknown10);
                    temp.setUnknown11(unknown11);
                    temp.setUnknown12(unknown12);
                    temp.setUnknown13(unknown13);
                    temp.setUnknown14(unknown14);
                    temp.setUnknown15(unknown15);
                    temp.setUnknown16(unknown16);
                    temp.setUnknown17(unknown17);
                    temp.setUnknown18(unknown18);
                    temp.setUnknown19(unknown19);
                    temp.setUnknown20(unknown20);
                    temp.setUnknown21(unknown21);
                    temp.setUnknown22(unknown22);
                    temp.setUnknown23(unknown23);
                    temp.setUnknown24(unknown24);
                    temp.setUnknown25(unknown25);
                    temp.setUnknown26(unknown26);
                    temp.setUnknown27(unknown27);
                    temp.setUnknown28(unknown28);
                    temp.setUnknown29(unknown29);
                    temp.setUnknown30(unknown30);
                    temp.setUnknown31(unknown31);
                    temp.setUnknown32(unknown32);
                    temp.setUnknown33(unknown33);
					temp.setEyeskinColor(eyeSkinColor);
                    temp.setUnknown34(unknown34);
                    temp.setUnknown35(unknown35);
                    temp.setUnknown36(unknown36);
                    temp.setUnknown38(unknown38);
                    temp.setUnknown39(unknown39);
                    temp.setUnknown40(unknown40);
                    temp.setUnknown41(unknown41);
                    temp.setUnknown42(unknown42);
                    temp.setUnknown43(unknown43);
                    temp.setUnknown44(unknown44);
                    temp.setUnknown45(unknown45);
                    temp.setUnknown46(unknown46);
                    temp.setUnknown47(unknown47);
                    temp.setUnknown48(unknown48);
                    temp.setUnknown49(unknown49);
                    temp.setUnknown50(unknown50);
                    temp.setUnknown51(unknown51);
                    temp.setUnknown52(unknown52);
                    temp.setUnknown53(unknown53);
                    temp.setUnknown54(unknown54);
                    temp.setUnknown55(unknown55);
                    temp.setUnknown56(unknown56);

                    playerAppearanceList.Add(temp);

                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return playerAppearanceList;
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
            using (BinaryWriter b = new BinaryWriter(File.Open(patch + PATH, FileMode.Create)))
            {
                // Use foreach and write all 12 integers.
                foreach (PlayerAppearance temp in controller.getPlayerAppearanceList())
                {
                    saveHex0(temp.getId(), b);
                    saveHex2(temp.getUnknown1(), b);
                    saveHex2(temp.getUnknown2(), b);
                    saveHex2(temp.getUnknown3(), b);
                    saveHex2(temp.getUnknown4(), b);
                    saveHex2(temp.getUnknown5(), b);
                    saveHex2(temp.getUnknown6(), b);
                    saveHex2(temp.getUnknown7(), b);
                    saveHex2(temp.getUnknown8(), b);
                    saveHex2(temp.getUnknown9(), b);
                    saveHex2(temp.getUnknown10(), b);
                    saveHex2(temp.getUnknown11(), b);
                    saveHex2(temp.getUnknown12(), b);
                    saveHex2(temp.getUnknown13(), b);
                    saveHex2(temp.getUnknown14(), b);
                    saveHex2(temp.getUnknown15(), b);
                    saveHex2(temp.getUnknown16(), b);
                    saveHex2(temp.getUnknown17(), b);
                    saveHex2(temp.getUnknown18(), b);
                    saveHex2(temp.getUnknown19(), b);
                    saveHex2(temp.getUnknown20(), b);
                    saveHex2(temp.getUnknown21(), b);
                    saveHex2(temp.getUnknown22(), b);
                    saveHex2(temp.getUnknown23(), b);
                    saveHex2(temp.getUnknown24(), b);
                    saveHex2(temp.getUnknown25(), b);
                    saveHex2(temp.getUnknown26(), b);
                    saveHex2(temp.getUnknown27(), b);
                    saveHex2(temp.getUnknown28(), b);
                    saveHex2(temp.getUnknown29(), b);
                    saveHex2(temp.getUnknown30(), b);
                    saveHex2(temp.getUnknown31(), b);
                    saveHex2(temp.getUnknown32(), b);
                    saveHex2(temp.getUnknown33(), b);
                    saveHex2(temp.getEyeskinColor(), b);
                    saveHex2(temp.getUnknown34(), b);
                    saveHex2(temp.getUnknown35(), b);
                    saveHex2(temp.getUnknown36(), b);
                    saveHex2(temp.getUnknown38(), b);
                    saveHex2(temp.getUnknown39(), b);
                    saveHex2(temp.getUnknown40(), b);
                    saveHex2(temp.getUnknown41(), b);
                    saveHex2(temp.getUnknown42(), b);
                    saveHex2(temp.getUnknown43(), b);
                    saveHex2(temp.getUnknown44(), b);
                    saveHex2(temp.getUnknown45(), b);
                    saveHex2(temp.getUnknown46(), b);
                    saveHex2(temp.getUnknown47(), b);
                    saveHex2(temp.getUnknown48(), b);
                    saveHex2(temp.getUnknown49(), b);
                    saveHex2(temp.getUnknown50(), b);
                    saveHex2(temp.getUnknown51(), b);
                    saveHex2(temp.getUnknown52(), b);
                    saveHex2(temp.getUnknown53(), b);
                    saveHex2(temp.getUnknown54(), b);
                    saveHex2(temp.getUnknown55(), b);
                    saveHex2(temp.getUnknown56(), b);
                }
            }

            if (bitRecognized == 1 || bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAppearance(ref memory1);
                File.WriteAllBytes(patch + PATH, memory1.ToArray());
                memory1.Close();
            }

        }

    }
}

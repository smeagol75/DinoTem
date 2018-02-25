using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DinoTem.model;
using DinoTem.ui;
using Team_Editor_Manager_New_Generation.zlibUnzlib;

namespace DinoTem.persistence
{
    //pes 18, pes 17
    public class MyPlayerAppearancePersister
    {
        private static string PATH = "/PlayerAppearance.bin";
        private static int block = 60;

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            byte[] file = File.ReadAllBytes(patch + PATH);
            memory1 = new MemoryStream(file);

            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public PlayerAppearance loadPlayerAppearance(UInt32 id, int bitRecognized, MemoryStream memory1, BinaryReader reader)
        {
            PlayerAppearance temp = null;

            //calcolo giocatori
            // Create new FileInfo object and get the Length.
            int bytes_player = (int)memory1.Length;
            int calcolo_player = bytes_player / block;

            UInt32 IdPlayer = 0;
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
                for (int i = 1; i <= NumberOfRepetitions; i++)
                {
                    START1 += block;
                    START2 += block;
                    START3 += block;
                    START4 += block;
                    START5 += block;
                    START6 += block;
                    START7 += block;
                    START8 += block;
                    START9 += block;
                    START10 += block;
                    START11 += block;
                    START12 += block;
                    START13 += block;
                    START14 += block;
                    START15 += block;
                    START16 += block;
                    START17 += block;
                    START18 += block;
                    START19 += block;
                    START20 += block;
                    START21 += block;
                    START22 += block;
                    START23 += block;
                    START24 += block;
                    START25 += block;
                    START26 += block;
                    START27 += block;
                    START28 += block;
                    START29 += block;
                    START30 += block;
                    START31 += block;
                    START32 += block;
                    START33 += block;
                    START34 += block;
                    START35 += block;
                    START36 += block;
                    START37 += block;
                    START38 += block;
                    START39 += block;
                    START40 += block;
                    START41 += block;
                    START42 += block;
                    START43 += block;
                    START44 += block;
                    START45 += block;
                    START46 += block;
                    START47 += block;
                    START48 += block;
                    START49 += block;
                    START50 += block;
                    START51 += block;
                    START52 += block;
                    START53 += block;
                    START54 += block;
                    START55 += block;
                    START56 += block;
                    START57 += block;

                    memory1.Seek(START1, SeekOrigin.Begin);
                    if (bitRecognized == 0)
                        IdPlayer = reader.ReadUInt32();
                    else if (bitRecognized == 1 || bitRecognized == 2)
                        IdPlayer = UnzlibZlibConsole.swaps.swap32(reader.ReadUInt32());

                    if (IdPlayer == id)
                    {
                        memory1.Seek(START2, SeekOrigin.Begin);
                        unknown1 = reader.ReadByte();

                        memory1.Seek(START3, SeekOrigin.Begin);
                        unknown2 = reader.ReadByte();

                        memory1.Seek(START4, SeekOrigin.Begin);
                        unknown3 = reader.ReadByte();

                        memory1.Seek(START5, SeekOrigin.Begin);
                        unknown4 = reader.ReadByte();

                        memory1.Seek(START6, SeekOrigin.Begin);
                        unknown5 = reader.ReadByte();

                        memory1.Seek(START7, SeekOrigin.Begin);
                        unknown6 = reader.ReadByte();

                        memory1.Seek(START8, SeekOrigin.Begin);
                        unknown7 = reader.ReadByte();

                        memory1.Seek(START9, SeekOrigin.Begin);
                        unknown8 = reader.ReadByte();

                        memory1.Seek(START10, SeekOrigin.Begin);
                        unknown9 = reader.ReadByte();

                        memory1.Seek(START11, SeekOrigin.Begin);
                        unknown10 = reader.ReadByte();

                        memory1.Seek(START12, SeekOrigin.Begin);
                        unknown11 = reader.ReadByte();

                        memory1.Seek(START13, SeekOrigin.Begin);
                        unknown12 = reader.ReadByte();

                        memory1.Seek(START14, SeekOrigin.Begin);
                        unknown13 = reader.ReadByte();

                        memory1.Seek(START15, SeekOrigin.Begin);
                        unknown14 = reader.ReadByte();

                        memory1.Seek(START16, SeekOrigin.Begin);
                        unknown15 = reader.ReadByte();

                        memory1.Seek(START17, SeekOrigin.Begin);
                        unknown16 = reader.ReadByte();

                        memory1.Seek(START18, SeekOrigin.Begin);
                        unknown17 = reader.ReadByte();

                        memory1.Seek(START19, SeekOrigin.Begin);
                        unknown18 = reader.ReadByte();

                        memory1.Seek(START20, SeekOrigin.Begin);
                        unknown19 = reader.ReadByte();

                        memory1.Seek(START21, SeekOrigin.Begin);
                        unknown20 = reader.ReadByte();

                        memory1.Seek(START22, SeekOrigin.Begin);
                        unknown21 = reader.ReadByte();

                        memory1.Seek(START23, SeekOrigin.Begin);
                        unknown22 = reader.ReadByte();

                        memory1.Seek(START24, SeekOrigin.Begin);
                        unknown23 = reader.ReadByte();

                        memory1.Seek(START25, SeekOrigin.Begin);
                        unknown24 = reader.ReadByte();

                        memory1.Seek(START26, SeekOrigin.Begin);
                        unknown25 = reader.ReadByte();

                        memory1.Seek(START27, SeekOrigin.Begin);
                        unknown26 = reader.ReadByte();

                        memory1.Seek(START28, SeekOrigin.Begin);
                        unknown27 = reader.ReadByte();

                        memory1.Seek(START29, SeekOrigin.Begin);
                        unknown28 = reader.ReadByte();

                        memory1.Seek(START30, SeekOrigin.Begin);
                        unknown29 = reader.ReadByte();

                        memory1.Seek(START31, SeekOrigin.Begin);
                        unknown30 = reader.ReadByte();

                        memory1.Seek(START32, SeekOrigin.Begin);
                        unknown31 = reader.ReadByte();

                        memory1.Seek(START33, SeekOrigin.Begin);
                        unknown32 = reader.ReadByte();

                        memory1.Seek(START34, SeekOrigin.Begin);
                        unknown33 = reader.ReadByte();

                        memory1.Seek(START35, SeekOrigin.Begin);
                        eyeSkinColor = reader.ReadByte();

                        memory1.Seek(START36, SeekOrigin.Begin);
                        unknown34 = reader.ReadByte();

                        memory1.Seek(START37, SeekOrigin.Begin);
                        unknown35 = reader.ReadByte();

                        memory1.Seek(START38, SeekOrigin.Begin);
                        unknown36 = reader.ReadByte();

                        memory1.Seek(START39, SeekOrigin.Begin);
                        unknown38 = reader.ReadByte();

                        memory1.Seek(START40, SeekOrigin.Begin);
                        unknown39 = reader.ReadByte();

                        memory1.Seek(START41, SeekOrigin.Begin);
                        unknown40 = reader.ReadByte();

                        memory1.Seek(START42, SeekOrigin.Begin);
                        unknown41 = reader.ReadByte();

                        memory1.Seek(START43, SeekOrigin.Begin);
                        unknown42 = reader.ReadByte();

                        memory1.Seek(START44, SeekOrigin.Begin);
                        unknown43 = reader.ReadByte();

                        memory1.Seek(START45, SeekOrigin.Begin);
                        unknown44 = reader.ReadByte();

                        memory1.Seek(START46, SeekOrigin.Begin);
                        unknown45 = reader.ReadByte();

                        memory1.Seek(START47, SeekOrigin.Begin);
                        unknown46 = reader.ReadByte();

                        memory1.Seek(START48, SeekOrigin.Begin);
                        unknown47 = reader.ReadByte();

                        memory1.Seek(START49, SeekOrigin.Begin);
                        unknown48 = reader.ReadByte();

                        memory1.Seek(START50, SeekOrigin.Begin);
                        unknown49 = reader.ReadByte();

                        memory1.Seek(START51, SeekOrigin.Begin);
                        unknown50 = reader.ReadByte();

                        memory1.Seek(START52, SeekOrigin.Begin);
                        unknown51 = reader.ReadByte();

                        memory1.Seek(START53, SeekOrigin.Begin);
                        unknown52 = reader.ReadByte();

                        memory1.Seek(START54, SeekOrigin.Begin);
                        unknown53 = reader.ReadByte();

                        memory1.Seek(START55, SeekOrigin.Begin);
                        unknown54 = reader.ReadByte();

                        memory1.Seek(START56, SeekOrigin.Begin);
                        unknown55 = reader.ReadByte();

                        memory1.Seek(START57, SeekOrigin.Begin);
                        unknown56 = reader.ReadByte();

                        temp = new PlayerAppearance(IdPlayer);
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
                    }

                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return temp;
        }

        public void applyPlayerAppearance(BinaryReader reader, MemoryStream unzlib, PlayerAppearance playerApp, ref BinaryWriter writer)
        {
            //calcolo giocatori
            // Create new FileInfo object and get the Length.
            int bytes_player = (int)unzlib.Length;
            int calcolo_player = bytes_player / block;

            long START2 = -60;
            for (int i = 0; i <= (calcolo_player - 1); i++)
            {
                START2 += block;
                unzlib.Seek(START2, SeekOrigin.Begin);
                if (playerApp.getId() == reader.ReadUInt32())
                {
                    writer.BaseStream.Position = START2;
                    writer.Write(playerApp.getId());
                    writer.Write(playerApp.getUnknown1());
                    writer.Write(playerApp.getUnknown2());
                    writer.Write(playerApp.getUnknown3());
                    writer.Write(playerApp.getUnknown4());
                    writer.Write(playerApp.getUnknown5());
                    writer.Write(playerApp.getUnknown6());
                    writer.Write(playerApp.getUnknown7());
                    writer.Write(playerApp.getUnknown8());
                    writer.Write(playerApp.getUnknown9());
                    writer.Write(playerApp.getUnknown10());
                    writer.Write(playerApp.getUnknown11());
                    writer.Write(playerApp.getUnknown12());
                    writer.Write(playerApp.getUnknown13());
                    writer.Write(playerApp.getUnknown14());
                    writer.Write(playerApp.getUnknown15());
                    writer.Write(playerApp.getUnknown16());
                    writer.Write(playerApp.getUnknown17());
                    writer.Write(playerApp.getUnknown18());
                    writer.Write(playerApp.getUnknown19());
                    writer.Write(playerApp.getUnknown20());
                    writer.Write(playerApp.getUnknown21());
                    writer.Write(playerApp.getUnknown22());
                    writer.Write(playerApp.getUnknown23());
                    writer.Write(playerApp.getUnknown24());
                    writer.Write(playerApp.getUnknown25());
                    writer.Write(playerApp.getUnknown26());
                    writer.Write(playerApp.getUnknown27());
                    writer.Write(playerApp.getUnknown28());
                    writer.Write(playerApp.getUnknown29());
                    writer.Write(playerApp.getUnknown30());
                    writer.Write(playerApp.getUnknown31());
                    writer.Write(playerApp.getUnknown32());
                    writer.Write(playerApp.getUnknown33());
                    writer.Write(playerApp.getEyeskinColor());
                    writer.Write(playerApp.getUnknown34());
                    writer.Write(playerApp.getUnknown35());
                    writer.Write(playerApp.getUnknown36());
                    writer.Write(playerApp.getUnknown38());
                    writer.Write(playerApp.getUnknown39());
                    writer.Write(playerApp.getUnknown40());
                    writer.Write(playerApp.getUnknown41());
                    writer.Write(playerApp.getUnknown42());
                    writer.Write(playerApp.getUnknown43());
                    writer.Write(playerApp.getUnknown44());
                    writer.Write(playerApp.getUnknown45());
                    writer.Write(playerApp.getUnknown46());
                    writer.Write(playerApp.getUnknown47());
                    writer.Write(playerApp.getUnknown48());
                    writer.Write(playerApp.getUnknown49());
                    writer.Write(playerApp.getUnknown50());
                    writer.Write(playerApp.getUnknown51());
                    writer.Write(playerApp.getUnknown52());
                    writer.Write(playerApp.getUnknown53());
                    writer.Write(playerApp.getUnknown54());
                    writer.Write(playerApp.getUnknown55());
                    writer.Write(playerApp.getUnknown56());
                }
            }

        }

        public void save(string patch, ref MemoryStream memoryGicotori, int bitRecognized)
        {
            //save zlib
            byte[] ss13 = Zlib18.ZLIBFile(memoryGicotori.ToArray());
            File.WriteAllBytes(patch + PATH, ss13);
        }

    }
}

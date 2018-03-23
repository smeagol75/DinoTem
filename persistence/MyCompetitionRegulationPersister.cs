using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;

namespace DinoTem.persistence
{
    public class MyCompetitionRegulationPersister
    {
        private static string PATH = "/CompetitionRegulation.bin";
        private static int block = 148;

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
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionRegulation_toPc(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo
            int bytesCompetition = (int)memory1.Length;
            int comp = bytesCompetition / block;

            if (comp == 0)
            {
                MessageBox.Show("No competitions regulation found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string name;
            try
            {
                long START2 = -132;

                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);

                for (int i = 0; i <= (comp - 1); i++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    name = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(32)).TrimEnd('\0');

                    Form1._Form1.ListBox_comp_reg.Items.Add(name);
                    Form1._Form1.competitionEntryBox.Items.Add(name);
                }

                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public CompetitionRegulation loadCompetitionRegulation(int selectIndex, MemoryStream memory1, BinaryReader reader)
        {
            UInt32 Pos_ini = (uint) (selectIndex * block);
            reader.BaseStream.Position = Pos_ini;
            UInt16 UNK1 = reader.ReadUInt16();
            
            UInt16 UNK2 = reader.ReadUInt16();
            
            UInt16 UNK3 = reader.ReadUInt16();
            
            byte UNK4 = reader.ReadByte();
            
            byte UNK5 = reader.ReadByte();

            UInt32 Big_32_BYTE_VAL = reader.ReadUInt32();

            UInt32 comp_id = UNK5;
            UInt32 UNK6 = Big_32_BYTE_VAL >> 29;
            
            UInt32 UNK7 = Big_32_BYTE_VAL << 3;
            UNK7 = UNK7 >> 27;
            
            UInt32 UNK8 = Big_32_BYTE_VAL << 8;
            UNK8 = UNK8 >> 26;
            
            UInt32 UNK9 = Big_32_BYTE_VAL << 14;
            UNK9 = UNK9 >> 26;
            
            UInt32 UNK10 = Big_32_BYTE_VAL << 20;
            UNK10 = UNK10 >> 26;
            
            UInt32 UNK11 = Big_32_BYTE_VAL << 26;
            UNK11 = UNK11 >> 26;
            
            UInt16 Big_16_BYTE_VAL = reader.ReadUInt16();

            UInt16 CHECK63 = (ushort) (Big_16_BYTE_VAL >> 15);

            UInt16 CHECK64 = (ushort) (Big_16_BYTE_VAL << 1);
            CHECK64 = (ushort) (CHECK64 >> 15);

            UInt16 CHECK65 = (ushort) (Big_16_BYTE_VAL << 2);
            CHECK65 = (ushort) (CHECK65 >> 14);

            UInt16 UNK12 = (ushort) (Big_16_BYTE_VAL << 4);
            UNK12 = (ushort) (UNK12 >> 13);

            UInt16 UNK13 = (ushort) (Big_16_BYTE_VAL << 7);
            UNK13 = (ushort) (UNK13 >> 13);

            UInt16 UNK14 = (ushort) (Big_16_BYTE_VAL << 10);
            UNK14 = (ushort) (UNK14 >> 13);

            UInt16 UNK15 = (ushort) (Big_16_BYTE_VAL << 13);
            UNK15 = (ushort) (UNK15 >> 13);
            
            byte Byte_1 = reader.ReadByte();
            byte CHECK66 = (byte) (Byte_1 >> 7);

            byte CHECK67 = (byte) (Byte_1 << 1);
            CHECK67 = (byte) (CHECK67 >> 7);

            byte CHECK68 = (byte) (Byte_1 << 2);
            CHECK68 = (byte) (CHECK68 >> 7);

            byte CHECK69 = (byte) (Byte_1 << 3);
            CHECK69 = (byte) (CHECK69 >> 7);

            byte CHECK70 = (byte) (Byte_1 << 4);
            CHECK70 = (byte) (CHECK70 >> 7);

            byte CHECK71 = (byte) (Byte_1 << 5);
            CHECK71 = (byte) (CHECK71 >> 7);

            byte CHECK72 = (byte) (Byte_1 << 6);
            CHECK72 = (byte) (CHECK72 >> 7);

            byte CHECK73 = (byte) (Byte_1 << 7);
            CHECK73 = (byte) (CHECK73 >> 7);

            byte Byte_2 = reader.ReadByte();
            byte CHECK74 = (byte) (Byte_2 >> 7);

            byte CHECK75 = (byte) (Byte_2 << 1);
            CHECK75 = (byte) (CHECK75 >> 7);

            byte CHECK76 = (byte) (Byte_2 << 2);
            CHECK76 = (byte) (CHECK76 >> 7);

            byte CHECK77 = (byte) (Byte_2 << 3);
            CHECK77 = (byte) (CHECK77 >> 7);

            byte CHECK78 = (byte)(Byte_2 << 4);
            CHECK78 = (byte) (CHECK78 >> 7);

            byte CHECK79 = (byte) (Byte_2 << 5);
            CHECK79 = (byte) (CHECK79 >> 7);

            byte CHECK80 = (byte) (Byte_2 << 6);
            CHECK80 = (byte) (CHECK80 >> 7);

            byte CHECK81 = (byte) (Byte_2 << 7);
            CHECK81 = (byte) (CHECK81 >> 7);

            CompetitionRegulation comp = new CompetitionRegulation();
            comp.setUNK1(UNK1);
            comp.setUNK10(UNK10);
            comp.setUNK11(UNK11);
            comp.setUNK12(UNK12);
            comp.setUNK13(UNK13);
            comp.setUNK14(UNK14);
            comp.setUNK15(UNK15);
            comp.setUNK2(UNK2);
            comp.setUNK3(UNK3);
            comp.setUNK4(UNK4);
            comp.setUNK5(UNK5);
            comp.setUNK6(UNK6);
            comp.setUNK7(UNK7);
            comp.setUNK8(UNK8);
            comp.setUNK9(UNK9);
            comp.setCHECK63(CHECK63);
            comp.setCHECK64(CHECK64);
            comp.setCHECK65(CHECK65);
            comp.setCHECK66(CHECK66);
            comp.setCHECK67(CHECK67);
            comp.setCHECK68(CHECK68);
            comp.setCHECK69(CHECK69);
            comp.setCHECK70(CHECK70);
            comp.setCHECK71(CHECK71);
            comp.setCHECK72(CHECK72);
            comp.setCHECK73(CHECK73);
            comp.setCHECK74(CHECK74);
            comp.setCHECK75(CHECK75);
            comp.setCHECK76(CHECK76);
            comp.setCHECK77(CHECK77);
            comp.setCHECK78(CHECK78);
            comp.setCHECK79(CHECK79);
            comp.setCHECK80(CHECK80);
            comp.setCHECK81(CHECK81);

            return comp;
        }

        public void applyCompetitionRegulation(int selectedIndex, MemoryStream unzlib, CompetitionRegulation competizione, ref BinaryWriter writer)
        {
            UInt32 Pos_ini = (UInt32) (selectedIndex * block);
            writer.BaseStream.Position = Pos_ini;
            UInt16 UNK1 = competizione.getUNK1();
            UInt16 UNK2 = competizione.getUNK2();
            UInt16 UNK3 = competizione.getUNK3();
            byte UNK4 = competizione.getUNK4();
            byte UNK5 = competizione.getUNK5();

            UInt32 Big_32_BYTE_VAL = 0;
            UInt32 UNK6 = competizione.getUNK6();
            UInt32 UNK7 = competizione.getUNK7();
            UInt32 UNK8 = competizione.getUNK8();
            UInt32 UNK9 = competizione.getUNK9();
            UInt32 UNK10 = competizione.getUNK10();
            UInt32 UNK11 = competizione.getUNK11();
            UInt32 aux_32 = UNK6 << 29;
            Big_32_BYTE_VAL = (aux_32 | Big_32_BYTE_VAL);
            aux_32 = UNK7 << 24;
            Big_32_BYTE_VAL = (aux_32 | Big_32_BYTE_VAL);
            aux_32 = UNK8 << 18;
            Big_32_BYTE_VAL = (aux_32 | Big_32_BYTE_VAL);
            aux_32 = UNK9 << 12;
            Big_32_BYTE_VAL = (aux_32 | Big_32_BYTE_VAL);
            aux_32 = UNK10 << 6;
            Big_32_BYTE_VAL = (aux_32 | Big_32_BYTE_VAL);
            aux_32 = UNK11;
            Big_32_BYTE_VAL = (aux_32 | Big_32_BYTE_VAL);

            UInt16 Big_16_BYTE_VAL = 0;
            UInt16 CHECK63;
            if (competizione.getCHECK63() == 1)
            {
                CHECK63 = 1;
            }
            else
            {
                CHECK63 = 0;
            }

            UInt16 CHECK64;
            if (competizione.getCHECK64() == 1)
            {
                CHECK64 = 1;
            }
            else
            {
                CHECK64 = 0;
            }

            UInt16 CHECK65;
            if (competizione.getCHECK65() == 1)
            {
                CHECK65 = 1;
            }
            else
            {
                CHECK65 = 0;
            }

            UInt16 UNK12 = competizione.getUNK12();
            UInt16 UNK13 = competizione.getUNK13();
            UInt16 UNK14 = competizione.getUNK14();
            UInt16 UNK15 = competizione.getUNK15();
            UInt16 aux16 = (byte) (CHECK63 << 15);
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);
            aux16 = (byte) (CHECK64 << 14);
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);
            aux16 = (byte) (CHECK65 << 12);
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);
            aux16 = (byte) (UNK12 << 9);
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);
            aux16 = (byte) (UNK13 << 6);
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);
            aux16 = (byte) (UNK14 << 3);
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);
            aux16 = UNK15;
            Big_16_BYTE_VAL = (byte) (aux16 | Big_16_BYTE_VAL);

            byte Byte_1 = 0;
            byte CHECK66;
            if (competizione.getCHECK66() == 1)
            {
                CHECK66 = 1;
            }
            else
            {
                CHECK66 = 0;
            }

            byte CHECK67;
            if (competizione.getCHECK67() == 1)
            {
                CHECK67 = 1;
            }
            else
            {
                CHECK67 = 0;
            }

            byte CHECK68;
            if (competizione.getCHECK68() == 1)
            {
                CHECK68 = 1;
            }
            else
            {
                CHECK68 = 0;
            }

            byte CHECK69;
            if (competizione.getCHECK69() == 1)
            {
                CHECK69 = 1;
            }
            else
            {
                CHECK69 = 0;
            }

            byte CHECK70;
            if (competizione.getCHECK70() == 1)
            {
                CHECK70 = 1;
            }
            else
            {
                CHECK70 = 0;
            }

            byte CHECK71;
            if (competizione.getCHECK71() == 1)
            {
                CHECK71 = 1;
            }
            else
            {
                CHECK71 = 0;
            }

            byte CHECK72;
            if (competizione.getCHECK72() == 1)
            {
                CHECK72 = 1;
            }
            else
            {
                CHECK72 = 0;
            }

            byte CHECK73;
            if (competizione.getCHECK73() == 11)
            {
                CHECK73 = 1;
            }
            else
            {
                CHECK73 = 0;
            }

            byte Aux_byte = 0;
            Aux_byte = (byte) (CHECK66 << 7);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = (byte) (CHECK67 << 6);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = (byte) (CHECK68 << 5);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = (byte) (CHECK69 << 4);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = (byte) (CHECK70 << 3);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = (byte) (CHECK71 << 2);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = (byte) (CHECK72 << 1);
            Byte_1 = (byte) (Aux_byte | Byte_1);
            Aux_byte = CHECK73;
            Byte_1 = (byte) (Aux_byte | Byte_1);

            byte Byte_2 = 0;
            byte CHECK74;
            if (competizione.getCHECK74() == 1)
            {
                CHECK74 = 1;
            }
            else
            {
                CHECK74 = 0;
            }

            byte CHECK75;
            if (competizione.getCHECK75() == 1)
            {
                CHECK75 = 1;
            }
            else
            {
                CHECK75 = 0;
            }

            byte CHECK76;
            if (competizione.getCHECK76() == 1)
            {
                CHECK76 = 1;
            }
            else
            {
                CHECK76 = 0;
            }

            byte CHECK77;
            if (competizione.getCHECK77() == 1)
            {
                CHECK77 = 1;
            }
            else
            {
                CHECK77 = 0;
            }

            byte CHECK78;
            if (competizione.getCHECK78() == 1)
            {
                CHECK78 = 1;
            }
            else
            {
                CHECK78 = 0;
            }

            byte CHECK79;
            if (competizione.getCHECK79() == 1)
            {
                CHECK79 = 1;
            }
            else
            {
                CHECK79 = 0;
            }

            byte CHECK80;
            if (competizione.getCHECK80() == 1)
            {
                CHECK80 = 1;
            }
            else
            {
                CHECK80 = 0;
            }

            byte CHECK81;
            if (competizione.getCHECK81() == 1)
            {
                CHECK81 = 1;
            }
            else
            {
                CHECK81 = 0;
            }

            Aux_byte = (byte) (CHECK74 << 7);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = (byte) (CHECK75 << 6);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = (byte) (CHECK76 << 5);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = (byte) (CHECK77 << 4);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = (byte) (CHECK78 << 3);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = (byte) (CHECK79 << 2);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = (byte) (CHECK80 << 1);
            Byte_2 = (byte) (Aux_byte | Byte_2);
            Aux_byte = CHECK81;
            Byte_2 = (byte) (Aux_byte | Byte_2);

            writer.Write(UNK1);
            writer.Write(UNK2);
            writer.Write(UNK3);
            writer.Write(UNK4);
            writer.Write(UNK5);
            writer.Write(Big_32_BYTE_VAL);
            writer.Write(Big_16_BYTE_VAL);
            writer.Write(Byte_1);
            writer.Write(Byte_2);
        }

        public void save(string patch, ref MemoryStream memoryCompetitionRegulation, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryCompetitionRegulation.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionRegulation_toConsole(ref memoryCompetitionRegulation);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryCompetitionRegulation, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionRegulation_toConsole(ref memoryCompetitionRegulation);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryCompetitionRegulation, patch + PATH);
            }
        }
    }
}

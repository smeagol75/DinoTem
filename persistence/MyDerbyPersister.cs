﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;

namespace DinoTem.persistence
{
    public class MyDerbyPersister
    {
        private static string PATH = "/Derby.bin";
        private static int block = 12;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Derby_toPc(memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo tattiche
            int bytesDerby = (int)memory1.Length;
            int derby = bytesDerby / block;

            if (derby == 0)
            {
                MessageBox.Show("No derby found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            UInt32 Team1_Derby_id;
            UInt32 Team2_Derby_id;
            UInt16 Frag_val1;
            UInt16 Frag_val2;
            UInt16 Frag_val3;
            UInt16 Frag_val4;
            UInt16 FRAG_VAL;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                long START2 = -block;

                int NumberOfRepetitions1 = Convert.ToInt32(derby);
                for (int i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);

                    reader.BaseStream.Position = START2;
                    Team1_Derby_id = reader.ReadUInt32();
                    Team2_Derby_id = reader.ReadUInt32();
                    FRAG_VAL = reader.ReadUInt16();

                    Frag_val1 = (ushort) (FRAG_VAL >> 12);

                    Frag_val2 = (ushort) (FRAG_VAL << 4);
                    Frag_val2 = (ushort) (Frag_val2 >> 14);

                    Frag_val3 = (ushort) (FRAG_VAL << 6);
                    Frag_val3 = (ushort) (Frag_val3 >> 13);

                    Frag_val4 = (ushort) (FRAG_VAL << 9);
                    Frag_val4 = (ushort) (Frag_val4 >> 9);

                    Form1._Form1.DataGridView_derby.Rows.Add(Team1_Derby_id, "", Team2_Derby_id, "", Frag_val2, Frag_val3, Frag_val4);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public void applyDerby(int selectedIndex, MemoryStream unzlib, Derby derby, ref BinaryWriter writer)
        {
            UInt32 Index = (uint) (selectedIndex * block);
            if ((Index > unzlib.Length))
            {
                Index = (uint) (unzlib.Length);
            }

            writer.BaseStream.Position = Index;
            UInt32 Team1_Derby_id = derby.getTeam1DerbyId();
            UInt32 Team2_Derby_id = derby.getTeam2DerbyId();
            UInt16 FRAG_VAL = 0;
            UInt16 Frag_val1 = derby.getFragVal1();
            UInt16 Frag_val2 = derby.getFragVal2();
            UInt16 Frag_val3 = derby.getFragVal3();
            UInt16 Frag_val4 = derby.getFragVal4();
            UInt16 aux16 = (ushort) (Frag_val1 << 12);
            FRAG_VAL = (ushort) (aux16 | FRAG_VAL);
            aux16 = (ushort) (Frag_val2 << 10);
            FRAG_VAL = (ushort) (aux16 | FRAG_VAL);
            aux16 = (ushort) (Frag_val3 << 7);
            FRAG_VAL = (ushort) (aux16 | FRAG_VAL);
            aux16 = Frag_val4;
            FRAG_VAL = (ushort) (aux16 | FRAG_VAL);

            UInt16 Zero_16 = 0;
            writer.Write(Team1_Derby_id);
            writer.Write(Team2_Derby_id);
            writer.Write(FRAG_VAL);
            writer.Write(Zero_16);
        }

        public void addDerby(ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            byte[] test = new byte[(int)memory1.Length + block];
            for (int i = 0; i < test.Count() - 1; i++)
            {
                test[i] = 0;
            }

            byte[] temp = memory1.ToArray();
            for (int i = 0; i < (int)memory1.Length - 1; i++)
            {
                test[i] = temp[i];
            }

            memory1 = new MemoryStream(test);
            reader = new BinaryReader(memory1);
            writer = new BinaryWriter(memory1);
        }

        public void save(string patch, MemoryStream memoryDerby, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryDerby.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Derby_toConsole(memoryDerby), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Derby_toConsole(memoryDerby), patch + PATH);
            }
        }

    }
}

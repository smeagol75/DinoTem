﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18
    public class MyTacticsFormationPersister
    {
        private static string PATH = "/TacticsFormation.bin";
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
                UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Pc(memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            int bytes = (int)memory1.Length;
            int tactics = bytes / block;

            if (tactics == 0)
            {
                MessageBox.Show("No tactics formations found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

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

        public List<TacticsFormation> loadTacticsFormation(UInt16 idTactics, MemoryStream memory1, BinaryReader reader)
        {
            List<TacticsFormation> list = new List<TacticsFormation>();

            //Calcolo tattiche
            int bytesTactics = (int)memory1.Length;
            int tactics = bytesTactics / block;

            byte position;
            UInt16 TeamTacticIdFormation;
            byte Y;
            byte X;
            byte byte_frag;

            long START = -block;
            long START2 = -8;
            long START3 = -6;
            long START4 = -5;
            long START5 = -4;

            int NumberOfRepetitions2 = Convert.ToInt32(tactics);
            for (int i2 = 0; i2 <= NumberOfRepetitions2 - 1; i2++)
            {
                START2 += block;
                START += block;
                START3 += block;
                START4 += block;
                START5 += block;

                memory1.Seek(START2, SeekOrigin.Begin);
                TeamTacticIdFormation = reader.ReadUInt16();
                if (TeamTacticIdFormation == idTactics)
                {
                    memory1.Seek(START, SeekOrigin.Begin);
                    position = reader.ReadByte();
 
                    memory1.Seek(START3, SeekOrigin.Begin);
                    Y = reader.ReadByte();

                    memory1.Seek(START4, SeekOrigin.Begin);
                    X = reader.ReadByte();

                    memory1.Seek(START5, SeekOrigin.Begin);
                    byte_frag = reader.ReadByte();

                    TacticsFormation form = new TacticsFormation(TeamTacticIdFormation);
                    form.setPosition(position);
                    form.setY(Y);
                    form.setX(X);
                    form.setbyteFrag(byte_frag);

                    list.Add(form);
                }
            }

            return list;
        }

        public void applyTacticsFormation(MemoryStream unzlib, BinaryReader reader, List<TacticsFormation> tatticsF, ref BinaryWriter writer)
        {
            //Calcolo tattiche
            int bytesTactics = (int)unzlib.Length;
            int tactics = bytesTactics / block;

            long START2 = -8;
            int k = 0;

            UInt16 TeamTacticIdFormation;
            int NumberOfRepetitions2 = Convert.ToInt32(tactics);
            for (int i2 = 0; i2 <= NumberOfRepetitions2 - 1; i2++)
            {
                START2 += block;
                unzlib.Seek(START2, SeekOrigin.Begin);
                TeamTacticIdFormation = reader.ReadUInt16();
                if (TeamTacticIdFormation == tatticsF[0].getTeamTacticId())
                {
                    writer.BaseStream.Position = START2 - 4;
                    writer.Write(tatticsF[k].getPosition());

                    writer.BaseStream.Position = START2 + 2;
                    writer.Write(tatticsF[k].getY());

                    writer.BaseStream.Position = START2 + 3;
                    writer.Write(tatticsF[k].getX());

                    k++;
                }
            }
        }

        public void addTacticsFormation(UInt16 idTactics, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            byte[] tacticsFormation_block;
            reader.BaseStream.Position = 0;
            tacticsFormation_block = reader.ReadBytes(block * 33);

            for (int j = 0; j < 33; j++)
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

            writer.BaseStream.Position = memory1.Length - (block * 33);
            writer.Write(tacticsFormation_block);

            writer.BaseStream.Position = memory1.Length - (block * 33) + 4;
            for (int j = 0; j < 33; j++)
            {
                writer.Write(idTactics);
                writer.BaseStream.Position += block - 2;
            }
        }

        public void save(string patch, MemoryStream memoryTattiche, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryTattiche.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Console(memoryTattiche), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Console(memoryTattiche), patch + PATH);
            }
        }

    }
}

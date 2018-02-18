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
    public class MyBallConditionPersister
    {
        private static string PATH = "/BallCondition.bin";
        private static int block = 8;

        private MemoryStream unzlib(string patch, int bitRecognized)
        {
            MemoryStream memory1 = null;
            if (bitRecognized == 0) {
                byte[] file = File.ReadAllBytes(patch + PATH);
                byte[] ss1 = Unzlib.unZLIBFilePC(file);
                memory1 = new MemoryStream(ss1);
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                FileStream writeStream = new FileStream(patch + PATH, FileMode.Open);
                memory1 = UnzlibZlibConsole.UnzlibZlibConsole.unzlibconsole_to_MemStream(writeStream);
                UnzlibZlibConsole.UnzlibZlibConsole.BallCondition_Pc(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

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

        public List<BallCondition> loadBallCondition(UInt16 id, MemoryStream memory1, BinaryReader reader)
        {
            List<BallCondition> list = new List<BallCondition>();

            //calcolo BallCondition
            int bytes_ball1 = (int) memory1.Length;
            int ball1 = bytes_ball1 / block;

            UInt16 IdCondition;
            byte byteCondition;
            UInt16 frag;
            try
            {
                long START1 = -8; //id
                long START3 = -6; //byte
                long START2 = -4; //byte

                int NumberOfRepetitions = Convert.ToInt32(ball1);
                for (int i = 1; i <= NumberOfRepetitions; i++)
                {
                    START1 += block;
                    START3 += block;
                    START2 += block;

                    memory1.Seek(START1, SeekOrigin.Begin);
                    IdCondition = reader.ReadUInt16();
                    if (IdCondition == id)
                    {
                        memory1.Seek(START3, SeekOrigin.Begin);
                        frag = reader.ReadUInt16();

                        memory1.Seek(START2, SeekOrigin.Begin);
                        byteCondition = reader.ReadByte();

                        BallCondition bc = new BallCondition(IdCondition);
                        bc.setFrag(frag);
                        bc.setUnknown(byteCondition);
                        list.Add(bc);
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return list;
        }

        public void applyBallCondition(MemoryStream unzlib, BinaryReader reader, List<BallCondition> ballCondition, ref BinaryWriter writer)
        {
            //calcolo BallCondition
            int bytes_ball1 = (int)unzlib.Length;
            int ball1 = bytes_ball1 / block;

            long START3 = -6; //byte

            int k = 0;
            int NumberOfRepetitions = Convert.ToInt32(ball1);
            for (int i = 1; i <= NumberOfRepetitions; i++)
            {
                START3 += block;

                unzlib.Seek(START3, SeekOrigin.Begin);
                if (ballCondition[k].getFrag() == reader.ReadUInt16())
                {
                    writer.BaseStream.Position = START3 - 2;

                    writer.Write(ballCondition[k].getId());
                    writer.Write(ballCondition[k].getFrag());
                    writer.Write(ballCondition[k].getUnknown());

                    if ((k+1) < ballCondition.Count)
                        k++;
                }

            }
        }

        public void save(string patch, ref MemoryStream memoryPalloni, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryPalloni.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.BallCondition_Console(ref memoryPalloni);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryPalloni, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.BallCondition_Console(ref memoryPalloni);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryPalloni, patch + PATH);
            }
        }
    }
}

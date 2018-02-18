using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using Team_Editor_Manager_New_Generation.persistence;

namespace DinoTem.persistence
{
    //pes 18
    public class MyBallPersister
    {
        private static string PATH = "/Ball.bin";
        private static int block = 140;

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
                UnzlibZlibConsole.UnzlibZlibConsole.ball(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
             memory1 = unzlib(patch, bitRecognized);

            //Calcolo palloni
            int bytes_ball = (int)memory1.Length;
            int ball = bytes_ball / block;

            string ballName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -136; //nome pallone

                int NumberOfRepetitions1 = Convert.ToInt32(ball);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    ballName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(135)).TrimEnd('\0');

                    Form1._Form1.ballsBox.Items.Add(ballName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Ball loadBall(int index, BinaryReader reader)
        {
            Ball pallone = null;

            UInt16 ballId;
            byte order;
            string ballName;
            try
            {
                reader.BaseStream.Position = index * block + 4;
                ballName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(135)).TrimEnd('\0');

                reader.BaseStream.Position = index * block;
                ballId = reader.ReadUInt16();

                reader.BaseStream.Position = index * block + 2;
                order = reader.ReadByte();

                pallone = new Ball(ballId);
                pallone.setName(ballName);
                pallone.setOrder(order);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return pallone;
        }

        public void applyBall(int selectedIndex, MemoryStream unzlib, Ball pallone, ref BinaryWriter writer)
        {
            int Index = (block * selectedIndex);
            writer.BaseStream.Position = Index;
            byte zero = 0;
            if (Index == unzlib.Length)
            {
                for (int i = 0; i <= (block - 1); i++)
                {
                    writer.Write(zero);
                }

                writer.BaseStream.Position = Index;
            }

            UInt16 id = pallone.getId();
            byte order = pallone.getOrder();
            string ballName = pallone.getName();
            writer.Write(id);
            writer.Write(order);
            writer.BaseStream.Position = (Index + 4);
            for (int i = 0; i <= 134; i++)
            {
                writer.Write(zero);
            }

            writer.BaseStream.Position = (Index + 4);
            writer.Write(ballName.ToCharArray());
        }

        public void save(string patch, ref MemoryStream memoryBall, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryBall.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.ball(ref memoryBall);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryBall, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.ball(ref memoryBall);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryBall, patch + PATH);
            }
        }

    }
}

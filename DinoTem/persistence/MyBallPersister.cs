using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using DinoTem.ui;
using Team_Editor_Manager_New_Generation.persistence;

namespace DinoTem.persistence
{
    //pes 18
    public class MyBallPersister
    {
        private static string PATH = "/Ball.bin";

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

        public List<Ball> load(string patch, int bitRecognized)
        {
            List<Ball> ballList = new List<Ball>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //Calcolo palloni
            int bytes_ball = (int)memory1.Length;
            int ball = bytes_ball / 140;

            string ballName;
            UInt16 ballId;
            byte order;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -136; //nome pallone

                long START = -140; //id

                long START3 = -138; //order

                int NumberOfRepetitions1 = Convert.ToInt32(ball);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += 140;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    ballName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(57)).TrimEnd('\0');

                    START += 140;
                    memory1.Seek(START, SeekOrigin.Begin);
                    ballId = reader.ReadUInt16();

                    START3 += 140;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    order = reader.ReadByte();

                    // Instantiate a new object, set it's number and
                    // some other properties
                    Ball pallone = new Ball(ballId, order, ballName);
                    ballList.Add(pallone);
                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return ballList;
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

        private void saveHexPadding(BinaryWriter b)
        {
            string hex2klkoa6 = "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";  // La tua stringa contenente i valori esadecimali
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
            string hex2klkoa6 = "00 ";
            for (int i = value; i < 57; i++)
            {
                hex2klkoa6 += "00 ";
            }
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Trim(' ').Split(' ');
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
                foreach (Ball temp in controller.getListBall())
                {
                    saveHex(temp.getId(), b);
                    saveHex(temp.getOrder(), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getName()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getName()).Count(), b);
                    saveHexPadding(b);
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
                UnzlibZlibConsole.UnzlibZlibConsole.ball(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.ball(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
        }

    }
}

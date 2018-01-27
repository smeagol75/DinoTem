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

        public List<BallCondition> load(string patch, int bitRecognized)
        {
            List<BallCondition> ballConditionList = new List<BallCondition>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //calcolo BallCondition
            // Create new FileInfo object and get the Length.
            int bytes_ball1 = (int) memory1.Length; //Convert.ToInt32(ss1.Length);
            int ball1 = bytes_ball1 / 8;

            UInt16 IdCondition;
            byte byteCondition;
            UInt16 frag;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i = 0;

                long START1 = -8; //id
                long START3 = -6; //byte
                long START2 = -4; //byte

                int NumberOfRepetitions = Convert.ToInt32(ball1);
                for (i = 1; i <= NumberOfRepetitions; i++)
                {
                    START1 += 8;
                    memory1.Seek(START1, SeekOrigin.Begin);
                    IdCondition = reader.ReadUInt16();

                    START3 += 8;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    frag = reader.ReadUInt16();

                    START2 += 8;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    byteCondition = reader.ReadByte();

                    BallCondition bc = new BallCondition(IdCondition, frag, byteCondition);
                    ballConditionList.Add(bc);           
                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return ballConditionList;
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

        public void save(string patch, Controller controller, int bitRecognized)
        {
            using (BinaryWriter b = new BinaryWriter(File.Open(patch + PATH, FileMode.Create)))
            {
                foreach (BallCondition temp in controller.getBallConditionList())
                {
                    saveHex(temp.getId(), b);
                    saveHex(temp.getFrag(), b);
                    saveHex(temp.getUnknown(), b);
                    saveHex(0, b);
                }
            }

            if (bitRecognized == 0)
            {
                //save zlib
                byte[] inputData14 = File.ReadAllBytes(patch + PATH);
                byte[] ss14 = Zlib18.ZLIBFile(inputData14);
                File.WriteAllBytes(patch + PATH, ss14);
            }
            else if (bitRecognized == 1)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.BallCondition_Console(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.BallCondition_Console(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
        }
    }
}

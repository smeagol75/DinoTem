using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using Team_Editor_Manager_New_Generation.persistence;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18
    public class MyTacticsFormationPersister
    {
        private static string PATH = "/TacticsFormation.bin";

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
                UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Pc(ref memory1);
            }

            return memory1;
        }

        public List<TacticsFormation> load(string patch, int bitRecognized)
        {
            List<TacticsFormation> tacticsList = new List<TacticsFormation>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //Calcolo TacticsFormation
            // Create new FileInfo object and get the Length.
            int bytes_tattica = (int)memory1.Length;
            int tattica = bytes_tattica / 12;

            byte position;
            UInt16 TeamTacticIdFormation;
            byte Y;
            byte X;
            byte byte_frag;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i2 = 0;
                long START = -12;
                long START2 = -8;
                long START3 = -6;
                long START4 = -5;
                long START5 = -4;

                int NumberOfRepetitions2 = Convert.ToInt32(tattica);
                for (i2 = 1; i2 <= NumberOfRepetitions2; i2++)
                {
                    START += 12;
                    memory1.Seek(START, SeekOrigin.Begin);
                    position = reader.ReadByte();

                    START2 += 12;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    TeamTacticIdFormation = reader.ReadUInt16();
                    START3 += 12;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    Y = reader.ReadByte();

                    START4 += 12;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    X = reader.ReadByte();

                    START5 += 12;
                    memory1.Seek(START5, SeekOrigin.Begin);
                    byte_frag = reader.ReadByte();

                    // Instantiate a new object, set it's number and
                    // some other properties
                    TacticsFormation form = new TacticsFormation(TeamTacticIdFormation);
                    form.setPosition(position);
                    form.setY(Y);
                    form.setX(X);
                    form.setbyteFrag(byte_frag);
                    tacticsList.Add(form);
                }
                reader.Close();
                memory1.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            return tacticsList;
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
            using (BinaryWriter b = new BinaryWriter(File.Open(patch + PATH, FileMode.Create)))
            {
                // Use foreach and write all 12 integers.
                foreach (TacticsFormation temp in controller.getTacticsFormationList())
                {
                    saveHex(temp.getPosition(), b);
                    saveHex(0, b);
                    saveHex(temp.getTeamTacticId(), b);
                    saveHex2(temp.getY(), b);
                    saveHex2(temp.getX(), b);
                    saveHex2(temp.getbyteFrag(), b);
                    saveHex(0, b);
                    saveHex2(0, b);
                }
            }

            if (bitRecognized == 0)
            {
                //save zlib
                byte[] inputData7 = File.ReadAllBytes(patch + PATH);
                byte[] ss8 = Zlib18.ZLIBFile(inputData7);
                File.WriteAllBytes(patch + PATH, ss8);
            }
            else if (bitRecognized == 1)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Console(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Console(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
        }

    }
}

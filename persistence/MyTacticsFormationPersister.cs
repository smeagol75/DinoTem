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
                UnzlibZlibConsole.UnzlibZlibConsole.TacticsFormation_Pc(ref memory1);
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

            long START = -12;
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

        public void applyTacticsFormation(int selectedIndex, ref MemoryStream unzlib, TacticsFormation tatticsF, ref BinaryWriter writer)
        {
        }

        public void save(string patch, ref MemoryStream memoryTattiche, int bitRecognized)
        {
        }

    }
}

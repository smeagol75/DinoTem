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
    public class MyCompetitionEntryPersister
    {
        private static string PATH = "/CompetitionEntry.bin";
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
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionEntry_toPc(ref memory1);
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

        public void loadCompetitionEntry(UInt32 Comp_Id, MemoryStream memory1, BinaryReader reader)
        {
            //Calcolo
            int bytes = (int)memory1.Length;
            int competitionEntry = bytes / block;

            Form1._Form1.DataGridView1.Rows.Clear();

            reader.BaseStream.Position = 0;
            for (int i = 0; (i <= (competitionEntry - 1)); i++)
            {
                reader.BaseStream.Position += 10;
                UInt32 Check_league = reader.ReadByte();
                if ((Check_league == Comp_Id))
                {
                    reader.BaseStream.Position -= 11;
                    UInt32 TeamId = reader.ReadUInt32();
                    UInt16 ValorUNK16 = reader.ReadUInt16();
                    UInt16 C_Entry_Index = reader.ReadUInt16();
                    reader.BaseStream.Position++;
                    byte Order = reader.ReadByte();

                    Form1._Form1.DataGridView1.Rows.Add(Order, "", C_Entry_Index, TeamId, ValorUNK16);
                    reader.BaseStream.Position += 2;
                }
                else
                {
                    reader.BaseStream.Position++;
                }
            }

        }

        public void applyCompetitionEntry(int selectedIndex, MemoryStream unzlib, CompetitionEntry compEntry, ref BinaryWriter writer)
        {
        }

        public void save(string patch, ref MemoryStream memoryCompetition, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryCompetition.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionEntry_toConsole(ref memoryCompetition);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryCompetition, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionEntry_toConsole(ref memoryCompetition);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryCompetition, patch + PATH);
            }
        }
    }
}

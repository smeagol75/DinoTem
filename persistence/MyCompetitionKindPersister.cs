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
    public class MyCompetitionKindPersister
    {
        private static string PATH = "/CompetitionKind.bin";
        private static int block = 88;

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
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionKind_to_pc(memory1);
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
                MessageBox.Show("No competitions kind found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string name;
            try
            {
                long START2 = -23;

                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);

                for (int i = 0; i <= (comp - 1); i++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    name = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(23)).TrimEnd('\0');

                    Form1._Form1.competitionsKind.Items.Add(name);
                }

                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public CompetitionKind loadCompetitionKind(int selectIndex, MemoryStream memory1, BinaryReader reader)
        {
            CompetitionKind comp = new CompetitionKind();

            UInt32 Pos_ini = (uint) (selectIndex * block);
            reader.BaseStream.Position = Pos_ini;
            byte Order = reader.ReadByte();
            
            byte Byte_imp = reader.ReadByte();
            byte UNK1 = (byte) (Byte_imp >> 6);

            byte UNK2 = (byte) (Byte_imp << 2);
            UNK2 = (byte) (UNK2 >> 5);

            byte UNK3 = (byte) (Byte_imp << 5);
            UNK3 = (byte) (UNK3 >> 5);

            comp.setOrder(Order);
            comp.setUnk1(UNK1);
            comp.setUnk2(UNK2);
            comp.setUnk3(UNK3);

            return comp;
        }

        public void applyCompetitionKind(int selectedIndex, MemoryStream unzlib, CompetitionKind comp, ref BinaryWriter writer)
        {
            UInt32 Pos_ini = (uint) (selectedIndex * block);
            writer.BaseStream.Position = Pos_ini;
            byte Order = comp.getOrder();
            byte Byte_imp = 0;
            byte UNK1 = comp.getUnk1();
            byte UNK2 = comp.getUnk2();
            byte UNK3 = comp.getUnk3();
            byte Aux_byte = (byte) (UNK1 << 6);
            Byte_imp = (byte) (Aux_byte | Byte_imp);
            Aux_byte = (byte) (UNK2 << 3);
            Byte_imp = (byte) (Aux_byte | Byte_imp);
            Aux_byte = UNK3;
            Byte_imp = (byte) (Aux_byte | Byte_imp);

            writer.Write(Order);
            writer.Write(Byte_imp);
        }

        public void save(string patch, MemoryStream memoryCompetitionKind, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryCompetitionKind.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.CompetitionKind_to_console(memoryCompetitionKind), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.CompetitionKind_to_console(memoryCompetitionKind), patch + PATH);
            }
        }
    }
}

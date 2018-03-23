using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DinoTem.model;
using Team_Editor_Manager_New_Generation.zlibUnzlib;

namespace DinoTem.persistence
{
    public class MyCompetitionPersister
    {
        private static string PATH = "/Competition.bin";
        private static int block = 32;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Competition_toPc(ref memory1);
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
                MessageBox.Show("No competitions found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string name;
            try
            {
                long START2 = -28;

                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);

                for (int i = 0; i <= (comp - 1); i++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    name = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(32)).TrimEnd('\0');

                    Form1._Form1.competitionsBox.Items.Add(name);
                }

                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Competition loadCompetition(int selectIndex, MemoryStream memory1, BinaryReader reader)
        {
            Competition competition;

            UInt32 Pos_ini = (uint) (selectIndex * block);
            reader.BaseStream.Position = Pos_ini;
            UInt32 Valor_32_imp = reader.ReadUInt32();

            UInt32 CHECK54 = Valor_32_imp >> 31;

            UInt32 CHECK55 = Valor_32_imp << 1;
            CHECK55 = CHECK55 >> 31;

            UInt32 CHECK56 = Valor_32_imp << 2;
            CHECK56 = CHECK56 >> 31;

            UInt32 CHECK57 = Valor_32_imp << 3;
            CHECK57 = CHECK57 >> 31;

            UInt32 CHECK58 = Valor_32_imp << 4;
            CHECK58 = CHECK58 >> 31;

            UInt32 CHECK59 = Valor_32_imp << 5;
            CHECK59 = CHECK59 >> 31;

            UInt32 CHECK60 = Valor_32_imp << 6;
            CHECK60 = CHECK60 >> 31;

            UInt32 CHECK61 = Valor_32_imp << 7;
            CHECK61 = CHECK61 >> 31; //licensed

            UInt32 UNK_1 = Valor_32_imp << 8;
            UNK_1 = UNK_1 >> 30; //type
            
            UInt32 CHECK62 = Valor_32_imp << 10;
            CHECK62 = CHECK62 >> 31; //second division

            UInt32 UNK_2 = Valor_32_imp << 11;
            UNK_2 = UNK_2 >> 26; //id
            
            UInt32 UNK_3 = Valor_32_imp << 17;
            UNK_3 = UNK_3 >> 25;
            
            UInt32 UNK_4 = Valor_32_imp << 24;
            UNK_4 = UNK_4 >> 24; //zone

            competition = new Competition(UNK_2);
            competition.setCheck54(CHECK54);
            competition.setCheck55(CHECK55);
            competition.setCheck56(CHECK56);
            competition.setCheck57(CHECK57);
            competition.setCheck58(CHECK58);
            competition.setCheck59(CHECK59);
            competition.setCheck60(CHECK60);
            competition.setLicensed(CHECK61);
            competition.setSecondDivision(CHECK62);
            competition.setType(UNK_1);
            competition.setUnk3(UNK_3);
            competition.setZone(UNK_4);

            return competition;
        }

        public void applyCompetition(int selectedIndex, MemoryStream unzlib, Competition competizione, ref BinaryWriter writer)
        {
            UInt32 Pos_ini = (uint) (selectedIndex * block);
            writer.BaseStream.Position = Pos_ini;
            UInt32 CHECK54;
            if (competizione.getCheck54() == 1)
            {
                CHECK54 = 1;
            }
            else
            {
                CHECK54 = 0;
            }

            UInt32 CHECK55;
            if (competizione.getCheck55() == 1)
            {
                CHECK55 = 1;
            }
            else
            {
                CHECK55 = 0;
            }

            UInt32 CHECK56;
            if (competizione.getCheck56() == 1)
            {
                CHECK56 = 1;
            }
            else
            {
                CHECK56 = 0;
            }

            UInt32 CHECK57;
            if (competizione.getCheck57() == 1)
            {
                CHECK57 = 1;
            }
            else
            {
                CHECK57 = 0;
            }

            UInt32 CHECK58;
            if (competizione.getCheck58() == 1)
            {
                CHECK58 = 1;
            }
            else
            {
                CHECK58 = 0;
            }

            UInt32 CHECK59;
            if (competizione.getCheck59() == 1)
            {
                CHECK59 = 1;
            }
            else
            {
                CHECK59 = 0;
            }

            UInt32 CHECK60;
            if (competizione.getCheck60() == 1)
            {
                CHECK60 = 1;
            }
            else
            {
                CHECK60 = 0;
            }

            UInt32 CHECK61;
            if (competizione.getLicensed() == 1)
            {
                CHECK61 = 1;
            }
            else
            {
                CHECK61 = 0;
            }

            UInt32 UNK_1 = competizione.getType();
            UInt32 CHECK62;
            if (competizione.getSecondDivision() == 1)
            {
                CHECK62 = 1;
            }
            else
            {
                CHECK62 = 0;
            }

            UInt32 UNK_2 = competizione.getId();
            UInt32 UNK_3 = competizione.getUnk3();
            UInt32 UNK_4 = competizione.getZone();
            UInt32 Valor_32_imp = 0;
            UInt32 Aux32 = CHECK54 << 31;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK55 << 30;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK56 << 29;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK57 << 28;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK58 << 27;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK59 << 26;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK60 << 25;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK61 << 24;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = UNK_1 << 22;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = CHECK62 << 21;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = UNK_2 << 15;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = UNK_3 << 8;
            Valor_32_imp = (Aux32 | Valor_32_imp);
            Aux32 = UNK_4;
            Valor_32_imp = (Aux32 | Valor_32_imp);

            writer.Write(Valor_32_imp);
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
                UnzlibZlibConsole.UnzlibZlibConsole.Competition_toConsole(ref memoryCompetition);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryCompetition, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Competition_toConsole(ref memoryCompetition);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryCompetition, patch + PATH);
            }
        }
    }
}

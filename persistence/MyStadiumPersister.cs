using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18
    public class MyStadiumPersister
    {
        private static string PATH = "/Stadium.bin";
        private static int block = 272;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Stadium_toPc(memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo stadi
            int bytesStadiums = (int)memory1.Length;
            int stadium = bytesStadiums / block;

            if (stadium == 0)
            {
                MessageBox.Show("No stadiums found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string stadiumName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -143;

                int NumberOfRepetitions1 = Convert.ToInt32(stadium);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    stadiumName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(110)).TrimEnd('\0');

                    Form1._Form1.stadiumsBox.Items.Add(stadiumName);
                    Form1._Form1.teamStadium.Items.Add(stadiumName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Stadium loadStadium(int index, BinaryReader reader)
        {
            Stadium stadium = null;

            UInt16 stadiumId;
            byte zone;
            string stadiumName;
            string japName;
            string konamiName;
            UInt32 na;
            UInt32 licensed;
            UInt32 country;
            UInt32 capacita;
            try
            {
                reader.BaseStream.Position = index * block;
                UInt32 valore32 = reader.ReadUInt32();

                na = valore32 >> 30;
                licensed = valore32 << 2;
                licensed = licensed >> 31;
                country = valore32 << 3;
                country = country >> 23;
                capacita = valore32 << 12;
                capacita = capacita >> 12;

                reader.BaseStream.Position = index * block + 4;
                stadiumId = reader.ReadUInt16();

                reader.BaseStream.Position = index * block + 6;
                zone = reader.ReadByte();

                reader.BaseStream.Position = index * block + 8;
                japName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(110)).TrimEnd('\0');

                reader.BaseStream.Position = index * block + 129;
                stadiumName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(110)).TrimEnd('\0');

                reader.BaseStream.Position = index * block + 250;
                konamiName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(20)).TrimEnd('\0');

                stadium = new Stadium(stadiumId);
                stadium.setName(stadiumName);
                stadium.setJapaneseName(japName);
                stadium.setNa(na);
                stadium.setLicense(licensed);
                stadium.setCountry(country);
                stadium.setCapacity(capacita);
                stadium.setZone(zone);
                stadium.setKonamiName(konamiName);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return stadium;
        }

        public int loadStadiumById(MemoryStream memory1, BinaryReader reader, UInt16 stadiumId)
        {
            int bytes = (int)memory1.Length;
            int stadium = bytes / block;

            reader.BaseStream.Position = 4;
            for (int i = 0; i <= (stadium - 1); i++)
            {
                if (stadiumId == reader.ReadUInt16())
                    return i;
                reader.BaseStream.Position += block - 2;
            }

            return -1;
        }

        public UInt16 findIndexStadium(MemoryStream memory1, BinaryReader reader)
        {
            UInt16 stadium_index_mayor = 0;

            int bytesStadiums = (int)memory1.Length;
            int stadium = bytesStadiums / block;

            reader.BaseStream.Position = 4;
            for (int i = 0; (i <= (stadium - 1)); i++)
            {
                UInt16 temp_index = reader.ReadUInt16();
                if ((temp_index >= stadium_index_mayor))
                {
                    stadium_index_mayor = (ushort)(temp_index + 1);
                }
                reader.BaseStream.Position += block - 2;
            }

            return stadium_index_mayor;
        }

        public void applyStadium(int selectedIndex, MemoryStream unzlib, Stadium stadium, ref BinaryWriter writer)
        {
            int Index = (block * selectedIndex);
            writer.BaseStream.Position = Index;
            byte zero = 0;
            if ((Index == unzlib.Length))
            {
                for (int i = 0; i <= 271; i++)
                {
                    writer.Write(zero);
                }

                writer.BaseStream.Position = Index;
            }

            UInt32 valore32 = 0;
            UInt32 na = stadium.getNa();
            UInt32 licensed = stadium.getLicense();
            UInt32 country = stadium.getCountry();
            UInt32 capacita = stadium.getCapacity();
            UInt16 id = stadium.getId();
            UInt32 zone = stadium.getZone();
            UInt32 Aux_32 = na << 30;
            valore32 = (Aux_32 | valore32);
            Aux_32 = licensed << 29;
            valore32 = (Aux_32 | valore32);
            Aux_32 = country << 20;
            valore32 = (Aux_32 | valore32);
            Aux_32 = capacita;
            valore32 = (Aux_32 | valore32);

            writer.Write(valore32);
            writer.Write(id);
            writer.Write(zone);

            writer.BaseStream.Position = Index + 8;
            for (int i = 0; i <= 120; i++)
            {
                writer.Write(zero);
            }

            writer.BaseStream.Position = Index + 8;
            writer.Write(stadium.getJapaneseName().ToCharArray());
            writer.BaseStream.Position = Index + 129;
            for (int i = 0; i <= 120; i++)
            {
                writer.Write(zero);
            }

            writer.BaseStream.Position = Index + 129;
            writer.Write(stadium.getName().ToCharArray());
            writer.BaseStream.Position = Index + 250;
            for (int i = 0; i <= 20; i++)
            {
                writer.Write(zero);
            }

            writer.BaseStream.Position = Index + 250;
            writer.Write(stadium.getKonamiName().ToCharArray());
        }

        public void addStadium(ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
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

        public void save(string patch, MemoryStream memoryStadium, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryStadium.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Stadium_toConsole(memoryStadium), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Stadium_toConsole(memoryStadium), patch + PATH);
            }
            return;
        }

    }
}

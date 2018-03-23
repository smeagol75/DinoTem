using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;
using DinoTem;

namespace DinoTem.persistence
{
    //pes 18, pes 17
    public class MyCountryPersister
    {
        private static string PATH = "/Country.bin";
        private static int block = 1348;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Country_toPc(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            var result = readNationality();
            var result2 = readNation();

            //Calcolo paesi
            int bytesCountries = (int)memory1.Length;
            int country = bytesCountries / block;

            if (country == 0)
            {
                MessageBox.Show("No countries found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string countryName;
            UInt32 countryId;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START = -1348;
                long START2 = -140;

                int NumberOfRepetitions1 = Convert.ToInt32(country);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START += block;
                    memory1.Seek(START, SeekOrigin.Begin);
                    UInt32 Valor_imp_32 = reader.ReadUInt32();
                    countryId = Valor_imp_32 << 13;
                    countryId = countryId >> 23;

                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    countryName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0');

                    Form1._Form1.stadiumCountry.Items.Add(countryName);
                    Form1._Form1.teamCountry.Items.Add(countryName);

                    string mapValue;
                    if (!result.TryGetValue(countryId, out mapValue))
                        throw new ArgumentException("id not found in file Nationality.ini");
                    Form1._Form1.allenatoreNationality.Items.Add(mapValue);
                    Form1._Form1.giocatoreNationality.Items.Add(mapValue);

                    string mapValue2;
                    if (!result2.TryGetValue(countryId, out mapValue2))
                        throw new ArgumentException("id not found in file Nation.ini");
                    Form1._Form1.nationalityBox.Items.Add(mapValue2);
                }
                Form1._Form1.nationalityBox.Items.Add("All");

                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        private Dictionary<uint, string> readNationality()
        {
            var result = new Dictionary<uint, string>();

            foreach (string line in File.ReadLines(Application.StartupPath + @"\Data\Nationality.ini", Encoding.UTF8))
            {
                string[] tokenizer = line.Split(';');
                uint id = parseUint(tokenizer[0].Trim());

                if (id != 0)
                {
                    string nationality = tokenizer[1].Trim();
                    result.Add(id, nationality);
                }
            }

            return result;
        }

        private Dictionary<uint, string> readNation()
        {
            var result = new Dictionary<uint, string>();

            foreach (string line in File.ReadLines(Application.StartupPath + @"\Data\Nation.ini", Encoding.UTF8))
            {
                string[] tokenizer = line.Split(';');
                uint id = parseUint(tokenizer[0].Trim());

                if (id != 0)
                {
                    string nationality = tokenizer[1].Replace(" ", "").Trim();
                    result.Add(id, nationality);
                }
            }

            return result;
        }

        private uint parseUint(string s)
        {
            try
            {
                return uint.Parse(s);
            }
            catch
            {
                return 0;
            }
        }

        public Country loadCountry(int index, BinaryReader reader)
        {
            Country country = null;

            UInt32 countryId;
            string countryName;
            string shortName;
            UInt32 violet;
            UInt32 blue;
            UInt32 green;
            byte unk;
            byte zone;
            try
            {
                reader.BaseStream.Position = index * block;
                UInt32 Valor_imp_32 = reader.ReadUInt32();

                violet = Valor_imp_32 << 1;
                violet = violet >> 29;
                blue = Valor_imp_32 << 4;
                blue = blue >> 23;
                countryId = Valor_imp_32 << 13;
                countryId = countryId >> 23;
                green = Valor_imp_32 << 22;
                green = green >> 22;

                reader.BaseStream.Position = index * block + 4;
                unk = reader.ReadByte();

                reader.BaseStream.Position = index * block + 5;
                zone = reader.ReadByte();

                reader.BaseStream.Position = index * block + 143;
                countryName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0');

                reader.BaseStream.Position = index * block + 708;
                shortName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(3));

                country = new Country(countryId);
                country.setBlue(blue);
                country.setGreen(green);
                country.setName(countryName);
                country.setUnk(unk);
                country.setViolet(violet);
                country.setZone(zone);
                country.setShortName(shortName);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return country;
        }
    }
}

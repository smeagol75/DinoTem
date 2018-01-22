using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;
using DinoTem;
using Team_Editor_Manager_New_Generation.persistence;

namespace DinoTem.persistence
{
    //pes 18, pes 17
    public class MyCountryPersister
    {
        private static string PATH = "/Country.bin";

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

        public List<Country> load(string patch, int bitRecognized)
        {
            //leggo nazionalità
            var result = readNationality();
            var result2 = readNation();

            //leggo il file
            List<Country> countryList = new List<Country>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //Calcolo paesi
            // Create new FileInfo object and get the Length.
            int bytes_country = (int)memory1.Length;
            int calcolo_paesi = bytes_country / 1348;

            byte[] block;
            byte continent;
            string countryName;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);

                int i2 = 0;
                long START2 = -1348; //blocco
                long START4 = -1344; //continent
                long START3 = -140; //nome country

                int NumberOfRepetitions2 = Convert.ToInt32(calcolo_paesi);
                for (i2 = 1; i2 <= NumberOfRepetitions2; i2++)
                {
                    START2 += 1348;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    block = reader.ReadBytes(4);

                    START4 += 1348;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    continent = reader.ReadByte();
                            
                    START3 += 1348;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    countryName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(46)).TrimEnd('\0');

                    string Blocco = MyBinary.Reverse32(block);

                    string mapValue;
                    if (!result.TryGetValue(MyBinary.BinaryToInt(Blocco.Substring(13, 9)), out mapValue))
                        throw new ArgumentException("id not found in file Nationality.ini");

                    Country f = new Country(MyBinary.BinaryToInt(Blocco.Substring(13, 9)), Continent(continent), mapValue, countryName);

                    string mapValue2;
                    if (!result2.TryGetValue(MyBinary.BinaryToInt(Blocco.Substring(13, 9)), out mapValue2))
                        throw new ArgumentException("id not found in file Nation.ini");
                    f.setNationFm(mapValue2);

                    countryList.Add(f);
                }
                Country f2 = new Country(0, "NOTHING", "No second National", "No second National");
                f2.setNationFm("No second National");
                countryList.Add(f2);

                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return countryList;
        }

        private string Continent(int i)
        {
            if (i == 2)
            {
                return "EUROPE";
            }
            else if (i == 3)
            {
                return "ASIA";
            }
            if (i == 4)
            {
                return "SOUTH AMERICA";
            }
            else if (i == 5)
            {
                return "AFRICA";
            }
            else if (i == 6)
            {
                return "NORTH AMERICA";
            }
            else if (i == 7)
            {
                return "OCEANIA";
            }

            return "NOTHING";
        }

        private Dictionary<int, string> readNationality()
        {
            var result = new Dictionary<int, string>();

            foreach (string line in File.ReadLines(Application.StartupPath + @"\Data\Nationality.ini", Encoding.UTF8))
            {
                string[] tokenizer = line.Split(';');
                int id = parseInt(tokenizer[0].Trim());

                if (id != -1)
                {
                    string nationality = tokenizer[1].Trim();
                    result.Add(id, nationality);
                }
            }
		
		    return result;
        }

        private Dictionary<int, string> readNation()
        {
            var result = new Dictionary<int, string>();

            foreach (string line in File.ReadLines(Application.StartupPath + @"\Data\Nation.ini", Encoding.UTF8))
            {
                string[] tokenizer = line.Split(';');
                int id = parseInt(tokenizer[0].Trim());

                if (id != -1)
                {
                    string nationality = tokenizer[1].Replace(" ","").Trim();
                    result.Add(id, nationality);
                }
            }

            return result;
        }

        private int parseInt(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch {
                return -1;
            }
        }

        public void save(int bitRecognized)
        {
            // TODO Auto-generated method stub
        }

    }
}

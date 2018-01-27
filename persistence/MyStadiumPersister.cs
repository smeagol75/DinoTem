using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using Team_Editor_Manager_New_Generation.persistence;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18
    public class MyStadiumPersister
    {
        private static string PATH = "/Stadium.bin";

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
                UnzlibZlibConsole.UnzlibZlibConsole.Stadium_toPc(ref memory1);
            }

            return memory1;
        }

        public List<Stadium> load(string patch, int bitRecognized)
        {
            List<Stadium> stadiumList = new List<Stadium>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //Calcolo stadi
            int bytes_stadium = (int)memory1.Length;
            int stadium = bytes_stadium / 272;

			string japaneseName;
            string stadiumName;
			string konamiName;
			byte[] Block;
            UInt16 stadiumId;
			UInt16 zone;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i1 = 0;

				long START5 = -272; //block
                long START = -268; //id
				long START1 = -264; //nome japanese
				long START2 = -143; //nome stadio
				long START4 = -266; //zone
				long START3 = -22; //konami

                int NumberOfRepetitions1 = Convert.ToInt32(stadium);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
					START += 272;
                    memory1.Seek(START, SeekOrigin.Begin);
                    stadiumId = reader.ReadUInt16();

                    Stadium temp = new Stadium(stadiumId);

                    START2 += 272;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    stadiumName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(58)).TrimEnd('\0');
                    temp.setName(stadiumName);
					
					//Block
                    START5 += 272;
                    memory1.Seek(START5, SeekOrigin.Begin);
                    Block = reader.ReadBytes(4);
                    StringBuilder sba2 = new StringBuilder();
                    foreach (byte read2 in Block)
                        sba2.Append(read2.ToString("X2"));
                    string hexStringm2 = sba2.ToString();
					//(BYTE 00-01-02-03)
					string blocco2 = hexStringm2.Substring(0, 8);
                    blocco2 = blocco2.Substring(6, 2) + blocco2.Substring(4, 2) + blocco2.Substring(2, 2) + blocco2.Substring(0, 2);
                    blocco2 = Convert.ToString(Convert.ToInt64(blocco2, 16), 2).PadLeft(32, '0');
					temp.setNa(MyBinary.BinaryToInt(blocco2.Substring(0, 2)));
                    if (blocco2.Substring(2, 1).Equals("1"))
                        temp.setLicense(true);
                    else
                        temp.setLicense(false);
					temp.setCountry(MyBinary.BinaryToInt(blocco2.Substring(3, 9)));
					temp.setCapacity(MyBinary.BinaryToInt(blocco2.Substring(12, 20)));
					
					START1 += 272;
                    memory1.Seek(START1, SeekOrigin.Begin);
                    japaneseName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(58)).TrimEnd('\0');
                    temp.setJapaneseName(japaneseName);
					START4 += 272;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    zone = reader.ReadUInt16();
                    temp.setZone(zone);
					START3 += 272;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    konamiName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(22)).TrimEnd('\0');
                    temp.setKonamiName(konamiName);

                    stadiumList.Add(temp);
                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return stadiumList;
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

        private void saveHex0(long value, BinaryWriter b)
        {
            string hex2klkoa6 = value.ToString("X8").Substring(6, 2) + " " + value.ToString("X8").Substring(4, 2) + " " + value.ToString("X8").Substring(2, 2) + " " + value.ToString("X8").Substring(0, 2);  // La tua stringa contenente i valori esadecimali
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
            string hex2klkoa6 = "00";  // La tua stringa contenente i valori esadecimali
            for (int i = value; i < 120; i++)
            {
                hex2klkoa6 += " 00";
            }
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        private void saveHexText2(int value, BinaryWriter b)
        {
            string hex2klkoa6 = "00";  // La tua stringa contenente i valori esadecimali
            for (int i = value; i < 21; i++)
            {
                hex2klkoa6 += " 00";
            }
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
                foreach (Stadium temp in controller.getListStadium())
                {
                    string license = "0";
                    if (temp.getLicense())
                        license = "1";

                    string unire1 = MyBinary.ToBinaryX(temp.getNa(), 2) + license + MyBinary.ToBinaryX(temp.getCountry(), 9) + MyBinary.ToBinaryX(temp.getCapacity(), 20);
                    saveHex0(MyBinary.BinaryToInt(unire1), b);
                    saveHex(temp.getId(), b);
                    saveHex(temp.getZone(), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getJapaneseName()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getJapaneseName()).Count(), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getName()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getName()).Count(), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getKonamiName()));
                    saveHexText2(Encoding.UTF8.GetBytes(temp.getKonamiName()).Count(), b);
                }
            }

            if (bitRecognized == 0)
            {
                //save zlib
                byte[] inputData1 = File.ReadAllBytes(patch + PATH);
                byte[] ss2 = Zlib18.ZLIBFile(inputData1);
                File.WriteAllBytes(patch + PATH, ss2);
            }
            else if (bitRecognized == 1)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.Stadium_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.Stadium_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
        }

    }
}

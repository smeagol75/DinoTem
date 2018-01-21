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
    public class MyTeamPersister
    {
        private static string PATH = "/Team.bin";

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
                UnzlibZlibConsole.UnzlibZlibConsole.Team_toPc(ref memory1);
            }

            return memory1;
        }

        public List<Team> load(string patch, int bitRecognized)
        {
            List<Team> teamList = new List<Team>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //Calcolo squadre
            int bytes_team = (int)memory1.Length;
            int calcolo_squadre = bytes_team / 1400;

            UInt16 IdTeam;
            UInt32 idManager;
            UInt32 feederTeamId;
            UInt32 parentTeamId;
            UInt16 stadiumId;
            UInt16 teamSortNumber;
            byte[] blocco1;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i = 0;
                long START21 = -1400; //managerid
                long START22 = -1396; //feederTeamId
                long START23 = -1388; //parentTeamId
                long START24 = -1384; //stadiumId
                long START25 = -1382; //teamSortNumber
                long START = -1392; //id
                long START1 = -1380; //blocco
                long START5 = -1376; //japanese
                long START6 = -1306; //spanish
                long START7 = -1236; //greek
                long START3 = -1166; //english
                long START8 = -1026; //latin america
                long START9 = -956; //French
                long START10 = -886; //Turkish
                long START11 = -816; //Portuguese
                long START12 = -746; //KONAMI
                long START14 = -722; //German
                long START4 = -652; //Short Name
                long START15 = -642; //brazilian Portuguese
                long START16 = -502; //Dutch
                long START17 = -362; //Swedish
                long START18 = -292; //Italian
                long START19 = -222; //Russian
                long START20 = -72; //English US
                long START26 = -152; //internalShortName

                int NumberOfRepetitions = Convert.ToInt32(calcolo_squadre);
                for (i = 1; i <= NumberOfRepetitions; i++)
                {
                    START += 1400;
                    memory1.Seek(START, SeekOrigin.Begin);
                    IdTeam = reader.ReadUInt16();

                    //Blocco
                    START1 += 1400;
                    memory1.Seek(START1, SeekOrigin.Begin);
                    blocco1 = reader.ReadBytes(4);
                    string blocco = MyBinary.Reverse32(blocco1);

                    Team temp; //inizializzo squadra (nazionale o club?)
                    if (blocco.Substring(7, 1).Equals("1"))
                    {
                        temp = new National(IdTeam);
                        temp.setNational(true);
                    }
                    else
                    {
                        temp = new Club(IdTeam);
                        temp.setNational(false);
                    }

                    //enlish
                    START3 += 1400;
                    memory1.Seek(START3, SeekOrigin.Begin);
                    temp.setEnglish(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));

                    if (blocco.Substring(5, 1).Equals("1"))
                        temp.setHasLicensedPlayers(true);
                    else
                        temp.setHasLicensedPlayers(false);

                    if (blocco.Substring(6, 1).Equals("1"))
                        temp.setLicensedTeam(true);
                    else
                        temp.setLicensedTeam(false);

                    if (blocco.Substring(8, 1).Equals("1"))
                        temp.setFakeTeam(true);
                    else
                        temp.setFakeTeam(false);

                    if (blocco.Substring(9, 2).Equals("11"))
                        temp.setLicensedCoach(true);
                    else
                        temp.setLicensedCoach(false);

                    if (blocco.Substring(11, 1).Equals("1"))
                        temp.setHasAnthem(true);
                    else
                        temp.setHasAnthem(false);
                    temp.setAnthemStandingAngle(MyBinary.BinaryToInt(blocco.Substring(12, 2)));
                    temp.setAnthemPlayersSinging(MyBinary.BinaryToInt(blocco.Substring(14, 2)));
                    temp.setAnthemStandingStyle(MyBinary.BinaryToInt(blocco.Substring(16, 3)));
                    if (blocco.Substring(19, 1).Equals("1"))
                        temp.setUnknown6(true);
                    else
                        temp.setUnknown6(false);
                    temp.setNotPlayableLeague(MyBinary.BinaryToInt(blocco.Substring(20, 3)));
                    temp.setCountry(MyBinary.BinaryToInt(blocco.Substring(23, 9)));

                    //manager id
                    START21 += 1400;
                    memory1.Seek(START21, SeekOrigin.Begin);
                    idManager = reader.ReadUInt32();
                    temp.setManagerId(idManager);

                    //feederTeamId
                    START22 += 1400;
                    memory1.Seek(START22, SeekOrigin.Begin);
                    feederTeamId = reader.ReadUInt32();
                    temp.setFeederTeamId(feederTeamId);

                    //parentTeamId
                    START23 += 1400;
                    memory1.Seek(START23, SeekOrigin.Begin);
                    parentTeamId = reader.ReadUInt32();
                    temp.setParentTeamId(parentTeamId);

                    //stadiumId
                    START24 += 1400;
                    memory1.Seek(START24, SeekOrigin.Begin);
                    stadiumId = reader.ReadUInt16();
                    temp.setStadiumId(stadiumId);

                    //setTeamSortNumber
                    START25 += 1400;
                    memory1.Seek(START25, SeekOrigin.Begin);
                    teamSortNumber = reader.ReadUInt16();
                    temp.setTeamSortNumber(teamSortNumber);

                    //japanese
                    START5 += 1400;
                    memory1.Seek(START5, SeekOrigin.Begin);
                    temp.setJapanese(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //spanish
                    START6 += 1400;
                    memory1.Seek(START6, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setSpanish(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //greek
                    START7 += 1400;
                    memory1.Seek(START7, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setGreek(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //english
                    //latin america (spa2)
                    START8 += 1400;
                    memory1.Seek(START8, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setLatinAmericaSpanish(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //french
                    START9 += 1400;
                    memory1.Seek(START9, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setFrench(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //turkish
                    START10 += 1400;
                    memory1.Seek(START10, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setTurkish(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //portuguese
                    START11 += 1400;
                    memory1.Seek(START11, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setPortuguese(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //internal_name
                    START12 += 1400;
                    memory1.Seek(START12, SeekOrigin.Begin);
                    temp.setKonami(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(24)).Trim());
                    //.TrimEnd('\0')
                    //german
                    START14 += 1400;
                    memory1.Seek(START14, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setGerman(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //short
                    START4 += 1400;
                    memory1.Seek(START4, SeekOrigin.Begin);
                    temp.setShortSquadra(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(3)).TrimEnd('\0'));
                    //portuguese brazil
                    START15 += 1400;
                    memory1.Seek(START15, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setBrazilianPortuguese(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //nederlans
                    START16 += 1400;
                    memory1.Seek(START16, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setDutch(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //swedish
                    START17 += 1400;
                    memory1.Seek(START17, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setSwedish(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //italian
                    START18 += 1400;
                    memory1.Seek(START18, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setItalian(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //russian
                    START19 += 1400;
                    memory1.Seek(START19, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setRussian(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    //english (US)
                    START20 += 1400;
                    memory1.Seek(START20, SeekOrigin.Begin);
                    if (temp.getNational())
                        ((National)temp).setEnglishUS(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(70)).TrimEnd('\0'));
                    teamList.Add(temp);

                    //internal short name
                    START26 += 1400;
                    memory1.Seek(START26, SeekOrigin.Begin);
                    if (!temp.getNational())
                        ((Club)temp).setInternalShortName(System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4)));
                    //.TrimEnd('\0')
                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
		
		    return teamList;
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

        private void saveHex7(BinaryWriter b)
        {
            string hex2klkoa6 = "00 00 00 00 00 00 00";  // La tua stringa contenente i valori esadecimali
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        private void saveHexText70(BinaryWriter b)
        {
            string hex2klkoa6 = "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";  // La tua stringa contenente i valori esadecimali
            string[] hexValuesSplit2klkoa6 = hex2klkoa6.Split(' ');
            byte[] Bytes2klkoa6 = new byte[hexValuesSplit2klkoa6.Length];   // La matrice di byte che verrà scritta nel file

            for (int Ivo = 0; Ivo <= hexValuesSplit2klkoa6.Length - 1; Ivo++)
            {
                Bytes2klkoa6[Ivo] = Convert.ToByte(hexValuesSplit2klkoa6[Ivo], 16);    // Converte ogni singolo esadecimale in un valore di tipo byte e lo mette nella matrice di byte
            }
            b.Write(Bytes2klkoa6);
        }

        private void saveHexText(int valueStringa, int totaLenght, BinaryWriter b)
        {
            string hex2klkoa6 = "00";  // La tua stringa contenente i valori esadecimali
            for (int i = valueStringa; i < totaLenght; i++)
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
                foreach (Team temp in controller.getListTeam())
                {
                    saveHex0(temp.getManagerId(), b);
                    saveHex0(temp.getFeederTeamId(), b);
                    saveHex(temp.getId(), b);
                    saveHex(0, b);
                    saveHex0(temp.getParentTeamId(), b);
                    saveHex(temp.getStadiumId(), b);
                    saveHex(temp.getTeamSortNumber(), b);

                    string hasLicensedPlayers = "0";
                    if (temp.getHasLicensedPlayers())
                        hasLicensedPlayers = "1";

                    string licensedTeam = "0";
                    if (temp.getLicensedTeam())
                        licensedTeam = "1";

                    string national = "0";
                    if (temp.getNational())
                        national = "1";

                    string fakeTeam = "0";
                    if (temp.getFakeTeam())
                        fakeTeam = "1";

                    string licensedCoach = "00";
                    if (temp.getLicensedCoach())
                    {
                        licensedCoach = "11";
                    }

                    string hasAnthem = "0";
                    if (temp.getHasAnthem())
                        hasAnthem = "1";

                    string unk6 = "0";
                    if (temp.getUnknown6())
                        unk6 = "1";
                    
                    //blocco 20/23
                    string unire1 = "00000" + hasLicensedPlayers + licensedTeam + national + fakeTeam + licensedCoach + hasAnthem + MyBinary.ToBinaryX(temp.getAnthemStandingAngle(), 2) + MyBinary.ToBinaryX(temp.getAnthemPlayersSinging(), 2) + MyBinary.ToBinaryX(temp.getAnthemStandingStyle(), 3) + unk6 + MyBinary.ToBinaryX(temp.getNotPlayableLeague(), 3) + MyBinary.ToBinaryX(temp.getCountry(), 9);
                    saveHex0(MyBinary.BinaryToInt(unire1), b);
                    b.Write(Encoding.UTF8.GetBytes(temp.getJapanese()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getJapanese()).Count(), 69, b);
                    if (temp.getNational())
                    {
                        National temp2 = (National)temp;
                        b.Write(Encoding.UTF8.GetBytes(temp2.getSpanish()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getSpanish()).Count(), 69, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getGreek()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getGreek()).Count(), 69, b);
                    }
                    else
                    {
                        saveHexText70(b);
                        saveHexText70(b);
                    }
                    b.Write(Encoding.UTF8.GetBytes(temp.getEnglish()));
                    saveHexText(Encoding.UTF8.GetBytes(temp.getEnglish()).Count(), 69, b);
                    saveHexText70(b);
                    if (temp.getNational())
                    {
                        National temp2 = (National)temp;
                        b.Write(Encoding.UTF8.GetBytes(temp2.getLatinAmericaSpanish()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getLatinAmericaSpanish()).Count(), 69, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getFrench()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getFrench()).Count(), 69, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getTurkish()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getTurkish()).Count(), 69, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getPortuguese()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getPortuguese()).Count(), 69, b);
                    }
                    else
                    {
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                    }
                    b.Write(Encoding.UTF8.GetBytes(temp.getKonami()));//
                    if (temp.getNational())
                    {
                        National temp2 = (National)temp;
                        b.Write(Encoding.UTF8.GetBytes(temp2.getGerman()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getGerman()).Count(), 69, b);
                    }
                    else
                        saveHexText70(b);

                    b.Write(Encoding.UTF8.GetBytes(temp.getShortSquadra()));
                    if (temp.getShortSquadra().Count() != 3)
                        saveHexText(Encoding.UTF8.GetBytes(temp.getShortSquadra()).Count(), 2, b);
                    saveHex7(b);
                    if (temp.getNational())
                    {
                        National temp2 = (National)temp;
                        b.Write(Encoding.UTF8.GetBytes(temp2.getBrazilianPortuguese()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getBrazilianPortuguese()).Count(), 69, b);
                        saveHexText70(b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getDutch()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getDutch()).Count(), 69, b);
                        saveHexText70(b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getSwedish()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getSwedish()).Count(), 69, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getItalian()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getItalian()).Count(), 69, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getRussian()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getRussian()).Count(), 69, b);
                        saveHexText70(b);
                        saveHex0(0, b);
                        saveHex0(0, b);
                        saveHex(0, b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getEnglishUS()));
                        saveHexText(Encoding.UTF8.GetBytes(temp2.getEnglishUS()).Count(), 69, b);
                    }
                    else
                    {
                        Club temp2 = (Club)temp;
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                        saveHexText70(b);
                        b.Write(Encoding.UTF8.GetBytes(temp2.getInternalShortName()));//
                        saveHex0(0, b);
                        saveHex(0, b);
                        saveHexText70(b);
                        saveHexText70(b);
                    }
                    saveHex(0, b);
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
                UnzlibZlibConsole.UnzlibZlibConsole.Team_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
            else if (bitRecognized == 2)
            {
                byte[] inputData13 = File.ReadAllBytes(patch + PATH);
                MemoryStream memory1 = new MemoryStream(inputData13);
                UnzlibZlibConsole.UnzlibZlibConsole.Team_toConsole(ref memory1);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memory1, patch + PATH);
                memory1.Close();
            }
		
	    }
    }
}

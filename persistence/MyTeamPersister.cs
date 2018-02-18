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
        private static int block = 1400;

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

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo squadre
            int bytesTeam = (int)memory1.Length;
            int team = bytesTeam / block;

            string teamName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -1166;

                int NumberOfRepetitions1 = Convert.ToInt32(team);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    teamName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                    Form1._Form1.teamBox1.Items.Add(teamName);
                    Form1._Form1.teamBox2.Items.Add(teamName);
                    Form1._Form1.teamsBox.Items.Add(teamName);
                    Form1._Form1.derbyTeam1.Items.Add(teamName);
                    Form1._Form1.derbyTeam2.Items.Add(teamName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
	    }

        private UInt32 Coach_pos = 0;
        private UInt32 feederTeamId = 4;
        private UInt32 Id_32_pos = 8;
        private UInt32 parentTeamId = 8;
        private UInt32 Stadium_16_pos = 16;
        private UInt32 Country_16_pos = 20;
        public Team loadTeam(int index, BinaryReader reader)
        {
            Team team = null;

            UInt32 idTeam;
            UInt32 stadium;
            UInt32 country;
            UInt32 coach;
            UInt32 feeder;
            UInt32 parent;
            string teamJapanese;
            string teamSpanish;
            string teamGreek;
            string teamEnglish;
            string teamlatinAmerica;
            string teamFrench;
            string teamTurkish;
            string teamPortuguese;
            string teamKonami;
            string teamGerman;
            string shortName;
            string teamBrazilianPortuguese;
            string teamDutch;
            string teamSwedish;
            string teamItalian;
            string teamRussian;
            string teamEnglishUs;
            try
            {
                index = index * block;

                reader.BaseStream.Position = index + Coach_pos;
                coach = reader.ReadUInt32();
                reader.BaseStream.Position = index + feederTeamId;
                feeder = reader.ReadUInt32();
                reader.BaseStream.Position = (index + Id_32_pos);
                idTeam = reader.ReadUInt32();
                reader.BaseStream.Position = index + parentTeamId;
                parent = reader.ReadUInt32();
                reader.BaseStream.Position = (index + Stadium_16_pos);
                stadium = reader.ReadUInt16();
                reader.BaseStream.Position = (index + Country_16_pos);
                UInt32 Valor_IMP_32 = reader.ReadUInt32();

                /*UInt32 CHECK90 = Valor_IMP_32 >> 31;
                UInt32 CHECK91 = Valor_IMP_32 << 1;
                CHECK91 = CHECK91 >> 31;
                UInt32 CHECK92 = Valor_IMP_32 << 2;
                CHECK92 = CHECK92 >> 31;
                UInt32 CHECK93 = Valor_IMP_32 << 3;
                CHECK93 = CHECK93 >> 31;
                UInt32 CHECK94 = Valor_IMP_32 << 4;
                CHECK94 = CHECK94 >> 31;*/

                UInt32 CHECK95 = Valor_IMP_32 << 5;
                CHECK95 = CHECK95 >> 31;
                UInt32 CHECK96 = Valor_IMP_32 << 6;
                CHECK96 = CHECK96 >> 31;
                UInt32 CHECK97 = Valor_IMP_32 << 7;
                CHECK97 = CHECK97 >> 31;
                UInt32 CHECK98 = Valor_IMP_32 << 8;
                CHECK98 = CHECK98 >> 31;
                UInt32 CHECK99 = Valor_IMP_32 << 9;
                CHECK99 = CHECK99 >> 31;
                UInt32 CHECK100 = Valor_IMP_32 << 10;
                CHECK100 = CHECK100 >> 31;
                UInt32 CHECK101 = Valor_IMP_32 << 11;
                CHECK101 = CHECK101 >> 31;
                UInt32 Gray = Valor_IMP_32 << 12;
                Gray = Gray >> 30;
                UInt32 Orange = Valor_IMP_32 << 14;
                Orange = Orange >> 30;
                UInt32 Pink = Valor_IMP_32 << 16;
                Pink = Pink >> 29;
                UInt32 Non_playable_team = Valor_IMP_32 << 19;
                Non_playable_team = Non_playable_team >> 28;
                country = Valor_IMP_32 << 23;
                country = country >> 23;

                if (CHECK97 == 1)
                {
                    team = new National(idTeam);
                    team.setNational(CHECK97);
                }
                else
                {
                    team = new Club(idTeam);
                    team.setNational(CHECK97);
                }
                team.setManagerId(coach);
                team.setFeederTeamId(feeder);
                team.setParentTeamId(parent);
                team.setStadiumId(stadium);
                //teamSortNumber
                team.setHasLicensedPlayers(CHECK95);
                team.setLicensedTeam(CHECK96);
                //
                team.setFakeTeam(CHECK98);
                team.setLicensedCoach(CHECK99);
                team.setLicensedCoach2(CHECK100);
                team.setHasAnthem(CHECK101);
                team.setAnthemStandingAngle(Gray);
                team.setAnthemPlayersSinging(Orange);
                team.setAnthemStandingStyle(Pink);
                team.setNotPlayableLeague(Non_playable_team);
                team.setCountry(country);

                reader.BaseStream.Position = index + 24;
                teamJapanese = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 94;
                teamSpanish = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 164;
                teamGreek = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 234;
                teamEnglish = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 374;
                teamlatinAmerica = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 444;
                teamFrench = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 514;
                teamTurkish = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 584;
                teamPortuguese = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 654;
                teamKonami = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(24)).TrimEnd('\0');

                reader.BaseStream.Position = index + 678;
                teamGerman = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 748;
                shortName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(3)).TrimEnd('\0');

                reader.BaseStream.Position = index + 758;
                teamBrazilianPortuguese = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 898;
                teamDutch = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 1038;
                teamSwedish = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 1108;
                teamItalian = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 1178;
                teamRussian = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                reader.BaseStream.Position = index + 1328;
                teamEnglishUs = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(45)).TrimEnd('\0');

                team.setShortSquadra(shortName);
                team.setEnglish(teamEnglish);
                team.setKonami(teamKonami);
                team.setJapanese(teamJapanese);
                if (CHECK97 == 1)
                {
                    ((National)team).setSpanish(teamSpanish);
                    ((National)team).setGreek(teamGreek);
                    ((National)team).setLatinAmericaSpanish(teamlatinAmerica);
                    ((National)team).setFrench(teamFrench);
                    ((National)team).setTurkish(teamTurkish);
                    ((National)team).setPortuguese(teamPortuguese);
                    ((National)team).setGerman(teamGerman);
                    ((National)team).setBrazilianPortuguese(teamBrazilianPortuguese);
                    ((National)team).setDutch(teamDutch);
                    ((National)team).setSwedish(teamSwedish);
                    ((National)team).setItalian(teamItalian);
                    ((National)team).setRussian(teamRussian);
                    ((National)team).setEnglishUS(teamEnglishUs);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return team;
        }

        public void applyTeam(int selectedIndex, MemoryStream unzlib, Team squadra, ref BinaryWriter writer)
        {
            int pos_ini_team_block = selectedIndex * block;

            UInt32 New_coach = squadra.getManagerId();
            writer.BaseStream.Position = pos_ini_team_block + 0;
            writer.Write(New_coach);
            UInt32 NewId = squadra.getId();
            writer.BaseStream.Position = pos_ini_team_block + 8;
            writer.Write(NewId);
            UInt16 NewStadium = (UInt16) squadra.getStadiumId();
            writer.BaseStream.Position = pos_ini_team_block + 16;
            writer.Write(NewStadium);

            writer.BaseStream.Position = pos_ini_team_block + 20;
            UInt32 Aux = 0;
            UInt32 Nuevo_val_32 = 0;
            UInt32 CHECK90 = 0;
            /*if ((Form1.CheckBox90.Checked == true))
            {
                CHECK90 = 1;
            }
            else
            {
                CHECK90 = 0;
            }*/

            UInt32 CHECK91 = 0;
            /*if ((Form1.CheckBox91.Checked == true))
            {
                CHECK91 = 1;
            }
            else
            {
                CHECK91 = 0;
            }*/

            UInt32 CHECK92 = 0;
            /*if ((Form1.CheckBox92.Checked == true))
            {
                CHECK92 = 1;
            }
            else
            {
                CHECK92 = 0;
            }*/

            UInt32 CHECK93 = 0;
            /*if ((Form1.CheckBox93.Checked == true))
            {
                CHECK93 = 1;
            }
            else
            {
                CHECK93 = 0;
            }*/

            UInt32 CHECK94 = 0;
            /*if ((Form1.CheckBox94.Checked == true))
            {
                CHECK94 = 1;
            }
            else
            {
                CHECK94 = 0;
            }*/

            UInt32 CHECK95;
            if (squadra.getHasLicensedPlayers() == 1)
            {
                CHECK95 = 1;
            }
            else
            {
                CHECK95 = 0;
            }

            UInt32 CHECK96;
            if (squadra.getLicensedTeam() == 1)
            {
                CHECK96 = 1;
            }
            else
            {
                CHECK96 = 0;
            }

            UInt32 CHECK97;
            if (squadra.getNational() == 1)
            {
                CHECK97 = 1;
            }
            else
            {
                CHECK97 = 0;
            }

            UInt32 CHECK98;
            if (squadra.getFakeTeam() == 1)
            {
                CHECK98 = 1;
            }
            else
            {
                CHECK98 = 0;
            }

            UInt32 CHECK99;
            if (squadra.getLicensedCoach() == 1)
            {
                CHECK99 = 1;
            }
            else
            {
                CHECK99 = 0;
            }

            UInt32 CHECK100;
            if (squadra.getLicensedCoach2() == 1)
            {
                CHECK100 = 1;
            }
            else
            {
                CHECK100 = 0;
            }

            UInt32 CHECK101;
            if (squadra.getHasAnthem() == 1)
            {
                CHECK101 = 1;
            }
            else
            {
                CHECK101 = 0;
            }

            UInt32 New_Gray = squadra.getAnthemStandingAngle();
            UInt32 New_Orange = squadra.getAnthemPlayersSinging();
            UInt32 New_Pink = squadra.getAnthemStandingStyle();
            UInt32 New_Non_playable_team = squadra.getNotPlayableLeague();
            UInt32 New_Country_16 = squadra.getCountry();
            Aux = CHECK90;
            Aux = Aux << 31;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK91;
            Aux = Aux << 30;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK92;
            Aux = Aux << 29;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK93;
            Aux = Aux << 28;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK94;
            Aux = Aux << 27;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK95;
            Aux = Aux << 26;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK96;
            Aux = Aux << 25;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK97;
            Aux = Aux << 24;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK98;
            Aux = Aux << 23;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK99;
            Aux = Aux << 22;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK100;
            Aux = Aux << 21;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = CHECK101;
            Aux = Aux << 20;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = New_Gray;
            Aux = Aux << 18;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = New_Orange;
            Aux = Aux << 16;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = New_Pink;
            Aux = Aux << 13;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = New_Non_playable_team;
            Aux = Aux << 9;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            Aux = New_Country_16;
            Nuevo_val_32 = Aux | Nuevo_val_32;
            writer.Write(Nuevo_val_32);

            int Position_sel = 24;
            writer.BaseStream.Position = pos_ini_team_block + Position_sel;
            for (int i = pos_ini_team_block + Position_sel; i <= (pos_ini_team_block + Position_sel) + 69; i++)
            {
                byte cero = 0;
                writer.Write(cero);
            }
            writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
            writer.Write(squadra.getJapanese().ToCharArray());

            Position_sel = 234;
            writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
            for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
            {
                byte cero = 0;
                writer.Write(cero);
            }

            writer.BaseStream.Position = pos_ini_team_block + Position_sel;
            writer.Write(squadra.getEnglish().ToCharArray());

            if (squadra.getNational() == 1)
            {
                Position_sel = 94;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = pos_ini_team_block + Position_sel; i <= (pos_ini_team_block + Position_sel) + 69; i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = pos_ini_team_block + Position_sel;
                writer.Write(((National)squadra).getSpanish().ToCharArray());

                Position_sel = 164;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = pos_ini_team_block + Position_sel;
                writer.Write(((National)squadra).getGreek().ToCharArray());

                /*Position_sel = 304;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(Form1.TextBox_Team_Na.Text.ToCharArray());*/

                Position_sel = 374;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getLatinAmericaSpanish().ToCharArray());

                Position_sel = 444;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getFrench().ToCharArray());

                Position_sel = 514;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getTurkish().ToCharArray());

                Position_sel = 584;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getPortuguese().ToCharArray());

                Position_sel = 678;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getGerman().ToCharArray());

                Position_sel = 758;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getBrazilianPortuguese().ToCharArray());

                Position_sel = 898;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getDutch().ToCharArray());

                Position_sel = 1038;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getSwedish().ToCharArray());

                Position_sel = 1108;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getItalian().ToCharArray());

                Position_sel = 1178;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getRussian().ToCharArray());

                Position_sel = 1328;
                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                for (int i = (pos_ini_team_block + Position_sel); (i <= ((pos_ini_team_block + Position_sel) + 69)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + Position_sel);
                writer.Write(((National)squadra).getEnglishUS().ToCharArray());
            }

            // Nombre Short
            writer.BaseStream.Position = (pos_ini_team_block + 748);
            for (int i = (pos_ini_team_block + 748); (i <= ((pos_ini_team_block + 748) + 3)); i++)
            {
                byte cero = 0;
                writer.Write(cero);
            }

            writer.BaseStream.Position = (pos_ini_team_block + 748);
            writer.Write(squadra.getShortSquadra().ToCharArray());

            // bloque short si es o no licensed
            if (CHECK96 == 1 || CHECK98 == 1)
            {
                writer.BaseStream.Position = (pos_ini_team_block + 748);
                for (int i = pos_ini_team_block + 748; i <= ((pos_ini_team_block + 748) + 3); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + 748);
                writer.Write(squadra.getShortSquadra().ToCharArray());
                writer.BaseStream.Position = (pos_ini_team_block + 1248);
                for (int i = (pos_ini_team_block + 1248); (i <= ((pos_ini_team_block + 1248) + 3)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                if ((CHECK96 == 1))
                {
                    writer.BaseStream.Position = (pos_ini_team_block + 1248);
                    writer.Write("None".ToCharArray());
                }

            }
            else
            {
                writer.BaseStream.Position = (pos_ini_team_block + 1248);
                for (int i = (pos_ini_team_block + 1248); (i <= ((pos_ini_team_block + 1248) + 3)); i++)
                {
                    byte cero = 0;
                    writer.Write(cero);
                }

                writer.BaseStream.Position = (pos_ini_team_block + 1248);
                writer.Write(squadra.getShortSquadra().ToCharArray());
            }
        }

        public void save(string patch, ref MemoryStream memorySquadre, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memorySquadre.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Team_toConsole(ref memorySquadre);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memorySquadre, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Team_toConsole(ref memorySquadre);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memorySquadre, patch + PATH);
            }
        }
    }
}

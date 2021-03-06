﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DinoTem.model;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;

namespace DinoTem.ui
{
    //pes 18
    class MyCoachPersister
    {
        private static string PATH = "/Coach.bin";
        private static int block = 108;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Coach_toPc(memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo allenatori
            int bytesCoach = (int)memory1.Length;
            int coach = bytesCoach / block;

            if (coach == 0)
            {
                MessageBox.Show("No coaches found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string coachName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -46;

                int NumberOfRepetitions1 = Convert.ToInt32(coach);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    coachName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(40)).TrimEnd('\0');

                    Form1._Form1.coachBox.Items.Add(coachName);
                    Form1._Form1.teamCoach.Items.Add(coachName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Coach loadCoach(int index, BinaryReader reader)
        {
            Coach coach = null;

            UInt32 coachId;
            string coachName;
            string japName;
            UInt16 countryId;
            byte byteLic;
            UInt16 coachLicId = 0;
            try
            {
                reader.BaseStream.Position = index * block;
                coachId = reader.ReadUInt32();

                reader.BaseStream.Position = index * block + 2;
                byteLic = reader.ReadByte();

                reader.BaseStream.Position = index * block + 4;
                countryId = reader.ReadUInt16();
                countryId = (ushort) (countryId << 8);
                countryId = (ushort)(countryId >> 8);

                reader.BaseStream.Position = index * block + 16;
                japName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(40)).TrimEnd('\0');

                reader.BaseStream.Position = index * block + 62;
                coachName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(40)).TrimEnd('\0');

                if (byteLic != 0)
                {
                    reader.BaseStream.Position = index * block;
                    coachLicId = reader.ReadUInt16();
                }

                coach = new Coach(coachId);
                coach.setJapName(japName);
                coach.setName(coachName);
                coach.setCountry(countryId);
                coach.setByteLic(byteLic);
                coach.setCoachLicId(coachLicId);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return coach;
        }

        public int loadCoachById(MemoryStream memory1, BinaryReader reader, UInt32 coachId)
        {
            int bytes = (int)memory1.Length;
            int coach = bytes / block;

            reader.BaseStream.Position = 0;
            for (int i = 0; i <= (coach - 1); i++)
            {
                if (coachId == reader.ReadUInt32())
                    return i;
                reader.BaseStream.Position += block - 4;
            }

            return -1;
        }

        public UInt32 findIndexCoach(MemoryStream memory1, BinaryReader reader)
        {
            UInt32 coach_index_mayor = 0;

            int bytesCoach = (int)memory1.Length;
            int coach = bytesCoach / block;

            for (int i = 0; (i <= (coach - 1)); i++)
            {
                UInt32 temp_index = reader.ReadUInt32();
                if ((temp_index >= coach_index_mayor))
                {
                    coach_index_mayor = (uint)(temp_index + 1);
                }
                reader.BaseStream.Position += block - 4;
            }

            return coach_index_mayor;
        }

        public void applyCoach(int selectedIndex, MemoryStream unzlib, Coach allenatore, ref BinaryWriter writer)
        {
            int index = (block * selectedIndex);
            writer.BaseStream.Position = index;
            UInt32 coachId = allenatore.getId();
            UInt16 country = allenatore.getCountry();
            writer.BaseStream.Position = index + 5;
            UInt16 Segundo_byte_porbyte9 = allenatore.getByteLic();
            UInt16 Aux1;
            UInt16 new_byte9_and_secondbyte = 0;
            Aux1 = country;
            Aux1 = (ushort) (Aux1 & Convert.ToUInt32("111111111", 2));
            new_byte9_and_secondbyte = (ushort) (Aux1 | new_byte9_and_secondbyte);
            Aux1 = Segundo_byte_porbyte9;
            Aux1 = (ushort) (Aux1 & Convert.ToUInt32("1111111", 2));
            Aux1 = (ushort) (Aux1 << 8);
            new_byte9_and_secondbyte = (ushort) (Aux1 | new_byte9_and_secondbyte);

            country = new_byte9_and_secondbyte;

            writer.BaseStream.Position = index;
            writer.Write(coachId);
            writer.BaseStream.Position = index + 4;
            writer.Write(country);
            byte cero_cero = 0;
            writer.BaseStream.Position = index + 16;
            for (int i = 0; i <= 45; i++)
            {
                writer.Write(cero_cero);
            }
            writer.BaseStream.Position = index + 62;
            for (int i = 0; i <= 45; i++)
            {
                writer.Write(cero_cero);
            }

            writer.BaseStream.Position = (index + 16);
            writer.Write(allenatore.getJapName().ToCharArray());

            writer.BaseStream.Position = (index + 62);
            writer.Write(allenatore.getName().ToCharArray());
        }

        public void addCoach(ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
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

        public void save(string patch, MemoryStream memoryAllenatori, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryAllenatori.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Coach_toConsole(memoryAllenatori), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Coach_toConsole(memoryAllenatori), patch + PATH);
            }
        }
    }
}

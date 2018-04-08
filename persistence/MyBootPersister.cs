using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;

namespace DinoTem.ui
{
    public class MyBootPersister
    {
        //pes 18
        private static string PATH = "/Boots.bin";
        private static int block = 304;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Boots_toPc(memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo scarpe
            int bytesBoots = (int)memory1.Length;
            int boot = bytesBoots / block;

            if (boot == 0)
            {
                MessageBox.Show("No boots found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            string bootName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -100;

                int NumberOfRepetitions1 = Convert.ToInt32(boot);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    bootName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                    Form1._Form1.bootsBox.Items.Add(bootName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Boot loadBoot(int index, BinaryReader reader)
        {
            Boot boot = null;

            UInt16 bootId;
            byte order;
            string bootName;
            string color;
            string material;
            try
            {
                reader.BaseStream.Position = index * block + 204;
                bootName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                reader.BaseStream.Position = index * block;
                bootId = reader.ReadUInt16();

                reader.BaseStream.Position = index * block + 2;
                order = reader.ReadByte();

                reader.BaseStream.Position = index * block + 4;
                color = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                reader.BaseStream.Position = index * block + 104;
                material = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                boot = new Boot(bootId);
                boot.setName(bootName);
                boot.setOrder(order);
                boot.setColor(color);
                boot.setMaterial(material);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return boot;
        }

        public UInt16 findIndexBoot(MemoryStream memory1, BinaryReader reader)
        {
            UInt16 boot_index_mayor = 0;

            int bytesBoots = (int)memory1.Length;
            int boot = bytesBoots / block;

            for (int i = 0; (i <= (boot - 1)); i++)
            {
                UInt16 temp_index = reader.ReadUInt16();
                if ((temp_index >= boot_index_mayor))
                {
                    boot_index_mayor = (ushort)(temp_index + 1);
                }
                reader.BaseStream.Position += block - 2;
            }

            return boot_index_mayor;
        }

        public void applyBoot(int selectedIndex, MemoryStream unzlib, Boot scarpa, ref BinaryWriter writer)
        {
            int Index = (block * selectedIndex);
            writer.BaseStream.Position = Index;
            byte zero = 0;
            if ((Index == unzlib.Length))
            {
                for (int i = 0; i <= (block - 1); i++)
                {
                    writer.Write(zero);
                }

                writer.BaseStream.Position = Index;
            }

            UInt16 id = scarpa.getId();
            byte order = scarpa.getOrder();
            string color = scarpa.getColor();
            string bootName = scarpa.getName();
            string material = scarpa.getMaterial();
            writer.Write(id);
            writer.Write(order);
            writer.BaseStream.Position = (Index + 4);
            for (int i = 0; i <= 299; i++)
            {
                writer.Write(zero);
            }

            writer.BaseStream.Position = (Index + 4);
            writer.Write(color.ToCharArray());
            writer.BaseStream.Position = (Index + 104);
            writer.Write(material.ToCharArray());
            writer.BaseStream.Position = (Index + 204);
            writer.Write(bootName.ToCharArray());
        }

        public void addBoot(ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
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

        public void save(string patch, MemoryStream memoryBoot, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryBoot.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Boots_toConsole(memoryBoot), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.Boots_toConsole(memoryBoot), patch + PATH);
            }
        }
    }
}

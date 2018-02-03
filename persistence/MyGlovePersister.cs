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
   public class MyGlovePersister
    {
        //pes 18
        private static string PATH = "/Glove.bin";
        private static int block = 204;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Glove(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo guanti
            int bytesGloves = (int)memory1.Length;
            int glove = bytesGloves / block;

            string gloveName;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                int i1 = 0;
                long START2 = -100;

                int NumberOfRepetitions1 = Convert.ToInt32(glove);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    gloveName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                    Form1._Form1.glovesBox.Items.Add(gloveName);
                }
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public Glove loadGlove(int index, BinaryReader reader)
        {
            Glove guanto = null;

            UInt16 gloveId;
            byte order;
            string gloveName;
            string color;
            try
            {
                reader.BaseStream.Position = index * block + 104;
                gloveName = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                reader.BaseStream.Position = index * block;
                gloveId = reader.ReadUInt16();

                reader.BaseStream.Position = index * block + 2;
                order = reader.ReadByte();

                reader.BaseStream.Position = index * block + 4;
                color = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(98)).TrimEnd('\0');

                guanto = new Glove(gloveId);
                guanto.setName(gloveName);
                guanto.setOrder(order);
                guanto.setColor(color);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return guanto;
        }

        public void applyGlove(int selectedIndex, ref MemoryStream unzlib, Glove guanto, ref BinaryWriter writer)
        {
            int Index = (block * selectedIndex);
            writer.BaseStream.Position = Index;
            byte zero = 0;
            if (Index == unzlib.Length)
            {
                for (int i = 0; i <= block - 1; i++)
                {
                    writer.Write(zero);
                }

                writer.BaseStream.Position = Index;
            }

            UInt16 id = guanto.getId();
            byte order = guanto.getOrder();
            string color = guanto.getColor();
            string gloveName = guanto.getName();
            writer.Write(id);
            writer.Write(order);
            writer.BaseStream.Position = (Index + 4);
            for (int i = 0; i <= 199; i++)
            {
                writer.Write(zero);
            }

            writer.BaseStream.Position = (Index + 4);
            writer.Write(color.ToCharArray());
            writer.BaseStream.Position = (Index + 104);
            writer.Write(gloveName.ToCharArray());
        }

        public void save(string patch, ref MemoryStream memoryGlove, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryGlove.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Glove(ref memoryGlove);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryGlove, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Glove(ref memoryGlove);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryGlove, patch + PATH);
            }
        }
    }
}

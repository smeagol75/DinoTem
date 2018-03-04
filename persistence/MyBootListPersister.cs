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
    public class MyBootListPersister
    {
        private static string PATH = "/BootsList.bin";
        private static int block = 8;

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
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }

        public BootList loadBootList(UInt32 id, int bitRecognized, MemoryStream memory1, BinaryReader reader)
        {
            reader.BaseStream.Position = 0;
            UInt16 Boots_id = 0;
            if (bitRecognized == 0)
            {
                for (int i = 0; i <= memory1.Length / 8 - 1; i++)
                {
                    if (id == reader.ReadUInt32())
                    {
                        Boots_id = reader.ReadUInt16();
                        BootList list = new BootList(id);
                        list.setBootId(Boots_id);
                        return list;
                    }
                    else
                        reader.BaseStream.Position += 4;

                }
            }

            if (bitRecognized == 1 || bitRecognized == 2)
            {
                for (int i = 0; i <= memory1.Length / 8 - 1; i++)
                {
                    if (id == UnzlibZlibConsole.swaps.swap32(reader.ReadUInt32()))
                    {
                        Boots_id = UnzlibZlibConsole.swaps.swap16(reader.ReadUInt16());
                        BootList list = new BootList(id);
                        list.setBootId(Boots_id);
                        return list;
                    }
                    else
                        reader.BaseStream.Position += 4;
                }
            }

            return null;
        }

        public void applyBootList(BinaryReader reader, int bitRecognized, MemoryStream unzlib, BootList boot, ref BinaryWriter writer)
        {
            reader.BaseStream.Position = 0;
            if (bitRecognized == 0)
            {
                for (int i = 0; (i <= ((unzlib.Length / block) - 1)); i++)
                {
                    UInt32 Player_to_find = reader.ReadUInt32();
                    if ((boot.getPlayerId() == Player_to_find))
                    {
                        UInt16 Boot_to_save = boot.getBootId();
                        writer.Write(Boot_to_save);
                        break;
                    }
                    else
                        writer.BaseStream.Position += 4;

                }
            }

            if (bitRecognized == 1 || bitRecognized == 2)
            {
                for (int i = 0; (i <= ((unzlib.Length / block) - 1)); i++)
                {
                    UInt32 Player_to_find = UnzlibZlibConsole.swaps.swap32(reader.ReadUInt32());
                    if ((boot.getPlayerId() == Player_to_find))
                    {
                        UInt16 Boot_to_save = boot.getBootId();
                        writer.Write(UnzlibZlibConsole.swaps.swap16(Boot_to_save));
                        break;
                    }
                    else
                        writer.BaseStream.Position += 4;
                }
            }
        }

        public void save(string patch, ref MemoryStream memoryBall, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryBall.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryBall, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryBall, patch + PATH);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;

namespace DinoTem.persistence
{
    public class MyGloveListPersister
    {
        private static string PATH = "/GloveList.bin";
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

            int bytes = (int)memory1.Length;
            int glove = bytes / block;

            if (glove == 0)
            {
                MessageBox.Show("No gloves list found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

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

        public GloveList loadGloveList(UInt32 id, int bitRecognized, MemoryStream memory1, BinaryReader reader)
        {
            reader.BaseStream.Position = 0;
            UInt16 Gloves_id = 0;
            if (bitRecognized == 0)
            {
                for (int i = 0; i <= memory1.Length / block - 1; i++)
                {
                    if (id == reader.ReadUInt32())
                    {
                        Gloves_id = reader.ReadUInt16();
                        GloveList list = new GloveList(id);
                        list.setGloveId(Gloves_id);
                        return list;
                    }
                    else
                        reader.BaseStream.Position += 4;

                }
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                for (int i = 0; i <= memory1.Length / block - 1; i++)
                {
                    if (id == UnzlibZlibConsole.swaps.swap32(reader.ReadUInt32()))
                    {
                        Gloves_id = UnzlibZlibConsole.swaps.swap16(reader.ReadUInt16());
                        GloveList list = new GloveList(id);
                        list.setGloveId(Gloves_id);
                        return list;
                    }
                    else
                        reader.BaseStream.Position += 4;
                }
            }

            return null;
        }

        public void replaceGloveList(BinaryReader reader, int bitRecognized, MemoryStream unzlib, ref BinaryWriter writer, UInt32 oldPlayerId, UInt32 newPlayerId)
        {
            reader.BaseStream.Position = 0;
            if (bitRecognized == 0)
            {
                for (int i = 0; (i <= ((unzlib.Length / block) - 1)); i++)
                {
                    UInt32 Player_to_find = reader.ReadUInt32();
                    if (oldPlayerId == Player_to_find)
                    {
                        writer.BaseStream.Position -= 4;
                        writer.Write(newPlayerId);
                        break;
                    }
                    else
                        writer.BaseStream.Position += 4;
                }
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                for (int i = 0; (i <= ((unzlib.Length / block) - 1)); i++)
                {
                    UInt32 Player_to_find = UnzlibZlibConsole.swaps.swap32(reader.ReadUInt32());
                    if (oldPlayerId == Player_to_find)
                    {
                        writer.BaseStream.Position -= 4;
                        writer.Write(UnzlibZlibConsole.swaps.swap32(newPlayerId));
                        break;
                    }
                    else
                        writer.BaseStream.Position += 4;
                }
            }
        }

        public void applyGloveList(BinaryReader reader, int bitRecognized, MemoryStream unzlib, GloveList glove, ref BinaryWriter writer)
        {
            reader.BaseStream.Position = 0;
            if (bitRecognized == 0)
            {
                for (int i = 0; (i <= ((unzlib.Length / block) - 1)); i++)
                {
                    UInt32 Player_to_find = reader.ReadUInt32();
                    if ((glove.getPlayerId() == Player_to_find))
                    {
                        UInt16 Glove_to_save = glove.getGloveId();
                        writer.Write(Glove_to_save);
                        break;
                    }
                    else
                        writer.BaseStream.Position += 4;
                }
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                for (int i = 0; (i <= ((unzlib.Length / block) - 1)); i++)
                {
                    UInt32 Player_to_find = UnzlibZlibConsole.swaps.swap32(reader.ReadUInt32());
                    if ((glove.getPlayerId() == Player_to_find))
                    {
                        UInt16 Glove_to_save = glove.getGloveId();
                        writer.Write(UnzlibZlibConsole.swaps.swap16(Glove_to_save));
                        break;
                    }
                    else
                        writer.BaseStream.Position += 4;
                }
            }
        }

        public void addGloveList(UInt32 idPlayer, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            byte[] Player_block = { 0, 0, 0, 0 };

            byte[] end_of_file;
            reader.BaseStream.Position = 0;
            UInt32 Check_order = 0;
            for (int j = 0; j <= (memory1.Length / block) - 1; j++)
            {
                Check_order = reader.ReadUInt32();

                if (Check_order < idPlayer)
                {
                    reader.BaseStream.Position += 4;
                }
                else if (j == (memory1.Length / block) - 1)
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

                    writer.Write(idPlayer);
                    writer.Write(Player_block);
                    break;
                }
                //else if ((Check_order == idPlayer))
                //{
                //writer.Write(Player_Player_appareance_block);
                //break;
                //}
                else
                {
                    // leer hasta el final
                    reader.BaseStream.Position -= 4;
                    long Posicion_a_grabar = reader.BaseStream.Position;
                    long Tamanho_a_leer = (memory1.Length - Posicion_a_grabar);
                    end_of_file = reader.ReadBytes((int)Tamanho_a_leer);

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

                    writer.BaseStream.Position = Posicion_a_grabar;
                    writer.Write(idPlayer);
                    writer.Write(Player_block);
                    writer.Write(end_of_file);
                    break;
                }

            }
        }

        public void save(string patch, MemoryStream memoryBall, int bitRecognized)
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

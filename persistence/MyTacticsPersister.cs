using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using DinoTem.model;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18, pes 17
    public class MyTacticsPersister
    {
        private static string PATH = "/Tactics.bin";
        private static int block = 12;

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
                UnzlibZlibConsole.UnzlibZlibConsole.Tactics_toPc(ref memory1);
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

        public List<Tactics> loadTactics(UInt32 id, MemoryStream memory1, BinaryReader reader)
        {
            List<Tactics> list = new List<Tactics>();

            //Calcolo tattiche
            int bytesTactics = (int)memory1.Length;
            int tactics = bytesTactics / block;

            UInt32 Team_id;
            UInt16 tactics_id;
            UInt16 Frag_val1;
            UInt16 Frag_val2;
            UInt16 Frag_val3;
            UInt16 Frag_val4;
            UInt16 Frag_val5;
            UInt16 FRAG_VAL;

            reader.BaseStream.Position = 0;
            for (int i = 0; i <= (tactics - 1); i++)
            {
                Team_id = reader.ReadUInt32();
                if (Team_id == id)
                {
                    tactics_id = reader.ReadUInt16();
                    FRAG_VAL = reader.ReadUInt16();

                    Frag_val1 = (ushort) (FRAG_VAL >> 14); //defendingNumbers
                    Frag_val2 = (ushort) (FRAG_VAL << 2); //attackingNumbers
                    Frag_val2 = (ushort) (Frag_val2 >> 14);
                    Frag_val3 = (ushort) (FRAG_VAL << 4); //defensiveLine
                    Frag_val3 = (ushort) (Frag_val3 >> 12);
                    Frag_val4 = (ushort) (FRAG_VAL << 8); //supportRange
                    Frag_val4 = (ushort) (Frag_val4 >> 12);
                    Frag_val5 = (ushort) (FRAG_VAL << 12); // compactness;
                    Frag_val5 = (ushort) (Frag_val5 >> 12);
                    byte CHECBOXES_VAL = reader.ReadByte();

                    byte CHECK103 = (byte) (CHECBOXES_VAL >> 7); //buildUp
                    byte CHECK104 = (byte) (CHECBOXES_VAL << 1); //Defensive Style;
                    CHECK104 = (byte) (CHECK104 >> 7);
                    byte CHECK105 = (byte) (CHECBOXES_VAL << 2); //Attacking Area
                    CHECK105 = (byte) (CHECK105 >> 7);

                    byte CHECK106 = (byte) (CHECBOXES_VAL << 3); //Containment Area
                    CHECK106 = (byte) (CHECK106 >> 7);

                    byte CHECK107 = (byte) (CHECBOXES_VAL << 4); //Pressuring
                    CHECK107 = (byte) (CHECK107 >> 7);

                    byte CHECK108 = (byte) (CHECBOXES_VAL << 5); //Attacking Style
                    CHECK108 = (byte) (CHECK108 >> 7);

                    byte CHECK109 = (byte) (CHECBOXES_VAL << 6); //Fluid Formation
                    CHECK109 = (byte) (CHECK109 >> 7);

                    byte CHECK110 = (byte) (CHECBOXES_VAL << 7); //Positioning
                    CHECK110 = (byte) (CHECK110 >> 7);

                    Tactics temp = new Tactics(Team_id, tactics_id);
                    temp.setDefendingNumbers(Frag_val1);
                    temp.setAttackingNumbers(Frag_val2);
                    temp.setDefensiveLine((ushort)(Frag_val3 + 1));
                    temp.setSupportRange((ushort) (Frag_val4 + 1));
                    temp.setCompactness((ushort)(Frag_val5 + 1));
                    temp.setBuildUp(CHECK103);
                    temp.setDefensiveStyle(CHECK104);
                    temp.setAttackingArea(CHECK105);
                    temp.setContainmentArea(CHECK106);
                    temp.setPressuring(CHECK107);
                    temp.setAttackingStyle(CHECK108);
                    temp.setFluidFormation(CHECK109);
                    temp.setPositioning(CHECK110);
                    list.Add(temp);

                    reader.BaseStream.Position += 3;
                }
                else
                    reader.BaseStream.Position += 8;
            }

            return list;
        }

        public void applyTactics(BinaryReader reader, MemoryStream unzlib, Tactics tattica, ref BinaryWriter writer)
        {
            //Calcolo tattiche
            int bytesTactics = (int)unzlib.Length;
            int tactics = bytesTactics / block;

            UInt16 Frag_val1;
            UInt16 Frag_val2;
            UInt16 Frag_val3;
            UInt16 Frag_val4;
            UInt16 Frag_val5;
            UInt16 FRAG_VAL = 0;

            long START2 = -8;
            for (int i = 0; i <= (tactics - 1); i++)
            {
                START2 += block;
                unzlib.Seek(START2, SeekOrigin.Begin);
                if (tattica.getTacticsId() == reader.ReadUInt16())
                {
                    writer.BaseStream.Position = START2;
                    Frag_val1 = tattica.getDefendingNumbers();
                    Frag_val2 = tattica.getAttackingNumbers();
                    Frag_val3 = (ushort)(tattica.getDefensiveLine() - 1);
                    Frag_val4 = (ushort)(tattica.getSupportRange() - 1);
                    Frag_val5 = (ushort)(tattica.getCompactness() - 1);
                    UInt16 aux16 = (ushort)(Frag_val1 << 14);
                    FRAG_VAL = (ushort)(aux16 | FRAG_VAL);
                    aux16 = (ushort)(Frag_val2 << 12);
                    FRAG_VAL = (ushort)(aux16 | FRAG_VAL);
                    aux16 = (ushort)(Frag_val3 << 8);
                    FRAG_VAL = (ushort)(aux16 | FRAG_VAL);
                    aux16 = (ushort)(Frag_val4 << 4);
                    FRAG_VAL = (ushort)(aux16 | FRAG_VAL);
                    aux16 = Frag_val5;
                    FRAG_VAL = (ushort)(aux16 | FRAG_VAL);

                    byte CHECK103;
                    if (tattica.getBuildUp() == 1)
                    {
                        CHECK103 = 1;
                    }
                    else
                    {
                        CHECK103 = 0;
                    }

                    byte CHECK104;
                    if (tattica.getDefensiveStyle() == 1)
                    {
                        CHECK104 = 1;
                    }
                    else
                    {
                        CHECK104 = 0;
                    }

                    byte CHECK105;
                    if (tattica.getAttackingArea() == 1)
                    {
                        CHECK105 = 1;
                    }
                    else
                    {
                        CHECK105 = 0;
                    }

                    byte CHECK106;
                    if (tattica.getContainmentArea() == 1)
                    {
                        CHECK106 = 1;
                    }
                    else
                    {
                        CHECK106 = 0;
                    }

                    byte CHECK107;
                    if (tattica.getPressuring() == 1)
                    {
                        CHECK107 = 1;
                    }
                    else
                    {
                        CHECK107 = 0;
                    }

                    byte CHECK108;
                    if (tattica.getAttackingStyle() == 1)
                    {
                        CHECK108 = 1;
                    }
                    else
                    {
                        CHECK108 = 0;
                    }

                    byte CHECK109;
                    if (tattica.getFluidFormation() == 1)
                    {
                        CHECK109 = 1;
                    }
                    else
                    {
                        CHECK109 = 0;
                    }

                    byte CHECK110;
                    if (tattica.getPositioning() == 1)
                    {
                        CHECK110 = 1;
                    }
                    else
                    {
                        CHECK110 = 0;
                    }

                    byte AuxByte = (byte)(CHECK103 << 7);
                    byte Byte_GRAB = 0;
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = (byte)(CHECK104 << 6);
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = (byte)(CHECK105 << 5);
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = (byte)(CHECK106 << 4);
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = (byte)(CHECK107 << 3);
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = (byte)(CHECK108 << 2);
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = (byte)(CHECK109 << 1);
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);
                    AuxByte = CHECK110;
                    Byte_GRAB = (byte)(AuxByte | Byte_GRAB);

                    writer.BaseStream.Position += 2;
                    writer.Write(FRAG_VAL);
                    writer.Write(Byte_GRAB);
                }
            }
        }

        public void save(string patch, ref MemoryStream memoryTattiche, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryTattiche.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Tactics_toConsole(ref memoryTattiche);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryTattiche, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.Tactics_toConsole(ref memoryTattiche);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryTattiche, patch + PATH);
            }
        }

    }
}

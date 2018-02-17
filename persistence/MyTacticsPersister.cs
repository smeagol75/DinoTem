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
                    temp.setDefensiveLine(Frag_val3);
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

        public void applyTactics(int selectedIndex, ref MemoryStream unzlib, Tactics tattica, ref BinaryWriter writer)
        {
        }

        public void save(string patch, ref MemoryStream memoryTattiche, int bitRecognized)
        {
            // TODO Auto-generated method stub

        }

    }
}

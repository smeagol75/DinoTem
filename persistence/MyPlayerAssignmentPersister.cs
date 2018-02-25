using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;
using DinoTem.model;
using Team_Editor_Manager_New_Generation.persistence;
using DinoTem.ui;

namespace DinoTem.persistence
{
    //pes 18
    public class MyPlayerAssignmentPersister
    {
        private static string PATH = "/PlayerAssignment.bin";
        private static int block = 16;

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
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAssignment_toPc(ref memory1);
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

        public List<PlayerAssignment> loadPlayerTeam(UInt32 id, MemoryStream memory1, BinaryReader reader)
        {
            List<PlayerAssignment> list = new List<PlayerAssignment>();

            int bytesPlayer = (int)memory1.Length;
            int bloques_assig = bytesPlayer / block;

            reader.BaseStream.Position = 0;
            for (int i = 0; (i <= (bloques_assig - 1)); i++)
            {
                reader.BaseStream.Position += 8;
                UInt32 Team = reader.ReadUInt32();
                if ((Team == id))
                {
                    reader.BaseStream.Position -= 12;
                    UInt32 Index_PLASSIG = reader.ReadUInt32();
                    UInt32 Player_id = reader.ReadUInt32();
                    reader.BaseStream.Position += 4;
                    byte number = reader.ReadByte();

                    UInt16 Valor_partido = reader.ReadUInt16();
                    UInt32 CHECK46 = (ushort)(Valor_partido << 4);
                    CHECK46 = CHECK46 >> 15; //CAPTAIN

                    UInt32 CHECK47 = (ushort)(Valor_partido << 5);
                    CHECK47 = CHECK47 >> 15; //PENALTY_KICK

                    UInt32 CHECK48 = (ushort)(Valor_partido << 6);
                    CHECK48 = CHECK48 >> 15; //LONG_SHOT

                    UInt32 CHECK49 = (ushort)(Valor_partido << 7);
                    CHECK49 = CHECK49 >> 15; //LEFT_CK

                    UInt32 CHECK50 = (ushort)(Valor_partido << 8);
                    CHECK50 = CHECK50 >> 15; //SHORT_FOUL

                    UInt32 CHECK51 = (ushort) (Valor_partido << 9);
                    CHECK51 = (CHECK51 >> 15); //RIGHT_CK

                    UInt16 Order_in_Team = (ushort) (Valor_partido << 10);
                    Order_in_Team = (ushort) (Order_in_Team >> 10);

                    PlayerAssignment temp = new PlayerAssignment(Player_id, Team);
                    temp.setShirtNumber(number);
                    temp.setEntryId(Index_PLASSIG);
                    temp.setCaptain(CHECK46);
                    temp.setPenaltyKick(CHECK47);
                    temp.setLongShotLk(CHECK48);
                    temp.setLeftCkTk(CHECK49);
                    temp.setShortFoulFk(CHECK50);
                    temp.setRightCornerKick(CHECK51);
                    temp.setOrder(Order_in_Team);
                    list.Add(temp);

                    reader.BaseStream.Position += 1;
                }
                else
                    reader.BaseStream.Position += 4;

            }

            return list;
        }

        public List<UInt32> loadTeamId(UInt32 idPlayer, MemoryStream memory1, BinaryReader reader)
        {
            List<UInt32> list = new List<UInt32>();

            int bytesPlayer = (int)memory1.Length;
            int bloques_assig = bytesPlayer / block;

            reader.BaseStream.Position = 0;
            for (int i = 0; (i <= (bloques_assig - 1)); i++)
            {
                reader.BaseStream.Position += 4;
                UInt32 player = reader.ReadUInt32();
                if ((player == idPlayer))
                {
                    UInt32 Team = reader.ReadUInt32();

                    reader.BaseStream.Position += 4;

                    list.Add(Team);
                }
                else
                    reader.BaseStream.Position += 8;

            }

            return list;
        }

        public void applyPlayerA(MemoryStream unzlibPlayerAssign, BinaryReader reader, List<PlayerAssignment> pa, ref BinaryWriter writer)
        {
            int bytesPlayer = (int)unzlibPlayerAssign.Length;
            int bloques_assig = bytesPlayer / block;

            int k = 0;
            long START2 = -16;
            for (int i = 0; i <= (bloques_assig - 1); i++)
            {
                START2 += block;
                unzlibPlayerAssign.Seek(START2, SeekOrigin.Begin);

                if (k < pa.Count)
                    if (pa[k].getEntryId() == reader.ReadUInt32())
                    {
                        writer.BaseStream.Position = START2 + 4;

                        UInt32 New_ID = pa[k].getPlayerId();
                        UInt32 New_team = pa[k].getTeamId();
                        byte New_Number = pa[k].getShirtNumber();
                        writer.Write(New_ID);
                        writer.Write(New_team);
                        writer.Write(New_Number);
                        UInt16 Nuevo_Valor_16 = 0;
                        UInt16 Aux_16 = 0;
                        UInt16 CHECK_CAP = (ushort) pa[k].getCaptain();
                        UInt16 CHECK_PENAL = (ushort) pa[k].getPenaltyKick();
                        UInt16 CHECK_Long = (ushort) pa[k].getLongShotLk();
                        UInt16 CHECK_LCK = (ushort) pa[k].getLeftCkTk();
                        UInt16 CHECK_SHORT = (ushort) pa[k].getShortFoulFk();
                        UInt16 CHECK_RCK = (ushort) pa[k].getRightCornerKick();
                        UInt16 New_Order = pa[k].getOrder();
                        Aux_16 = CHECK_CAP;
                        Aux_16 = (ushort) (Aux_16 << 11);
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);
                        Aux_16 = CHECK_PENAL;
                        Aux_16 = (ushort) (Aux_16 << 10);
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);
                        Aux_16 = CHECK_Long;
                        Aux_16 = (ushort) (Aux_16 << 9);
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);
                        Aux_16 = CHECK_LCK;
                        Aux_16 = (ushort) (Aux_16 << 8);
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);
                        Aux_16 = CHECK_SHORT;
                        Aux_16 = (ushort) (Aux_16 << 7);
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);
                        Aux_16 = CHECK_RCK;
                        Aux_16 = (ushort) (Aux_16 << 6);
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);
                        Aux_16 = New_Order;
                        Nuevo_Valor_16 = (ushort) (Aux_16 | Nuevo_Valor_16);

                        writer.Write(Nuevo_Valor_16);

                        k++;
                    }
            }
        }

        public void save(string patch, ref MemoryStream memoryGicotori, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryGicotori.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAssignment_toConsole(ref memoryGicotori);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(memoryGicotori, patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.PlayerAssignment_toConsole(ref memoryGicotori);
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(memoryGicotori, patch + PATH);
            }
        }
    }
}

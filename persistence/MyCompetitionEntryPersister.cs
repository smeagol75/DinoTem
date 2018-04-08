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
    public class MyCompetitionEntryPersister
    {
        private static string PATH = "/CompetitionEntry.bin";
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
                UnzlibZlibConsole.UnzlibZlibConsole.CompetitionEntry_toPc(memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            int bytes = (int)memory1.Length;
            int comp = bytes / block;

            if (comp == 0)
            {
                MessageBox.Show("No competitions entry found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void loadCompetitionEntry(UInt32 Comp_Id, MemoryStream memory1, BinaryReader reader)
        {
            //Calcolo
            int bytes = (int)memory1.Length;
            int competitionEntry = bytes / block;

            Form1._Form1.DataGridView1.Rows.Clear();

            reader.BaseStream.Position = 0;
            for (int i = 0; (i <= (competitionEntry - 1)); i++)
            {
                reader.BaseStream.Position += 10;
                UInt32 Check_league = reader.ReadByte();
                if ((Check_league == Comp_Id))
                {
                    reader.BaseStream.Position -= 11;
                    UInt32 TeamId = reader.ReadUInt32();
                    UInt16 ValorUNK16 = reader.ReadUInt16();
                    UInt16 C_Entry_Index = reader.ReadUInt16();
                    reader.BaseStream.Position++;
                    byte Order = reader.ReadByte();

                    Form1._Form1.DataGridView1.Rows.Add(Order, "", C_Entry_Index, TeamId, ValorUNK16);
                    Form1._Form1.DataGridView1_orig.Rows.Add(Order, "", C_Entry_Index, TeamId, ValorUNK16);
                    reader.BaseStream.Position += 2;
                }
                else
                {
                    reader.BaseStream.Position++;
                }
            }

        }

        public void applyCompetitionEntry(int selectedIndex, ref MemoryStream unzlib, byte competitionId, ref BinaryReader reader, ref BinaryWriter writer)
        {
            if (Form1._Form1.DataGridView1.Rows.Count == Form1._Form1.DataGridView1_orig.Rows.Count) {
                foreach (DataGridViewRow row in Form1._Form1.DataGridView1.Rows)
                {
                    UInt16 new_c_entry_index = ushort.Parse(Form1._Form1.DataGridView1.Rows[row.Index].Cells[2].Value.ToString());
                    UInt32 new_team_Id = uint.Parse(Form1._Form1.DataGridView1.Rows[row.Index].Cells[3].Value.ToString());
                    reader.BaseStream.Position = 0;
                    reader.BaseStream.Position += 6;
                    UInt16 Old_c_entry_index = reader.ReadUInt16();
                    while (new_c_entry_index != Old_c_entry_index && (reader.BaseStream.Position < unzlib.Length)) {
                        reader.BaseStream.Position += 10;
                        Old_c_entry_index = reader.ReadUInt16();
                    }
        
                    reader.BaseStream.Position -= 8;
                    writer.BaseStream.Position = reader.BaseStream.Position;
                    writer.Write(new_team_Id);
                }
                //ListBox2.SelectedItem = ListBox2.SelectedItem;
            }
            else if (Form1._Form1.DataGridView1.Rows.Count < Form1._Form1.DataGridView1_orig.Rows.Count) {
                foreach (DataGridViewRow row in Form1._Form1.DataGridView1.Rows)
                {
                    UInt16 new_c_entry_index = ushort.Parse(Form1._Form1.DataGridView1.Rows[row.Index].Cells[2].Value.ToString());
                    UInt32 new_team_Id = uint.Parse(Form1._Form1.DataGridView1.Rows[row.Index].Cells[3].Value.ToString());
                    reader.BaseStream.Position = 6;
                    UInt16 Old_c_entry_index = reader.ReadUInt16();
                    while (new_c_entry_index != Old_c_entry_index && (reader.BaseStream.Position < unzlib.Length)) {
                        reader.BaseStream.Position += 10;
                        Old_c_entry_index = reader.ReadUInt16();
                    }
        
                    reader.BaseStream.Position -= 8;
                    writer.BaseStream.Position = reader.BaseStream.Position;
                    writer.Write(new_team_Id);
                    reader.BaseStream.Position += 8;
                }

                // Poner para borrar los elementos existentes anteriores
                MemoryStream unzlib_CompetitionEntry_aux = new MemoryStream();
                BinaryWriter Grabar_Competition_Entry_aux = new BinaryWriter(unzlib_CompetitionEntry_aux);
                for (int i = Form1._Form1.DataGridView1.Rows.Count; i  <= Form1._Form1.DataGridView1_orig.Rows.Count - 1; i++)
                {
                    reader.BaseStream.Position = 6;
                    UInt16 index_a_borrar = ushort.Parse(Form1._Form1.DataGridView1_orig.Rows[i].Cells[2].Value.ToString());
                    UInt16 Index_leido = reader.ReadUInt16();
                    while ((Index_leido != index_a_borrar))
                    {
                        reader.BaseStream.Position += 10;
                        Index_leido = reader.ReadUInt16();
                    }
        
                    reader.BaseStream.Position -= 2;
                    UInt16 cero = 0;
                    writer.BaseStream.Position = reader.BaseStream.Position;
                    writer.Write(cero);
                }
    
                reader.BaseStream.Position = 6;
                System.UInt32 Centry_bloques = (uint) (unzlib.Length / block);
                for (int i = 0; i  <= Centry_bloques - 1; i++)
                {
                    if (reader.ReadUInt16() != 0) {
                        reader.BaseStream.Position -= 8;
                        writer.BaseStream.Position = reader.BaseStream.Position;
                        Grabar_Competition_Entry_aux.Write(reader.ReadUInt32());
                        Grabar_Competition_Entry_aux.Write(reader.ReadUInt16());
                        Grabar_Competition_Entry_aux.Write(reader.ReadUInt16());
                        Grabar_Competition_Entry_aux.Write(reader.ReadByte());
                        Grabar_Competition_Entry_aux.Write(reader.ReadByte());
                        Grabar_Competition_Entry_aux.Write(reader.ReadByte());
                        Grabar_Competition_Entry_aux.Write(reader.ReadByte());
                        reader.BaseStream.Position += 6;
                    }
                    else {
                        reader.BaseStream.Position += 10;
                    }
                }
    
                unzlib.Close();
                unzlib = new MemoryStream();
                unzlib_CompetitionEntry_aux.Position = 0;
                unzlib_CompetitionEntry_aux.CopyTo(unzlib);
                unzlib_CompetitionEntry_aux.Close();
                reader = new BinaryReader(unzlib);
                writer = new BinaryWriter(unzlib);
                //ListBox2.SelectedItem = ListBox2.SelectedItem;
            }
            else {
                foreach (DataGridViewRow row in Form1._Form1.DataGridView1.Rows)
                {
                    UInt16 new_c_entry_index = ushort.Parse(Form1._Form1.DataGridView1.Rows[row.Index].Cells[2].Value.ToString());
                    UInt32 new_team_Id = uint.Parse(Form1._Form1.DataGridView1.Rows[row.Index].Cells[3].Value.ToString());
                    reader.BaseStream.Position = 6;
                    UInt16 Old_c_entry_index = reader.ReadUInt16();
                    while (new_c_entry_index != Old_c_entry_index && reader.BaseStream.Position < unzlib.Length - 10) {
                        reader.BaseStream.Position += 10;
                        Old_c_entry_index = reader.ReadUInt16();
                    }
        
                    reader.BaseStream.Position -= 8;
                    writer.BaseStream.Position = reader.BaseStream.Position;
                    writer.Write(new_team_Id);
                }
    
                // Poner para borrar los elementos existentes anteriores
                for (int i = Form1._Form1.DataGridView1_orig.Rows.Count; i  <= (Form1._Form1.DataGridView1.Rows.Count - 1); i++)
                {
                    writer.BaseStream.Position = unzlib.Length;
                    UInt16 Centry_Index = (ushort) Form1._Form1.DataGridView1.Rows[i].Cells[2].Value;
                    UInt32 Team_id = (uint) Form1._Form1.DataGridView1.Rows[i].Cells[3].Value;
                    byte Order = (byte) Form1._Form1.DataGridView1.Rows[i].Cells[0].Value;
                    byte League = competitionId;

                    UInt16 UNK = (ushort) Form1._Form1.DataGridView1.Rows[0].Cells[4].Value;
                    byte cero_byte = 0;
                    writer.Write(Team_id);
                    writer.Write(UNK);
                    writer.Write(Centry_Index);
                    writer.Write(cero_byte);
                    writer.Write(Order);
                    writer.Write(League);
                    writer.Write(cero_byte);
                }
                //ListBox2.SelectedItem = ListBox2.SelectedItem;
                // Poner para grabar los elementos que a�ades.
            }

        }

        public void save(string patch, MemoryStream memoryCompetition, int bitRecognized)
        {
            if (bitRecognized == 0)
            {
                //save zlib
                byte[] ss13 = Zlib18.ZLIBFile(memoryCompetition.ToArray());
                File.WriteAllBytes(patch + PATH, ss13);
            }
            else if (bitRecognized == 1)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_xbox_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.CompetitionEntry_toConsole(memoryCompetition), patch + PATH);
            }
            else if (bitRecognized == 2)
            {
                UnzlibZlibConsole.UnzlibZlibConsole.zlib_memstream_to_console_ps3_overwriting(UnzlibZlibConsole.UnzlibZlibConsole.CompetitionEntry_toConsole(memoryCompetition), patch + PATH);
            }
        }
    }
}

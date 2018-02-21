using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;

namespace DinoTem.persistence
{
    public class MyStadiumOrderInConfederationPersister
    {
        private static string PATH = "/StadiumOrderInConfederation.bin";
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
                UnzlibZlibConsole.UnzlibZlibConsole.StadiumOrderInConfederation_toPc(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo stadium order
            int bytes = (int)memory1.Length;
            int stadium = bytes / block;

            UInt16 order_index_in_conf;
            UInt16 order_id_in_conf;
            byte byte_in_conf;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                long START2 = -8;

                int NumberOfRepetitions1 = Convert.ToInt32(stadium);
                for (int i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);

                    reader.BaseStream.Position = START2;
                    order_id_in_conf = reader.ReadUInt16();
                    order_index_in_conf = reader.ReadUInt16();
                    byte_in_conf = reader.ReadByte();

                    Form1._Form1.DataGridView_stadium_order_in_conf.Rows.Add("", order_index_in_conf, order_id_in_conf, byte_in_conf);
                }

                writer = new BinaryWriter(memory1);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
        }
    }
}

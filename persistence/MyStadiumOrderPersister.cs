using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Team_Editor_Manager_New_Generation.zlibUnzlib;
using System.Windows.Forms;

namespace DinoTem.persistence
{
    public class MyStadiumOrderPersister
    {
        private static string PATH = "/StadiumOrder.bin";
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
                UnzlibZlibConsole.UnzlibZlibConsole.StadiumOrder_toPc(ref memory1);
            }

            return memory1;
        }

        public void load(string patch, int bitRecognized, ref MemoryStream memory1, ref BinaryReader reader, ref BinaryWriter writer)
        {
            memory1 = unzlib(patch, bitRecognized);

            //Calcolo stadium order
            int bytes = (int)memory1.Length;
            int stadiumOrder = bytes / block;

            UInt16 order_index;
            UInt16 order_id;
            UInt16 Order_frag;
            UInt16 negro7;
            UInt16 rojo2;
            UInt16 verde7;
            try
            {
                // Use the memory stream in a binary reader.
                reader = new BinaryReader(memory1);
                long START2 = -8;

                int NumberOfRepetitions1 = Convert.ToInt32(stadiumOrder);
                for (int i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {
                    START2 += block;
                    memory1.Seek(START2, SeekOrigin.Begin);

                    reader.BaseStream.Position = START2;
                    order_index = reader.ReadUInt16();
                    order_id = reader.ReadUInt16();
                    Order_frag = reader.ReadUInt16();

                    negro7 = (ushort) (Order_frag >> 9);
                    rojo2 = (ushort) (Order_frag << 7);
                    rojo2 = (ushort) (rojo2 >> 14);
                    verde7 = (ushort) (Order_frag << 9);
                    verde7 = (ushort) (verde7 >> 9);

                    Form1._Form1.DataGridView_stadium_order.Rows.Add("", order_index, order_id, negro7, rojo2, verde7);
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

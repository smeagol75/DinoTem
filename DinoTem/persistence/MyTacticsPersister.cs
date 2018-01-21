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

        public List<Tactics> load(string patch, int bitRecognized)
        {
            List<Tactics> tacticsList = new List<Tactics>();

            MemoryStream memory1 = unzlib(patch, bitRecognized);

            //calcolo Tactics
            // Create new FileInfo object and get the Length.
            int bytes_tattica = (int)memory1.Length;
            int tattica = bytes_tattica / 12;

            UInt16 connectionTacticId;
            UInt16 teamTacticId;
            try
            {
                // Use the memory stream in a binary reader.
                BinaryReader reader = new BinaryReader(memory1);
                int i1 = 0;

                long START = -12; //id
                long START2 = -8; //connection

                int NumberOfRepetitions1 = Convert.ToInt32(tattica);
                for (i1 = 1; i1 <= NumberOfRepetitions1; i1++)
                {

                    START += 12;
                    memory1.Seek(START, SeekOrigin.Begin);
                    teamTacticId = reader.ReadUInt16();

                    START2 += 12;
                    memory1.Seek(START2, SeekOrigin.Begin);
                    connectionTacticId = reader.ReadUInt16();

                    Tactics temp = new Tactics(teamTacticId, connectionTacticId);

                    tacticsList.Add(temp);
                }
                memory1.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            return tacticsList;
        }

        public void save(string patch, Controller controller, int bitRecognized)
        {
            // TODO Auto-generated method stub

        }

    }
}

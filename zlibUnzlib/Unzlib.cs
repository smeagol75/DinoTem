using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System.IO;

namespace Team_Editor_Manager_New_Generation.zlibUnzlib
{
    public static partial class Unzlib
    {
        //Unzlib
        public static byte[] unZLIBFilePC(byte[] filetounzlib)
        {
            byte[] outcome = { };
            try
            {
                Inflater inflater = new Inflater(false);
                int zzsize = Convert.ToInt32(BitConverter.ToUInt32(filetounzlib, 8));
                int eesize = Convert.ToInt32(BitConverter.ToUInt32(filetounzlib, 12));
                inflater.SetInput(filetounzlib, 16, zzsize);
                byte[] outdata = new byte[eesize];
                inflater.Inflate(outdata);
                outcome = outdata;
            }
            catch
            {

            }
            return outcome;
        }

        //Thanks to sxsxsx for part of Unzlib Code
    }
}
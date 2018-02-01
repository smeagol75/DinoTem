using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.ui
{
    class MyCoachPersister
    {
        internal void applyCoach(int index, ref System.IO.MemoryStream unzlibAllenatori, model.Coach allenatore, ref System.IO.BinaryWriter scriviAllenatori)
        {
            throw new NotImplementedException();
        }

        internal void load(string patch, int bitRecognized, ref System.IO.MemoryStream unzlibAllenatori, ref System.IO.BinaryReader leggiAllenatori, ref System.IO.BinaryWriter scriviAllenatori)
        {
            throw new NotImplementedException();
        }

        internal model.Coach loadCoach(int index, System.IO.BinaryReader leggiAllenatori)
        {
            throw new NotImplementedException();
        }

        internal void save(string patch, ref System.IO.MemoryStream unzlibAllenatori, int bitRecognized)
        {
            throw new NotImplementedException();
        }
    }
}

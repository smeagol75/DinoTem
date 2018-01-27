using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DinoTem.model;

namespace DinoTem.persistence
{
    public interface FmPersister
    {
        List<Fm> load(string patch);
    }
}

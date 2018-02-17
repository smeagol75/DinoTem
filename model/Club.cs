using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Club : Team
    {
        private string internalShortName;
	    private string latinScript;

        public Club(UInt32 id) : base(id)
        {
	    }

	    public string getInternalShortName() {
		    return internalShortName;
	    }

	    public void setInternalShortName(string internalShortName) {
            //internalShortName == null ||
		    if (internalShortName == "")
                throw new ArgumentException("Internal name not valid - " + base.getEnglish());
		
		    this.internalShortName = internalShortName;
	    }

	    public string getLatinScript() {
		    return latinScript;
	    }

	    public void setLatinScript(string latinScript) {
            //internalShortName == null || 
		    if (internalShortName == "")
                throw new ArgumentException("Latin script not valid - " + base.getEnglish());
		
		    this.latinScript = latinScript;
	    }

    }
}

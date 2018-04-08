using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class BallCondition
    {
        private UInt16 id;
        private UInt16 frag;
        private byte unknown;

        public BallCondition(UInt16 id)
        {
            if (id < 0 || id > 65535)
                throw new ArgumentException("Ball's id isn't valid: " + id);
    	
            this.id = id;
        }

        public UInt16 getId()
        {
            return this.id;
        }

        public UInt16 getFrag()
        {
            return this.frag;
        }

        public byte getUnknown()
        {
            return this.unknown;
        }

        public void setId(UInt16 id)
        {
            if (id < 0 || id > 65535)
                throw new ArgumentException("Ball's id isn't valid: " + id);
    	
            this.id = id;
        }

        public void setFrag(UInt16 frag)
        {
            if (frag < 0)
                this.frag = 0;
            if (frag > 65535)
                this.frag = 65535;
            //throw new ArgumentException("Ball's frag isn't valid - Id ball: " + getId());

            this.frag = frag;
        }

        public void setUnknown(byte unknown)
        {
    	    if (unknown < 0)
                this.unknown = 0;
            if (unknown > 255)
                this.unknown = 255;
            //throw new ArgumentException("Ball's byte isn't valid - Id ball: " + getId());
    	
            this.unknown = unknown;
        }
    }
}

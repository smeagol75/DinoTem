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
    	    if (id < 0)
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
    	    if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);
    	
            this.id = id;
        }

        public void setFrag(UInt16 frag)
        {
    	    if (frag < 0)
                throw new ArgumentException("Ball's frag isn't valid - Id ball: " + getId());

            this.frag = frag;
        }

        public void setUnknown(byte unknown)
        {
    	    if (unknown < 0)
                throw new ArgumentException("Ball's byte isn't valid - Id ball: " + getId());
    	
            this.unknown = unknown;
        }

        /*public override bool Equals(Object obj)
        {
            if (obj is BallCondition)
    	    {
                BallCondition c = (BallCondition)obj;
    		    return getId() == c.getId() && getUnknown() == c.getUnknown();
    	    }
            return false;
        }*/
    }
}

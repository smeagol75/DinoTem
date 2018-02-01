using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class BallCondition
    {
        private int id;
	    private int frag;
        private int unknown;

        public BallCondition(int id)
        {
    	    if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);
    	
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }
    
        public int getFrag()
        {
            return this.frag;
        }

        public int getUnknown()
        {
            return this.unknown;
        }

        public void setId(int id)
        {
    	    if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);
    	
            this.id = id;
        }
    
        public void setFrag(int frag)
        {
    	    if (frag < 0)
                throw new ArgumentException("Ball's frag isn't valid - Id ball: " + getId());

            this.frag = frag;
        }

        public void setUnknown(int unknown)
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

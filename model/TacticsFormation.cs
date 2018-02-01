using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class TacticsFormation
    {
        private int position;
        private int TeamTacticId;
        private int Y;
        private int X;
        private int byteFrag;

        public TacticsFormation(int TeamTacticId)
        {
            if (TeamTacticId < 0)
                throw new ArgumentException("Tactic's id isn't valid: " + TeamTacticId);

            this.TeamTacticId = TeamTacticId;
        }

        public int getPosition()
        {
            return this.position;
        }

        public int getTeamTacticId()
        {
            return this.TeamTacticId;
        }

        public int getY()
        {
            return this.Y;
        }

        public int getX()
        {
            return this.X;
        }

        public int getbyteFrag()
        {
            return this.byteFrag;
        }

        public void setPosition(int position)
        {
    	    if (position < 0)
                throw new ArgumentException("Position of player in the team isn't valid - id tactic: " + getTeamTacticId());
    	
            this.position = position;
        }

        public void setTeamTacticId(int TeamTacticId)
        {
    	    if (TeamTacticId < 0)
                throw new ArgumentException("Tactic's id isn't valid: " + TeamTacticId);
    	
            this.TeamTacticId = TeamTacticId;
        }

        public void setX(int X)
        {
    	    if (X < 0)
                throw new ArgumentException("Y position  isn't valid - id tactic: " + getTeamTacticId());

            this.X = X;
        }

        public void setY(int Y)
        {
    	    if (Y < 0)
                throw new ArgumentException("X position isn't valid - id tactic: " + getTeamTacticId());
    	
            this.Y = Y;
        }

        public void setbyteFrag(int byteFrag)
        {
    	    if (byteFrag < 0)
                throw new ArgumentException("Tactic's byteFrag isn't valid - id tactic: " + getTeamTacticId());
    	
            this.byteFrag = byteFrag;
        }
    
        public string getStringPosition()
        {
            string t = "";

            switch (getPosition())
            {
                case 0: t = "GK";
                    break;
                case 1: t = "CB";
                    break;
                case 2: t = "LB";
                    break;
                case 3: t = "RB";
                    break;
                case 4: t = "DMF";
                    break;
                case 5: t = "CMF";
                    break;
                case 6: t = "LMF";
                    break;
                case 7: t = "AMF";
                    break;
                case 8: t = "RMF";
                    break;
                case 9: t = "LWF";
                    break;
                case 10: t = "RWF";
                    break;
                case 11: t = "SS";
                    break;
                case 12: t = "CF";
                    break;
            }
            return t;
        }

        /*public override bool Equals(Object obj)
        {
            if (obj is TacticsFormation)
    	    {
                TacticsFormation c = (TacticsFormation) obj;
    		    return getTeamTacticId() == c.getTeamTacticId();
    	    }
            return false;
        }*/
    }
}

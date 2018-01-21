using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Tactics
    {
        private int teamID, tacticsID;
	
	    public Tactics(int teamID, int tacticsID) {
		    if (teamID < 0)
                throw new ArgumentException("Tactic's team id isn't valid: " + teamID);
		    if (tacticsID < 0)
                throw new ArgumentException("Tactic id isn't valid: " + tacticsID);
		
		    this.teamID = teamID;
		    this.tacticsID = tacticsID;
	    }
	
	    public int getTacticsID() {
		    return this.tacticsID;
	    }
	
	    public int getTeamID() {
		    return this.teamID;
	    }
	
	    public void setTeamID(int teamID) {
		    if (teamID < 0)
                throw new ArgumentException("Tactic's team id isn't valid: " + teamID);
		
		    this.teamID = teamID;
	    }
	
	    public void setTacticsID(int tacticsID) {
		    if (tacticsID < 0)
                throw new ArgumentException("Tactic id isn't valid: " + teamID);
		
		    this.tacticsID = tacticsID;
	    }

        public override bool Equals(Object obj)
        {
            if (obj is Tactics)
		    {
                Tactics c = (Tactics) obj;
			    return getTacticsID() == c.getTacticsID() && getTeamID() == c.getTeamID();
		    }
		    return false;
	    }
    }
}

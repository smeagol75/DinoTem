using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Tactics
    {
        private int teamId, tacticsId;
	
	    public Tactics(int teamId, int tacticsId) {
            if (teamId < 0)
                throw new ArgumentException("Tactic's team id isn't valid: " + teamId);
            if (tacticsId < 0)
                throw new ArgumentException("Tactic id isn't valid: " + tacticsId);

            this.teamId = teamId;
            this.tacticsId = tacticsId;
	    }
	
	    public int getTacticsId() {
		    return this.tacticsId;
	    }
	
	    public int getTeamId() {
		    return this.teamId;
	    }
	
	    public void setTeamId(int teamId) {
            if (teamId < 0)
                throw new ArgumentException("Tactic's team id isn't valid: " + teamId);

            this.teamId = teamId;
	    }
	
	    public void setTacticsId(int tacticsId) {
            if (tacticsId < 0)
                throw new ArgumentException("Tactic id isn't valid: " + teamId);

            this.tacticsId = tacticsId;
	    }

        /*public override bool Equals(Object obj)
        {
            if (obj is Tactics)
		    {
                Tactics c = (Tactics) obj;
			    return getTacticsID() == c.getTacticsID() && getTeamID() == c.getTeamID();
		    }
		    return false;
	    }*/
    }
}

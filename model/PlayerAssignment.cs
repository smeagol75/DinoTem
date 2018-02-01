using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class PlayerAssignment
    {
        private int entryId = 0;
        private long playerId;
        private int teamId;
        private int shirtNumber = 0;
        private bool captain = false;
        private bool penaltyKick = false;
        private bool longShotLk = false;
        private bool leftCkTk = false;
        private bool shortFoulFk = false;
        private bool rightCornerKick = false;
        private int order = 0;

        public PlayerAssignment(long playerId, int teamId)
        {
    	    if (playerId < 0)
                throw new ArgumentException("Player's player id isn't valid: " + playerId);
    	    if (teamId < 0)
                throw new ArgumentException("Player's team id isn't valid: " + teamId);
    	
            this.playerId = playerId;
            this.teamId = teamId;
        }

        public int getEntryId()
        {
            return this.entryId;
        }

        public long getPlayerId()
        {
            return this.playerId;
        }

        public int getTeamId()
        {
            return this.teamId;
        }
    
        public bool getCaptain()
        {
            return this.captain;
        }

        public bool getPenaltyKick()
        {
            return this.penaltyKick;
        }

        public bool getLongShotLk()
        {
            return this.longShotLk;
        }

        public bool getLeftCkTk()
        {
            return this.leftCkTk;
        }

        public bool getShortFoulFk()
        {
            return this.shortFoulFk;
        }

        public bool getRightCornerKick()
        {
            return this.rightCornerKick;
        }

        public int getShirtNumber()
        {
            return this.shirtNumber;
        }

        public int getOrder()
        {
            return this.order;
        }

        public void setEntryId(int entryId)
        {
    	    if (entryId < 0)
                throw new ArgumentException("Entry id isn't valid: " + entryId);
    	
            this.entryId = entryId;
        }

        public void setPlayerId(long playerId)
        {
    	    if (playerId < 0)
                throw new ArgumentException("Player's id isn't valid: " + playerId);
    	
            this.playerId = playerId;
        }

        public void setTeamId(int teamId)
        {
    	    if (teamId < 0)
                throw new ArgumentException("Team's id isn't valid: " + teamId);
    	
            this.teamId = teamId;
        }

        public void setCaptain(bool captain)
        {
            this.captain = captain;
        }

        public void setPenaltyKick(bool penaltyKick)
        {
            this.penaltyKick = penaltyKick;
        }

        public void setLongShotLk(bool longShotLk)
        {
            this.longShotLk = longShotLk;
        }

        public void setLeftCkTk(bool leftCkTk)
        {
            this.leftCkTk = leftCkTk;
        }

        public void setShortFoulFk(bool shortFoulFk)
        {
            this.shortFoulFk = shortFoulFk;
        }

        public void setRightCornerKick(bool rightCornerKick)
        {
            this.rightCornerKick = rightCornerKick;
        }

        public void setShirtNumber(int shirtNumber)
        {
    	    if (shirtNumber < 0)
                throw new ArgumentException("Player's shirt number isn't valid: " + shirtNumber);
    	
            this.shirtNumber = shirtNumber;
        }

        public void setOrder(int order)
        {
    	    if (order < 0)
                throw new ArgumentException("Player's order in team isn't valid: " + order);
    	
            this.order = order;
        }

        /*public override bool Equals(Object obj)
        {
            if (obj is PlayerAssignment)
    	    {
                PlayerAssignment c = (PlayerAssignment) obj;
    		    return getPlayerId() == c.getPlayerId() && getTeamId() == c.getTeamId();
    	    }
    	    return false;
        }*/
    }
}

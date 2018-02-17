using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class PlayerAssignment
    {
        private UInt32 entryId = 0;
        private UInt32 playerId;
        private UInt32 teamId;
        private byte shirtNumber = 0;
        private UInt32 captain = 0;
        private UInt32 penaltyKick = 0;
        private UInt32 longShotLk = 0;
        private UInt32 leftCkTk = 0;
        private UInt32 shortFoulFk = 0;
        private UInt32 rightCornerKick = 0;
        private UInt16 order = 0;

        public PlayerAssignment(UInt32 playerId, UInt32 teamId)
        {
    	    if (playerId < 0)
                throw new ArgumentException("Player's player id isn't valid: " + playerId);
    	    if (teamId < 0)
                throw new ArgumentException("Player's team id isn't valid: " + teamId);
    	
            this.playerId = playerId;
            this.teamId = teamId;
        }

        public UInt32 getEntryId()
        {
            return this.entryId;
        }

        public UInt32 getPlayerId()
        {
            return this.playerId;
        }

        public UInt32 getTeamId()
        {
            return this.teamId;
        }

        public UInt32 getCaptain()
        {
            return this.captain;
        }

        public UInt32 getPenaltyKick()
        {
            return this.penaltyKick;
        }

        public UInt32 getLongShotLk()
        {
            return this.longShotLk;
        }

        public UInt32 getLeftCkTk()
        {
            return this.leftCkTk;
        }

        public UInt32 getShortFoulFk()
        {
            return this.shortFoulFk;
        }

        public UInt32 getRightCornerKick()
        {
            return this.rightCornerKick;
        }

        public byte getShirtNumber()
        {
            return this.shirtNumber;
        }

        public UInt16 getOrder()
        {
            return this.order;
        }

        public void setEntryId(UInt32 entryId)
        {
    	    if (entryId < 0)
                throw new ArgumentException("Entry id isn't valid: " + entryId);
    	
            this.entryId = entryId;
        }

        public void setPlayerId(UInt32 playerId)
        {
    	    if (playerId < 0)
                throw new ArgumentException("Player's id isn't valid: " + playerId);
    	
            this.playerId = playerId;
        }

        public void setTeamId(UInt32 teamId)
        {
    	    if (teamId < 0)
                throw new ArgumentException("Team's id isn't valid: " + teamId);
    	
            this.teamId = teamId;
        }

        public void setCaptain(UInt32 captain)
        {
            this.captain = captain;
        }

        public void setPenaltyKick(UInt32 penaltyKick)
        {
            this.penaltyKick = penaltyKick;
        }

        public void setLongShotLk(UInt32 longShotLk)
        {
            this.longShotLk = longShotLk;
        }

        public void setLeftCkTk(UInt32 leftCkTk)
        {
            this.leftCkTk = leftCkTk;
        }

        public void setShortFoulFk(UInt32 shortFoulFk)
        {
            this.shortFoulFk = shortFoulFk;
        }

        public void setRightCornerKick(UInt32 rightCornerKick)
        {
            this.rightCornerKick = rightCornerKick;
        }

        public void setShirtNumber(byte shirtNumber)
        {
    	    if (shirtNumber < 0)
                throw new ArgumentException("Player's shirt number isn't valid: " + shirtNumber);
    	
            this.shirtNumber = shirtNumber;
        }

        public void setOrder(UInt16 order)
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

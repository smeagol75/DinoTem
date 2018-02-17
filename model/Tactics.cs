using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Tactics
    {
        private UInt32 teamId;
        private UInt16 tacticsId;
        private UInt16 compactness;
        private UInt16 supportRange;
        private UInt16 defensiveLine;
        private UInt16 attackingNumbers;
        private UInt16 defendingNumbers;
        private byte positioning;
        private byte fluidFormation;
        private byte attackingStyle;
        private byte pressuring;
        private byte containmentArea;
        private byte attackingArea;
        private byte defensiveStyle;
        private byte buildUp;

        public Tactics(UInt32 teamId, UInt16 tacticsId)
        {
            if (teamId < 0)
                throw new ArgumentException("Tactic's team id isn't valid: " + teamId);
            if (tacticsId < 0)
                throw new ArgumentException("Tactic id isn't valid: " + tacticsId);

            this.teamId = teamId;
            this.tacticsId = tacticsId;
	    }

        public UInt16 getTacticsId()
        {
		    return this.tacticsId;
	    }

        public UInt32 getTeamId()
        {
		    return this.teamId;
	    }

        public UInt16 getCompactness()
        {
            return this.compactness;
        }

        public UInt16 getSupportRange()
        {
            return this.supportRange;
        }

        public UInt16 getDefensiveLine()
        {
            return this.defensiveLine;
        }

        public UInt16 getAttackingNumbers()
        {
            return this.attackingNumbers;
        }

        public UInt16 getDefendingNumbersAttackingNumbers()
        {
            return this.defendingNumbers;
        }

        public byte getPositioning()
        {
            return this.positioning;
        }

        public byte getFluidFormation()
        {
            return this.fluidFormation;
        }

        public byte getAttackingStyle()
        {
            return this.attackingStyle;
        }

        public byte getPressuring()
        {
            return this.pressuring;
        }

        public byte getContainmentArea()
        {
            return this.containmentArea;
        }

        public byte getAttackingArea()
        {
            return this.attackingArea;
        }

        public byte getDefensiveStyle()
        {
            return this.defensiveStyle;
        }

        public byte getBuildUp()
        {
            return this.buildUp;
        }

        public void setTeamId(UInt32 teamId)
        {
            if (teamId < 0)
                throw new ArgumentException("Tactic's team id isn't valid: " + teamId);

            this.teamId = teamId;
	    }

        public void setTacticsId(UInt16 tacticsId)
        {
            if (tacticsId < 0)
                throw new ArgumentException("Tactic id isn't valid: " + teamId);

            this.tacticsId = tacticsId;
	    }

        public void setCompactness(UInt16 compactness)
        {
            if (compactness < 0)
                throw new ArgumentException("Compactness isn't valid - team id: " + teamId);

            this.compactness = compactness;
        }

        public void setSupportRange(UInt16 supportRange)
        {
            if (supportRange < 0)
                throw new ArgumentException("Support range isn't valid - team id: " + teamId);

            this.supportRange = supportRange;
        }

        public void setDefensiveLine(UInt16 defensiveLine)
        {
            if (defensiveLine < 0)
                throw new ArgumentException("Support range isn't valid - team id: " + teamId);

            this.defensiveLine = defensiveLine;
        }

        public void setAttackingNumbers(UInt16 attackingNumbers)
        {
            if (attackingNumbers < 0)
                throw new ArgumentException("Attacking numbers isn't valid - team id: " + teamId);

            this.attackingNumbers = attackingNumbers;
        }

        public void setDefendingNumbers(UInt16 defendingNumbers)
        {
            if (defendingNumbers < 0)
                throw new ArgumentException("Defending numbers isn't valid - team id: " + teamId);

            this.defendingNumbers = defendingNumbers;
        }

        public void setPositioning(byte positioning)
        {
            if (positioning < 0)
                throw new ArgumentException("Positioning isn't valid - team id: " + teamId);

            this.positioning = positioning;
        }

        public void setFluidFormation(byte fluidFormation)
        {
            if (fluidFormation < 0)
                throw new ArgumentException("Strategy type isn't valid - team id: " + teamId);

            this.fluidFormation = fluidFormation;
        }

        public void setAttackingStyle(byte attackingStyle)
        {
            if (attackingStyle < 0)
                throw new ArgumentException("Attacking styles isn't valid - team id: " + teamId);

            this.attackingStyle = attackingStyle;
        }

        public void setPressuring(byte pressuring)
        {
            if (pressuring < 0)
                throw new ArgumentException("Pressuring isn't valid - team id: " + teamId);

            this.pressuring = pressuring;
        }

        public void setContainmentArea(byte containmentArea)
        {
            if (containmentArea < 0)
                throw new ArgumentException("Containment area isn't valid - team id: " + teamId);

            this.containmentArea = containmentArea;
        }

        public void setAttackingArea(byte attackingArea)
        {
            if (attackingArea < 0)
                throw new ArgumentException("Attacking area isn't valid - team id: " + teamId);

            this.attackingArea = attackingArea;
        }

        public void setDefensiveStyle(byte defensiveStyle)
        {
            if (defensiveStyle < 0)
                throw new ArgumentException("Defensive styles isn't valid - team id: " + teamId);

            this.defensiveStyle = defensiveStyle;
        }

        public void setBuildUp(byte buildUp)
        {
            if (buildUp < 0)
                throw new ArgumentException("Build up isn't valid - team id: " + teamId);

            this.buildUp = buildUp;
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

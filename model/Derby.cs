using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class Derby
    {
        private UInt32 team1DerbyId;
        private UInt32 team2DerbyId;
        private UInt16 fragVal1;
        private UInt16 fragVal2;
        private UInt16 fragVal3;
        private UInt16 fragVal4;
        private UInt16 fragVal;

        public Derby()
        {
        }

        public UInt32 getTeam1DerbyId()
        {
            return this.team1DerbyId;
        }

        public UInt32 getTeam2DerbyId()
        {
            return this.team2DerbyId;
        }

        public UInt16 getFragVal1()
        {
            return this.fragVal1;
        }

        public UInt16 getFragVal2()
        {
            return this.fragVal2;
        }

        public UInt16 getFragVal3()
        {
            return this.fragVal3;
        }

        public UInt16 getFragVal4()
        {
            return this.fragVal4;
        }

        public UInt16 getFragVal()
        {
            return this.fragVal;
        }

        public void setTeam1DerbyId(UInt32 team1DerbyId)
        {
            if (team1DerbyId < 0)
                this.team1DerbyId = 0;
            if (team1DerbyId > 65535)
                this.team1DerbyId = 65535;
            //throw new ArgumentException("team1 derby id isn't valid: " + team1DerbyId);

            this.team1DerbyId = team1DerbyId;
        }

        public void setTeam2DerbyId(UInt32 team2DerbyId)
        {
            if (team2DerbyId < 0)
                this.team2DerbyId = 0;
            if (team2DerbyId > 65535)
                this.team2DerbyId = 65535;
            //throw new ArgumentException("team2 derby id isn't valid: " + team2DerbyId);

            this.team2DerbyId = team2DerbyId;
        }

        public void setFragVal1(UInt16 fragVal1)
        {
            if (fragVal1 < 0)
                this.fragVal1 = 0;
            //throw new ArgumentException("frag val1 isn't valid: " + fragVal1);

            this.fragVal1 = fragVal1;
        }

        public void setFragVal2(UInt16 fragVal2)
        {
            if (fragVal2 < 0)
                this.fragVal2 = 0;
            //throw new ArgumentException("frag val2 isn't valid: " + fragVal2);

            this.fragVal2 = fragVal2;
        }

        public void setFragVal3(UInt16 fragVal3)
        {
            if (fragVal3 < 0)
                this.fragVal3 = 0;
            //throw new ArgumentException("frag val3 isn't valid: " + fragVal3);

            this.fragVal3 = fragVal3;
        }

        public void setFragVal4(UInt16 fragVal4)
        {
            if (fragVal4 < 0)
                this.fragVal4 = 0;
            //throw new ArgumentException("frag val4 isn't valid: " + fragVal4);

            this.fragVal4 = fragVal4;
        }

        public void setFragVal(UInt16 fragVal)
        {
            if (fragVal < 0)
                this.fragVal = 0;
            //throw new ArgumentException("frag val isn't valid: " + fragVal);

            this.fragVal = fragVal;
        }

    }
}

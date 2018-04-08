using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class Competition
    {
        private UInt32 CHECK54;
        private UInt32 CHECK55;
        private UInt32 CHECK56;
        private UInt32 CHECK57;
        private UInt32 CHECK58;
        private UInt32 CHECK59;
        private UInt32 CHECK60;
        private UInt32 licensed;
        private UInt32 type;
        private UInt32 secondDivision;
        private UInt32 id;
        private UInt32 UNK_3;
        private UInt32 zone;

        public Competition(UInt32 competitionId)
        {
            if (competitionId < 0)
                throw new ArgumentException("Competition's id isn't valid: " + competitionId);

            this.id = competitionId;
	    }

        public UInt32 getId()
        {
            return this.id;
        }

        public UInt32 getZone()
        {
            return this.zone;
        }

        public UInt32 getUnk3()
        {
            return this.UNK_3;
        }

        public UInt32 getSecondDivision()
        {
            return this.secondDivision;
        }

        public UInt32 getType()
        {
            return this.type;
        }

        public UInt32 getLicensed()
        {
            return this.licensed;
        }

        public UInt32 getCheck60()
        {
            return this.CHECK60;
        }

        public UInt32 getCheck59()
        {
            return this.CHECK59;
        }

        public UInt32 getCheck58()
        {
            return this.CHECK58;
        }

        public UInt32 getCheck57()
        {
            return this.CHECK57;
        }

        public UInt32 getCheck56()
        {
            return this.CHECK56;
        }

        public UInt32 getCheck55()
        {
            return this.CHECK55;
        }

        public UInt32 getCheck54()
        {
            return this.CHECK54;
        }

        public void setTeamId(UInt32 id)
        {
            if (id < 0 || id > 65535)
                throw new ArgumentException("Competition's id isn't valid: " + id);

            this.id = id;
        }

        public void setZone(UInt32 zone)
        {
            if (zone < 0)
                this.zone = 0;
            if (zone > 7)
                this.zone = 7;
            //throw new ArgumentException("zone isn't valid - id competition: " + id);

            this.zone = zone;
        }

        public void setUnk3(UInt32 UNK_3)
        {
            if (UNK_3 < 0)
                throw new ArgumentException("unk3 isn't valid - id competition: " + id);

            this.UNK_3 = UNK_3;
        }

        public void setSecondDivision(UInt32 secondDivision)
        {
            if (secondDivision < 0)
                throw new ArgumentException("second division isn't valid - id competition: " + id);

            this.secondDivision = secondDivision;
        }

        public void setType(UInt32 type)
        {
            if (type < 0)
                throw new ArgumentException("type isn't valid - id competition: " + id);

            this.type = type;
        }

        public void setLicensed(UInt32 licensed)
        {
            if (licensed < 0)
                throw new ArgumentException("licensed isn't valid - id competition: " + id);

            this.licensed = licensed;
        }

        public void setCheck60(UInt32 CHECK60)
        {
            if (CHECK60 < 0)
                throw new ArgumentException("check60 isn't valid - id competition: " + id);

            this.CHECK60 = CHECK60;
        }

        public void setCheck59(UInt32 CHECK59)
        {
            if (CHECK59 < 0)
                throw new ArgumentException("check59 isn't valid - id competition: " + id);

            this.CHECK59 = CHECK59;
        }

        public void setCheck58(UInt32 CHECK58)
        {
            if (CHECK58 < 0)
                throw new ArgumentException("check58 isn't valid - id competition: " + id);

            this.CHECK58 = CHECK58;
        }

        public void setCheck57(UInt32 CHECK57)
        {
            if (CHECK57 < 0)
                throw new ArgumentException("check57 isn't valid - id competition: " + id);

            this.CHECK57 = CHECK57;
        }

        public void setCheck56(UInt32 CHECK56)
        {
            if (CHECK56 < 0)
                throw new ArgumentException("check56 isn't valid - id competition: " + id);

            this.CHECK56 = CHECK56;
        }

        public void setCheck55(UInt32 CHECK55)
        {
            if (CHECK55 < 0)
                throw new ArgumentException("check55 isn't valid - id competition: " + id);

            this.CHECK55 = CHECK55;
        }

        public void setCheck54(UInt32 CHECK54)
        {
            if (CHECK54 < 0)
                throw new ArgumentException("check54 isn't valid - id competition: " + id);

            this.CHECK54 = CHECK54;
        }

    }
}

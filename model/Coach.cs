using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class Coach
    {
        private UInt32 id;
        private UInt16 country;
        private byte byteLic;
        private string name;
        private string japName;
        UInt16 coachLicId;

        public Coach(UInt32 id)
        {
            if (id < 0)
                throw new ArgumentException("Coach's id isn't valid: " + id);

            this.id = id;
        }

        public UInt32 getId()
        {
            return this.id;
        }

        public UInt16 getCoachLicId()
        {
            return this.coachLicId;
        }

        public UInt16 getCountry()
        {
            return this.country;
        }

        public byte getByteLic()
        {
            return this.byteLic;
        }

        public string getName()
        {
            return this.name;
        }

        public string getJapName()
        {
            return this.japName;
        }

        public void setId(UInt32 id)
        {
            if (id < 0)
                throw new ArgumentException("Coach's id isn't valid: " + id);

            this.id = id;
        }

        public void setCountry(UInt16 country)
        {
            if (country < 0)
                throw new ArgumentException("Coach's nationality isn't valid - Id coach: " + getId());

            this.country = country;
        }

        public void setCoachLicId(UInt16 coachLicId)
        {
            if (coachLicId < 0)
                throw new ArgumentException("Coach's license id isn't valid - Id coach: " + getId());

            this.coachLicId = coachLicId;
        }

        public void setByteLic(byte byteLic)
        {
            if (byteLic < 0)
                throw new ArgumentException("Coach's byte license isn't valid - Id coach: " + getId());

            this.byteLic = byteLic;
        }

        public void setName(string name)
        {
            if (name == null || name == "")
                throw new ArgumentException("Coach's name isn't valid - Id coach: " + getId());

            this.name = name;
        }

        public void setJapName(string japName)
        {
            if (japName == null || japName == "")
                throw new ArgumentException("Coach's name isn't valid - Id coach: " + getId());

            this.japName = japName;
        }
    }
}

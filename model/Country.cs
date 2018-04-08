using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Country
    {
        private UInt32 id;
        private string name;
        private string shortName;
        private UInt32 violet;
        private UInt32 blue;
        private UInt32 green;
        private byte unk;
        private byte zone;

        public Country(UInt32 id)
        {
    	    if (id < 0)
                throw new ArgumentException("Country's id isn't valid: " + id);
    	
            this.id = id;
        }

        public UInt32 getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public string getShortName()
        {
            return this.shortName;
        }

        public UInt32 getViolet()
        {
            return this.violet;
        }

        public UInt32 getBlue()
        {
            return this.blue;
        }

        public UInt32 getGreen()
        {
            return this.green;
        }

        public byte getUnk()
        {
            return this.unk;
        }

        public byte getZone()
        {
            return this.zone;
        }

        public void setId(UInt32 id)
        {
    	    if (id < 0)
                throw new ArgumentException("Country's id isn't valid: " + id);
    	
            this.id = id;
        }

        public void setViolet(UInt32 violet)
        {
            if (violet < 0)
                throw new ArgumentException("Country's violet isn't valid: " + id);

            this.violet = violet;
        }

        public void setBlue(UInt32 blue)
        {
            if (blue < 0)
                throw new ArgumentException("Country's blue isn't valid: " + id);

            this.blue = blue;
        }

        public void setGreen(UInt32 green)
        {
            if (green < 0)
                throw new ArgumentException("Country's green isn't valid: " + id);

            this.green = green;
        }

        public void setUnk(byte unk)
        {
            if (unk < 0)
                throw new ArgumentException("Country's name isn't valid - Id country: " + getId());

            this.unk = unk;
        }

        public void setZone(byte zone)
        {
            if (zone < 0)
                this.zone = 0;
            if (zone > 7)
                this.zone = 7;
            //throw new ArgumentException("Country's name isn't valid - Id country: " + getId());

            this.zone = zone;
        }

        public void setName(string name)
        {
    	    if (name == null || name == "")
                this.shortName = "Country without name";
            //throw new ArgumentException("Country's name isn't valid - Id country: " + getId());
    	
            this.name = name;
        }

        public void setShortName(string shortName)
        {
            if (shortName == null || shortName == "")
                this.shortName = "UNK";
            //throw new ArgumentException("Country's short name isn't valid - Id country: " + getId());

            this.shortName = shortName;
        }

        private string stringContinent(int i)
        {
            if (i == 2)
                return "EUROPE";
            else if (i == 3)
                return "ASIA";
            if (i == 4)
                return "SOUTH AMERICA";
            else if (i == 5)
                return "AFRICA";
            else if (i == 6)
                return "NORTH AMERICA";
            else if (i == 7)
                return "OCEANIA";

            return "NOTHING";
        }

        public override string ToString()
        {
            return getName();
        }
    }
}

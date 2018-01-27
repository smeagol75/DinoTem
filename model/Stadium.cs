using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Stadium
    {
        private int id;
        private string name;
		private string japaneseName;
		private string konamiName;
		private int capacity;
		private int country;
		private int zone;
		private int na;
		private bool license;

        public Stadium(int id)
        {
            if (id < 0)
                throw new ArgumentException("Stadium's id isn't valid: " + id);

            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }
		
		public string getJapaneseName()
        {
            return this.japaneseName;
        }
		
		public string getKonamiName()
        {
            return this.konamiName;
        }
		
		public int getCapacity()
        {
            return this.capacity;
        }
		
		public int getCountry()
        {
            return this.country;
        }
		
		public int getZone()
        {
            return this.zone;
        }
		
		public int getNa()
        {
            return this.na;
        }
		
		public bool getLicense()
        {
            return this.license;
        }

        public void setId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Stadium's id isn't valid: " + id);

            this.id = id;
        }

        public void setName(string name)
        {
            if (name == null || name == "")
                throw new ArgumentException("Stadium name isn't valid - Id stadium: " + getId());

            this.name = name;
        }
		
		public void setJapaneseName(string japaneseName)
        {
            if (japaneseName == null || japaneseName == "")
                throw new ArgumentException("Stadium's japanese name isn't valid - " + getName());

            this.japaneseName = japaneseName;
        }
		
		public void setKonamiName(string konamiName)
        {
            if (konamiName == null || konamiName == "")
                throw new ArgumentException("Stadium's Konami name isn't valid - " + getName());

            this.konamiName = konamiName;
        }
		
		public void setCapacity(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Stadium's capacity isn't valid - " + getName());

            this.capacity = capacity;
        }
		
		public void setCountry(int country)
        {
            if (country < 0)
                throw new ArgumentException("Stadium's country isn't valid - " + getName());

            this.country = country;
        }
		
		public void setZone(int zone)
        {
            if (zone < 2)
                throw new ArgumentException("Stadium's zone isn't valid - " + getName());

            this.zone = zone;
        }
		
		public void setNa(int na)
        {
            if (na < 0 && na > 3)
                throw new ArgumentException("Stadium's n/a isn't valid - " + getName());

            this.na = na;
        }
		
		public void setLicense(bool license)
        {
            this.license = license;
        }

        public string getStringZone()
        {
            string t = "";

            switch (getZone())
            {
                case 2: t = "Europe";
                    break;
                case 3: t = "Asia";
                    break;
                case 4: t = "South America";
                    break;
                case 5: t = "Africa";
                    break;
                case 6: t = "North America";
                    break;
                case 7: t = "Oceania America";
                    break;
            }
            return t;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Stadium)
            {
                Stadium c = (Stadium)obj;
                return getId() == c.getId();
            }
            return false;
        }

        public override string ToString()
        {
            return getName();
        }
    }
}

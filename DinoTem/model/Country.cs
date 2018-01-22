using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Country
    {
        private int id;
        private string continente;
        private string nationality;
        private string name;
        private string nationFm;

        public Country(int id, string continente, string nationality, string name)
        {
    	    if (id < 0)
                throw new ArgumentException("Country's id isn't valid: " + id);
    	    if (continente == null || continente == "")
                throw new ArgumentException("Country's continent isn't valid - Id country: " + getId());
            if (nationality == null || nationality == "")
                throw new ArgumentException("Country's nationality isn't valid - Id country: " + getId());
            if (name == null || name == "")
                throw new ArgumentException("Country name isn't valid - Id country: " + getId());
    	
            this.id = id;
            this.continente = continente;
            this.nationality = nationality;
            this.name = name;
        }

        public int getId()
        {
            return this.id;
        }

        public string getContinente()
        {
            return this.continente;
        }

        public string getNationality()
        {
            return this.nationality;
        }

        public string getNationFm()
        {
            return this.nationFm;
        }

        public string getName()
        {
            return this.name;
        }

        public void setId(int id)
        {
    	    if (id < 0)
                throw new ArgumentException("Country's id isn't valid: " + id);
    	
            this.id = id;
        }

        public void setContinente(string continente)
        {
    	    if (continente == null || continente == "")
                throw new ArgumentException("Country's continent isn't valid - Id country: " + getId());
    	
            this.continente = continente;
        }

        public void setNationality(string nationality)
        {
    	    if (nationality == null || nationality == "")
                throw new ArgumentException("Country's nationality isn't valid - Id country: " + getId());
    	
            this.nationality = nationality;
        }

        public void setNationFm(string nationFm)
        {
            if (nationFm == null || nationFm == "")
                throw new ArgumentException("NationFm isn't valid - Id country: " + getId());

            this.nationFm = nationFm;
        }

        public void setName(string name)
        {
    	    if (name == null || name == "")
                throw new ArgumentException("Country's name isn't valid - Id country: " + getId());
    	
            this.name = name;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Country)
    	    {
                Country c = (Country)obj;
    		    return getId() == c.getId();
    	    }
    	    return false;
        }

        public override string ToString()
        {
            return getNationality();
        }
    }
}

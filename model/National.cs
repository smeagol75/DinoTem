﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class National : Team
    {
        public National(UInt32 id) : base(id)
        {
        }

        private string greek;
        private string spanish;
        private string latinAmericaSpanish;
        private string french;
        private string turkish;
        private string portuguese;
        private string brazilianPortuguese;
        private string german;
        private string dutch;
        private string swedish;
        private string italian;
        private string russian;
        private string englishUS;

        public string getSpanish()
        {
            return this.spanish;
        }

        public string getBrazilianPortuguese()
        {
            return brazilianPortuguese;
        }

        public string getItalian()
        {
            return this.italian;
        }

        public string getGerman()
        {
            return this.german;
        }

        public string getDutch()
        {
            return this.dutch;
        }

        public string getSwedish()
        {
            return this.swedish;
        }

        public string getRussian()
        {
            return this.russian;
        }

        public string getGreek()
        {
            return this.greek;
        }

        public string getLatinAmericaSpanish()
        {
            return this.latinAmericaSpanish;
        }

        public string getFrench()
        {
            return this.french;
        }

        public string getTurkish()
        {
            return this.turkish;
        }

        public string getPortuguese()
        {
            return this.portuguese;
        }

        public string getEnglishUS()
        {
            return this.englishUS;
        }

        public void setSpanish(string spanish)
        {
            if (spanish == null || spanish == "")
                this.spanish = "National without name";
            //throw new ArgumentException("Spanish name isn't valid - " + base.getEnglish());

            this.spanish = spanish;
            return;
        }

        public void setEnglishUS(string englishUS)
        {
            if (englishUS == null || englishUS == "")
                this.englishUS = "National without name";
            //throw new ArgumentException("English Us name isn't valid - " + base.getEnglish());

            this.englishUS = englishUS;
            return;
        }

        public void setPortuguese(string portuguese)
        {
            if (portuguese == null || portuguese == "")
                this.portuguese = "National without name";
            //throw new ArgumentException("Portuguese name isn't valid - " + base.getEnglish());

            this.portuguese = portuguese;
            return;
        }

        public void setTurkish(string turkish)
        {
            if (turkish == null || turkish == "")
                this.turkish = "National without name";
            //throw new ArgumentException("Turkish name isn't valid - " + base.getEnglish());

            this.turkish = turkish;
            return;
        }

        public void setFrench(string french)
        {
            if (french == null || french == "")
                this.french = "National without name";
            //throw new ArgumentException("French name isn't valid - " + base.getEnglish());

            this.french = french;
            return;
        }

        public void setLatinAmericaSpanish(string latinAmericaSpanish)
        {
            if (latinAmericaSpanish == null || latinAmericaSpanish == "")
                this.latinAmericaSpanish = "National without name";
            //throw new ArgumentException("Latin america spanish name isn't valid - " + base.getEnglish());

            this.latinAmericaSpanish = latinAmericaSpanish;
            return;
        }

        public void setGreek(string greek)
        {
            if (greek == null || greek == "")
                this.greek = "National without name";
            //throw new ArgumentException("Greek name isn't valid - " + base.getEnglish());

            this.greek = greek;
            return;
        }

        public void setRussian(string russian)
        {
            if (russian == null || russian == "")
                this.russian = "National without name";
            //throw new ArgumentException("Russian name isn't valid - " + base.getEnglish());

            this.russian = russian;
            return;
        }

        public void setItalian(string italian)
        {
            if (italian == null || italian == "")
                this.italian = "National without name";
            //throw new ArgumentException("Italian name isn't valid - " + base.getEnglish());

            this.italian = italian;
            return;
        }

        public void setSwedish(string swedish)
        {
            if (swedish == null || swedish == "")
                this.swedish = "National without name";
            //throw new ArgumentException("Swedish name isn't valid - " + base.getEnglish());

            this.swedish = swedish;
            return;
        }

        public void setDutch(string dutch)
        {
            if (dutch == null || dutch == "")
                this.dutch = "National without name";
            //throw new ArgumentException("Dutch name isn't valid - " + base.getEnglish());

            this.dutch = dutch;
            return;
        }

        public void setGerman(string german)
        {
            if (german == null || german == "")
                this.german = "National without name";
            //throw new ArgumentException("German name isn't valid - " + base.getEnglish());

            this.german = german;
            return;
        }

        public void setBrazilianPortuguese(string brazilianPortuguese)
        {
            if (brazilianPortuguese == null || brazilianPortuguese == "")
                this.brazilianPortuguese = "National without name";
            //throw new ArgumentException("Portuguese name isn't valid - " + base.getEnglish());

            this.brazilianPortuguese = brazilianPortuguese;
            return;
        }
    }
}

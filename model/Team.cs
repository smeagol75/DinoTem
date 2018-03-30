using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public abstract class Team
    {
        private UInt32 id;
        private UInt32 managerId;
        private UInt32 feederTeamId;
        private UInt32 parentTeamId;
        private UInt32 stadiumId;
        private string ShortSquadra;
        private UInt32 hasLicensedPlayers;
        private UInt32 licensedTeam;
        private UInt32 national;
        private UInt32 fakeTeam;
        private UInt32 licensedCoach;
        private UInt32 licensedCoach2;
        private UInt32 hasAnthem;
        private UInt32 anthemStandingAngle;
        private UInt32 anthemPlayersSinging;
        private UInt32 anthemStandingStyle;
        private UInt32 unknown6;
        private UInt32 notPlayableLeague;
        private UInt32 country;
        private string english;
        private string japanese;
        private string konami;

        public Team(UInt32 idSquadra)
        {
            if (idSquadra < 0)
                throw new ArgumentException("Team's Id isn't valid: " + idSquadra);
    	
            this.id = idSquadra;
        }

        public UInt32 getId()
        {
            return this.id;
        }

        public UInt32 getParentTeamId()
        {
            return this.parentTeamId;
        }

        public UInt32 getFeederTeamId()
        {
            return this.feederTeamId;
        }

        public UInt32 getManagerId()
        {
            return this.managerId;
        }

        public UInt32 getStadiumId()
        {
            return this.stadiumId;
        }

        public string getEnglish()
        {
            return this.english;
        }

        public string getShortSquadra()
        {
            return this.ShortSquadra;
        }

        public UInt32 getHasLicensedPlayers()
        {
            return this.hasLicensedPlayers;
        }

        public UInt32 getLicensedTeam()
        {
            return this.licensedTeam;
        }

        public UInt32 getNational()
        {
            return this.national;
        }

        public UInt32 getFakeTeam()
        {
            return this.fakeTeam;
        }

        public UInt32 getLicensedCoach()
        {
            return this.licensedCoach;
        }

        public UInt32 getLicensedCoach2()
        {
            return this.licensedCoach2;
        }

        public UInt32 getHasAnthem()
        {
            return this.hasAnthem;
        }

        public UInt32 getAnthemStandingAngle()
        {
            return this.anthemStandingAngle;
        }

        public UInt32 getAnthemPlayersSinging()
        {
            return this.anthemPlayersSinging;
        }

        public UInt32 getAnthemStandingStyle()
        {
            return this.anthemStandingStyle;
        }

        public UInt32 getUnknown6()
        {
            return this.unknown6;
        }

        public UInt32 getNotPlayableLeague()
        {
            return this.notPlayableLeague;
        }

        public UInt32 getCountry()
        {
            return this.country;
        }

        public string getJapanese()
        {
            return this.japanese;
        }

        public string getKonami()
        {
            return this.konami;
        }

        public void setId(UInt32 id)
        {
            if (id < 0 && id > 65535)
                throw new ArgumentException("Team's id isn't valid: " + id);
    	
		    this.id = id;
	    }

	    public void setKonami(string konami)
        {
    	    //konami.isEmpty()
    	    if (konami == null)
                throw new ArgumentException("Team's Konami name isn't valid - " + getEnglish());
    	
            this.konami = konami;
            return;
        }

        public void setJapanese(string japanese)
        {
    	    if (japanese == null || japanese == "")
                throw new ArgumentException("Team's japanese name isn't valid - " + getEnglish());
    	
            this.japanese = japanese;
            return;
        }

        public void setNotPlayableLeague(UInt32 notPlayableLeague)
        {
            if (notPlayableLeague < 0 && notPlayableLeague > 7)
                throw new ArgumentException("Team's playable league isn't valid - " + getEnglish());
    	
            this.notPlayableLeague = notPlayableLeague;
            return;
        }

        public void setAnthemStandingStyle(UInt32 anthemStandingStyle)
        {
            if (anthemStandingStyle < 0 && anthemStandingStyle > 7)
                throw new ArgumentException("Team's anthemStandingStyle isn't valid - " + getEnglish());

            this.anthemStandingStyle = anthemStandingStyle;
            return;
        }

        public void setAnthemPlayersSinging(UInt32 anthemPlayersSinging)
        {
            if (anthemPlayersSinging < 0 && anthemPlayersSinging > 3)
                throw new ArgumentException("Team's anthemPlayersSinging isn't valid - " + getEnglish());

            this.anthemPlayersSinging = anthemPlayersSinging;
            return;
        }

        public void setAnthemStandingAngle(UInt32 anthemStandingAngle)
        {
            if (anthemStandingAngle < 0 && anthemStandingAngle > 3)
                throw new ArgumentException("Team's anthem standing angle isn't valid - " + getEnglish());

            this.anthemStandingAngle = anthemStandingAngle;
            return;
        }

        public void setHasAnthem(UInt32 hasAnthem)
        {
            this.hasAnthem = hasAnthem;
            return;
        }

        public void setLicensedCoach(UInt32 b)
        {
            this.licensedCoach = b;
        }

        public void setLicensedCoach2(UInt32 b)
        {
            this.licensedCoach2 = b;
        }

        public void setFakeTeam(UInt32 fakeTeam)
        {
            this.fakeTeam = fakeTeam;
            return;
        }

        public void setNational(UInt32 national)
        {
            this.national = national;
            return;
        }

        public void setLicensedTeam(UInt32 licensedTeam)
        {
            this.licensedTeam = licensedTeam;
            return;
        }

        public void setHasLicensedPlayers(UInt32 hasLicensedPlayers)
        {
            this.hasLicensedPlayers = hasLicensedPlayers;
            return;
        }

        public void setUnknown6(UInt32 unknown6)
        {
            this.unknown6 = unknown6;
            return;
        }

        public void setShortSquadra(string ShortSquadra)
        {
    	    if (ShortSquadra == null || ShortSquadra == "")
                throw new ArgumentException("Team's short name isn't valid - " + getEnglish());
    	
            this.ShortSquadra = ShortSquadra;
            return;
        }

        public void setManagerId(UInt32 managerId)
        {
            if (managerId < 0)
                throw new ArgumentException("Team's manager isn't valid - " + getEnglish());

            this.managerId = managerId;
            return;
        }

        public void setFeederTeamId(UInt32 feederTeamId)
        {
            if (feederTeamId < 0)
                throw new ArgumentException("Feeder team id isn't valid - " + getEnglish());

            this.feederTeamId = feederTeamId;
            return;
        }

        public void setParentTeamId(UInt32 parentTeamId)
        {
            if (parentTeamId < 0)
                throw new ArgumentException("Team's parent team id isn't valid - " + getEnglish());

            this.parentTeamId = parentTeamId;
            return;
        }

        public void setStadiumId(UInt32 stadiumId)
        {
            if (stadiumId < 0)
                throw new ArgumentException("Team's stadium id isn't valid - " + getEnglish());

            this.stadiumId = stadiumId;
            return;
        }

        public void setCountry(UInt32 country)
        {
    	    if (country < 0)
                throw new ArgumentException("Team's country id isn't valid - " + getEnglish());
    	
		    this.country = country;
	    }

	    public void setEnglish(string english)
        {
    	    if (english == null || english == "")
                throw new ArgumentException("Team's english name isn't valid - " + getEnglish());
    	
            this.english = english;
            return;
        }

        public string getStringNotPlayableLeague()
        {
            string t = "";

            switch (getNotPlayableLeague())
            {
                case 0: t = "No League";
                    break;
                case 1: t = "Classic League";
                    break;
                case 2: t = "Other Europe League";
                    break;
                case 3: t = "Other Asian League";
                    break;
                case 4: t = "Hidden Fake European League";
                    break;
                case 5: t = "ML Hidden League";
                    break;
                case 6: t = "Other America League";
                    break;
                case 7: t = "Other Africa League";
                    break;
            }
            return t;
        }

        public string getStringLicensedTeam()
        {
            string t = "";

            switch (getLicensedTeam())
            {
                case 0: t = "Unlicensed";
                    break;
                case 1: t = "Licensed";
                    break;
            }
            return t;
        }

        public string getStringNational()
        {
            string t = "";

            switch (getNational())
            {
                case 0: t = "Club";
                    break;
                case 1: t = "National";
                    break;
            }
            return t;
        }

        public string getStringFakeTeam()
        {
            string t = "";

            switch (getFakeTeam())
            {
                case 0: t = "No";
                    break;
                case 1: t = "Yes";
                    break;
            }
            return t;
        }

        public string getStringLicensedCoach()
        {
            if (getLicensedCoach() == 1 && getLicensedCoach2() == 1)
                return "Licensed";

            return "Unlicensed";
        }

        public string getStringHasAnthem()
        {
            string t = "";

            switch (getHasAnthem())
            {
                case 0: t = "No";
                    break;
                case 1: t = "Yes";
                    break;
            }
            return t;
        }

        public string getStringHasLicensedPlayers()
        {
            string t = "";

            switch (getHasLicensedPlayers())
            {
                case 0: t = "No";
                    break;
                case 1: t = "Yes";
                    break;
            }
            return t;
        }

        /*public override bool Equals(Object obj)
        {
            if (obj is Team)
    	    {
                Team c = (Team) obj;
    		    return getId() == c.getId();
    	    }
    	    return false;
        }*/

        public override string ToString()
        {
    	    return getEnglish();
        }
    }
}

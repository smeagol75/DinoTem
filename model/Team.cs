using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public abstract class Team
    {
        private int id;
        private long managerId;
        private long feederTeamId;
        private long parentTeamId;
        private int stadiumId;
        private int teamSortNumber;
        private string ShortSquadra = null;
        private bool hasLicensedPlayers;
        private bool licensedTeam;
        private bool national;
        private bool fakeTeam;
        private bool licensedCoach;
        private bool hasAnthem;
        private int anthemStandingAngle;
        private int anthemPlayersSinging;
        private int anthemStandingStyle;
        private bool unknown6;
        private int notPlayableLeague;
        private int country;
        private string english = null;
        private string japanese = null;
        private string konami = null;

        public Team(int idSquadra)
        {
    	    if (idSquadra < 0)
                throw new ArgumentException("Team's Id isn't valid: " + idSquadra);
    	
            this.id = idSquadra;
        }

        public int getId()
        {
            return this.id;
        }

        public long getParentTeamId()
        {
            return this.parentTeamId;
        }
        
        public long getFeederTeamId()
        {
            return this.feederTeamId;
        }

        public long getManagerId()
        {
            return this.managerId;
        }

        public int getStadiumId()
        {
            return this.stadiumId;
        }

        public int getTeamSortNumber()
        {
            return this.teamSortNumber;
        }

        public string getEnglish()
        {
            return this.english;
        }

        public string getShortSquadra()
        {
            return this.ShortSquadra;
        }

        public bool getHasLicensedPlayers()
        {
            return this.hasLicensedPlayers;
        }

        public bool getLicensedTeam()
        {
            return this.licensedTeam;
        }

        public bool getNational()
        {
            return this.national;
        }

        public bool getFakeTeam()
        {
            return this.fakeTeam;
        }

        public bool getLicensedCoach()
        {
            return this.licensedCoach;
        }

        public bool getHasAnthem()
        {
            return this.hasAnthem;
        }

        public int getAnthemStandingAngle()
        {
            return this.anthemStandingAngle;
        }

        public int getAnthemPlayersSinging()
        {
            return this.anthemPlayersSinging;
        }

        public int getAnthemStandingStyle()
        {
            return this.anthemStandingStyle;
        }

        public bool getUnknown6()
        {
            return this.unknown6;
        }
    
        public int getNotPlayableLeague()
        {
            return this.notPlayableLeague;
        }

        public int getCountry()
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

        public void setId(int id) {
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

        public void setNotPlayableLeague(int notPlayableLeague)
        {
            if (notPlayableLeague < 0 && notPlayableLeague > 7)
                throw new ArgumentException("Team's playable league isn't valid - " + getEnglish());
    	
            this.notPlayableLeague = notPlayableLeague;
            return;
        }

        public void setAnthemStandingStyle(int anthemStandingStyle)
        {
            if (anthemStandingStyle < 0 && anthemStandingStyle > 7)
                throw new ArgumentException("Team's anthemStandingStyle isn't valid - " + getEnglish());

            this.anthemStandingStyle = anthemStandingStyle;
            return;
        }

        public void setAnthemPlayersSinging(int anthemPlayersSinging)
        {
            if (anthemPlayersSinging < 0 && anthemPlayersSinging > 3)
                throw new ArgumentException("Team's anthemPlayersSinging isn't valid - " + getEnglish());

            this.anthemPlayersSinging = anthemPlayersSinging;
            return;
        }

        public void setAnthemStandingAngle(int anthemStandingAngle)
        {
            if (anthemStandingAngle < 0 && anthemStandingAngle > 3)
                throw new ArgumentException("Team's anthem standing angle isn't valid - " + getEnglish());

            this.anthemStandingAngle = anthemStandingAngle;
            return;
        }

        public void setHasAnthem(bool hasAnthem)
        {
            this.hasAnthem = hasAnthem;
            return;
        }

        public void setLicensedCoach(bool b)
        {
            this.licensedCoach = b;
        }

        public void setFakeTeam(bool fakeTeam)
        {
            this.fakeTeam = fakeTeam;
            return;
        }

        public void setNational(bool national)
        {
            this.national = national;
            return;
        }

        public void setLicensedTeam(bool licensedTeam)
        {
            this.licensedTeam = licensedTeam;
            return;
        }

        public void setHasLicensedPlayers(bool hasLicensedPlayers)
        {
            this.hasLicensedPlayers = hasLicensedPlayers;
            return;
        }

        public void setUnknown6(bool unknown6)
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

        public void setManagerId(long managerId)
        {
            if (managerId < 0)
                throw new ArgumentException("Team's manager isn't valid - " + getEnglish());

            this.managerId = managerId;
            return;
        }

        public void setFeederTeamId(long feederTeamId)
        {
            if (feederTeamId < 0)
                throw new ArgumentException("Feeder team id isn't valid - " + getEnglish());

            this.feederTeamId = feederTeamId;
            return;
        }

        public void setParentTeamId(long parentTeamId)
        {
            if (parentTeamId < 0)
                throw new ArgumentException("Team's parent team id isn't valid - " + getEnglish());

            this.parentTeamId = parentTeamId;
            return;
        }

        public void setStadiumId(int stadiumId)
        {
            if (stadiumId < 0)
                throw new ArgumentException("Team's stadium id isn't valid - " + getEnglish());

            this.stadiumId = stadiumId;
            return;
        }

        public void setTeamSortNumber(int teamSortNumber)
        {
            if (teamSortNumber < 0)
                throw new ArgumentException("Team's sort number isn't valid - " + getEnglish());

            this.teamSortNumber = teamSortNumber;
            return;
        }

        public void setCountry(int country) {
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

        public override bool Equals(Object obj)
        {
            if (obj is Team)
    	    {
                Team c = (Team) obj;
    		    return getId() == c.getId();
    	    }
    	    return false;
        }

        public override string ToString()
        {
    	    return getEnglish();
        }
    }
}

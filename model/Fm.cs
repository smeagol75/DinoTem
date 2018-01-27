using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class Fm
    {

        private int id;
        private string firstName;
        private string firstInitial;
        private string surname;
        private string dateOfBirth;
        private string nation;
        private string club;
        private int leftFoot;
        private int rightFoot;
        private string position;
        private int gk;
        private int sw;
        private int rb;
        private int lb;
        private int cb;
        private int wbr;
        private int wbl;
        private int dm;
        private int rm;
        private int lm;
        private int cm;
        private int aml;
        private int amr;
        private int amc;
        private int st;
        private int Acceleration;
        private int Adaptability;
        private int aerialAbility;
        private int aggression;
        private int agility;
        private int ambition;
        private int anticipation;
        private int balance;
        private int bravery;
        private int commandOfArea;
        private int Communication;
        private int Composure;
        private int Concentration;
        private int Consistency;
        private int Controversy;
        private int Corners;
        private int Crossing;
        private int Decisions;
        private int determination;
        private int dirtiness;
        private int dribbling;
        private int eccentricity;
        private int finishing;
        private int firstTouch;
        private int flair;
        private int freeKicks;
        private int handling;
        private int heading;
        private int importantMatches;
        private int injuryProneness;
        private int jumping;
        private int kicking;
        private int leadership;
        private int longShots;
        private int longThrows;
        private int loyalty;
        private int marking;
        private int naturalFitness;
        private int offTheBall;
        private int oneOnOnes;
        private int pace;
        private int passing;
        private int penalties;
        private int positioning;
        private int pressure;
        private int professionalism;
        private int reflexes;
        private int rushingOut;
        private int sportsmanship;
        private int stamina;
        private int strength;
        private int tackling;
        private int teamwork;
        private int technique;
        private int temperament;
        private int tendancyToPunch;
        private int throwing;
        private int versatility;
        private int vision;
        private int WorkRate;

        public Fm(int id)
        {
            if (id < 0)
                throw new ArgumentException("Fm player isn't valid: " + id);

            this.id = id;
        }

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public string getFirstInitial()
        {
            return firstInitial;
        }
        public void setFirstInitial(string firstInitial)
        {
            this.firstInitial = firstInitial;
        }
        public string getSurname()
        {
            return surname;
        }
        public void setSurname(string surname)
        {
            this.surname = surname;
        }
        public string getDateOfBirth()
        {
            return dateOfBirth;
        }
        public void setDateOfBirth(string dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
        public string getNation()
        {
            return nation;
        }
        public void setNation(string nation)
        {
            this.nation = nation;
        }
        public string getClub()
        {
            return club;
        }
        public void setClub(string club)
        {
            this.club = club;
        }
        public int getLeftFoot()
        {
            return leftFoot;
        }
        public void setLeftFoot(int leftFoot)
        {
            this.leftFoot = leftFoot;
        }
        public int getRightFoot()
        {
            return rightFoot;
        }
        public void setRightFoot(int rightFoot)
        {
            this.rightFoot = rightFoot;
        }
        public string getPosition()
        {
            return position;
        }
        public void setPosition(string position)
        {
            this.position = position;
        }
        public int getGk()
        {
            return gk;
        }
        public void setGk(int gk)
        {
            this.gk = gk;
        }
        public int getSw()
        {
            return sw;
        }
        public void setSw(int sw)
        {
            this.sw = sw;
        }
        public int getRb()
        {
            return rb;
        }
        public void setRb(int rb)
        {
            this.rb = rb;
        }
        public int getLb()
        {
            return lb;
        }
        public void setLb(int lb)
        {
            this.lb = lb;
        }
        public int getCb()
        {
            return cb;
        }
        public void setCb(int cb)
        {
            this.cb = cb;
        }
        public int getWbr()
        {
            return wbr;
        }
        public void setWbr(int wbr)
        {
            this.wbr = wbr;
        }
        public int getWbl()
        {
            return wbl;
        }
        public void setWbl(int wbl)
        {
            this.wbl = wbl;
        }
        public int getDm()
        {
            return dm;
        }
        public void setDm(int dm)
        {
            this.dm = dm;
        }
        public int getRm()
        {
            return rm;
        }
        public void setRm(int rm)
        {
            this.rm = rm;
        }
        public int getLm()
        {
            return lm;
        }
        public void setLm(int lm)
        {
            this.lm = lm;
        }
        public int getCm()
        {
            return cm;
        }
        public void setCm(int cm)
        {
            this.cm = cm;
        }
        public int getAml()
        {
            return aml;
        }
        public void setAml(int aml)
        {
            this.aml = aml;
        }
        public int getAmr()
        {
            return amr;
        }
        public void setAmr(int amr)
        {
            this.amr = amr;
        }
        public int getAmc()
        {
            return amc;
        }
        public void setAmc(int amc)
        {
            this.amc = amc;
        }
        public int getSt()
        {
            return st;
        }
        public void setSt(int st)
        {
            this.st = st;
        }
        public int getAcceleration()
        {
            return Acceleration;
        }
        public void setAcceleration(int acceleration)
        {
            Acceleration = acceleration;
        }
        public int getAdaptability()
        {
            return Adaptability;
        }
        public void setAdaptability(int adaptability)
        {
            Adaptability = adaptability;
        }
        public int getAerialAbility()
        {
            return aerialAbility;
        }
        public void setAerialAbility(int aerialAbility)
        {
            this.aerialAbility = aerialAbility;
        }
        public int getAggression()
        {
            return aggression;
        }
        public void setAggression(int aggression)
        {
            this.aggression = aggression;
        }
        public int getAgility()
        {
            return agility;
        }
        public void setAgility(int agility)
        {
            this.agility = agility;
        }
        public int getAmbition()
        {
            return ambition;
        }
        public void setAmbition(int ambition)
        {
            this.ambition = ambition;
        }
        public int getAnticipation()
        {
            return anticipation;
        }
        public void setAnticipation(int anticipation)
        {
            this.anticipation = anticipation;
        }
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int balance)
        {
            this.balance = balance;
        }
        public int getBravery()
        {
            return bravery;
        }
        public void setBravery(int bravery)
        {
            this.bravery = bravery;
        }
        public int getCommandOfArea()
        {
            return commandOfArea;
        }
        public void setCommandOfArea(int commandOfArea)
        {
            this.commandOfArea = commandOfArea;
        }
        public int getCommunication()
        {
            return Communication;
        }
        public void setCommunication(int communication)
        {
            Communication = communication;
        }
        public int getComposure()
        {
            return Composure;
        }
        public void setComposure(int composure)
        {
            Composure = composure;
        }
        public int getConcentration()
        {
            return Concentration;
        }
        public void setConcentration(int concentration)
        {
            Concentration = concentration;
        }
        public int getConsistency()
        {
            return Consistency;
        }
        public void setConsistency(int consistency)
        {
            Consistency = consistency;
        }
        public int getControversy()
        {
            return Controversy;
        }
        public void setControversy(int controversy)
        {
            Controversy = controversy;
        }
        public int getCorners()
        {
            return Corners;
        }
        public void setCorners(int corners)
        {
            Corners = corners;
        }
        public int getCrossing()
        {
            return Crossing;
        }
        public void setCrossing(int crossing)
        {
            Crossing = crossing;
        }
        public int getDecisions()
        {
            return Decisions;
        }
        public void setDecisions(int decisions)
        {
            Decisions = decisions;
        }
        public int getDetermination()
        {
            return determination;
        }
        public void setDetermination(int determination)
        {
            this.determination = determination;
        }
        public int getDirtiness()
        {
            return dirtiness;
        }
        public void setDirtiness(int dirtiness)
        {
            this.dirtiness = dirtiness;
        }
        public int getDribbling()
        {
            return dribbling;
        }
        public void setDribbling(int dribbling)
        {
            this.dribbling = dribbling;
        }
        public int getEccentricity()
        {
            return eccentricity;
        }
        public void setEccentricity(int eccentricity)
        {
            this.eccentricity = eccentricity;
        }
        public int getFinishing()
        {
            return finishing;
        }
        public void setFinishing(int finishing)
        {
            this.finishing = finishing;
        }
        public int getFirstTouch()
        {
            return firstTouch;
        }
        public void setFirstTouch(int firstTouch)
        {
            this.firstTouch = firstTouch;
        }
        public int getFlair()
        {
            return flair;
        }
        public void setFlair(int flair)
        {
            this.flair = flair;
        }
        public int getFreeKicks()
        {
            return freeKicks;
        }
        public void setFreeKicks(int freeKicks)
        {
            this.freeKicks = freeKicks;
        }
        public int getHandling()
        {
            return handling;
        }
        public void setHandling(int handling)
        {
            this.handling = handling;
        }
        public int getHeading()
        {
            return heading;
        }
        public void setHeading(int heading)
        {
            this.heading = heading;
        }
        public int getImportantMatches()
        {
            return importantMatches;
        }
        public void setImportantMatches(int importantMatches)
        {
            this.importantMatches = importantMatches;
        }
        public int getInjuryProneness()
        {
            return injuryProneness;
        }
        public void setInjuryProneness(int injuryProneness)
        {
            this.injuryProneness = injuryProneness;
        }
        public int getJumping()
        {
            return jumping;
        }
        public void setJumping(int jumping)
        {
            this.jumping = jumping;
        }
        public int getKicking()
        {
            return kicking;
        }
        public void setKicking(int kicking)
        {
            this.kicking = kicking;
        }
        public int getLeadership()
        {
            return leadership;
        }
        public void setLeadership(int leadership)
        {
            this.leadership = leadership;
        }
        public int getLongShots()
        {
            return longShots;
        }
        public void setLongShots(int longShots)
        {
            this.longShots = longShots;
        }
        public int getLongThrows()
        {
            return longThrows;
        }
        public void setLongThrows(int longThrows)
        {
            this.longThrows = longThrows;
        }
        public int getLoyalty()
        {
            return loyalty;
        }
        public void setLoyalty(int loyalty)
        {
            this.loyalty = loyalty;
        }
        public int getMarking()
        {
            return marking;
        }
        public void setMarking(int marking)
        {
            this.marking = marking;
        }
        public int getNaturalFitness()
        {
            return naturalFitness;
        }
        public void setNaturalFitness(int naturalFitness)
        {
            this.naturalFitness = naturalFitness;
        }
        public int getOffTheBall()
        {
            return offTheBall;
        }
        public void setOffTheBall(int offTheBall)
        {
            this.offTheBall = offTheBall;
        }
        public int getOneOnOnes()
        {
            return oneOnOnes;
        }
        public void setOneOnOnes(int oneOnOnes)
        {
            this.oneOnOnes = oneOnOnes;
        }
        public int getPace()
        {
            return pace;
        }
        public void setPace(int pace)
        {
            this.pace = pace;
        }
        public int getPassing()
        {
            return passing;
        }
        public void setPassing(int passing)
        {
            this.passing = passing;
        }
        public int getPenalties()
        {
            return penalties;
        }
        public void setPenalties(int penalties)
        {
            this.penalties = penalties;
        }
        public int getPositioning()
        {
            return positioning;
        }
        public void setPositioning(int positioning)
        {
            this.positioning = positioning;
        }
        public int getPressure()
        {
            return pressure;
        }
        public void setPressure(int pressure)
        {
            this.pressure = pressure;
        }
        public int getProfessionalism()
        {
            return professionalism;
        }
        public void setProfessionalism(int professionalism)
        {
            this.professionalism = professionalism;
        }
        public int getReflexes()
        {
            return reflexes;
        }
        public void setReflexes(int reflexes)
        {
            this.reflexes = reflexes;
        }
        public int getRushingOut()
        {
            return rushingOut;
        }
        public void setRushingOut(int rushingOut)
        {
            this.rushingOut = rushingOut;
        }
        public int getSportsmanship()
        {
            return sportsmanship;
        }
        public void setSportsmanship(int sportsmanship)
        {
            this.sportsmanship = sportsmanship;
        }
        public int getStamina()
        {
            return stamina;
        }
        public void setStamina(int stamina)
        {
            this.stamina = stamina;
        }
        public int getStrength()
        {
            return strength;
        }
        public void setStrength(int strength)
        {
            this.strength = strength;
        }
        public int getTackling()
        {
            return tackling;
        }
        public void setTackling(int tackling)
        {
            this.tackling = tackling;
        }
        public int getTeamwork()
        {
            return teamwork;
        }
        public void setTeamwork(int teamwork)
        {
            this.teamwork = teamwork;
        }
        public int getTechnique()
        {
            return technique;
        }
        public void setTechnique(int technique)
        {
            this.technique = technique;
        }
        public int getTemperament()
        {
            return temperament;
        }
        public void setTemperament(int temperament)
        {
            this.temperament = temperament;
        }
        public int getTendancyToPunch()
        {
            return tendancyToPunch;
        }
        public void setTendancyToPunch(int tendancyToPunch)
        {
            this.tendancyToPunch = tendancyToPunch;
        }
        public int getThrowing()
        {
            return throwing;
        }
        public void setThrowing(int throwing)
        {
            this.throwing = throwing;
        }
        public int getVersatility()
        {
            return versatility;
        }
        public void setVersatility(int versatility)
        {
            this.versatility = versatility;
        }
        public int getVision()
        {
            return vision;
        }
        public void setVision(int vision)
        {
            this.vision = vision;
        }
        public int getWorkRate()
        {
            return WorkRate;
        }
        public void setWorkRate(int workRate)
        {
            WorkRate = workRate;
        }

        public override string ToString()
        {
            string f = getFirstName() + " " + getSurname();
            return f.TrimStart(' ');
        }

    }
}

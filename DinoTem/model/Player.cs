using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18
    public class Player
    {
        private long id;
        private long youthPlayerId = 0;
        private long padding = 0;
        private string playerName = null;
        private string shirtName = null;
        private string japanese = null;
        private int weight = 30;
        private int height = 100;
        private int national = 0;
        private int national2 = 0;
        private bool earlyCross;
        private int defense = 40;
        private int clearing = 40;
        private int lowPass = 40;
        private int placeKick = 40;
        private int goalCelebrate = 0;
        private int lb = 0;
        private int coverage = 40;
        private int cathing = 40;
        private int jump = 40;
        private int header = 40;
        private int ballControll = 40;
        private int gk = 40;
        private int goalkeeping = 40;
        private int reflexes = 40;
        private int finishing = 40;
        private int ballWinning = 40;
        private int speed = 40;
        private int penaltyKick = 0;
        private int kickingPower = 40;
        private int dribbling = 40;
        private int explosiveP = 40;
        private int stamina = 40;
        private int swerve = 40;
        private int playingAttitude = 0;
        private int age = 15;
        private int loftedPass = 40;
        private int physical = 40;
        private int bodyControll = 40;
        private int attack = 40;
        private int wcUsage = 0;
        private int dmf = 0;
        private int starPlayerIndicator = 0;
        private int runningArm = 0;
        private int driblingArm = 0;
        private int cornerKick = 0;
        private int form = 0;
        private int position = 0;
        private int freeKick = 0;
        private int playingStyle = 0;
        private bool pinCrossing;
        private bool sombrero;
        private int runningH = 0;
        private int ss = 0;
        private int unk2 = 0;
        private int rwf = 0;
        private int lmf = 0;
        private int rb = 0;
        private int lwf = 0;
        private int cf = 0;
        private int cb = 0;
        private int driblingH = 0;
        private int amf = 0;
        private int weakFootAcc = 0;
        private int rmf = 0;
        private int injuryRes = 0;
        private int cmf = 0;
        private bool speedingBullet;
        private bool schotMove;
        private bool gkLong;
        private bool longThrow;
        private bool scissorFeint;
        private bool trackBack;
        private bool superSub;
        private bool rabona;
        private bool acrobatingFinishing;
        private bool strongerFoot;
        private bool knucleShot;
        private bool firstTimeShot;
        private bool comIncisiveRun;
        private bool strongerHand;
        private bool hiddenPlayer;
        private bool comLongRanger;
        private bool oneTouchPass;
        private bool hellTick;
        private bool unk4;
        private bool manMarking;
        private bool legendGoldenBall;
        private bool marseilleTurn;
        private bool heading;
        private bool outsideCurler;
        private bool captaincy;
        private bool malicia;
        private bool lowPuntTrajectory;
        private bool comTrickster;
        private bool lowLoftedPass;
        private bool fightingSpirit;
        private bool flipFlap;
        private bool weightnessPass;
        private bool unk6;
        private bool unk7;
        private bool unk8;
        private bool comMazingRun;
        private bool acrobatingClear;
        private bool comBallExpert;
        private bool cutBehind;
        private bool longRange;

        public Player(long id)
        {
    	    if (id < 0)
                throw new ArgumentException("Player's id isn't valid: " + id);
    	
            this.id = id;
        }

	    public long getId()
        {
            return this.id;
        }

        public long getYouthPlayerId()
        {
            return this.youthPlayerId;
        }

        public long getPadding()
        {
            return this.padding;
        }

        public int getFinishing()
        {
            return this.finishing;
        }

        public bool getLongRange()
        {
            return this.longRange;
        }

        public bool getCutBehind()
        {
            return this.cutBehind;
        }

        public bool getComBallExpert()
        {
            return this.comBallExpert;
        }

        public bool getAcrobatingClear()
        {
            return this.acrobatingClear;
        }

        public bool getComMazingRun()
        {
            return this.comMazingRun;
        }

        public bool getUnk8()
        {
            return this.unk8;
        }

        public bool getUnk7()
        {
            return this.unk7;
        }

        public bool getUnk6()
        {
            return this.unk6;
        }

        public bool getWeightnessPass()
        {
            return this.weightnessPass;
        }

        public bool getFlipFlap()
        {
            return this.flipFlap;
        }

        public bool getFightingSpirit()
        {
            return this.fightingSpirit;
        }

        public bool getLowLoftedPass()
        {
            return this.lowLoftedPass;
        }

        public bool getComTrickster()
        {
            return this.comTrickster;
        }

        public bool getLowPuntTrajectory()
        {
            return this.lowPuntTrajectory;
        }

        public bool getMalicia()
        {
            return this.malicia;
        }

        public bool getCaptaincy()
        {
            return this.captaincy;
        }

        public bool getOutsideCurler()
        {
            return this.outsideCurler;
        }

        public bool getHeading()
        {
            return this.heading;
        }

        public bool getMarseilleTurn()
        {
            return this.marseilleTurn;
        }

        public bool getLegendGoldenBall()
        {
            return this.legendGoldenBall;
        }

        public bool getManMarking()
        {
            return this.manMarking;
        }

        public bool getUnk4()
        {
            return this.unk4;
        }

        public bool getHellTick()
        {
            return this.hellTick;
        }

        public bool getOneTouchPass()
        {
            return this.oneTouchPass;
        }

        public bool getComLongRanger()
        {
            return this.comLongRanger;
        }

        public bool getHiddenPlayer()
        {
            return this.hiddenPlayer;
        }

        public bool getStrongerHand()
        {
            return this.strongerHand;
        }

        public bool getComIncisiveRun()
        {
            return this.comIncisiveRun;
        }

        public bool getFirstTimeShot()
        {
            return this.firstTimeShot;
        }

        public bool getKnucleShot()
        {
            return this.knucleShot;
        }

        public bool getStrongerFoot()
        {
            return this.strongerFoot;
        }

        public bool getAcrobatingFinishing()
        {
            return this.acrobatingFinishing;
        }

        public bool getRabona()
        {
            return this.rabona;
        }

        public bool getSuperSub()
        {
            return this.superSub;
        }

        public bool getTrackBack()
        {
            return this.trackBack;
        }

        public bool getScissorFeint()
        {
            return this.scissorFeint;
        }

        public bool getLongThrow()
        {
            return this.longThrow;
        }

        public bool getGkLong()
        {
            return this.gkLong;
        }

        public bool getSchotMove()
        {
            return this.schotMove;
        }

        public bool getSpeedingBullet()
        {
            return this.speedingBullet;
        }

        public int getCmf()
        {
            return this.cmf;
        }

        public int getWeakFootAcc()
        {
            return this.weakFootAcc;
        }

        public int getRmf()
        {
            return this.rmf;
        }

        public int getInjuryRes()
        {
            return this.injuryRes;
        }

        public int getAmf()
        {
            return this.amf;
        }

        public int getDriblingH()
        {
            return this.driblingH;
        }

        public int getCb()
        {
            return this.cb;
        }

        public int getCf()
        {
            return this.cf;
        }

        public int getLwf()
        {
            return this.lwf;
        }

        public int getRb()
        {
            return this.rb;
        }

        public int getLmf()
        {
            return this.lmf;
        }

        public int getRwf()
        {
            return this.rwf;
        }

        public int getUnk2()
        {
            return this.unk2;
        }

        public int getSs()
        {
            return this.ss;
        }

        public int getRunningH()
        {
            return this.runningH;
        }

        public bool getSombrero()
        {
            return this.sombrero;
        }

        public bool getPinCrossing()
        {
            return this.pinCrossing;
        }

        public int getPlayingStyle()
        {
            return this.playingStyle;
        }

        public int getFreeKick()
        {
            return this.freeKick;
        }

        public int getPosition()
        {
            return this.position;
        }

        public int getForm()
        {
            return this.form;
        }

        public int getCornerKick()
        {
            return this.cornerKick;
        }

        public int getDriblingArm()
        {
            return this.driblingArm;
        }

        public int getRunningArm()
        {
            return this.runningArm;
        }

        public int getStarPlayerIndicator()
        {
            return this.starPlayerIndicator;
        }

        public int getDmf()
        {
            return this.dmf;
        }

        public int getWcUsage()
        {
            return this.wcUsage;
        }

        public int getAttack()
        {
            return this.attack;
        }

        public int getBodyControll()
        {
            return this.bodyControll;
        }

        public int getPhysical()
        {
            return this.physical;
        }

        public int getLoftedPass()
        {
            return this.loftedPass;
        }

        public int getAge()
        {
            return this.age;
        }

        public int getPlayingAttitude()
        {
            return this.playingAttitude;
        }

        public int getSwerve()
        {
            return this.swerve;
        }

        public int getStamina()
        {
            return this.stamina;
        }

        public int getExplosiveP()
        {
            return this.explosiveP;
        }

        public int getDribbling()
        {
            return this.dribbling;
        }

        public int getKickingPower()
        {
            return this.kickingPower;
        }

        public int getPenaltyKick()
        {
            return this.penaltyKick;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public int getBallWinning()
        {
            return this.ballWinning;
        }

        public int getReflexes()
        {
            return this.reflexes;
        }

        public int getGoalkeeping()
        {
            return this.goalkeeping;
        }

        public int getGk()
        {
            return this.gk;
        }

        public int getBallControll()
        {
            return this.ballControll;
        }

        public int getHeader()
        {
            return this.header;
        }

        public int getJump()
        {
            return this.jump;
        }

        public int getCathing()
        {
            return this.cathing;
        }

        public int getCoverage()
        {
            return this.coverage;
        }

        public int getLb()
        {
            return this.lb;
        }

        public int getGoalCelebrate()
        {
            return this.goalCelebrate;
        }

        public int getLowPass()
        {
            return this.lowPass;
        }

        public int getPlaceKick()
        {
            return this.placeKick;
        }

        public int getClearing()
        {
            return this.clearing;
        }

        public int getDefense()
        {
            return this.defense;
        }

        public bool getEarlyCross()
        {
            return this.earlyCross;
        }

        public int getNational2()
        {
            return this.national2;
        }

        public int getNational()
        {
            return this.national;
        }

        public int getWeight()
        {
            return this.weight;
        }

        public int getHeight()
        {
            return this.height;
        }

        public string getPlayerName()
        {
            return this.playerName;
        }

        public string getShirtName()
        {
            return this.shirtName;
        }
    
        public string getJapanese()
        {
            return this.japanese;
        }

        public void setId(long id)
        {
			if (id < 0)
                throw new ArgumentException("Player's id isn't valid: " + id);
            this.id = id;
        }
    
        public void setJapanese(string japanese) {
    	    if (japanese == null || japanese == "")
    		    throw new ArgumentException("Player's japanese name isn't valid - " + getPlayerName());
    	
		    this.japanese = japanese;
	    }

        public void setLongRange(bool longRange)
        {
            this.longRange = longRange;
            return;
        }

        public void setCutBehind(bool cutBehind)
        {
            this.cutBehind = cutBehind;
            return;
        }

        public void setComBallExpert(bool comBallExpert)
        {
            this.comBallExpert = comBallExpert;
            return;
        }

        public void setAcrobatingClear(bool acrobatingClear)
        {
            this.acrobatingClear = acrobatingClear;
            return;
        }

        public void setComMazingRun(bool comMazingRun)
        {
            this.comMazingRun = comMazingRun;
            return;
        }

        public void setUnk8(bool unk8)
        {
            this.unk8 = unk8;
            return;
        }

        public void setUnk7(bool unk7)
        {
            this.unk7 = unk7;
            return;
        }

        public void setUnk6(bool unk6)
        {
            this.unk6 = unk6;
            return;
        }

        public void setWeightnessPass(bool weightnessPass)
        {
            this.weightnessPass = weightnessPass;
            return;
        }

        public void setFlipFlap(bool flipFlap)
        {
            this.flipFlap = flipFlap;
            return;
        }

        public void setFightingSpirit(bool fightingSpirit)
        {
            this.fightingSpirit = fightingSpirit;
            return;
        }

        public void setLowLoftedPass(bool lowLoftedPass)
        {
            this.lowLoftedPass = lowLoftedPass;
            return;
        }

        public void setComTrickster(bool comTrickster)
        {
            this.comTrickster = comTrickster;
            return;
        }

        public void setLowPuntTrajectory(bool lowPuntTrajectory)
        {
            this.lowPuntTrajectory = lowPuntTrajectory;
            return;
        }

        public void setMalicia(bool malicia)
        {
            this.malicia = malicia;
            return;
        }

        public void setCaptaincy(bool captaincy)
        {
            this.captaincy = captaincy;
            return;
        }

        public void setOutsideCurler(bool outsideCurler)
        {
            this.outsideCurler = outsideCurler;
            return;
        }

        public void setHeading(bool heading)
        {
            this.heading = heading;
            return;
        }

        public void setMarseilleTurn(bool marseilleTurn)
        {
            this.marseilleTurn = marseilleTurn;
            return;
        }

        public void setLegendGoldenBall(bool legendGoldenBall)
        {
            this.legendGoldenBall = legendGoldenBall;
            return;
        }

        public void setManMarking(bool manMarking)
        {
            this.manMarking = manMarking;
            return;
        }

        public void setUnk4(bool unk4)
        {
            this.unk4 = unk4;
            return;
        }

        public void setHellTick(bool hellTick)
        {
            this.hellTick = hellTick;
            return;
        }

        public void setOneTouchPass(bool oneTouchPass)
        {
            this.oneTouchPass = oneTouchPass;
            return;
        }

        public void setComLongRanger(bool comLongRanger)
        {
            this.comLongRanger = comLongRanger;
            return;
        }

        public void setHiddenPlayer(bool hiddenPlayer)
        {
            this.hiddenPlayer = hiddenPlayer;
            return;
        }

        public void setStrongerHand(bool strongerHand)
        {
            this.strongerHand = strongerHand;
            return;
        }

        public void setComIncisiveRun(bool comIncisiveRun)
        {
            this.comIncisiveRun = comIncisiveRun;
            return;
        }

        public void setFirstTimeShot(bool firstTimeShot)
        {
            this.firstTimeShot = firstTimeShot;
            return;
        }

        public void setKnucleShot(bool knucleShot)
        {
            this.knucleShot = knucleShot;
            return;
        }

        public void setStrongerFoot(bool strongerFoot)
        {
            this.strongerFoot = strongerFoot;
            return;
        }

        public void setAcrobatingFinishing(bool acrobatingFinishing)
        {
            this.acrobatingFinishing = acrobatingFinishing;
            return;
        }

        public void setRabona(bool rabona)
        {
            this.rabona = rabona;
            return;
        }

        public void setSuperSub(bool superSub)
        {
            this.superSub = superSub;
            return;
        }

        public void setTrackBack(bool trackBack)
        {
            this.trackBack = trackBack;
            return;
        }

        public void setScissorFeint(bool scissorFeint)
        {
            this.scissorFeint = scissorFeint;
            return;
        }

        public void setLongThrow(bool longThrow)
        {
            this.longThrow = longThrow;
            return;
        }

        public void setGkLong(bool gkLong)
        {
            this.gkLong = gkLong;
            return;
        }

        public void setSchotMove(bool schotMove)
        {
            this.schotMove = schotMove;
            return;
        }

        public void setSpeedingBullet(bool speedingBullet)
        {
            this.speedingBullet = speedingBullet;
            return;
        }

        public void setFinishing(int finishing)
        {
    	    if (finishing < 40 || finishing > 99)
                throw new ArgumentException("Player's finishing isn't valid: " + finishing + " - " + getPlayerName());
    	
            this.finishing = finishing;
            return;
        }

        public void setCmf(int cmf)
        {
    	    if (cmf < 0 && cmf > 2)
                throw new ArgumentException("Player's cmf isn't valid: " + cmf + " - " + getPlayerName());
    	
            this.cmf = cmf;
            return;
        }

        public void setWeakFootAcc(int weakFootAcc)
        {
    	    if (weakFootAcc < 0)
                throw new ArgumentException("Player's weak foot acc isn't valid: " + weakFootAcc + " - " + getPlayerName());
    	
            this.weakFootAcc = weakFootAcc;
            return;
        }

        public void setRmf(int rmf)
        {
            if (rmf < 0 && rmf > 2)
                throw new ArgumentException("Player's rmf isn't valid: " + rmf + " - " + getPlayerName());
    	
            this.rmf = rmf;
            return;
        }

        public void setInjuryRes(int injuryRes)
        {
    	    if (injuryRes < 0)
                throw new ArgumentException("Player's injury res isn't valid: " + injuryRes + " - " + getPlayerName());
    	
            this.injuryRes = injuryRes;
            return;
        }

        public void setAmf(int amf)
        {
            if (amf < 0 && amf > 2)
                throw new ArgumentException("Player's amf isn't valid: " + amf + " - " + getPlayerName());
    	
            this.amf = amf;
            return;
        }

        public void setDriblingH(int driblingH)
        {
    	    if (driblingH < 0)
                throw new ArgumentException("Player's dribling hunching isn't valid: " + driblingH + " - " + getPlayerName());
    	
            this.driblingH = driblingH;
            return;
        }

        public void setCb(int cb)
        {
            if (cb < 0 && cb > 2)
                throw new ArgumentException("Player's cb isn't valid: " + cb + " - " + getPlayerName());
    	
            this.cb = cb;
            return;
        }

        public void setCf(int cf)
        {
            if (cf < 0 && cf > 2)
                throw new ArgumentException("Player's cf isn't valid: " + cf + " - " + getPlayerName());
    	
            this.cf = cf;
            return;
        }

        public void setLwf(int lwf)
        {
            if (lwf < 0 && lwf > 2)
                throw new ArgumentException("Player's lwf isn't valid: " + lwf + " - " + getPlayerName());
    	
            this.lwf = lwf;
            return;
        }

        public void setRb(int rb)
        {
            if (rb < 0 && rb > 2)
                throw new ArgumentException("Player's rb isn't valid: " + rb + " - " + getPlayerName());
    	
            this.rb = rb;
            return;
        }

        public void setRwf(int rwf)
        {
            if (rwf < 0 && rwf > 2)
                throw new ArgumentException("Player's rwf isn't valid: " + rwf + " - " + getPlayerName());
    	
            this.rwf = rwf;
            return;
        }

        public void setLmf(int lmf)
        {
            if (lmf < 0 && lmf > 2)
                throw new ArgumentException("Player's lmf isn't valid: " + lmf + " - " + getPlayerName());
    	
            this.lmf = lmf;
            return;
        }

        public void setUnk2(int unk2)
        {
    	    if (unk2 < 0)
                throw new ArgumentException("Player's unk2 isn't valid: " + unk2 + " - " + getPlayerName());
    	
            this.unk2 = unk2;
            return;
        }

        public void setSs(int ss)
        {
            if (ss < 0 && ss > 2)
                throw new ArgumentException("Player's ss isn't valid: " + ss + " - " + getPlayerName());
    	
            this.ss = ss;
        }

        public void setRunningH(int runningH)
        {
    	    if (runningH < 0)
                throw new ArgumentException("Player's running hunching isn't valid: " + runningH + " - " + getPlayerName());
    	
            this.runningH = runningH;
        }

        public void setSombrero(bool sombrero)
        {
            this.sombrero = sombrero;
        }

        public void setPinCrossing(bool pinCrossing)
        {
            this.pinCrossing = pinCrossing;
            return;
        }

        public void setPlayingStyle(int playingStyle)
        {
    	    if (playingStyle < 0)
                throw new ArgumentException("Player's playing style isn't valid: " + playingStyle + " - " + getPlayerName());
    	
            this.playingStyle = playingStyle;
            return;
        }

        public void setFreeKick(int freeKick)
        {
    	    if (freeKick < 0)
                throw new ArgumentException("Player's free kick isn't valid: " + freeKick + " - " + getPlayerName());
    	
            this.freeKick = freeKick;
            return;
        }

        public void setPosition(int position)
        {
            if (position < 0 || position > 12)
                throw new ArgumentException("Player's position isn't valid: " + position + " - " + getPlayerName());
    	
            this.position = position;
        }


        public void setYouthPlayerId(long youthPlayerId)
        {
            if (youthPlayerId < 0)
                throw new ArgumentException("Youth player Id isn't valid: " + youthPlayerId + " - " + getPlayerName());

            this.youthPlayerId = youthPlayerId;
        }

        public void setPadding(long padding)
        {
            if (padding < 0)
                throw new ArgumentException("Player's padding isn't valid: " + padding + " - " + getPlayerName());

            this.padding = padding;
        }

        public void setForm(int form)
        {
    	    if (form < 0)
                throw new ArgumentException("Player's form isn't valid: " + form + " - " + getPlayerName());
    	
            this.form = form;
            return;
        }

        public void setCornerKick(int cornerKick)
        {
    	    if (cornerKick < 0)
                throw new ArgumentException("Player's corner kick isn't valid: " + cornerKick + " - " + getPlayerName());
    	
            this.cornerKick = cornerKick;
        }

        public void setDriblingArm(int driblingArm)
        {
    	    if (driblingArm < 0)
                throw new ArgumentException("Player's dribling arm isn't valid: " + driblingArm + " - " + getPlayerName());
    	
            this.driblingArm = driblingArm;
        }

        public void setRunningArm(int runningArm)
        {
    	    if (runningArm < 0)
                throw new ArgumentException("Player's running arm isn't valid: " + runningArm + " - " + getPlayerName());
    	
            this.runningArm = runningArm;
        }

        public void setStarPlayerIndicator(int starPlayerIndicator)
        {
    	    if (starPlayerIndicator < 0)
                throw new ArgumentException("Star player indicator isn't valid: " + starPlayerIndicator + " - " + getPlayerName());
    	
            this.starPlayerIndicator = starPlayerIndicator;
        }

        public void setDmf(int dmf)
        {
            if (dmf < 0 && dmf > 2)
                throw new ArgumentException("Player's dmf isn't valid: " + dmf + " - " + getPlayerName());
    	
            this.dmf = dmf;
        }

        public void setWcUsage(int wcUsage)
        {
    	    if (wcUsage < 0)
                throw new ArgumentException("Player's wc usage isn't valid: " + wcUsage + " - " + getPlayerName());
    	
            this.wcUsage = wcUsage;
        }

        public void setAttack(int attack)
        {
    	    if (attack < 40 || attack > 99)
                throw new ArgumentException("Player's attack isn't valid: " + attack + " - " + getPlayerName());
    	
            this.attack = attack;
            return;
        }

        public void setBodyControll(int bodyControll)
        {
    	    if (bodyControll < 40 || bodyControll > 99)
                throw new ArgumentException("Player's body controll isn't valid: " + bodyControll + " - " + getPlayerName());
    	
            this.bodyControll = bodyControll;
            return;
        }

        public void setPhysical(int physical)
        {
    	    if (physical < 40 || physical > 99)
                throw new ArgumentException("Player's physical isn't valid: " + physical + " - " + getPlayerName());
    	
            this.physical = physical;
            return;
        }

        public void setLoftedPass(int loftedPass)
        {
    	    if (loftedPass < 40 || loftedPass > 99)
                throw new ArgumentException("Player's lofted pass isn't valid: " + loftedPass + " - " + getPlayerName());
    	
            this.loftedPass = loftedPass;
            return;
        }

        public void setAge(int age)
        {
    	    if (age < 15 || age > 48)
                throw new ArgumentException("Player's age isn't valid: " + age + " - " + getPlayerName());
    	
            this.age = age;
            return;
        }

        public void setPlayingAttitude(int playingAttitude)
        {
    	    if (playingAttitude < 0)
                throw new ArgumentException("Player's playing attitude isn't valid: " + playingAttitude + " - " + getPlayerName());
    	
            this.playingAttitude = playingAttitude;
            return;
        }

        public void setSwerve(int swerve)
        {
    	    if (swerve < 40 || swerve > 99)
                throw new ArgumentException("Player's swerve isn't valid: " + swerve + " - " + getPlayerName());
    	
            this.swerve = swerve;
            return;
        }

        public void setStamina(int stamina)
        {
    	    if (stamina < 40 || stamina > 99)
                throw new ArgumentException("Player's stamina isn't valid: " + stamina + " - " + getPlayerName());
    	
            this.stamina = stamina;
            return;
        }

        public void setExplosiveP(int explosiveP)
        {
    	    if (explosiveP < 40 || explosiveP > 99)
                throw new ArgumentException("Player's explosive power isn't valid: " + explosiveP + " - " + getPlayerName());
    	
            this.explosiveP = explosiveP;
            return;
        }

        public void setDribbling(int dribbling)
        {
    	    if (dribbling < 40 || dribbling > 99)
                throw new ArgumentException("Player's dribbling isn't valid: " + dribbling + " - " + getPlayerName());
    	
            this.dribbling = dribbling;
            return;
        }

        public void setKickingPower(int kickingPower)
        {
    	    if (kickingPower < 40 || kickingPower > 99)
                throw new ArgumentException("Player's kicking power isn't valid: " + kickingPower + " - " + getPlayerName());
    	
            this.kickingPower = kickingPower;
            return;
        }

        public void setPenaltyKick(int penaltyKick)
        {
    	    if (penaltyKick < 0)
                throw new ArgumentException("Player's penalty kick isn't valid: " + penaltyKick + " - " + getPlayerName());
    	
            this.penaltyKick = penaltyKick;
            return;
        }

        public void setSpeed(int speed)
        {
    	    if (speed < 40 || speed > 99)
                throw new ArgumentException("Player's speed isn't valid: " + speed + " - " + getPlayerName());
    	
            this.speed = speed;
            return;
        }

        public void setBallWinning(int ballWinning)
        {
    	    if (ballWinning < 40 || ballWinning > 99)
                throw new ArgumentException("Player's ball winning isn't valid: " + ballWinning + " - " + getPlayerName());
    	
            this.ballWinning = ballWinning;
            return;
        }

        public void setReflexes(int reflexes)
        {
    	    if (reflexes < 40 || reflexes > 99)
                throw new ArgumentException("Player's reflexes isn't valid: " + reflexes + " - " + getPlayerName());
    	
            this.reflexes = reflexes;
            return;
        }

        public void setGoalkeeping(int goalkeeping)
        {
    	    if (goalkeeping < 40 || goalkeeping > 99)
                throw new ArgumentException("Player's goalkeeping isn't valid: " + goalkeeping + " - " + getPlayerName());
    	
            this.goalkeeping = goalkeeping;
            return;
        }

        public void setGk(int gk)
        {
            if (gk < 0 && gk > 2)
                throw new ArgumentException("Player's gk isn't valid: " + gk + " - " + getPlayerName());
    	
            this.gk = gk;
            return;
        }

        public void setBallControll(int ballControll)
        {
    	    if (ballControll < 40 || ballControll > 99)
                throw new ArgumentException("Player's ball controll isn't valid: " + ballControll + " - " + getPlayerName());
    	
            this.ballControll = ballControll;
            return;
        }

        public void setHeader(int header)
        {
    	    if (header < 40 || header > 99)
                throw new ArgumentException("Player's header isn't valid: " + header + " - " + getPlayerName());
    	
            this.header = header;
            return;
        }

        public void setJump(int jump)
        {
    	    if (jump < 40 || jump > 99)
                throw new ArgumentException("Player's jump isn't valid: " + jump + " - " + getPlayerName());
    	
            this.jump = jump;
            return;
        }

        public void setCathing(int cathing)
        {
    	    if (cathing < 40 || cathing > 99)
                throw new ArgumentException("Player's cathing isn't valid: " + cathing + " - " + getPlayerName());
    	
            this.cathing = cathing;
            return;
        }

        public void setCoverage(int coverage)
        {
    	    if (coverage < 40 || coverage > 99)
                throw new ArgumentException("Player's coverage isn't valid: " + coverage + " - " + getPlayerName());
    	
            this.coverage = coverage;
            return;
        }

        public void setLb(int lb)
        {
            if (lb < 0 && lb > 2)
                throw new ArgumentException("Player's lb isn't valid: " + lb + " - " + getPlayerName());
    	
            this.lb = lb;
            return;
        }

        public void setGoalCelebrate(int goalCelebrate)
        {
    	    if (goalCelebrate < 0)
                throw new ArgumentException("Player's goal celebrate isn't valid: " + goalCelebrate + " - " + getPlayerName());
    	
            this.goalCelebrate = goalCelebrate;
            return;
        }

        public void setLowPass(int lowPass)
        {
    	    if (lowPass < 40 || lowPass > 99)
                throw new ArgumentException("Player's low pass isn't valid: " + lowPass + " - " + getPlayerName());
    	
            this.lowPass = lowPass;
            return;
        }

        public void setPlaceKick(int placeKick)
        {
    	    if (placeKick < 40 || placeKick > 99)
                throw new ArgumentException("Player's place kick isn't valid: " + placeKick + " - " + getPlayerName());
    	
            this.placeKick = placeKick;
            return;
        }

        public void setClearing(int clearing)
        {
    	    if (clearing < 40 || clearing > 99)
                throw new ArgumentException("Player's clearing isn't valid: " + clearing + " - " + getPlayerName());
    	
            this.clearing = clearing;
            return;
        }

        public void setDefense(int defense)
        {
    	    if (defense < 40 || defense > 99)
                throw new ArgumentException("Player's defense isn't valid: " + defense + " - " + getPlayerName());
    	
            this.defense = defense;
            return;
        }

        public void setEarlyCross(bool earlyCross)
        {
            this.earlyCross = earlyCross;
            return;
        }

        public void setNational(int national)
        {
    	    if (national < 0)
                throw new ArgumentException("Player's nationality isn't valid: " + national + " - " + getPlayerName());
    	
            this.national = national;
            return;
        }

        public void setNational2(int national2)
        {
    	    if (national2 < 0)
                throw new ArgumentException("Player's second nationality isn't valid: " + national2 + " - " + getPlayerName());
    	
            this.national2 = national2;
            return;
        }

        public void setHeight(int height)
        {
    	    if (height < 100 || height > 227)
                throw new ArgumentException("Player's height isn't valid: " + height + " - " + getPlayerName());

            this.height = height;
            return;
        }

        public void setWeight(int weight)
        {
    	    if (weight < 30 || weight > 157)
                throw new ArgumentException("Player's weight isn't valid: " + weight + " - " + getPlayerName());
    	
            this.weight = weight;
            return;
        }

        public void setPlayerName(string playerName)
        {
    	    if (playerName == null || playerName == "")
                throw new ArgumentException("Player's name isn't valid - Id player: " + getId() + ")");
    	
            this.playerName = playerName;
            return;
        }

        public void setShirtName(string shirtName)
        {
    	    if (shirtName == null || shirtName == "")
                throw new ArgumentException("Player's shirt name isn't valid - " + getPlayerName());
    	
            this.shirtName = shirtName;
            return;
        }

        public string getStringFake()
        {
            string pl_type = getId().ToString("X8").ToString();
            pl_type = pl_type.Substring(6, 2) + pl_type.Substring(4, 2) + pl_type.Substring(2, 2) + pl_type.Substring(0, 2);
            pl_type = pl_type.Substring(4, 2);
            if (pl_type == "04" | pl_type == "05")
            {
                return "Fake";
            }
            else
            {
                return "Real";
            }
        }

        public string getstringStrongerFoot()
        {
            if (getStrongerFoot())
                return "Left";
            else
                return "Right";
        }

        public string getStringPlayingStyle()
        {
    	    string temp = "";
            switch (getPlayingStyle())
            {
                case 0: temp = "N/A";
                    break;
                case 1: temp = "Goal Poacher";
                    break;
                case 2: temp = "Dummy Runner";
                    break;
                case 3: temp = "Fox in the Box";
                    break;
                case 4: temp = "Prolific Winger";
                    break;
                case 5: temp = "Classic No. 10";
                    break;
                case 6: temp = "Hole Player";
                    break;
                case 7: temp = "Box-To-Box";
                    break;
                case 8: temp = "Anchor Man";
                    break;
                case 9: temp = "The Destroyer";
                    break;
                case 10: temp = "Extra Frontman";
                    break;
                case 11: temp = "Offensive Full-Back";
                    break;
                case 12: temp = "Defensive Full-Back";
                    break;
                case 13: temp = "Target Man";
                    break;
                case 14: temp = "Creative Playmaker";
                    break;
                case 15: temp = "Build Up";
                    break;
                case 16: temp = "Offensive Goalkeeper";
                    break;
                case 17: temp = "Defensive Goalkeeper";
                    break;
            }
            return temp;
        }

        public string getStringPosition() 
        {
            string temp = "";
            switch (getPosition())
            {
                case 0: temp = "GK";
                    break;
                case 1: temp = "CB";
                    break;
                case 2: temp = "LB";
                    break;
                case 3: temp = "RB";
                    break;
                case 4: temp = "DMF";
                    break;
                case 5: temp = "CMF";
                    break;
                case 6: temp = "LMF";
                    break;
                case 7: temp = "RMF";
                    break;
                case 8: temp = "AMF";
                    break;
                case 9: temp = "LWF";
                    break;
                case 10: temp = "RWF";
                    break;
                case 11: temp = "SS";
                    break;
                case 12: temp = "CF";
                    break;
            }
            return temp;
        }

        public string getStringGK()
        {
            string t = "";

            switch (getGk())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }

            return t;
        }

        public string getStringGB()
        {
            string t = "";

            switch (getCb())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringLB()
        {
            string t = "";

            switch (getLb())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringRB()
        {
            string t = "";

            switch (getRb())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringDMF()
        {
            string t = "";

            switch (getDmf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringCMF()
        {
            string t = "";

            switch (getCmf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringLMF()
        {
            string t = "";

            switch (getLmf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringAMF()
        {
            string t = "";

            switch (getAmf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringRMF()
        {
            string t = "";

            switch (getRmf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringLWF()
        {
            string t = "";

            switch (getLwf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringRWF()
        {
            string t = "";

            switch (getRwf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringSS()
        {
            string t = "";

            switch (getSs())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public string getStringCF()
        {
            string t = "";

            switch (getCf())
            {
                case 0: t = "C";
                    break;
                case 1: t = "B";
                    break;
                case 2: t = "A";
                    break;
            }
            return t;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Player)
    	    {
                Player c = (Player) obj;
                return getId() == c.getId();
    	    }
    	    return false;
        }

        public override string ToString()
        {
    	    return getPlayerName();
        }
    }
}

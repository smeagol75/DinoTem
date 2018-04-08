using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18
    public class Player
    {
        private UInt32 id;
        private UInt32 youthPlayerId = 0;
        private string name;
        private string shirtName;
        private string japanese;
        private UInt32 weight = 30;
        private UInt32 height = 100;
        private UInt32 national = 215;
        private UInt32 national2 = 0;
        private UInt32 earlyCross = 0;
        private UInt32 defense = 40;
        private UInt32 clearing = 40;
        private UInt32 lowPass = 40;
        private UInt32 placeKick = 40;
        private UInt32 goalCelebrate = 0;
        private UInt32 lb = 0;
        private UInt32 coverage = 40;
        private UInt32 cathing = 40;
        private UInt32 jump = 40;
        private UInt32 header = 40;
        private UInt32 ballControll = 40;
        private UInt32 gk = 40;
        private UInt32 goalkeeping = 40;
        private UInt32 reflexes = 40;
        private UInt32 finishing = 40;
        private UInt32 ballWinning = 40;
        private UInt32 speed = 40;
        private UInt32 penaltyKick = 0;
        private UInt32 kickingPower = 40;
        private UInt32 dribbling = 40;
        private UInt32 explosiveP = 40;
        private UInt32 stamina = 40;
        private UInt32 swerve = 40;
        private UInt32 playingAttitude = 0;
        private UInt32 age = 15;
        private UInt32 loftedPass = 40;
        private UInt32 physical = 40;
        private UInt32 bodyControl = 40;
        private UInt32 attack = 40;
        private UInt32 wcUsage = 1;
        private UInt32 dmf = 0;
        private UInt32 starPlayerIndicator = 0;
        private UInt32 runningArm = 0;
        private UInt32 driblingArm = 0;
        private UInt32 cornerKick = 0;
        private UInt32 form = 1;
        private UInt32 position = 2;
        private UInt32 freeKick = 0;
        private UInt32 playingStyle = 0;
        private UInt32 pinCrossing;
        private UInt32 sombrero;
        private UInt32 runningH = 0;
        private UInt32 ss = 0;
        private UInt32 unk2 = 0;
        private UInt32 rwf = 0;
        private UInt32 lmf = 0;
        private UInt32 rb = 0;
        private UInt32 lwf = 0;
        private UInt32 cf = 0;
        private UInt32 cb = 0;
        private UInt32 driblingH = 0;
        private UInt32 amf = 0;
        private UInt32 weakFootAcc = 1;
        private UInt32 rmf = 0;
        private UInt32 injuryRes = 1;
        private UInt32 cmf = 0;
        private UInt32 speedingBullet = 0;
        private UInt32 schotMove = 0;
        private UInt32 gkLong = 0;
        private UInt32 longThrow = 0;
        private UInt32 scissorFeint = 0;
        private UInt32 trackBack = 0;
        private UInt32 superSub = 0;
        private UInt32 rabona = 0;
        private UInt32 acrobatingFinishing = 0;
        private UInt32 strongerFoot = 0;
        private UInt32 knucleShot = 0;
        private UInt32 firstTimeShot = 0;
        private UInt32 comIncisiveRun = 0;
        private UInt32 strongerHand = 0;
        private UInt32 hiddenPlayer = 0;
        private UInt32 comLongRanger = 0;
        private UInt32 oneTouchPass = 0;
        private UInt32 hellTick = 0;
        private UInt32 unk4 = 0;
        private UInt32 manMarking = 0;
        private UInt32 legendGoldenBall = 0;
        private UInt32 marseilleTurn = 0;
        private UInt32 heading = 0;
        private UInt32 outsideCurler = 0;
        private UInt32 captaincy = 0;
        private UInt32 malicia = 0;
        private UInt32 lowPuntTrajectory = 0;
        private UInt32 comTrickster = 0;
        private UInt32 lowLoftedPass = 0;
        private UInt32 fightingSpirit = 0;
        private UInt32 flipFlap = 0;
        private UInt32 weightnessPass = 0;
        private UInt32 unk6 = 0;
        private UInt32 unk7 = 0;
        private UInt32 unk8 = 0;
        private UInt32 comMazingRun = 0;
        private UInt32 acrobatingClear = 0;
        private UInt32 comBallExpert = 0;
        private UInt32 cutBehind = 0;
        private UInt32 longRange = 0;

        public Player(UInt32 id)
        {
    	    if (id < 0 || id > 4294967295)
                throw new ArgumentException("Player's id isn't valid: " + id);
    	
            this.id = id;
        }

        public UInt32 getId()
        {
            return this.id;
        }

        public UInt32 getYouthPlayerId()
        {
            return this.youthPlayerId;
        }

        public UInt32 getFinishing()
        {
            return this.finishing;
        }

        public UInt32 getLongRange()
        {
            return this.longRange;
        }

        public UInt32 getCutBehind()
        {
            return this.cutBehind;
        }

        public UInt32 getComBallExpert()
        {
            return this.comBallExpert;
        }

        public UInt32 getAcrobatingClear()
        {
            return this.acrobatingClear;
        }

        public UInt32 getComMazingRun()
        {
            return this.comMazingRun;
        }

        public UInt32 getUnk8()
        {
            return this.unk8;
        }

        public UInt32 getUnk7()
        {
            return this.unk7;
        }

        public UInt32 getUnk6()
        {
            return this.unk6;
        }

        public UInt32 getWeightnessPass()
        {
            return this.weightnessPass;
        }

        public UInt32 getFlipFlap()
        {
            return this.flipFlap;
        }

        public UInt32 getFightingSpirit()
        {
            return this.fightingSpirit;
        }

        public UInt32 getLowLoftedPass()
        {
            return this.lowLoftedPass;
        }

        public UInt32 getComTrickster()
        {
            return this.comTrickster;
        }

        public UInt32 getLowPuntTrajectory()
        {
            return this.lowPuntTrajectory;
        }

        public UInt32 getMalicia()
        {
            return this.malicia;
        }

        public UInt32 getCaptaincy()
        {
            return this.captaincy;
        }

        public UInt32 getOutsideCurler()
        {
            return this.outsideCurler;
        }

        public UInt32 getHeading()
        {
            return this.heading;
        }

        public UInt32 getMarseilleTurn()
        {
            return this.marseilleTurn;
        }

        public UInt32 getLegendGoldenBall()
        {
            return this.legendGoldenBall;
        }

        public UInt32 getManMarking()
        {
            return this.manMarking;
        }

        public UInt32 getUnk4()
        {
            return this.unk4;
        }

        public UInt32 getHellTick()
        {
            return this.hellTick;
        }

        public UInt32 getOneTouchPass()
        {
            return this.oneTouchPass;
        }

        public UInt32 getComLongRanger()
        {
            return this.comLongRanger;
        }

        public UInt32 getHiddenPlayer()
        {
            return this.hiddenPlayer;
        }

        public UInt32 getStrongerHand()
        {
            return this.strongerHand;
        }

        public UInt32 getComIncisiveRun()
        {
            return this.comIncisiveRun;
        }

        public UInt32 getFirstTimeShot()
        {
            return this.firstTimeShot;
        }

        public UInt32 getKnucleShot()
        {
            return this.knucleShot;
        }

        public UInt32 getStrongerFoot()
        {
            return this.strongerFoot;
        }

        public UInt32 getAcrobatingFinishing()
        {
            return this.acrobatingFinishing;
        }

        public UInt32 getRabona()
        {
            return this.rabona;
        }

        public UInt32 getSuperSub()
        {
            return this.superSub;
        }

        public UInt32 getTrackBack()
        {
            return this.trackBack;
        }

        public UInt32 getScissorFeint()
        {
            return this.scissorFeint;
        }

        public UInt32 getLongThrow()
        {
            return this.longThrow;
        }

        public UInt32 getGkLong()
        {
            return this.gkLong;
        }

        public UInt32 getSchotMove()
        {
            return this.schotMove;
        }

        public UInt32 getSpeedingBullet()
        {
            return this.speedingBullet;
        }

        public UInt32 getCmf()
        {
            return this.cmf;
        }

        public UInt32 getWeakFootAcc()
        {
            return this.weakFootAcc;
        }

        public UInt32 getRmf()
        {
            return this.rmf;
        }

        public UInt32 getInjuryRes()
        {
            return this.injuryRes;
        }

        public UInt32 getAmf()
        {
            return this.amf;
        }

        public UInt32 getDriblingH()
        {
            return this.driblingH;
        }

        public UInt32 getCb()
        {
            return this.cb;
        }

        public UInt32 getCf()
        {
            return this.cf;
        }

        public UInt32 getLwf()
        {
            return this.lwf;
        }

        public UInt32 getRb()
        {
            return this.rb;
        }

        public UInt32 getLmf()
        {
            return this.lmf;
        }

        public UInt32 getRwf()
        {
            return this.rwf;
        }

        public UInt32 getUnk2()
        {
            return this.unk2;
        }

        public UInt32 getSs()
        {
            return this.ss;
        }

        public UInt32 getRunningH()
        {
            return this.runningH;
        }

        public UInt32 getSombrero()
        {
            return this.sombrero;
        }

        public UInt32 getPinCrossing()
        {
            return this.pinCrossing;
        }

        public UInt32 getPlayingStyle()
        {
            return this.playingStyle;
        }

        public UInt32 getFreeKick()
        {
            return this.freeKick;
        }

        public UInt32 getPosition()
        {
            return this.position;
        }

        public UInt32 getForm()
        {
            return this.form;
        }

        public UInt32 getCornerKick()
        {
            return this.cornerKick;
        }

        public UInt32 getDriblingArm()
        {
            return this.driblingArm;
        }

        public UInt32 getRunningArm()
        {
            return this.runningArm;
        }

        public UInt32 getStarPlayerIndicator()
        {
            return this.starPlayerIndicator;
        }

        public UInt32 getDmf()
        {
            return this.dmf;
        }

        public UInt32 getWcUsage()
        {
            return this.wcUsage;
        }

        public UInt32 getAttack()
        {
            return this.attack;
        }

        public UInt32 getBodyControl()
        {
            return this.bodyControl;
        }

        public UInt32 getPhysical()
        {
            return this.physical;
        }

        public UInt32 getLoftedPass()
        {
            return this.loftedPass;
        }

        public UInt32 getAge()
        {
            return this.age;
        }

        public UInt32 getPlayingAttitude()
        {
            return this.playingAttitude;
        }

        public UInt32 getSwerve()
        {
            return this.swerve;
        }

        public UInt32 getStamina()
        {
            return this.stamina;
        }

        public UInt32 getExplosiveP()
        {
            return this.explosiveP;
        }

        public UInt32 getDribbling()
        {
            return this.dribbling;
        }

        public UInt32 getKickingPower()
        {
            return this.kickingPower;
        }

        public UInt32 getPenaltyKick()
        {
            return this.penaltyKick;
        }

        public UInt32 getSpeed()
        {
            return this.speed;
        }

        public UInt32 getBallWinning()
        {
            return this.ballWinning;
        }

        public UInt32 getReflexes()
        {
            return this.reflexes;
        }

        public UInt32 getGoalkeeping()
        {
            return this.goalkeeping;
        }

        public UInt32 getGk()
        {
            return this.gk;
        }

        public UInt32 getBallControll()
        {
            return this.ballControll;
        }

        public UInt32 getHeader()
        {
            return this.header;
        }

        public UInt32 getJump()
        {
            return this.jump;
        }

        public UInt32 getCathing()
        {
            return this.cathing;
        }

        public UInt32 getCoverage()
        {
            return this.coverage;
        }

        public UInt32 getLb()
        {
            return this.lb;
        }

        public UInt32 getGoalCelebrate()
        {
            return this.goalCelebrate;
        }

        public UInt32 getLowPass()
        {
            return this.lowPass;
        }

        public UInt32 getPlaceKick()
        {
            return this.placeKick;
        }

        public UInt32 getClearing()
        {
            return this.clearing;
        }

        public UInt32 getDefense()
        {
            return this.defense;
        }

        public UInt32 getEarlyCross()
        {
            return this.earlyCross;
        }

        public UInt32 getNational2()
        {
            return this.national2;
        }

        public UInt32 getNational()
        {
            return this.national;
        }

        public UInt32 getWeight()
        {
            return this.weight;
        }

        public UInt32 getHeight()
        {
            return this.height;
        }

        public string getName()
        {
            return this.name;
        }

        public string getShirtName()
        {
            return this.shirtName;
        }
    
        public string getJapanese()
        {
            return this.japanese;
        }

        public void setId(UInt32 id)
        {
            if (id < 0 || id > 4294967295)
                throw new ArgumentException("Player's id isn't valid: " + id);
            this.id = id;
        }
    
        public void setJapanese(string japanese) {
    	    //if (japanese == null || japanese == "")
    		    //throw new ArgumentException("Player's japanese name isn't valid - " + getName());
    	
		    this.japanese = japanese;
	    }

        public void setLongRange(UInt32 longRange)
        {
            this.longRange = longRange;
            return;
        }

        public void setCutBehind(UInt32 cutBehind)
        {
            this.cutBehind = cutBehind;
            return;
        }

        public void setComBallExpert(UInt32 comBallExpert)
        {
            this.comBallExpert = comBallExpert;
            return;
        }

        public void setAcrobatingClear(UInt32 acrobatingClear)
        {
            this.acrobatingClear = acrobatingClear;
            return;
        }

        public void setComMazingRun(UInt32 comMazingRun)
        {
            this.comMazingRun = comMazingRun;
            return;
        }

        public void setUnk8(UInt32 unk8)
        {
            this.unk8 = unk8;
            return;
        }

        public void setUnk7(UInt32 unk7)
        {
            this.unk7 = unk7;
            return;
        }

        public void setUnk6(UInt32 unk6)
        {
            this.unk6 = unk6;
            return;
        }

        public void setWeightnessPass(UInt32 weightnessPass)
        {
            this.weightnessPass = weightnessPass;
            return;
        }

        public void setFlipFlap(UInt32 flipFlap)
        {
            this.flipFlap = flipFlap;
            return;
        }

        public void setFightingSpirit(UInt32 fightingSpirit)
        {
            this.fightingSpirit = fightingSpirit;
            return;
        }

        public void setLowLoftedPass(UInt32 lowLoftedPass)
        {
            this.lowLoftedPass = lowLoftedPass;
            return;
        }

        public void setComTrickster(UInt32 comTrickster)
        {
            this.comTrickster = comTrickster;
            return;
        }

        public void setLowPuntTrajectory(UInt32 lowPuntTrajectory)
        {
            this.lowPuntTrajectory = lowPuntTrajectory;
            return;
        }

        public void setMalicia(UInt32 malicia)
        {
            this.malicia = malicia;
            return;
        }

        public void setCaptaincy(UInt32 captaincy)
        {
            this.captaincy = captaincy;
            return;
        }

        public void setOutsideCurler(UInt32 outsideCurler)
        {
            this.outsideCurler = outsideCurler;
            return;
        }

        public void setHeading(UInt32 heading)
        {
            this.heading = heading;
            return;
        }

        public void setMarseilleTurn(UInt32 marseilleTurn)
        {
            this.marseilleTurn = marseilleTurn;
            return;
        }

        public void setLegendGoldenBall(UInt32 legendGoldenBall)
        {
            this.legendGoldenBall = legendGoldenBall;
            return;
        }

        public void setManMarking(UInt32 manMarking)
        {
            this.manMarking = manMarking;
            return;
        }

        public void setUnk4(UInt32 unk4)
        {
            this.unk4 = unk4;
            return;
        }

        public void setHellTick(UInt32 hellTick)
        {
            this.hellTick = hellTick;
            return;
        }

        public void setOneTouchPass(UInt32 oneTouchPass)
        {
            this.oneTouchPass = oneTouchPass;
            return;
        }

        public void setComLongRanger(UInt32 comLongRanger)
        {
            this.comLongRanger = comLongRanger;
            return;
        }

        public void setHiddenPlayer(UInt32 hiddenPlayer)
        {
            this.hiddenPlayer = hiddenPlayer;
            return;
        }

        public void setStrongerHand(UInt32 strongerHand)
        {
            this.strongerHand = strongerHand;
            return;
        }

        public void setComIncisiveRun(UInt32 comIncisiveRun)
        {
            this.comIncisiveRun = comIncisiveRun;
            return;
        }

        public void setFirstTimeShot(UInt32 firstTimeShot)
        {
            this.firstTimeShot = firstTimeShot;
            return;
        }

        public void setKnucleShot(UInt32 knucleShot)
        {
            this.knucleShot = knucleShot;
            return;
        }

        public void setStrongerFoot(UInt32 strongerFoot)
        {
            this.strongerFoot = strongerFoot;
            return;
        }

        public void setAcrobatingFinishing(UInt32 acrobatingFinishing)
        {
            this.acrobatingFinishing = acrobatingFinishing;
            return;
        }

        public void setRabona(UInt32 rabona)
        {
            this.rabona = rabona;
            return;
        }

        public void setSuperSub(UInt32 superSub)
        {
            this.superSub = superSub;
            return;
        }

        public void setTrackBack(UInt32 trackBack)
        {
            this.trackBack = trackBack;
            return;
        }

        public void setScissorFeint(UInt32 scissorFeint)
        {
            this.scissorFeint = scissorFeint;
            return;
        }

        public void setLongThrow(UInt32 longThrow)
        {
            this.longThrow = longThrow;
            return;
        }

        public void setGkLong(UInt32 gkLong)
        {
            this.gkLong = gkLong;
            return;
        }

        public void setSchotMove(UInt32 schotMove)
        {
            this.schotMove = schotMove;
            return;
        }

        public void setSpeedingBullet(UInt32 speedingBullet)
        {
            this.speedingBullet = speedingBullet;
            return;
        }

        public void setFinishing(UInt32 finishing)
        {
    	    if (finishing < 40)
                this.finishing = 40;
            if (finishing > 99)
                this.finishing = 99;
            //throw new ArgumentException("Player's finishing isn't valid: " + finishing + " - " + getName());
    	
            this.finishing = finishing;
            return;
        }

        public void setCmf(UInt32 cmf)
        {
    	    if (cmf < 0)
                this.cmf = 0;
            if (cmf > 2)
                this.cmf = 2;
            //throw new ArgumentException("Player's cmf isn't valid: " + cmf + " - " + getName());
    	
            this.cmf = cmf;
            return;
        }

        public void setWeakFootAcc(UInt32 weakFootAcc)
        {
    	    if (weakFootAcc < 1)
                this.weakFootAcc = 1;
            if (weakFootAcc > 4)
                this.weakFootAcc = 4;
            //throw new ArgumentException("Player's weak foot acc isn't valid: " + weakFootAcc + " - " + getName());

            this.weakFootAcc = weakFootAcc;
            return;
        }

        public void setRmf(UInt32 rmf)
        {
            if (rmf < 0)
                this.rmf = 0;
            if (rmf > 2)
                this.rmf = 2;
            //throw new ArgumentException("Player's rmf isn't valid: " + rmf + " - " + getName());

            this.rmf = rmf;
            return;
        }

        public void setInjuryRes(UInt32 injuryRes)
        {
    	    if (injuryRes < 1)
                this.injuryRes = 1;
            if (injuryRes > 4)
                this.injuryRes = 4;
            //throw new ArgumentException("Player's injury res isn't valid: " + injuryRes + " - " + getName());
    	
            this.injuryRes = injuryRes;
            return;
        }

        public void setAmf(UInt32 amf)
        {
            if (amf < 0)
                this.amf = 0;
            if (amf > 2)
                this.amf = 2;
            //throw new ArgumentException("Player's amf isn't valid: " + amf + " - " + getName());
    	
            this.amf = amf;
            return;
        }

        public void setDriblingH(UInt32 driblingH)
        {
    	    if (driblingH < 1)
                this.driblingH = 1;
            if (driblingH > 3)
                this.driblingH = 3;
            //throw new ArgumentException("Player's dribling hunching isn't valid: " + driblingH + " - " + getName());

            this.driblingH = driblingH;
            return;
        }

        public void setCb(UInt32 cb)
        {
            if (cb < 0)
                this.cb = 0;
            if (cb > 2)
                this.cb = 2;
            //throw new ArgumentException("Player's cb isn't valid: " + cb + " - " + getName());
    	
            this.cb = cb;
            return;
        }

        public void setCf(UInt32 cf)
        {
            if (cf < 0)
                this.cf = 0;
            if (cf > 2)
                this.cf = 2;
            //throw new ArgumentException("Player's cf isn't valid: " + cf + " - " + getName());
    	
            this.cf = cf;
            return;
        }

        public void setLwf(UInt32 lwf)
        {
            if (lwf < 0)
                this.lwf = 0;
            if (lwf > 2)
                this.lwf = 2;
            //throw new ArgumentException("Player's lwf isn't valid: " + lwf + " - " + getName());
    	
            this.lwf = lwf;
            return;
        }

        public void setRb(UInt32 rb)
        {
            if (rb < 0)
                this.rb = 0;
            if (rb > 2)
                this.rb = 2;
            //throw new ArgumentException("Player's rb isn't valid: " + rb + " - " + getName());
    	
            this.rb = rb;
            return;
        }

        public void setRwf(UInt32 rwf)
        {
            if (rwf < 0)
                this.rwf = 0;
            if (rwf > 2)
                this.rwf = 2;
            //throw new ArgumentException("Player's rwf isn't valid: " + rwf + " - " + getName());
    	
            this.rwf = rwf;
            return;
        }

        public void setLmf(UInt32 lmf)
        {
            if (lmf < 0)
                this.lmf = 0;
            if (lmf > 2)
                this.lmf = 2;
            //throw new ArgumentException("Player's lmf isn't valid: " + lmf + " - " + getName());
    	
            this.lmf = lmf;
            return;
        }

        public void setUnk2(UInt32 unk2)
        {
    	    if (unk2 < 0)
                this.unk2 = 0;
            //throw new ArgumentException("Player's unk2 isn't valid: " + unk2 + " - " + getName());
    	
            this.unk2 = unk2;
            return;
        }

        public void setSs(UInt32 ss)
        {
            if (ss < 0)
                this.ss = 0;
            if (ss > 2)
                this.ss = 2;
            //throw new ArgumentException("Player's ss isn't valid: " + ss + " - " + getName());
    	
            this.ss = ss;
        }

        public void setRunningH(UInt32 runningH)
        {
    	    if (runningH < 1)
                this.runningH = 1;
            if (runningH > 3)
                this.runningH = 3;
            //throw new ArgumentException("Player's running hunching isn't valid: " + runningH + " - " + getName());
    	
            this.runningH = runningH;
        }

        public void setSombrero(UInt32 sombrero)
        {
            this.sombrero = sombrero;
        }

        public void setPinCrossing(UInt32 pinCrossing)
        {
            this.pinCrossing = pinCrossing;
            return;
        }

        public void setPlayingStyle(UInt32 playingStyle)
        {
    	    if (playingStyle < 0)
                this.playingStyle = 0;
            //throw new ArgumentException("Player's playing style isn't valid: " + playingStyle + " - " + getName());
    	
            this.playingStyle = playingStyle;
            return;
        }

        public void setFreeKick(UInt32 freeKick)
        {
    	    if (freeKick < 1)
                this.freeKick = 1;
            if (freeKick > 16)
                this.freeKick = 16;
            //throw new ArgumentException("Player's free kick isn't valid: " + freeKick + " - " + getName());
    	
            this.freeKick = freeKick;
            return;
        }

        public void setPosition(UInt32 position)
        {
            if (position < 0)
                this.position = 0;
            if (position > 12)
                this.position = 12;
            //throw new ArgumentException("Player's position isn't valid: " + position + " - " + getName());
    	
            this.position = position;
        }


        public void setYouthPlayerId(UInt32 youthPlayerId)
        {
            if (youthPlayerId < 0)
                this.youthPlayerId = 0;
            //throw new ArgumentException("Youth player Id isn't valid: " + youthPlayerId + " - " + getName());

            this.youthPlayerId = youthPlayerId;
        }

        public void setForm(UInt32 form)
        {
    	    if (form < 1)
                this.form = 1;
            if (form > 8)
                this.form = 8;
            //throw new ArgumentException("Player's form isn't valid: " + form + " - " + getName());
    	
            this.form = form;
            return;
        }

        public void setCornerKick(UInt32 cornerKick)
        {
    	    if (cornerKick < 1)
                this.cornerKick = 1;
            if (cornerKick > 6)
                this.cornerKick = 6;
            //throw new ArgumentException("Player's corner kick isn't valid: " + cornerKick + " - " + getName());
    	
            this.cornerKick = cornerKick;
        }

        public void setDriblingArm(UInt32 driblingArm)
        {
    	    if (driblingArm < 1)
                this.driblingArm = 1;
            if (driblingArm > 8)
                this.driblingArm = 8;
            //throw new ArgumentException("Player's dribling arm isn't valid: " + driblingArm + " - " + getName());
    	
            this.driblingArm = driblingArm;
        }

        public void setRunningArm(UInt32 runningArm)
        {
    	    if (runningArm < 1)
                this.runningArm = 1;
            if (runningArm > 8)
                this.runningArm = 8;
            //throw new ArgumentException("Player's running arm isn't valid: " + runningArm + " - " + getName());
    	
            this.runningArm = runningArm;
        }

        public void setStarPlayerIndicator(UInt32 starPlayerIndicator)
        {
    	    if (starPlayerIndicator < 1)
                this.starPlayerIndicator = 1;
            if (starPlayerIndicator > 8)
                this.starPlayerIndicator = 8;
            //throw new ArgumentException("Star player indicator isn't valid: " + starPlayerIndicator + " - " + getName());
    	
            this.starPlayerIndicator = starPlayerIndicator;
        }

        public void setDmf(UInt32 dmf)
        {
            if (dmf < 0)
                this.dmf = 0;
            if (dmf > 2)
                this.dmf = 2;
            //throw new ArgumentException("Player's dmf isn't valid: " + dmf + " - " + getName());
    	
            this.dmf = dmf;
        }

        public void setWcUsage(UInt32 wcUsage)
        {
    	    if (wcUsage < 1)
                this.wcUsage = 1;
            if (wcUsage > 4)
                this.wcUsage = 4;
            //throw new ArgumentException("Player's wc usage isn't valid: " + wcUsage + " - " + getName());
    	
            this.wcUsage = wcUsage;
        }

        public void setAttack(UInt32 attack)
        {
    	    if (attack < 40)
                this.attack = 40;
            if (attack > 99)
                this.attack = 99;
            //throw new ArgumentException("Player's attack isn't valid: " + attack + " - " + getName());
    	
            this.attack = attack;
            return;
        }

        public void setBodyControl(UInt32 bodyControl)
        {
            if (bodyControl < 40)
                this.bodyControl = 40;
            if (bodyControl > 99)
                this.bodyControl = 99;
            //throw new ArgumentException("Player's body controll isn't valid: " + bodyControl + " - " + getName());
    	
            this.bodyControl = bodyControl;
            return;
        }

        public void setPhysical(UInt32 physical)
        {
    	    if (physical < 40)
                this.physical = 40;
            if (physical > 99)
                this.physical = 99;
            //throw new ArgumentException("Player's physical isn't valid: " + physical + " - " + getName());
    	
            this.physical = physical;
            return;
        }

        public void setLoftedPass(UInt32 loftedPass)
        {
    	    if (loftedPass < 40)
                this.loftedPass = 40;
            if (loftedPass > 99)
                this.loftedPass = 99;
            //throw new ArgumentException("Player's lofted pass isn't valid: " + loftedPass + " - " + getName());
    	
            this.loftedPass = loftedPass;
            return;
        }

        public void setAge(UInt32 age)
        {
    	    if (age < 15)
                this.age = 15;
            if (age > 48)
                this.age = 48;
            //throw new ArgumentException("Player's age isn't valid: " + age + " - " + getName());
    	
            this.age = age;
            return;
        }

        public void setPlayingAttitude(UInt32 playingAttitude)
        {
    	    if (playingAttitude < 0)
                this.playingAttitude = 0;
            //throw new ArgumentException("Player's playing attitude isn't valid: " + playingAttitude + " - " + getName());
    	
            this.playingAttitude = playingAttitude;
            return;
        }

        public void setSwerve(UInt32 swerve)
        {
    	    if (swerve < 40)
                this.swerve = 40;
            if (swerve > 99)
                this.swerve = 99;
            //throw new ArgumentException("Player's swerve isn't valid: " + swerve + " - " + getName());
    	
            this.swerve = swerve;
            return;
        }

        public void setStamina(UInt32 stamina)
        {
    	    if (stamina < 40)
                this.stamina = 40;
            if (stamina > 99)
                this.stamina = 99;
            //throw new ArgumentException("Player's stamina isn't valid: " + stamina + " - " + getName());
    	
            this.stamina = stamina;
            return;
        }

        public void setExplosiveP(UInt32 explosiveP)
        {
    	    if (explosiveP < 40)
                this.explosiveP = 40;
            if (explosiveP > 99)
                this.explosiveP = 99;
            //throw new ArgumentException("Player's explosive power isn't valid: " + explosiveP + " - " + getName());
    	
            this.explosiveP = explosiveP;
            return;
        }

        public void setDribbling(UInt32 dribbling)
        {
    	    if (dribbling < 40)
                this.dribbling = 40;
            if (dribbling > 99)
                this.dribbling = 99;
            //throw new ArgumentException("Player's dribbling isn't valid: " + dribbling + " - " + getName());
    	
            this.dribbling = dribbling;
            return;
        }

        public void setKickingPower(UInt32 kickingPower)
        {
    	    if (kickingPower < 40)
                this.kickingPower = 40;
            if (kickingPower > 99)
                this.kickingPower = 99;
            //throw new ArgumentException("Player's kicking power isn't valid: " + kickingPower + " - " + getName());
    	
            this.kickingPower = kickingPower;
            return;
        }

        public void setPenaltyKick(UInt32 penaltyKick)
        {
    	    if (penaltyKick < 0)
                this.penaltyKick = 0;
            if (penaltyKick > 4)
                this.penaltyKick = 4;
            //throw new ArgumentException("Player's penalty kick isn't valid: " + penaltyKick + " - " + getName());
    	
            this.penaltyKick = penaltyKick;
            return;
        }

        public void setSpeed(UInt32 speed)
        {
    	    if (speed < 40)
                this.speed = 40;
            if (speed > 99)
                this.speed = 99;
            //throw new ArgumentException("Player's speed isn't valid: " + speed + " - " + getName());
    	
            this.speed = speed;
            return;
        }

        public void setBallWinning(UInt32 ballWinning)
        {
    	    if (ballWinning < 40)
                this.ballWinning = 40;
            if (ballWinning > 99)
                this.ballWinning = 99;
            //throw new ArgumentException("Player's ball winning isn't valid: " + ballWinning + " - " + getName());
    	
            this.ballWinning = ballWinning;
            return;
        }

        public void setReflexes(UInt32 reflexes)
        {
    	    if (reflexes < 40)
                this.reflexes = 40;
            if (reflexes > 99)
                this.reflexes = 99;
            //throw new ArgumentException("Player's reflexes isn't valid: " + reflexes + " - " + getName());
    	
            this.reflexes = reflexes;
            return;
        }

        public void setGoalkeeping(UInt32 goalkeeping)
        {
    	    if (goalkeeping < 40)
                this.goalkeeping = 40;
            if (goalkeeping > 99)
                this.goalkeeping = 99;
            //throw new ArgumentException("Player's goalkeeping isn't valid: " + goalkeeping + " - " + getName());
    	
            this.goalkeeping = goalkeeping;
            return;
        }

        public void setGk(UInt32 gk)
        {
            if (gk < 0)
                this.gk = 0;
            if (gk > 2)
                this.gk = 2;
            //throw new ArgumentException("Player's gk isn't valid: " + gk + " - " + getName());
    	
            this.gk = gk;
            return;
        }

        public void setBallControll(UInt32 ballControll)
        {
    	    if (ballControll < 40)
                this.ballControll = 40;
            if (ballControll > 99)
                this.ballControll = 99;
            //throw new ArgumentException("Player's ball controll isn't valid: " + ballControll + " - " + getName());
    	
            this.ballControll = ballControll;
            return;
        }

        public void setHeader(UInt32 header)
        {
    	    if (header < 40)
                this.header = 40;
            if (header > 99)
                this.header = 99;
            //throw new ArgumentException("Player's header isn't valid: " + header + " - " + getName());
    	
            this.header = header;
            return;
        }

        public void setJump(UInt32 jump)
        {
    	    if (jump < 40)
                this.jump = 40;
            if (jump > 99)
                this.jump = 99;
            //throw new ArgumentException("Player's jump isn't valid: " + jump + " - " + getName());
    	
            this.jump = jump;
            return;
        }

        public void setCathing(UInt32 cathing)
        {
    	    if (cathing < 40)
                this.cathing = 40;
            if (cathing > 99)
                this.cathing = 99;
            //throw new ArgumentException("Player's cathing isn't valid: " + cathing + " - " + getName());
    	
            this.cathing = cathing;
            return;
        }

        public void setCoverage(UInt32 coverage)
        {
    	    if (coverage < 40)
                this.coverage = 40;
            if (coverage > 99)
                this.coverage = 99;
            //throw new ArgumentException("Player's coverage isn't valid: " + coverage + " - " + getName());
    	
            this.coverage = coverage;
            return;
        }

        public void setLb(UInt32 lb)
        {
            if (lb < 0)
                this.lb = 0;
            if (lb > 2)
                this.lb = 2;
            //throw new ArgumentException("Player's lb isn't valid: " + lb + " - " + getName());
    	
            this.lb = lb;
            return;
        }

        public void setGoalCelebrate(UInt32 goalCelebrate)
        {
    	    if (goalCelebrate < 0)
                this.goalCelebrate = 0;
            //throw new ArgumentException("Player's goal celebrate isn't valid: " + goalCelebrate + " - " + getName());
    	
            this.goalCelebrate = goalCelebrate;
            return;
        }

        public void setLowPass(UInt32 lowPass)
        {
    	    if (lowPass < 40)
                this.lowPass = 40;
            if (lowPass > 99)
                this.lowPass = 99;
            //throw new ArgumentException("Player's low pass isn't valid: " + lowPass + " - " + getName());
    	
            this.lowPass = lowPass;
            return;
        }

        public void setPlaceKick(UInt32 placeKick)
        {
    	    if (placeKick < 40)
                this.placeKick = 40;
            if (placeKick > 99)
                this.placeKick = 99;
            //throw new ArgumentException("Player's place kick isn't valid: " + placeKick + " - " + getName());
    	
            this.placeKick = placeKick;
            return;
        }

        public void setClearing(UInt32 clearing)
        {
    	    if (clearing < 40)
                this.clearing = 40;
            if (clearing > 99)
                this.clearing = 99;
            //throw new ArgumentException("Player's clearing isn't valid: " + clearing + " - " + getName());
    	
            this.clearing = clearing;
            return;
        }

        public void setDefense(UInt32 defense)
        {
    	    if (defense < 40)
                this.defense = 40;
            if (defense > 99)
                this.defense = 99;
            //throw new ArgumentException("Player's defense isn't valid: " + defense + " - " + getName());
    	
            this.defense = defense;
            return;
        }

        public void setEarlyCross(UInt32 earlyCross)
        {
            this.earlyCross = earlyCross;
            return;
        }

        public void setNational(UInt32 national)
        {
    	    if (national < 0)
                this.national = 215;
            //throw new ArgumentException("Player's nationality isn't valid: " + national + " - " + getName());
    	
            this.national = national;
            return;
        }

        public void setNational2(UInt32 national2)
        {
    	    if (national2 < 0)
                this.national2 = 0;
            //throw new ArgumentException("Player's second nationality isn't valid: " + national2 + " - " + getName());
    	
            this.national2 = national2;
            return;
        }

        public void setHeight(UInt32 height)
        {
    	    if (height < 100)
                this.height = 100;
            if (height > 227)
                this.height = 227;
            //throw new ArgumentException("Player's height isn't valid: " + height + " - " + getName());

            this.height = height;
            return;
        }

        public void setWeight(UInt32 weight)
        {
    	    if (weight < 30)
                this.weight = 30;
            if (weight > 157)
                this.weight = 157;
            //throw new ArgumentException("Player's weight isn't valid: " + weight + " - " + getName());
    	
            this.weight = weight;
            return;
        }

        public void setName(string name)
        {
            if (name == null || name == "")
                this.name = "Player without name";
            //throw new ArgumentException("Player's name isn't valid - Id player: " + getId() + ")");

            this.name = name;
            return;
        }

        public void setShirtName(string shirtName)
        {
    	    if (shirtName == null || shirtName == "")
                this.shirtName = "Player without name";
            //throw new ArgumentException("Player's shirt name isn't valid - " + getName());
    	
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

        public string getStringStrongerFoot()
        {
            if (getStrongerFoot() == 1)
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

        public override string ToString()
        {
    	    return getName();
        }

        //vincoli mancanti: goal celebrate, national, national2, playingAttitude, playingStyle, unk2
    }
}

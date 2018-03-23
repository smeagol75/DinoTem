using System;
using System.IO;
using System.Windows.Forms;

public sealed class skills
{
    //PES 14/PES 15/PES 16

    /*
    Overall (GK) = [(goalkeeping-25)*0.52 + (Saving-25)*0.52 + (Body Balance-25)*0,12 + (jump-25)*0,12)] + 7

    Overall (SS) = [(Attacking Prowess-25)*0.16 + (Ball Control-25)*0.2 + (dribbling-25)*0,2 + (Low Pass-25)*0,1 + (Lofted Pass-25)*0,1 + (finishing-25)*0.15 + (Kicking Power-25)*0,06 + (speed-25)*0,1 + (Explosive Power-25)*0,2 + (Body Balance-25)*0,07 + (stamina-25)*0,04] + 7

    Overall (CF) = (Attacking Prowess - 25) * 0,33 + (Ball Control - 25) * 0,25 + (dribbling - 25) * 0,15 + (finishing - 25) * 0,38 + (header - 25) * 0,03 + (speed - 25) * 0,05 + (Explosive Power - 25) * 0,05 + (Body Balance - 25) * 0,1 + (jump - 25) * 0,03 + 7

    Overall (CB) = (header - 25) * 0,2 + (Defensive Prowess - 25) * 0,27 + (Ball Winning - 25) * 0,27 + (speed - 25) * 0,11 + (Body Balance - 25) * 0,21 + (jump - 25) * 0,21 + (stamina - 25) * 0,1 + 7


    Overall ( DMF ) = (Attacking Prowess - 25) * 0,07 + (Ball Control - 25) * 0,19 + (dribbling - 25) * 0,16 + (Low Pass - 25) * 0,19 + (Loft Pass - 25) * 0,2 + (Controlled Spin - 25) * 0,13 + (Defensive Prowess - 25) * 0,07 + (Ball Winning - 25) * 0,03 + (speed - 25) * 0,03 + (Explosive Power - 25) * 0,03 + (Body Balance - 25) * 0,14 + (jump - 25) * 0,05 + (stamina - 25) * 0,15 + 8

    Overall (CMF) = (Attacking Prowess - 25) * 0,05 + (Ball Control - 25) * 0,25 + (dribbling - 25) * 0,25 + (Low Pass - 25) * 0,25 + (Loft Pass - 25) * 0,22 + (Defensive Prowess - 25) * 0,03 + (speed - 25) * 0,04 + (Explosive Power - 25) * 0,06 + (Body Balance - 25) * 0,05 + (stamina - 25) * 0,18 + 7

    Overall (AMF) = (Attacking Prowess - 25) * 0,15 + (Ball Control - 25) * 0,23 + (dribbling - 25) * 0,23 + (Low Pass - 25) * 0,23 + (Loft Pass - 25) * 0,15 + (finishing - 25) * 0,18 + (speed - 25) * 0,05 + (Explosive Power - 25) * 0,07 + (Body Balance - 25) * 0,05 + (stamina - 25) * 0,03 + 7

    Overall(RMF) = Overall(LMF) = (Attacking Prowess - 25) * 0,07 + (Ball Control - 25) * 0,16 + (dribbling - 25) * 0,26 + (Low Pass - 25) * 0,07 + (Loft Pass - 25) * 0,13 + (Controlled Spin - 25) * 0,04 + (speed - 25) * 0,26 + (Explosive Power - 25) * 0,23 + (stamina - 25) * 0,14 + 7

    Overall (RB) = Overall (LB) = (Attacking Prowess - 25) * 0,06 + (Ball Control - 25) * 0,1 + (dribbling - 25) * 0,15 + (Loft Pass - 25) * 0,15 + (Defensive Prowess - 25) * 0,15 + (Ball Winning - 25) * 0,14 + (speed - 25) * 0,15 + (Explosive Power - 25) * 0,15 + (Body Balance - 25) * 0,12 + (jump - 25) * 0,12 + (stamina - 25) * 0,13 + 8

    Overall (LWF) = Overall (RWF) = (Attacking Prowess - 25) * 0,18 + (Ball Control - 25) * 0,22 + (dribbling - 25) * 0,22 + (Low Pass - 25) * 0,05 + (Loft Pass - 25) * 0,1 + (finishing - 25) * 0,12 + (Kicking Power - 25) * 0,05 + (speed - 25) * 0,16 + (Explosive Power - 25) * 0,16 + (Body Balance - 25) * 0,06 + (stamina - 25) * 0,06 + 9*/

    public static UInt32 calculateMaxRaking(UInt32 position, UInt32 goalkeeping, UInt32 catching, UInt32 clearing, UInt32 reflexes, UInt32 coverage, UInt32 physicalContact, UInt32 bodyControll, UInt32 jump,
        UInt32 header, UInt32 defensiveProwess, UInt32 ballWinning, UInt32 speed, UInt32 stamina, UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 loftedPass, UInt32 explosivePower,
        UInt32 lowPass, UInt32 swerve, UInt32 finishing, UInt32 kickingPower)
    {
        switch (position)
        {
            case 0: return skills.gk(goalkeeping, catching, clearing, reflexes, coverage, physicalContact, bodyControll, jump);
            case 1: return skills.cb(header, defensiveProwess, ballWinning, speed, physicalContact, bodyControll, jump, stamina);
            case 2: return skills.lbRb(attackingProwess, ballControl, dribbling, loftedPass, defensiveProwess, ballWinning, explosivePower, physicalContact, bodyControll, speed, jump, stamina);
            case 3: return skills.lbRb(attackingProwess, ballControl, dribbling, loftedPass, defensiveProwess, ballWinning, explosivePower, physicalContact, bodyControll, speed, jump, stamina);
            case 4: return skills.dmf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, swerve, defensiveProwess, ballWinning, speed, explosivePower, physicalContact, bodyControll, jump, stamina);
            case 5: return skills.cmf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, defensiveProwess, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 6: return skills.lmfRmf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, finishing, kickingPower, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 7: return skills.amf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, finishing, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 8: return skills.lmfRmf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, finishing, kickingPower, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 9: return skills.lwfRwf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, finishing, kickingPower, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 10: return skills.lwfRwf(attackingProwess, ballControl, dribbling, lowPass, loftedPass, finishing, kickingPower, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 11: return skills.ss(attackingProwess, ballControl, dribbling, lowPass, loftedPass, finishing, kickingPower, speed, explosivePower, physicalContact, bodyControll, stamina);
            case 12: return skills.cf(attackingProwess, ballControl, dribbling, finishing, header, speed, explosivePower, physicalContact, bodyControll, jump);
            default: return 0;
        }
    }

    public static UInt32 gk(UInt32 goalkeeping, UInt32 catching, UInt32 clearing, UInt32 reflexes, UInt32 coverage, UInt32 physicalContact, UInt32 bodyControll, UInt32 jump)
    {
        double m = ((goalkeeping - 25) * 0.52 + (((reflexes + catching + reflexes + coverage) / 4) - 25) * 0.52 + ((physicalContact + bodyControll)/2- 25) * 0.12 + (jump - 25) * 0.12) + 7;

        return (UInt32)Math.Round(m);
    }

    public static UInt32 cb(UInt32 header, UInt32 defensiveProwess, UInt32 ballWinning, UInt32 speed, UInt32 physicalContact, UInt32 bodyControll, UInt32 jump, UInt32 stamina)
    {
        //
        double m = ((header - 25) * 0.11 + (defensiveProwess - 25) * 0.25 + (ballWinning - 25) * 0.11 + (speed - 25) * 0.13 + ((physicalContact + bodyControll) / 2 - 25) * 0.21 + (jump - 25) * 0.27 + (stamina - 25) * 0.27) + 7;

        return (UInt32)Math.Round(m);
    }

    public static UInt32 lbRb(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 loftedPass, UInt32 defensiveProwess, UInt32 ballWinning, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 speed, UInt32 jump, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.06 + (ballControl - 25) * 0.1 + (dribbling - 25) * 0.15 + (loftedPass - 25) * 0.15 + (defensiveProwess - 25) * 0.15 + (ballWinning - 25) * 0.14 + (speed - 25) * 0.15 + (explosivePower - 25) * 0.15 + ((physicalContact + bodyControll) / 2 - 25) * 0.12 + (jump - 25) * 0.12 + (stamina - 25) * 0.13) + 8 + 3;
        return (UInt32) m;
    }

    public static UInt32 dmf(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 lowPass, UInt32 loftedPass, UInt32 swerve, UInt32 defensiveProwess, UInt32 ballWinning, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 jump, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.07 + (ballControl - 25) * 0.19 + (dribbling - 25) * 0.16 + (lowPass - 25) * 0.19 + (loftedPass - 25) * 0.2 + (swerve - 25) * 0.13 + (defensiveProwess - 25) * 0.07 + (ballWinning - 25) * 0.03 + (speed - 25) * 0.03 + (explosivePower - 25) * 0.03 + ((physicalContact + bodyControll) / 2 - 25) * 0.14 + (jump - 25) * 0.05 + (stamina - 25) * 0.15) + 8;
        return (UInt32) m;
    }

    public static UInt32 cmf(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 lowPass, UInt32 loftedPass, UInt32 defensiveProwess, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.05 + (ballControl - 25) * 0.25 + (dribbling - 25) * 0.25 + (lowPass - 25) * 0.25 + (loftedPass - 25) * 0.22 + (defensiveProwess - 25) * 0.03 + (speed - 25) * 0.04 + (explosivePower - 25) * 0.06 + ((physicalContact + bodyControll) / 2 - 25) * 0.05 + (stamina - 25) * 0.18) + 7;
        return (UInt32) m;
    }

    public static UInt32 lmfRmf(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 lowPass, UInt32 loftedPass, UInt32 finishing, UInt32 kickingPower, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.18 + (ballControl - 25) * 0.22 + (dribbling - 25) * 0.22 + (lowPass - 25) * 0.05 + (loftedPass - 25) * 0.1 + (finishing - 25) * 0.12 + (kickingPower - 25) * 0.05 + (speed - 25) * 0.16 + (explosivePower - 25) * 0.16 + ((physicalContact + bodyControll) / 2 - 25) * 0.06 + (stamina - 25) * 0.06) + 9;
        return (UInt32) m;
    }

    public static UInt32 amf(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 lowPass, UInt32 loftedPass, UInt32 finishing, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.15 + (ballControl - 25) * 0.23 + (dribbling - 25) * 0.23 + (lowPass - 25) * 0.23 + (loftedPass - 25) * 0.15 + (finishing - 25) * 0.18 + (speed - 25) * 0.05 + (explosivePower - 25) * 0.07 + ((physicalContact + bodyControll) / 2 - 25) * 0.05 + (stamina - 25) * 0.03) + 7;
        return (UInt32) m;
    }

    public static UInt32 lwfRwf(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 lowPass, UInt32 loftedPass, UInt32 finishing, UInt32 kickingPower, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.18 + (ballControl - 25) * 0.22 + (dribbling - 25) * 0.22 + (lowPass - 25) * 0.05 + (loftedPass - 25) * 0.1 + (finishing - 25) * 0.12 + (kickingPower - 25) * 0.05 + (speed - 25) * 0.16 + (explosivePower - 25) * 0.16 + ((physicalContact + bodyControll) / 2 - 25) * 0.06 + (stamina - 25) * 0.06) + 9 + 3;
        return (UInt32) m;
    }

    public static UInt32 ss(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 lowPass, UInt32 loftedPass, UInt32 finishing, UInt32 kickingPower, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 stamina)
    {
        double m = ((attackingProwess - 25) * 0.16 + (ballControl - 25) * 0.2 + (dribbling - 25) * 0.2 + (lowPass - 25) * 0.1 + (loftedPass - 25) * 0.1 + (finishing - 25) * 0.15 + (kickingPower - 25) * 0.06 + (speed - 25) * 0.1 + (explosivePower - 25) * 0.2 + ((physicalContact + bodyControll) / 2 - 25) * 0.07 + (stamina - 25) * 0.04) + 6.5;
        return (UInt32) m;
    }

    public static UInt32 cf(UInt32 attackingProwess, UInt32 ballControl, UInt32 dribbling, UInt32 finishing, UInt32 header, UInt32 speed, UInt32 explosivePower, UInt32 physicalContact, UInt32 bodyControll, UInt32 jump)
    {
        double m = ((attackingProwess - 25) * 0.33 + (ballControl - 25) * 0.25 + (dribbling - 25) * 0.15 + (finishing - 25) * 0.38 + (header - 25) * 0.03 + (speed - 25) * 0.05 + (explosivePower - 25) * 0.05 + ((physicalContact + bodyControll) / 2 - 25) * 0.1 + (jump - 25) * 0.03) + 7;
        return (UInt32) m;
    }
}
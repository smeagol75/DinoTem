using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class PlayerAppearance
    {
        private long id;
        private byte unknown1 = 0;
        private byte unknown2 = 0;
        private byte unknown3 = 0;
        private byte unknown4 = 0;
        private byte unknown5 = 0;
        private byte unknown6 = 0;
        private byte unknown7 = 0;
        private byte unknown8 = 0;
        private byte unknown9 = 0;
        private byte unknown10 = 0;
        private byte unknown11 = 0;
        private byte unknown12 = 0;
        private byte unknown13 = 0;
        private byte unknown14 = 0;
        private byte unknown15 = 0;
        private byte unknown16 = 0;
        private byte unknown17 = 0;
        private byte unknown18 = 0;
        private byte unknown19 = 0;
        private byte unknown20 = 0;
        private byte unknown21 = 0;
        private byte unknown22 = 0;
        private byte unknown23 = 0;
        private byte unknown24 = 0;
        private byte unknown25 = 0;
        private byte unknown26 = 0;
        private byte unknown27 = 0;
        private byte unknown28 = 0;
        private byte unknown29 = 0;
        private byte unknown30 = 0;
        private byte unknown31 = 0;
        private byte unknown32 = 0;
        private byte unknown33 = 0;
        private byte unknown34 = 0;
        private byte unknown35 = 0;
        private byte unknown36 = 0;
        private byte eyeskinColor = 0;
        private byte unknown38 = 0;
        private byte unknown39 = 0;
        private byte unknown40 = 0;
        private byte unknown41 = 0;
        private byte unknown42 = 0;
        private byte unknown43 = 0;
        private byte unknown44 = 0;
        private byte unknown45 = 0;
        private byte unknown46 = 0;
        private byte unknown47 = 0;
        private byte unknown48 = 0;
        private byte unknown49 = 0;
        private byte unknown50 = 0;
        private byte unknown51 = 0;
        private byte unknown52 = 0;
        private byte unknown53 = 0;
        private byte unknown54 = 0;
        private byte unknown55 = 0;
        private byte unknown56 = 0;
    
        public PlayerAppearance(long id) {
    	    if (id < 0)
                throw new ArgumentException("Player's appearance id isn't valid: " + id);
    	
    	    this.id = id;
        }

        public long getId()
        {
            return this.id;
        }

        public void setId(long id)
        {
    	    if (id < 0)
                throw new ArgumentException("Player id isn't valid: " + +id);
    	
            this.id = id;
        }

        public byte getUnknown1() {
		    return unknown1;
	    }

	    public void setUnknown1(byte unknown1) {
		    this.unknown1 = unknown1;
	    }

	    public byte getUnknown2() {
		    return unknown2;
	    }

	    public void setUnknown2(byte unknown2) {
		    this.unknown2 = unknown2;
	    }

	    public byte getUnknown3() {
		    return unknown3;
	    }

	    public void setUnknown3(byte unknown3) {
		    this.unknown3 = unknown3;
	    }

	    public byte getUnknown4() {
		    return unknown4;
	    }

	    public void setUnknown4(byte unknown4) {
		    this.unknown4 = unknown4;
	    }

	    public byte getUnknown5() {
		    return unknown5;
	    }

	    public void setUnknown5(byte unknown5) {
		    this.unknown5 = unknown5;
	    }

	    public byte getUnknown6() {
		    return unknown6;
	    }

	    public void setUnknown6(byte unknown6) {
		    this.unknown6 = unknown6;
	    }

	    public byte getUnknown7() {
		    return unknown7;
	    }

	    public void setUnknown7(byte unknown7) {
		    this.unknown7 = unknown7;
	    }

	    public byte getUnknown8() {
		    return unknown8;
	    }

	    public void setUnknown8(byte unknown8) {
		    this.unknown8 = unknown8;
	    }

	    public byte getUnknown9() {
		    return unknown9;
	    }

	    public void setUnknown9(byte unknown9) {
		    this.unknown9 = unknown9;
	    }

	    public byte getUnknown10() {
		    return unknown10;
	    }

	    public void setUnknown10(byte unknown10) {
		    this.unknown10 = unknown10;
	    }

	    public byte getUnknown11() {
		    return unknown11;
	    }

	    public void setUnknown11(byte unknown11) {
		    this.unknown11 = unknown11;
	    }

	    public byte getUnknown12() {
		    return unknown12;
	    }

	    public void setUnknown12(byte unknown12) {
		    this.unknown12 = unknown12;
	    }

	    public byte getUnknown13() {
		    return unknown13;
	    }

	    public void setUnknown13(byte unknown13) {
		    this.unknown13 = unknown13;
	    }

	    public byte getUnknown14() {
		    return unknown14;
	    }

	    public void setUnknown14(byte unknown14) {
		    this.unknown14 = unknown14;
	    }

	    public byte getUnknown15() {
		    return unknown15;
	    }

	    public void setUnknown15(byte unknown15) {
		    this.unknown15 = unknown15;
	    }

	    public byte getUnknown16() {
		    return unknown16;
	    }

	    public void setUnknown16(byte unknown16) {
		    this.unknown16 = unknown16;
	    }

	    public byte getUnknown17() {
		    return unknown17;
	    }

	    public void setUnknown17(byte unknown17) {
		    this.unknown17 = unknown17;
	    }

	    public byte getUnknown18() {
		    return unknown18;
	    }

	    public void setUnknown18(byte unknown18) {
		    this.unknown18 = unknown18;
	    }

	    public byte getUnknown19() {
		    return unknown19;
	    }

	    public void setUnknown19(byte unknown19) {
		    this.unknown19 = unknown19;
	    }

	    public byte getUnknown20() {
		    return unknown20;
	    }

	    public void setUnknown20(byte unknown20) {
		    this.unknown20 = unknown20;
	    }

	    public byte getUnknown21() {
		    return unknown21;
	    }

	    public void setUnknown21(byte unknown21) {
		    this.unknown21 = unknown21;
	    }

	    public byte getUnknown22() {
		    return unknown22;
	    }

	    public void setUnknown22(byte unknown22) {
		    this.unknown22 = unknown22;
	    }

	    public byte getUnknown23() {
		    return unknown23;
	    }

	    public void setUnknown23(byte unknown23) {
		    this.unknown23 = unknown23;
	    }

	    public byte getUnknown24() {
		    return unknown24;
	    }

	    public void setUnknown24(byte unknown24) {
		    this.unknown24 = unknown24;
	    }

	    public byte getUnknown25() {
		    return unknown25;
	    }

	    public void setUnknown25(byte unknown25) {
		    this.unknown25 = unknown25;
	    }

	    public byte getUnknown26() {
		    return unknown26;
	    }

	    public void setUnknown26(byte unknown26) {
		    this.unknown26 = unknown26;
	    }

	    public byte getUnknown27() {
		    return unknown27;
	    }

	    public void setUnknown27(byte unknown27) {
		    this.unknown27 = unknown27;
	    }

	    public byte getUnknown28() {
		    return unknown28;
	    }

	    public void setUnknown28(byte unknown28) {
		    this.unknown28 = unknown28;
	    }

	    public byte getUnknown29() {
		    return unknown29;
	    }

	    public void setUnknown29(byte unknown29) {
		    this.unknown29 = unknown29;
	    }

	    public byte getUnknown30() {
		    return unknown30;
	    }

	    public void setUnknown30(byte unknown30) {
		    this.unknown30 = unknown30;
	    }

	    public byte getUnknown31() {
		    return unknown31;
	    }

	    public void setUnknown31(byte unknown31) {
		    this.unknown31 = unknown31;
	    }

	    public byte getUnknown32() {
		    return unknown32;
	    }

	    public void setUnknown32(byte unknown32) {
		    this.unknown32 = unknown32;
	    }

	    public byte getUnknown33() {
		    return unknown33;
	    }

	    public void setUnknown33(byte unknown33) {
		    this.unknown33 = unknown33;
	    }

	    public byte getUnknown34() {
		    return unknown34;
	    }

	    public void setUnknown34(byte unknown34) {
		    this.unknown34 = unknown34;
	    }

	    public byte getUnknown35() {
		    return unknown35;
	    }

	    public void setUnknown35(byte unknown35) {
		    this.unknown35 = unknown35;
	    }

	    public byte getUnknown36() {
		    return unknown36;
	    }

	    public void setUnknown36(byte unknown36) {
		    this.unknown36 = unknown36;
	    }
	
        public byte getEyeskinColor()
        {
            return this.eyeskinColor;
        }

        public void setEyeskinColor(byte eyeskinColor)
        {
            this.eyeskinColor = eyeskinColor;
            return;
        }

	    public byte getUnknown38() {
		    return unknown38;
	    }

	    public void setUnknown38(byte unknown38) {
		    this.unknown38 = unknown38;
	    }

	    public byte getUnknown39() {
		    return unknown39;
	    }

	    public void setUnknown39(byte unknown39) {
		    this.unknown39 = unknown39;
	    }

	    public byte getUnknown40() {
		    return unknown40;
	    }

	    public void setUnknown40(byte unknown40) {
		    this.unknown40 = unknown40;
	    }

	    public byte getUnknown41() {
		    return unknown41;
	    }

	    public void setUnknown41(byte unknown41) {
		    this.unknown41 = unknown41;
	    }

	    public byte getUnknown42() {
		    return unknown42;
	    }

	    public void setUnknown42(byte unknown42) {
		    this.unknown42 = unknown42;
	    }

	    public byte getUnknown43() {
		    return unknown43;
	    }

	    public void setUnknown43(byte unknown43) {
		    this.unknown43 = unknown43;
	    }

	    public byte getUnknown44() {
		    return unknown44;
	    }

	    public void setUnknown44(byte unknown44) {
		    this.unknown44 = unknown44;
	    }

	    public byte getUnknown45() {
		    return unknown45;
	    }

	    public void setUnknown45(byte unknown45) {
		    this.unknown45 = unknown45;
	    }

	    public byte getUnknown46() {
		    return unknown46;
	    }

	    public void setUnknown46(byte unknown46) {
		    this.unknown46 = unknown46;
	    }

	    public byte getUnknown47() {
		    return unknown47;
	    }

	    public void setUnknown47(byte unknown47) {
		    this.unknown47 = unknown47;
	    }

	    public byte getUnknown48() {
		    return unknown48;
	    }

	    public void setUnknown48(byte unknown48) {
		    this.unknown48 = unknown48;
	    }

	    public byte getUnknown49() {
		    return unknown49;
	    }

	    public void setUnknown49(byte unknown49) {
		    this.unknown49 = unknown49;
	    }

	    public byte getUnknown50() {
		    return unknown50;
	    }

	    public void setUnknown50(byte unknown50) {
		    this.unknown50 = unknown50;
	    }

	    public byte getUnknown51() {
		    return unknown51;
	    }

	    public void setUnknown51(byte unknown51) {
		    this.unknown51 = unknown51;
	    }

	    public byte getUnknown52() {
		    return unknown52;
	    }

	    public void setUnknown52(byte unknown52) {
		    this.unknown52 = unknown52;
	    }

	    public byte getUnknown53() {
		    return unknown53;
	    }

	    public void setUnknown53(byte unknown53) {
		    this.unknown53 = unknown53;
	    }

	    public byte getUnknown54() {
		    return unknown54;
	    }

	    public void setUnknown54(byte unknown54) {
		    this.unknown54 = unknown54;
	    }

	    public byte getUnknown55() {
		    return unknown55;
	    }

	    public void setUnknown55(byte unknown55) {
		    this.unknown55 = unknown55;
	    }

        public byte getUnknown56()
        {
            return unknown56;
        }

        public void setUnknown56(byte unknown56)
        {
            this.unknown56 = unknown56;
        }

        /*public override bool Equals(Object obj)
        {
            if (obj is PlayerAppearance)
    	    {
                PlayerAppearance c = (PlayerAppearance) obj;
    		    return getId() == c.getId();
    	    }
    	    return false;
        }*/
    }
}

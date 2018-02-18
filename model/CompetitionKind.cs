using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class CompetitionKind
    {
        private byte order;
        private byte unk1;
        private byte unk2;
        private byte unk3;

        public CompetitionKind()
        {
        }

        public byte getOrder()
        {
            return this.order;
        }

        public byte getUnk1()
        {
            return this.unk1;
        }

        public byte getUnk2()
        {
            return this.unk2;
        }

        public byte getUnk3()
        {
            return this.unk3;
        }

        public void setOrder(byte order)
        {
            if (order < 0)
                throw new ArgumentException("order isn't valid: " + order);

            this.order = order;
        }

        public void setUnk1(byte unk1)
        {
            if (unk1 < 0)
                throw new ArgumentException("unk1 isn't valid: " + unk1);

            this.unk1 = unk1;
        }

        public void setUnk2(byte unk2)
        {
            if (unk2 < 0)
                throw new ArgumentException("unk2 isn't valid: " + unk2);

            this.unk2 = unk2;
        }

        public void setUnk3(byte unk3)
        {
            if (unk3 < 0)
                throw new ArgumentException("unk3 isn't valid: " + unk3);

            this.unk3 = unk3;
        }
    }
}

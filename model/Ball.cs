using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Ball
    {
        private UInt16 id;
        private byte order;
        private string name;

        public Ball(UInt16 id)
        {
            if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);

            this.id = id;
        }

        public UInt16 getId()
        {
            return this.id;
        }

        public byte getOrder()
        {
            return this.order;
        }

        public string getName()
        {
            return this.name;
        }

        public void setId(UInt16 id)
        {
            if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);

            this.id = id;
        }

        public void setOrder(byte order)
        {
            if (order < 0)
                throw new ArgumentException("Ball's order isn't valid - Id ball: " + getId());

            this.order = order;
        }

        public void setName(string name)
        {
            if (name == null || name == "")
                throw new ArgumentException("Ball's name isn't valid - Id ball: " + getId());

            this.name = name;
        }

        /*public override bool Equals(Object obj)
        {
            if (obj is Ball)
            {
                Ball c = (Ball)obj;
                return getId() == c.getId();
            }
            return false;
        }*/

        public override string ToString()
        {
            return getName();
        }
    }
}

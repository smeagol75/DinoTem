using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class Glove
    {
        private UInt16 id;
        private byte order;
        private string name;
        private string color;

        public Glove(UInt16 id)
        {
            if (id < 0 || id > 65535)
                throw new ArgumentException("Glove's id isn't valid: " + id);

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

        public string getColor()
        {
            return this.color;
        }

        public void setId(UInt16 id)
        {
            if (id < 0 || id > 65535)
                throw new ArgumentException("Glove's id isn't valid: " + id);

            this.id = id;
        }

        public void setOrder(byte order)
        {
            if (order < 0 ||order > 255)
                this.order = 0;
            if (order > 255)
                this.order = 255;
            //throw new ArgumentException("Glove's order isn't valid - Id glove: " + getId());

            this.order = order;
        }

        public void setName(string name)
        {
            if (name == null || name == "")
                this.name = "Glove without name";
            //throw new ArgumentException("Glove's name isn't valid - Id glove: " + getId());

            this.name = name;
        }

        public void setColor(string color)
        {
            if (color == null || color == "")
                this.name = "Color without name";
            //throw new ArgumentException("Glove's color isn't valid - Id glove: " + getId());

            this.color = color;
        }

        public override string ToString()
        {
            return getName();
        }
    }
}

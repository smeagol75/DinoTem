using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18
    public class Boot
    {
        private UInt16 id;
        private byte order;
        private string name;
        private string color;
        private string material;

        public Boot(UInt16 id)
        {
            if (id < 0)
                throw new ArgumentException("Boot's id isn't valid: " + id);

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

        public string getMaterial()
        {
            return this.material;
        }

        public void setId(UInt16 id)
        {
            if (id < 0)
                throw new ArgumentException("Boot's id isn't valid: " + id);

            this.id = id;
        }

        public void setOrder(byte order)
        {
            if (order < 0)
                throw new ArgumentException("Boot's order isn't valid - Id ball: " + getId());

            this.order = order;
        }

        public void setName(string name)
        {
            if (name == null || name == "")
                throw new ArgumentException("Boot's name isn't valid - Id ball: " + getId());

            this.name = name;
        }

        public void setColor(string color)
        {
            if (color == null || color == "")
                throw new ArgumentException("Boot's color isn't valid - Id ball: " + getId());

            this.color = color;
        }

        public void setMaterial(string material)
        {
            if (name == null || name == "")
                throw new ArgumentException("Boot's material isn't valid - Id ball: " + getId());

            this.material = material;
        }

        public override string ToString()
        {
            return getName();
        }
    }
}

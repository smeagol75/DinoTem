using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    //pes 18, pes 17
    public class Ball
    {
        private int id;
        private int order;
        private string name;

        public Ball(int id, int order, string name)
        {
            if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);
            if (order < 0)
                throw new ArgumentException("Ball's order isn't valid - Id ball: " + getId());
            if (name == null || name == "")
                throw new ArgumentException("Ball's name isn't valid - Id ball: " + getId());

            this.id = id;
            this.order = order;
            this.name = name;
        }

        public int getId()
        {
            return this.id;
        }

        public int getOrder()
        {
            return this.order;
        }

        public string getName()
        {
            return this.name;
        }

        public void setId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Ball's id isn't valid: " + id);

            this.id = id;
        }

        public void setOrder(int order)
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

        public override bool Equals(Object obj)
        {
            if (obj is Ball)
            {
                Ball c = (Ball)obj;
                return getId() == c.getId();
            }
            return false;
        }

        public override string ToString()
        {
            return getName();
        }
    }
}

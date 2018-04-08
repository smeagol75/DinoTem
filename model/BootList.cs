using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class BootList
    {
        private UInt32 playerId;
        private UInt16 bootId;

        public BootList(UInt32 playerId)
        {
            if (playerId < 0 || playerId > 4294967295)
                throw new ArgumentException("Player's id isn't valid: " + playerId);

            this.playerId = playerId;
        }

        public UInt32 getPlayerId()
        {
            return this.playerId;
        }

        public UInt16 getBootId()
        {
            return this.bootId;
        }

        public void setId(UInt32 playerId)
        {
            if (playerId < 0 || playerId > 4294967295)
                throw new ArgumentException("Player's id isn't valid: " + playerId);

            this.playerId = playerId;
        }

        public void setBootId(UInt16 bootId)
        {
            if (bootId < 0 || bootId > 65535)
                throw new ArgumentException("Boot's id isn't valid - id player: " + playerId);

            this.bootId = bootId;
        }
    }
}

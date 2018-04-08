using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinoTem.model
{
    public class GloveList
    {
        private UInt32 playerId;
        private UInt16 gloveId;

        public GloveList(UInt32 playerId)
        {
            if (playerId < 0 || playerId > 4294967295)
                throw new ArgumentException("Player's id isn't valid: " + playerId);

            this.playerId = playerId;
        }

        public UInt32 getPlayerId()
        {
            return this.playerId;
        }

        public UInt16 getGloveId()
        {
            return this.gloveId;
        }

        public void setId(UInt32 playerId)
        {
            if (playerId < 0 || playerId > 4294967295)
                throw new ArgumentException("Player's id isn't valid: " + playerId);

            this.playerId = playerId;
        }

        public void setGloveId(UInt16 gloveId)
        {
            if (gloveId < 0 || gloveId > 65535)
                throw new ArgumentException("Glove's id isn't valid - id player: " + playerId);

            this.gloveId = gloveId;
        }
    }
}

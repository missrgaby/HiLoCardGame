using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Class that represent all clubs cards.
    /// </summary>
    public class ClubsCard : ICard
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        public ClubsCard(Ranks rank)
        {
            this.Suit = Suits.Clubs;
            this.Rank = rank;
        }

        public override string ToString()
            => $"{('\u2663').ToString()} {Rank}";
    }
}

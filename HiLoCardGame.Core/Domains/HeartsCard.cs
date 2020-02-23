using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Class that represent all hearts cards.
    /// </summary>
    public class HeartsCard : ICard
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        public HeartsCard(Ranks rank)
        {
            this.Suit = Suits.Hearts;
            this.Rank = rank;
        }

        public override string ToString()
            => $"{('\u2665').ToString()} {Rank}";
    }
}

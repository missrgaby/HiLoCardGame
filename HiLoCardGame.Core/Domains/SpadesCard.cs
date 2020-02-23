using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Class that represent all spades cards.
    /// </summary>
    public class SpadesCard : ICard
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        public SpadesCard(Ranks rank)
        {
            this.Suit = Suits.Spades;
            this.Rank = rank;
        }

        public override string ToString()
            => $"{('\u2660').ToString()} {Rank}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Class that represent all diamonds cards.
    /// </summary>
    public class DiamondsCard : ICard
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        public DiamondsCard(Ranks rank)
        {
            this.Suit = Suits.Diamonds;
            this.Rank = rank;
        }

        public override string ToString()
            => $"{('\u2666').ToString()} {Rank}";
    }
}

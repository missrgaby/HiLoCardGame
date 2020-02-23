using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// A interface used for create a different type of cards i.e. Queen of Hearts, Queen of Spades.
    /// </summary>
    public interface ICard
    {
        Suits Suit { get; set; }
        Ranks Rank { get; set; }
    }
}

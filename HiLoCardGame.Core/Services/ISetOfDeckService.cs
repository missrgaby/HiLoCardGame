using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// An interface used for helping a set of decks with it own tasks 
    /// i.e. shuffle the entire set, get a random card from the set.
    /// </summary>
    public interface ISetOfDeckService
    {
        ICard GetNextCard(List<ICard> setOfDecks);
        bool Shuffle(List<ICard> setOfDecks);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Implement services for a set of deck.
    /// </summary>
    public class SetOfDeckService : ISetOfDeckService
    {
        public ICard GetNextCard(List<ICard> setOfDecks)
        {
            Random rnd = new Random();

            ICard card = setOfDecks[rnd.Next(setOfDecks.Count)];
            setOfDecks.Remove(card);

            return card;
        }

        public bool Shuffle(List<ICard> setOfDecks)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Build a deck of cards with 52 unique cards.
    /// </summary>
    public class Deck
    {
        public List<ICard> DeckOfCards { get; set; }
        public Deck()
        {
            DeckOfCards = new List<ICard>();
            BuildDeck();
        }

        private void BuildDeck()
        {
            foreach (Suits suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks rank in (Ranks[])Enum.GetValues(typeof(Ranks)))
                {
                    ICard newCard;
                    if (suit == Suits.Clubs)
                    {
                        newCard = new ClubsCard(rank);
                    }
                    else if (suit == Suits.Hearts)
                    {
                        newCard = new HeartsCard(rank);
                    }
                    else if (suit == Suits.Spades)
                    {
                        newCard = new SpadesCard(rank);
                    }
                    else
                    {
                        newCard = new DiamondsCard(rank);
                    }
                    DeckOfCards.Add(newCard);
                }
            }
        }

        public void RemoveCardFromDeck(List<ICard> cards)
        {
            foreach (ICard card in cards)
            {
                DeckOfCards.Remove(card);
            }
        }
    }
}

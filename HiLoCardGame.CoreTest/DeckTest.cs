using System;
using System.Linq;
using System.Collections.Generic;
using HiLoCardGame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiLoCardGame.CoreTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void Init_Deck_Constructor()
        {
            Deck deck = new Deck();

            Assert.AreNotEqual(null, deck);
            Assert.IsTrue(deck.DeckOfCards.Count > 0);
        }

        [TestMethod]
        public void A_Deck_Has_52_Cards()
        {
            Deck deck = new Deck();

            Assert.IsTrue(deck.DeckOfCards.Count == 52);
        }

        [TestMethod]
        public void A_Deck_Has_No_Duplicate_Cards()
        {
            Deck deck = new Deck();

            List<ICard> uniqueCards = deck.DeckOfCards.Select(x => x).Distinct().ToList();
            Assert.IsTrue(uniqueCards.Count == 52);
        }

        [TestMethod]
        public void A_Deck_Has_No_Contain_Removed_Cards()
        {
            Deck deck = new Deck();

            List<ICard> removeCards = new List<ICard>();
            removeCards.Add(new ClubsCard(Ranks.Queen));
            removeCards.Add(new DiamondsCard(Ranks.Ace));
            removeCards.Add(new SpadesCard(Ranks.King));
            deck.RemoveCardFromDeck(removeCards);

            foreach (var card in removeCards)
            {
                Assert.IsFalse(deck.DeckOfCards.Contains(card));
            }
        }
    }
}

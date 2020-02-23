using System;
using System.Linq;
using System.Collections.Generic;
using HiLoCardGame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiLoCardGame.CoreTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Init_Game()
        {
            GameSettings setting = new GameSettings();

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.AreNotEqual(null, newPlayer);
            Assert.IsTrue(newPlayer.SetOfDecks.Count > 0);
        }

        [TestMethod]
        public void A_Game_Has_Input_Settings()
        {
            GameSettings setting = new GameSettings();
            setting.NumberOfDecks = 5;
            setting.ExcludeCards.Add(new HeartsCard(Ranks.Jack));
            setting.ExcludeCards.Add(new HeartsCard(Ranks.Queen));
            setting.ExcludeCards.Add(new HeartsCard(Ranks.King));

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == (setting.NumberOfDecks * 52));
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_Get_A_Random_Card()
        {
            GameSettings setting = new GameSettings();

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            newPlayer.NextCard();
            Assert.AreNotEqual(null, newPlayer.FaceUpCard);

            ICard firstCard = newPlayer.FaceUpCard;

            newPlayer.NextCard();
            Assert.AreNotEqual(null, newPlayer.FaceUpCard);

            ICard secondCard = newPlayer.FaceUpCard;

            Assert.AreNotSame(firstCard, secondCard);
        }

    }
}

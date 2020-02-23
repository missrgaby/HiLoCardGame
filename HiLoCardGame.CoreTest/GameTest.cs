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
            
            Assert.AreNotEqual(null, newPlayer);            
        }

        [TestMethod]
        public void A_Game_Is_Initialize()
        {
            GameSettings setting = new GameSettings();
            var newPlayer = new Game(setting);

            newPlayer.BeginGame();

            Assert.IsNull(newPlayer.FaceUpCard);
            Assert.IsTrue(newPlayer.PlayerScore == 0);
            Assert.IsTrue(newPlayer.SetOfDecks.Count > 0);
        }

        [TestMethod]
        public void A_Game_Is_Initialize_For_The_Second_Time()
        {
            GameSettings setting = new GameSettings();
            setting.NumberOfDecks = 5;

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            newPlayer.NextCard();
            newPlayer.NextCard();
            newPlayer.NextCard();
            newPlayer.NextCard();

            newPlayer.BeginGame();

            Assert.IsNull(newPlayer.FaceUpCard);
            Assert.IsTrue(newPlayer.PlayerScore == 0);
            Assert.IsTrue(newPlayer.SetOfDecks.Count == (setting.NumberOfDecks * 52));
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

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 245);
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_Is_Initialize_With_First_Customize_Set_Of_Deck()
        {
            GameSettings setting = ValidateGameRules.GetSettingSetOfDecks(1);

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 416);
        }

        [TestMethod]
        public void A_Game_Is_Initialize_With_Second_Customize_Set_Of_Deck()
        {
            GameSettings setting = ValidateGameRules.GetSettingSetOfDecks(2);

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 64);
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_Is_Initialize_With_Third_Customize_Set_Of_Deck()
        {
            GameSettings setting = ValidateGameRules.GetSettingSetOfDecks(3);

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 36);
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_Is_Initialize_With_Fourth_Customize_Set_Of_Deck()
        {
            GameSettings setting = ValidateGameRules.GetSettingSetOfDecks(4);

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 24);
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_Is_Initialize_With_Fifth_Customize_Set_Of_Deck()
        {
            GameSettings setting = ValidateGameRules.GetSettingSetOfDecks(5);

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 320);
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_Is_Initialize_With_Sixth_Customize_Set_Of_Deck()
        {
            GameSettings setting = ValidateGameRules.GetSettingSetOfDecks(6);

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 48);
            foreach (var card in setting.ExcludeCards)
            {
                Assert.IsFalse(newPlayer.SetOfDecks.Contains(card));
            }
        }

        [TestMethod]
        public void A_Game_With_3_Number_Of_Decks_Contain_155_Cards_After_The_First_Pulling()
        {
            GameSettings setting = new GameSettings();
            setting.NumberOfDecks = 3;

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 156);

            newPlayer.NextCard();

            Assert.IsTrue(newPlayer.SetOfDecks.Count == 155);

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

        [TestMethod]
        public void A_Game_Compare_If_Next_Card_Is_High()
        {
            GameSettings setting = new GameSettings();

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            newPlayer.NextCard();
            
            bool Continue = true;
            while (Continue)
            {
                if (newPlayer.NextCard(1))
                {
                    Continue = false;
                }
            }

            Assert.IsTrue(newPlayer.PlayerScore == 1);
        }

        [TestMethod]
        public void A_Game_Compare_If_Next_Card_Is_Lower()
        {
            GameSettings setting = new GameSettings();

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            newPlayer.NextCard();

            bool Continue = true;
            while (Continue)
            {
                if (newPlayer.NextCard(-1))
                {
                    Continue = false;
                }
            }

            Assert.IsTrue(newPlayer.PlayerScore == 1);
        }

        [TestMethod]
        public void A_Game_Player_Guess_If_All_Next_Cards_Are_Higher()
        {
            GameSettings setting = new GameSettings();

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            newPlayer.NextCard();

            int count = 0;
            bool Continue = true;
            while (Continue)
            {
                count++;
                Continue = newPlayer.NextCard(1);
            }

            if (newPlayer.PlayerScore == count)
            {
                string msg = $"Congratulations! All the cards were guessed, your final score was { newPlayer.PlayerScore.ToString() }";
                Assert.AreEqual(newPlayer.ShowFinalResult().Trim(), msg.Trim());
            }
            else
            {
                string msg = $"Game Over! You lost, the last card was { newPlayer.ShowFaceUpCard() } and your final score was { newPlayer.PlayerScore.ToString() }";
                Assert.AreEqual(newPlayer.ShowFinalResult().Trim(), msg.Trim());
            }
            
        }

        [TestMethod]
        public void A_Game_Player_Guess_If_All_Next_Cards_Are_Lower()
        {
            GameSettings setting = new GameSettings();

            var newPlayer = new Game(setting);
            newPlayer.BeginGame();

            newPlayer.NextCard();

            int count = 0;
            bool Continue = true;
            while (Continue)
            {
                count++;
                Continue = newPlayer.NextCard(-1);
            }

            if (newPlayer.PlayerScore == count)
            {
                string msg = $"Congratulations! All the cards were guessed, your final score was { newPlayer.PlayerScore.ToString() }";
                Assert.AreEqual(newPlayer.ShowFinalResult().Trim(), msg.Trim());
            }
            else
            {
                string msg = $"Game Over! You lost, the last card was { newPlayer.ShowFaceUpCard() } and your final score was { newPlayer.PlayerScore.ToString() }";
                Assert.AreEqual(newPlayer.ShowFinalResult().Trim(), msg.Trim());
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    public class Game
    {       
        private GameSettings Settings { get; set; }
        public List<ICard> SetOfDecks { get; set; }
        private ISetOfDeckService SetOfDeckService;
        public int PlayerScore { get; set; }
        public ICard FaceUpCard { get; set; }

        public Game(GameSettings settings)
        {
            Settings = settings;
            SetOfDecks = new List<ICard>();
            SetOfDeckService = new SetOfDeckService();
        }

        /// <summary>
        /// Game begins by creating a set of decks with all input settings.
        /// </summary>
        public void BeginGame()
        {
            for (int i = 0; i < Settings.NumberOfDecks; i++)
            {
                Deck deck = new Deck();
                deck.RemoveCardFromDeck(Settings.ExcludeCards);
                SetOfDecks.AddRange(deck.DeckOfCards);
            }
        }
        
        /// <summary>
        /// A new card is pulled from the set of deck to be evaluated 
        /// with the previous one. The score is calculated.
        /// </summary>
        /// <param name="res">Player guesses if the next card is (1) Higher or (-1) Lower</param>
        /// <returns>If game continues or stops</returns>
        public bool NextCard(int res = 0)
        {
            if (SetOfDecks.Count == 0) return false;

            ICard previousCard = FaceUpCard;

            FaceUpCard = this.SetOfDeckService.GetNextCard(SetOfDecks);
            SetOfDecks.Remove(FaceUpCard);

            if (res == 0) return true;

            if (previousCard != null)
            {
                int compare = this.CompareTo(previousCard);
                if (compare != 0 && (!res.Equals(compare)))
                {
                    return false;
                }
                PlayerScore += 1;
            }

            return true;
        }

#region "Helpers"        
        public string ShowFaceUpCard() => FaceUpCard.ToString();

        public string ShowFinalResult()
        {
            string message = string.Empty;

            if (SetOfDecks.Count == 0)
            {
                message = $"Congratulations! All the cards were guessed, you score was { PlayerScore.ToString() }";
            }
            else
            {
                message = $"Game Over! You lost, you score was { PlayerScore.ToString() }";
            }

            return message;
        }

        private int CompareTo(ICard previousCard)
            => FaceUpCard.Rank.Equals(previousCard.Rank) ? 0 : ((int)FaceUpCard.Rank > (int)previousCard.Rank) ? 1 : -1 ;

#endregion

    }
}

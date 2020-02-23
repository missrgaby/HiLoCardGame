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

        public void BeginGame()
        {
            for (int i = 0; i < Settings.NumberOfDecks; i++)
            {
                Deck deck = new Deck();
                deck.RemoveCardFromDeck(Settings.ExcludeCards);
                SetOfDecks.AddRange(deck.DeckOfCards);
            }
        }

        public void NextCard()
        {
            FaceUpCard = this.SetOfDeckService.GetNextCard(SetOfDecks);
            SetOfDecks.Remove(FaceUpCard);
        }

    }
}

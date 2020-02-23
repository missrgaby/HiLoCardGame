using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    /// <summary>
    /// Properties that are input by the player for customize game.
    /// </summary>
    public class GameSettings
    {
        public int NumberOfDecks { get; set; }
        public List<ICard> ExcludeCards { get; set; }

        public GameSettings()
        {
            NumberOfDecks = 1;
            ExcludeCards = new List<ICard>();
        }
    }
}

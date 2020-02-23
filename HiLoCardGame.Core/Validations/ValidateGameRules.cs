using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.Core
{
    public static class ValidateGameRules
    {
        public static bool ValidateNumberOfDecks(int numberOfDecks)
        {
            bool isValid = true;
            if (numberOfDecks <= 0 || numberOfDecks > 10) isValid = false;
            return isValid;
        }

        public static bool ValidateNumberOfDecks(string input)
        {
            int numberOfDecks = 0;

            int.TryParse(input, out numberOfDecks);
            return ValidateNumberOfDecks(numberOfDecks);
        }

        public static bool ValidateSettingSetOfDecks(string input)
        {
            int numberOfDecks = 0;
            int.TryParse(input, out numberOfDecks);

            bool isValid = true;
            if (numberOfDecks <= 0 || numberOfDecks > 6) isValid = false;
            return isValid;
        }

        public static GameSettings GetSettingSetOfDecks(int type)
        {
            GameSettings settings;
            switch (type)
            {
                case 1:
                    //Baccarat or Blackjack - Eight standard decks shuffled together from a Card Shoe
                    settings = GetSettingSetOfDecks(8, 0, 0);
                    break;
                case 2:
                    //Bezique - Two standard decks with 2's through 6's removed
                    settings = GetSettingSetOfDecks(2, 2, 6);
                    break;
                case 3:
                    //Durak - Standard deck with the 2's through 5's removed
                    settings = GetSettingSetOfDecks(1, 2, 5);
                    break;
                case 4:
                    //Euchre - Standard deck with the 2's through 8's removed
                    settings = GetSettingSetOfDecks(1, 2, 8);
                    break;
                case 5:
                    //Panguingue (Pan) - Eight standard decks with the 8's, 9's, and 10's removed
                    settings = GetSettingSetOfDecks(8, 8, 10);
                    break;
                case 6:
                    //Pinochle - Two standard decks with 2's through 8's removed.
                    settings = GetSettingSetOfDecks(2, 2, 8);                    
                    break;
                default:
                    settings = null;
                    break;
            }
            return settings;
        }

        public static GameSettings GetSettingSetOfDecks(int num, int init, int fin)
        {
            GameSettings settings = new GameSettings();

            settings.NumberOfDecks = num;

            foreach (Suits suit in (Suits[])Enum.GetValues(typeof(Suits)))
            {
                for (int i = init; i <= fin; i++)
                {
                    if (suit == Suits.Clubs)
                    {
                        settings.ExcludeCards.Add(new ClubsCard((Ranks)i));
                    }
                    else if (suit == Suits.Hearts)
                    {
                        settings.ExcludeCards.Add(new HeartsCard((Ranks)i));
                    }
                    else if (suit == Suits.Spades)
                    {
                        settings.ExcludeCards.Add(new SpadesCard((Ranks)i));
                    }
                    else
                    {
                        settings.ExcludeCards.Add(new DiamondsCard((Ranks)i));
                    }
                }
            }            

            return settings;
        }


    }
}

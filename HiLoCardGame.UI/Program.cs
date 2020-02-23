using HiLoCardGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoCardGame.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Welcome to Hi-Lo Card Game, Would you like to play with a customize decks today? (y/n):");

            input = Console.ReadLine().Trim().ToUpper();

            while (input != "Y" && input != "N")
            {
                Console.WriteLine("Invalid entry please type (y/n):");
                input = Console.ReadLine().Trim().ToUpper();
            }

            Game newPlayer = new Game(SetGameSetting(input));
            bool playAgain = true;
            while (playAgain)
            {
                string msg = string.Empty;

                newPlayer.BeginGame();
                newPlayer.NextCard();

                bool Continue = true;
                while (Continue)
                {
                    Console.WriteLine($"Score: { newPlayer.PlayerScore } >> Remaing Cards: { newPlayer.SetOfDecks.Count } - Is the next card, HIGHER or LOWER than { newPlayer.ShowFaceUpCard() }? (h/l):");
                    input = Console.ReadLine().Trim().ToUpper();

                    while (input != "H" && input != "L")
                    {
                        Console.WriteLine("Invalid entry please type (h/l):");
                        input = Console.ReadLine().Trim().ToUpper();
                    }
                    int res = input == "H" ? 1 : -1;
                    Continue = newPlayer.NextCard(res);
                }

                Console.WriteLine();

                msg = newPlayer.ShowFinalResult();
                Console.WriteLine(msg);

                Console.WriteLine();

                Console.WriteLine("Would you like to replay the game? (y/n):");
                input = Console.ReadLine().Trim().ToUpper();

                // Checks its user would like to play again.
                while (input != "Y" && input != "N")
                {
                    Console.WriteLine("Invalid entry please type (y/n):");
                    input = Console.ReadLine().Trim().ToUpper();
                }

                if (input.Trim().ToUpper().Equals("N"))
                {
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine("\n\n\n\nNew Round!\n\n\n\n");
                }
            }

            Console.WriteLine("\n\nThank you for playing! press any key to close");
            Console.ReadKey();
        }


        private static GameSettings SetGameSetting(string input)
        {
            GameSettings setting = new GameSettings();

            if (input.Trim().ToUpper().Equals("Y"))
            {
                Console.WriteLine();

                Console.WriteLine("Please select one of above: " +
                                  "\n1. Enter number of decks" +
                                  "\n2. Select a set of decks");
                input = Console.ReadLine().Trim().ToUpper();

                while (input != "1" && input != "2")
                {
                    Console.WriteLine("Invalid entry please try again (1-2):");
                    input = Console.ReadLine().Trim().ToUpper();
                }

                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("How many decks will be playing? (1-10):");
                        input = Console.ReadLine();

                        while (!ValidateGameRules.ValidateNumberOfDecks(input))
                        {
                            Console.WriteLine("Invalid number of decks try again please (1-10): ");
                            input = Console.ReadLine();
                        }
                        setting = ValidateGameRules.GetSettingSetOfDecks(int.Parse(input), 0, 0);
                        break;

                    case "2":
                        Console.WriteLine("Please select one of above: " +
                                            "\n1. Eight standard decks (416 cards)" +
                                            "\n2. Two standard decks with 2's through 6's removed (64 cards)" +
                                            "\n3. Standard deck with the 2's through 5's removed (36 cards)" +
                                            "\n4. Standard deck with the 2's through 8's removed (24 cards)" +
                                            "\n5. Eight standard decks with the 8's, 9's, and 10's removed (320 cards)" +
                                            "\n6. Two standard decks with 2's through 8's removed (48 cards)");
                        input = Console.ReadLine().Trim().ToUpper();

                        while (!ValidateGameRules.ValidateSettingSetOfDecks(input))
                        {
                            Console.WriteLine("Invalid set of decks try again please (1-6): ");
                            input = Console.ReadLine();
                        }

                        setting = ValidateGameRules.GetSettingSetOfDecks(int.Parse(input));
                        break;
                }

                Console.WriteLine();

            }

            return setting;
        }
    }
}

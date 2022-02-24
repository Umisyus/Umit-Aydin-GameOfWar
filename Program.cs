using System;
using static Umit_Aydin_GameOfWar.Extensions;

namespace Umit_Aydin_GameOfWar
{
    internal static class Program
    {
        private static int CURRENT_INDEX = 0;
        private static Player player1;
        private static Player player2;

        private static void Main()
        {
            // Output unicode
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Clear();

            Console.WriteLine("Welcome to War!");
            var playPleasePressEnter = "To play, please press <ENTER> \u23CE!";

            Console.WriteLine(playPleasePressEnter);

            // Initialize game elements
            Deck deck = new Deck();
            var gameDeck = deck.CompletedCards;

            var shuffled = deck.ShuffleCards(gameDeck);

            player1 = new Player("Player 1");
            player2 = new Player("Player 2");

            var split = deck.SplitDeck(shuffled);

            player1.Cards = split[0];
            player2.Cards = split[1];

            // Game loop
            while (Console.ReadLine() == String.Empty)
            {
                // draw one card from each player's deck.
                var player1Card = player1.Cards[CURRENT_INDEX];
                var player2Card = player2.Cards[CURRENT_INDEX];

                IncrementCardIndex();

                PrintGameState(player1, player2, player1Card, player2Card);

                // compare
                // p1's card: p2's card:
                // x     >    y ? true (p1 wins) : false (p2 wins)
                int result = DetermineWinner(player1, player2);

                // Compare cards, if same declare "WAR"

                // if p1's card == p2's card
                // declare war:
                // draw 4 cards
                // (draw and compare four times)
                if (result == 3)
                {
                    Console.WriteLine(">>>> W̳A̳R̳! <<<<");

                    War(player1, player2);
                }

                Console.WriteLine("To continue please press <ENTER> \u23CE...");
            }
        }

        private static void IncrementCardIndex()
        {
            if (CURRENT_INDEX != 25)
                CURRENT_INDEX++;
            else
                AskReplay(player1, player2);
        }

        private static void AskReplay(Player player1, Player player2)
        {
            Console.WriteLine("The game has ended...");
            Console.WriteLine($@"
The final score was: Player 1: {player1.Score} Player 2: {player2.Score}
");

            // Insert cheecky comment here...
            if (player1.Score > player2.Score)
            {
                Console.WriteLine($"It seems that {player1} got the best of you...\nPlayer {player1}," +
                                  "better luck next time!");
            }
            else
                Console.WriteLine($"It seems that {player2} got the best of you...");

            Console.WriteLine("Would you like to play again?");
            Console.Write("> ");
            // Restart game if answer 'y'

            while (true)
            {
                var ans = Console.ReadKey().KeyChar;

                if (ans == 'y')
                {
                    RestartGame();
                    break;
                }

                if (ans == 'n')
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }

        private static void RestartGame()
        {
            player1 = new Player("1");
            player2 = new Player("2");
            CURRENT_INDEX = 0;
            Main();
        }

        private static void PrintGameState(Player player1, Player player2, Card card1, Card card2)
        {
            Console.WriteLine($@" 
{player1} Score: {player1.Score}        {player2} Score: {player2.Score}
{player1} draws {card1}, {player2} draws {card2}");
        }

        private static int DetermineWinner(
            Player p1, Player p2)
        {
            var p1Card = p1.Cards[CURRENT_INDEX].Rank;
            var p2Card = p2.Cards[CURRENT_INDEX].Rank;
            var isGreaterThan = p1Card > p2Card;

            var isEqual = p1Card == p2Card;
            int val;

            if (isGreaterThan)
            {
                p1.Score++;
                val = 1;
            }
            else
            {
                p2.Score++;
                val = 2;
            }

            if (isEqual)
            {
                // WAR!
                val = 3;
            }

            return val;
        }

        private static void War(Player p1, Player p2)
        {
            // Compare cards, if same declare "WAR", draw and compare FOUR cards!
            int[] wins = new int[4];


            try
            {
                var previousScorePlayer1 = player1.Score;
                var previousScorePlayer2 = player2.Score;


                for (int warCard = 0; warCard < 3; warCard++)
                {
                    // Take from the array
                    // player1Deck.Tak(player1Card);
                    // Compare cards recursively but do not call war again

                    Card p1WarCard = p1.Cards[CURRENT_INDEX];
                    Card p2WarCard = p2.Cards[CURRENT_INDEX];

                    wins[warCard] = DetermineWinner(p1, p2);

                    IncrementCardIndex();

                    // Print war results
                    PrintGameState(p1, p2, p1WarCard, p2WarCard);
                }

                var victor = player1.Score > player2.Score;

                var resultOfWar = victor
                    ? $"{player1} wins {player1.Score - previousScorePlayer1} points"
                    : $"{player2} wins {player2.Score - previousScorePlayer2} points";

                Console.WriteLine(resultOfWar);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
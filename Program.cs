using System;
using static Umit_Aydin_GameOfWar.Extensions;

namespace Umit_Aydin_GameOfWar
{
    internal static class Program
    {
        static int _player1Score = 0, _player2Score = 0;

        private static int CURRENT_INDEX = 0;

        private static void Main()
        {
            // Output unicode
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var rng = new Random().Next(1, 52);

            Console.WriteLine("Welcome to War!");
            Deck deck = new Deck();
            var gameDeck = deck.CompletedCards;

            Card[] player1Deck = { };
            Card[] player2Deck = { };

            var shuffled = Deck.ShuffleCards(gameDeck);
            bool gameHasTurn = true;

            var player1 = new Player();
            var player2 = new Player();


            var split = SplitDeck(shuffled);

            player1Deck = split[0];

            player2Deck = split[1];

            while (Console.ReadLine() == String.Empty)
            {
                // draw one card from each player's deck.
                var player1Card = player1Deck[^1];
                var player2Card = player1Deck[^1];

                Print(player1, player2, player1Card, player2Card);

                // compare
                // p1's card: p2's card:
                // x     >    y ? true (p1 wins) : false (p2 wins)
                int result = DetermineWinner(player1Card, player2Card, ref _player1Score, ref _player2Score);

                // Compare cards, if same declare "WAR"

                // if p1's card == p2's card
                // declare war:
                // draw 4 cards
                // (draw and compare four times)
                if (result == 3)
                {
                    Console.WriteLine(">>>> W̳A̳R̳! <<<<");
                    War(player1Deck, player2Deck);
                }
            }
        }

        private static void Print(Player player1, Player player2, Card card1, Card card2)
        {
            Console.WriteLine($@" Player {player1} draws {card1} Player {player2} draws {card2}");
        }

        private static int DetermineWinner(
            Card player1Card, Card player2Card,
            ref int player1Score,
            ref int player2Score)
        {
            var isGreaterThan = player1Card.Rank > player2Card.Rank;
            var isEqual = player1Card.Rank == player2Card.Rank;
            int val;

            if (isGreaterThan)
            {
                player1Score++;
                val = 1;
            }
            else
            {
                player2Score++;
                val = 2;
            }

            if (isEqual)
            {
                // WAR!
                val = 3;
            }

            return val;
        }

        public static Card DrawCard()
        {
            return null;
        }

        private static Card[][] SplitDeck(Card[] gameDeck)
        {
            // Split deck among players

            if (gameDeck.Length % 2 == 0)
            {
                // Get half of array length
                var gameDeckLength = gameDeck.Length / 2;
                // Get cards/elements from the start up to the half of the array 
                var gameDeckPart1 = gameDeck[..gameDeckLength];
                // Proceed to get the cards/elements from the half of the array to the length of the array
                var gameDeckPart2 = gameDeck[(gameDeckLength / 2)..gameDeckLength];

                // return our split array as one
                return new[] {gameDeckPart1, gameDeckPart2};
            }

            // Return empty
            return new Card[][] { };
        }

        private static void War(Card[] player1Deck, Card[] player2Deck)
        {
            // Compare cards, if same declare "WAR", draw and compare FOUR cards!
            for (int warCard = 0; warCard < 3; warCard++)
            {
                Card player1Card;
                Card player2Card;

                try
                {
                    player1Card = player1Deck[warCard];
                    player2Card = player2Deck[warCard];
                    // Take from the array
                    // player1Deck.Tak(player1Card);
                    // Compare cards recursively but do not call war again
                    DetermineWinner(player1Card, player2Card, ref _player1Score, ref _player2Score);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
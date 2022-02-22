using System;
using static Umit_Aydin_GameOfWar.Extensions;

namespace Umit_Aydin_GameOfWar
{
    internal static class Program
    {
        private static void Main()
        {
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

            int player1Score = 0, player2Score = 0;


            var split = SplitDeck(shuffled);

            player1Deck = split[0];

            player2Deck = split[1];

            while (gameHasTurn)
            {
                // draw one card from each player's deck.
                var player1Card = player1Deck[player1Deck.Length - 1];
                var player2Card = player1Deck[player2Deck.Length - 1];

                // compare
                // p1's card: p2's card:
                // x     >    y ? true (p1 wins) : false (p2 wins)
                DetermineWinner(player1Card, player2Card, ref player1Score, player1Deck, player2Deck, player1, player2,
                    ref player2Score);

                // if p1's card == p2's card
                // declare war:
                // draw 4 cards
                // (draw and compare four times)

                CompareCards(player1Deck, player2Deck, player1, player2);
            }
        }

        private static void DetermineWinner(Card player1Card, Card player2Card, ref int player1Score,
            Card[] player1Deck,
            Card[] player2Deck, Player player1, Player player2, ref int player2Score)
        {
            var isGreaterThan = player1Card.Rank > player2Card.Rank;
            var isEqual = player1Card.Rank == player2Card.Rank;

            if (isGreaterThan)
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }

            if (isEqual)
            {
                // WAR!
                War(player1Deck, player2Deck, player1, player2);
            }
        }

        private static Card[][] SplitDeck(Card[] gameDeck)
        {
            Card[] gameDeckpt1 = new Card[25];
            Card[] gameDeckpt2 = new Card[25];

            // Split deck among players

            if (gameDeck.Length % 2 == 0) // Even
                for (var index = 0; index < (gameDeck.Length / 2); index++)
                {
                    var card = gameDeck[index];
                    gameDeckpt1[index] = card;
                }
            else
            {
                var len = (gameDeck.Length - 1); // Odd

                for (var index = len / 2; index < len; index++)
                {
                    var card = gameDeck[index];
                    gameDeckpt2[index] = card;
                }
            }


            return new Card[][]
            {
                gameDeckpt1, gameDeckpt2
            };
        }

        private static void CompareCards(Card[] player1Deck, Card[] player2Deck, Player player1, Player player2)
        {
            // Compare ONE card
            for (int i = 0; i < 1; i++)
            {
                var player1Card = player1Deck[i];
                var player2Card = player2Deck[i];

                // Compare cards, if same declare "WAR"
                if (player1Card == player2Card)
                {
                    Console.WriteLine(">>>> W̳A̳R̳! <<<<");
                    War(player1Deck, player2Deck, player1, player2);
                }
            }
        }

        private static void War(Card[] player1Deck, Card[] player2Deck, Player player1, Player player2)
        {
            // Compare cards, if same declare "WAR", draw and compare FOUR cards!
            for (int warCard = 0; warCard < 3; warCard++)
            {
                Card player1Card = player1Deck[warCard];
                Card player2Card = player2Deck[warCard];


                if (player1Card == player2Card)
                {
                    Console.WriteLine(">>>> W̳A̳R̳! <<<<");
                }

                CompareCards(player1Deck, player2Deck, player1, player2);
            }
        }
    }
}
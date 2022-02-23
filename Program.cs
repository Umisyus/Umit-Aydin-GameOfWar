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

                Print(player1, player2, player1Card, player2Card);

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

        private static void Print(Player player1, Player player2, Card card1, Card card2)
        {
            Console.WriteLine($@" Player {player1} draws {card1} Player {player2} draws {card2}");
        }

        private static void DetermineWinner(Card player1Card, Card player2Card, ref int player1Score,
            Card[] player1Deck, Card[] player2Deck, Player player1, Player player2, ref int player2Score)
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
            Card[] gameDeckpt1 = null;
            Card[] gameDeckpt2 = null;

            gameDeckpt1 = gameDeck[1..3];
            
            // Split deck among players

            // Start from 0 to 25 of gameDeck
            if (gameDeck.Length % 2 == 0)
            {
                var gameDeckLengthHalf = (gameDeck.Length / 2);
                gameDeckpt1 = new Card[gameDeckLengthHalf];
                gameDeckpt2 = new Card[gameDeckLengthHalf];

                for (var index = 0; index < gameDeckLengthHalf; index++)
                {
                    var card = gameDeck[index];

                    gameDeckpt1[index] = card;
                }

                // Continue from (gameDeckLength /2) = 26 onwards to end of array
                int i = 0;

                for (var index2 = gameDeckLengthHalf; index2 < gameDeck.Length; index2--)
                {
                    var card = gameDeck[index2];

                    gameDeckpt2[i] = card;

                    i++;

                    if (i == gameDeckLengthHalf)
                    {
                        break;
                    }
                }

                return new Card[][] {gameDeckpt1, gameDeckpt2};
            }

            return new Card[][] { };
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
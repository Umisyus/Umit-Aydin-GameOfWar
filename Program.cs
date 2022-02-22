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

            Card[] gameDeck = Deck.CompletedCards;
            var shuffled = Deck.ShuffleCards(gameDeck);

            Card[] player1Deck = { };
            Card[] player2Deck = { };

            bool gameHasTurn = true;


            var player1 = new Player();
            var player2 = new Player();

            var split = SplitDeck(shuffled);
            player1Deck = split[0];
            player2Deck = split[1];

            while (gameHasTurn)
            {
                CompareCards(player1Deck, player2Deck, player1, player2);
            }
        }

        private static Card[][] SplitDeck(Card[] gameDeck)
        {
            Card[] gameDeckpt1 = null;
            Card[] gameDeckpt2 = null;

            // Split deck among players

            if (gameDeck.Length % 2 == 0)
            {
                var gameDeckLength = (gameDeck.Length / 2);

                for (var index = 0; index < gameDeckLength; index++)
                {
                    var card = gameDeck[index];
                    gameDeckpt1 = new Card[gameDeckLength];
                    gameDeckpt1[index] = card;

                    gameDeckpt2 = new Card[gameDeckLength];
                    gameDeckpt2[index] = card;
                }

                return new Card[][]
                {
                    gameDeckpt1, gameDeckpt2
                };
            }

            return new Card[][] { };
        }

        private static void CompareCards(Card[] player1Deck, Card[] player2Deck, Player player1, Player player2)
        {
            // Compare cards, if same declare "WAR"
            for (int i = 0; i < 3; i++)
            {
                var player1Card = player1Deck[i];
                var player2Card = player2Deck[i];
                Console.WriteLine($"{player1} draws {player1Card}. {player2} draws {player2Card} ");
                if (player1Card == player2Card)
                {
                    Console.WriteLine(">>>> WAR! <<<<");
                }
            }
        }
    }
}
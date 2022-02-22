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
                
                
                
                
                
                // draw one card from each player's deck.

                // compare
                // p1's card: p2's card:
                // x     >    y ? true (p1 wins) : false (p2 wins)
                // if p1's card == p2's card
                // declare war:
                // draw 4 cards
                // (draw and compare four times)
                
                CompareCards(player1Deck, player2Deck, player1, player2);

            }
      
        }

        private static Card[][] SplitDeck(Card[] gameDeck)
        {
            Card[] gameDeckpt1 = new Card[] { };
            Card[] gameDeckpt2 = new Card[] { };

            // Split deck among players

            if (gameDeck.Length % 2 == 0)
                for (var index = 0; index < (gameDeck.Length / 2); index++)
                {
                    var card = gameDeck[index];
                    gameDeckpt1[index] = card;
                }

            for (var index = 25; index < (gameDeck.Length / 2); index++)
            {
                var card = gameDeck[index];
                gameDeckpt2[index] = card;
            }


            return new Card[][]
            {
                gameDeckpt1, gameDeckpt2
            };
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
                    Console.WriteLine(">>>> W̳A̳R̳! <<<<");
                }
            }
        }
    }
}
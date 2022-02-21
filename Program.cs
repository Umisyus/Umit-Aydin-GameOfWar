using System;
using static Umit_Aydin_GameOfWar.Extensions;

namespace Umit_Aydin_GameOfWar
{
    internal static class Program
    {
        private static void Main()
        {
            var rng = new Random().Next(1, 50);

            Console.WriteLine("Welcome to War!");
            Deck.Card[] gameDeck = Deck.CompletedCards;
            Deck.Card[] player1Deck = { };
            Deck.Card[] player2Deck = { };

            var shuffled = ShuffleArray(Deck.CompletedCards);

            for (var index = 0; index < (gameDeck.Length / 2); index++)
            {
                var card = gameDeck[index];
                player1Deck[index] = card;

                for (int i = 25; i < gameDeck.Length; i++)
                {
                    var card2 = gameDeck[index]; 
                    player1Deck[i] = card2;
                }
            }

            var player1 = new Player("Player 1", player1Deck);
            var player2 = new Player("Player 2", player2Deck);

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
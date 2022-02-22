using System;
using static Umit_Aydin_GameOfWar.Card;

namespace Umit_Aydin_GameOfWar
{
    class Foo
    {
        static int random = new Random().Next(1, 10);

        public static void Main2()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Hello!");
            var cards = GenerateCards();

            foreach (var card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }

        private static Card[] GenerateCards()
        {
            var cards = new Card[53];
            var geAllSuits = Suits.GeAllSuits();

            for (int i = 0; i < 13;)
            {
                // Loop for all suits
                foreach (var suit in geAllSuits)
                {
                    // Loop for 13 ranks
                    for (int rank = 1; rank < 14; rank++)
                    {
                        // Add the card
                        cards[i] = new Card(suit, rank.ToString());

                        // Stop on the 53rd card
                        if (i == 52)
                        {
                            break;
                        }

                        // Advance to next card
                        i++;
                    }
                }
            }

            return cards;
        }
    }
}
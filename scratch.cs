using System;
using static Umit_Aydin_GameOfWar.Card;

namespace Umit_Aydin_GameOfWar
{
    class Foo
    {
        public static void Main2()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Hello!");
            var cards = GenerateCards();

            for (var index = 0; index < cards.Length; index++)
            {
                var card = cards[index];
                Console.WriteLine(card.ToString());

                Console.WriteLine(new string('-', 10));

                Console.WriteLine($"REMOVING {card}");
                cards.Remove(index);
                Console.WriteLine($"REMOVED {card}");

                Console.WriteLine(new string('-', 10));
                Console.WriteLine($"Item count in ARRAY: {cards.Length}");
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
                        cards[i] = new Card(suit, rank);

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
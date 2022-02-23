using System;

namespace Umit_Aydin_GameOfWar
{
    public class Deck
    {
        private int random;
        public Card[] CompletedCards { get; }

        public Card[] ShuffleCards(Card[] completedCards)
        {
            random = new Random().Next(0, CompletedCards.Length);

            var result_cards = new Card[completedCards.Length];

            for (var index = 0; index < completedCards.Length; index++)
            {
                var random_index = Math.Abs(random - index);

                var card = completedCards[random];
                result_cards[index] = completedCards[random_index];
            }

            return result_cards;
        }

        public Deck()
        {
            CompletedCards = GenerateCards();
        }

        private static Card[] GenerateCards()
        {
            var cards = new Card[52];
            var geAllSuits = Card.Suits.GeAllSuits();

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
                        if (i == 51)
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

        internal Card[][] SplitDeck(Card[] gameDeck)
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
    }
}
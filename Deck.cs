using System;

namespace Umit_Aydin_GameOfWar
{
    public class Deck
    {
        public Card[] CompletedCards { get; }

        public Card[] ShuffleCards(Card[] completedCards)
        {
            int random = new Random().Next(0, CompletedCards.Length);

            var resultCards = new Card[completedCards.Length];

            for (var index = 0; index < completedCards.Length; index++)
            {
                var randomIndex = Math.Abs(random - index);

                var card = completedCards[random];
                resultCards[index] = completedCards[randomIndex];
            }

            return resultCards;
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

        public Card[][] SplitDeck(Card[] gameDeck)
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
    }
}
namespace Umit_Aydin_GameOfWar
{
    public class Deck
    {
        public static Card[] ShuffleCards(Card[] completedCards)
        {
            return null;
        }

        public Deck()
        {
            CompletedCards = GenerateCards();
        }

        private static Card[] GenerateCards()
        {
            var cards = new Card[53];
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

        public static Card[] CompletedCards { get; set; }
    }
}
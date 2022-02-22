using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Umit_Aydin_GameOfWar
{
    public class Card
    {
        public class Suits
        {
            /*
             enum Suitz
            {
                Heart = '\u2665',
                Diamond = '\u2666',
                Club = '\u2663',
                Spade = '\u2660',
                Jack = 'J',
                King = 'K',
                Queen = 'Q',
            }
            */

            private const char Heart = '\u2665';
            private const char Diamond = '\u2666';
            private const char Club = '\u2663';
            private const char Spade = '\u2660';
            private const char Jack = 'J';
            private const char King = 'K';
            private const char Queen = 'Q';

            public static char GetSuit(int id)
            {
                switch (id)
                {
                    case 0: return Heart;
                    case 1: return Diamond;
                    case 2: return Club;
                    case 3: return Spade;
                    case 4: return Jack;
                    case 5: return King;
                    case 6: return Queen;

                    default: return '-';
                }
            }

            public static char[] GeAllSuits()
            {
                return new[] {Heart, Diamond, Club, Spade, Jack, King, Queen};
            }
        };

        public string Rank { get; }
        public char Suit { get; }


        public Card(char suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }


        public override string ToString()
        {
            return $"{Suit}{Rank}";
        }
    }
}
namespace Umit_Aydin_GameOfWar
{

    public class Player
    {
        private Deck deckOfCards = new Deck();
        private string Name { get; set; }
        public Card[] Cards { get; set; }

        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
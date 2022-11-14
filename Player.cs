namespace Sjuan {
    class Player {

        public String name;
        public IBrain brain;
        public List<Card> hand;

        public Player(string name, IBrain brain)
        {
            this.name = name;
            this.brain = brain;
            
            hand = new List<Card>();

        }
    }
}
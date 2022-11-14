namespace Sjuan {
    struct Card
    {
        readonly Suit suit;
        readonly byte rank;

        public Suit Suit { get => suit; }
        public byte Rank { get => rank; }

        public static Card NULLCard() {
            return new Card(Suit.NULL, 0);
        }

        public static bool operator ==(Card a, Card b) => a.suit == b.suit && a.rank == b.rank;
        public static bool operator !=(Card a, Card b) => !(a == b);
        public bool IsNULL { get => suit == Suit.NULL; }

        public Card(Suit suit, byte rank) {
            this.suit = suit;
            this.rank = rank;
        }
    }
}
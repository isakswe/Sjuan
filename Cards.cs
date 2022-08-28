using System.Collections.Generic;

namespace Sjuan
{
    //The interface for a bot to implement
    interface ISevenBot
    {
        /// <summary>
        /// Playing a card after the first player in other
        /// </summary>
        /// <param name="table">Current table layout</param>
        /// <param name="yourHand">Current hand. If no plays are possible, this will be null</param>
        /// <param name="otherCardCount">How many card the other players have</param>
        /// <param name="otherMoves">The most recent moves made by other players. </param>
        /// <returns>The index of yourHand to play</returns>
        public int Play(Table table, List<Card>yourHand, int[] otherCardCount, Card[] otherMoves);
        /// <summary>
        /// Giving a card to the last player in other
        /// </summary>
        /// <param name="table">Current table layout</param>
        /// <param name="yourHand">Current hand. If no plays are possible, this will be null</param>
        /// <param name="otherCardCount">How many card the other players have</param>
        /// <param name="otherMoves">The most recent moves made by other players. </param>
        /// <returns>The index of yourHand to give</returns>
        public int GiveCard(Table table, List<Card> yourHand, int[] otherCardCount, Card[] otherMoves);
    }
    
    class Table
    {
        //Current high number, -1 if null
        public int High(Suit suit) {
            //TODO
            return 0;
        }

        //Current low number, -1 if null
        public int Low(Suit suit) {
            //TODO
            return 0;
        }

        //Status of 7, true if it has been placed
        public bool Started(Suit suit) {
            //TODO
            return true;
        }
    }

    enum Suit : byte { Spades, Hearts, Clovers, Diamonds, NULL};
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

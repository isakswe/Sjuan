using System.Collections.Generic;

namespace Sjuan
{
    class Table
    {
        int[,] ranks;
        bool[] sevenStatuses;

        public Table(int[,] ranks, bool[] sevenStatuses) {
            this.ranks = ranks;
            this.sevenStatuses = sevenStatuses;
        }

        //Le epic deep copy
        public Table(Table table){
            ranks = table.ranks;
            sevenStatuses = table.sevenStatuses;
        }

        //Current high number, -1 if null
        public int High(Suit suit) { return ranks[(byte)suit, 1]; }

        //Current low number, -1 if null
        public int Low(Suit suit) { return ranks[(byte)suit, 0]; }

        //Status of 7, true if it has been placed
        public bool Started(Suit suit) { return sevenStatuses[(byte)suit]; }

        public bool CanPlay(Card card) {
            if (card.Rank == 7) {
                return true;
            } else if (card.Rank < 7) {
                return (card.Rank == Low(card.Suit) - 1);
            } else {
                return (card.Rank == High(card.Suit) + 1);
            }
        }

        public void Play(Card card){
            if (CanPlay(card) == false) {
                throw new Exception("Cringe");
            }
            
            if (card.Rank == 7) {
                sevenStatuses[(byte)card.Suit] = true;
            } else if (card.Rank < 7) {
                ranks[(byte)card.Suit, 0]--;
            } else {
                ranks[(byte)card.Suit, 1]++;
            }
        }
    }
}

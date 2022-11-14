namespace Sjuan
{
    class FirstBest : IBrain
    {
        public string getName()
        {
            return "First best (just first)";
        }

        public int GiveCard(Table table, List<Card> hand, List<int> otherCardCount, List<Card> otherMoves)
        {
            return 0;
        }

        public int Play(Table table, List<Card> hand, List<int> otherCardCount, List<Card> otherMoves)
        {
            for (int i = 0; i < hand.Count(); i++)
            {
                if (table.CanPlay(hand[i]))
                {
                    return i;
                }
            }

            throw new Exception("Why did you let me play?");
        }
    }
}

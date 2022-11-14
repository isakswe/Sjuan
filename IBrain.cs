namespace Sjuan {
    //The interface for a bot to implement
    interface IBrain
    {
        /// <summary>
        /// Playing a card after the first player in other
        /// </summary>
        /// <param name="table">Current table layout</param>
        /// <param name="yourHand">Current hand. If no plays are possible, this will be null</param>
        /// <param name="otherCardCount">How many card the other players have</param>
        /// <param name="otherMoves">The most recent moves made by other players. </param>
        /// <returns>The index of yourHand to play</returns>
        public int Play(Table table, List<Card> yourHand, List<int> otherCardCount, List<Card> otherMoves);
        /// <summary>
        /// Giving a card to the last player in other
        /// </summary>
        /// <param name="table">Current table layout</param>
        /// <param name="yourHand">Current hand. If no plays are possible, this will be null</param>
        /// <param name="otherCardCount">How many card the other players have</param>
        /// <param name="otherMoves">The most recent moves made by other players. </param>
        /// <returns>The index of yourHand to give</returns>
        public int GiveCard(Table table, List<Card> yourHand, List<int> otherCardCount, List<Card> otherMoves);
    }
}
using System.Linq;

namespace Sjuan
{
    class Game
    {

        List<Player> players;

        List<int> seats;
        int currentSeat;

        Table table;

        List<Card> history;

        public Game(List<Player> players)
        {
            this.players = players;
            seats = Enumerable.Range(0, players.Count).ToList();

            table = new Table(new int[4, 2], new bool[] { false, false, false, false });

            history = new List<Card>();
        }

        public GameResult Play()
        {
            seats.Shuffle();
            currentSeat = 0;

            List<Card> deck = new List<Card>();

            for (byte i = 1; i < 13 + 1; i++)
            {
                for (byte j = 0; j < 4; j++)
                {
                    deck.Add(new Card((Suit)j, i));
                }
            }
            deck.Shuffle();

            int dealee = 0;
            for (int i = 0; i < 52; i++)
            {
                players[seats[dealee]].hand.Add(deck[i]);

                dealee = (dealee + 1) % players.Count;
            }

            while (true)
            {
                int currentPlayerIndex = seats[currentSeat];
                Player currentPlayer = players[currentPlayerIndex];
                IBrain brain = currentPlayer.brain;

                //Are we done checking what the player can play?
                bool doneChecking = false;

                List<Card> fantasyHand = new List<Card>(currentPlayer.hand);
                Table fantasyTable = new Table(table);

                bool canPlay = false;

                while (!doneChecking)
                {
                    doneChecking = true;

                    foreach (Card card in fantasyHand.ToList()) //Deep copy each run-through not to modify while iterating
                    {
                        if (fantasyTable.CanPlay(card))
                        {
                            doneChecking = false;
                            canPlay = true;
                            fantasyHand.Remove(card);
                            fantasyTable.Play(card);
                        }
                    }
                }

                List<int> othersCardCount = new List<int>();
                for (int i = 0; i < players.Count - 1; i++)
                {
                    othersCardCount.Add(players[seats[(currentSeat + (i + 1)) % players.Count]].hand.Count);
                }

                if (canPlay)
                {
                    if (fantasyHand.Count == 0)
                    {
                        //Player has won
                        //Later, maybe don't end the game here
                        return new GameResult(currentPlayerIndex);
                    }

                    Card card = currentPlayer.hand[brain.Play(table, currentPlayer.hand, othersCardCount, history.Skip(Math.Max(0, history.Count() - (players.Count - 1))).ToList<Card>())];

                    currentPlayer.hand.Remove(card);
                    table.Play(card);

                    history.Add(card);

                }
                else
                {


                    Card card = currentPlayer.hand[brain.GiveCard(table, currentPlayer.hand, othersCardCount, history.Skip(Math.Max(0, history.Count() - (players.Count - 1))).ToList())];


                    currentPlayer.hand.Remove(card);
                    players[seats[(currentSeat + 1) % players.Count]].hand.Add(card);

                    history.Add(new Card(Suit.NULL, 0));
                }

                currentSeat = (currentSeat + 1) % players.Count;

            }
        }


    }
}
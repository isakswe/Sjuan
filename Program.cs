using System;

namespace Sjuan
{
    class Program
    {
        static void Main(string[] args) {
            
            Game game = new Game(
                new List<Player> {
                    new Player("First best", new FirstBest()), 
                    new Player("Best first", new FirstBest()) 
                }
            );

            Console.WriteLine(game.Play().winner);
            
        }
    }
}

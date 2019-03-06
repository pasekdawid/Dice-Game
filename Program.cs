using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool nextGame;
            do
            {
                DiceGame game = new DiceGame("Pierwszy", "Drugi");
                nextGame = game.Start();
            } while (nextGame);
        }
    }  
}

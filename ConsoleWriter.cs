using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    static class ConsoleWriter
    {
        public static void StartGame(string playerName1, string playerName2)
        {
            Console.Clear();
            Console.WriteLine($"Dice Game between {playerName1} and {playerName2} has started!\n");
        }

        public static void NextRound(int round, string name1, string name2, double score1, double score2)
        {
            if (round != 0)
                Console.Clear();
            Console.WriteLine($"Round {round + 1}!");
            Console.WriteLine($"Player {name1} has {score1:0.00} points, player {name2} has {score2:0.00} points.\n");
        }

        public static void PlayerTurn(string name, double score)
        {
            Console.WriteLine($"{name} turn, current points: {score:0.00}.");
            Console.WriteLine($"Press any key to roll the dice!");
            Console.ReadKey();
            ClearCurrentConsoleLine();
        }

        public static void DicesRolled(int dice1, double dice2)
        {
            Console.WriteLine($"Rolling... {dice1} and {dice2}!");
        }

        public static void RoundWon(string name, double score)
        {
            Console.WriteLine($"Player {name} won round with {score:0.00} points!\n");
        }

        public static void RoundLost(string name, double score)
        {
            Console.WriteLine($"Player {name} lost round with {score:0.00} points!\n");
        }

        public static void CurrentPoints(string name, double score, double totalscore)
        {
            Console.WriteLine($"Player {name} earned {score:0.00} points! His total score is {totalscore:0.00}.\n");
        }

        public static void EndGame(string name1, string name2, double score1, double score2)
        {
            if (score1 < score2)
            {
                Console.WriteLine($"Player {name1} won the game versus {name2} with {score1:0.00} points. Player {name2} scored in total {score2:0.00} points.\n");
                Console.WriteLine($"Press any key to start new game and ESC to exit.");
            }
            else if (score1 > score2)
            {
                Console.WriteLine($"Player {name2} won the game versus {name1} with {score2:0.00} points. Player {name1} scored in total {score1:0.00} points.\n");
                Console.WriteLine($"Press any key to start new game and ESC to exit.");
            }
            else
            {
                Console.WriteLine($"Draw! Both of players - {name1} and {name2} scored {score1:0.00} points!\n");
                Console.WriteLine($"Press any key to start new game and ESC to exit.");
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

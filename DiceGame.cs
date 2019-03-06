using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class DiceGame
    {
        private Player _player1, _player2;
        private int _roundCounter;
        private const int MAXTURNS = 5;
        private const int MAXROLLS = 10;

        public DiceGame(string playerName1, string playerName2)
        {
            this._player1 = new Player(playerName1);
            this._player2 = new Player(playerName2);
            this._roundCounter = 0;
        }

        public bool Start()
        {
            ConsoleWriter.StartGame(Player1.Name, Player2.Name);

            Rounds();
            ConsoleWriter.EndGame(Player1.Name, Player2.Name, Player1.Score, Player2.Score);

            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                return false;
            return true;
        }

        private void Rounds()
        {
            do
            {
                ConsoleWriter.NextRound(RoundCounter, Player1.Name, Player2.Name, Player1.Score, Player2.Score);
                Turns(Player1);
                Turns(Player2);
                _roundCounter++;
            } while (RoundCounter < MAXTURNS);
        }

        private void Turns(Player player)
        {
            int rollsCounter = 0;
            double roundPoints = 0.0;
            double points = 0.0;
            Random rnd = new Random();
            double roll = 0.0;
            int dice1, dice2;

            do
            {
                points = 0.0;
                roll = 0.0;
                ConsoleWriter.PlayerTurn(player.Name, player.Score);

                dice1 = rnd.Next(1, 7);
                dice2 = rnd.Next(1, 7);
                ConsoleWriter.DicesRolled(dice1, dice2);

                if (rollsCounter == 0 && (dice1 + dice2 == 7 || dice1 + dice2 == 11))
                {
                    ConsoleWriter.RoundWon(player.Name, 0.0);
                    break;
                }
                if (rollsCounter == 0 && (dice1 + dice2 == 2 || dice1 + dice2 == 12))
                {
                    points = MaxScore();
                    ConsoleWriter.RoundLost(player.Name, points);
                    break;
                }
                if (dice1 + dice2 == 5)
                {
                    ConsoleWriter.RoundWon(player.Name, roundPoints);
                    break;
                }
                else
                {
                    roll = (dice1 + dice2);
                    roll /= (rollsCounter + 1);
                    ConsoleWriter.CurrentPoints(player.Name, roll, player.Score + roll);
                }
                points += roll;
                player.AddPoints(points);
                roundPoints += points;
                rollsCounter++;
            } while (rollsCounter < MAXROLLS);
        }

        private double MaxScore()
        {
            double output = 0.0;
            for (int i = 1; i <= MAXROLLS; i++)
            {
                output += 12.0 / i;
            }
            return output;
        }

        public Player Player1 => _player1;
        public Player Player2 => _player2;

        public int RoundCounter => _roundCounter;
    }
}

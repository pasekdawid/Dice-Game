using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Player
    {
        private string _name;
        private double _score;

        public Player(string playerName)
        {
            this._name = playerName;
            this._score = 0;
        }

        public void AddPoints(double value)
        {
            _score += value;
        }

        public string Name => _name;
        public double Score => _score;
    }
}

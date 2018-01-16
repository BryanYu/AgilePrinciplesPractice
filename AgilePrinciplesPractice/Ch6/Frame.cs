using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch6
{
    public class Frame
    {
        private int _score;

        public int Score
        {
            get { return this._score; }
        }

        public void Add(int pins)
        {
            _score += pins;
        }
    }
}
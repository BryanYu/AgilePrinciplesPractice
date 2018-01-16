using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch6
{
    public class Game
    {
        private int _currentFrame = 0;
        private bool _isFirstThrow = true;
        private Scorer _scorer = new Scorer();

        public int Score
        {
            get { return ScoreForFrame(_currentFrame); }
        }

        public int CuurentFrame
        {
            get { return this._currentFrame; }
        }

        public void Add(int pins)
        {
            this._scorer.AddThrow(pins);
            AdjustCuurentFrame(pins);
        }

        public int ScoreForFrame(int theFrame)
        {
            return this._scorer.ScoreForFrame(theFrame);
        }

        private void AdjustCuurentFrame(int pins)
        {
            if (LastBallInFrame(pins))
            {
                AdvanceFrame();
            }
            else
            {
                _isFirstThrow = false;
            }
        }

        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!_isFirstThrow);
        }

        private bool Strike(int pins)
        {
            return (_isFirstThrow && pins == 10);
        }

        private void AdvanceFrame()
        {
            this._currentFrame++;
            if (this._currentFrame > 10)
            {
                this._currentFrame = 10;
            }
        }
    }

    public class Scorer
    {
        private int _ball;
        private int[] _throws = new int[21];
        private int _currentThrows;

        private int _nextTwoBallsForStrike
        {
            get { return _throws[_ball + 1] + _throws[_ball + 2]; }
        }

        private int _nextBallForSpare
        {
            get { return _throws[_ball + 2]; }
        }

        private int _twoBallsInFrame
        {
            get { return _throws[_ball] + _throws[_ball + 1]; }
        }

        public void AddThrow(int pins)
        {
            _throws[_currentThrows++] = pins;
        }

        public int ScoreForFrame(int theFrame)
        {
            _ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + _nextTwoBallsForStrike;
                    _ball++;
                }
                else if (Spare())
                {
                    score += 10 + _nextBallForSpare;
                    _ball += 2;
                }
                else
                {
                    score += _twoBallsInFrame;
                    _ball += 2;
                }
            }

            return score;
        }

        private bool Strike()
        {
            return _throws[_ball] == 10;
        }

        private bool Spare()
        {
            return _throws[_ball] + _throws[_ball + 1] == 10;
        }
    }
}
using System;
namespace Bowling {
    public class BowlingGame {
        private int _frame;
        private int _ball;
        private int _score;
        private int _lastRollScore;
        private int _mark;

        public void Roll(int pins) {
            if (pins > 10) {
                throw new Exception("Pins cannot exceed 10");
            }

            if (pins < 0) {
                throw new Exception("Pins cannot be negative");
            }

            if (_lastRollScore + pins > 10 && _ball == 1) {
                throw new Exception("Single frame score cannot exceed 10");
            }


            if (_mark > 0) {
                _score += pins;
                _mark--;
            }


            _score = pins + _score;

            //set fields for next roll

            if (pins + _lastRollScore == 10 && _ball == 1) {
                _mark = 1;
            }

            if (pins == 10 && _ball == 0) {
                _mark = 2;
                _frame++;
                _ball = 0;
                return;
            }

            if (_ball == 0) {
                _ball++;
            }
            else {
                _ball = 0;
                _frame++;
            }



            _lastRollScore = pins;
        }

        public int GetScore() {
            return _score;
        }
    }
}

using System;
namespace Bowling {
    public class BowlingGame {
        private int _frame;
        private int _ball;
        private int _score;
        private int _previousRollPins;
        private int _markMultiplier = 1;

        public void Roll(int pins) {
            if (pins > 10) {
                throw new Exception("Pins cannot exceed 10");
            }

            if (pins < 0) {
                throw new Exception("Pins cannot be negative");
            }

            if (_previousRollPins + pins > 10 && _ball == 1) {
                throw new Exception("Single frame score cannot exceed 10");
            }

            _score += pins * _markMultiplier;

            //set fields for next roll

            if (pins + _previousRollPins == 10 && _ball == 1) {
                _markMultiplier = 2;
            }

            if (pins == 10 && _previousRollPins == 10 && _markMultiplier == 2) {
                _markMultiplier = 3;
                _frame++;
                _ball = 0;
                _previousRollPins = pins;
                return;
            }

            if (pins == 10 && _ball == 0) {
                _markMultiplier = 2;
                _frame++;
                _ball = 0;
                _previousRollPins = pins;
                return;
            }

            if (_ball == 0) {
                _ball++;
            }
            else {
                _ball = 0;
                _frame++;
            }

            _previousRollPins = pins;
        }

        public int GetScore() {
            return _score;
        }
    }
}

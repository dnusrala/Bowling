using NUnit.Framework;
using Bowling;
using System;

namespace BowlingTests {
    [TestFixture]
    public class BowlingTests {
        private BowlingGame _bowling;

        [SetUp]
        public void SetUp() {
            _bowling = new BowlingGame();

        }

        [Test]
        public void ScoreStartsAtZero() {
            var score = _bowling.GetScore();
            Assert.AreEqual(0, score);
        }

        [Test]
        public void FirstRollPinCount() {
            _bowling.Roll(7);
            var score = _bowling.GetScore();
            Assert.AreEqual(7, score);
        }

        [Test]
        public void ScoreIsUnderTen() {
            Assert.Throws<Exception>(() => _bowling.Roll(11), "Pins cannot exceed 10");
        }

        [Test]
        public void ScoreIsNegative() {
            Assert.Throws<Exception>(() => _bowling.Roll(-1), "Pins cannot be negative");
        }

        [Test]
        public void SingleFrameScore() {
            _bowling.Roll(2);
            _bowling.Roll(1);
            var score = _bowling.GetScore();
            Assert.AreEqual(3, score);
        }

        [Test]
        public void SingleFrameScoreMaxTen() {
            _bowling.Roll(3);
            Assert.Throws<Exception>(() => _bowling.Roll(8), "Single frame score cannot exceed 10");

        }
        [Test]
        public void ScoreAfterTwoFrames() {
            _bowling.Roll(7);
            _bowling.Roll(2);
            _bowling.Roll(5);
            _bowling.Roll(4);
            var score = _bowling.GetScore();
            Assert.AreEqual(18, score);
        }

        [Test]
        public void ScoreAfterSpare() {
            _bowling.Roll(1);
            _bowling.Roll(9);
            _bowling.Roll(5);
            var score = _bowling.GetScore();
            Assert.AreEqual(20, score);
        }

        [Test]
        public void ScoreAfterStrike() {
            _bowling.Roll(10);
            _bowling.Roll(4);
            _bowling.Roll(5);
            var score = _bowling.GetScore();
            Assert.AreEqual(28, score);
        }

        [Test]
        public void ScoreAfterTwoStrikes() {
            _bowling.Roll(10);
            _bowling.Roll(10);
            var score = _bowling.GetScore();
            Assert.AreEqual(30, score);
        }

        [Test]
        public void ScoreAfterThreeStrikes() {
            _bowling.Roll(10);
            _bowling.Roll(10);
            _bowling.Roll(10);
            var score = _bowling.GetScore();
            Assert.AreEqual(60, score);
        }

        [TestCase(new[] { 5, 2, 3 }, 10)]
        [TestCase(new[] { 1, 2, 3, 4 }, 10)]
        [TestCase(new[] { 10, 10, 10, 0, 10, 10 }, 100)]
        [TestCase(new[] { 10, 5, 5, 10, 5, 5, 10, 5, 5, 10 }, 130)]
        [TestCase(new[] { 5, 5, 10, 5, 5, 10, 1, 9, 10, 9, 1, 10 }, 150)]
        [TestCase(new[] { 0, 10, 5, 4}, 24)]
        public void ScoreTest(int[] rolls, int expectedScore) {
            foreach (var roll in rolls) {
                _bowling.Roll(roll);
            }

            Assert.AreEqual(expectedScore, _bowling.GetScore());
        }
    }
}

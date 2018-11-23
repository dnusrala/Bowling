using NUnit.Framework;
using Bowling;
using System;

namespace BowlingTests {
    [TestFixture]
    public class BowlingTests {

        [Test]
        public void ScoreStartsAtZero() {
            var bowling = new BowlingGame();
            var score = bowling.GetScore();
            Assert.AreEqual(0, score);
        }

        [Test]
        public void FirstRollPinCount() {
            var bowling = new BowlingGame();
            bowling.Roll(7);
            var score = bowling.GetScore();
            Assert.AreEqual(7, score);
        }

        [Test]
        public void ScoreIsUnderTen() {
            var bowling = new BowlingGame();
            Assert.Throws<Exception>(() => bowling.Roll(11), "Pins cannot exceed 10");
        }

        [Test]
        public void ScoreIsNegative() {
            var bowling = new BowlingGame();
            Assert.Throws<Exception>(() => bowling.Roll(-1), "Pins cannot be negative");
        }

        [Test]
        public void SingleFrameScore() {
            var bowling = new BowlingGame();
            bowling.Roll(2);
            bowling.Roll(1);
            var score = bowling.GetScore();
            Assert.AreEqual(3, score);
        }

        [Test]
        public void SingleFrameScoreMaxTen() {
            var bowling = new BowlingGame();
            bowling.Roll(3);
            Assert.Throws<Exception>(() => bowling.Roll(8), "Single frame score cannot exceed 10");

        }
        [Test]
        public void ScoreAfterTwoFrames() {
            var bowling = new BowlingGame();
            bowling.Roll(7);
            bowling.Roll(2);
            bowling.Roll(5);
            bowling.Roll(4);
            var score = bowling.GetScore();
            Assert.AreEqual(18, score);
        }

        [Test]
        public void ScoreAfterSpare() {
            var bowling = new BowlingGame();
            bowling.Roll(1);
            bowling.Roll(9);
            bowling.Roll(5);
            var score = bowling.GetScore();
            Assert.AreEqual(20, score);
        }
        [Test]
        public void ScoreAfterStrike() {
            var bowling = new BowlingGame();
            bowling.Roll(10);
            bowling.Roll(4);
            bowling.Roll(5);
            var score = bowling.GetScore();
            Assert.AreEqual(28, score);
        }
    }
}

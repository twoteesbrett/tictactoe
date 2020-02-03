using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass]
    public class HasMovesRemainingTests
    {
        [TestMethod]
        public void HasMovesRemaining_AllMovesAvailable_ReturnsTrue()
        {
            // arrange
            char[,] board =
            {
                { '_', '_', '_'},
                { '_', '_', '_'},
                { '_', '_', '_'}
            };

            // act
            var actual = Game.HasMovesRemaining(board);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HasMovesRemaining_SomeMovesAvailable_ReturnsTrue()
        {
            // arrange
            char[,] board =
            {
                { 'x', 'o', '_'},
                { 'x', '_', '_'},
                { 'o', '_', '_'}
            };

            // act
            var actual = Game.HasMovesRemaining(board);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HasMovesRemaining_OneMoveRemaining_ReturnsTrue()
        {
            // arrange
            char[,] board =
            {
                { 'o', 'x', 'o'},
                { 'x', 'x', 'o'},
                { 'o', '_', 'x'}
            };

            // act
            var actual = Game.HasMovesRemaining(board);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HasMovesRemaining_NoMovesRemaining_ReturnsFalse()
        {
            // arrange
            char[,] board =
            {
                { 'o', 'x', 'o'},
                { 'x', 'x', 'o'},
                { 'o', 'o', 'x'}
            };

            // act
            var actual = Game.HasMovesRemaining(board);

            // assert
            Assert.IsFalse(actual);
        }
    }
}

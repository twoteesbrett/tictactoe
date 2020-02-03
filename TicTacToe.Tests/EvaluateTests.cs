using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass]
    public class EvaluateTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evaluate_UnevenBoardDimensions_ThrowsArgumentException()
        {
            // arrange
            char[,] board =
            {
                { 'x', 'x', 'x'},
                { '_', '_', 'o'}
            };

            // act
            Game.Evaluate(board);
        }

        [TestMethod]
        public void Evaluate_RowXWin_ReturnsPositiveInfinity()
        {
            // arrange
            char[,] board =
            {
                { 'x', 'x', 'x'},
                { '_', 'o', 'o'},
                { '_', '_', 'o'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_RowOWin_ReturnsNegativeInfinity()
        {
            // arrange
            char[,] board =
            {
                { '_', '_', 'x'},
                { '_', 'x', 'x'},
                { 'o', 'o', 'o'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(-Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_ColumnXWin_ReturnsPositiveInfinity()
        {
            // arrange
            char[,] board =
            {
                { '_', '_', 'x'},
                { '_', 'o', 'x'},
                { 'o', 'o', 'x'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_ColumnOWin_ReturnsNegativeInfinity()
        {
            // arrange
            char[,] board =
            {
                { 'o', '_', '_'},
                { 'o', 'x', '_'},
                { 'o', 'x', 'x'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(-Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_DiagonalLowerToUpperXWin_ReturnsPositiveInfinity()
        {
            // arrange
            char[,] board =
            {
                { 'x', '_', 'o'},
                { '_', 'x', 'o'},
                { '_', '_', 'x'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_DiagonalUpperToLowerXWin_ReturnsPositiveInfinity()
        {
            // arrange
            char[,] board =
            {
                { 'o', '_', 'x'},
                { '_', 'x', 'o'},
                { 'x', '_', 'o'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_DiagonalLowerToUpperOWin_ReturnsNegativeInfinity()
        {
            // arrange
            char[,] board =
            {
                { 'o', '_', 'x'},
                { 'x', 'o', '_'},
                { 'x', '_', 'o'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(-Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_DiagonalUpperToLowerOWin_ReturnsNegativeInfinity()
        {
            // arrange
            char[,] board =
            {
                { 'x', '_', 'o'},
                { '_', 'o', 'x'},
                { 'o', '_', 'x'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(-Game.Infinity, actual);
        }

        [TestMethod]
        public void Evaluate_Draw_ReturnsZero()
        {
            // arrange
            char[,] board =
            {
                { 'o', 'x', 'o'},
                { 'x', 'x', 'o'},
                { 'o', '_', 'x'}
            };

            // act
            var actual = Game.Evaluate(board);

            // assert
            Assert.AreEqual(0, actual);
        }
    }
}

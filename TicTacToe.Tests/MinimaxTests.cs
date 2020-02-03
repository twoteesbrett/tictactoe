using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Tests
{
    [TestClass]
    public class MinimaxTests
    {
        // A utility function to find Log n in base 2 
        private static int Log2(int n) => Convert.ToInt32(Math.Log(n, 2));

        // Here there are only two choices for a player. In general, there
        // can be more choices. In that case, we need to recur for all possible
        // moves and find the maximum/minimum. For example, in Tic-Tac-Toe,
        // the first player can make 9 possible moves.
        [TestMethod]
        public void Minimax_GetOptimalValue_ReturnsOptimalValue()
        {
            // arrange
            // The number of elements in scores must be a power of 2
            int[] scores = { 3, 5, 2, 9, 12, 5, 23, 23 };
            var n = scores.Length;
            var height = Log2(n);

            // act
            var actual = Game.Minimax(0, 0, true, scores, height);

            // assert
            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void Minimax__Returns()
        {
            // arrange
            char[,] board =
            {
                { 'x', '_', '_'},
                { '_', '_', '_'},
                { '_', '_', '_'}
            };

            // act
            var actual = Game.FindBestMove(board);

            // assert
            Assert.AreEqual(0, actual);
        }
    }
}

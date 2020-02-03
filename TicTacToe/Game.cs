using System;
using System.Collections.Generic;
using System.Linq;

public class Game
{
    public const char Player = 'x';
    public const char Opponent = 'o';
    public const char EmptyMove = '_';

    public static readonly int Infinity = int.MaxValue;

    private static int GetBoardSize(char[,] board)
    {
        if (board.GetLength(0) != board.GetLength(1))
        {
            throw new ArgumentException("The board dimensions must be equal.");
        }

        var size = board.GetLength(0);

        return size;
    }

    // Returns true if there are moves remaining on the board.
    // It returns false if there are no moves left to play.
    public static bool HasMovesRemaining(char[,] board)
    {
        var size = GetBoardSize(board);

        for (var i = 0; i < size; i++)
        {
            var slice = board.SliceRow(i);

            if (slice.Any(b => b == EmptyMove))
            {
                return true;
            }
        }

        return false;
    }

    // Returns the optimal value a maximizer can obtain. 
    // depth is current depth in game tree. 
    // nndex is index of current node in scores[]. 
    // isMaximum is true if current move is of maximizer, else false 
    // scores[] stores leaves of Game tree. 
    // height is maximum height of Game tree 
    public static int Minimax(int depth, int index, bool isMaximiser, int[] scores, int height)
    {
        // Terminating condition. i.e leaf node is reached 
        if (depth == height)
        {
            return scores[index];
        }

        // If current move is maximizer, find the maximum attainable value 
        if (isMaximiser)
        {
            return Math.Max(
                Minimax(depth + 1, index * 2, false, scores, height),
                Minimax(depth + 1, index * 2 + 1, false, scores, height));
        }

        // Else (If current move is Minimizer), find the minimum attainable value 
        else
        {
            return Math.Min(
                Minimax(depth + 1, index * 2, true, scores, height),
                Minimax(depth + 1, index * 2 + 1, true, scores, height));
        }
    }

    // This is the minimax function. It considers all 
    // the possible ways the game can go and returns 
    // the value of the board 
    public static int Minimax(char[,] board, int depth, bool isMaximiser)
    {
        var score = Evaluate(board);

        // If Maximizer has won the game  
        // return his/her evaluated score 
        if (score == Infinity)
        {
            return score;
        }

        // If Minimizer has won the game  
        // return his/her evaluated score 
        if (score == -Infinity)
        {
            return score;
        }

        // If there are no more moves and  
        // no winner then it is a tie 
        if (HasMovesRemaining(board) == false)
        {
            return 0;
        }

        var size = GetBoardSize(board);

        // If this maximizer's move 
        if (isMaximiser)
        {
            int best = -1000;

            // Traverse all cells 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Check if cell is empty 
                    if (board[i, j] == EmptyMove)
                    {
                        // Make the move 
                        board[i, j] = Player;

                        // Call minimax recursively and choose the maximum value 
                        best = Math.Max(best, Minimax(board, depth + 1, !isMaximiser));

                        // Undo the move 
                        board[i, j] = EmptyMove;
                    }
                }
            }

            return best;
        }
        // If this minimizer's move 
        else
        {
            int best = 1000;

            // Traverse all cells 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Check if cell is empty 
                    if (board[i, j] == EmptyMove)
                    {
                        // Make the move 
                        board[i, j] = Opponent;

                        // Call minimax recursively and choose the minimum value 
                        best = Math.Min(best, Minimax(board, depth + 1, !isMaximiser));

                        // Undo the move 
                        board[i, j] = EmptyMove;
                    }
                }
            }

            return best;
        }
    }

    public static int Evaluate(char[,] board)
    {
        IEnumerable<char> slice;
        var size = GetBoardSize(board);

        // Checking for Rows for X or O victory. 
        for (int i = 0; i < size; i++)
        {
            slice = board.SliceRow(i);

            if (slice.All(s => s == Player)) return +Infinity;
            if (slice.All(s => s == Opponent)) return -Infinity;

            // Checking for Columns for X or O victory. 
            slice = board.SliceColumn(i);

            if (slice.All(s => s == Player)) return +Infinity;
            if (slice.All(s => s == Opponent)) return -Infinity;
        }

        // Checking for Diagonals for X or O victory. 
        slice = board.SliceDiagonalLowerToUpper();

        if (slice.All(s => s == Player)) return +Infinity;
        if (slice.All(s => s == Opponent)) return -Infinity;

        slice = board.SliceDiagonalUpperToLower();

        if (slice.All(s => s == Player)) return +Infinity;
        if (slice.All(s => s == Opponent)) return -Infinity;

        // Else if none of them have won then return 0 
        return 0;
    }

    // This will return the best possible move for the player 
    public static Move FindBestMove(char[,] board)
    {
        var size = GetBoardSize(board);
        var bestScore = -1000;

        var bestMove = new Move
        {
            Row = -1,
            Column = -1
        };

        // Traverse all cells, evaluate minimax function  
        // for all empty cells. And return the cell  
        // with optimal value. 
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                // Check if cell is empty 
                if (board[i, j] == EmptyMove)
                {
                    // Make the move 
                    board[i, j] = Player;

                    // compute evaluation function for this move
                    var score = Minimax(board, 0, false);

                    // Undo the move 
                    board[i, j] = EmptyMove;

                    // If the value of the current move is 
                    // more than the best value, then update 
                    // best
                    if (score > bestScore)
                    {
                        bestMove.Row = i;
                        bestMove.Column = j;

                        bestScore = score;
                    }
                }
            }
        }

        return bestMove;
    }
}
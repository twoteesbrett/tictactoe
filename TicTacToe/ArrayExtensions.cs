using System.Collections;
using System.Collections.Generic;

public static class ArrayExtensions
{
    public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            yield return array[row, i];
        }
    }

    public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            yield return array[i, column];
        }
    }

    public static IEnumerable<T> SliceDiagonalLowerToUpper<T>(this T[,] array)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            yield return array[i, i];
        }
    }

    public static IEnumerable<T> SliceDiagonalUpperToLower<T>(this T[,] array)
    {
        var length = array.GetLength(0);

        for (var i = 0; i < length; i++)
        {
            yield return array[i, length - i - 1];
        }
    }
}
namespace d9.egl.core;
public static class Extensions
{
    public static IEnumerable<(int x, int y)> AllPoints<T>(this T[,] array)
    {
        for (int x = 0; x < array.GetLength(0); x++)
            for (int y = 0; y < array.GetLength(1); y++)
                yield return (x, y);
    }
    public static bool ContainsCoord<T>(this T[,] array, int x, int y)
    {
        return x >= 0 && x < array.GetLength(0) && y >= 0 && y < array.GetLength(1);
    }
    public static IEnumerable<(int x, int y)> SquareNeighborCoords<T>(this T[,] board, int x, int y, int radius = 1)
    {
        for(int x2 = -radius;  x2 <= radius; x2++)
            for(int y2 = -radius; y2 <= radius; y2++)
            {
                if (x2 == 0 && y2 == 0) continue;
                if (board.ContainsCoord(x + x2, y + y2))
                    yield return (x + x2, y + y2);
            }
    }
    public static bool Bool(this Random random)
        => random.NextDouble() < 0.5;
}

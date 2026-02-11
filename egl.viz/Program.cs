using d9.egl.core;
using d9.egl.core.Instance.Conway;
using d9.egl.viz.util;
using d9.utl.types;

namespace d9.egl.viz;

internal class Program
{
    [STAThread]
    private static void Main()
    {
        ConwayGame game = new(new ConwayReplicationRule(new DefaultDictionary<int, bool>(_ => true)
        {
            { 0, false },
            { 1, true },
            { 2, true },
            { 3, true },
            { 4, false },
            { 5, true },
            { 6, false },
            { 7, true },
            { 8, false },
        }));
        using SdlWindow window = new("test", 800, 600);
        bool[,] board = new bool[800, 600];
        board[13, 99] = true;
        while (window.Pump())
        {
            DrawBoard(board, window);
            board = game.Successor(board);
        }
    }
    private static void DrawBoard(bool[,] board, SdlWindow window)
    {
        window.Render.SetColor(0, 0, 0);
        window.Render.Clear();
        window.Render.SetColor(255, 255, 255);
        foreach((int x, int y) in board.AllPoints())
            if (board[x, y])
                window.Render.DrawPoint(x, y);
        window.Render.Present();
    }
}

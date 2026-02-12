using d9.egl.core;
using d9.egl.core.Instance.Conway;
using d9.egl.core.Instance.Evolution;
using d9.egl.viz.util;
using d9.utl;
using d9.utl.types;
using Hexa.NET.SDL3;

namespace d9.egl.viz;

internal class Program
{
    [STAThread]
    private static void Main()
    {
        // ConwayGame game = new(new ConwayReplicationRule(x => x.IsOdd()));
        using SdlWindow window = new("test", 800, 600);
        // bool[,] board = new bool[800, 600];
        // board[13, 99] = true;
        int scale = 6;
        EvolvableCell[,] board = new EvolvableCell[1920 / scale, 1080 / scale];
        foreach ((int x, int y) in board.AllPoints())
            board[x, y] = new(false, new([.. false.Repeat(9)]));
        EvolutionGame evolutionGame = new(
            new(x => {
                return 0.001;
                int alleles = x.Rule.Rule.Sum(x => x ? 1 : 0);
                return alleles / 9.0 + 0.1;
            }), new());
        board[1920 / scale / 2, 1080 / scale / 2] = new(true, new([true, false, true, false, false, false, false, false, false]));
        while (window.Pump())
        {
            DrawBoard(board, window, scale);
            board = evolutionGame.Successor(board);
        }
    }
    private static void DrawBoard(bool[,] board, SdlWindow window)
    {
        window.Render.SetColor(new HsvColor(0, 0.9, 0.1).ToRgba());
        window.Render.Clear();
        window.Render.SetColor(new HsvColor(0.5, 0.9, 0.9).ToRgba());
        foreach((int x, int y) in board.AllPoints())
            if (board[x, y])
                window.Render.DrawPoint(x, y);
        window.Render.Present();
    }
    private static void DrawBoard(EvolvableCell[,] board, SdlWindow window, int scale = 8)
    {
        // treat rule as a number in 0 .. 2^8 = H
        // S = 0.9
        // V = IsAlive ? 0.1 : 0.9
        window.Render.SetColor(0, 0, 0);
        window.Render.Clear();
        foreach((int x, int y) in board.AllPoints())
        {
            if (!board[x, y].IsAlive)
                continue;
            window.Render.SetColor(CellColor(board[x, y]));
            window.Render.FillRect(x * scale, y * scale, scale, scale);
        }
        window.Render.Present();
    }
    private static DefaultDictionary<bool[], double> _hueCache = new(x => x.ToHue());
    private static HsvColor CellColor(EvolvableCell cell)
    {
        return new(_hueCache[cell.Rule.Rule], 0.9, cell.IsAlive ? 0.9 : 0.1);
    }
}

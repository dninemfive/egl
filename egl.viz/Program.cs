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
        // bool[,] board = new bool[800, 600];
        // board[13, 99] = true;
        int scale = 2;
        using SdlWindow window = new("EGL", 1920 / scale, 1080 / scale);
        EvolutionReplicationRule rule = new(0.0001, 8);
        EvolvableCell[,] board = new EvolvableCell[1920 / scale, 1080 / scale];
        foreach ((int x, int y) in board.AllPoints())
            board[x, y] = rule.DEAD;
        EvolutionGame evolutionGame = new(rule, new());
        // todo: _alternative_ game where genotypes have a fixed number of alleles so you have e.g. [2,3] and [2,6] rules but no [2,3,4]
        // also something is leaking memory real bad ~~(probably the rect structs)~~ actually definitely not the rect structs but those should be checked too
        board[1920 / scale / 2, 1080 / scale / 2] = EvolvableCell.FromBools(true, [true, false, true, false, false, false, false, false, false]);
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
            window.Render.SetColor(_colors[board[x, y]]);
            // window.Render.FillRect(x * scale, y * scale, scale, scale);
            window.Render.DrawPoint(x, y);
        }
        window.Render.Present();
    }
    private static readonly DefaultDictionary<EvolvableCell, RgbaColor> _colors = new(x => new HsvColor(x.Rule / 512.0, 0.9, x.IsAlive ? 0.9 : 0.1).ToRgba());
}

using d9.egl.core;
using d9.egl.core.Instance.Evolution;
using d9.egl.core.Interface;
using d9.egl.viz.util;
using System.Threading.Tasks;

namespace d9.egl.viz;

internal class Program
{
    [STAThread]
    private static async Task Main()
    {
        int width = 900, height = 900;
        int scale = 3;
        using SdlWindow window = new("Evolutionary Game of Life", width, height, windowFlags: 0);
        EvolutionReplicationRule rule = new(0.0001, 8);
        EvolvableCell[,] board = new EvolvableCell[width / scale, height / scale];
        foreach ((int x, int y) in board.AllPoints())
            board[x, y] = rule.DEAD;
        EvolutionGame evolutionGame = new(rule, new());
        EvolutionaryBoardRenderer renderer = new(cell => new HsvColor(cell.Rule / 512.0, 0.9, 0.9).ToRgba(), scale: scale);
        // todo: _alternative_ game where genotypes have a fixed number of alleles so you have e.g. [2,3] and [2,6] rules but no [2,3,4]
        board[width / scale / 2, height / scale / 2] = EvolvableCell.FromBools(true, [true, false, true, false, false, false, false, false, false]);
        while (window.Pump())
        {
            window.DrawFrame(((IBoardRenderer<EvolvableCell[,]>)renderer).Render(board));
            board = await ((IArray2DAutomaton<EvolvableCell, EvolutionaryNeighborGetter, EvolutionReplicationRule>)evolutionGame).Successor(board);
        }
    }
}

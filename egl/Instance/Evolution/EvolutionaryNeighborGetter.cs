using d9.egl.core.Interface;

namespace d9.egl.core.Instance.Evolution;
public class EvolutionaryNeighborGetter
    : INeighborGetter<EvolvableCell[,], (int x, int y), EvolvableCell>
{
    public int MaxNeighbors => 8;

    public IEnumerable<EvolvableCell> NeighborsOf(EvolvableCell[,] board, (int x, int y) point)
        => board.SquareNeighborCoords(point.x, point.y).Select(p => board[p.x, p.y]);
}

using d9.egl.Interface;

namespace d9.egl.Instance;
public class ConwayNeighborGetter
    : INeighborGetter<bool[,], (int x, int y), bool>
{
    public IEnumerable<bool> NeighborsOf(bool[,] board, (int x, int y) point)
        => board.SquareNeighborCoords(point.x, point.y).Select(p => board[p.x, p.y]);
}

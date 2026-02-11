namespace d9.egl.Interface;
public interface INeighborGetter<TBoard, TPoint, TCell>
{
    public IEnumerable<TCell> NeighborsOf(TBoard board, TPoint point);
}

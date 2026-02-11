namespace d9.egl.Instance;
public class ConwayGame(ConwayReplicationRule rule)
{
    public ConwayReplicationRule Rule => rule;
    public ConwayNeighborGetter NeighborGetter => new();
    public bool[,] Successor(bool[,] state)
    {
        bool[,] next = new bool[state.GetLength(0), state.GetLength(1)];
        foreach ((int x, int y) in state.AllPoints())
        {
            next[x, y] = Rule.Successor(NeighborGetter.NeighborsOf(state, (x, y)));
        }
        return next;
    }
}

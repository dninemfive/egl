namespace d9.egl.core.Instance.Evolution;
public class EvolutionGame(EvolutionReplicationRule rule, EvolutionaryNeighborGetter neighborGetter)
{
    public EvolvableCell[,] Successor(EvolvableCell[,] state)
    {
        EvolvableCell[,] next = new EvolvableCell[state.GetLength(0), state.GetLength(1)];
        foreach ((int x, int y) in state.AllPoints())
            next[x, y] = rule.Successor(state[x, y], neighborGetter.NeighborsOf(state, (x, y)));
        return next;
    }
}
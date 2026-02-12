
using d9.egl.core.Instance.Evolution;
using System.Collections;
using System.Data;

namespace d9.egl.core.Interface;
public interface IArray2DAutomaton<C, N, R>
    : IAutomaton<C[,], (int x, int y), C, N, R>
    where N : INeighborGetter<C[,], (int x, int y), C>
    where R : IReplicationRule<C>
{
    public R Rule { get; }
    public N NeighborGetter { get; }
    async Task<C[,]> IAutomaton<C[,], (int x, int y), C, N, R>.Successor(C[,] state)
    {
        C[,] next = new C[state.GetLength(0), state.GetLength(1)];
        async Task reproduce((int x, int y) point)
        {
            (int x, int y) = point;
            await Task.Run(() => next[x, y] = Rule.Successor(state[x, y], NeighborGetter.NeighborsOf(state, point)));
        }
        await Task.WhenAll(state.AllPoints().Select(reproduce));
        return next;
    }
}

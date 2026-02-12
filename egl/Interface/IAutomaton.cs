namespace d9.egl.core.Interface;
public interface IAutomaton<B, P, C, N, R>
    where N : INeighborGetter<B, P, C>
    where R : IReplicationRule<C>
{
}

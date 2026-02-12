using d9.egl.core.Interface;

namespace d9.egl.core.Instance.Conway;
public class ConwayGame(ConwayReplicationRule rule)
    : IArray2DAutomaton<bool, ConwayNeighborGetter, ConwayReplicationRule>
{
    public ConwayReplicationRule Rule => rule;
    public ConwayNeighborGetter NeighborGetter => new();
}

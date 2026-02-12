using d9.egl.core.Interface;

namespace d9.egl.core.Instance.Evolution;
public class EvolutionGame(EvolutionReplicationRule rule, EvolutionaryNeighborGetter neighborGetter)
    : IArray2DAutomaton<EvolvableCell, EvolutionaryNeighborGetter, EvolutionReplicationRule>
{
    public EvolutionReplicationRule Rule => rule;
    public EvolutionaryNeighborGetter NeighborGetter => neighborGetter;
}
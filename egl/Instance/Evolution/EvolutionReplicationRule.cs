using d9.egl.core.Interface;
using d9.utl;

namespace d9.egl.core.Instance.Evolution;
public class EvolutionReplicationRule(Func<EvolvableCell, double> mutationRate)
    : IReplicationRule<EvolvableCell>
{
    public EvolvableCell Successor(EvolvableCell self, IEnumerable<EvolvableCell> neighbors)
    {
        IEnumerable<EvolvableCell> aliveNeighbors = neighbors.Where(x => x.IsAlive);
        bool alive = self.Rule.Rule[aliveNeighbors.Count()];
        if (!alive)
            return new(false, new([false, true, true, ..false.Repeat(6)]));
        Genotype rule = self.Rule.Mutate(mutationRate(self));
        if (aliveNeighbors.Any())
            rule = rule.BreedWith(aliveNeighbors.WeightedRandomElement(x => rule.DifferenceFrom(x.Rule)).Rule);
        return new(alive, rule);
    }
}

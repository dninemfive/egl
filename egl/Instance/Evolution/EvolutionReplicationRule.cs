using d9.egl.core.Interface;
using d9.utl;
using System.Data;

namespace d9.egl.core.Instance.Evolution;
public class EvolutionReplicationRule(double mutationRate, int maxMutations, int ruleLength = 9, Random? random = null)
    : IReplicationRule<EvolvableCell>
{
    public int RuleLength = ruleLength;
    public int MaxMutations = maxMutations;
    public double MutationRate => mutationRate;
    public Random Random => random ?? new();
    public readonly EvolvableCell DEAD = EvolvableCell.FromBools(true, [false, true, true, .. false.Repeat(6)]);
    public EvolvableCell Successor(EvolvableCell self, IEnumerable<EvolvableCell> neighbors)
    {
        IEnumerable<EvolvableCell> aliveNeighbors = neighbors.Where(x => x.IsAlive);
        bool previouslyAlive = self.IsAlive;
        bool alive = self.GenotypeAt(aliveNeighbors.Count());
        if (!alive)
            return DEAD;
        if (!previouslyAlive && aliveNeighbors.Any())
            self = aliveNeighbors.RandomElement();
        self = Mutate(self);
        if (aliveNeighbors.Any())
            self = Breed(self, aliveNeighbors.WeightedRandomElement(other => DifferenceBetween(self, other)));
        return self;
    }
    public EvolvableCell Breed(EvolvableCell a, EvolvableCell b)
    {
        bool[] genotype = new bool[RuleLength];
        for (int i = 0; i < RuleLength; i++)
            genotype[i] = Random.Bool() ? a.GenotypeAt(i) : b.GenotypeAt(i);
        return EvolvableCell.FromBools(true, genotype);
    }
    public EvolvableCell Mutate(EvolvableCell cell)
    {
        if (!cell.IsAlive)
            return DEAD;
        bool[] genotype = new bool[RuleLength];
        for(int i = 0; i < RuleLength; i++)
        {
            genotype[i] = cell.GenotypeAt(i);
        }
        for (int i = 0; i < MaxMutations; i++)
        {
            if (Random.NextDouble() > mutationRate)
                break;
            genotype[Random.Next(0, RuleLength)] = Random.Bool();
        }
        return EvolvableCell.FromBools(true, genotype);
    }
    public int DifferenceBetween(EvolvableCell a, EvolvableCell b)
    {
        int result = 0;
        for (int i = 0; i < RuleLength; i++)
            if (a.GenotypeAt(i) != b.GenotypeAt(i))
                result++;
        return result;
    }
}

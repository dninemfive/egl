namespace d9.egl.core.Instance.Evolution;
public class Genotype(bool[] rule, Random? random = null)
{
    public Random Random = random ?? new();
    public readonly bool[] Rule = rule;
    public Genotype BreedWith(Genotype mate)
    {
        bool[] result = new bool[Rule.Length];
        for (int i = 0; i < Rule.Length; i++)
            result[i] = Random.Bool() ? Rule[i] : mate.Rule[i];
        return new(result, Random);
    }
    public Genotype Mutate(double mutationRate)
    {
        bool[] result = new bool[Rule.Length];
        Rule.CopyTo(result, 0);
        for(int i = 0; i < Rule.Length; i++)
        {
            if (Random.NextDouble() > mutationRate)
                break;
            result[Random.Next(0, Rule.Length)] = Random.Bool();
        }
        return new(result, Random);
    }
}

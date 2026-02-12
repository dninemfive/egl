namespace d9.egl.core.Instance.Evolution;
public class Genotype(bool[] rule, Random? random = null)
{
    public Random Random = random ?? new();
    public readonly bool[] Rule = rule;
}

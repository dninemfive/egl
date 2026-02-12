namespace d9.egl.core.Instance.Evolution;
public record struct EvolvableCell(short Data)
{
    const short LIFE_MASK = 0b0000000000000001;
    public readonly bool IsAlive => (Data & LIFE_MASK) == 1;
    public readonly bool GenotypeAt(int index)
        => (Data & (1 << (index + 1))) == 1;
    public static EvolvableCell FromBools(bool isAlive, bool[] genotype)
    {
        short data = (short)(isAlive ? 1 : 0);
        short flag = 0b10;
        foreach(bool b in genotype)
        {
            if (b)
                data |= flag;
            flag <<= 1;
        }
        return new(data);
    }
    public readonly int Rule => Data >> 1;
}
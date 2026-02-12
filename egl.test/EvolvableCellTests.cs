using d9.egl.core.Instance.Evolution;

namespace d9.egl.test;
[TestFixture]
public class EvolvableCellTests
{
    [Test]
    [TestCase(0b1, ExpectedResult = true)]
    [TestCase(0b0, ExpectedResult = false)]
    public bool IsAlive(short data)
    {
        EvolvableCell cell = new(data);
        return cell.IsAlive;
    }
    [Test]
    [TestCase(0b000001111111110, 0, ExpectedResult = true)]
    [TestCase(0b000001111111110, 1, ExpectedResult = true)]
    [TestCase(0b000001111111110, 2, ExpectedResult = true)]
    [TestCase(0b000001111111110, 3, ExpectedResult = true)]
    [TestCase(0b000001111111110, 4, ExpectedResult = true)]
    [TestCase(0b000001111111110, 5, ExpectedResult = true)]
    [TestCase(0b000001111111110, 6, ExpectedResult = true)]
    [TestCase(0b000001111111110, 7, ExpectedResult = true)]
    [TestCase(0b000001111111110, 8, ExpectedResult = true)]
    [TestCase(0b111110000000001, 0, ExpectedResult = false)]
    [TestCase(0b111110000000001, 1, ExpectedResult = false)]
    [TestCase(0b111110000000001, 2, ExpectedResult = false)]
    [TestCase(0b111110000000001, 3, ExpectedResult = false)]
    [TestCase(0b111110000000001, 4, ExpectedResult = false)]
    [TestCase(0b111110000000001, 5, ExpectedResult = false)]
    [TestCase(0b111110000000001, 6, ExpectedResult = false)]
    [TestCase(0b111110000000001, 7, ExpectedResult = false)]
    [TestCase(0b111110000000001, 8, ExpectedResult = false)]
    public bool GenotypeAt(short data, int index)
    {
        return new EvolvableCell(data).GenotypeAt(index);
    }
}

using d9.egl.Interface;
namespace d9.egl.Instance;
public class ConwayReplicationRule(IDictionary<int, bool> rule)
    : IReplicationRule<bool>
{
    public IReadOnlyDictionary<int, bool> Rule => rule.AsReadOnly();
    public bool Successor(IEnumerable<bool> neighbors)
        => Rule[neighbors.Where(x => x).Count()];
}
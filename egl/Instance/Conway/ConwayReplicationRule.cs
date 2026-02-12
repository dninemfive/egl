using d9.egl.core.Interface;

namespace d9.egl.core.Instance.Conway;
public class ConwayReplicationRule(Func<int, bool> rule)
    : IReplicationRule<bool>
{
    private readonly Func<int, bool> _rule = rule;
    public bool Successor(bool _, IEnumerable<bool> neighbors)
        => _rule(neighbors.Where(x => x).Count());
}
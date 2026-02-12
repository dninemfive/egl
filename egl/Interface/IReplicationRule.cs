namespace d9.egl.core.Interface;
public interface IReplicationRule<T>
{
    public T Successor(T self, IEnumerable<T> neighbors);
}
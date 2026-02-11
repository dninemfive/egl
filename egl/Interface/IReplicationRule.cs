namespace d9.egl.core.Interface;
public interface IReplicationRule<T>
{
    public T Successor(IEnumerable<T> neighbors);
}
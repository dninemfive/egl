namespace d9.egl;
public interface IReplicationRule<T>
{
    public T Successor(IEnumerable<T> neighbors);
}
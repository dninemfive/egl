namespace d9.egl.Interface;
public interface IReplicationRule<T>
{
    public T Successor(IEnumerable<T> neighbors);
}
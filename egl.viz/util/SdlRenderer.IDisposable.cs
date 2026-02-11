using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlRenderer
    : IDisposable
{
    private bool _disposed;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            SDL.DestroyRenderer(_renderer);
            _disposed = true;
        }
    }
    ~SdlRenderer()
        => Dispose(false);
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

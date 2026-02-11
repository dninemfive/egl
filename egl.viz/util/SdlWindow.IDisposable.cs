using d9.utl;
using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlWindow
    : IDisposable
{
    private bool _disposed;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                Render.Dispose();
            SDL.DestroyWindow(_window);
            SDL.Quit();
            _disposed = true;
        }
    }
    ~SdlWindow()
        => Dispose(false);
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

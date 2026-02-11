using d9.utl;
using SDL3;

namespace egl.viz.util;
public partial class SdlWindow
    : IDisposable
{
    private bool _disposed;
    private readonly nint _renderer, _window;
    private static Exception LogAndMakeException(string acting, SDL.LogCategory category, params object[] args)
    {
        string msg = $"Caught SDL error when {acting}: {SDL.GetError()}! Relevant args: {args.ListNotation()}";
        return new Exception(msg);
    }
    #region initialization
    public SdlWindow(string title, int width, int height, SDL.InitFlags initFlags = SDL.InitFlags.Video, SDL.WindowFlags windowFlags = 0)
    {
        if (!SDL.Init(initFlags))
            throw LogAndMakeException("initializing SDL", SDL.LogCategory.System, title, width, height, initFlags, windowFlags);
        if(!SDL.CreateWindowAndRenderer(title, width, height, windowFlags, out _window, out _renderer))
            throw LogAndMakeException("creating window and renderer", SDL.LogCategory.Application, title, width, height, initFlags, windowFlags);
    }
    #endregion initialization
    #region disposal
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            // if (disposing) ;

            SDL.DestroyRenderer(_renderer);
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
    #endregion disposal
}

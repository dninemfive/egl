using d9.utl;
using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlWindow
    : IDisposable
{
    private bool _disposed;
    private readonly SDLWindowPtr _window;
    private readonly SDLRendererPtr _renderer;

    public uint WindowId => SDL.GetWindowID(_window); 
    private static Exception LogAndMakeException(string acting, SDLLogCategory category, params object[] args)
    {
        string msg = $"Caught SDL error when {acting}: {SDL.GetErrorS()}! Relevant args: {args.ListNotation()}";
        return new Exception(msg);
    }
    #region initialization
    public SdlWindow(string title, int width, int height, 
        SDLInitFlags initFlags = SDLInitFlags.Events | SDLInitFlags.Video, 
        SDLWindowFlags windowFlags = SDLWindowFlags.Resizable)
    {
        if (!SDL.Init((uint)initFlags))
            throw LogAndMakeException("initializing SDL", SDLLogCategory.System, title, width, height, initFlags, windowFlags);
        _window = SDL.CreateWindow(title, width, height, (ulong)windowFlags);
        if(_window.IsNull)
            throw LogAndMakeException("creating window", SDLLogCategory.Application, title, width, height, initFlags, windowFlags);
        _renderer = SDL.CreateRenderer(_window, title);
        //if (_renderer.IsNull)
        //    throw LogAndMakeException("creating renderer", SDLLogCategory.Application, "renderer", width, height, initFlags, windowFlags);
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

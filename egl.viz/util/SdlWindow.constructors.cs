using d9.utl;
using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlWindow
{
    private readonly SDLWindowPtr _window;
    public readonly SdlRenderer Render;
    public SdlWindow(string title, int width, int height, 
        SDLInitFlags initFlags = SDLInitFlags.Events | SDLInitFlags.Video, 
        SDLWindowFlags windowFlags = SDLWindowFlags.Resizable)
    {
        if (!SDL.Init((uint)initFlags))
            throw InformativeException("initializing SDL", SDLLogCategory.System, initFlags);
        _window = SDL.CreateWindow(title, width, height, (ulong)windowFlags);
        if(_window.IsNull)
            throw InformativeException("creating window", SDLLogCategory.Application, title, width, height, windowFlags);
        Render = new(_window);
        if (Render.IsNull)
            throw InformativeException("creating renderer", SDLLogCategory.Application);
    }
}

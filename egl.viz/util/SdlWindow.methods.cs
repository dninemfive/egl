using d9.utl;
using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlWindow
{
    public static bool PollEvent(out SDLEvent e)
    {
        e = default;
        return SDL.PollEvent(ref e);
    }
    public bool ShouldCloseFor(SDLEvent e)
        => (SDLEventType)e.Type switch
        {
            SDLEventType.Quit or SDLEventType.Terminating => true,
            SDLEventType.WindowCloseRequested => e.Window.WindowID == WindowId,
            _ => false
        };
    public bool SetColor(byte r, byte g, byte b, byte a = 255)
        => SDL.SetRenderDrawColor(_renderer, r, g, b, a);
    public bool RenderPoint(float x, float y)
        => SDL.RenderPoint(_renderer, x, y);
    public bool Pump()
    {
        SDL.PumpEvents();
        while (PollEvent(out SDLEvent e))
            if (ShouldCloseFor(e))
                return false;
        return true;
    }
    public bool RenderClear()
        => SDL.RenderClear(_renderer);
}

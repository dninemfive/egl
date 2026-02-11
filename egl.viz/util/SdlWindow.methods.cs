using d9.utl;
using Hexa.NET.SDL3;

namespace d9.egl.viz.util;
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
    public bool Pump()
    {
        SDL.PumpEvents();
        while (PollEvent(out SDLEvent e))
            if (ShouldCloseFor(e))
                return false;
        return true;
    }
}

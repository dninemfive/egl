using d9.utl;
using SDL3;

namespace egl.viz.util;
public partial class SdlWindow
{
    public bool SetRenderDrawColor(byte r, byte g, byte b, byte a)
        => SDL.SetRenderDrawColor(_renderer, r, g, b, a);
    public static bool PollEvent(out SDL.Event e)
        => SDL.PollEvent(out e);
    public bool RenderClear()
        => SDL.RenderClear(_renderer);
    public bool RenderPresent()
        => SDL.RenderPresent(_renderer);
    public bool RenderLoop()
    {
        bool result = true;
        while (PollEvent(out SDL.Event e))
            if ((SDL.EventType)e.Type == SDL.EventType.Quit)
                result = false;
        RenderClear();
        RenderPresent();
        return result;
    }
}

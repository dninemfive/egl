using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlRenderer
{
    public bool SetColor(byte r, byte g, byte b, byte a = 255)
        => SDL.SetRenderDrawColor(_renderer, r, g, b, a);
    public bool DrawPoint(float x, float y)
        => SDL.RenderPoint(_renderer, x, y);
    public bool Clear()
        => SDL.RenderClear(_renderer);
    public bool Present()
        => SDL.RenderPresent(_renderer);
}

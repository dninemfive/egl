using Hexa.NET.SDL3;

namespace d9.egl.viz.util;
public partial class SdlRenderer
{
    public bool SetColor(byte r, byte g, byte b, byte a = 255)
        => SDL.SetRenderDrawColor(_renderer, r, g, b, a);
    public bool SetColor(RgbaColor color)
    {
        (byte r, byte g, byte b, byte a) = color;
        return SetColor(r, g, b, a);
    }
    public bool SetColor(HsvColor color)
        => SetColor(color.ToRgba());
    public bool DrawPoint(float x, float y)
        => SDL.RenderPoint(_renderer, x, y);
    public bool Clear()
        => SDL.RenderClear(_renderer);
    public bool Present()
        => SDL.RenderPresent(_renderer);
    public bool DrawRect(SDLFRect rect)
        => SDL.RenderRect(_renderer, rect);
    public bool DrawRect(double x, double y, double width, double height)
        => SDL.RenderRect(_renderer, 
            new SDLFRect(float.CreateTruncating(x), 
                         float.CreateTruncating(y), 
                         float.CreateTruncating(width), 
                         float.CreateTruncating(height)));
    public bool FillRect(double x, double y, double width, double height)
        => SDL.RenderFillRect(_renderer,
            new SDLFRect(float.CreateTruncating(x),
                         float.CreateTruncating(y),
                         float.CreateTruncating(width),
                         float.CreateTruncating(height)));
}

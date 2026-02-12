using Hexa.NET.SDL3;

namespace d9.egl.viz.util;
public partial class SdlRenderer(SDLRendererPtr ptr)
{
    private readonly SDLRendererPtr _renderer = ptr;
    public SdlRenderer(SDLWindowPtr parent) : this(SDL.CreateRenderer(parent, (byte)default)) { }
}

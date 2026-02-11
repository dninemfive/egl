using Hexa.NET.SDL3;

namespace d9.egl.viz.util;
public partial class SdlWindow
    : IDisposable
{
    public uint WindowId => SDL.GetWindowID(_window);
}

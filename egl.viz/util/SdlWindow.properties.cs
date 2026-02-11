using d9.utl;
using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlWindow
    : IDisposable
{
    public uint WindowId => SDL.GetWindowID(_window);
}

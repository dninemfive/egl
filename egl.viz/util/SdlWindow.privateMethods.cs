using d9.utl;
using Hexa.NET.SDL3;

namespace egl.viz.util;
public partial class SdlWindow
    : IDisposable
{
    private static Exception InformativeException(string acting, SDLLogCategory category, params object[] args)
        => new($"Caught SDL error when {acting}: {SDL.GetErrorS()}! Relevant args: {args.ListNotation()}");
}

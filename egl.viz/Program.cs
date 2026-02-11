using egl.viz.util;

namespace egl.viz;

internal class Program
{
    [STAThread]
    private static void Main()
    {
        using SdlWindow window = new("test", 800, 600);
        while (window.RenderLoop()) ;
    }
}

using egl.viz.util;

namespace egl.viz;

internal class Program
{
    [STAThread]
    private static void Main()
    {
        using SdlWindow window = new("test", 800, 600);
        window.SetColor(255, 255, 255);
        while (window.Pump())
        {
            window.RenderPoint(0.25f, 0.25f);
        }
    }
}

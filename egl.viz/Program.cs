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
            window.SetColor(255, 0, 255);
            window.RenderPoint(300, 300);
            // window.RenderClear();
            window.RenderPresent();
        }
    }
}

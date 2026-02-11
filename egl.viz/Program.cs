using egl.viz.util;

namespace egl.viz;

internal class Program
{
    [STAThread]
    private static void Main()
    {
        using SdlWindow window = new("test", 800, 600);
        while (window.Pump())
        {
            window.Render.SetColor(255, 0, 255);
            window.Render.DrawPoint(300, 300);
            // window.RenderClear();
            window.Render.Present();
        }
    }
}

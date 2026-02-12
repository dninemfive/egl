

namespace d9.egl.viz.util;
public class ConwayBoardRenderer(RgbaColor? foregroundColor = null, RgbaColor? backgroundColor = null, int scale = 1)
    : IBoardRenderer<bool[,]>
{
    public readonly RgbaColor ForegroundColor = foregroundColor ?? RgbaColor.White;
    public readonly RgbaColor BackgroundColor = backgroundColor ?? RgbaColor.Black;
    public int Scale => scale;
    public RgbaColor ColorFor(bool value)
        => value ? ForegroundColor : BackgroundColor;
    public Action<SdlWindow> Render(bool[,] board)
        => ((IBoardRenderer<bool[,]>)this).Render(board);
}

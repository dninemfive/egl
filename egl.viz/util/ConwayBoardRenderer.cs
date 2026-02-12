

namespace d9.egl.viz.util;
public class ConwayBoardRenderer(RgbaColor? foregroundColor = null, RgbaColor? backgroundColor = null, int scale = 1)
    : IArrayRenderer2D<bool>
{
    public readonly RgbaColor ForegroundColor = foregroundColor ?? RgbaColor.White;
    public readonly RgbaColor BackgroundColor = backgroundColor ?? RgbaColor.Black;
    public int Scale => scale;
    public RgbaColor ColorFor(bool value)
        => value ? ForegroundColor : BackgroundColor;
}

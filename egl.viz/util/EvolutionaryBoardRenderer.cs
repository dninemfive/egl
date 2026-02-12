

using d9.egl.core.Instance.Evolution;
using d9.utl.types;

namespace d9.egl.viz.util;
public class EvolutionaryBoardRenderer(Func<EvolvableCell, RgbaColor> func, RgbaColor? backgroundColor = null, int scale = 1)
    : IArrayRenderer2D<EvolvableCell>
{
    public readonly RgbaColor BackgroundColor = backgroundColor ?? RgbaColor.Black;
    private readonly DefaultDictionary<EvolvableCell, RgbaColor> _colors = new(func);
    public int Scale => scale;
    public RgbaColor ColorFor(EvolvableCell cell)
        => cell.IsAlive ? _colors[cell] : BackgroundColor;
}

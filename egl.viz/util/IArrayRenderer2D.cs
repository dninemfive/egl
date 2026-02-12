using d9.egl.core;

namespace d9.egl.viz.util;
public interface IArrayRenderer2D<TCell>
    : IBoardRenderer<TCell[,]>
{
    public RgbaColor? ColorFor(TCell cell);
    Action<SdlWindow> IBoardRenderer<TCell[,]>.Render(TCell[,] board)
    {
        return window =>
        {
            foreach ((int x, int y) in board.AllPoints())
            {
                if (ColorFor(board[x, y]) is RgbaColor color)
                {
                    window.Render.SetColor(color);
                    window.Render.SquareAt(x * Scale, y * Scale, Scale);
                }
            }
        };
    }
}

namespace d9.egl.viz.util;
public interface IBoardRenderer<T>
{
    public int Scale { get; }
    public Action<SdlWindow> Render(T board);
}

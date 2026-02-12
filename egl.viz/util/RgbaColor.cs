namespace d9.egl.viz.util;
public record RgbaColor(byte R, byte G, byte B, byte A = 255)
{
    public static readonly RgbaColor Black = new(0, 0, 0);
    public static readonly RgbaColor White = new(255, 255, 255);
}

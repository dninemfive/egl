namespace d9.egl.viz.util;
public static class ColorConversionExtensions
{
    public static RgbaColor ToRgba(this HsvColor color)
    {
        (double h, double s, double v, double a) = color;
        double c = s * v;
        double h_prime = 6 * h;
        double x = c * (1 - Math.Abs(h_prime % 2 - 1));
        double m = v - c;
        (double r_1, double g_1, double b_1) = (ValueTuple<double, double, double>)(h_prime switch
        {
            >= 0 and < 1 => (c, x, 0),
            < 2 => (x, c, 0),
            < 3 => (0, c, x),
            < 4 => (0, x, c),
            < 5 => (x, 0, c),
            < 6 => (c, 0, x),
            _ => throw new Exception() 
        });
        (double r, double g, double b) = (r_1 + m, g_1 + m, b_1 + m);
        return new((byte)(r * byte.MaxValue), (byte)(g * byte.MaxValue), (byte)(b * byte.MaxValue));
    }
    public static HsvColor ToHsv(this RgbaColor color)
    {
        throw new NotImplementedException();
    }
    public static double ToHue(this bool[] bools)
    {
        double result = 0, max = 0;
        double addend = 1;
        for (int i = 0; i < bools.Length; i++)
        {
            if (bools[i])
                result += addend;
            max += addend;
            addend *= 2;
        }
        return result / addend;
    }
}

using JPEG.Images;

namespace JPEG.Benchmarks.Benchmarks.SetPixelsBenchmarks;

public class LoopsSetPixels
{
    private const float Coef1 = 298.082f;
    private const float Coef2 = 408.583f;
    private const float Coef3 = 256.0f;
    private const float Coef4 = 222.921f;
    private const float Coef5 = 100.291f;
    private const float Coef6 = 208.120f;
    private const float Coef7 = 135.576f;
    private const float Coef8 = 516.412f;
    private const float Coef9 = 276.836f;

    public static void SetPixels(
        Matrix matrix,
        Span<float> a,
        Span<float> b,
        Span<float> c,
        int yOffset,
        int xOffset)
    {
        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                matrix.Pixels[(yOffset + y) * matrix.Width + (xOffset + x)].Value1 =
                    (Coef1 * a[y * 8 + x] + Coef2 * c[y * 8 + x]) / Coef3 - Coef4;
                matrix.Pixels[(yOffset + y) * matrix.Width + (xOffset + x)].Value2 =
                    (Coef1 * a[y * 8 + x] - Coef5 * b[y * 8 + x] - Coef6 * c[y * 8 + x]) / Coef3 + Coef7;
                matrix.Pixels[(yOffset + y) * matrix.Width + (xOffset + x)].Value3 =
                    (Coef1 * a[y * 8 + x] + Coef8 * b[y * 8 + x]) / Coef3 - Coef9;
            }
        }
    }
}
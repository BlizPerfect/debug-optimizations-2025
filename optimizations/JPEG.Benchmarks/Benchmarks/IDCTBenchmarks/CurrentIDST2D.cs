using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.IDCTBenchmarks;

public class CurrentIDST2D
{
    private const double Beta = 0.25;
    
    private static readonly double[] AlphaCache = new double[]
    {
        0.70710678118654752440084436210485,
        1.0,
        1.0,
        1.0,
        1.0,
        1.0,
        1.0,
        1.0,
    };
    
    private static readonly double[,] cosCacheX;
    private static readonly double[,] cosCacheY;
    
    static CurrentIDST2D()
    {
        var multiplicationPart = Math.PI / (2 * JpegProcessor.DctSize);

        cosCacheX = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];
        cosCacheY = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];

        var u = 0;
        var x = 0;

        var v = 0;
        var y = 0;

        for (u = 0; u < JpegProcessor.DctSize; u++)
        {
            for (x = 0; x < JpegProcessor.DctSize; x++)
            {
                cosCacheX[u, x] = Math.Cos((2 * x + 1) * u * multiplicationPart);
            }
        }

        for (v = 0; v < JpegProcessor.DctSize; v++)
        {
            for (y = 0; y < JpegProcessor.DctSize; y++)
            {
                cosCacheY[v, y] = Math.Cos((2 * y + 1) * v * multiplicationPart);
            }
        }
    }

    public static void IDCT2D(double[,] coeffs, double[,] output)
    {
        var y = 0;
        var u = 0;
        var sum = 0.0;
        var uSum = 0.0;
        var v = 0;

        for (var x = 0; x < JpegProcessor.DctSize; x++)
        {
            for (y = 0; y < JpegProcessor.DctSize; y++)
            {
                sum = 0.0;

                for (u = 0; u < JpegProcessor.DctSize; u++)
                {
                    uSum = 0.0;
                    for (v = 0; v < JpegProcessor.DctSize; v++)
                    {
                        uSum += coeffs[u, v] * cosCacheX[u, x] * cosCacheY[v, y] * AlphaCache[u] * AlphaCache[v];
                    }

                    sum += uSum;
                }

                output[x, y] = sum * Beta + JpegProcessor.DctSizeDoubleSquare;
            }
        }
    }
}
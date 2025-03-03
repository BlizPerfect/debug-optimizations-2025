using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.DSTBenchmarks;

public class PrecomputedNonLinqDCT2D
{
    private static readonly double[,] cosCacheX;
    private static readonly double[,] cosCacheY;

    static PrecomputedNonLinqDCT2D()
    {
        cosCacheX = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];
        cosCacheY = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];

        for (var u = 0; u < JpegProcessor.DctSize; u++)
        {
            for (var x = 0; x < JpegProcessor.DctSize; x++)
            {
                cosCacheX[u, x] = Math.Cos((2 * x + 1) * u * Math.PI / (2 * JpegProcessor.DctSize));
            }
        }

        for (var v = 0; v < JpegProcessor.DctSize; v++)
        {
            for (var y = 0; y < JpegProcessor.DctSize; y++)
            {
                cosCacheY[v, y] = Math.Cos((2 * y + 1) * v * Math.PI / (2 * JpegProcessor.DctSize));
            }
        }
    }

    public static double[,] DCT2D(double[,] input)
    {
        var height = input.GetLength(0);
        var width = input.GetLength(1);
        var result = new double[width, height];

        for (var u = 0; u < width; u++)
        {
            for (var v = 0; v < height; v++)
            {
                var sum = 0.0;
                for (var x = 0; x < width; x++)
                {
                    var basisSum = 0.0;
                    for (int y = 0; y < height; y++)
                    {
                        basisSum += input[x, y] * cosCacheX[u, x] * cosCacheY[v, y];
                    }

                    sum += basisSum;
                }

                result[u, v] = sum * Utilities.Beta(height, width) * Utilities.Alpha(u) * Utilities.Alpha(v);
            }
        }

        return result;
    }
}
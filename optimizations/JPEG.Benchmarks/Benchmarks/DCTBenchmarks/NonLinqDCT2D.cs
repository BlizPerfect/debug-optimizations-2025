namespace JPEG.Benchmarks.Benchmarks.DSTBenchmarks;

public class NonLinqDCT2D
{
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
                    for (var y = 0; y < height; y++)
                    {
                        basisSum += Utilities.BasisFunction(input[x, y], u, v, x, y, height, width);
                    }

                    sum += basisSum;
                }

                result[u, v] = sum * Utilities.Beta(height, width) * Utilities.Alpha(u) * Utilities.Alpha(v);
            }
        }

        return result;
    }
}
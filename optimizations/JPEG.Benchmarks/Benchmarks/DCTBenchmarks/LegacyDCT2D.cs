namespace JPEG.Benchmarks.Benchmarks.DSTBenchmarks;

public class LegacyDCT2D
{
    public static double[,] DCT2D(double[,] input)
    {
        var height = input.GetLength(0);
        var width = input.GetLength(1);
        var coeffs = new double[width, height];

        OldMathEx.LoopByTwoVariables(
            0, width,
            0, height,
            (u, v) =>
            {
                var sum = OldMathEx
                    .SumByTwoVariables(
                        0, width,
                        0, height,
                        (x, y) => Utilities.BasisFunction(input[x, y], u, v, x, y, height, width));

                coeffs[u, v] = sum * Utilities.Beta(height, width) * Utilities.Alpha(u) * Utilities.Alpha(v);
            });

        return coeffs;
    }
}
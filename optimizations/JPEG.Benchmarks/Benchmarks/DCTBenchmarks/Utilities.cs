namespace JPEG.Benchmarks.Benchmarks.DSTBenchmarks;

public static class Utilities
{
    public static double Alpha(int u)
    {
        if (u == 0)
        {
            return 0.70710678118654752440084436210485;
        }

        return 1;
    }

    public static double Beta(int height, int width)
        => 1d / width + 1d / height;

    public static double BasisFunction(double a, double u, double v, double x, double y, int height, int width)
    {
        var b = Math.Cos(((2d * x + 1d) * u * Math.PI) / (2 * width));
        var c = Math.Cos(((2d * y + 1d) * v * Math.PI) / (2 * height));

        return a * b * c;
    }
}
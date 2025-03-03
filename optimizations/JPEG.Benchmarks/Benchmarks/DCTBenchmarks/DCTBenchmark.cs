using BenchmarkDotNet.Attributes;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.DSTBenchmarks;

[MemoryDiagnoser]
public class DCTBenchmark
{
    private readonly Random random = new Random();
    private double[,] inputMatrix2D = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];
    private double[] inputMatrix1D = new double[JpegProcessor.DctSizeSquare];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < JpegProcessor.DctSize; i++)
        {
            for (var j = 0; j < JpegProcessor.DctSize; j++)
            {
                inputMatrix2D[i, j] = random.NextDouble();
                inputMatrix1D[i * JpegProcessor.DctSize + j] = random.NextDouble();
            }
        }
    }

    [Benchmark]
    public void Compress_LegacyDCT2D()
    {
        LegacyDCT2D.DCT2D(inputMatrix2D);
    }

    [Benchmark]
    public void Compress_NonLinqDCT2D()
    {
        NonLinqDCT2D.DCT2D(inputMatrix2D);
    }

    [Benchmark]
    public void Compress_PrecomputedNonLinqDCT2D()
    {
        PrecomputedNonLinqDCT2D.DCT2D(inputMatrix2D);
    }

    [Benchmark]
    public void Compress_FullyUnrolledDST2D()
    {
        Span<double> result = stackalloc double[JpegProcessor.DctSize * JpegProcessor.DctSize];
        FullyUnrolledDST2D.DCT2D(inputMatrix1D, result);
    }
}
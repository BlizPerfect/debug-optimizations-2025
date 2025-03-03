using BenchmarkDotNet.Attributes;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.IDCTBenchmarks;

[MemoryDiagnoser]
public class IDCTBenchmark
{
    private readonly Random random = new Random();
    private double[,] inputMatrix = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < JpegProcessor.DctSize; i++)
        {
            for (var j = 0; j < JpegProcessor.DctSize; j++)
            {
                inputMatrix[i, j] = random.NextDouble();
            }
        }
    }

    [Benchmark]
    public void Uncompress_CurrentIDST2D()
    {
        CurrentIDST2D.IDCT2D(inputMatrix, new double[JpegProcessor.DctSize, JpegProcessor.DctSize]);
    }

    [Benchmark]
    public void Uncompress_FullyUnrolledIDST2D()
    {
        FullyUnrolledIDST2D.IDCT2D(inputMatrix, new double[JpegProcessor.DctSize, JpegProcessor.DctSize]);
    }

    [Benchmark]
    public void Uncompress_FullyUnrolledBakedIDST2D()
    {
        FullyUnrolledBakedIDST2D.IDCT2D(inputMatrix, new double[JpegProcessor.DctSize, JpegProcessor.DctSize]);
    }
}
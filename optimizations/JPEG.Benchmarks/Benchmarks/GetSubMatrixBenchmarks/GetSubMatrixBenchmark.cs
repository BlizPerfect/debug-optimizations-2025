using BenchmarkDotNet.Attributes;
using JPEG.Images;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.GetSubMatrixBenchmarks;

[MemoryDiagnoser]
public class GetSubMatrixBenchmark
{
    private readonly Random random = new Random();
    private Matrix matrix = new Matrix(JpegProcessor.DctSize, JpegProcessor.DctSize);
    private float[] a = new float[JpegProcessor.DctSizeSquare];
    private float[] b = new float[JpegProcessor.DctSizeSquare];
    private float[] c = new float[JpegProcessor.DctSizeSquare];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < JpegProcessor.DctSizeSquare; i++)
        {
            matrix.Pixels[i].Value1 = random.NextSingle();
            matrix.Pixels[i].Value2 = random.NextSingle();
            matrix.Pixels[i].Value3 = random.NextSingle();
        }
    }

    [Benchmark]
    public void GetSubMatrixUnrolled()
    {
        UnrolledGetSubMatrix.GetSubMatrix(
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan(),
            matrix,
            0,
            0);
    }

    [Benchmark]
    public void GetSubMatrixVectors()
    {
        VectorsGetSubMatrix.GetSubMatrix(
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan(),
            matrix,
            0,
            0);
    }
}
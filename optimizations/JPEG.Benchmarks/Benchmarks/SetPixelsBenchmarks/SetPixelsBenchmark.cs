using BenchmarkDotNet.Attributes;
using JPEG.Images;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.SetPixelsBenchmarks;

[MemoryDiagnoser]
public class SetPixelsBenchmark
{
    private readonly Random random = new Random();
    private Matrix matrix = new Matrix(JpegProcessor.DctSize, JpegProcessor.DctSize);
    private readonly float[] a = new float[JpegProcessor.DctSizeSquare];
    private readonly float[] b = new float[JpegProcessor.DctSizeSquare];
    private readonly float[] c = new float[JpegProcessor.DctSizeSquare];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < 64; i++)
        {
            a[i] = random.NextSingle();
            b[i] = random.NextSingle();
            c[i] = random.NextSingle();
        }
    }

    [Benchmark]
    public void SetPixelsLoops()
    {
        LoopsSetPixels.SetPixels(
            matrix,
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan(),
            0,
            0);
    }

    [Benchmark]
    public void SetPixelsUnrolled()
    {
        UnrolledSetPixels.SetPixels(
            matrix,
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan(),
            0,
            0);
    }

    [Benchmark]
    public void SetPixelsVectors()
    {
        VectorsSetPixels.SetPixels(
            matrix,
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan(),
            0,
            0);
    }

    [Benchmark]
    public void SetPixelsVectorsUnrolled()
    {
        VectorsUnrolledSetPixels.SetPixels(
            matrix,
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan(),
            0,
            0);
    }
}
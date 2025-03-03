using BenchmarkDotNet.Attributes;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.QuantizeBenchmarks;

[MemoryDiagnoser]
public class QuantizeBenchmark
{
    private readonly Random random = new Random();
    private readonly float[] a = new float[JpegProcessor.DctSizeSquare];
    private readonly byte[] aR = new byte[JpegProcessor.DctSizeSquare];
    private readonly float[] b = new float[JpegProcessor.DctSizeSquare];
    private readonly byte[] bR = new byte[JpegProcessor.DctSizeSquare];
    private readonly float[] c = new float[JpegProcessor.DctSizeSquare];
    private readonly byte[] cR = new byte[JpegProcessor.DctSizeSquare];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < JpegProcessor.DctSizeSquare; i++)
        {
            a[i] = random.NextSingle();
            b[i] = random.NextSingle();
            c[i] = random.NextSingle();
        }
    }

    [Benchmark]
    public void Quantize_loops()
    {
        QuantizeLoops.Quantize(
            aR.AsSpan(),
            bR.AsSpan(),
            cR.AsSpan(),
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan());
    }

    [Benchmark]
    public void Quantize_Unrolled()
    {
        QuantizeUnrolled.Quantize(
            aR.AsSpan(),
            bR.AsSpan(),
            cR.AsSpan(),
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan());
    }

    [Benchmark]
    public void Quantize_Unrolled_Plus()
    {
        QuantizeUnrolledPlus.Quantize(
            aR.AsSpan(),
            bR.AsSpan(),
            cR.AsSpan(),
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan());
    }

    [Benchmark]
    public void Quantize_Unrolled_Plus_Const()
    {
        QuantizeConst.Quantize(
            aR.AsSpan(),
            bR.AsSpan(),
            cR.AsSpan(),
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan());
    }

    [Benchmark]
    public void Quantize_Unrolled_Plus_Const_Opti()
    {
        QuantizeConstOptimized.Quantize(
            aR.AsSpan(),
            bR.AsSpan(),
            cR.AsSpan(),
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan());
    }

    [Benchmark]
    public void Quantize_Vectors()
    {
        QuantizeVectors.Quantize(
            aR.AsSpan(),
            bR.AsSpan(),
            cR.AsSpan(),
            a.AsSpan(),
            b.AsSpan(),
            c.AsSpan());
    }
}
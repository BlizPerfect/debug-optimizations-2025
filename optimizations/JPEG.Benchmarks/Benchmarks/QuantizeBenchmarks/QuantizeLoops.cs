using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.QuantizeBenchmarks;

public class QuantizeLoops
{
    private static readonly byte[] quantizationMatrix =
    {
        10, 7, 6, 10, 14, 24, 31, 37, 7, 7, 8, 11, 16, 35, 36, 33, 8, 8, 10, 14, 24, 34, 41, 34, 8, 10, 13, 17, 31, 52,
        48, 37, 11, 13, 22, 34, 41, 65, 62, 46, 14, 21, 33, 38, 49, 62, 68, 55, 29, 38, 47, 52, 62, 73, 72, 61, 43, 55,
        57, 59, 67, 60, 62, 59
    };
    
    public static void Quantize(
        Span<byte> resultY,
        Span<byte> resultCb,
        Span<byte> resultCr,
        Span<float> channelFreqsY,
        Span<float> channelFreqsCb,
        Span<float> channelFreqsCr)
    {
        var x = 0;
        var index = 0;
        byte quantizationValue = 0;
        for (var y = 0; y < JpegProcessor.DctSize; y++)
        {
            for (x = 0; x < JpegProcessor.DctSize; x++)
            {
                index = y * JpegProcessor.DctSize + x;
                quantizationValue = quantizationMatrix[index];
                resultY[index] = (byte)(channelFreqsY[index] / quantizationValue);
                resultCb[index] = (byte)(channelFreqsCb[index] / quantizationValue);
                resultCr[index] = (byte)(channelFreqsCr[index] / quantizationValue);
            }
        }
    }
}
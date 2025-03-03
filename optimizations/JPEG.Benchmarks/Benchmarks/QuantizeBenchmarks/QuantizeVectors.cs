using System.Numerics;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.QuantizeBenchmarks;

public class QuantizeVectors
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
        for (var i = 0; i < JpegProcessor.DctSizeSquare; i += JpegProcessor.DctSize)
        {
            var quantVector = new Vector<float>(quantizationMatrix[i]);

            var yVector = new Vector<float>(channelFreqsY.Slice(i));
            var cbVector = new Vector<float>(channelFreqsCb.Slice(i));
            var crVector = new Vector<float>(channelFreqsCr.Slice(i));

            var resultYVector = yVector / quantVector;
            var resultCbVector = cbVector / quantVector;
            var resultCrVector = crVector / quantVector;

            for (var j = 0; j < JpegProcessor.DctSize; j++)
            {
                resultY[i + j] = (byte)Math.Clamp((int)resultYVector[j], 0, 255);
                resultCb[i + j] = (byte)Math.Clamp((int)resultCbVector[j], 0, 255);
                resultCr[i + j] = (byte)Math.Clamp((int)resultCrVector[j], 0, 255);
            }
        }
    }
}
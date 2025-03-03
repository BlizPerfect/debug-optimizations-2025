using System.Numerics;
using JPEG.Images;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.GetSubMatrixBenchmarks;

public class VectorsGetSubMatrix
{
    public static void GetSubMatrix(
        Span<float> resultY,
        Span<float> resultCb,
        Span<float> resultCr,
        Matrix matrix,
        int yOffset,
        int xOffset)
    {
        var width = matrix.Width;
        var shift = new Vector<float>(JpegProcessor.DctSizeDoubleSquare);
        var pixels = matrix.Pixels;

        var tempY = new float[JpegProcessor.DctSize];
        var tempCb = new float[JpegProcessor.DctSize];
        var tempCr = new float[JpegProcessor.DctSize];

        byte k = 0;
        var rowOffset = 0;
        var baseIndex = 0;
        for (var j = 0; j < JpegProcessor.DctSize; j++)
        {
            rowOffset = (yOffset + j) * width + xOffset;
            baseIndex = j * 8;

            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            rowOffset += 1;
            tempY[k] = pixels[rowOffset].Value1;
            tempCb[k] = pixels[rowOffset].Value2;
            tempCr[k] = pixels[rowOffset].Value3;

            var vecY = new Vector<float>(tempY) - shift;
            var vecCb = new Vector<float>(tempCb) - shift;
            var vecCr = new Vector<float>(tempCr) - shift;

            vecY.CopyTo(resultY.Slice(baseIndex, JpegProcessor.DctSize));
            vecCb.CopyTo(resultCb.Slice(baseIndex, JpegProcessor.DctSize));
            vecCr.CopyTo(resultCr.Slice(baseIndex, JpegProcessor.DctSize));
        }
    }
}
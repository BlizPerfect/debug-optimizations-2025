using System.Numerics;
using JPEG.Images;
using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.SetPixelsBenchmarks;

public class VectorsUnrolledSetPixels
{
    private static Vector<float> Coef1 = new Vector<float>(298.082f);
    private static Vector<float> Coef2 = new Vector<float>(408.583f);
    private static Vector<float> Coef3 = new Vector<float>(256.0f);
    private static Vector<float> Coef4 = new Vector<float>(222.921f);
    private static Vector<float> Coef5 = new Vector<float>(100.291f);
    private static Vector<float> Coef6 = new Vector<float>(208.120f);
    private static Vector<float> Coef7 = new Vector<float>(135.576f);
    private static Vector<float> Coef8 = new Vector<float>(516.412f);
    private static Vector<float> Coef9 = new Vector<float>(276.836f);

    public static void SetPixels(
        Matrix matrix,
        Span<float> a,
        Span<float> b,
        Span<float> c,
        int yOffset,
        int xOffset)
    {
        var width = matrix.Width;
        var rowOffset = 0;
        var startIndex = 0;
        var pixelsIndex = 0;

        var vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        var vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        var vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        var result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        var result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        var result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 0) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 8;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 1) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 16;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 2) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 24;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 3) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 32;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 4) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 40;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 5) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 48;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 6) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];

        startIndex = 56;
        vecA = new Vector<float>(a.Slice(startIndex, JpegProcessor.DctSize));
        vecB = new Vector<float>(b.Slice(startIndex, JpegProcessor.DctSize));
        vecC = new Vector<float>(c.Slice(startIndex, JpegProcessor.DctSize));

        result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
        result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
        result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

        pixelsIndex = (yOffset + 7) * width + xOffset;
        matrix.Pixels[pixelsIndex].Value1 = result1[0];
        matrix.Pixels[pixelsIndex].Value2 = result2[0];
        matrix.Pixels[pixelsIndex].Value3 = result3[0];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[1];
        matrix.Pixels[pixelsIndex].Value2 = result2[1];
        matrix.Pixels[pixelsIndex].Value3 = result3[1];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[2];
        matrix.Pixels[pixelsIndex].Value2 = result2[2];
        matrix.Pixels[pixelsIndex].Value3 = result3[2];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[3];
        matrix.Pixels[pixelsIndex].Value2 = result2[3];
        matrix.Pixels[pixelsIndex].Value3 = result3[3];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[4];
        matrix.Pixels[pixelsIndex].Value2 = result2[4];
        matrix.Pixels[pixelsIndex].Value3 = result3[4];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[5];
        matrix.Pixels[pixelsIndex].Value2 = result2[5];
        matrix.Pixels[pixelsIndex].Value3 = result3[5];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[6];
        matrix.Pixels[pixelsIndex].Value2 = result2[6];
        matrix.Pixels[pixelsIndex].Value3 = result3[6];
        pixelsIndex += 1;
        matrix.Pixels[pixelsIndex].Value1 = result1[7];
        matrix.Pixels[pixelsIndex].Value2 = result2[7];
        matrix.Pixels[pixelsIndex].Value3 = result3[7];
    }
}
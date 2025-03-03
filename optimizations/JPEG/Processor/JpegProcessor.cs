using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JPEG.Images;

namespace JPEG.Processor;

public class JpegProcessor : IJpegProcessor
{
    public const byte DctSize = 8;
    public const byte ChannelCount = 3;
    public const byte DctSizeSquare = 64;
    public const byte CompressionQuality = 70;
    public const byte DctSizeDoubleSquare = 128;
    private const byte SpanSize = 192;

    private static readonly Vector<float> Coef1 = new Vector<float>(298.082f);
    private static readonly Vector<float> Coef2 = new Vector<float>(408.583f);
    private static readonly Vector<float> Coef3 = new Vector<float>(256.0f);
    private static readonly Vector<float> Coef4 = new Vector<float>(222.921f);
    private static readonly Vector<float> Coef5 = new Vector<float>(100.291f);
    private static readonly Vector<float> Coef6 = new Vector<float>(208.120f);
    private static readonly Vector<float> Coef7 = new Vector<float>(135.576f);
    private static readonly Vector<float> Coef8 = new Vector<float>(516.412f);
    private static readonly Vector<float> Coef9 = new Vector<float>(276.836f);

    private const byte QuantizationValue0 = 10;
    private const byte QuantizationValue1 = 7;
    private const byte QuantizationValue2 = 6;
    private const byte QuantizationValue4 = 14;
    private const byte QuantizationValue5 = 24;
    private const byte QuantizationValue6 = 31;
    private const byte QuantizationValue7 = 37;
    private const byte QuantizationValue10 = 8;
    private const byte QuantizationValue11 = 11;
    private const byte QuantizationValue12 = 16;
    private const byte QuantizationValue13 = 35;
    private const byte QuantizationValue14 = 36;
    private const byte QuantizationValue15 = 33;
    private const byte QuantizationValue21 = 34;
    private const byte QuantizationValue22 = 41;
    private const byte QuantizationValue26 = 13;
    private const byte QuantizationValue27 = 17;
    private const byte QuantizationValue29 = 52;
    private const byte QuantizationValue30 = 48;
    private const byte QuantizationValue34 = 22;
    private const byte QuantizationValue37 = 65;
    private const byte QuantizationValue38 = 62;
    private const byte QuantizationValue39 = 46;
    private const byte QuantizationValue41 = 21;
    private const byte QuantizationValue43 = 38;
    private const byte QuantizationValue44 = 49;
    private const byte QuantizationValue46 = 68;
    private const byte QuantizationValue47 = 55;
    private const byte QuantizationValue48 = 29;
    private const byte QuantizationValue50 = 47;
    private const byte QuantizationValue53 = 73;
    private const byte QuantizationValue54 = 72;
    private const byte QuantizationValue55 = 61;
    private const byte QuantizationValue56 = 43;
    private const byte QuantizationValue58 = 57;
    private const byte QuantizationValue59 = 59;
    private const byte QuantizationValue60 = 67;
    private const byte QuantizationValue61 = 60;

    public static readonly JpegProcessor Init = new();

    public void Compress(string imagePath, string compressedImagePath)
    {
        using var fileStream = File.OpenRead(imagePath);
        using var bmp = (Bitmap)Image.FromStream(fileStream, false, false);
        var imageMatrix = (Matrix)bmp;
        var compressionResult = Compress(imageMatrix);
        compressionResult.Save(compressedImagePath);
    }

    public void Uncompress(string compressedImagePath, string uncompressedImagePath)
    {
        var compressedImage = CompressedImage.Load(compressedImagePath);
        var uncompressedImage = Uncompress(compressedImage);
        var resultBmp = (Bitmap)uncompressedImage;
        resultBmp.Save(uncompressedImagePath, ImageFormat.Bmp);
    }

    private static CompressedImage Compress(Matrix matrix)
    {
        var blocksByXCount = matrix.Width / DctSize;
        var blocksByYCount = matrix.Height / DctSize;
        var blocksCount = blocksByYCount * blocksByXCount;
        var allQuantizedBytes = new byte[blocksCount * SpanSize];
        Parallel.For(0, blocksCount, currentBlockIndex =>
        {
            var x = currentBlockIndex % blocksByXCount;
            var y = currentBlockIndex / blocksByXCount;
            var offset = currentBlockIndex * SpanSize;

            Span<float> channelFreqs = stackalloc float[SpanSize];
            Span<byte> quantizedFreqs = stackalloc byte[SpanSize];
            Span<byte> quantizedBytes = stackalloc byte[SpanSize];
            Span<float> values = stackalloc float[SpanSize];

            GetSubMatrix(
                values.Slice(0, DctSizeSquare),
                values.Slice(DctSizeSquare, DctSizeSquare),
                values.Slice(DctSizeDoubleSquare, DctSizeSquare),
                matrix,
                y * DctSize,
                x * DctSize);

            DCT.DCT2D(
                values.Slice(0, DctSizeSquare),
                values.Slice(DctSizeSquare, DctSizeSquare),
                values.Slice(DctSizeDoubleSquare, DctSizeSquare),
                channelFreqs.Slice(0, DctSizeSquare),
                channelFreqs.Slice(DctSizeSquare, DctSizeSquare),
                channelFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare));

            Quantize(
                quantizedFreqs.Slice(0, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeSquare, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare),
                channelFreqs.Slice(0, DctSizeSquare),
                channelFreqs.Slice(DctSizeSquare, DctSizeSquare),
                channelFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare));

            ZigZagScan(
                quantizedFreqs.Slice(0, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeSquare, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare),
                quantizedBytes.Slice(0, DctSizeSquare),
                quantizedBytes.Slice(DctSizeSquare, DctSizeSquare),
                quantizedBytes.Slice(DctSizeDoubleSquare, DctSizeSquare));

            quantizedBytes.CopyTo(allQuantizedBytes.AsSpan(offset, SpanSize));
        });

        var compressedBytes = HuffmanCodec
            .Encode(
                allQuantizedBytes,
                out var decodeTable,
                out var bitsCount);
        return new CompressedImage
        {
            Quality = CompressionQuality,
            CompressedBytes = compressedBytes,
            BitsCount = bitsCount,
            DecodeTable = decodeTable,
            Height = matrix.Height,
            Width = matrix.Width
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Matrix Uncompress(CompressedImage image)
    {
        var blocksByXCount = image.Width / DctSize;
        var blocksByYCount = image.Height / DctSize;
        var result = new Matrix(image.Height, image.Width);
        Memory<byte> allQuantizedBytes = HuffmanCodec.Decode(image.CompressedBytes, image.DecodeTable, image.BitsCount);
        Parallel.For(0, blocksByYCount * blocksByXCount, blockIndex =>
        {
            var x = blockIndex % blocksByXCount;
            var y = blockIndex / blocksByXCount;
            var offset = blockIndex * SpanSize;

            Span<byte> allQuantizedBytesSpan = allQuantizedBytes.Span;
            Span<byte> quantizedFreqs = stackalloc byte[SpanSize];
            Span<float> channelFreqs = stackalloc float[SpanSize];
            Span<float> values = stackalloc float[SpanSize];

            ZigZagUnScan(
                allQuantizedBytesSpan.Slice(offset, DctSizeSquare),
                allQuantizedBytesSpan.Slice(offset + DctSizeSquare, DctSizeSquare),
                allQuantizedBytesSpan.Slice(offset + DctSizeDoubleSquare, DctSizeSquare),
                quantizedFreqs.Slice(0, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeSquare, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare));

            DeQuantize(channelFreqs.Slice(0, DctSizeSquare),
                channelFreqs.Slice(DctSizeSquare, DctSizeSquare),
                channelFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare),
                quantizedFreqs.Slice(0, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeSquare, DctSizeSquare),
                quantizedFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare));

            DCT.IDCT2D(channelFreqs.Slice(0, DctSizeSquare),
                channelFreqs.Slice(DctSizeSquare, DctSizeSquare),
                channelFreqs.Slice(DctSizeDoubleSquare, DctSizeSquare),
                values.Slice(0, DctSizeSquare),
                values.Slice(DctSizeSquare, DctSizeSquare),
                values.Slice(DctSizeDoubleSquare, DctSizeSquare));

            SetPixels(
                result,
                values.Slice(0, DctSizeSquare),
                values.Slice(DctSizeSquare, DctSizeSquare),
                values.Slice(DctSizeDoubleSquare, DctSizeSquare),
                y * DctSize,
                x * DctSize);
        });

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SetPixels(
        Matrix matrix,
        Span<float> a,
        Span<float> b,
        Span<float> c,
        int yOffset,
        int xOffset)
    {
        var startIndex = 0;
        var pixelsIndex = 0;
        for (byte y = 0; y < DctSize; y++)
        {
            startIndex = y * DctSize;

            var vecA = new Vector<float>(a.Slice(startIndex, DctSize));
            var vecB = new Vector<float>(b.Slice(startIndex, DctSize));
            var vecC = new Vector<float>(c.Slice(startIndex, DctSize));

            var result1 = (Coef1 * vecA + Coef2 * vecC) / Coef3 - Coef4;
            var result2 = (Coef1 * vecA - Coef5 * vecB - Coef6 * vecC) / Coef3 + Coef7;
            var result3 = (Coef1 * vecA + Coef8 * vecB) / Coef3 - Coef9;

            pixelsIndex = (yOffset + y) * matrix.Width + xOffset;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void GetSubMatrix(
        Span<float> resultY,
        Span<float> resultCb,
        Span<float> resultCr,
        Matrix matrix,
        int yOffset,
        int xOffset)
    {
        var width = matrix.Width;
        var pixelsIndex = yOffset * width + xOffset;
        resultY[0] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[0] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[0] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[1] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[1] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[1] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[2] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[2] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[2] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[3] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[3] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[3] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[4] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[4] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[4] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[5] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[5] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[5] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[6] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[6] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[6] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[7] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[7] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[7] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 1) * width + xOffset;
        resultY[8] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[8] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[8] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[9] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[9] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[9] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[10] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[10] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[10] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[11] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[11] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[11] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[12] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[12] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[12] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[13] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[13] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[13] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[14] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[14] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[14] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[15] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[15] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[15] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 2) * width + xOffset;
        resultY[16] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[16] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[16] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[17] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[17] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[17] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[18] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[18] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[18] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[19] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[19] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[19] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[20] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[20] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[20] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[21] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[21] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[21] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[22] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[22] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[22] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[23] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[23] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[23] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 3) * width + xOffset;
        resultY[24] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[24] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[24] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[25] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[25] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[25] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[26] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[26] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[26] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[27] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[27] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[27] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[28] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[28] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[28] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[29] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[29] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[29] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[30] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[30] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[30] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[31] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[31] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[31] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 4) * width + xOffset;
        resultY[32] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[32] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[32] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[33] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[33] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[33] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[34] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[34] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[34] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[35] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[35] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[35] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[36] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[36] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[36] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[37] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[37] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[37] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[38] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[38] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[38] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[39] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[39] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[39] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 5) * width + xOffset;
        resultY[40] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[40] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[40] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[41] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[41] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[41] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[42] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[42] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[42] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[43] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[43] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[43] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[44] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[44] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[44] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[45] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[45] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[45] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[46] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[46] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[46] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[47] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[47] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[47] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 6) * width + xOffset;
        resultY[48] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[48] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[48] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[49] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[49] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[49] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[50] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[50] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[50] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[51] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[51] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[51] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[52] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[52] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[52] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[53] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[53] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[53] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[54] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[54] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[54] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[55] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[55] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[55] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;

        pixelsIndex = (yOffset + 7) * width + xOffset;
        resultY[56] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[56] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[56] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[57] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[57] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[57] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[58] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[58] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[58] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[59] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[59] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[59] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[60] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[60] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[60] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[61] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[61] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[61] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[62] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[62] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[62] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
        pixelsIndex += 1;
        resultY[63] = matrix.Pixels[pixelsIndex].Value1 - DctSizeDoubleSquare;
        resultCb[63] = matrix.Pixels[pixelsIndex].Value2 - DctSizeDoubleSquare;
        resultCr[63] = matrix.Pixels[pixelsIndex].Value3 - DctSizeDoubleSquare;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ZigZagScan(
        Span<byte> channelFreqsY,
        Span<byte> channelFreqsCb,
        Span<byte> channelFreqsCr,
        Span<byte> resultY,
        Span<byte> resultCb,
        Span<byte> resultCr)
    {
        resultY[0] = channelFreqsY[0];
        resultY[1] = channelFreqsY[1];
        resultY[2] = channelFreqsY[8];
        resultY[3] = channelFreqsY[16];
        resultY[4] = channelFreqsY[9];
        resultY[5] = channelFreqsY[2];
        resultY[6] = channelFreqsY[3];
        resultY[7] = channelFreqsY[10];
        resultY[8] = channelFreqsY[17];
        resultY[9] = channelFreqsY[24];
        resultY[10] = channelFreqsY[32];
        resultY[11] = channelFreqsY[25];
        resultY[12] = channelFreqsY[18];
        resultY[13] = channelFreqsY[11];
        resultY[14] = channelFreqsY[4];
        resultY[15] = channelFreqsY[5];
        resultY[16] = channelFreqsY[12];
        resultY[17] = channelFreqsY[19];
        resultY[18] = channelFreqsY[26];
        resultY[19] = channelFreqsY[33];
        resultY[20] = channelFreqsY[40];
        resultY[21] = channelFreqsY[48];
        resultY[22] = channelFreqsY[41];
        resultY[23] = channelFreqsY[34];
        resultY[24] = channelFreqsY[27];
        resultY[25] = channelFreqsY[20];
        resultY[26] = channelFreqsY[13];
        resultY[27] = channelFreqsY[6];
        resultY[28] = channelFreqsY[7];
        resultY[29] = channelFreqsY[14];
        resultY[30] = channelFreqsY[21];
        resultY[31] = channelFreqsY[28];
        resultY[32] = channelFreqsY[35];
        resultY[33] = channelFreqsY[42];
        resultY[34] = channelFreqsY[49];
        resultY[35] = channelFreqsY[56];
        resultY[36] = channelFreqsY[57];
        resultY[37] = channelFreqsY[50];
        resultY[38] = channelFreqsY[43];
        resultY[39] = channelFreqsY[36];
        resultY[40] = channelFreqsY[29];
        resultY[41] = channelFreqsY[22];
        resultY[42] = channelFreqsY[15];
        resultY[43] = channelFreqsY[23];
        resultY[44] = channelFreqsY[30];
        resultY[45] = channelFreqsY[37];
        resultY[46] = channelFreqsY[44];
        resultY[47] = channelFreqsY[51];
        resultY[48] = channelFreqsY[58];
        resultY[49] = channelFreqsY[59];
        resultY[50] = channelFreqsY[52];
        resultY[51] = channelFreqsY[45];
        resultY[52] = channelFreqsY[38];
        resultY[53] = channelFreqsY[31];
        resultY[54] = channelFreqsY[39];
        resultY[55] = channelFreqsY[46];
        resultY[56] = channelFreqsY[53];
        resultY[57] = channelFreqsY[60];
        resultY[58] = channelFreqsY[61];
        resultY[59] = channelFreqsY[54];
        resultY[60] = channelFreqsY[47];
        resultY[61] = channelFreqsY[55];
        resultY[62] = channelFreqsY[62];
        resultY[63] = channelFreqsY[63];

        resultCb[0] = channelFreqsCb[0];
        resultCb[1] = channelFreqsCb[1];
        resultCb[2] = channelFreqsCb[8];
        resultCb[3] = channelFreqsCb[16];
        resultCb[4] = channelFreqsCb[9];
        resultCb[5] = channelFreqsCb[2];
        resultCb[6] = channelFreqsCb[3];
        resultCb[7] = channelFreqsCb[10];
        resultCb[8] = channelFreqsCb[17];
        resultCb[9] = channelFreqsCb[24];
        resultCb[10] = channelFreqsCb[32];
        resultCb[11] = channelFreqsCb[25];
        resultCb[12] = channelFreqsCb[18];
        resultCb[13] = channelFreqsCb[11];
        resultCb[14] = channelFreqsCb[4];
        resultCb[15] = channelFreqsCb[5];
        resultCb[16] = channelFreqsCb[12];
        resultCb[17] = channelFreqsCb[19];
        resultCb[18] = channelFreqsCb[26];
        resultCb[19] = channelFreqsCb[33];
        resultCb[20] = channelFreqsCb[40];
        resultCb[21] = channelFreqsCb[48];
        resultCb[22] = channelFreqsCb[41];
        resultCb[23] = channelFreqsCb[34];
        resultCb[24] = channelFreqsCb[27];
        resultCb[25] = channelFreqsCb[20];
        resultCb[26] = channelFreqsCb[13];
        resultCb[27] = channelFreqsCb[6];
        resultCb[28] = channelFreqsCb[7];
        resultCb[29] = channelFreqsCb[14];
        resultCb[30] = channelFreqsCb[21];
        resultCb[31] = channelFreqsCb[28];
        resultCb[32] = channelFreqsCb[35];
        resultCb[33] = channelFreqsCb[42];
        resultCb[34] = channelFreqsCb[49];
        resultCb[35] = channelFreqsCb[56];
        resultCb[36] = channelFreqsCb[57];
        resultCb[37] = channelFreqsCb[50];
        resultCb[38] = channelFreqsCb[43];
        resultCb[39] = channelFreqsCb[36];
        resultCb[40] = channelFreqsCb[29];
        resultCb[41] = channelFreqsCb[22];
        resultCb[42] = channelFreqsCb[15];
        resultCb[43] = channelFreqsCb[23];
        resultCb[44] = channelFreqsCb[30];
        resultCb[45] = channelFreqsCb[37];
        resultCb[46] = channelFreqsCb[44];
        resultCb[47] = channelFreqsCb[51];
        resultCb[48] = channelFreqsCb[58];
        resultCb[49] = channelFreqsCb[59];
        resultCb[50] = channelFreqsCb[52];
        resultCb[51] = channelFreqsCb[45];
        resultCb[52] = channelFreqsCb[38];
        resultCb[53] = channelFreqsCb[31];
        resultCb[54] = channelFreqsCb[39];
        resultCb[55] = channelFreqsCb[46];
        resultCb[56] = channelFreqsCb[53];
        resultCb[57] = channelFreqsCb[60];
        resultCb[58] = channelFreqsCb[61];
        resultCb[59] = channelFreqsCb[54];
        resultCb[60] = channelFreqsCb[47];
        resultCb[61] = channelFreqsCb[55];
        resultCb[62] = channelFreqsCb[62];
        resultCb[63] = channelFreqsCb[63];

        resultCr[0] = channelFreqsCr[0];
        resultCr[1] = channelFreqsCr[1];
        resultCr[2] = channelFreqsCr[8];
        resultCr[3] = channelFreqsCr[16];
        resultCr[4] = channelFreqsCr[9];
        resultCr[5] = channelFreqsCr[2];
        resultCr[6] = channelFreqsCr[3];
        resultCr[7] = channelFreqsCr[10];
        resultCr[8] = channelFreqsCr[17];
        resultCr[9] = channelFreqsCr[24];
        resultCr[10] = channelFreqsCr[32];
        resultCr[11] = channelFreqsCr[25];
        resultCr[12] = channelFreqsCr[18];
        resultCr[13] = channelFreqsCr[11];
        resultCr[14] = channelFreqsCr[4];
        resultCr[15] = channelFreqsCr[5];
        resultCr[16] = channelFreqsCr[12];
        resultCr[17] = channelFreqsCr[19];
        resultCr[18] = channelFreqsCr[26];
        resultCr[19] = channelFreqsCr[33];
        resultCr[20] = channelFreqsCr[40];
        resultCr[21] = channelFreqsCr[48];
        resultCr[22] = channelFreqsCr[41];
        resultCr[23] = channelFreqsCr[34];
        resultCr[24] = channelFreqsCr[27];
        resultCr[25] = channelFreqsCr[20];
        resultCr[26] = channelFreqsCr[13];
        resultCr[27] = channelFreqsCr[6];
        resultCr[28] = channelFreqsCr[7];
        resultCr[29] = channelFreqsCr[14];
        resultCr[30] = channelFreqsCr[21];
        resultCr[31] = channelFreqsCr[28];
        resultCr[32] = channelFreqsCr[35];
        resultCr[33] = channelFreqsCr[42];
        resultCr[34] = channelFreqsCr[49];
        resultCr[35] = channelFreqsCr[56];
        resultCr[36] = channelFreqsCr[57];
        resultCr[37] = channelFreqsCr[50];
        resultCr[38] = channelFreqsCr[43];
        resultCr[39] = channelFreqsCr[36];
        resultCr[40] = channelFreqsCr[29];
        resultCr[41] = channelFreqsCr[22];
        resultCr[42] = channelFreqsCr[15];
        resultCr[43] = channelFreqsCr[23];
        resultCr[44] = channelFreqsCr[30];
        resultCr[45] = channelFreqsCr[37];
        resultCr[46] = channelFreqsCr[44];
        resultCr[47] = channelFreqsCr[51];
        resultCr[48] = channelFreqsCr[58];
        resultCr[49] = channelFreqsCr[59];
        resultCr[50] = channelFreqsCr[52];
        resultCr[51] = channelFreqsCr[45];
        resultCr[52] = channelFreqsCr[38];
        resultCr[53] = channelFreqsCr[31];
        resultCr[54] = channelFreqsCr[39];
        resultCr[55] = channelFreqsCr[46];
        resultCr[56] = channelFreqsCr[53];
        resultCr[57] = channelFreqsCr[60];
        resultCr[58] = channelFreqsCr[61];
        resultCr[59] = channelFreqsCr[54];
        resultCr[60] = channelFreqsCr[47];
        resultCr[61] = channelFreqsCr[55];
        resultCr[62] = channelFreqsCr[62];
        resultCr[63] = channelFreqsCr[63];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ZigZagUnScan(
        Span<byte> quantizedBytesY,
        Span<byte> quantizedBytesCb,
        Span<byte> quantizedBytesCr,
        Span<byte> resultY,
        Span<byte> resultCb,
        Span<byte> resultCr)
    {
        resultY[0] = quantizedBytesY[0];
        resultY[1] = quantizedBytesY[1];
        resultY[2] = quantizedBytesY[5];
        resultY[3] = quantizedBytesY[6];
        resultY[4] = quantizedBytesY[14];
        resultY[5] = quantizedBytesY[15];
        resultY[6] = quantizedBytesY[27];
        resultY[7] = quantizedBytesY[28];
        resultY[8] = quantizedBytesY[2];
        resultY[9] = quantizedBytesY[4];
        resultY[10] = quantizedBytesY[7];
        resultY[11] = quantizedBytesY[13];
        resultY[12] = quantizedBytesY[16];
        resultY[13] = quantizedBytesY[26];
        resultY[14] = quantizedBytesY[29];
        resultY[15] = quantizedBytesY[42];
        resultY[16] = quantizedBytesY[3];
        resultY[17] = quantizedBytesY[8];
        resultY[18] = quantizedBytesY[12];
        resultY[19] = quantizedBytesY[17];
        resultY[20] = quantizedBytesY[25];
        resultY[21] = quantizedBytesY[30];
        resultY[22] = quantizedBytesY[41];
        resultY[23] = quantizedBytesY[43];
        resultY[24] = quantizedBytesY[9];
        resultY[25] = quantizedBytesY[11];
        resultY[26] = quantizedBytesY[18];
        resultY[27] = quantizedBytesY[24];
        resultY[28] = quantizedBytesY[31];
        resultY[29] = quantizedBytesY[40];
        resultY[30] = quantizedBytesY[44];
        resultY[31] = quantizedBytesY[53];
        resultY[32] = quantizedBytesY[10];
        resultY[33] = quantizedBytesY[19];
        resultY[34] = quantizedBytesY[23];
        resultY[35] = quantizedBytesY[32];
        resultY[36] = quantizedBytesY[39];
        resultY[37] = quantizedBytesY[45];
        resultY[38] = quantizedBytesY[52];
        resultY[39] = quantizedBytesY[54];
        resultY[40] = quantizedBytesY[20];
        resultY[41] = quantizedBytesY[22];
        resultY[42] = quantizedBytesY[33];
        resultY[43] = quantizedBytesY[38];
        resultY[44] = quantizedBytesY[46];
        resultY[45] = quantizedBytesY[51];
        resultY[46] = quantizedBytesY[55];
        resultY[47] = quantizedBytesY[60];
        resultY[48] = quantizedBytesY[21];
        resultY[49] = quantizedBytesY[34];
        resultY[50] = quantizedBytesY[37];
        resultY[51] = quantizedBytesY[47];
        resultY[52] = quantizedBytesY[50];
        resultY[53] = quantizedBytesY[56];
        resultY[54] = quantizedBytesY[59];
        resultY[55] = quantizedBytesY[61];
        resultY[56] = quantizedBytesY[35];
        resultY[57] = quantizedBytesY[36];
        resultY[58] = quantizedBytesY[48];
        resultY[59] = quantizedBytesY[49];
        resultY[60] = quantizedBytesY[57];
        resultY[61] = quantizedBytesY[58];
        resultY[62] = quantizedBytesY[62];
        resultY[63] = quantizedBytesY[63];

        resultCb[0] = quantizedBytesCb[0];
        resultCb[1] = quantizedBytesCb[1];
        resultCb[2] = quantizedBytesCb[5];
        resultCb[3] = quantizedBytesCb[6];
        resultCb[4] = quantizedBytesCb[14];
        resultCb[5] = quantizedBytesCb[15];
        resultCb[6] = quantizedBytesCb[27];
        resultCb[7] = quantizedBytesCb[28];
        resultCb[8] = quantizedBytesCb[2];
        resultCb[9] = quantizedBytesCb[4];
        resultCb[10] = quantizedBytesCb[7];
        resultCb[11] = quantizedBytesCb[13];
        resultCb[12] = quantizedBytesCb[16];
        resultCb[13] = quantizedBytesCb[26];
        resultCb[14] = quantizedBytesCb[29];
        resultCb[15] = quantizedBytesCb[42];
        resultCb[16] = quantizedBytesCb[3];
        resultCb[17] = quantizedBytesCb[8];
        resultCb[18] = quantizedBytesCb[12];
        resultCb[19] = quantizedBytesCb[17];
        resultCb[20] = quantizedBytesCb[25];
        resultCb[21] = quantizedBytesCb[30];
        resultCb[22] = quantizedBytesCb[41];
        resultCb[23] = quantizedBytesCb[43];
        resultCb[24] = quantizedBytesCb[9];
        resultCb[25] = quantizedBytesCb[11];
        resultCb[26] = quantizedBytesCb[18];
        resultCb[27] = quantizedBytesCb[24];
        resultCb[28] = quantizedBytesCb[31];
        resultCb[29] = quantizedBytesCb[40];
        resultCb[30] = quantizedBytesCb[44];
        resultCb[31] = quantizedBytesCb[53];
        resultCb[32] = quantizedBytesCb[10];
        resultCb[33] = quantizedBytesCb[19];
        resultCb[34] = quantizedBytesCb[23];
        resultCb[35] = quantizedBytesCb[32];
        resultCb[36] = quantizedBytesCb[39];
        resultCb[37] = quantizedBytesCb[45];
        resultCb[38] = quantizedBytesCb[52];
        resultCb[39] = quantizedBytesCb[54];
        resultCb[40] = quantizedBytesCb[20];
        resultCb[41] = quantizedBytesCb[22];
        resultCb[42] = quantizedBytesCb[33];
        resultCb[43] = quantizedBytesCb[38];
        resultCb[44] = quantizedBytesCb[46];
        resultCb[45] = quantizedBytesCb[51];
        resultCb[46] = quantizedBytesCb[55];
        resultCb[47] = quantizedBytesCb[60];
        resultCb[48] = quantizedBytesCb[21];
        resultCb[49] = quantizedBytesCb[34];
        resultCb[50] = quantizedBytesCb[37];
        resultCb[51] = quantizedBytesCb[47];
        resultCb[52] = quantizedBytesCb[50];
        resultCb[53] = quantizedBytesCb[56];
        resultCb[54] = quantizedBytesCb[59];
        resultCb[55] = quantizedBytesCb[61];
        resultCb[56] = quantizedBytesCb[35];
        resultCb[57] = quantizedBytesCb[36];
        resultCb[58] = quantizedBytesCb[48];
        resultCb[59] = quantizedBytesCb[49];
        resultCb[60] = quantizedBytesCb[57];
        resultCb[61] = quantizedBytesCb[58];
        resultCb[62] = quantizedBytesCb[62];
        resultCb[63] = quantizedBytesCb[63];

        resultCr[0] = quantizedBytesCr[0];
        resultCr[1] = quantizedBytesCr[1];
        resultCr[2] = quantizedBytesCr[5];
        resultCr[3] = quantizedBytesCr[6];
        resultCr[4] = quantizedBytesCr[14];
        resultCr[5] = quantizedBytesCr[15];
        resultCr[6] = quantizedBytesCr[27];
        resultCr[7] = quantizedBytesCr[28];
        resultCr[8] = quantizedBytesCr[2];
        resultCr[9] = quantizedBytesCr[4];
        resultCr[10] = quantizedBytesCr[7];
        resultCr[11] = quantizedBytesCr[13];
        resultCr[12] = quantizedBytesCr[16];
        resultCr[13] = quantizedBytesCr[26];
        resultCr[14] = quantizedBytesCr[29];
        resultCr[15] = quantizedBytesCr[42];
        resultCr[16] = quantizedBytesCr[3];
        resultCr[17] = quantizedBytesCr[8];
        resultCr[18] = quantizedBytesCr[12];
        resultCr[19] = quantizedBytesCr[17];
        resultCr[20] = quantizedBytesCr[25];
        resultCr[21] = quantizedBytesCr[30];
        resultCr[22] = quantizedBytesCr[41];
        resultCr[23] = quantizedBytesCr[43];
        resultCr[24] = quantizedBytesCr[9];
        resultCr[25] = quantizedBytesCr[11];
        resultCr[26] = quantizedBytesCr[18];
        resultCr[27] = quantizedBytesCr[24];
        resultCr[28] = quantizedBytesCr[31];
        resultCr[29] = quantizedBytesCr[40];
        resultCr[30] = quantizedBytesCr[44];
        resultCr[31] = quantizedBytesCr[53];
        resultCr[32] = quantizedBytesCr[10];
        resultCr[33] = quantizedBytesCr[19];
        resultCr[34] = quantizedBytesCr[23];
        resultCr[35] = quantizedBytesCr[32];
        resultCr[36] = quantizedBytesCr[39];
        resultCr[37] = quantizedBytesCr[45];
        resultCr[38] = quantizedBytesCr[52];
        resultCr[39] = quantizedBytesCr[54];
        resultCr[40] = quantizedBytesCr[20];
        resultCr[41] = quantizedBytesCr[22];
        resultCr[42] = quantizedBytesCr[33];
        resultCr[43] = quantizedBytesCr[38];
        resultCr[44] = quantizedBytesCr[46];
        resultCr[45] = quantizedBytesCr[51];
        resultCr[46] = quantizedBytesCr[55];
        resultCr[47] = quantizedBytesCr[60];
        resultCr[48] = quantizedBytesCr[21];
        resultCr[49] = quantizedBytesCr[34];
        resultCr[50] = quantizedBytesCr[37];
        resultCr[51] = quantizedBytesCr[47];
        resultCr[52] = quantizedBytesCr[50];
        resultCr[53] = quantizedBytesCr[56];
        resultCr[54] = quantizedBytesCr[59];
        resultCr[55] = quantizedBytesCr[61];
        resultCr[56] = quantizedBytesCr[35];
        resultCr[57] = quantizedBytesCr[36];
        resultCr[58] = quantizedBytesCr[48];
        resultCr[59] = quantizedBytesCr[49];
        resultCr[60] = quantizedBytesCr[57];
        resultCr[61] = quantizedBytesCr[58];
        resultCr[62] = quantizedBytesCr[62];
        resultCr[63] = quantizedBytesCr[63];
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Quantize(
        Span<byte> resultY,
        Span<byte> resultCb,
        Span<byte> resultCr,
        Span<float> channelFreqsY,
        Span<float> channelFreqsCb,
        Span<float> channelFreqsCr)
    {
        var index = 0;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue0);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue0);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue0);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue1);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue1);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue1);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue2);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue2);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue2);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue0);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue0);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue0);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue4);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue4);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue4);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue5);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue5);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue5);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue6);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue6);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue6);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue7);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue7);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue7);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue1);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue1);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue1);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue1);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue1);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue1);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue10);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue10);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue10);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue11);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue11);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue11);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue12);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue12);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue12);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue13);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue13);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue13);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue14);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue14);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue14);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue15);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue15);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue15);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue10);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue10);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue10);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue10);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue10);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue10);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue0);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue0);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue0);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue4);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue4);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue4);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue5);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue5);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue5);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue21);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue21);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue21);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue22);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue22);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue22);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue21);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue21);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue21);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue10);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue10);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue10);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue0);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue0);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue0);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue26);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue26);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue26);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue27);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue27);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue27);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue6);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue6);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue6);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue29);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue29);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue29);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue30);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue30);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue30);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue7);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue7);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue7);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue11);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue11);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue11);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue26);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue26);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue26);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue34);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue34);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue34);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue21);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue21);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue21);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue22);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue22);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue22);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue37);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue37);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue37);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue38);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue38);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue38);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue39);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue39);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue39);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue4);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue4);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue4);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue41);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue41);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue41);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue15);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue15);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue15);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue43);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue43);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue43);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue44);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue44);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue44);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue38);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue38);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue38);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue46);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue46);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue46);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue47);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue47);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue47);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue48);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue48);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue48);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue43);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue43);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue43);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue50);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue50);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue50);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue29);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue29);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue29);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue38);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue38);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue38);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue53);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue53);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue53);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue54);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue54);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue54);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue55);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue55);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue55);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue56);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue56);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue56);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue47);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue47);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue47);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue58);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue58);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue58);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue59);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue59);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue59);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue60);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue60);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue60);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue61);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue61);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue61);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue38);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue38);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue38);
        index += 1;
        resultY[index] = (byte)(channelFreqsY[index] / QuantizationValue59);
        resultCb[index] = (byte)(channelFreqsCb[index] / QuantizationValue59);
        resultCr[index] = (byte)(channelFreqsCr[index] / QuantizationValue59);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DeQuantize(
        Span<float> resultY,
        Span<float> resultCb,
        Span<float> resultCr,
        Span<byte> quantizedBytesY,
        Span<byte> quantizedBytesCb,
        Span<byte> quantizedBytesCr)
    {
        var index = 0;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue0;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue0;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue0;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue1;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue1;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue1;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue2;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue2;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue2;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue0;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue0;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue0;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue4;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue4;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue4;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue5;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue5;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue5;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue6;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue6;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue6;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue7;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue7;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue7;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue1;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue1;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue1;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue1;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue1;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue1;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue10;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue10;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue10;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue11;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue11;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue11;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue12;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue12;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue12;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue13;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue13;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue13;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue14;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue14;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue14;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue15;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue15;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue15;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue10;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue10;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue10;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue10;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue10;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue10;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue0;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue0;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue0;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue4;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue4;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue4;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue5;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue5;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue5;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue21;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue21;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue21;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue22;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue22;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue22;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue21;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue21;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue21;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue10;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue10;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue10;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue0;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue0;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue0;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue26;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue26;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue26;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue27;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue27;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue27;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue6;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue6;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue6;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue29;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue29;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue29;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue30;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue30;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue30;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue7;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue7;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue7;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue11;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue11;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue11;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue26;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue26;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue26;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue34;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue34;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue34;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue21;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue21;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue21;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue22;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue22;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue22;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue37;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue37;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue37;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue38;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue38;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue38;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue39;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue39;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue39;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue4;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue4;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue4;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue41;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue41;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue41;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue15;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue15;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue15;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue43;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue43;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue43;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue44;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue44;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue44;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue38;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue38;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue38;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue46;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue46;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue46;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue47;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue47;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue47;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue48;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue48;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue48;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue43;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue43;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue43;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue50;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue50;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue50;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue29;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue29;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue29;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue38;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue38;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue38;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue53;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue53;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue53;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue54;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue54;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue54;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue55;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue55;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue55;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue56;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue56;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue56;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue47;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue47;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue47;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue58;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue58;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue58;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue59;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue59;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue59;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue60;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue60;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue60;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue61;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue61;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue61;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue38;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue38;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue38;
        index += 1;
        resultY[index] = (sbyte)quantizedBytesY[index] * QuantizationValue59;
        resultCb[index] = (sbyte)quantizedBytesCb[index] * QuantizationValue59;
        resultCr[index] = (sbyte)quantizedBytesCr[index] * QuantizationValue59;
    }
}
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using JPEG.Processor;

namespace JPEG.Images;

public class Matrix(int height, int width)
{
    public readonly Pixel[] Pixels = new Pixel[height * width];
    public readonly int Height = height;
    public readonly int Width = width;

    private const float Coef1 = 16.0f;
    private const float Coef2 = 65.738f;
    private const float Coef3 = 129.057f;
    private const float Coef4 = 24.064f;
    private const float Coef5 = 256.0f;
    private const float Coef6 = 128.0f;
    private const float Coef7 = -37.945f;
    private const float Coef8 = 74.494f;
    private const float Coef9 = 112.439f;
    private const float Coef10 = 94.154f;
    private const float Coef11 = 18.285f;

    public static unsafe explicit operator Matrix(Bitmap bmp)
    {
        var height = bmp.Height - bmp.Height % JpegProcessor.DctSize;
        var width = bmp.Width - bmp.Width % JpegProcessor.DctSize;
        var result = new Matrix(height, width);

        var lockedBitmapData = bmp
            .LockBits(
                new Rectangle(
                    0,
                    0,
                    width,
                    height),
                ImageLockMode.ReadOnly,
                bmp.PixelFormat);

        byte* scan0 = (byte*)lockedBitmapData.Scan0;
        var i = 0;
        var index = 0;
        byte red;
        byte green;
        byte blue;
        for (var j = 0; j < height; j++)
        {
            byte* row = scan0 + j * lockedBitmapData.Stride;
            for (i = 0; i < width; i++)
            {
                index = i * JpegProcessor.ChannelCount;
                red = row[index + 2];
                green = row[index + 1];
                blue = row[index];
                result.Pixels[j * width + i] = new Pixel(
                    Coef1 + (Coef2 * red + Coef3 * green + Coef4 * blue) / Coef5,
                    Coef6 + (Coef7 * red - Coef8 * green + Coef9 * blue) / Coef5,
                    Coef6 + (Coef9 * red - Coef10 * green - Coef11 * blue) / Coef5);
            }
        }

        bmp.UnlockBits(lockedBitmapData);
        return result;
    }

    public static unsafe explicit operator Bitmap(Matrix matrix)
    {
        var height = matrix.Height;
        var width = matrix.Width;
        var pixelFormat = PixelFormat.Format24bppRgb;
        var result = new Bitmap(width, height, pixelFormat);
        var lockedBitmapData = result
            .LockBits(
                new Rectangle(
                    0,
                    0,
                    width,
                    height),
                ImageLockMode.WriteOnly,
                pixelFormat);
        var scan0 = (byte*)lockedBitmapData.Scan0;
        var j = 0;
        fixed (Pixel* ptr = matrix.Pixels)
        {
            var pixel = ptr;
            for (var i = 0; i < height; i++, scan0 += lockedBitmapData.Stride)
            {
                var row = scan0;
                for (j = 0; j < width; j++, pixel += 1)
                {
                    *row = ToByte(pixel->Value3);
                    row += 1;
                    *row = ToByte(pixel->Value2);
                    row += 1;
                    *row = ToByte(pixel->Value1);
                    row += 1;
                }
            }
        }

        result.UnlockBits(lockedBitmapData);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte ToByte(float d)
    {
        if (d > byte.MaxValue)
        {
            return byte.MaxValue;
        }

        if (d < byte.MinValue)
        {
            return byte.MinValue;
        }

        return (byte)d;
    }
}
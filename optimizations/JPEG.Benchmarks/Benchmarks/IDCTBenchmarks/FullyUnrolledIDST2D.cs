using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.IDCTBenchmarks;

public class FullyUnrolledIDST2D
{
    private const double Alpha = 0.70710678118654752440084436210485;
    private const double Beta = 0.25;

    private static readonly double[,] cosCacheX;
    private static readonly double[,] cosCacheY;


    static FullyUnrolledIDST2D()
    {
        var multiplicationPart = Math.PI / (2 * JpegProcessor.DctSize);

        cosCacheX = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];
        cosCacheY = new double[JpegProcessor.DctSize, JpegProcessor.DctSize];

        var u = 0;
        var x = 0;

        var v = 0;
        var y = 0;

        for (u = 0; u < JpegProcessor.DctSize; u++)
        {
            for (x = 0; x < JpegProcessor.DctSize; x++)
            {
                cosCacheX[u, x] = Math.Cos((2 * x + 1) * u * multiplicationPart);
            }
        }

        for (v = 0; v < JpegProcessor.DctSize; v++)
        {
            for (y = 0; y < JpegProcessor.DctSize; y++)
            {
                cosCacheY[v, y] = Math.Cos((2 * y + 1) * v * multiplicationPart);
            }
        }
    }

    public static void IDCT2D(double[,] coeffs, double[,] output)
    {
        var coeffs0 = coeffs[0, 0];
        var cosCacheX0 = cosCacheX[0, 0];
        var cosCacheY0 = cosCacheY[0, 0];
        var coeffs1 = coeffs[0, 1];
        var cosCacheX1 = cosCacheX[0, 1];
        var cosCacheY1 = cosCacheY[0, 1];
        var coeffs2 = coeffs[0, 2];
        var cosCacheX2 = cosCacheX[0, 2];
        var cosCacheY2 = cosCacheY[0, 2];
        var coeffs3 = coeffs[0, 3];
        var cosCacheX3 = cosCacheX[0, 3];
        var cosCacheY3 = cosCacheY[0, 3];
        var coeffs4 = coeffs[0, 4];
        var cosCacheX4 = cosCacheX[0, 4];
        var cosCacheY4 = cosCacheY[0, 4];
        var coeffs5 = coeffs[0, 5];
        var cosCacheX5 = cosCacheX[0, 5];
        var cosCacheY5 = cosCacheY[0, 5];
        var coeffs6 = coeffs[0, 6];
        var cosCacheX6 = cosCacheX[0, 6];
        var cosCacheY6 = cosCacheY[0, 6];
        var coeffs7 = coeffs[0, 7];
        var cosCacheX7 = cosCacheX[0, 7];
        var cosCacheY7 = cosCacheY[0, 7];
        var coeffs8 = coeffs[1, 0];
        var cosCacheX8 = cosCacheX[1, 0];
        var cosCacheY8 = cosCacheY[1, 0];
        var coeffs9 = coeffs[1, 1];
        var cosCacheX9 = cosCacheX[1, 1];
        var cosCacheY9 = cosCacheY[1, 1];
        var coeffs10 = coeffs[1, 2];
        var cosCacheX10 = cosCacheX[1, 2];
        var cosCacheY10 = cosCacheY[1, 2];
        var coeffs11 = coeffs[1, 3];
        var cosCacheX11 = cosCacheX[1, 3];
        var cosCacheY11 = cosCacheY[1, 3];
        var coeffs12 = coeffs[1, 4];
        var cosCacheX12 = cosCacheX[1, 4];
        var cosCacheY12 = cosCacheY[1, 4];
        var coeffs13 = coeffs[1, 5];
        var cosCacheX13 = cosCacheX[1, 5];
        var cosCacheY13 = cosCacheY[1, 5];
        var coeffs14 = coeffs[1, 6];
        var cosCacheX14 = cosCacheX[1, 6];
        var cosCacheY14 = cosCacheY[1, 6];
        var coeffs15 = coeffs[1, 7];
        var cosCacheX15 = cosCacheX[1, 7];
        var cosCacheY15 = cosCacheY[1, 7];
        var coeffs16 = coeffs[2, 0];
        var cosCacheX16 = cosCacheX[2, 0];
        var cosCacheY16 = cosCacheY[2, 0];
        var coeffs17 = coeffs[2, 1];
        var cosCacheX17 = cosCacheX[2, 1];
        var cosCacheY17 = cosCacheY[2, 1];
        var coeffs18 = coeffs[2, 2];
        var cosCacheX18 = cosCacheX[2, 2];
        var cosCacheY18 = cosCacheY[2, 2];
        var coeffs19 = coeffs[2, 3];
        var cosCacheX19 = cosCacheX[2, 3];
        var cosCacheY19 = cosCacheY[2, 3];
        var coeffs20 = coeffs[2, 4];
        var cosCacheX20 = cosCacheX[2, 4];
        var cosCacheY20 = cosCacheY[2, 4];
        var coeffs21 = coeffs[2, 5];
        var cosCacheX21 = cosCacheX[2, 5];
        var cosCacheY21 = cosCacheY[2, 5];
        var coeffs22 = coeffs[2, 6];
        var cosCacheX22 = cosCacheX[2, 6];
        var cosCacheY22 = cosCacheY[2, 6];
        var coeffs23 = coeffs[2, 7];
        var cosCacheX23 = cosCacheX[2, 7];
        var cosCacheY23 = cosCacheY[2, 7];
        var coeffs24 = coeffs[3, 0];
        var cosCacheX24 = cosCacheX[3, 0];
        var cosCacheY24 = cosCacheY[3, 0];
        var coeffs25 = coeffs[3, 1];
        var cosCacheX25 = cosCacheX[3, 1];
        var cosCacheY25 = cosCacheY[3, 1];
        var coeffs26 = coeffs[3, 2];
        var cosCacheX26 = cosCacheX[3, 2];
        var cosCacheY26 = cosCacheY[3, 2];
        var coeffs27 = coeffs[3, 3];
        var cosCacheX27 = cosCacheX[3, 3];
        var cosCacheY27 = cosCacheY[3, 3];
        var coeffs28 = coeffs[3, 4];
        var cosCacheX28 = cosCacheX[3, 4];
        var cosCacheY28 = cosCacheY[3, 4];
        var coeffs29 = coeffs[3, 5];
        var cosCacheX29 = cosCacheX[3, 5];
        var cosCacheY29 = cosCacheY[3, 5];
        var coeffs30 = coeffs[3, 6];
        var cosCacheX30 = cosCacheX[3, 6];
        var cosCacheY30 = cosCacheY[3, 6];
        var coeffs31 = coeffs[3, 7];
        var cosCacheX31 = cosCacheX[3, 7];
        var cosCacheY31 = cosCacheY[3, 7];
        var coeffs32 = coeffs[4, 0];
        var cosCacheX32 = cosCacheX[4, 0];
        var cosCacheY32 = cosCacheY[4, 0];
        var coeffs33 = coeffs[4, 1];
        var cosCacheX33 = cosCacheX[4, 1];
        var cosCacheY33 = cosCacheY[4, 1];
        var coeffs34 = coeffs[4, 2];
        var cosCacheX34 = cosCacheX[4, 2];
        var cosCacheY34 = cosCacheY[4, 2];
        var coeffs35 = coeffs[4, 3];
        var cosCacheX35 = cosCacheX[4, 3];
        var cosCacheY35 = cosCacheY[4, 3];
        var coeffs36 = coeffs[4, 4];
        var cosCacheX36 = cosCacheX[4, 4];
        var cosCacheY36 = cosCacheY[4, 4];
        var coeffs37 = coeffs[4, 5];
        var cosCacheX37 = cosCacheX[4, 5];
        var cosCacheY37 = cosCacheY[4, 5];
        var coeffs38 = coeffs[4, 6];
        var cosCacheX38 = cosCacheX[4, 6];
        var cosCacheY38 = cosCacheY[4, 6];
        var coeffs39 = coeffs[4, 7];
        var cosCacheX39 = cosCacheX[4, 7];
        var cosCacheY39 = cosCacheY[4, 7];
        var coeffs40 = coeffs[5, 0];
        var cosCacheX40 = cosCacheX[5, 0];
        var cosCacheY40 = cosCacheY[5, 0];
        var coeffs41 = coeffs[5, 1];
        var cosCacheX41 = cosCacheX[5, 1];
        var cosCacheY41 = cosCacheY[5, 1];
        var coeffs42 = coeffs[5, 2];
        var cosCacheX42 = cosCacheX[5, 2];
        var cosCacheY42 = cosCacheY[5, 2];
        var coeffs43 = coeffs[5, 3];
        var cosCacheX43 = cosCacheX[5, 3];
        var cosCacheY43 = cosCacheY[5, 3];
        var coeffs44 = coeffs[5, 4];
        var cosCacheX44 = cosCacheX[5, 4];
        var cosCacheY44 = cosCacheY[5, 4];
        var coeffs45 = coeffs[5, 5];
        var cosCacheX45 = cosCacheX[5, 5];
        var cosCacheY45 = cosCacheY[5, 5];
        var coeffs46 = coeffs[5, 6];
        var cosCacheX46 = cosCacheX[5, 6];
        var cosCacheY46 = cosCacheY[5, 6];
        var coeffs47 = coeffs[5, 7];
        var cosCacheX47 = cosCacheX[5, 7];
        var cosCacheY47 = cosCacheY[5, 7];
        var coeffs48 = coeffs[6, 0];
        var cosCacheX48 = cosCacheX[6, 0];
        var cosCacheY48 = cosCacheY[6, 0];
        var coeffs49 = coeffs[6, 1];
        var cosCacheX49 = cosCacheX[6, 1];
        var cosCacheY49 = cosCacheY[6, 1];
        var coeffs50 = coeffs[6, 2];
        var cosCacheX50 = cosCacheX[6, 2];
        var cosCacheY50 = cosCacheY[6, 2];
        var coeffs51 = coeffs[6, 3];
        var cosCacheX51 = cosCacheX[6, 3];
        var cosCacheY51 = cosCacheY[6, 3];
        var coeffs52 = coeffs[6, 4];
        var cosCacheX52 = cosCacheX[6, 4];
        var cosCacheY52 = cosCacheY[6, 4];
        var coeffs53 = coeffs[6, 5];
        var cosCacheX53 = cosCacheX[6, 5];
        var cosCacheY53 = cosCacheY[6, 5];
        var coeffs54 = coeffs[6, 6];
        var cosCacheX54 = cosCacheX[6, 6];
        var cosCacheY54 = cosCacheY[6, 6];
        var coeffs55 = coeffs[6, 7];
        var cosCacheX55 = cosCacheX[6, 7];
        var cosCacheY55 = cosCacheY[6, 7];
        var coeffs56 = coeffs[7, 0];
        var cosCacheX56 = cosCacheX[7, 0];
        var cosCacheY56 = cosCacheY[7, 0];
        var coeffs57 = coeffs[7, 1];
        var cosCacheX57 = cosCacheX[7, 1];
        var cosCacheY57 = cosCacheY[7, 1];
        var coeffs58 = coeffs[7, 2];
        var cosCacheX58 = cosCacheX[7, 2];
        var cosCacheY58 = cosCacheY[7, 2];
        var coeffs59 = coeffs[7, 3];
        var cosCacheX59 = cosCacheX[7, 3];
        var cosCacheY59 = cosCacheY[7, 3];
        var coeffs60 = coeffs[7, 4];
        var cosCacheX60 = cosCacheX[7, 4];
        var cosCacheY60 = cosCacheY[7, 4];
        var coeffs61 = coeffs[7, 5];
        var cosCacheX61 = cosCacheX[7, 5];
        var cosCacheY61 = cosCacheY[7, 5];
        var coeffs62 = coeffs[7, 6];
        var cosCacheX62 = cosCacheX[7, 6];
        var cosCacheY62 = cosCacheY[7, 6];
        var coeffs63 = coeffs[7, 7];
        var cosCacheX63 = cosCacheX[7, 7];
        var cosCacheY63 = cosCacheY[7, 7];
        output[0, 0] = (coeffs0 * cosCacheX0 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY8 +
                        coeffs10 * cosCacheX8 * cosCacheY16 +
                        coeffs11 * cosCacheX8 * cosCacheY24 +
                        coeffs12 * cosCacheX8 * cosCacheY32 +
                        coeffs13 * cosCacheX8 * cosCacheY40 +
                        coeffs14 * cosCacheX8 * cosCacheY48 +
                        coeffs15 * cosCacheX8 * cosCacheY56 +
                        coeffs16 * cosCacheX16 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY8 +
                        coeffs18 * cosCacheX16 * cosCacheY16 +
                        coeffs19 * cosCacheX16 * cosCacheY24 +
                        coeffs20 * cosCacheX16 * cosCacheY32 +
                        coeffs21 * cosCacheX16 * cosCacheY40 +
                        coeffs22 * cosCacheX16 * cosCacheY48 +
                        coeffs23 * cosCacheX16 * cosCacheY56 +
                        coeffs24 * cosCacheX24 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY8 +
                        coeffs26 * cosCacheX24 * cosCacheY16 +
                        coeffs27 * cosCacheX24 * cosCacheY24 +
                        coeffs28 * cosCacheX24 * cosCacheY32 +
                        coeffs29 * cosCacheX24 * cosCacheY40 +
                        coeffs30 * cosCacheX24 * cosCacheY48 +
                        coeffs31 * cosCacheX24 * cosCacheY56 +
                        coeffs32 * cosCacheX32 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY8 +
                        coeffs34 * cosCacheX32 * cosCacheY16 +
                        coeffs35 * cosCacheX32 * cosCacheY24 +
                        coeffs36 * cosCacheX32 * cosCacheY32 +
                        coeffs37 * cosCacheX32 * cosCacheY40 +
                        coeffs38 * cosCacheX32 * cosCacheY48 +
                        coeffs39 * cosCacheX32 * cosCacheY56 +
                        coeffs40 * cosCacheX40 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY8 +
                        coeffs42 * cosCacheX40 * cosCacheY16 +
                        coeffs43 * cosCacheX40 * cosCacheY24 +
                        coeffs44 * cosCacheX40 * cosCacheY32 +
                        coeffs45 * cosCacheX40 * cosCacheY40 +
                        coeffs46 * cosCacheX40 * cosCacheY48 +
                        coeffs47 * cosCacheX40 * cosCacheY56 +
                        coeffs48 * cosCacheX48 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY8 +
                        coeffs50 * cosCacheX48 * cosCacheY16 +
                        coeffs51 * cosCacheX48 * cosCacheY24 +
                        coeffs52 * cosCacheX48 * cosCacheY32 +
                        coeffs53 * cosCacheX48 * cosCacheY40 +
                        coeffs54 * cosCacheX48 * cosCacheY48 +
                        coeffs55 * cosCacheX48 * cosCacheY56 +
                        coeffs56 * cosCacheX56 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY8 +
                        coeffs58 * cosCacheX56 * cosCacheY16 +
                        coeffs59 * cosCacheX56 * cosCacheY24 +
                        coeffs60 * cosCacheX56 * cosCacheY32 +
                        coeffs61 * cosCacheX56 * cosCacheY40 +
                        coeffs62 * cosCacheX56 * cosCacheY48 +
                        coeffs63 * cosCacheX56 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 1] = (coeffs0 * cosCacheX0 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY9 +
                        coeffs10 * cosCacheX8 * cosCacheY17 +
                        coeffs11 * cosCacheX8 * cosCacheY25 +
                        coeffs12 * cosCacheX8 * cosCacheY33 +
                        coeffs13 * cosCacheX8 * cosCacheY41 +
                        coeffs14 * cosCacheX8 * cosCacheY49 +
                        coeffs15 * cosCacheX8 * cosCacheY57 +
                        coeffs16 * cosCacheX16 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY9 +
                        coeffs18 * cosCacheX16 * cosCacheY17 +
                        coeffs19 * cosCacheX16 * cosCacheY25 +
                        coeffs20 * cosCacheX16 * cosCacheY33 +
                        coeffs21 * cosCacheX16 * cosCacheY41 +
                        coeffs22 * cosCacheX16 * cosCacheY49 +
                        coeffs23 * cosCacheX16 * cosCacheY57 +
                        coeffs24 * cosCacheX24 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY9 +
                        coeffs26 * cosCacheX24 * cosCacheY17 +
                        coeffs27 * cosCacheX24 * cosCacheY25 +
                        coeffs28 * cosCacheX24 * cosCacheY33 +
                        coeffs29 * cosCacheX24 * cosCacheY41 +
                        coeffs30 * cosCacheX24 * cosCacheY49 +
                        coeffs31 * cosCacheX24 * cosCacheY57 +
                        coeffs32 * cosCacheX32 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY9 +
                        coeffs34 * cosCacheX32 * cosCacheY17 +
                        coeffs35 * cosCacheX32 * cosCacheY25 +
                        coeffs36 * cosCacheX32 * cosCacheY33 +
                        coeffs37 * cosCacheX32 * cosCacheY41 +
                        coeffs38 * cosCacheX32 * cosCacheY49 +
                        coeffs39 * cosCacheX32 * cosCacheY57 +
                        coeffs40 * cosCacheX40 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY9 +
                        coeffs42 * cosCacheX40 * cosCacheY17 +
                        coeffs43 * cosCacheX40 * cosCacheY25 +
                        coeffs44 * cosCacheX40 * cosCacheY33 +
                        coeffs45 * cosCacheX40 * cosCacheY41 +
                        coeffs46 * cosCacheX40 * cosCacheY49 +
                        coeffs47 * cosCacheX40 * cosCacheY57 +
                        coeffs48 * cosCacheX48 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY9 +
                        coeffs50 * cosCacheX48 * cosCacheY17 +
                        coeffs51 * cosCacheX48 * cosCacheY25 +
                        coeffs52 * cosCacheX48 * cosCacheY33 +
                        coeffs53 * cosCacheX48 * cosCacheY41 +
                        coeffs54 * cosCacheX48 * cosCacheY49 +
                        coeffs55 * cosCacheX48 * cosCacheY57 +
                        coeffs56 * cosCacheX56 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY9 +
                        coeffs58 * cosCacheX56 * cosCacheY17 +
                        coeffs59 * cosCacheX56 * cosCacheY25 +
                        coeffs60 * cosCacheX56 * cosCacheY33 +
                        coeffs61 * cosCacheX56 * cosCacheY41 +
                        coeffs62 * cosCacheX56 * cosCacheY49 +
                        coeffs63 * cosCacheX56 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 2] = (coeffs0 * cosCacheX0 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY10 +
                        coeffs10 * cosCacheX8 * cosCacheY18 +
                        coeffs11 * cosCacheX8 * cosCacheY26 +
                        coeffs12 * cosCacheX8 * cosCacheY34 +
                        coeffs13 * cosCacheX8 * cosCacheY42 +
                        coeffs14 * cosCacheX8 * cosCacheY50 +
                        coeffs15 * cosCacheX8 * cosCacheY58 +
                        coeffs16 * cosCacheX16 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY10 +
                        coeffs18 * cosCacheX16 * cosCacheY18 +
                        coeffs19 * cosCacheX16 * cosCacheY26 +
                        coeffs20 * cosCacheX16 * cosCacheY34 +
                        coeffs21 * cosCacheX16 * cosCacheY42 +
                        coeffs22 * cosCacheX16 * cosCacheY50 +
                        coeffs23 * cosCacheX16 * cosCacheY58 +
                        coeffs24 * cosCacheX24 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY10 +
                        coeffs26 * cosCacheX24 * cosCacheY18 +
                        coeffs27 * cosCacheX24 * cosCacheY26 +
                        coeffs28 * cosCacheX24 * cosCacheY34 +
                        coeffs29 * cosCacheX24 * cosCacheY42 +
                        coeffs30 * cosCacheX24 * cosCacheY50 +
                        coeffs31 * cosCacheX24 * cosCacheY58 +
                        coeffs32 * cosCacheX32 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY10 +
                        coeffs34 * cosCacheX32 * cosCacheY18 +
                        coeffs35 * cosCacheX32 * cosCacheY26 +
                        coeffs36 * cosCacheX32 * cosCacheY34 +
                        coeffs37 * cosCacheX32 * cosCacheY42 +
                        coeffs38 * cosCacheX32 * cosCacheY50 +
                        coeffs39 * cosCacheX32 * cosCacheY58 +
                        coeffs40 * cosCacheX40 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY10 +
                        coeffs42 * cosCacheX40 * cosCacheY18 +
                        coeffs43 * cosCacheX40 * cosCacheY26 +
                        coeffs44 * cosCacheX40 * cosCacheY34 +
                        coeffs45 * cosCacheX40 * cosCacheY42 +
                        coeffs46 * cosCacheX40 * cosCacheY50 +
                        coeffs47 * cosCacheX40 * cosCacheY58 +
                        coeffs48 * cosCacheX48 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY10 +
                        coeffs50 * cosCacheX48 * cosCacheY18 +
                        coeffs51 * cosCacheX48 * cosCacheY26 +
                        coeffs52 * cosCacheX48 * cosCacheY34 +
                        coeffs53 * cosCacheX48 * cosCacheY42 +
                        coeffs54 * cosCacheX48 * cosCacheY50 +
                        coeffs55 * cosCacheX48 * cosCacheY58 +
                        coeffs56 * cosCacheX56 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY10 +
                        coeffs58 * cosCacheX56 * cosCacheY18 +
                        coeffs59 * cosCacheX56 * cosCacheY26 +
                        coeffs60 * cosCacheX56 * cosCacheY34 +
                        coeffs61 * cosCacheX56 * cosCacheY42 +
                        coeffs62 * cosCacheX56 * cosCacheY50 +
                        coeffs63 * cosCacheX56 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 3] = (coeffs0 * cosCacheX0 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY11 +
                        coeffs10 * cosCacheX8 * cosCacheY19 +
                        coeffs11 * cosCacheX8 * cosCacheY27 +
                        coeffs12 * cosCacheX8 * cosCacheY35 +
                        coeffs13 * cosCacheX8 * cosCacheY43 +
                        coeffs14 * cosCacheX8 * cosCacheY51 +
                        coeffs15 * cosCacheX8 * cosCacheY59 +
                        coeffs16 * cosCacheX16 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY11 +
                        coeffs18 * cosCacheX16 * cosCacheY19 +
                        coeffs19 * cosCacheX16 * cosCacheY27 +
                        coeffs20 * cosCacheX16 * cosCacheY35 +
                        coeffs21 * cosCacheX16 * cosCacheY43 +
                        coeffs22 * cosCacheX16 * cosCacheY51 +
                        coeffs23 * cosCacheX16 * cosCacheY59 +
                        coeffs24 * cosCacheX24 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY11 +
                        coeffs26 * cosCacheX24 * cosCacheY19 +
                        coeffs27 * cosCacheX24 * cosCacheY27 +
                        coeffs28 * cosCacheX24 * cosCacheY35 +
                        coeffs29 * cosCacheX24 * cosCacheY43 +
                        coeffs30 * cosCacheX24 * cosCacheY51 +
                        coeffs31 * cosCacheX24 * cosCacheY59 +
                        coeffs32 * cosCacheX32 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY11 +
                        coeffs34 * cosCacheX32 * cosCacheY19 +
                        coeffs35 * cosCacheX32 * cosCacheY27 +
                        coeffs36 * cosCacheX32 * cosCacheY35 +
                        coeffs37 * cosCacheX32 * cosCacheY43 +
                        coeffs38 * cosCacheX32 * cosCacheY51 +
                        coeffs39 * cosCacheX32 * cosCacheY59 +
                        coeffs40 * cosCacheX40 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY11 +
                        coeffs42 * cosCacheX40 * cosCacheY19 +
                        coeffs43 * cosCacheX40 * cosCacheY27 +
                        coeffs44 * cosCacheX40 * cosCacheY35 +
                        coeffs45 * cosCacheX40 * cosCacheY43 +
                        coeffs46 * cosCacheX40 * cosCacheY51 +
                        coeffs47 * cosCacheX40 * cosCacheY59 +
                        coeffs48 * cosCacheX48 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY11 +
                        coeffs50 * cosCacheX48 * cosCacheY19 +
                        coeffs51 * cosCacheX48 * cosCacheY27 +
                        coeffs52 * cosCacheX48 * cosCacheY35 +
                        coeffs53 * cosCacheX48 * cosCacheY43 +
                        coeffs54 * cosCacheX48 * cosCacheY51 +
                        coeffs55 * cosCacheX48 * cosCacheY59 +
                        coeffs56 * cosCacheX56 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY11 +
                        coeffs58 * cosCacheX56 * cosCacheY19 +
                        coeffs59 * cosCacheX56 * cosCacheY27 +
                        coeffs60 * cosCacheX56 * cosCacheY35 +
                        coeffs61 * cosCacheX56 * cosCacheY43 +
                        coeffs62 * cosCacheX56 * cosCacheY51 +
                        coeffs63 * cosCacheX56 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 4] = (coeffs0 * cosCacheX0 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY12 +
                        coeffs10 * cosCacheX8 * cosCacheY20 +
                        coeffs11 * cosCacheX8 * cosCacheY28 +
                        coeffs12 * cosCacheX8 * cosCacheY36 +
                        coeffs13 * cosCacheX8 * cosCacheY44 +
                        coeffs14 * cosCacheX8 * cosCacheY52 +
                        coeffs15 * cosCacheX8 * cosCacheY60 +
                        coeffs16 * cosCacheX16 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY12 +
                        coeffs18 * cosCacheX16 * cosCacheY20 +
                        coeffs19 * cosCacheX16 * cosCacheY28 +
                        coeffs20 * cosCacheX16 * cosCacheY36 +
                        coeffs21 * cosCacheX16 * cosCacheY44 +
                        coeffs22 * cosCacheX16 * cosCacheY52 +
                        coeffs23 * cosCacheX16 * cosCacheY60 +
                        coeffs24 * cosCacheX24 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY12 +
                        coeffs26 * cosCacheX24 * cosCacheY20 +
                        coeffs27 * cosCacheX24 * cosCacheY28 +
                        coeffs28 * cosCacheX24 * cosCacheY36 +
                        coeffs29 * cosCacheX24 * cosCacheY44 +
                        coeffs30 * cosCacheX24 * cosCacheY52 +
                        coeffs31 * cosCacheX24 * cosCacheY60 +
                        coeffs32 * cosCacheX32 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY12 +
                        coeffs34 * cosCacheX32 * cosCacheY20 +
                        coeffs35 * cosCacheX32 * cosCacheY28 +
                        coeffs36 * cosCacheX32 * cosCacheY36 +
                        coeffs37 * cosCacheX32 * cosCacheY44 +
                        coeffs38 * cosCacheX32 * cosCacheY52 +
                        coeffs39 * cosCacheX32 * cosCacheY60 +
                        coeffs40 * cosCacheX40 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY12 +
                        coeffs42 * cosCacheX40 * cosCacheY20 +
                        coeffs43 * cosCacheX40 * cosCacheY28 +
                        coeffs44 * cosCacheX40 * cosCacheY36 +
                        coeffs45 * cosCacheX40 * cosCacheY44 +
                        coeffs46 * cosCacheX40 * cosCacheY52 +
                        coeffs47 * cosCacheX40 * cosCacheY60 +
                        coeffs48 * cosCacheX48 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY12 +
                        coeffs50 * cosCacheX48 * cosCacheY20 +
                        coeffs51 * cosCacheX48 * cosCacheY28 +
                        coeffs52 * cosCacheX48 * cosCacheY36 +
                        coeffs53 * cosCacheX48 * cosCacheY44 +
                        coeffs54 * cosCacheX48 * cosCacheY52 +
                        coeffs55 * cosCacheX48 * cosCacheY60 +
                        coeffs56 * cosCacheX56 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY12 +
                        coeffs58 * cosCacheX56 * cosCacheY20 +
                        coeffs59 * cosCacheX56 * cosCacheY28 +
                        coeffs60 * cosCacheX56 * cosCacheY36 +
                        coeffs61 * cosCacheX56 * cosCacheY44 +
                        coeffs62 * cosCacheX56 * cosCacheY52 +
                        coeffs63 * cosCacheX56 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 5] = (coeffs0 * cosCacheX0 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY13 +
                        coeffs10 * cosCacheX8 * cosCacheY21 +
                        coeffs11 * cosCacheX8 * cosCacheY29 +
                        coeffs12 * cosCacheX8 * cosCacheY37 +
                        coeffs13 * cosCacheX8 * cosCacheY45 +
                        coeffs14 * cosCacheX8 * cosCacheY53 +
                        coeffs15 * cosCacheX8 * cosCacheY61 +
                        coeffs16 * cosCacheX16 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY13 +
                        coeffs18 * cosCacheX16 * cosCacheY21 +
                        coeffs19 * cosCacheX16 * cosCacheY29 +
                        coeffs20 * cosCacheX16 * cosCacheY37 +
                        coeffs21 * cosCacheX16 * cosCacheY45 +
                        coeffs22 * cosCacheX16 * cosCacheY53 +
                        coeffs23 * cosCacheX16 * cosCacheY61 +
                        coeffs24 * cosCacheX24 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY13 +
                        coeffs26 * cosCacheX24 * cosCacheY21 +
                        coeffs27 * cosCacheX24 * cosCacheY29 +
                        coeffs28 * cosCacheX24 * cosCacheY37 +
                        coeffs29 * cosCacheX24 * cosCacheY45 +
                        coeffs30 * cosCacheX24 * cosCacheY53 +
                        coeffs31 * cosCacheX24 * cosCacheY61 +
                        coeffs32 * cosCacheX32 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY13 +
                        coeffs34 * cosCacheX32 * cosCacheY21 +
                        coeffs35 * cosCacheX32 * cosCacheY29 +
                        coeffs36 * cosCacheX32 * cosCacheY37 +
                        coeffs37 * cosCacheX32 * cosCacheY45 +
                        coeffs38 * cosCacheX32 * cosCacheY53 +
                        coeffs39 * cosCacheX32 * cosCacheY61 +
                        coeffs40 * cosCacheX40 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY13 +
                        coeffs42 * cosCacheX40 * cosCacheY21 +
                        coeffs43 * cosCacheX40 * cosCacheY29 +
                        coeffs44 * cosCacheX40 * cosCacheY37 +
                        coeffs45 * cosCacheX40 * cosCacheY45 +
                        coeffs46 * cosCacheX40 * cosCacheY53 +
                        coeffs47 * cosCacheX40 * cosCacheY61 +
                        coeffs48 * cosCacheX48 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY13 +
                        coeffs50 * cosCacheX48 * cosCacheY21 +
                        coeffs51 * cosCacheX48 * cosCacheY29 +
                        coeffs52 * cosCacheX48 * cosCacheY37 +
                        coeffs53 * cosCacheX48 * cosCacheY45 +
                        coeffs54 * cosCacheX48 * cosCacheY53 +
                        coeffs55 * cosCacheX48 * cosCacheY61 +
                        coeffs56 * cosCacheX56 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY13 +
                        coeffs58 * cosCacheX56 * cosCacheY21 +
                        coeffs59 * cosCacheX56 * cosCacheY29 +
                        coeffs60 * cosCacheX56 * cosCacheY37 +
                        coeffs61 * cosCacheX56 * cosCacheY45 +
                        coeffs62 * cosCacheX56 * cosCacheY53 +
                        coeffs63 * cosCacheX56 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 6] = (coeffs0 * cosCacheX0 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY14 +
                        coeffs10 * cosCacheX8 * cosCacheY22 +
                        coeffs11 * cosCacheX8 * cosCacheY30 +
                        coeffs12 * cosCacheX8 * cosCacheY38 +
                        coeffs13 * cosCacheX8 * cosCacheY46 +
                        coeffs14 * cosCacheX8 * cosCacheY54 +
                        coeffs15 * cosCacheX8 * cosCacheY62 +
                        coeffs16 * cosCacheX16 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY14 +
                        coeffs18 * cosCacheX16 * cosCacheY22 +
                        coeffs19 * cosCacheX16 * cosCacheY30 +
                        coeffs20 * cosCacheX16 * cosCacheY38 +
                        coeffs21 * cosCacheX16 * cosCacheY46 +
                        coeffs22 * cosCacheX16 * cosCacheY54 +
                        coeffs23 * cosCacheX16 * cosCacheY62 +
                        coeffs24 * cosCacheX24 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY14 +
                        coeffs26 * cosCacheX24 * cosCacheY22 +
                        coeffs27 * cosCacheX24 * cosCacheY30 +
                        coeffs28 * cosCacheX24 * cosCacheY38 +
                        coeffs29 * cosCacheX24 * cosCacheY46 +
                        coeffs30 * cosCacheX24 * cosCacheY54 +
                        coeffs31 * cosCacheX24 * cosCacheY62 +
                        coeffs32 * cosCacheX32 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY14 +
                        coeffs34 * cosCacheX32 * cosCacheY22 +
                        coeffs35 * cosCacheX32 * cosCacheY30 +
                        coeffs36 * cosCacheX32 * cosCacheY38 +
                        coeffs37 * cosCacheX32 * cosCacheY46 +
                        coeffs38 * cosCacheX32 * cosCacheY54 +
                        coeffs39 * cosCacheX32 * cosCacheY62 +
                        coeffs40 * cosCacheX40 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY14 +
                        coeffs42 * cosCacheX40 * cosCacheY22 +
                        coeffs43 * cosCacheX40 * cosCacheY30 +
                        coeffs44 * cosCacheX40 * cosCacheY38 +
                        coeffs45 * cosCacheX40 * cosCacheY46 +
                        coeffs46 * cosCacheX40 * cosCacheY54 +
                        coeffs47 * cosCacheX40 * cosCacheY62 +
                        coeffs48 * cosCacheX48 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY14 +
                        coeffs50 * cosCacheX48 * cosCacheY22 +
                        coeffs51 * cosCacheX48 * cosCacheY30 +
                        coeffs52 * cosCacheX48 * cosCacheY38 +
                        coeffs53 * cosCacheX48 * cosCacheY46 +
                        coeffs54 * cosCacheX48 * cosCacheY54 +
                        coeffs55 * cosCacheX48 * cosCacheY62 +
                        coeffs56 * cosCacheX56 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY14 +
                        coeffs58 * cosCacheX56 * cosCacheY22 +
                        coeffs59 * cosCacheX56 * cosCacheY30 +
                        coeffs60 * cosCacheX56 * cosCacheY38 +
                        coeffs61 * cosCacheX56 * cosCacheY46 +
                        coeffs62 * cosCacheX56 * cosCacheY54 +
                        coeffs63 * cosCacheX56 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 7] = (coeffs0 * cosCacheX0 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX0 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX0 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX0 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX0 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX0 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX0 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX0 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX8 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX8 * cosCacheY15 +
                        coeffs10 * cosCacheX8 * cosCacheY23 +
                        coeffs11 * cosCacheX8 * cosCacheY31 +
                        coeffs12 * cosCacheX8 * cosCacheY39 +
                        coeffs13 * cosCacheX8 * cosCacheY47 +
                        coeffs14 * cosCacheX8 * cosCacheY55 +
                        coeffs15 * cosCacheX8 * cosCacheY63 +
                        coeffs16 * cosCacheX16 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX16 * cosCacheY15 +
                        coeffs18 * cosCacheX16 * cosCacheY23 +
                        coeffs19 * cosCacheX16 * cosCacheY31 +
                        coeffs20 * cosCacheX16 * cosCacheY39 +
                        coeffs21 * cosCacheX16 * cosCacheY47 +
                        coeffs22 * cosCacheX16 * cosCacheY55 +
                        coeffs23 * cosCacheX16 * cosCacheY63 +
                        coeffs24 * cosCacheX24 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX24 * cosCacheY15 +
                        coeffs26 * cosCacheX24 * cosCacheY23 +
                        coeffs27 * cosCacheX24 * cosCacheY31 +
                        coeffs28 * cosCacheX24 * cosCacheY39 +
                        coeffs29 * cosCacheX24 * cosCacheY47 +
                        coeffs30 * cosCacheX24 * cosCacheY55 +
                        coeffs31 * cosCacheX24 * cosCacheY63 +
                        coeffs32 * cosCacheX32 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX32 * cosCacheY15 +
                        coeffs34 * cosCacheX32 * cosCacheY23 +
                        coeffs35 * cosCacheX32 * cosCacheY31 +
                        coeffs36 * cosCacheX32 * cosCacheY39 +
                        coeffs37 * cosCacheX32 * cosCacheY47 +
                        coeffs38 * cosCacheX32 * cosCacheY55 +
                        coeffs39 * cosCacheX32 * cosCacheY63 +
                        coeffs40 * cosCacheX40 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX40 * cosCacheY15 +
                        coeffs42 * cosCacheX40 * cosCacheY23 +
                        coeffs43 * cosCacheX40 * cosCacheY31 +
                        coeffs44 * cosCacheX40 * cosCacheY39 +
                        coeffs45 * cosCacheX40 * cosCacheY47 +
                        coeffs46 * cosCacheX40 * cosCacheY55 +
                        coeffs47 * cosCacheX40 * cosCacheY63 +
                        coeffs48 * cosCacheX48 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX48 * cosCacheY15 +
                        coeffs50 * cosCacheX48 * cosCacheY23 +
                        coeffs51 * cosCacheX48 * cosCacheY31 +
                        coeffs52 * cosCacheX48 * cosCacheY39 +
                        coeffs53 * cosCacheX48 * cosCacheY47 +
                        coeffs54 * cosCacheX48 * cosCacheY55 +
                        coeffs55 * cosCacheX48 * cosCacheY63 +
                        coeffs56 * cosCacheX56 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX56 * cosCacheY15 +
                        coeffs58 * cosCacheX56 * cosCacheY23 +
                        coeffs59 * cosCacheX56 * cosCacheY31 +
                        coeffs60 * cosCacheX56 * cosCacheY39 +
                        coeffs61 * cosCacheX56 * cosCacheY47 +
                        coeffs62 * cosCacheX56 * cosCacheY55 +
                        coeffs63 * cosCacheX56 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 0] = (coeffs0 * cosCacheX1 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY8 +
                        coeffs10 * cosCacheX9 * cosCacheY16 +
                        coeffs11 * cosCacheX9 * cosCacheY24 +
                        coeffs12 * cosCacheX9 * cosCacheY32 +
                        coeffs13 * cosCacheX9 * cosCacheY40 +
                        coeffs14 * cosCacheX9 * cosCacheY48 +
                        coeffs15 * cosCacheX9 * cosCacheY56 +
                        coeffs16 * cosCacheX17 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY8 +
                        coeffs18 * cosCacheX17 * cosCacheY16 +
                        coeffs19 * cosCacheX17 * cosCacheY24 +
                        coeffs20 * cosCacheX17 * cosCacheY32 +
                        coeffs21 * cosCacheX17 * cosCacheY40 +
                        coeffs22 * cosCacheX17 * cosCacheY48 +
                        coeffs23 * cosCacheX17 * cosCacheY56 +
                        coeffs24 * cosCacheX25 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY8 +
                        coeffs26 * cosCacheX25 * cosCacheY16 +
                        coeffs27 * cosCacheX25 * cosCacheY24 +
                        coeffs28 * cosCacheX25 * cosCacheY32 +
                        coeffs29 * cosCacheX25 * cosCacheY40 +
                        coeffs30 * cosCacheX25 * cosCacheY48 +
                        coeffs31 * cosCacheX25 * cosCacheY56 +
                        coeffs32 * cosCacheX33 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY8 +
                        coeffs34 * cosCacheX33 * cosCacheY16 +
                        coeffs35 * cosCacheX33 * cosCacheY24 +
                        coeffs36 * cosCacheX33 * cosCacheY32 +
                        coeffs37 * cosCacheX33 * cosCacheY40 +
                        coeffs38 * cosCacheX33 * cosCacheY48 +
                        coeffs39 * cosCacheX33 * cosCacheY56 +
                        coeffs40 * cosCacheX41 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY8 +
                        coeffs42 * cosCacheX41 * cosCacheY16 +
                        coeffs43 * cosCacheX41 * cosCacheY24 +
                        coeffs44 * cosCacheX41 * cosCacheY32 +
                        coeffs45 * cosCacheX41 * cosCacheY40 +
                        coeffs46 * cosCacheX41 * cosCacheY48 +
                        coeffs47 * cosCacheX41 * cosCacheY56 +
                        coeffs48 * cosCacheX49 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY8 +
                        coeffs50 * cosCacheX49 * cosCacheY16 +
                        coeffs51 * cosCacheX49 * cosCacheY24 +
                        coeffs52 * cosCacheX49 * cosCacheY32 +
                        coeffs53 * cosCacheX49 * cosCacheY40 +
                        coeffs54 * cosCacheX49 * cosCacheY48 +
                        coeffs55 * cosCacheX49 * cosCacheY56 +
                        coeffs56 * cosCacheX57 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY8 +
                        coeffs58 * cosCacheX57 * cosCacheY16 +
                        coeffs59 * cosCacheX57 * cosCacheY24 +
                        coeffs60 * cosCacheX57 * cosCacheY32 +
                        coeffs61 * cosCacheX57 * cosCacheY40 +
                        coeffs62 * cosCacheX57 * cosCacheY48 +
                        coeffs63 * cosCacheX57 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 1] = (coeffs0 * cosCacheX1 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY9 +
                        coeffs10 * cosCacheX9 * cosCacheY17 +
                        coeffs11 * cosCacheX9 * cosCacheY25 +
                        coeffs12 * cosCacheX9 * cosCacheY33 +
                        coeffs13 * cosCacheX9 * cosCacheY41 +
                        coeffs14 * cosCacheX9 * cosCacheY49 +
                        coeffs15 * cosCacheX9 * cosCacheY57 +
                        coeffs16 * cosCacheX17 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY9 +
                        coeffs18 * cosCacheX17 * cosCacheY17 +
                        coeffs19 * cosCacheX17 * cosCacheY25 +
                        coeffs20 * cosCacheX17 * cosCacheY33 +
                        coeffs21 * cosCacheX17 * cosCacheY41 +
                        coeffs22 * cosCacheX17 * cosCacheY49 +
                        coeffs23 * cosCacheX17 * cosCacheY57 +
                        coeffs24 * cosCacheX25 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY9 +
                        coeffs26 * cosCacheX25 * cosCacheY17 +
                        coeffs27 * cosCacheX25 * cosCacheY25 +
                        coeffs28 * cosCacheX25 * cosCacheY33 +
                        coeffs29 * cosCacheX25 * cosCacheY41 +
                        coeffs30 * cosCacheX25 * cosCacheY49 +
                        coeffs31 * cosCacheX25 * cosCacheY57 +
                        coeffs32 * cosCacheX33 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY9 +
                        coeffs34 * cosCacheX33 * cosCacheY17 +
                        coeffs35 * cosCacheX33 * cosCacheY25 +
                        coeffs36 * cosCacheX33 * cosCacheY33 +
                        coeffs37 * cosCacheX33 * cosCacheY41 +
                        coeffs38 * cosCacheX33 * cosCacheY49 +
                        coeffs39 * cosCacheX33 * cosCacheY57 +
                        coeffs40 * cosCacheX41 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY9 +
                        coeffs42 * cosCacheX41 * cosCacheY17 +
                        coeffs43 * cosCacheX41 * cosCacheY25 +
                        coeffs44 * cosCacheX41 * cosCacheY33 +
                        coeffs45 * cosCacheX41 * cosCacheY41 +
                        coeffs46 * cosCacheX41 * cosCacheY49 +
                        coeffs47 * cosCacheX41 * cosCacheY57 +
                        coeffs48 * cosCacheX49 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY9 +
                        coeffs50 * cosCacheX49 * cosCacheY17 +
                        coeffs51 * cosCacheX49 * cosCacheY25 +
                        coeffs52 * cosCacheX49 * cosCacheY33 +
                        coeffs53 * cosCacheX49 * cosCacheY41 +
                        coeffs54 * cosCacheX49 * cosCacheY49 +
                        coeffs55 * cosCacheX49 * cosCacheY57 +
                        coeffs56 * cosCacheX57 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY9 +
                        coeffs58 * cosCacheX57 * cosCacheY17 +
                        coeffs59 * cosCacheX57 * cosCacheY25 +
                        coeffs60 * cosCacheX57 * cosCacheY33 +
                        coeffs61 * cosCacheX57 * cosCacheY41 +
                        coeffs62 * cosCacheX57 * cosCacheY49 +
                        coeffs63 * cosCacheX57 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 2] = (coeffs0 * cosCacheX1 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY10 +
                        coeffs10 * cosCacheX9 * cosCacheY18 +
                        coeffs11 * cosCacheX9 * cosCacheY26 +
                        coeffs12 * cosCacheX9 * cosCacheY34 +
                        coeffs13 * cosCacheX9 * cosCacheY42 +
                        coeffs14 * cosCacheX9 * cosCacheY50 +
                        coeffs15 * cosCacheX9 * cosCacheY58 +
                        coeffs16 * cosCacheX17 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY10 +
                        coeffs18 * cosCacheX17 * cosCacheY18 +
                        coeffs19 * cosCacheX17 * cosCacheY26 +
                        coeffs20 * cosCacheX17 * cosCacheY34 +
                        coeffs21 * cosCacheX17 * cosCacheY42 +
                        coeffs22 * cosCacheX17 * cosCacheY50 +
                        coeffs23 * cosCacheX17 * cosCacheY58 +
                        coeffs24 * cosCacheX25 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY10 +
                        coeffs26 * cosCacheX25 * cosCacheY18 +
                        coeffs27 * cosCacheX25 * cosCacheY26 +
                        coeffs28 * cosCacheX25 * cosCacheY34 +
                        coeffs29 * cosCacheX25 * cosCacheY42 +
                        coeffs30 * cosCacheX25 * cosCacheY50 +
                        coeffs31 * cosCacheX25 * cosCacheY58 +
                        coeffs32 * cosCacheX33 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY10 +
                        coeffs34 * cosCacheX33 * cosCacheY18 +
                        coeffs35 * cosCacheX33 * cosCacheY26 +
                        coeffs36 * cosCacheX33 * cosCacheY34 +
                        coeffs37 * cosCacheX33 * cosCacheY42 +
                        coeffs38 * cosCacheX33 * cosCacheY50 +
                        coeffs39 * cosCacheX33 * cosCacheY58 +
                        coeffs40 * cosCacheX41 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY10 +
                        coeffs42 * cosCacheX41 * cosCacheY18 +
                        coeffs43 * cosCacheX41 * cosCacheY26 +
                        coeffs44 * cosCacheX41 * cosCacheY34 +
                        coeffs45 * cosCacheX41 * cosCacheY42 +
                        coeffs46 * cosCacheX41 * cosCacheY50 +
                        coeffs47 * cosCacheX41 * cosCacheY58 +
                        coeffs48 * cosCacheX49 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY10 +
                        coeffs50 * cosCacheX49 * cosCacheY18 +
                        coeffs51 * cosCacheX49 * cosCacheY26 +
                        coeffs52 * cosCacheX49 * cosCacheY34 +
                        coeffs53 * cosCacheX49 * cosCacheY42 +
                        coeffs54 * cosCacheX49 * cosCacheY50 +
                        coeffs55 * cosCacheX49 * cosCacheY58 +
                        coeffs56 * cosCacheX57 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY10 +
                        coeffs58 * cosCacheX57 * cosCacheY18 +
                        coeffs59 * cosCacheX57 * cosCacheY26 +
                        coeffs60 * cosCacheX57 * cosCacheY34 +
                        coeffs61 * cosCacheX57 * cosCacheY42 +
                        coeffs62 * cosCacheX57 * cosCacheY50 +
                        coeffs63 * cosCacheX57 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 3] = (coeffs0 * cosCacheX1 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY11 +
                        coeffs10 * cosCacheX9 * cosCacheY19 +
                        coeffs11 * cosCacheX9 * cosCacheY27 +
                        coeffs12 * cosCacheX9 * cosCacheY35 +
                        coeffs13 * cosCacheX9 * cosCacheY43 +
                        coeffs14 * cosCacheX9 * cosCacheY51 +
                        coeffs15 * cosCacheX9 * cosCacheY59 +
                        coeffs16 * cosCacheX17 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY11 +
                        coeffs18 * cosCacheX17 * cosCacheY19 +
                        coeffs19 * cosCacheX17 * cosCacheY27 +
                        coeffs20 * cosCacheX17 * cosCacheY35 +
                        coeffs21 * cosCacheX17 * cosCacheY43 +
                        coeffs22 * cosCacheX17 * cosCacheY51 +
                        coeffs23 * cosCacheX17 * cosCacheY59 +
                        coeffs24 * cosCacheX25 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY11 +
                        coeffs26 * cosCacheX25 * cosCacheY19 +
                        coeffs27 * cosCacheX25 * cosCacheY27 +
                        coeffs28 * cosCacheX25 * cosCacheY35 +
                        coeffs29 * cosCacheX25 * cosCacheY43 +
                        coeffs30 * cosCacheX25 * cosCacheY51 +
                        coeffs31 * cosCacheX25 * cosCacheY59 +
                        coeffs32 * cosCacheX33 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY11 +
                        coeffs34 * cosCacheX33 * cosCacheY19 +
                        coeffs35 * cosCacheX33 * cosCacheY27 +
                        coeffs36 * cosCacheX33 * cosCacheY35 +
                        coeffs37 * cosCacheX33 * cosCacheY43 +
                        coeffs38 * cosCacheX33 * cosCacheY51 +
                        coeffs39 * cosCacheX33 * cosCacheY59 +
                        coeffs40 * cosCacheX41 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY11 +
                        coeffs42 * cosCacheX41 * cosCacheY19 +
                        coeffs43 * cosCacheX41 * cosCacheY27 +
                        coeffs44 * cosCacheX41 * cosCacheY35 +
                        coeffs45 * cosCacheX41 * cosCacheY43 +
                        coeffs46 * cosCacheX41 * cosCacheY51 +
                        coeffs47 * cosCacheX41 * cosCacheY59 +
                        coeffs48 * cosCacheX49 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY11 +
                        coeffs50 * cosCacheX49 * cosCacheY19 +
                        coeffs51 * cosCacheX49 * cosCacheY27 +
                        coeffs52 * cosCacheX49 * cosCacheY35 +
                        coeffs53 * cosCacheX49 * cosCacheY43 +
                        coeffs54 * cosCacheX49 * cosCacheY51 +
                        coeffs55 * cosCacheX49 * cosCacheY59 +
                        coeffs56 * cosCacheX57 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY11 +
                        coeffs58 * cosCacheX57 * cosCacheY19 +
                        coeffs59 * cosCacheX57 * cosCacheY27 +
                        coeffs60 * cosCacheX57 * cosCacheY35 +
                        coeffs61 * cosCacheX57 * cosCacheY43 +
                        coeffs62 * cosCacheX57 * cosCacheY51 +
                        coeffs63 * cosCacheX57 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 4] = (coeffs0 * cosCacheX1 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY12 +
                        coeffs10 * cosCacheX9 * cosCacheY20 +
                        coeffs11 * cosCacheX9 * cosCacheY28 +
                        coeffs12 * cosCacheX9 * cosCacheY36 +
                        coeffs13 * cosCacheX9 * cosCacheY44 +
                        coeffs14 * cosCacheX9 * cosCacheY52 +
                        coeffs15 * cosCacheX9 * cosCacheY60 +
                        coeffs16 * cosCacheX17 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY12 +
                        coeffs18 * cosCacheX17 * cosCacheY20 +
                        coeffs19 * cosCacheX17 * cosCacheY28 +
                        coeffs20 * cosCacheX17 * cosCacheY36 +
                        coeffs21 * cosCacheX17 * cosCacheY44 +
                        coeffs22 * cosCacheX17 * cosCacheY52 +
                        coeffs23 * cosCacheX17 * cosCacheY60 +
                        coeffs24 * cosCacheX25 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY12 +
                        coeffs26 * cosCacheX25 * cosCacheY20 +
                        coeffs27 * cosCacheX25 * cosCacheY28 +
                        coeffs28 * cosCacheX25 * cosCacheY36 +
                        coeffs29 * cosCacheX25 * cosCacheY44 +
                        coeffs30 * cosCacheX25 * cosCacheY52 +
                        coeffs31 * cosCacheX25 * cosCacheY60 +
                        coeffs32 * cosCacheX33 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY12 +
                        coeffs34 * cosCacheX33 * cosCacheY20 +
                        coeffs35 * cosCacheX33 * cosCacheY28 +
                        coeffs36 * cosCacheX33 * cosCacheY36 +
                        coeffs37 * cosCacheX33 * cosCacheY44 +
                        coeffs38 * cosCacheX33 * cosCacheY52 +
                        coeffs39 * cosCacheX33 * cosCacheY60 +
                        coeffs40 * cosCacheX41 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY12 +
                        coeffs42 * cosCacheX41 * cosCacheY20 +
                        coeffs43 * cosCacheX41 * cosCacheY28 +
                        coeffs44 * cosCacheX41 * cosCacheY36 +
                        coeffs45 * cosCacheX41 * cosCacheY44 +
                        coeffs46 * cosCacheX41 * cosCacheY52 +
                        coeffs47 * cosCacheX41 * cosCacheY60 +
                        coeffs48 * cosCacheX49 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY12 +
                        coeffs50 * cosCacheX49 * cosCacheY20 +
                        coeffs51 * cosCacheX49 * cosCacheY28 +
                        coeffs52 * cosCacheX49 * cosCacheY36 +
                        coeffs53 * cosCacheX49 * cosCacheY44 +
                        coeffs54 * cosCacheX49 * cosCacheY52 +
                        coeffs55 * cosCacheX49 * cosCacheY60 +
                        coeffs56 * cosCacheX57 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY12 +
                        coeffs58 * cosCacheX57 * cosCacheY20 +
                        coeffs59 * cosCacheX57 * cosCacheY28 +
                        coeffs60 * cosCacheX57 * cosCacheY36 +
                        coeffs61 * cosCacheX57 * cosCacheY44 +
                        coeffs62 * cosCacheX57 * cosCacheY52 +
                        coeffs63 * cosCacheX57 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 5] = (coeffs0 * cosCacheX1 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY13 +
                        coeffs10 * cosCacheX9 * cosCacheY21 +
                        coeffs11 * cosCacheX9 * cosCacheY29 +
                        coeffs12 * cosCacheX9 * cosCacheY37 +
                        coeffs13 * cosCacheX9 * cosCacheY45 +
                        coeffs14 * cosCacheX9 * cosCacheY53 +
                        coeffs15 * cosCacheX9 * cosCacheY61 +
                        coeffs16 * cosCacheX17 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY13 +
                        coeffs18 * cosCacheX17 * cosCacheY21 +
                        coeffs19 * cosCacheX17 * cosCacheY29 +
                        coeffs20 * cosCacheX17 * cosCacheY37 +
                        coeffs21 * cosCacheX17 * cosCacheY45 +
                        coeffs22 * cosCacheX17 * cosCacheY53 +
                        coeffs23 * cosCacheX17 * cosCacheY61 +
                        coeffs24 * cosCacheX25 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY13 +
                        coeffs26 * cosCacheX25 * cosCacheY21 +
                        coeffs27 * cosCacheX25 * cosCacheY29 +
                        coeffs28 * cosCacheX25 * cosCacheY37 +
                        coeffs29 * cosCacheX25 * cosCacheY45 +
                        coeffs30 * cosCacheX25 * cosCacheY53 +
                        coeffs31 * cosCacheX25 * cosCacheY61 +
                        coeffs32 * cosCacheX33 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY13 +
                        coeffs34 * cosCacheX33 * cosCacheY21 +
                        coeffs35 * cosCacheX33 * cosCacheY29 +
                        coeffs36 * cosCacheX33 * cosCacheY37 +
                        coeffs37 * cosCacheX33 * cosCacheY45 +
                        coeffs38 * cosCacheX33 * cosCacheY53 +
                        coeffs39 * cosCacheX33 * cosCacheY61 +
                        coeffs40 * cosCacheX41 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY13 +
                        coeffs42 * cosCacheX41 * cosCacheY21 +
                        coeffs43 * cosCacheX41 * cosCacheY29 +
                        coeffs44 * cosCacheX41 * cosCacheY37 +
                        coeffs45 * cosCacheX41 * cosCacheY45 +
                        coeffs46 * cosCacheX41 * cosCacheY53 +
                        coeffs47 * cosCacheX41 * cosCacheY61 +
                        coeffs48 * cosCacheX49 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY13 +
                        coeffs50 * cosCacheX49 * cosCacheY21 +
                        coeffs51 * cosCacheX49 * cosCacheY29 +
                        coeffs52 * cosCacheX49 * cosCacheY37 +
                        coeffs53 * cosCacheX49 * cosCacheY45 +
                        coeffs54 * cosCacheX49 * cosCacheY53 +
                        coeffs55 * cosCacheX49 * cosCacheY61 +
                        coeffs56 * cosCacheX57 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY13 +
                        coeffs58 * cosCacheX57 * cosCacheY21 +
                        coeffs59 * cosCacheX57 * cosCacheY29 +
                        coeffs60 * cosCacheX57 * cosCacheY37 +
                        coeffs61 * cosCacheX57 * cosCacheY45 +
                        coeffs62 * cosCacheX57 * cosCacheY53 +
                        coeffs63 * cosCacheX57 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 6] = (coeffs0 * cosCacheX1 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY14 +
                        coeffs10 * cosCacheX9 * cosCacheY22 +
                        coeffs11 * cosCacheX9 * cosCacheY30 +
                        coeffs12 * cosCacheX9 * cosCacheY38 +
                        coeffs13 * cosCacheX9 * cosCacheY46 +
                        coeffs14 * cosCacheX9 * cosCacheY54 +
                        coeffs15 * cosCacheX9 * cosCacheY62 +
                        coeffs16 * cosCacheX17 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY14 +
                        coeffs18 * cosCacheX17 * cosCacheY22 +
                        coeffs19 * cosCacheX17 * cosCacheY30 +
                        coeffs20 * cosCacheX17 * cosCacheY38 +
                        coeffs21 * cosCacheX17 * cosCacheY46 +
                        coeffs22 * cosCacheX17 * cosCacheY54 +
                        coeffs23 * cosCacheX17 * cosCacheY62 +
                        coeffs24 * cosCacheX25 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY14 +
                        coeffs26 * cosCacheX25 * cosCacheY22 +
                        coeffs27 * cosCacheX25 * cosCacheY30 +
                        coeffs28 * cosCacheX25 * cosCacheY38 +
                        coeffs29 * cosCacheX25 * cosCacheY46 +
                        coeffs30 * cosCacheX25 * cosCacheY54 +
                        coeffs31 * cosCacheX25 * cosCacheY62 +
                        coeffs32 * cosCacheX33 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY14 +
                        coeffs34 * cosCacheX33 * cosCacheY22 +
                        coeffs35 * cosCacheX33 * cosCacheY30 +
                        coeffs36 * cosCacheX33 * cosCacheY38 +
                        coeffs37 * cosCacheX33 * cosCacheY46 +
                        coeffs38 * cosCacheX33 * cosCacheY54 +
                        coeffs39 * cosCacheX33 * cosCacheY62 +
                        coeffs40 * cosCacheX41 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY14 +
                        coeffs42 * cosCacheX41 * cosCacheY22 +
                        coeffs43 * cosCacheX41 * cosCacheY30 +
                        coeffs44 * cosCacheX41 * cosCacheY38 +
                        coeffs45 * cosCacheX41 * cosCacheY46 +
                        coeffs46 * cosCacheX41 * cosCacheY54 +
                        coeffs47 * cosCacheX41 * cosCacheY62 +
                        coeffs48 * cosCacheX49 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY14 +
                        coeffs50 * cosCacheX49 * cosCacheY22 +
                        coeffs51 * cosCacheX49 * cosCacheY30 +
                        coeffs52 * cosCacheX49 * cosCacheY38 +
                        coeffs53 * cosCacheX49 * cosCacheY46 +
                        coeffs54 * cosCacheX49 * cosCacheY54 +
                        coeffs55 * cosCacheX49 * cosCacheY62 +
                        coeffs56 * cosCacheX57 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY14 +
                        coeffs58 * cosCacheX57 * cosCacheY22 +
                        coeffs59 * cosCacheX57 * cosCacheY30 +
                        coeffs60 * cosCacheX57 * cosCacheY38 +
                        coeffs61 * cosCacheX57 * cosCacheY46 +
                        coeffs62 * cosCacheX57 * cosCacheY54 +
                        coeffs63 * cosCacheX57 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 7] = (coeffs0 * cosCacheX1 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX1 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX1 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX1 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX1 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX1 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX1 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX1 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX9 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX9 * cosCacheY15 +
                        coeffs10 * cosCacheX9 * cosCacheY23 +
                        coeffs11 * cosCacheX9 * cosCacheY31 +
                        coeffs12 * cosCacheX9 * cosCacheY39 +
                        coeffs13 * cosCacheX9 * cosCacheY47 +
                        coeffs14 * cosCacheX9 * cosCacheY55 +
                        coeffs15 * cosCacheX9 * cosCacheY63 +
                        coeffs16 * cosCacheX17 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX17 * cosCacheY15 +
                        coeffs18 * cosCacheX17 * cosCacheY23 +
                        coeffs19 * cosCacheX17 * cosCacheY31 +
                        coeffs20 * cosCacheX17 * cosCacheY39 +
                        coeffs21 * cosCacheX17 * cosCacheY47 +
                        coeffs22 * cosCacheX17 * cosCacheY55 +
                        coeffs23 * cosCacheX17 * cosCacheY63 +
                        coeffs24 * cosCacheX25 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX25 * cosCacheY15 +
                        coeffs26 * cosCacheX25 * cosCacheY23 +
                        coeffs27 * cosCacheX25 * cosCacheY31 +
                        coeffs28 * cosCacheX25 * cosCacheY39 +
                        coeffs29 * cosCacheX25 * cosCacheY47 +
                        coeffs30 * cosCacheX25 * cosCacheY55 +
                        coeffs31 * cosCacheX25 * cosCacheY63 +
                        coeffs32 * cosCacheX33 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX33 * cosCacheY15 +
                        coeffs34 * cosCacheX33 * cosCacheY23 +
                        coeffs35 * cosCacheX33 * cosCacheY31 +
                        coeffs36 * cosCacheX33 * cosCacheY39 +
                        coeffs37 * cosCacheX33 * cosCacheY47 +
                        coeffs38 * cosCacheX33 * cosCacheY55 +
                        coeffs39 * cosCacheX33 * cosCacheY63 +
                        coeffs40 * cosCacheX41 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX41 * cosCacheY15 +
                        coeffs42 * cosCacheX41 * cosCacheY23 +
                        coeffs43 * cosCacheX41 * cosCacheY31 +
                        coeffs44 * cosCacheX41 * cosCacheY39 +
                        coeffs45 * cosCacheX41 * cosCacheY47 +
                        coeffs46 * cosCacheX41 * cosCacheY55 +
                        coeffs47 * cosCacheX41 * cosCacheY63 +
                        coeffs48 * cosCacheX49 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX49 * cosCacheY15 +
                        coeffs50 * cosCacheX49 * cosCacheY23 +
                        coeffs51 * cosCacheX49 * cosCacheY31 +
                        coeffs52 * cosCacheX49 * cosCacheY39 +
                        coeffs53 * cosCacheX49 * cosCacheY47 +
                        coeffs54 * cosCacheX49 * cosCacheY55 +
                        coeffs55 * cosCacheX49 * cosCacheY63 +
                        coeffs56 * cosCacheX57 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX57 * cosCacheY15 +
                        coeffs58 * cosCacheX57 * cosCacheY23 +
                        coeffs59 * cosCacheX57 * cosCacheY31 +
                        coeffs60 * cosCacheX57 * cosCacheY39 +
                        coeffs61 * cosCacheX57 * cosCacheY47 +
                        coeffs62 * cosCacheX57 * cosCacheY55 +
                        coeffs63 * cosCacheX57 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 0] = (coeffs0 * cosCacheX2 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY8 +
                        coeffs10 * cosCacheX10 * cosCacheY16 +
                        coeffs11 * cosCacheX10 * cosCacheY24 +
                        coeffs12 * cosCacheX10 * cosCacheY32 +
                        coeffs13 * cosCacheX10 * cosCacheY40 +
                        coeffs14 * cosCacheX10 * cosCacheY48 +
                        coeffs15 * cosCacheX10 * cosCacheY56 +
                        coeffs16 * cosCacheX18 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY8 +
                        coeffs18 * cosCacheX18 * cosCacheY16 +
                        coeffs19 * cosCacheX18 * cosCacheY24 +
                        coeffs20 * cosCacheX18 * cosCacheY32 +
                        coeffs21 * cosCacheX18 * cosCacheY40 +
                        coeffs22 * cosCacheX18 * cosCacheY48 +
                        coeffs23 * cosCacheX18 * cosCacheY56 +
                        coeffs24 * cosCacheX26 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY8 +
                        coeffs26 * cosCacheX26 * cosCacheY16 +
                        coeffs27 * cosCacheX26 * cosCacheY24 +
                        coeffs28 * cosCacheX26 * cosCacheY32 +
                        coeffs29 * cosCacheX26 * cosCacheY40 +
                        coeffs30 * cosCacheX26 * cosCacheY48 +
                        coeffs31 * cosCacheX26 * cosCacheY56 +
                        coeffs32 * cosCacheX34 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY8 +
                        coeffs34 * cosCacheX34 * cosCacheY16 +
                        coeffs35 * cosCacheX34 * cosCacheY24 +
                        coeffs36 * cosCacheX34 * cosCacheY32 +
                        coeffs37 * cosCacheX34 * cosCacheY40 +
                        coeffs38 * cosCacheX34 * cosCacheY48 +
                        coeffs39 * cosCacheX34 * cosCacheY56 +
                        coeffs40 * cosCacheX42 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY8 +
                        coeffs42 * cosCacheX42 * cosCacheY16 +
                        coeffs43 * cosCacheX42 * cosCacheY24 +
                        coeffs44 * cosCacheX42 * cosCacheY32 +
                        coeffs45 * cosCacheX42 * cosCacheY40 +
                        coeffs46 * cosCacheX42 * cosCacheY48 +
                        coeffs47 * cosCacheX42 * cosCacheY56 +
                        coeffs48 * cosCacheX50 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY8 +
                        coeffs50 * cosCacheX50 * cosCacheY16 +
                        coeffs51 * cosCacheX50 * cosCacheY24 +
                        coeffs52 * cosCacheX50 * cosCacheY32 +
                        coeffs53 * cosCacheX50 * cosCacheY40 +
                        coeffs54 * cosCacheX50 * cosCacheY48 +
                        coeffs55 * cosCacheX50 * cosCacheY56 +
                        coeffs56 * cosCacheX58 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY8 +
                        coeffs58 * cosCacheX58 * cosCacheY16 +
                        coeffs59 * cosCacheX58 * cosCacheY24 +
                        coeffs60 * cosCacheX58 * cosCacheY32 +
                        coeffs61 * cosCacheX58 * cosCacheY40 +
                        coeffs62 * cosCacheX58 * cosCacheY48 +
                        coeffs63 * cosCacheX58 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 1] = (coeffs0 * cosCacheX2 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY9 +
                        coeffs10 * cosCacheX10 * cosCacheY17 +
                        coeffs11 * cosCacheX10 * cosCacheY25 +
                        coeffs12 * cosCacheX10 * cosCacheY33 +
                        coeffs13 * cosCacheX10 * cosCacheY41 +
                        coeffs14 * cosCacheX10 * cosCacheY49 +
                        coeffs15 * cosCacheX10 * cosCacheY57 +
                        coeffs16 * cosCacheX18 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY9 +
                        coeffs18 * cosCacheX18 * cosCacheY17 +
                        coeffs19 * cosCacheX18 * cosCacheY25 +
                        coeffs20 * cosCacheX18 * cosCacheY33 +
                        coeffs21 * cosCacheX18 * cosCacheY41 +
                        coeffs22 * cosCacheX18 * cosCacheY49 +
                        coeffs23 * cosCacheX18 * cosCacheY57 +
                        coeffs24 * cosCacheX26 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY9 +
                        coeffs26 * cosCacheX26 * cosCacheY17 +
                        coeffs27 * cosCacheX26 * cosCacheY25 +
                        coeffs28 * cosCacheX26 * cosCacheY33 +
                        coeffs29 * cosCacheX26 * cosCacheY41 +
                        coeffs30 * cosCacheX26 * cosCacheY49 +
                        coeffs31 * cosCacheX26 * cosCacheY57 +
                        coeffs32 * cosCacheX34 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY9 +
                        coeffs34 * cosCacheX34 * cosCacheY17 +
                        coeffs35 * cosCacheX34 * cosCacheY25 +
                        coeffs36 * cosCacheX34 * cosCacheY33 +
                        coeffs37 * cosCacheX34 * cosCacheY41 +
                        coeffs38 * cosCacheX34 * cosCacheY49 +
                        coeffs39 * cosCacheX34 * cosCacheY57 +
                        coeffs40 * cosCacheX42 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY9 +
                        coeffs42 * cosCacheX42 * cosCacheY17 +
                        coeffs43 * cosCacheX42 * cosCacheY25 +
                        coeffs44 * cosCacheX42 * cosCacheY33 +
                        coeffs45 * cosCacheX42 * cosCacheY41 +
                        coeffs46 * cosCacheX42 * cosCacheY49 +
                        coeffs47 * cosCacheX42 * cosCacheY57 +
                        coeffs48 * cosCacheX50 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY9 +
                        coeffs50 * cosCacheX50 * cosCacheY17 +
                        coeffs51 * cosCacheX50 * cosCacheY25 +
                        coeffs52 * cosCacheX50 * cosCacheY33 +
                        coeffs53 * cosCacheX50 * cosCacheY41 +
                        coeffs54 * cosCacheX50 * cosCacheY49 +
                        coeffs55 * cosCacheX50 * cosCacheY57 +
                        coeffs56 * cosCacheX58 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY9 +
                        coeffs58 * cosCacheX58 * cosCacheY17 +
                        coeffs59 * cosCacheX58 * cosCacheY25 +
                        coeffs60 * cosCacheX58 * cosCacheY33 +
                        coeffs61 * cosCacheX58 * cosCacheY41 +
                        coeffs62 * cosCacheX58 * cosCacheY49 +
                        coeffs63 * cosCacheX58 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 2] = (coeffs0 * cosCacheX2 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY10 +
                        coeffs10 * cosCacheX10 * cosCacheY18 +
                        coeffs11 * cosCacheX10 * cosCacheY26 +
                        coeffs12 * cosCacheX10 * cosCacheY34 +
                        coeffs13 * cosCacheX10 * cosCacheY42 +
                        coeffs14 * cosCacheX10 * cosCacheY50 +
                        coeffs15 * cosCacheX10 * cosCacheY58 +
                        coeffs16 * cosCacheX18 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY10 +
                        coeffs18 * cosCacheX18 * cosCacheY18 +
                        coeffs19 * cosCacheX18 * cosCacheY26 +
                        coeffs20 * cosCacheX18 * cosCacheY34 +
                        coeffs21 * cosCacheX18 * cosCacheY42 +
                        coeffs22 * cosCacheX18 * cosCacheY50 +
                        coeffs23 * cosCacheX18 * cosCacheY58 +
                        coeffs24 * cosCacheX26 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY10 +
                        coeffs26 * cosCacheX26 * cosCacheY18 +
                        coeffs27 * cosCacheX26 * cosCacheY26 +
                        coeffs28 * cosCacheX26 * cosCacheY34 +
                        coeffs29 * cosCacheX26 * cosCacheY42 +
                        coeffs30 * cosCacheX26 * cosCacheY50 +
                        coeffs31 * cosCacheX26 * cosCacheY58 +
                        coeffs32 * cosCacheX34 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY10 +
                        coeffs34 * cosCacheX34 * cosCacheY18 +
                        coeffs35 * cosCacheX34 * cosCacheY26 +
                        coeffs36 * cosCacheX34 * cosCacheY34 +
                        coeffs37 * cosCacheX34 * cosCacheY42 +
                        coeffs38 * cosCacheX34 * cosCacheY50 +
                        coeffs39 * cosCacheX34 * cosCacheY58 +
                        coeffs40 * cosCacheX42 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY10 +
                        coeffs42 * cosCacheX42 * cosCacheY18 +
                        coeffs43 * cosCacheX42 * cosCacheY26 +
                        coeffs44 * cosCacheX42 * cosCacheY34 +
                        coeffs45 * cosCacheX42 * cosCacheY42 +
                        coeffs46 * cosCacheX42 * cosCacheY50 +
                        coeffs47 * cosCacheX42 * cosCacheY58 +
                        coeffs48 * cosCacheX50 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY10 +
                        coeffs50 * cosCacheX50 * cosCacheY18 +
                        coeffs51 * cosCacheX50 * cosCacheY26 +
                        coeffs52 * cosCacheX50 * cosCacheY34 +
                        coeffs53 * cosCacheX50 * cosCacheY42 +
                        coeffs54 * cosCacheX50 * cosCacheY50 +
                        coeffs55 * cosCacheX50 * cosCacheY58 +
                        coeffs56 * cosCacheX58 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY10 +
                        coeffs58 * cosCacheX58 * cosCacheY18 +
                        coeffs59 * cosCacheX58 * cosCacheY26 +
                        coeffs60 * cosCacheX58 * cosCacheY34 +
                        coeffs61 * cosCacheX58 * cosCacheY42 +
                        coeffs62 * cosCacheX58 * cosCacheY50 +
                        coeffs63 * cosCacheX58 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 3] = (coeffs0 * cosCacheX2 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY11 +
                        coeffs10 * cosCacheX10 * cosCacheY19 +
                        coeffs11 * cosCacheX10 * cosCacheY27 +
                        coeffs12 * cosCacheX10 * cosCacheY35 +
                        coeffs13 * cosCacheX10 * cosCacheY43 +
                        coeffs14 * cosCacheX10 * cosCacheY51 +
                        coeffs15 * cosCacheX10 * cosCacheY59 +
                        coeffs16 * cosCacheX18 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY11 +
                        coeffs18 * cosCacheX18 * cosCacheY19 +
                        coeffs19 * cosCacheX18 * cosCacheY27 +
                        coeffs20 * cosCacheX18 * cosCacheY35 +
                        coeffs21 * cosCacheX18 * cosCacheY43 +
                        coeffs22 * cosCacheX18 * cosCacheY51 +
                        coeffs23 * cosCacheX18 * cosCacheY59 +
                        coeffs24 * cosCacheX26 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY11 +
                        coeffs26 * cosCacheX26 * cosCacheY19 +
                        coeffs27 * cosCacheX26 * cosCacheY27 +
                        coeffs28 * cosCacheX26 * cosCacheY35 +
                        coeffs29 * cosCacheX26 * cosCacheY43 +
                        coeffs30 * cosCacheX26 * cosCacheY51 +
                        coeffs31 * cosCacheX26 * cosCacheY59 +
                        coeffs32 * cosCacheX34 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY11 +
                        coeffs34 * cosCacheX34 * cosCacheY19 +
                        coeffs35 * cosCacheX34 * cosCacheY27 +
                        coeffs36 * cosCacheX34 * cosCacheY35 +
                        coeffs37 * cosCacheX34 * cosCacheY43 +
                        coeffs38 * cosCacheX34 * cosCacheY51 +
                        coeffs39 * cosCacheX34 * cosCacheY59 +
                        coeffs40 * cosCacheX42 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY11 +
                        coeffs42 * cosCacheX42 * cosCacheY19 +
                        coeffs43 * cosCacheX42 * cosCacheY27 +
                        coeffs44 * cosCacheX42 * cosCacheY35 +
                        coeffs45 * cosCacheX42 * cosCacheY43 +
                        coeffs46 * cosCacheX42 * cosCacheY51 +
                        coeffs47 * cosCacheX42 * cosCacheY59 +
                        coeffs48 * cosCacheX50 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY11 +
                        coeffs50 * cosCacheX50 * cosCacheY19 +
                        coeffs51 * cosCacheX50 * cosCacheY27 +
                        coeffs52 * cosCacheX50 * cosCacheY35 +
                        coeffs53 * cosCacheX50 * cosCacheY43 +
                        coeffs54 * cosCacheX50 * cosCacheY51 +
                        coeffs55 * cosCacheX50 * cosCacheY59 +
                        coeffs56 * cosCacheX58 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY11 +
                        coeffs58 * cosCacheX58 * cosCacheY19 +
                        coeffs59 * cosCacheX58 * cosCacheY27 +
                        coeffs60 * cosCacheX58 * cosCacheY35 +
                        coeffs61 * cosCacheX58 * cosCacheY43 +
                        coeffs62 * cosCacheX58 * cosCacheY51 +
                        coeffs63 * cosCacheX58 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 4] = (coeffs0 * cosCacheX2 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY12 +
                        coeffs10 * cosCacheX10 * cosCacheY20 +
                        coeffs11 * cosCacheX10 * cosCacheY28 +
                        coeffs12 * cosCacheX10 * cosCacheY36 +
                        coeffs13 * cosCacheX10 * cosCacheY44 +
                        coeffs14 * cosCacheX10 * cosCacheY52 +
                        coeffs15 * cosCacheX10 * cosCacheY60 +
                        coeffs16 * cosCacheX18 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY12 +
                        coeffs18 * cosCacheX18 * cosCacheY20 +
                        coeffs19 * cosCacheX18 * cosCacheY28 +
                        coeffs20 * cosCacheX18 * cosCacheY36 +
                        coeffs21 * cosCacheX18 * cosCacheY44 +
                        coeffs22 * cosCacheX18 * cosCacheY52 +
                        coeffs23 * cosCacheX18 * cosCacheY60 +
                        coeffs24 * cosCacheX26 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY12 +
                        coeffs26 * cosCacheX26 * cosCacheY20 +
                        coeffs27 * cosCacheX26 * cosCacheY28 +
                        coeffs28 * cosCacheX26 * cosCacheY36 +
                        coeffs29 * cosCacheX26 * cosCacheY44 +
                        coeffs30 * cosCacheX26 * cosCacheY52 +
                        coeffs31 * cosCacheX26 * cosCacheY60 +
                        coeffs32 * cosCacheX34 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY12 +
                        coeffs34 * cosCacheX34 * cosCacheY20 +
                        coeffs35 * cosCacheX34 * cosCacheY28 +
                        coeffs36 * cosCacheX34 * cosCacheY36 +
                        coeffs37 * cosCacheX34 * cosCacheY44 +
                        coeffs38 * cosCacheX34 * cosCacheY52 +
                        coeffs39 * cosCacheX34 * cosCacheY60 +
                        coeffs40 * cosCacheX42 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY12 +
                        coeffs42 * cosCacheX42 * cosCacheY20 +
                        coeffs43 * cosCacheX42 * cosCacheY28 +
                        coeffs44 * cosCacheX42 * cosCacheY36 +
                        coeffs45 * cosCacheX42 * cosCacheY44 +
                        coeffs46 * cosCacheX42 * cosCacheY52 +
                        coeffs47 * cosCacheX42 * cosCacheY60 +
                        coeffs48 * cosCacheX50 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY12 +
                        coeffs50 * cosCacheX50 * cosCacheY20 +
                        coeffs51 * cosCacheX50 * cosCacheY28 +
                        coeffs52 * cosCacheX50 * cosCacheY36 +
                        coeffs53 * cosCacheX50 * cosCacheY44 +
                        coeffs54 * cosCacheX50 * cosCacheY52 +
                        coeffs55 * cosCacheX50 * cosCacheY60 +
                        coeffs56 * cosCacheX58 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY12 +
                        coeffs58 * cosCacheX58 * cosCacheY20 +
                        coeffs59 * cosCacheX58 * cosCacheY28 +
                        coeffs60 * cosCacheX58 * cosCacheY36 +
                        coeffs61 * cosCacheX58 * cosCacheY44 +
                        coeffs62 * cosCacheX58 * cosCacheY52 +
                        coeffs63 * cosCacheX58 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 5] = (coeffs0 * cosCacheX2 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY13 +
                        coeffs10 * cosCacheX10 * cosCacheY21 +
                        coeffs11 * cosCacheX10 * cosCacheY29 +
                        coeffs12 * cosCacheX10 * cosCacheY37 +
                        coeffs13 * cosCacheX10 * cosCacheY45 +
                        coeffs14 * cosCacheX10 * cosCacheY53 +
                        coeffs15 * cosCacheX10 * cosCacheY61 +
                        coeffs16 * cosCacheX18 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY13 +
                        coeffs18 * cosCacheX18 * cosCacheY21 +
                        coeffs19 * cosCacheX18 * cosCacheY29 +
                        coeffs20 * cosCacheX18 * cosCacheY37 +
                        coeffs21 * cosCacheX18 * cosCacheY45 +
                        coeffs22 * cosCacheX18 * cosCacheY53 +
                        coeffs23 * cosCacheX18 * cosCacheY61 +
                        coeffs24 * cosCacheX26 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY13 +
                        coeffs26 * cosCacheX26 * cosCacheY21 +
                        coeffs27 * cosCacheX26 * cosCacheY29 +
                        coeffs28 * cosCacheX26 * cosCacheY37 +
                        coeffs29 * cosCacheX26 * cosCacheY45 +
                        coeffs30 * cosCacheX26 * cosCacheY53 +
                        coeffs31 * cosCacheX26 * cosCacheY61 +
                        coeffs32 * cosCacheX34 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY13 +
                        coeffs34 * cosCacheX34 * cosCacheY21 +
                        coeffs35 * cosCacheX34 * cosCacheY29 +
                        coeffs36 * cosCacheX34 * cosCacheY37 +
                        coeffs37 * cosCacheX34 * cosCacheY45 +
                        coeffs38 * cosCacheX34 * cosCacheY53 +
                        coeffs39 * cosCacheX34 * cosCacheY61 +
                        coeffs40 * cosCacheX42 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY13 +
                        coeffs42 * cosCacheX42 * cosCacheY21 +
                        coeffs43 * cosCacheX42 * cosCacheY29 +
                        coeffs44 * cosCacheX42 * cosCacheY37 +
                        coeffs45 * cosCacheX42 * cosCacheY45 +
                        coeffs46 * cosCacheX42 * cosCacheY53 +
                        coeffs47 * cosCacheX42 * cosCacheY61 +
                        coeffs48 * cosCacheX50 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY13 +
                        coeffs50 * cosCacheX50 * cosCacheY21 +
                        coeffs51 * cosCacheX50 * cosCacheY29 +
                        coeffs52 * cosCacheX50 * cosCacheY37 +
                        coeffs53 * cosCacheX50 * cosCacheY45 +
                        coeffs54 * cosCacheX50 * cosCacheY53 +
                        coeffs55 * cosCacheX50 * cosCacheY61 +
                        coeffs56 * cosCacheX58 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY13 +
                        coeffs58 * cosCacheX58 * cosCacheY21 +
                        coeffs59 * cosCacheX58 * cosCacheY29 +
                        coeffs60 * cosCacheX58 * cosCacheY37 +
                        coeffs61 * cosCacheX58 * cosCacheY45 +
                        coeffs62 * cosCacheX58 * cosCacheY53 +
                        coeffs63 * cosCacheX58 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 6] = (coeffs0 * cosCacheX2 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY14 +
                        coeffs10 * cosCacheX10 * cosCacheY22 +
                        coeffs11 * cosCacheX10 * cosCacheY30 +
                        coeffs12 * cosCacheX10 * cosCacheY38 +
                        coeffs13 * cosCacheX10 * cosCacheY46 +
                        coeffs14 * cosCacheX10 * cosCacheY54 +
                        coeffs15 * cosCacheX10 * cosCacheY62 +
                        coeffs16 * cosCacheX18 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY14 +
                        coeffs18 * cosCacheX18 * cosCacheY22 +
                        coeffs19 * cosCacheX18 * cosCacheY30 +
                        coeffs20 * cosCacheX18 * cosCacheY38 +
                        coeffs21 * cosCacheX18 * cosCacheY46 +
                        coeffs22 * cosCacheX18 * cosCacheY54 +
                        coeffs23 * cosCacheX18 * cosCacheY62 +
                        coeffs24 * cosCacheX26 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY14 +
                        coeffs26 * cosCacheX26 * cosCacheY22 +
                        coeffs27 * cosCacheX26 * cosCacheY30 +
                        coeffs28 * cosCacheX26 * cosCacheY38 +
                        coeffs29 * cosCacheX26 * cosCacheY46 +
                        coeffs30 * cosCacheX26 * cosCacheY54 +
                        coeffs31 * cosCacheX26 * cosCacheY62 +
                        coeffs32 * cosCacheX34 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY14 +
                        coeffs34 * cosCacheX34 * cosCacheY22 +
                        coeffs35 * cosCacheX34 * cosCacheY30 +
                        coeffs36 * cosCacheX34 * cosCacheY38 +
                        coeffs37 * cosCacheX34 * cosCacheY46 +
                        coeffs38 * cosCacheX34 * cosCacheY54 +
                        coeffs39 * cosCacheX34 * cosCacheY62 +
                        coeffs40 * cosCacheX42 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY14 +
                        coeffs42 * cosCacheX42 * cosCacheY22 +
                        coeffs43 * cosCacheX42 * cosCacheY30 +
                        coeffs44 * cosCacheX42 * cosCacheY38 +
                        coeffs45 * cosCacheX42 * cosCacheY46 +
                        coeffs46 * cosCacheX42 * cosCacheY54 +
                        coeffs47 * cosCacheX42 * cosCacheY62 +
                        coeffs48 * cosCacheX50 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY14 +
                        coeffs50 * cosCacheX50 * cosCacheY22 +
                        coeffs51 * cosCacheX50 * cosCacheY30 +
                        coeffs52 * cosCacheX50 * cosCacheY38 +
                        coeffs53 * cosCacheX50 * cosCacheY46 +
                        coeffs54 * cosCacheX50 * cosCacheY54 +
                        coeffs55 * cosCacheX50 * cosCacheY62 +
                        coeffs56 * cosCacheX58 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY14 +
                        coeffs58 * cosCacheX58 * cosCacheY22 +
                        coeffs59 * cosCacheX58 * cosCacheY30 +
                        coeffs60 * cosCacheX58 * cosCacheY38 +
                        coeffs61 * cosCacheX58 * cosCacheY46 +
                        coeffs62 * cosCacheX58 * cosCacheY54 +
                        coeffs63 * cosCacheX58 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 7] = (coeffs0 * cosCacheX2 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX2 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX2 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX2 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX2 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX2 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX2 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX2 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX10 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX10 * cosCacheY15 +
                        coeffs10 * cosCacheX10 * cosCacheY23 +
                        coeffs11 * cosCacheX10 * cosCacheY31 +
                        coeffs12 * cosCacheX10 * cosCacheY39 +
                        coeffs13 * cosCacheX10 * cosCacheY47 +
                        coeffs14 * cosCacheX10 * cosCacheY55 +
                        coeffs15 * cosCacheX10 * cosCacheY63 +
                        coeffs16 * cosCacheX18 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX18 * cosCacheY15 +
                        coeffs18 * cosCacheX18 * cosCacheY23 +
                        coeffs19 * cosCacheX18 * cosCacheY31 +
                        coeffs20 * cosCacheX18 * cosCacheY39 +
                        coeffs21 * cosCacheX18 * cosCacheY47 +
                        coeffs22 * cosCacheX18 * cosCacheY55 +
                        coeffs23 * cosCacheX18 * cosCacheY63 +
                        coeffs24 * cosCacheX26 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX26 * cosCacheY15 +
                        coeffs26 * cosCacheX26 * cosCacheY23 +
                        coeffs27 * cosCacheX26 * cosCacheY31 +
                        coeffs28 * cosCacheX26 * cosCacheY39 +
                        coeffs29 * cosCacheX26 * cosCacheY47 +
                        coeffs30 * cosCacheX26 * cosCacheY55 +
                        coeffs31 * cosCacheX26 * cosCacheY63 +
                        coeffs32 * cosCacheX34 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX34 * cosCacheY15 +
                        coeffs34 * cosCacheX34 * cosCacheY23 +
                        coeffs35 * cosCacheX34 * cosCacheY31 +
                        coeffs36 * cosCacheX34 * cosCacheY39 +
                        coeffs37 * cosCacheX34 * cosCacheY47 +
                        coeffs38 * cosCacheX34 * cosCacheY55 +
                        coeffs39 * cosCacheX34 * cosCacheY63 +
                        coeffs40 * cosCacheX42 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX42 * cosCacheY15 +
                        coeffs42 * cosCacheX42 * cosCacheY23 +
                        coeffs43 * cosCacheX42 * cosCacheY31 +
                        coeffs44 * cosCacheX42 * cosCacheY39 +
                        coeffs45 * cosCacheX42 * cosCacheY47 +
                        coeffs46 * cosCacheX42 * cosCacheY55 +
                        coeffs47 * cosCacheX42 * cosCacheY63 +
                        coeffs48 * cosCacheX50 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX50 * cosCacheY15 +
                        coeffs50 * cosCacheX50 * cosCacheY23 +
                        coeffs51 * cosCacheX50 * cosCacheY31 +
                        coeffs52 * cosCacheX50 * cosCacheY39 +
                        coeffs53 * cosCacheX50 * cosCacheY47 +
                        coeffs54 * cosCacheX50 * cosCacheY55 +
                        coeffs55 * cosCacheX50 * cosCacheY63 +
                        coeffs56 * cosCacheX58 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX58 * cosCacheY15 +
                        coeffs58 * cosCacheX58 * cosCacheY23 +
                        coeffs59 * cosCacheX58 * cosCacheY31 +
                        coeffs60 * cosCacheX58 * cosCacheY39 +
                        coeffs61 * cosCacheX58 * cosCacheY47 +
                        coeffs62 * cosCacheX58 * cosCacheY55 +
                        coeffs63 * cosCacheX58 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 0] = (coeffs0 * cosCacheX3 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY8 +
                        coeffs10 * cosCacheX11 * cosCacheY16 +
                        coeffs11 * cosCacheX11 * cosCacheY24 +
                        coeffs12 * cosCacheX11 * cosCacheY32 +
                        coeffs13 * cosCacheX11 * cosCacheY40 +
                        coeffs14 * cosCacheX11 * cosCacheY48 +
                        coeffs15 * cosCacheX11 * cosCacheY56 +
                        coeffs16 * cosCacheX19 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY8 +
                        coeffs18 * cosCacheX19 * cosCacheY16 +
                        coeffs19 * cosCacheX19 * cosCacheY24 +
                        coeffs20 * cosCacheX19 * cosCacheY32 +
                        coeffs21 * cosCacheX19 * cosCacheY40 +
                        coeffs22 * cosCacheX19 * cosCacheY48 +
                        coeffs23 * cosCacheX19 * cosCacheY56 +
                        coeffs24 * cosCacheX27 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY8 +
                        coeffs26 * cosCacheX27 * cosCacheY16 +
                        coeffs27 * cosCacheX27 * cosCacheY24 +
                        coeffs28 * cosCacheX27 * cosCacheY32 +
                        coeffs29 * cosCacheX27 * cosCacheY40 +
                        coeffs30 * cosCacheX27 * cosCacheY48 +
                        coeffs31 * cosCacheX27 * cosCacheY56 +
                        coeffs32 * cosCacheX35 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY8 +
                        coeffs34 * cosCacheX35 * cosCacheY16 +
                        coeffs35 * cosCacheX35 * cosCacheY24 +
                        coeffs36 * cosCacheX35 * cosCacheY32 +
                        coeffs37 * cosCacheX35 * cosCacheY40 +
                        coeffs38 * cosCacheX35 * cosCacheY48 +
                        coeffs39 * cosCacheX35 * cosCacheY56 +
                        coeffs40 * cosCacheX43 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY8 +
                        coeffs42 * cosCacheX43 * cosCacheY16 +
                        coeffs43 * cosCacheX43 * cosCacheY24 +
                        coeffs44 * cosCacheX43 * cosCacheY32 +
                        coeffs45 * cosCacheX43 * cosCacheY40 +
                        coeffs46 * cosCacheX43 * cosCacheY48 +
                        coeffs47 * cosCacheX43 * cosCacheY56 +
                        coeffs48 * cosCacheX51 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY8 +
                        coeffs50 * cosCacheX51 * cosCacheY16 +
                        coeffs51 * cosCacheX51 * cosCacheY24 +
                        coeffs52 * cosCacheX51 * cosCacheY32 +
                        coeffs53 * cosCacheX51 * cosCacheY40 +
                        coeffs54 * cosCacheX51 * cosCacheY48 +
                        coeffs55 * cosCacheX51 * cosCacheY56 +
                        coeffs56 * cosCacheX59 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY8 +
                        coeffs58 * cosCacheX59 * cosCacheY16 +
                        coeffs59 * cosCacheX59 * cosCacheY24 +
                        coeffs60 * cosCacheX59 * cosCacheY32 +
                        coeffs61 * cosCacheX59 * cosCacheY40 +
                        coeffs62 * cosCacheX59 * cosCacheY48 +
                        coeffs63 * cosCacheX59 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 1] = (coeffs0 * cosCacheX3 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY9 +
                        coeffs10 * cosCacheX11 * cosCacheY17 +
                        coeffs11 * cosCacheX11 * cosCacheY25 +
                        coeffs12 * cosCacheX11 * cosCacheY33 +
                        coeffs13 * cosCacheX11 * cosCacheY41 +
                        coeffs14 * cosCacheX11 * cosCacheY49 +
                        coeffs15 * cosCacheX11 * cosCacheY57 +
                        coeffs16 * cosCacheX19 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY9 +
                        coeffs18 * cosCacheX19 * cosCacheY17 +
                        coeffs19 * cosCacheX19 * cosCacheY25 +
                        coeffs20 * cosCacheX19 * cosCacheY33 +
                        coeffs21 * cosCacheX19 * cosCacheY41 +
                        coeffs22 * cosCacheX19 * cosCacheY49 +
                        coeffs23 * cosCacheX19 * cosCacheY57 +
                        coeffs24 * cosCacheX27 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY9 +
                        coeffs26 * cosCacheX27 * cosCacheY17 +
                        coeffs27 * cosCacheX27 * cosCacheY25 +
                        coeffs28 * cosCacheX27 * cosCacheY33 +
                        coeffs29 * cosCacheX27 * cosCacheY41 +
                        coeffs30 * cosCacheX27 * cosCacheY49 +
                        coeffs31 * cosCacheX27 * cosCacheY57 +
                        coeffs32 * cosCacheX35 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY9 +
                        coeffs34 * cosCacheX35 * cosCacheY17 +
                        coeffs35 * cosCacheX35 * cosCacheY25 +
                        coeffs36 * cosCacheX35 * cosCacheY33 +
                        coeffs37 * cosCacheX35 * cosCacheY41 +
                        coeffs38 * cosCacheX35 * cosCacheY49 +
                        coeffs39 * cosCacheX35 * cosCacheY57 +
                        coeffs40 * cosCacheX43 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY9 +
                        coeffs42 * cosCacheX43 * cosCacheY17 +
                        coeffs43 * cosCacheX43 * cosCacheY25 +
                        coeffs44 * cosCacheX43 * cosCacheY33 +
                        coeffs45 * cosCacheX43 * cosCacheY41 +
                        coeffs46 * cosCacheX43 * cosCacheY49 +
                        coeffs47 * cosCacheX43 * cosCacheY57 +
                        coeffs48 * cosCacheX51 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY9 +
                        coeffs50 * cosCacheX51 * cosCacheY17 +
                        coeffs51 * cosCacheX51 * cosCacheY25 +
                        coeffs52 * cosCacheX51 * cosCacheY33 +
                        coeffs53 * cosCacheX51 * cosCacheY41 +
                        coeffs54 * cosCacheX51 * cosCacheY49 +
                        coeffs55 * cosCacheX51 * cosCacheY57 +
                        coeffs56 * cosCacheX59 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY9 +
                        coeffs58 * cosCacheX59 * cosCacheY17 +
                        coeffs59 * cosCacheX59 * cosCacheY25 +
                        coeffs60 * cosCacheX59 * cosCacheY33 +
                        coeffs61 * cosCacheX59 * cosCacheY41 +
                        coeffs62 * cosCacheX59 * cosCacheY49 +
                        coeffs63 * cosCacheX59 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 2] = (coeffs0 * cosCacheX3 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY10 +
                        coeffs10 * cosCacheX11 * cosCacheY18 +
                        coeffs11 * cosCacheX11 * cosCacheY26 +
                        coeffs12 * cosCacheX11 * cosCacheY34 +
                        coeffs13 * cosCacheX11 * cosCacheY42 +
                        coeffs14 * cosCacheX11 * cosCacheY50 +
                        coeffs15 * cosCacheX11 * cosCacheY58 +
                        coeffs16 * cosCacheX19 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY10 +
                        coeffs18 * cosCacheX19 * cosCacheY18 +
                        coeffs19 * cosCacheX19 * cosCacheY26 +
                        coeffs20 * cosCacheX19 * cosCacheY34 +
                        coeffs21 * cosCacheX19 * cosCacheY42 +
                        coeffs22 * cosCacheX19 * cosCacheY50 +
                        coeffs23 * cosCacheX19 * cosCacheY58 +
                        coeffs24 * cosCacheX27 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY10 +
                        coeffs26 * cosCacheX27 * cosCacheY18 +
                        coeffs27 * cosCacheX27 * cosCacheY26 +
                        coeffs28 * cosCacheX27 * cosCacheY34 +
                        coeffs29 * cosCacheX27 * cosCacheY42 +
                        coeffs30 * cosCacheX27 * cosCacheY50 +
                        coeffs31 * cosCacheX27 * cosCacheY58 +
                        coeffs32 * cosCacheX35 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY10 +
                        coeffs34 * cosCacheX35 * cosCacheY18 +
                        coeffs35 * cosCacheX35 * cosCacheY26 +
                        coeffs36 * cosCacheX35 * cosCacheY34 +
                        coeffs37 * cosCacheX35 * cosCacheY42 +
                        coeffs38 * cosCacheX35 * cosCacheY50 +
                        coeffs39 * cosCacheX35 * cosCacheY58 +
                        coeffs40 * cosCacheX43 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY10 +
                        coeffs42 * cosCacheX43 * cosCacheY18 +
                        coeffs43 * cosCacheX43 * cosCacheY26 +
                        coeffs44 * cosCacheX43 * cosCacheY34 +
                        coeffs45 * cosCacheX43 * cosCacheY42 +
                        coeffs46 * cosCacheX43 * cosCacheY50 +
                        coeffs47 * cosCacheX43 * cosCacheY58 +
                        coeffs48 * cosCacheX51 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY10 +
                        coeffs50 * cosCacheX51 * cosCacheY18 +
                        coeffs51 * cosCacheX51 * cosCacheY26 +
                        coeffs52 * cosCacheX51 * cosCacheY34 +
                        coeffs53 * cosCacheX51 * cosCacheY42 +
                        coeffs54 * cosCacheX51 * cosCacheY50 +
                        coeffs55 * cosCacheX51 * cosCacheY58 +
                        coeffs56 * cosCacheX59 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY10 +
                        coeffs58 * cosCacheX59 * cosCacheY18 +
                        coeffs59 * cosCacheX59 * cosCacheY26 +
                        coeffs60 * cosCacheX59 * cosCacheY34 +
                        coeffs61 * cosCacheX59 * cosCacheY42 +
                        coeffs62 * cosCacheX59 * cosCacheY50 +
                        coeffs63 * cosCacheX59 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 3] = (coeffs0 * cosCacheX3 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY11 +
                        coeffs10 * cosCacheX11 * cosCacheY19 +
                        coeffs11 * cosCacheX11 * cosCacheY27 +
                        coeffs12 * cosCacheX11 * cosCacheY35 +
                        coeffs13 * cosCacheX11 * cosCacheY43 +
                        coeffs14 * cosCacheX11 * cosCacheY51 +
                        coeffs15 * cosCacheX11 * cosCacheY59 +
                        coeffs16 * cosCacheX19 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY11 +
                        coeffs18 * cosCacheX19 * cosCacheY19 +
                        coeffs19 * cosCacheX19 * cosCacheY27 +
                        coeffs20 * cosCacheX19 * cosCacheY35 +
                        coeffs21 * cosCacheX19 * cosCacheY43 +
                        coeffs22 * cosCacheX19 * cosCacheY51 +
                        coeffs23 * cosCacheX19 * cosCacheY59 +
                        coeffs24 * cosCacheX27 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY11 +
                        coeffs26 * cosCacheX27 * cosCacheY19 +
                        coeffs27 * cosCacheX27 * cosCacheY27 +
                        coeffs28 * cosCacheX27 * cosCacheY35 +
                        coeffs29 * cosCacheX27 * cosCacheY43 +
                        coeffs30 * cosCacheX27 * cosCacheY51 +
                        coeffs31 * cosCacheX27 * cosCacheY59 +
                        coeffs32 * cosCacheX35 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY11 +
                        coeffs34 * cosCacheX35 * cosCacheY19 +
                        coeffs35 * cosCacheX35 * cosCacheY27 +
                        coeffs36 * cosCacheX35 * cosCacheY35 +
                        coeffs37 * cosCacheX35 * cosCacheY43 +
                        coeffs38 * cosCacheX35 * cosCacheY51 +
                        coeffs39 * cosCacheX35 * cosCacheY59 +
                        coeffs40 * cosCacheX43 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY11 +
                        coeffs42 * cosCacheX43 * cosCacheY19 +
                        coeffs43 * cosCacheX43 * cosCacheY27 +
                        coeffs44 * cosCacheX43 * cosCacheY35 +
                        coeffs45 * cosCacheX43 * cosCacheY43 +
                        coeffs46 * cosCacheX43 * cosCacheY51 +
                        coeffs47 * cosCacheX43 * cosCacheY59 +
                        coeffs48 * cosCacheX51 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY11 +
                        coeffs50 * cosCacheX51 * cosCacheY19 +
                        coeffs51 * cosCacheX51 * cosCacheY27 +
                        coeffs52 * cosCacheX51 * cosCacheY35 +
                        coeffs53 * cosCacheX51 * cosCacheY43 +
                        coeffs54 * cosCacheX51 * cosCacheY51 +
                        coeffs55 * cosCacheX51 * cosCacheY59 +
                        coeffs56 * cosCacheX59 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY11 +
                        coeffs58 * cosCacheX59 * cosCacheY19 +
                        coeffs59 * cosCacheX59 * cosCacheY27 +
                        coeffs60 * cosCacheX59 * cosCacheY35 +
                        coeffs61 * cosCacheX59 * cosCacheY43 +
                        coeffs62 * cosCacheX59 * cosCacheY51 +
                        coeffs63 * cosCacheX59 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 4] = (coeffs0 * cosCacheX3 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY12 +
                        coeffs10 * cosCacheX11 * cosCacheY20 +
                        coeffs11 * cosCacheX11 * cosCacheY28 +
                        coeffs12 * cosCacheX11 * cosCacheY36 +
                        coeffs13 * cosCacheX11 * cosCacheY44 +
                        coeffs14 * cosCacheX11 * cosCacheY52 +
                        coeffs15 * cosCacheX11 * cosCacheY60 +
                        coeffs16 * cosCacheX19 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY12 +
                        coeffs18 * cosCacheX19 * cosCacheY20 +
                        coeffs19 * cosCacheX19 * cosCacheY28 +
                        coeffs20 * cosCacheX19 * cosCacheY36 +
                        coeffs21 * cosCacheX19 * cosCacheY44 +
                        coeffs22 * cosCacheX19 * cosCacheY52 +
                        coeffs23 * cosCacheX19 * cosCacheY60 +
                        coeffs24 * cosCacheX27 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY12 +
                        coeffs26 * cosCacheX27 * cosCacheY20 +
                        coeffs27 * cosCacheX27 * cosCacheY28 +
                        coeffs28 * cosCacheX27 * cosCacheY36 +
                        coeffs29 * cosCacheX27 * cosCacheY44 +
                        coeffs30 * cosCacheX27 * cosCacheY52 +
                        coeffs31 * cosCacheX27 * cosCacheY60 +
                        coeffs32 * cosCacheX35 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY12 +
                        coeffs34 * cosCacheX35 * cosCacheY20 +
                        coeffs35 * cosCacheX35 * cosCacheY28 +
                        coeffs36 * cosCacheX35 * cosCacheY36 +
                        coeffs37 * cosCacheX35 * cosCacheY44 +
                        coeffs38 * cosCacheX35 * cosCacheY52 +
                        coeffs39 * cosCacheX35 * cosCacheY60 +
                        coeffs40 * cosCacheX43 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY12 +
                        coeffs42 * cosCacheX43 * cosCacheY20 +
                        coeffs43 * cosCacheX43 * cosCacheY28 +
                        coeffs44 * cosCacheX43 * cosCacheY36 +
                        coeffs45 * cosCacheX43 * cosCacheY44 +
                        coeffs46 * cosCacheX43 * cosCacheY52 +
                        coeffs47 * cosCacheX43 * cosCacheY60 +
                        coeffs48 * cosCacheX51 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY12 +
                        coeffs50 * cosCacheX51 * cosCacheY20 +
                        coeffs51 * cosCacheX51 * cosCacheY28 +
                        coeffs52 * cosCacheX51 * cosCacheY36 +
                        coeffs53 * cosCacheX51 * cosCacheY44 +
                        coeffs54 * cosCacheX51 * cosCacheY52 +
                        coeffs55 * cosCacheX51 * cosCacheY60 +
                        coeffs56 * cosCacheX59 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY12 +
                        coeffs58 * cosCacheX59 * cosCacheY20 +
                        coeffs59 * cosCacheX59 * cosCacheY28 +
                        coeffs60 * cosCacheX59 * cosCacheY36 +
                        coeffs61 * cosCacheX59 * cosCacheY44 +
                        coeffs62 * cosCacheX59 * cosCacheY52 +
                        coeffs63 * cosCacheX59 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 5] = (coeffs0 * cosCacheX3 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY13 +
                        coeffs10 * cosCacheX11 * cosCacheY21 +
                        coeffs11 * cosCacheX11 * cosCacheY29 +
                        coeffs12 * cosCacheX11 * cosCacheY37 +
                        coeffs13 * cosCacheX11 * cosCacheY45 +
                        coeffs14 * cosCacheX11 * cosCacheY53 +
                        coeffs15 * cosCacheX11 * cosCacheY61 +
                        coeffs16 * cosCacheX19 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY13 +
                        coeffs18 * cosCacheX19 * cosCacheY21 +
                        coeffs19 * cosCacheX19 * cosCacheY29 +
                        coeffs20 * cosCacheX19 * cosCacheY37 +
                        coeffs21 * cosCacheX19 * cosCacheY45 +
                        coeffs22 * cosCacheX19 * cosCacheY53 +
                        coeffs23 * cosCacheX19 * cosCacheY61 +
                        coeffs24 * cosCacheX27 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY13 +
                        coeffs26 * cosCacheX27 * cosCacheY21 +
                        coeffs27 * cosCacheX27 * cosCacheY29 +
                        coeffs28 * cosCacheX27 * cosCacheY37 +
                        coeffs29 * cosCacheX27 * cosCacheY45 +
                        coeffs30 * cosCacheX27 * cosCacheY53 +
                        coeffs31 * cosCacheX27 * cosCacheY61 +
                        coeffs32 * cosCacheX35 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY13 +
                        coeffs34 * cosCacheX35 * cosCacheY21 +
                        coeffs35 * cosCacheX35 * cosCacheY29 +
                        coeffs36 * cosCacheX35 * cosCacheY37 +
                        coeffs37 * cosCacheX35 * cosCacheY45 +
                        coeffs38 * cosCacheX35 * cosCacheY53 +
                        coeffs39 * cosCacheX35 * cosCacheY61 +
                        coeffs40 * cosCacheX43 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY13 +
                        coeffs42 * cosCacheX43 * cosCacheY21 +
                        coeffs43 * cosCacheX43 * cosCacheY29 +
                        coeffs44 * cosCacheX43 * cosCacheY37 +
                        coeffs45 * cosCacheX43 * cosCacheY45 +
                        coeffs46 * cosCacheX43 * cosCacheY53 +
                        coeffs47 * cosCacheX43 * cosCacheY61 +
                        coeffs48 * cosCacheX51 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY13 +
                        coeffs50 * cosCacheX51 * cosCacheY21 +
                        coeffs51 * cosCacheX51 * cosCacheY29 +
                        coeffs52 * cosCacheX51 * cosCacheY37 +
                        coeffs53 * cosCacheX51 * cosCacheY45 +
                        coeffs54 * cosCacheX51 * cosCacheY53 +
                        coeffs55 * cosCacheX51 * cosCacheY61 +
                        coeffs56 * cosCacheX59 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY13 +
                        coeffs58 * cosCacheX59 * cosCacheY21 +
                        coeffs59 * cosCacheX59 * cosCacheY29 +
                        coeffs60 * cosCacheX59 * cosCacheY37 +
                        coeffs61 * cosCacheX59 * cosCacheY45 +
                        coeffs62 * cosCacheX59 * cosCacheY53 +
                        coeffs63 * cosCacheX59 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 6] = (coeffs0 * cosCacheX3 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY14 +
                        coeffs10 * cosCacheX11 * cosCacheY22 +
                        coeffs11 * cosCacheX11 * cosCacheY30 +
                        coeffs12 * cosCacheX11 * cosCacheY38 +
                        coeffs13 * cosCacheX11 * cosCacheY46 +
                        coeffs14 * cosCacheX11 * cosCacheY54 +
                        coeffs15 * cosCacheX11 * cosCacheY62 +
                        coeffs16 * cosCacheX19 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY14 +
                        coeffs18 * cosCacheX19 * cosCacheY22 +
                        coeffs19 * cosCacheX19 * cosCacheY30 +
                        coeffs20 * cosCacheX19 * cosCacheY38 +
                        coeffs21 * cosCacheX19 * cosCacheY46 +
                        coeffs22 * cosCacheX19 * cosCacheY54 +
                        coeffs23 * cosCacheX19 * cosCacheY62 +
                        coeffs24 * cosCacheX27 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY14 +
                        coeffs26 * cosCacheX27 * cosCacheY22 +
                        coeffs27 * cosCacheX27 * cosCacheY30 +
                        coeffs28 * cosCacheX27 * cosCacheY38 +
                        coeffs29 * cosCacheX27 * cosCacheY46 +
                        coeffs30 * cosCacheX27 * cosCacheY54 +
                        coeffs31 * cosCacheX27 * cosCacheY62 +
                        coeffs32 * cosCacheX35 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY14 +
                        coeffs34 * cosCacheX35 * cosCacheY22 +
                        coeffs35 * cosCacheX35 * cosCacheY30 +
                        coeffs36 * cosCacheX35 * cosCacheY38 +
                        coeffs37 * cosCacheX35 * cosCacheY46 +
                        coeffs38 * cosCacheX35 * cosCacheY54 +
                        coeffs39 * cosCacheX35 * cosCacheY62 +
                        coeffs40 * cosCacheX43 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY14 +
                        coeffs42 * cosCacheX43 * cosCacheY22 +
                        coeffs43 * cosCacheX43 * cosCacheY30 +
                        coeffs44 * cosCacheX43 * cosCacheY38 +
                        coeffs45 * cosCacheX43 * cosCacheY46 +
                        coeffs46 * cosCacheX43 * cosCacheY54 +
                        coeffs47 * cosCacheX43 * cosCacheY62 +
                        coeffs48 * cosCacheX51 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY14 +
                        coeffs50 * cosCacheX51 * cosCacheY22 +
                        coeffs51 * cosCacheX51 * cosCacheY30 +
                        coeffs52 * cosCacheX51 * cosCacheY38 +
                        coeffs53 * cosCacheX51 * cosCacheY46 +
                        coeffs54 * cosCacheX51 * cosCacheY54 +
                        coeffs55 * cosCacheX51 * cosCacheY62 +
                        coeffs56 * cosCacheX59 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY14 +
                        coeffs58 * cosCacheX59 * cosCacheY22 +
                        coeffs59 * cosCacheX59 * cosCacheY30 +
                        coeffs60 * cosCacheX59 * cosCacheY38 +
                        coeffs61 * cosCacheX59 * cosCacheY46 +
                        coeffs62 * cosCacheX59 * cosCacheY54 +
                        coeffs63 * cosCacheX59 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 7] = (coeffs0 * cosCacheX3 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX3 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX3 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX3 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX3 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX3 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX3 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX3 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX11 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX11 * cosCacheY15 +
                        coeffs10 * cosCacheX11 * cosCacheY23 +
                        coeffs11 * cosCacheX11 * cosCacheY31 +
                        coeffs12 * cosCacheX11 * cosCacheY39 +
                        coeffs13 * cosCacheX11 * cosCacheY47 +
                        coeffs14 * cosCacheX11 * cosCacheY55 +
                        coeffs15 * cosCacheX11 * cosCacheY63 +
                        coeffs16 * cosCacheX19 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX19 * cosCacheY15 +
                        coeffs18 * cosCacheX19 * cosCacheY23 +
                        coeffs19 * cosCacheX19 * cosCacheY31 +
                        coeffs20 * cosCacheX19 * cosCacheY39 +
                        coeffs21 * cosCacheX19 * cosCacheY47 +
                        coeffs22 * cosCacheX19 * cosCacheY55 +
                        coeffs23 * cosCacheX19 * cosCacheY63 +
                        coeffs24 * cosCacheX27 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX27 * cosCacheY15 +
                        coeffs26 * cosCacheX27 * cosCacheY23 +
                        coeffs27 * cosCacheX27 * cosCacheY31 +
                        coeffs28 * cosCacheX27 * cosCacheY39 +
                        coeffs29 * cosCacheX27 * cosCacheY47 +
                        coeffs30 * cosCacheX27 * cosCacheY55 +
                        coeffs31 * cosCacheX27 * cosCacheY63 +
                        coeffs32 * cosCacheX35 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX35 * cosCacheY15 +
                        coeffs34 * cosCacheX35 * cosCacheY23 +
                        coeffs35 * cosCacheX35 * cosCacheY31 +
                        coeffs36 * cosCacheX35 * cosCacheY39 +
                        coeffs37 * cosCacheX35 * cosCacheY47 +
                        coeffs38 * cosCacheX35 * cosCacheY55 +
                        coeffs39 * cosCacheX35 * cosCacheY63 +
                        coeffs40 * cosCacheX43 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX43 * cosCacheY15 +
                        coeffs42 * cosCacheX43 * cosCacheY23 +
                        coeffs43 * cosCacheX43 * cosCacheY31 +
                        coeffs44 * cosCacheX43 * cosCacheY39 +
                        coeffs45 * cosCacheX43 * cosCacheY47 +
                        coeffs46 * cosCacheX43 * cosCacheY55 +
                        coeffs47 * cosCacheX43 * cosCacheY63 +
                        coeffs48 * cosCacheX51 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX51 * cosCacheY15 +
                        coeffs50 * cosCacheX51 * cosCacheY23 +
                        coeffs51 * cosCacheX51 * cosCacheY31 +
                        coeffs52 * cosCacheX51 * cosCacheY39 +
                        coeffs53 * cosCacheX51 * cosCacheY47 +
                        coeffs54 * cosCacheX51 * cosCacheY55 +
                        coeffs55 * cosCacheX51 * cosCacheY63 +
                        coeffs56 * cosCacheX59 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX59 * cosCacheY15 +
                        coeffs58 * cosCacheX59 * cosCacheY23 +
                        coeffs59 * cosCacheX59 * cosCacheY31 +
                        coeffs60 * cosCacheX59 * cosCacheY39 +
                        coeffs61 * cosCacheX59 * cosCacheY47 +
                        coeffs62 * cosCacheX59 * cosCacheY55 +
                        coeffs63 * cosCacheX59 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 0] = (coeffs0 * cosCacheX4 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY8 +
                        coeffs10 * cosCacheX12 * cosCacheY16 +
                        coeffs11 * cosCacheX12 * cosCacheY24 +
                        coeffs12 * cosCacheX12 * cosCacheY32 +
                        coeffs13 * cosCacheX12 * cosCacheY40 +
                        coeffs14 * cosCacheX12 * cosCacheY48 +
                        coeffs15 * cosCacheX12 * cosCacheY56 +
                        coeffs16 * cosCacheX20 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY8 +
                        coeffs18 * cosCacheX20 * cosCacheY16 +
                        coeffs19 * cosCacheX20 * cosCacheY24 +
                        coeffs20 * cosCacheX20 * cosCacheY32 +
                        coeffs21 * cosCacheX20 * cosCacheY40 +
                        coeffs22 * cosCacheX20 * cosCacheY48 +
                        coeffs23 * cosCacheX20 * cosCacheY56 +
                        coeffs24 * cosCacheX28 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY8 +
                        coeffs26 * cosCacheX28 * cosCacheY16 +
                        coeffs27 * cosCacheX28 * cosCacheY24 +
                        coeffs28 * cosCacheX28 * cosCacheY32 +
                        coeffs29 * cosCacheX28 * cosCacheY40 +
                        coeffs30 * cosCacheX28 * cosCacheY48 +
                        coeffs31 * cosCacheX28 * cosCacheY56 +
                        coeffs32 * cosCacheX36 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY8 +
                        coeffs34 * cosCacheX36 * cosCacheY16 +
                        coeffs35 * cosCacheX36 * cosCacheY24 +
                        coeffs36 * cosCacheX36 * cosCacheY32 +
                        coeffs37 * cosCacheX36 * cosCacheY40 +
                        coeffs38 * cosCacheX36 * cosCacheY48 +
                        coeffs39 * cosCacheX36 * cosCacheY56 +
                        coeffs40 * cosCacheX44 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY8 +
                        coeffs42 * cosCacheX44 * cosCacheY16 +
                        coeffs43 * cosCacheX44 * cosCacheY24 +
                        coeffs44 * cosCacheX44 * cosCacheY32 +
                        coeffs45 * cosCacheX44 * cosCacheY40 +
                        coeffs46 * cosCacheX44 * cosCacheY48 +
                        coeffs47 * cosCacheX44 * cosCacheY56 +
                        coeffs48 * cosCacheX52 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY8 +
                        coeffs50 * cosCacheX52 * cosCacheY16 +
                        coeffs51 * cosCacheX52 * cosCacheY24 +
                        coeffs52 * cosCacheX52 * cosCacheY32 +
                        coeffs53 * cosCacheX52 * cosCacheY40 +
                        coeffs54 * cosCacheX52 * cosCacheY48 +
                        coeffs55 * cosCacheX52 * cosCacheY56 +
                        coeffs56 * cosCacheX60 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY8 +
                        coeffs58 * cosCacheX60 * cosCacheY16 +
                        coeffs59 * cosCacheX60 * cosCacheY24 +
                        coeffs60 * cosCacheX60 * cosCacheY32 +
                        coeffs61 * cosCacheX60 * cosCacheY40 +
                        coeffs62 * cosCacheX60 * cosCacheY48 +
                        coeffs63 * cosCacheX60 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 1] = (coeffs0 * cosCacheX4 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY9 +
                        coeffs10 * cosCacheX12 * cosCacheY17 +
                        coeffs11 * cosCacheX12 * cosCacheY25 +
                        coeffs12 * cosCacheX12 * cosCacheY33 +
                        coeffs13 * cosCacheX12 * cosCacheY41 +
                        coeffs14 * cosCacheX12 * cosCacheY49 +
                        coeffs15 * cosCacheX12 * cosCacheY57 +
                        coeffs16 * cosCacheX20 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY9 +
                        coeffs18 * cosCacheX20 * cosCacheY17 +
                        coeffs19 * cosCacheX20 * cosCacheY25 +
                        coeffs20 * cosCacheX20 * cosCacheY33 +
                        coeffs21 * cosCacheX20 * cosCacheY41 +
                        coeffs22 * cosCacheX20 * cosCacheY49 +
                        coeffs23 * cosCacheX20 * cosCacheY57 +
                        coeffs24 * cosCacheX28 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY9 +
                        coeffs26 * cosCacheX28 * cosCacheY17 +
                        coeffs27 * cosCacheX28 * cosCacheY25 +
                        coeffs28 * cosCacheX28 * cosCacheY33 +
                        coeffs29 * cosCacheX28 * cosCacheY41 +
                        coeffs30 * cosCacheX28 * cosCacheY49 +
                        coeffs31 * cosCacheX28 * cosCacheY57 +
                        coeffs32 * cosCacheX36 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY9 +
                        coeffs34 * cosCacheX36 * cosCacheY17 +
                        coeffs35 * cosCacheX36 * cosCacheY25 +
                        coeffs36 * cosCacheX36 * cosCacheY33 +
                        coeffs37 * cosCacheX36 * cosCacheY41 +
                        coeffs38 * cosCacheX36 * cosCacheY49 +
                        coeffs39 * cosCacheX36 * cosCacheY57 +
                        coeffs40 * cosCacheX44 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY9 +
                        coeffs42 * cosCacheX44 * cosCacheY17 +
                        coeffs43 * cosCacheX44 * cosCacheY25 +
                        coeffs44 * cosCacheX44 * cosCacheY33 +
                        coeffs45 * cosCacheX44 * cosCacheY41 +
                        coeffs46 * cosCacheX44 * cosCacheY49 +
                        coeffs47 * cosCacheX44 * cosCacheY57 +
                        coeffs48 * cosCacheX52 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY9 +
                        coeffs50 * cosCacheX52 * cosCacheY17 +
                        coeffs51 * cosCacheX52 * cosCacheY25 +
                        coeffs52 * cosCacheX52 * cosCacheY33 +
                        coeffs53 * cosCacheX52 * cosCacheY41 +
                        coeffs54 * cosCacheX52 * cosCacheY49 +
                        coeffs55 * cosCacheX52 * cosCacheY57 +
                        coeffs56 * cosCacheX60 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY9 +
                        coeffs58 * cosCacheX60 * cosCacheY17 +
                        coeffs59 * cosCacheX60 * cosCacheY25 +
                        coeffs60 * cosCacheX60 * cosCacheY33 +
                        coeffs61 * cosCacheX60 * cosCacheY41 +
                        coeffs62 * cosCacheX60 * cosCacheY49 +
                        coeffs63 * cosCacheX60 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 2] = (coeffs0 * cosCacheX4 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY10 +
                        coeffs10 * cosCacheX12 * cosCacheY18 +
                        coeffs11 * cosCacheX12 * cosCacheY26 +
                        coeffs12 * cosCacheX12 * cosCacheY34 +
                        coeffs13 * cosCacheX12 * cosCacheY42 +
                        coeffs14 * cosCacheX12 * cosCacheY50 +
                        coeffs15 * cosCacheX12 * cosCacheY58 +
                        coeffs16 * cosCacheX20 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY10 +
                        coeffs18 * cosCacheX20 * cosCacheY18 +
                        coeffs19 * cosCacheX20 * cosCacheY26 +
                        coeffs20 * cosCacheX20 * cosCacheY34 +
                        coeffs21 * cosCacheX20 * cosCacheY42 +
                        coeffs22 * cosCacheX20 * cosCacheY50 +
                        coeffs23 * cosCacheX20 * cosCacheY58 +
                        coeffs24 * cosCacheX28 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY10 +
                        coeffs26 * cosCacheX28 * cosCacheY18 +
                        coeffs27 * cosCacheX28 * cosCacheY26 +
                        coeffs28 * cosCacheX28 * cosCacheY34 +
                        coeffs29 * cosCacheX28 * cosCacheY42 +
                        coeffs30 * cosCacheX28 * cosCacheY50 +
                        coeffs31 * cosCacheX28 * cosCacheY58 +
                        coeffs32 * cosCacheX36 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY10 +
                        coeffs34 * cosCacheX36 * cosCacheY18 +
                        coeffs35 * cosCacheX36 * cosCacheY26 +
                        coeffs36 * cosCacheX36 * cosCacheY34 +
                        coeffs37 * cosCacheX36 * cosCacheY42 +
                        coeffs38 * cosCacheX36 * cosCacheY50 +
                        coeffs39 * cosCacheX36 * cosCacheY58 +
                        coeffs40 * cosCacheX44 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY10 +
                        coeffs42 * cosCacheX44 * cosCacheY18 +
                        coeffs43 * cosCacheX44 * cosCacheY26 +
                        coeffs44 * cosCacheX44 * cosCacheY34 +
                        coeffs45 * cosCacheX44 * cosCacheY42 +
                        coeffs46 * cosCacheX44 * cosCacheY50 +
                        coeffs47 * cosCacheX44 * cosCacheY58 +
                        coeffs48 * cosCacheX52 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY10 +
                        coeffs50 * cosCacheX52 * cosCacheY18 +
                        coeffs51 * cosCacheX52 * cosCacheY26 +
                        coeffs52 * cosCacheX52 * cosCacheY34 +
                        coeffs53 * cosCacheX52 * cosCacheY42 +
                        coeffs54 * cosCacheX52 * cosCacheY50 +
                        coeffs55 * cosCacheX52 * cosCacheY58 +
                        coeffs56 * cosCacheX60 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY10 +
                        coeffs58 * cosCacheX60 * cosCacheY18 +
                        coeffs59 * cosCacheX60 * cosCacheY26 +
                        coeffs60 * cosCacheX60 * cosCacheY34 +
                        coeffs61 * cosCacheX60 * cosCacheY42 +
                        coeffs62 * cosCacheX60 * cosCacheY50 +
                        coeffs63 * cosCacheX60 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 3] = (coeffs0 * cosCacheX4 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY11 +
                        coeffs10 * cosCacheX12 * cosCacheY19 +
                        coeffs11 * cosCacheX12 * cosCacheY27 +
                        coeffs12 * cosCacheX12 * cosCacheY35 +
                        coeffs13 * cosCacheX12 * cosCacheY43 +
                        coeffs14 * cosCacheX12 * cosCacheY51 +
                        coeffs15 * cosCacheX12 * cosCacheY59 +
                        coeffs16 * cosCacheX20 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY11 +
                        coeffs18 * cosCacheX20 * cosCacheY19 +
                        coeffs19 * cosCacheX20 * cosCacheY27 +
                        coeffs20 * cosCacheX20 * cosCacheY35 +
                        coeffs21 * cosCacheX20 * cosCacheY43 +
                        coeffs22 * cosCacheX20 * cosCacheY51 +
                        coeffs23 * cosCacheX20 * cosCacheY59 +
                        coeffs24 * cosCacheX28 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY11 +
                        coeffs26 * cosCacheX28 * cosCacheY19 +
                        coeffs27 * cosCacheX28 * cosCacheY27 +
                        coeffs28 * cosCacheX28 * cosCacheY35 +
                        coeffs29 * cosCacheX28 * cosCacheY43 +
                        coeffs30 * cosCacheX28 * cosCacheY51 +
                        coeffs31 * cosCacheX28 * cosCacheY59 +
                        coeffs32 * cosCacheX36 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY11 +
                        coeffs34 * cosCacheX36 * cosCacheY19 +
                        coeffs35 * cosCacheX36 * cosCacheY27 +
                        coeffs36 * cosCacheX36 * cosCacheY35 +
                        coeffs37 * cosCacheX36 * cosCacheY43 +
                        coeffs38 * cosCacheX36 * cosCacheY51 +
                        coeffs39 * cosCacheX36 * cosCacheY59 +
                        coeffs40 * cosCacheX44 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY11 +
                        coeffs42 * cosCacheX44 * cosCacheY19 +
                        coeffs43 * cosCacheX44 * cosCacheY27 +
                        coeffs44 * cosCacheX44 * cosCacheY35 +
                        coeffs45 * cosCacheX44 * cosCacheY43 +
                        coeffs46 * cosCacheX44 * cosCacheY51 +
                        coeffs47 * cosCacheX44 * cosCacheY59 +
                        coeffs48 * cosCacheX52 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY11 +
                        coeffs50 * cosCacheX52 * cosCacheY19 +
                        coeffs51 * cosCacheX52 * cosCacheY27 +
                        coeffs52 * cosCacheX52 * cosCacheY35 +
                        coeffs53 * cosCacheX52 * cosCacheY43 +
                        coeffs54 * cosCacheX52 * cosCacheY51 +
                        coeffs55 * cosCacheX52 * cosCacheY59 +
                        coeffs56 * cosCacheX60 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY11 +
                        coeffs58 * cosCacheX60 * cosCacheY19 +
                        coeffs59 * cosCacheX60 * cosCacheY27 +
                        coeffs60 * cosCacheX60 * cosCacheY35 +
                        coeffs61 * cosCacheX60 * cosCacheY43 +
                        coeffs62 * cosCacheX60 * cosCacheY51 +
                        coeffs63 * cosCacheX60 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 4] = (coeffs0 * cosCacheX4 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY12 +
                        coeffs10 * cosCacheX12 * cosCacheY20 +
                        coeffs11 * cosCacheX12 * cosCacheY28 +
                        coeffs12 * cosCacheX12 * cosCacheY36 +
                        coeffs13 * cosCacheX12 * cosCacheY44 +
                        coeffs14 * cosCacheX12 * cosCacheY52 +
                        coeffs15 * cosCacheX12 * cosCacheY60 +
                        coeffs16 * cosCacheX20 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY12 +
                        coeffs18 * cosCacheX20 * cosCacheY20 +
                        coeffs19 * cosCacheX20 * cosCacheY28 +
                        coeffs20 * cosCacheX20 * cosCacheY36 +
                        coeffs21 * cosCacheX20 * cosCacheY44 +
                        coeffs22 * cosCacheX20 * cosCacheY52 +
                        coeffs23 * cosCacheX20 * cosCacheY60 +
                        coeffs24 * cosCacheX28 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY12 +
                        coeffs26 * cosCacheX28 * cosCacheY20 +
                        coeffs27 * cosCacheX28 * cosCacheY28 +
                        coeffs28 * cosCacheX28 * cosCacheY36 +
                        coeffs29 * cosCacheX28 * cosCacheY44 +
                        coeffs30 * cosCacheX28 * cosCacheY52 +
                        coeffs31 * cosCacheX28 * cosCacheY60 +
                        coeffs32 * cosCacheX36 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY12 +
                        coeffs34 * cosCacheX36 * cosCacheY20 +
                        coeffs35 * cosCacheX36 * cosCacheY28 +
                        coeffs36 * cosCacheX36 * cosCacheY36 +
                        coeffs37 * cosCacheX36 * cosCacheY44 +
                        coeffs38 * cosCacheX36 * cosCacheY52 +
                        coeffs39 * cosCacheX36 * cosCacheY60 +
                        coeffs40 * cosCacheX44 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY12 +
                        coeffs42 * cosCacheX44 * cosCacheY20 +
                        coeffs43 * cosCacheX44 * cosCacheY28 +
                        coeffs44 * cosCacheX44 * cosCacheY36 +
                        coeffs45 * cosCacheX44 * cosCacheY44 +
                        coeffs46 * cosCacheX44 * cosCacheY52 +
                        coeffs47 * cosCacheX44 * cosCacheY60 +
                        coeffs48 * cosCacheX52 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY12 +
                        coeffs50 * cosCacheX52 * cosCacheY20 +
                        coeffs51 * cosCacheX52 * cosCacheY28 +
                        coeffs52 * cosCacheX52 * cosCacheY36 +
                        coeffs53 * cosCacheX52 * cosCacheY44 +
                        coeffs54 * cosCacheX52 * cosCacheY52 +
                        coeffs55 * cosCacheX52 * cosCacheY60 +
                        coeffs56 * cosCacheX60 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY12 +
                        coeffs58 * cosCacheX60 * cosCacheY20 +
                        coeffs59 * cosCacheX60 * cosCacheY28 +
                        coeffs60 * cosCacheX60 * cosCacheY36 +
                        coeffs61 * cosCacheX60 * cosCacheY44 +
                        coeffs62 * cosCacheX60 * cosCacheY52 +
                        coeffs63 * cosCacheX60 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 5] = (coeffs0 * cosCacheX4 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY13 +
                        coeffs10 * cosCacheX12 * cosCacheY21 +
                        coeffs11 * cosCacheX12 * cosCacheY29 +
                        coeffs12 * cosCacheX12 * cosCacheY37 +
                        coeffs13 * cosCacheX12 * cosCacheY45 +
                        coeffs14 * cosCacheX12 * cosCacheY53 +
                        coeffs15 * cosCacheX12 * cosCacheY61 +
                        coeffs16 * cosCacheX20 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY13 +
                        coeffs18 * cosCacheX20 * cosCacheY21 +
                        coeffs19 * cosCacheX20 * cosCacheY29 +
                        coeffs20 * cosCacheX20 * cosCacheY37 +
                        coeffs21 * cosCacheX20 * cosCacheY45 +
                        coeffs22 * cosCacheX20 * cosCacheY53 +
                        coeffs23 * cosCacheX20 * cosCacheY61 +
                        coeffs24 * cosCacheX28 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY13 +
                        coeffs26 * cosCacheX28 * cosCacheY21 +
                        coeffs27 * cosCacheX28 * cosCacheY29 +
                        coeffs28 * cosCacheX28 * cosCacheY37 +
                        coeffs29 * cosCacheX28 * cosCacheY45 +
                        coeffs30 * cosCacheX28 * cosCacheY53 +
                        coeffs31 * cosCacheX28 * cosCacheY61 +
                        coeffs32 * cosCacheX36 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY13 +
                        coeffs34 * cosCacheX36 * cosCacheY21 +
                        coeffs35 * cosCacheX36 * cosCacheY29 +
                        coeffs36 * cosCacheX36 * cosCacheY37 +
                        coeffs37 * cosCacheX36 * cosCacheY45 +
                        coeffs38 * cosCacheX36 * cosCacheY53 +
                        coeffs39 * cosCacheX36 * cosCacheY61 +
                        coeffs40 * cosCacheX44 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY13 +
                        coeffs42 * cosCacheX44 * cosCacheY21 +
                        coeffs43 * cosCacheX44 * cosCacheY29 +
                        coeffs44 * cosCacheX44 * cosCacheY37 +
                        coeffs45 * cosCacheX44 * cosCacheY45 +
                        coeffs46 * cosCacheX44 * cosCacheY53 +
                        coeffs47 * cosCacheX44 * cosCacheY61 +
                        coeffs48 * cosCacheX52 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY13 +
                        coeffs50 * cosCacheX52 * cosCacheY21 +
                        coeffs51 * cosCacheX52 * cosCacheY29 +
                        coeffs52 * cosCacheX52 * cosCacheY37 +
                        coeffs53 * cosCacheX52 * cosCacheY45 +
                        coeffs54 * cosCacheX52 * cosCacheY53 +
                        coeffs55 * cosCacheX52 * cosCacheY61 +
                        coeffs56 * cosCacheX60 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY13 +
                        coeffs58 * cosCacheX60 * cosCacheY21 +
                        coeffs59 * cosCacheX60 * cosCacheY29 +
                        coeffs60 * cosCacheX60 * cosCacheY37 +
                        coeffs61 * cosCacheX60 * cosCacheY45 +
                        coeffs62 * cosCacheX60 * cosCacheY53 +
                        coeffs63 * cosCacheX60 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 6] = (coeffs0 * cosCacheX4 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY14 +
                        coeffs10 * cosCacheX12 * cosCacheY22 +
                        coeffs11 * cosCacheX12 * cosCacheY30 +
                        coeffs12 * cosCacheX12 * cosCacheY38 +
                        coeffs13 * cosCacheX12 * cosCacheY46 +
                        coeffs14 * cosCacheX12 * cosCacheY54 +
                        coeffs15 * cosCacheX12 * cosCacheY62 +
                        coeffs16 * cosCacheX20 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY14 +
                        coeffs18 * cosCacheX20 * cosCacheY22 +
                        coeffs19 * cosCacheX20 * cosCacheY30 +
                        coeffs20 * cosCacheX20 * cosCacheY38 +
                        coeffs21 * cosCacheX20 * cosCacheY46 +
                        coeffs22 * cosCacheX20 * cosCacheY54 +
                        coeffs23 * cosCacheX20 * cosCacheY62 +
                        coeffs24 * cosCacheX28 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY14 +
                        coeffs26 * cosCacheX28 * cosCacheY22 +
                        coeffs27 * cosCacheX28 * cosCacheY30 +
                        coeffs28 * cosCacheX28 * cosCacheY38 +
                        coeffs29 * cosCacheX28 * cosCacheY46 +
                        coeffs30 * cosCacheX28 * cosCacheY54 +
                        coeffs31 * cosCacheX28 * cosCacheY62 +
                        coeffs32 * cosCacheX36 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY14 +
                        coeffs34 * cosCacheX36 * cosCacheY22 +
                        coeffs35 * cosCacheX36 * cosCacheY30 +
                        coeffs36 * cosCacheX36 * cosCacheY38 +
                        coeffs37 * cosCacheX36 * cosCacheY46 +
                        coeffs38 * cosCacheX36 * cosCacheY54 +
                        coeffs39 * cosCacheX36 * cosCacheY62 +
                        coeffs40 * cosCacheX44 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY14 +
                        coeffs42 * cosCacheX44 * cosCacheY22 +
                        coeffs43 * cosCacheX44 * cosCacheY30 +
                        coeffs44 * cosCacheX44 * cosCacheY38 +
                        coeffs45 * cosCacheX44 * cosCacheY46 +
                        coeffs46 * cosCacheX44 * cosCacheY54 +
                        coeffs47 * cosCacheX44 * cosCacheY62 +
                        coeffs48 * cosCacheX52 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY14 +
                        coeffs50 * cosCacheX52 * cosCacheY22 +
                        coeffs51 * cosCacheX52 * cosCacheY30 +
                        coeffs52 * cosCacheX52 * cosCacheY38 +
                        coeffs53 * cosCacheX52 * cosCacheY46 +
                        coeffs54 * cosCacheX52 * cosCacheY54 +
                        coeffs55 * cosCacheX52 * cosCacheY62 +
                        coeffs56 * cosCacheX60 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY14 +
                        coeffs58 * cosCacheX60 * cosCacheY22 +
                        coeffs59 * cosCacheX60 * cosCacheY30 +
                        coeffs60 * cosCacheX60 * cosCacheY38 +
                        coeffs61 * cosCacheX60 * cosCacheY46 +
                        coeffs62 * cosCacheX60 * cosCacheY54 +
                        coeffs63 * cosCacheX60 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 7] = (coeffs0 * cosCacheX4 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX4 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX4 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX4 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX4 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX4 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX4 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX4 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX12 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX12 * cosCacheY15 +
                        coeffs10 * cosCacheX12 * cosCacheY23 +
                        coeffs11 * cosCacheX12 * cosCacheY31 +
                        coeffs12 * cosCacheX12 * cosCacheY39 +
                        coeffs13 * cosCacheX12 * cosCacheY47 +
                        coeffs14 * cosCacheX12 * cosCacheY55 +
                        coeffs15 * cosCacheX12 * cosCacheY63 +
                        coeffs16 * cosCacheX20 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX20 * cosCacheY15 +
                        coeffs18 * cosCacheX20 * cosCacheY23 +
                        coeffs19 * cosCacheX20 * cosCacheY31 +
                        coeffs20 * cosCacheX20 * cosCacheY39 +
                        coeffs21 * cosCacheX20 * cosCacheY47 +
                        coeffs22 * cosCacheX20 * cosCacheY55 +
                        coeffs23 * cosCacheX20 * cosCacheY63 +
                        coeffs24 * cosCacheX28 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX28 * cosCacheY15 +
                        coeffs26 * cosCacheX28 * cosCacheY23 +
                        coeffs27 * cosCacheX28 * cosCacheY31 +
                        coeffs28 * cosCacheX28 * cosCacheY39 +
                        coeffs29 * cosCacheX28 * cosCacheY47 +
                        coeffs30 * cosCacheX28 * cosCacheY55 +
                        coeffs31 * cosCacheX28 * cosCacheY63 +
                        coeffs32 * cosCacheX36 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX36 * cosCacheY15 +
                        coeffs34 * cosCacheX36 * cosCacheY23 +
                        coeffs35 * cosCacheX36 * cosCacheY31 +
                        coeffs36 * cosCacheX36 * cosCacheY39 +
                        coeffs37 * cosCacheX36 * cosCacheY47 +
                        coeffs38 * cosCacheX36 * cosCacheY55 +
                        coeffs39 * cosCacheX36 * cosCacheY63 +
                        coeffs40 * cosCacheX44 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX44 * cosCacheY15 +
                        coeffs42 * cosCacheX44 * cosCacheY23 +
                        coeffs43 * cosCacheX44 * cosCacheY31 +
                        coeffs44 * cosCacheX44 * cosCacheY39 +
                        coeffs45 * cosCacheX44 * cosCacheY47 +
                        coeffs46 * cosCacheX44 * cosCacheY55 +
                        coeffs47 * cosCacheX44 * cosCacheY63 +
                        coeffs48 * cosCacheX52 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX52 * cosCacheY15 +
                        coeffs50 * cosCacheX52 * cosCacheY23 +
                        coeffs51 * cosCacheX52 * cosCacheY31 +
                        coeffs52 * cosCacheX52 * cosCacheY39 +
                        coeffs53 * cosCacheX52 * cosCacheY47 +
                        coeffs54 * cosCacheX52 * cosCacheY55 +
                        coeffs55 * cosCacheX52 * cosCacheY63 +
                        coeffs56 * cosCacheX60 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX60 * cosCacheY15 +
                        coeffs58 * cosCacheX60 * cosCacheY23 +
                        coeffs59 * cosCacheX60 * cosCacheY31 +
                        coeffs60 * cosCacheX60 * cosCacheY39 +
                        coeffs61 * cosCacheX60 * cosCacheY47 +
                        coeffs62 * cosCacheX60 * cosCacheY55 +
                        coeffs63 * cosCacheX60 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 0] = (coeffs0 * cosCacheX5 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY8 +
                        coeffs10 * cosCacheX13 * cosCacheY16 +
                        coeffs11 * cosCacheX13 * cosCacheY24 +
                        coeffs12 * cosCacheX13 * cosCacheY32 +
                        coeffs13 * cosCacheX13 * cosCacheY40 +
                        coeffs14 * cosCacheX13 * cosCacheY48 +
                        coeffs15 * cosCacheX13 * cosCacheY56 +
                        coeffs16 * cosCacheX21 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY8 +
                        coeffs18 * cosCacheX21 * cosCacheY16 +
                        coeffs19 * cosCacheX21 * cosCacheY24 +
                        coeffs20 * cosCacheX21 * cosCacheY32 +
                        coeffs21 * cosCacheX21 * cosCacheY40 +
                        coeffs22 * cosCacheX21 * cosCacheY48 +
                        coeffs23 * cosCacheX21 * cosCacheY56 +
                        coeffs24 * cosCacheX29 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY8 +
                        coeffs26 * cosCacheX29 * cosCacheY16 +
                        coeffs27 * cosCacheX29 * cosCacheY24 +
                        coeffs28 * cosCacheX29 * cosCacheY32 +
                        coeffs29 * cosCacheX29 * cosCacheY40 +
                        coeffs30 * cosCacheX29 * cosCacheY48 +
                        coeffs31 * cosCacheX29 * cosCacheY56 +
                        coeffs32 * cosCacheX37 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY8 +
                        coeffs34 * cosCacheX37 * cosCacheY16 +
                        coeffs35 * cosCacheX37 * cosCacheY24 +
                        coeffs36 * cosCacheX37 * cosCacheY32 +
                        coeffs37 * cosCacheX37 * cosCacheY40 +
                        coeffs38 * cosCacheX37 * cosCacheY48 +
                        coeffs39 * cosCacheX37 * cosCacheY56 +
                        coeffs40 * cosCacheX45 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY8 +
                        coeffs42 * cosCacheX45 * cosCacheY16 +
                        coeffs43 * cosCacheX45 * cosCacheY24 +
                        coeffs44 * cosCacheX45 * cosCacheY32 +
                        coeffs45 * cosCacheX45 * cosCacheY40 +
                        coeffs46 * cosCacheX45 * cosCacheY48 +
                        coeffs47 * cosCacheX45 * cosCacheY56 +
                        coeffs48 * cosCacheX53 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY8 +
                        coeffs50 * cosCacheX53 * cosCacheY16 +
                        coeffs51 * cosCacheX53 * cosCacheY24 +
                        coeffs52 * cosCacheX53 * cosCacheY32 +
                        coeffs53 * cosCacheX53 * cosCacheY40 +
                        coeffs54 * cosCacheX53 * cosCacheY48 +
                        coeffs55 * cosCacheX53 * cosCacheY56 +
                        coeffs56 * cosCacheX61 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY8 +
                        coeffs58 * cosCacheX61 * cosCacheY16 +
                        coeffs59 * cosCacheX61 * cosCacheY24 +
                        coeffs60 * cosCacheX61 * cosCacheY32 +
                        coeffs61 * cosCacheX61 * cosCacheY40 +
                        coeffs62 * cosCacheX61 * cosCacheY48 +
                        coeffs63 * cosCacheX61 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 1] = (coeffs0 * cosCacheX5 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY9 +
                        coeffs10 * cosCacheX13 * cosCacheY17 +
                        coeffs11 * cosCacheX13 * cosCacheY25 +
                        coeffs12 * cosCacheX13 * cosCacheY33 +
                        coeffs13 * cosCacheX13 * cosCacheY41 +
                        coeffs14 * cosCacheX13 * cosCacheY49 +
                        coeffs15 * cosCacheX13 * cosCacheY57 +
                        coeffs16 * cosCacheX21 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY9 +
                        coeffs18 * cosCacheX21 * cosCacheY17 +
                        coeffs19 * cosCacheX21 * cosCacheY25 +
                        coeffs20 * cosCacheX21 * cosCacheY33 +
                        coeffs21 * cosCacheX21 * cosCacheY41 +
                        coeffs22 * cosCacheX21 * cosCacheY49 +
                        coeffs23 * cosCacheX21 * cosCacheY57 +
                        coeffs24 * cosCacheX29 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY9 +
                        coeffs26 * cosCacheX29 * cosCacheY17 +
                        coeffs27 * cosCacheX29 * cosCacheY25 +
                        coeffs28 * cosCacheX29 * cosCacheY33 +
                        coeffs29 * cosCacheX29 * cosCacheY41 +
                        coeffs30 * cosCacheX29 * cosCacheY49 +
                        coeffs31 * cosCacheX29 * cosCacheY57 +
                        coeffs32 * cosCacheX37 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY9 +
                        coeffs34 * cosCacheX37 * cosCacheY17 +
                        coeffs35 * cosCacheX37 * cosCacheY25 +
                        coeffs36 * cosCacheX37 * cosCacheY33 +
                        coeffs37 * cosCacheX37 * cosCacheY41 +
                        coeffs38 * cosCacheX37 * cosCacheY49 +
                        coeffs39 * cosCacheX37 * cosCacheY57 +
                        coeffs40 * cosCacheX45 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY9 +
                        coeffs42 * cosCacheX45 * cosCacheY17 +
                        coeffs43 * cosCacheX45 * cosCacheY25 +
                        coeffs44 * cosCacheX45 * cosCacheY33 +
                        coeffs45 * cosCacheX45 * cosCacheY41 +
                        coeffs46 * cosCacheX45 * cosCacheY49 +
                        coeffs47 * cosCacheX45 * cosCacheY57 +
                        coeffs48 * cosCacheX53 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY9 +
                        coeffs50 * cosCacheX53 * cosCacheY17 +
                        coeffs51 * cosCacheX53 * cosCacheY25 +
                        coeffs52 * cosCacheX53 * cosCacheY33 +
                        coeffs53 * cosCacheX53 * cosCacheY41 +
                        coeffs54 * cosCacheX53 * cosCacheY49 +
                        coeffs55 * cosCacheX53 * cosCacheY57 +
                        coeffs56 * cosCacheX61 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY9 +
                        coeffs58 * cosCacheX61 * cosCacheY17 +
                        coeffs59 * cosCacheX61 * cosCacheY25 +
                        coeffs60 * cosCacheX61 * cosCacheY33 +
                        coeffs61 * cosCacheX61 * cosCacheY41 +
                        coeffs62 * cosCacheX61 * cosCacheY49 +
                        coeffs63 * cosCacheX61 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 2] = (coeffs0 * cosCacheX5 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY10 +
                        coeffs10 * cosCacheX13 * cosCacheY18 +
                        coeffs11 * cosCacheX13 * cosCacheY26 +
                        coeffs12 * cosCacheX13 * cosCacheY34 +
                        coeffs13 * cosCacheX13 * cosCacheY42 +
                        coeffs14 * cosCacheX13 * cosCacheY50 +
                        coeffs15 * cosCacheX13 * cosCacheY58 +
                        coeffs16 * cosCacheX21 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY10 +
                        coeffs18 * cosCacheX21 * cosCacheY18 +
                        coeffs19 * cosCacheX21 * cosCacheY26 +
                        coeffs20 * cosCacheX21 * cosCacheY34 +
                        coeffs21 * cosCacheX21 * cosCacheY42 +
                        coeffs22 * cosCacheX21 * cosCacheY50 +
                        coeffs23 * cosCacheX21 * cosCacheY58 +
                        coeffs24 * cosCacheX29 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY10 +
                        coeffs26 * cosCacheX29 * cosCacheY18 +
                        coeffs27 * cosCacheX29 * cosCacheY26 +
                        coeffs28 * cosCacheX29 * cosCacheY34 +
                        coeffs29 * cosCacheX29 * cosCacheY42 +
                        coeffs30 * cosCacheX29 * cosCacheY50 +
                        coeffs31 * cosCacheX29 * cosCacheY58 +
                        coeffs32 * cosCacheX37 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY10 +
                        coeffs34 * cosCacheX37 * cosCacheY18 +
                        coeffs35 * cosCacheX37 * cosCacheY26 +
                        coeffs36 * cosCacheX37 * cosCacheY34 +
                        coeffs37 * cosCacheX37 * cosCacheY42 +
                        coeffs38 * cosCacheX37 * cosCacheY50 +
                        coeffs39 * cosCacheX37 * cosCacheY58 +
                        coeffs40 * cosCacheX45 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY10 +
                        coeffs42 * cosCacheX45 * cosCacheY18 +
                        coeffs43 * cosCacheX45 * cosCacheY26 +
                        coeffs44 * cosCacheX45 * cosCacheY34 +
                        coeffs45 * cosCacheX45 * cosCacheY42 +
                        coeffs46 * cosCacheX45 * cosCacheY50 +
                        coeffs47 * cosCacheX45 * cosCacheY58 +
                        coeffs48 * cosCacheX53 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY10 +
                        coeffs50 * cosCacheX53 * cosCacheY18 +
                        coeffs51 * cosCacheX53 * cosCacheY26 +
                        coeffs52 * cosCacheX53 * cosCacheY34 +
                        coeffs53 * cosCacheX53 * cosCacheY42 +
                        coeffs54 * cosCacheX53 * cosCacheY50 +
                        coeffs55 * cosCacheX53 * cosCacheY58 +
                        coeffs56 * cosCacheX61 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY10 +
                        coeffs58 * cosCacheX61 * cosCacheY18 +
                        coeffs59 * cosCacheX61 * cosCacheY26 +
                        coeffs60 * cosCacheX61 * cosCacheY34 +
                        coeffs61 * cosCacheX61 * cosCacheY42 +
                        coeffs62 * cosCacheX61 * cosCacheY50 +
                        coeffs63 * cosCacheX61 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 3] = (coeffs0 * cosCacheX5 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY11 +
                        coeffs10 * cosCacheX13 * cosCacheY19 +
                        coeffs11 * cosCacheX13 * cosCacheY27 +
                        coeffs12 * cosCacheX13 * cosCacheY35 +
                        coeffs13 * cosCacheX13 * cosCacheY43 +
                        coeffs14 * cosCacheX13 * cosCacheY51 +
                        coeffs15 * cosCacheX13 * cosCacheY59 +
                        coeffs16 * cosCacheX21 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY11 +
                        coeffs18 * cosCacheX21 * cosCacheY19 +
                        coeffs19 * cosCacheX21 * cosCacheY27 +
                        coeffs20 * cosCacheX21 * cosCacheY35 +
                        coeffs21 * cosCacheX21 * cosCacheY43 +
                        coeffs22 * cosCacheX21 * cosCacheY51 +
                        coeffs23 * cosCacheX21 * cosCacheY59 +
                        coeffs24 * cosCacheX29 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY11 +
                        coeffs26 * cosCacheX29 * cosCacheY19 +
                        coeffs27 * cosCacheX29 * cosCacheY27 +
                        coeffs28 * cosCacheX29 * cosCacheY35 +
                        coeffs29 * cosCacheX29 * cosCacheY43 +
                        coeffs30 * cosCacheX29 * cosCacheY51 +
                        coeffs31 * cosCacheX29 * cosCacheY59 +
                        coeffs32 * cosCacheX37 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY11 +
                        coeffs34 * cosCacheX37 * cosCacheY19 +
                        coeffs35 * cosCacheX37 * cosCacheY27 +
                        coeffs36 * cosCacheX37 * cosCacheY35 +
                        coeffs37 * cosCacheX37 * cosCacheY43 +
                        coeffs38 * cosCacheX37 * cosCacheY51 +
                        coeffs39 * cosCacheX37 * cosCacheY59 +
                        coeffs40 * cosCacheX45 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY11 +
                        coeffs42 * cosCacheX45 * cosCacheY19 +
                        coeffs43 * cosCacheX45 * cosCacheY27 +
                        coeffs44 * cosCacheX45 * cosCacheY35 +
                        coeffs45 * cosCacheX45 * cosCacheY43 +
                        coeffs46 * cosCacheX45 * cosCacheY51 +
                        coeffs47 * cosCacheX45 * cosCacheY59 +
                        coeffs48 * cosCacheX53 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY11 +
                        coeffs50 * cosCacheX53 * cosCacheY19 +
                        coeffs51 * cosCacheX53 * cosCacheY27 +
                        coeffs52 * cosCacheX53 * cosCacheY35 +
                        coeffs53 * cosCacheX53 * cosCacheY43 +
                        coeffs54 * cosCacheX53 * cosCacheY51 +
                        coeffs55 * cosCacheX53 * cosCacheY59 +
                        coeffs56 * cosCacheX61 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY11 +
                        coeffs58 * cosCacheX61 * cosCacheY19 +
                        coeffs59 * cosCacheX61 * cosCacheY27 +
                        coeffs60 * cosCacheX61 * cosCacheY35 +
                        coeffs61 * cosCacheX61 * cosCacheY43 +
                        coeffs62 * cosCacheX61 * cosCacheY51 +
                        coeffs63 * cosCacheX61 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 4] = (coeffs0 * cosCacheX5 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY12 +
                        coeffs10 * cosCacheX13 * cosCacheY20 +
                        coeffs11 * cosCacheX13 * cosCacheY28 +
                        coeffs12 * cosCacheX13 * cosCacheY36 +
                        coeffs13 * cosCacheX13 * cosCacheY44 +
                        coeffs14 * cosCacheX13 * cosCacheY52 +
                        coeffs15 * cosCacheX13 * cosCacheY60 +
                        coeffs16 * cosCacheX21 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY12 +
                        coeffs18 * cosCacheX21 * cosCacheY20 +
                        coeffs19 * cosCacheX21 * cosCacheY28 +
                        coeffs20 * cosCacheX21 * cosCacheY36 +
                        coeffs21 * cosCacheX21 * cosCacheY44 +
                        coeffs22 * cosCacheX21 * cosCacheY52 +
                        coeffs23 * cosCacheX21 * cosCacheY60 +
                        coeffs24 * cosCacheX29 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY12 +
                        coeffs26 * cosCacheX29 * cosCacheY20 +
                        coeffs27 * cosCacheX29 * cosCacheY28 +
                        coeffs28 * cosCacheX29 * cosCacheY36 +
                        coeffs29 * cosCacheX29 * cosCacheY44 +
                        coeffs30 * cosCacheX29 * cosCacheY52 +
                        coeffs31 * cosCacheX29 * cosCacheY60 +
                        coeffs32 * cosCacheX37 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY12 +
                        coeffs34 * cosCacheX37 * cosCacheY20 +
                        coeffs35 * cosCacheX37 * cosCacheY28 +
                        coeffs36 * cosCacheX37 * cosCacheY36 +
                        coeffs37 * cosCacheX37 * cosCacheY44 +
                        coeffs38 * cosCacheX37 * cosCacheY52 +
                        coeffs39 * cosCacheX37 * cosCacheY60 +
                        coeffs40 * cosCacheX45 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY12 +
                        coeffs42 * cosCacheX45 * cosCacheY20 +
                        coeffs43 * cosCacheX45 * cosCacheY28 +
                        coeffs44 * cosCacheX45 * cosCacheY36 +
                        coeffs45 * cosCacheX45 * cosCacheY44 +
                        coeffs46 * cosCacheX45 * cosCacheY52 +
                        coeffs47 * cosCacheX45 * cosCacheY60 +
                        coeffs48 * cosCacheX53 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY12 +
                        coeffs50 * cosCacheX53 * cosCacheY20 +
                        coeffs51 * cosCacheX53 * cosCacheY28 +
                        coeffs52 * cosCacheX53 * cosCacheY36 +
                        coeffs53 * cosCacheX53 * cosCacheY44 +
                        coeffs54 * cosCacheX53 * cosCacheY52 +
                        coeffs55 * cosCacheX53 * cosCacheY60 +
                        coeffs56 * cosCacheX61 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY12 +
                        coeffs58 * cosCacheX61 * cosCacheY20 +
                        coeffs59 * cosCacheX61 * cosCacheY28 +
                        coeffs60 * cosCacheX61 * cosCacheY36 +
                        coeffs61 * cosCacheX61 * cosCacheY44 +
                        coeffs62 * cosCacheX61 * cosCacheY52 +
                        coeffs63 * cosCacheX61 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 5] = (coeffs0 * cosCacheX5 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY13 +
                        coeffs10 * cosCacheX13 * cosCacheY21 +
                        coeffs11 * cosCacheX13 * cosCacheY29 +
                        coeffs12 * cosCacheX13 * cosCacheY37 +
                        coeffs13 * cosCacheX13 * cosCacheY45 +
                        coeffs14 * cosCacheX13 * cosCacheY53 +
                        coeffs15 * cosCacheX13 * cosCacheY61 +
                        coeffs16 * cosCacheX21 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY13 +
                        coeffs18 * cosCacheX21 * cosCacheY21 +
                        coeffs19 * cosCacheX21 * cosCacheY29 +
                        coeffs20 * cosCacheX21 * cosCacheY37 +
                        coeffs21 * cosCacheX21 * cosCacheY45 +
                        coeffs22 * cosCacheX21 * cosCacheY53 +
                        coeffs23 * cosCacheX21 * cosCacheY61 +
                        coeffs24 * cosCacheX29 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY13 +
                        coeffs26 * cosCacheX29 * cosCacheY21 +
                        coeffs27 * cosCacheX29 * cosCacheY29 +
                        coeffs28 * cosCacheX29 * cosCacheY37 +
                        coeffs29 * cosCacheX29 * cosCacheY45 +
                        coeffs30 * cosCacheX29 * cosCacheY53 +
                        coeffs31 * cosCacheX29 * cosCacheY61 +
                        coeffs32 * cosCacheX37 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY13 +
                        coeffs34 * cosCacheX37 * cosCacheY21 +
                        coeffs35 * cosCacheX37 * cosCacheY29 +
                        coeffs36 * cosCacheX37 * cosCacheY37 +
                        coeffs37 * cosCacheX37 * cosCacheY45 +
                        coeffs38 * cosCacheX37 * cosCacheY53 +
                        coeffs39 * cosCacheX37 * cosCacheY61 +
                        coeffs40 * cosCacheX45 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY13 +
                        coeffs42 * cosCacheX45 * cosCacheY21 +
                        coeffs43 * cosCacheX45 * cosCacheY29 +
                        coeffs44 * cosCacheX45 * cosCacheY37 +
                        coeffs45 * cosCacheX45 * cosCacheY45 +
                        coeffs46 * cosCacheX45 * cosCacheY53 +
                        coeffs47 * cosCacheX45 * cosCacheY61 +
                        coeffs48 * cosCacheX53 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY13 +
                        coeffs50 * cosCacheX53 * cosCacheY21 +
                        coeffs51 * cosCacheX53 * cosCacheY29 +
                        coeffs52 * cosCacheX53 * cosCacheY37 +
                        coeffs53 * cosCacheX53 * cosCacheY45 +
                        coeffs54 * cosCacheX53 * cosCacheY53 +
                        coeffs55 * cosCacheX53 * cosCacheY61 +
                        coeffs56 * cosCacheX61 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY13 +
                        coeffs58 * cosCacheX61 * cosCacheY21 +
                        coeffs59 * cosCacheX61 * cosCacheY29 +
                        coeffs60 * cosCacheX61 * cosCacheY37 +
                        coeffs61 * cosCacheX61 * cosCacheY45 +
                        coeffs62 * cosCacheX61 * cosCacheY53 +
                        coeffs63 * cosCacheX61 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 6] = (coeffs0 * cosCacheX5 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY14 +
                        coeffs10 * cosCacheX13 * cosCacheY22 +
                        coeffs11 * cosCacheX13 * cosCacheY30 +
                        coeffs12 * cosCacheX13 * cosCacheY38 +
                        coeffs13 * cosCacheX13 * cosCacheY46 +
                        coeffs14 * cosCacheX13 * cosCacheY54 +
                        coeffs15 * cosCacheX13 * cosCacheY62 +
                        coeffs16 * cosCacheX21 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY14 +
                        coeffs18 * cosCacheX21 * cosCacheY22 +
                        coeffs19 * cosCacheX21 * cosCacheY30 +
                        coeffs20 * cosCacheX21 * cosCacheY38 +
                        coeffs21 * cosCacheX21 * cosCacheY46 +
                        coeffs22 * cosCacheX21 * cosCacheY54 +
                        coeffs23 * cosCacheX21 * cosCacheY62 +
                        coeffs24 * cosCacheX29 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY14 +
                        coeffs26 * cosCacheX29 * cosCacheY22 +
                        coeffs27 * cosCacheX29 * cosCacheY30 +
                        coeffs28 * cosCacheX29 * cosCacheY38 +
                        coeffs29 * cosCacheX29 * cosCacheY46 +
                        coeffs30 * cosCacheX29 * cosCacheY54 +
                        coeffs31 * cosCacheX29 * cosCacheY62 +
                        coeffs32 * cosCacheX37 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY14 +
                        coeffs34 * cosCacheX37 * cosCacheY22 +
                        coeffs35 * cosCacheX37 * cosCacheY30 +
                        coeffs36 * cosCacheX37 * cosCacheY38 +
                        coeffs37 * cosCacheX37 * cosCacheY46 +
                        coeffs38 * cosCacheX37 * cosCacheY54 +
                        coeffs39 * cosCacheX37 * cosCacheY62 +
                        coeffs40 * cosCacheX45 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY14 +
                        coeffs42 * cosCacheX45 * cosCacheY22 +
                        coeffs43 * cosCacheX45 * cosCacheY30 +
                        coeffs44 * cosCacheX45 * cosCacheY38 +
                        coeffs45 * cosCacheX45 * cosCacheY46 +
                        coeffs46 * cosCacheX45 * cosCacheY54 +
                        coeffs47 * cosCacheX45 * cosCacheY62 +
                        coeffs48 * cosCacheX53 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY14 +
                        coeffs50 * cosCacheX53 * cosCacheY22 +
                        coeffs51 * cosCacheX53 * cosCacheY30 +
                        coeffs52 * cosCacheX53 * cosCacheY38 +
                        coeffs53 * cosCacheX53 * cosCacheY46 +
                        coeffs54 * cosCacheX53 * cosCacheY54 +
                        coeffs55 * cosCacheX53 * cosCacheY62 +
                        coeffs56 * cosCacheX61 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY14 +
                        coeffs58 * cosCacheX61 * cosCacheY22 +
                        coeffs59 * cosCacheX61 * cosCacheY30 +
                        coeffs60 * cosCacheX61 * cosCacheY38 +
                        coeffs61 * cosCacheX61 * cosCacheY46 +
                        coeffs62 * cosCacheX61 * cosCacheY54 +
                        coeffs63 * cosCacheX61 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 7] = (coeffs0 * cosCacheX5 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX5 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX5 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX5 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX5 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX5 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX5 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX5 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX13 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX13 * cosCacheY15 +
                        coeffs10 * cosCacheX13 * cosCacheY23 +
                        coeffs11 * cosCacheX13 * cosCacheY31 +
                        coeffs12 * cosCacheX13 * cosCacheY39 +
                        coeffs13 * cosCacheX13 * cosCacheY47 +
                        coeffs14 * cosCacheX13 * cosCacheY55 +
                        coeffs15 * cosCacheX13 * cosCacheY63 +
                        coeffs16 * cosCacheX21 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX21 * cosCacheY15 +
                        coeffs18 * cosCacheX21 * cosCacheY23 +
                        coeffs19 * cosCacheX21 * cosCacheY31 +
                        coeffs20 * cosCacheX21 * cosCacheY39 +
                        coeffs21 * cosCacheX21 * cosCacheY47 +
                        coeffs22 * cosCacheX21 * cosCacheY55 +
                        coeffs23 * cosCacheX21 * cosCacheY63 +
                        coeffs24 * cosCacheX29 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX29 * cosCacheY15 +
                        coeffs26 * cosCacheX29 * cosCacheY23 +
                        coeffs27 * cosCacheX29 * cosCacheY31 +
                        coeffs28 * cosCacheX29 * cosCacheY39 +
                        coeffs29 * cosCacheX29 * cosCacheY47 +
                        coeffs30 * cosCacheX29 * cosCacheY55 +
                        coeffs31 * cosCacheX29 * cosCacheY63 +
                        coeffs32 * cosCacheX37 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX37 * cosCacheY15 +
                        coeffs34 * cosCacheX37 * cosCacheY23 +
                        coeffs35 * cosCacheX37 * cosCacheY31 +
                        coeffs36 * cosCacheX37 * cosCacheY39 +
                        coeffs37 * cosCacheX37 * cosCacheY47 +
                        coeffs38 * cosCacheX37 * cosCacheY55 +
                        coeffs39 * cosCacheX37 * cosCacheY63 +
                        coeffs40 * cosCacheX45 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX45 * cosCacheY15 +
                        coeffs42 * cosCacheX45 * cosCacheY23 +
                        coeffs43 * cosCacheX45 * cosCacheY31 +
                        coeffs44 * cosCacheX45 * cosCacheY39 +
                        coeffs45 * cosCacheX45 * cosCacheY47 +
                        coeffs46 * cosCacheX45 * cosCacheY55 +
                        coeffs47 * cosCacheX45 * cosCacheY63 +
                        coeffs48 * cosCacheX53 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX53 * cosCacheY15 +
                        coeffs50 * cosCacheX53 * cosCacheY23 +
                        coeffs51 * cosCacheX53 * cosCacheY31 +
                        coeffs52 * cosCacheX53 * cosCacheY39 +
                        coeffs53 * cosCacheX53 * cosCacheY47 +
                        coeffs54 * cosCacheX53 * cosCacheY55 +
                        coeffs55 * cosCacheX53 * cosCacheY63 +
                        coeffs56 * cosCacheX61 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX61 * cosCacheY15 +
                        coeffs58 * cosCacheX61 * cosCacheY23 +
                        coeffs59 * cosCacheX61 * cosCacheY31 +
                        coeffs60 * cosCacheX61 * cosCacheY39 +
                        coeffs61 * cosCacheX61 * cosCacheY47 +
                        coeffs62 * cosCacheX61 * cosCacheY55 +
                        coeffs63 * cosCacheX61 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 0] = (coeffs0 * cosCacheX6 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY8 +
                        coeffs10 * cosCacheX14 * cosCacheY16 +
                        coeffs11 * cosCacheX14 * cosCacheY24 +
                        coeffs12 * cosCacheX14 * cosCacheY32 +
                        coeffs13 * cosCacheX14 * cosCacheY40 +
                        coeffs14 * cosCacheX14 * cosCacheY48 +
                        coeffs15 * cosCacheX14 * cosCacheY56 +
                        coeffs16 * cosCacheX22 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY8 +
                        coeffs18 * cosCacheX22 * cosCacheY16 +
                        coeffs19 * cosCacheX22 * cosCacheY24 +
                        coeffs20 * cosCacheX22 * cosCacheY32 +
                        coeffs21 * cosCacheX22 * cosCacheY40 +
                        coeffs22 * cosCacheX22 * cosCacheY48 +
                        coeffs23 * cosCacheX22 * cosCacheY56 +
                        coeffs24 * cosCacheX30 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY8 +
                        coeffs26 * cosCacheX30 * cosCacheY16 +
                        coeffs27 * cosCacheX30 * cosCacheY24 +
                        coeffs28 * cosCacheX30 * cosCacheY32 +
                        coeffs29 * cosCacheX30 * cosCacheY40 +
                        coeffs30 * cosCacheX30 * cosCacheY48 +
                        coeffs31 * cosCacheX30 * cosCacheY56 +
                        coeffs32 * cosCacheX38 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY8 +
                        coeffs34 * cosCacheX38 * cosCacheY16 +
                        coeffs35 * cosCacheX38 * cosCacheY24 +
                        coeffs36 * cosCacheX38 * cosCacheY32 +
                        coeffs37 * cosCacheX38 * cosCacheY40 +
                        coeffs38 * cosCacheX38 * cosCacheY48 +
                        coeffs39 * cosCacheX38 * cosCacheY56 +
                        coeffs40 * cosCacheX46 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY8 +
                        coeffs42 * cosCacheX46 * cosCacheY16 +
                        coeffs43 * cosCacheX46 * cosCacheY24 +
                        coeffs44 * cosCacheX46 * cosCacheY32 +
                        coeffs45 * cosCacheX46 * cosCacheY40 +
                        coeffs46 * cosCacheX46 * cosCacheY48 +
                        coeffs47 * cosCacheX46 * cosCacheY56 +
                        coeffs48 * cosCacheX54 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY8 +
                        coeffs50 * cosCacheX54 * cosCacheY16 +
                        coeffs51 * cosCacheX54 * cosCacheY24 +
                        coeffs52 * cosCacheX54 * cosCacheY32 +
                        coeffs53 * cosCacheX54 * cosCacheY40 +
                        coeffs54 * cosCacheX54 * cosCacheY48 +
                        coeffs55 * cosCacheX54 * cosCacheY56 +
                        coeffs56 * cosCacheX62 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY8 +
                        coeffs58 * cosCacheX62 * cosCacheY16 +
                        coeffs59 * cosCacheX62 * cosCacheY24 +
                        coeffs60 * cosCacheX62 * cosCacheY32 +
                        coeffs61 * cosCacheX62 * cosCacheY40 +
                        coeffs62 * cosCacheX62 * cosCacheY48 +
                        coeffs63 * cosCacheX62 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 1] = (coeffs0 * cosCacheX6 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY9 +
                        coeffs10 * cosCacheX14 * cosCacheY17 +
                        coeffs11 * cosCacheX14 * cosCacheY25 +
                        coeffs12 * cosCacheX14 * cosCacheY33 +
                        coeffs13 * cosCacheX14 * cosCacheY41 +
                        coeffs14 * cosCacheX14 * cosCacheY49 +
                        coeffs15 * cosCacheX14 * cosCacheY57 +
                        coeffs16 * cosCacheX22 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY9 +
                        coeffs18 * cosCacheX22 * cosCacheY17 +
                        coeffs19 * cosCacheX22 * cosCacheY25 +
                        coeffs20 * cosCacheX22 * cosCacheY33 +
                        coeffs21 * cosCacheX22 * cosCacheY41 +
                        coeffs22 * cosCacheX22 * cosCacheY49 +
                        coeffs23 * cosCacheX22 * cosCacheY57 +
                        coeffs24 * cosCacheX30 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY9 +
                        coeffs26 * cosCacheX30 * cosCacheY17 +
                        coeffs27 * cosCacheX30 * cosCacheY25 +
                        coeffs28 * cosCacheX30 * cosCacheY33 +
                        coeffs29 * cosCacheX30 * cosCacheY41 +
                        coeffs30 * cosCacheX30 * cosCacheY49 +
                        coeffs31 * cosCacheX30 * cosCacheY57 +
                        coeffs32 * cosCacheX38 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY9 +
                        coeffs34 * cosCacheX38 * cosCacheY17 +
                        coeffs35 * cosCacheX38 * cosCacheY25 +
                        coeffs36 * cosCacheX38 * cosCacheY33 +
                        coeffs37 * cosCacheX38 * cosCacheY41 +
                        coeffs38 * cosCacheX38 * cosCacheY49 +
                        coeffs39 * cosCacheX38 * cosCacheY57 +
                        coeffs40 * cosCacheX46 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY9 +
                        coeffs42 * cosCacheX46 * cosCacheY17 +
                        coeffs43 * cosCacheX46 * cosCacheY25 +
                        coeffs44 * cosCacheX46 * cosCacheY33 +
                        coeffs45 * cosCacheX46 * cosCacheY41 +
                        coeffs46 * cosCacheX46 * cosCacheY49 +
                        coeffs47 * cosCacheX46 * cosCacheY57 +
                        coeffs48 * cosCacheX54 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY9 +
                        coeffs50 * cosCacheX54 * cosCacheY17 +
                        coeffs51 * cosCacheX54 * cosCacheY25 +
                        coeffs52 * cosCacheX54 * cosCacheY33 +
                        coeffs53 * cosCacheX54 * cosCacheY41 +
                        coeffs54 * cosCacheX54 * cosCacheY49 +
                        coeffs55 * cosCacheX54 * cosCacheY57 +
                        coeffs56 * cosCacheX62 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY9 +
                        coeffs58 * cosCacheX62 * cosCacheY17 +
                        coeffs59 * cosCacheX62 * cosCacheY25 +
                        coeffs60 * cosCacheX62 * cosCacheY33 +
                        coeffs61 * cosCacheX62 * cosCacheY41 +
                        coeffs62 * cosCacheX62 * cosCacheY49 +
                        coeffs63 * cosCacheX62 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 2] = (coeffs0 * cosCacheX6 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY10 +
                        coeffs10 * cosCacheX14 * cosCacheY18 +
                        coeffs11 * cosCacheX14 * cosCacheY26 +
                        coeffs12 * cosCacheX14 * cosCacheY34 +
                        coeffs13 * cosCacheX14 * cosCacheY42 +
                        coeffs14 * cosCacheX14 * cosCacheY50 +
                        coeffs15 * cosCacheX14 * cosCacheY58 +
                        coeffs16 * cosCacheX22 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY10 +
                        coeffs18 * cosCacheX22 * cosCacheY18 +
                        coeffs19 * cosCacheX22 * cosCacheY26 +
                        coeffs20 * cosCacheX22 * cosCacheY34 +
                        coeffs21 * cosCacheX22 * cosCacheY42 +
                        coeffs22 * cosCacheX22 * cosCacheY50 +
                        coeffs23 * cosCacheX22 * cosCacheY58 +
                        coeffs24 * cosCacheX30 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY10 +
                        coeffs26 * cosCacheX30 * cosCacheY18 +
                        coeffs27 * cosCacheX30 * cosCacheY26 +
                        coeffs28 * cosCacheX30 * cosCacheY34 +
                        coeffs29 * cosCacheX30 * cosCacheY42 +
                        coeffs30 * cosCacheX30 * cosCacheY50 +
                        coeffs31 * cosCacheX30 * cosCacheY58 +
                        coeffs32 * cosCacheX38 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY10 +
                        coeffs34 * cosCacheX38 * cosCacheY18 +
                        coeffs35 * cosCacheX38 * cosCacheY26 +
                        coeffs36 * cosCacheX38 * cosCacheY34 +
                        coeffs37 * cosCacheX38 * cosCacheY42 +
                        coeffs38 * cosCacheX38 * cosCacheY50 +
                        coeffs39 * cosCacheX38 * cosCacheY58 +
                        coeffs40 * cosCacheX46 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY10 +
                        coeffs42 * cosCacheX46 * cosCacheY18 +
                        coeffs43 * cosCacheX46 * cosCacheY26 +
                        coeffs44 * cosCacheX46 * cosCacheY34 +
                        coeffs45 * cosCacheX46 * cosCacheY42 +
                        coeffs46 * cosCacheX46 * cosCacheY50 +
                        coeffs47 * cosCacheX46 * cosCacheY58 +
                        coeffs48 * cosCacheX54 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY10 +
                        coeffs50 * cosCacheX54 * cosCacheY18 +
                        coeffs51 * cosCacheX54 * cosCacheY26 +
                        coeffs52 * cosCacheX54 * cosCacheY34 +
                        coeffs53 * cosCacheX54 * cosCacheY42 +
                        coeffs54 * cosCacheX54 * cosCacheY50 +
                        coeffs55 * cosCacheX54 * cosCacheY58 +
                        coeffs56 * cosCacheX62 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY10 +
                        coeffs58 * cosCacheX62 * cosCacheY18 +
                        coeffs59 * cosCacheX62 * cosCacheY26 +
                        coeffs60 * cosCacheX62 * cosCacheY34 +
                        coeffs61 * cosCacheX62 * cosCacheY42 +
                        coeffs62 * cosCacheX62 * cosCacheY50 +
                        coeffs63 * cosCacheX62 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 3] = (coeffs0 * cosCacheX6 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY11 +
                        coeffs10 * cosCacheX14 * cosCacheY19 +
                        coeffs11 * cosCacheX14 * cosCacheY27 +
                        coeffs12 * cosCacheX14 * cosCacheY35 +
                        coeffs13 * cosCacheX14 * cosCacheY43 +
                        coeffs14 * cosCacheX14 * cosCacheY51 +
                        coeffs15 * cosCacheX14 * cosCacheY59 +
                        coeffs16 * cosCacheX22 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY11 +
                        coeffs18 * cosCacheX22 * cosCacheY19 +
                        coeffs19 * cosCacheX22 * cosCacheY27 +
                        coeffs20 * cosCacheX22 * cosCacheY35 +
                        coeffs21 * cosCacheX22 * cosCacheY43 +
                        coeffs22 * cosCacheX22 * cosCacheY51 +
                        coeffs23 * cosCacheX22 * cosCacheY59 +
                        coeffs24 * cosCacheX30 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY11 +
                        coeffs26 * cosCacheX30 * cosCacheY19 +
                        coeffs27 * cosCacheX30 * cosCacheY27 +
                        coeffs28 * cosCacheX30 * cosCacheY35 +
                        coeffs29 * cosCacheX30 * cosCacheY43 +
                        coeffs30 * cosCacheX30 * cosCacheY51 +
                        coeffs31 * cosCacheX30 * cosCacheY59 +
                        coeffs32 * cosCacheX38 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY11 +
                        coeffs34 * cosCacheX38 * cosCacheY19 +
                        coeffs35 * cosCacheX38 * cosCacheY27 +
                        coeffs36 * cosCacheX38 * cosCacheY35 +
                        coeffs37 * cosCacheX38 * cosCacheY43 +
                        coeffs38 * cosCacheX38 * cosCacheY51 +
                        coeffs39 * cosCacheX38 * cosCacheY59 +
                        coeffs40 * cosCacheX46 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY11 +
                        coeffs42 * cosCacheX46 * cosCacheY19 +
                        coeffs43 * cosCacheX46 * cosCacheY27 +
                        coeffs44 * cosCacheX46 * cosCacheY35 +
                        coeffs45 * cosCacheX46 * cosCacheY43 +
                        coeffs46 * cosCacheX46 * cosCacheY51 +
                        coeffs47 * cosCacheX46 * cosCacheY59 +
                        coeffs48 * cosCacheX54 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY11 +
                        coeffs50 * cosCacheX54 * cosCacheY19 +
                        coeffs51 * cosCacheX54 * cosCacheY27 +
                        coeffs52 * cosCacheX54 * cosCacheY35 +
                        coeffs53 * cosCacheX54 * cosCacheY43 +
                        coeffs54 * cosCacheX54 * cosCacheY51 +
                        coeffs55 * cosCacheX54 * cosCacheY59 +
                        coeffs56 * cosCacheX62 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY11 +
                        coeffs58 * cosCacheX62 * cosCacheY19 +
                        coeffs59 * cosCacheX62 * cosCacheY27 +
                        coeffs60 * cosCacheX62 * cosCacheY35 +
                        coeffs61 * cosCacheX62 * cosCacheY43 +
                        coeffs62 * cosCacheX62 * cosCacheY51 +
                        coeffs63 * cosCacheX62 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 4] = (coeffs0 * cosCacheX6 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY12 +
                        coeffs10 * cosCacheX14 * cosCacheY20 +
                        coeffs11 * cosCacheX14 * cosCacheY28 +
                        coeffs12 * cosCacheX14 * cosCacheY36 +
                        coeffs13 * cosCacheX14 * cosCacheY44 +
                        coeffs14 * cosCacheX14 * cosCacheY52 +
                        coeffs15 * cosCacheX14 * cosCacheY60 +
                        coeffs16 * cosCacheX22 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY12 +
                        coeffs18 * cosCacheX22 * cosCacheY20 +
                        coeffs19 * cosCacheX22 * cosCacheY28 +
                        coeffs20 * cosCacheX22 * cosCacheY36 +
                        coeffs21 * cosCacheX22 * cosCacheY44 +
                        coeffs22 * cosCacheX22 * cosCacheY52 +
                        coeffs23 * cosCacheX22 * cosCacheY60 +
                        coeffs24 * cosCacheX30 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY12 +
                        coeffs26 * cosCacheX30 * cosCacheY20 +
                        coeffs27 * cosCacheX30 * cosCacheY28 +
                        coeffs28 * cosCacheX30 * cosCacheY36 +
                        coeffs29 * cosCacheX30 * cosCacheY44 +
                        coeffs30 * cosCacheX30 * cosCacheY52 +
                        coeffs31 * cosCacheX30 * cosCacheY60 +
                        coeffs32 * cosCacheX38 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY12 +
                        coeffs34 * cosCacheX38 * cosCacheY20 +
                        coeffs35 * cosCacheX38 * cosCacheY28 +
                        coeffs36 * cosCacheX38 * cosCacheY36 +
                        coeffs37 * cosCacheX38 * cosCacheY44 +
                        coeffs38 * cosCacheX38 * cosCacheY52 +
                        coeffs39 * cosCacheX38 * cosCacheY60 +
                        coeffs40 * cosCacheX46 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY12 +
                        coeffs42 * cosCacheX46 * cosCacheY20 +
                        coeffs43 * cosCacheX46 * cosCacheY28 +
                        coeffs44 * cosCacheX46 * cosCacheY36 +
                        coeffs45 * cosCacheX46 * cosCacheY44 +
                        coeffs46 * cosCacheX46 * cosCacheY52 +
                        coeffs47 * cosCacheX46 * cosCacheY60 +
                        coeffs48 * cosCacheX54 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY12 +
                        coeffs50 * cosCacheX54 * cosCacheY20 +
                        coeffs51 * cosCacheX54 * cosCacheY28 +
                        coeffs52 * cosCacheX54 * cosCacheY36 +
                        coeffs53 * cosCacheX54 * cosCacheY44 +
                        coeffs54 * cosCacheX54 * cosCacheY52 +
                        coeffs55 * cosCacheX54 * cosCacheY60 +
                        coeffs56 * cosCacheX62 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY12 +
                        coeffs58 * cosCacheX62 * cosCacheY20 +
                        coeffs59 * cosCacheX62 * cosCacheY28 +
                        coeffs60 * cosCacheX62 * cosCacheY36 +
                        coeffs61 * cosCacheX62 * cosCacheY44 +
                        coeffs62 * cosCacheX62 * cosCacheY52 +
                        coeffs63 * cosCacheX62 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 5] = (coeffs0 * cosCacheX6 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY13 +
                        coeffs10 * cosCacheX14 * cosCacheY21 +
                        coeffs11 * cosCacheX14 * cosCacheY29 +
                        coeffs12 * cosCacheX14 * cosCacheY37 +
                        coeffs13 * cosCacheX14 * cosCacheY45 +
                        coeffs14 * cosCacheX14 * cosCacheY53 +
                        coeffs15 * cosCacheX14 * cosCacheY61 +
                        coeffs16 * cosCacheX22 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY13 +
                        coeffs18 * cosCacheX22 * cosCacheY21 +
                        coeffs19 * cosCacheX22 * cosCacheY29 +
                        coeffs20 * cosCacheX22 * cosCacheY37 +
                        coeffs21 * cosCacheX22 * cosCacheY45 +
                        coeffs22 * cosCacheX22 * cosCacheY53 +
                        coeffs23 * cosCacheX22 * cosCacheY61 +
                        coeffs24 * cosCacheX30 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY13 +
                        coeffs26 * cosCacheX30 * cosCacheY21 +
                        coeffs27 * cosCacheX30 * cosCacheY29 +
                        coeffs28 * cosCacheX30 * cosCacheY37 +
                        coeffs29 * cosCacheX30 * cosCacheY45 +
                        coeffs30 * cosCacheX30 * cosCacheY53 +
                        coeffs31 * cosCacheX30 * cosCacheY61 +
                        coeffs32 * cosCacheX38 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY13 +
                        coeffs34 * cosCacheX38 * cosCacheY21 +
                        coeffs35 * cosCacheX38 * cosCacheY29 +
                        coeffs36 * cosCacheX38 * cosCacheY37 +
                        coeffs37 * cosCacheX38 * cosCacheY45 +
                        coeffs38 * cosCacheX38 * cosCacheY53 +
                        coeffs39 * cosCacheX38 * cosCacheY61 +
                        coeffs40 * cosCacheX46 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY13 +
                        coeffs42 * cosCacheX46 * cosCacheY21 +
                        coeffs43 * cosCacheX46 * cosCacheY29 +
                        coeffs44 * cosCacheX46 * cosCacheY37 +
                        coeffs45 * cosCacheX46 * cosCacheY45 +
                        coeffs46 * cosCacheX46 * cosCacheY53 +
                        coeffs47 * cosCacheX46 * cosCacheY61 +
                        coeffs48 * cosCacheX54 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY13 +
                        coeffs50 * cosCacheX54 * cosCacheY21 +
                        coeffs51 * cosCacheX54 * cosCacheY29 +
                        coeffs52 * cosCacheX54 * cosCacheY37 +
                        coeffs53 * cosCacheX54 * cosCacheY45 +
                        coeffs54 * cosCacheX54 * cosCacheY53 +
                        coeffs55 * cosCacheX54 * cosCacheY61 +
                        coeffs56 * cosCacheX62 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY13 +
                        coeffs58 * cosCacheX62 * cosCacheY21 +
                        coeffs59 * cosCacheX62 * cosCacheY29 +
                        coeffs60 * cosCacheX62 * cosCacheY37 +
                        coeffs61 * cosCacheX62 * cosCacheY45 +
                        coeffs62 * cosCacheX62 * cosCacheY53 +
                        coeffs63 * cosCacheX62 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 6] = (coeffs0 * cosCacheX6 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY14 +
                        coeffs10 * cosCacheX14 * cosCacheY22 +
                        coeffs11 * cosCacheX14 * cosCacheY30 +
                        coeffs12 * cosCacheX14 * cosCacheY38 +
                        coeffs13 * cosCacheX14 * cosCacheY46 +
                        coeffs14 * cosCacheX14 * cosCacheY54 +
                        coeffs15 * cosCacheX14 * cosCacheY62 +
                        coeffs16 * cosCacheX22 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY14 +
                        coeffs18 * cosCacheX22 * cosCacheY22 +
                        coeffs19 * cosCacheX22 * cosCacheY30 +
                        coeffs20 * cosCacheX22 * cosCacheY38 +
                        coeffs21 * cosCacheX22 * cosCacheY46 +
                        coeffs22 * cosCacheX22 * cosCacheY54 +
                        coeffs23 * cosCacheX22 * cosCacheY62 +
                        coeffs24 * cosCacheX30 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY14 +
                        coeffs26 * cosCacheX30 * cosCacheY22 +
                        coeffs27 * cosCacheX30 * cosCacheY30 +
                        coeffs28 * cosCacheX30 * cosCacheY38 +
                        coeffs29 * cosCacheX30 * cosCacheY46 +
                        coeffs30 * cosCacheX30 * cosCacheY54 +
                        coeffs31 * cosCacheX30 * cosCacheY62 +
                        coeffs32 * cosCacheX38 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY14 +
                        coeffs34 * cosCacheX38 * cosCacheY22 +
                        coeffs35 * cosCacheX38 * cosCacheY30 +
                        coeffs36 * cosCacheX38 * cosCacheY38 +
                        coeffs37 * cosCacheX38 * cosCacheY46 +
                        coeffs38 * cosCacheX38 * cosCacheY54 +
                        coeffs39 * cosCacheX38 * cosCacheY62 +
                        coeffs40 * cosCacheX46 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY14 +
                        coeffs42 * cosCacheX46 * cosCacheY22 +
                        coeffs43 * cosCacheX46 * cosCacheY30 +
                        coeffs44 * cosCacheX46 * cosCacheY38 +
                        coeffs45 * cosCacheX46 * cosCacheY46 +
                        coeffs46 * cosCacheX46 * cosCacheY54 +
                        coeffs47 * cosCacheX46 * cosCacheY62 +
                        coeffs48 * cosCacheX54 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY14 +
                        coeffs50 * cosCacheX54 * cosCacheY22 +
                        coeffs51 * cosCacheX54 * cosCacheY30 +
                        coeffs52 * cosCacheX54 * cosCacheY38 +
                        coeffs53 * cosCacheX54 * cosCacheY46 +
                        coeffs54 * cosCacheX54 * cosCacheY54 +
                        coeffs55 * cosCacheX54 * cosCacheY62 +
                        coeffs56 * cosCacheX62 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY14 +
                        coeffs58 * cosCacheX62 * cosCacheY22 +
                        coeffs59 * cosCacheX62 * cosCacheY30 +
                        coeffs60 * cosCacheX62 * cosCacheY38 +
                        coeffs61 * cosCacheX62 * cosCacheY46 +
                        coeffs62 * cosCacheX62 * cosCacheY54 +
                        coeffs63 * cosCacheX62 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 7] = (coeffs0 * cosCacheX6 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX6 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX6 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX6 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX6 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX6 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX6 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX6 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX14 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX14 * cosCacheY15 +
                        coeffs10 * cosCacheX14 * cosCacheY23 +
                        coeffs11 * cosCacheX14 * cosCacheY31 +
                        coeffs12 * cosCacheX14 * cosCacheY39 +
                        coeffs13 * cosCacheX14 * cosCacheY47 +
                        coeffs14 * cosCacheX14 * cosCacheY55 +
                        coeffs15 * cosCacheX14 * cosCacheY63 +
                        coeffs16 * cosCacheX22 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX22 * cosCacheY15 +
                        coeffs18 * cosCacheX22 * cosCacheY23 +
                        coeffs19 * cosCacheX22 * cosCacheY31 +
                        coeffs20 * cosCacheX22 * cosCacheY39 +
                        coeffs21 * cosCacheX22 * cosCacheY47 +
                        coeffs22 * cosCacheX22 * cosCacheY55 +
                        coeffs23 * cosCacheX22 * cosCacheY63 +
                        coeffs24 * cosCacheX30 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX30 * cosCacheY15 +
                        coeffs26 * cosCacheX30 * cosCacheY23 +
                        coeffs27 * cosCacheX30 * cosCacheY31 +
                        coeffs28 * cosCacheX30 * cosCacheY39 +
                        coeffs29 * cosCacheX30 * cosCacheY47 +
                        coeffs30 * cosCacheX30 * cosCacheY55 +
                        coeffs31 * cosCacheX30 * cosCacheY63 +
                        coeffs32 * cosCacheX38 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX38 * cosCacheY15 +
                        coeffs34 * cosCacheX38 * cosCacheY23 +
                        coeffs35 * cosCacheX38 * cosCacheY31 +
                        coeffs36 * cosCacheX38 * cosCacheY39 +
                        coeffs37 * cosCacheX38 * cosCacheY47 +
                        coeffs38 * cosCacheX38 * cosCacheY55 +
                        coeffs39 * cosCacheX38 * cosCacheY63 +
                        coeffs40 * cosCacheX46 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX46 * cosCacheY15 +
                        coeffs42 * cosCacheX46 * cosCacheY23 +
                        coeffs43 * cosCacheX46 * cosCacheY31 +
                        coeffs44 * cosCacheX46 * cosCacheY39 +
                        coeffs45 * cosCacheX46 * cosCacheY47 +
                        coeffs46 * cosCacheX46 * cosCacheY55 +
                        coeffs47 * cosCacheX46 * cosCacheY63 +
                        coeffs48 * cosCacheX54 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX54 * cosCacheY15 +
                        coeffs50 * cosCacheX54 * cosCacheY23 +
                        coeffs51 * cosCacheX54 * cosCacheY31 +
                        coeffs52 * cosCacheX54 * cosCacheY39 +
                        coeffs53 * cosCacheX54 * cosCacheY47 +
                        coeffs54 * cosCacheX54 * cosCacheY55 +
                        coeffs55 * cosCacheX54 * cosCacheY63 +
                        coeffs56 * cosCacheX62 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX62 * cosCacheY15 +
                        coeffs58 * cosCacheX62 * cosCacheY23 +
                        coeffs59 * cosCacheX62 * cosCacheY31 +
                        coeffs60 * cosCacheX62 * cosCacheY39 +
                        coeffs61 * cosCacheX62 * cosCacheY47 +
                        coeffs62 * cosCacheX62 * cosCacheY55 +
                        coeffs63 * cosCacheX62 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 0] = (coeffs0 * cosCacheX7 * cosCacheY0 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY8 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY16 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY24 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY32 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY40 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY48 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY56 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY0 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY8 +
                        coeffs10 * cosCacheX15 * cosCacheY16 +
                        coeffs11 * cosCacheX15 * cosCacheY24 +
                        coeffs12 * cosCacheX15 * cosCacheY32 +
                        coeffs13 * cosCacheX15 * cosCacheY40 +
                        coeffs14 * cosCacheX15 * cosCacheY48 +
                        coeffs15 * cosCacheX15 * cosCacheY56 +
                        coeffs16 * cosCacheX23 * cosCacheY0 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY8 +
                        coeffs18 * cosCacheX23 * cosCacheY16 +
                        coeffs19 * cosCacheX23 * cosCacheY24 +
                        coeffs20 * cosCacheX23 * cosCacheY32 +
                        coeffs21 * cosCacheX23 * cosCacheY40 +
                        coeffs22 * cosCacheX23 * cosCacheY48 +
                        coeffs23 * cosCacheX23 * cosCacheY56 +
                        coeffs24 * cosCacheX31 * cosCacheY0 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY8 +
                        coeffs26 * cosCacheX31 * cosCacheY16 +
                        coeffs27 * cosCacheX31 * cosCacheY24 +
                        coeffs28 * cosCacheX31 * cosCacheY32 +
                        coeffs29 * cosCacheX31 * cosCacheY40 +
                        coeffs30 * cosCacheX31 * cosCacheY48 +
                        coeffs31 * cosCacheX31 * cosCacheY56 +
                        coeffs32 * cosCacheX39 * cosCacheY0 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY8 +
                        coeffs34 * cosCacheX39 * cosCacheY16 +
                        coeffs35 * cosCacheX39 * cosCacheY24 +
                        coeffs36 * cosCacheX39 * cosCacheY32 +
                        coeffs37 * cosCacheX39 * cosCacheY40 +
                        coeffs38 * cosCacheX39 * cosCacheY48 +
                        coeffs39 * cosCacheX39 * cosCacheY56 +
                        coeffs40 * cosCacheX47 * cosCacheY0 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY8 +
                        coeffs42 * cosCacheX47 * cosCacheY16 +
                        coeffs43 * cosCacheX47 * cosCacheY24 +
                        coeffs44 * cosCacheX47 * cosCacheY32 +
                        coeffs45 * cosCacheX47 * cosCacheY40 +
                        coeffs46 * cosCacheX47 * cosCacheY48 +
                        coeffs47 * cosCacheX47 * cosCacheY56 +
                        coeffs48 * cosCacheX55 * cosCacheY0 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY8 +
                        coeffs50 * cosCacheX55 * cosCacheY16 +
                        coeffs51 * cosCacheX55 * cosCacheY24 +
                        coeffs52 * cosCacheX55 * cosCacheY32 +
                        coeffs53 * cosCacheX55 * cosCacheY40 +
                        coeffs54 * cosCacheX55 * cosCacheY48 +
                        coeffs55 * cosCacheX55 * cosCacheY56 +
                        coeffs56 * cosCacheX63 * cosCacheY0 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY8 +
                        coeffs58 * cosCacheX63 * cosCacheY16 +
                        coeffs59 * cosCacheX63 * cosCacheY24 +
                        coeffs60 * cosCacheX63 * cosCacheY32 +
                        coeffs61 * cosCacheX63 * cosCacheY40 +
                        coeffs62 * cosCacheX63 * cosCacheY48 +
                        coeffs63 * cosCacheX63 * cosCacheY56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 1] = (coeffs0 * cosCacheX7 * cosCacheY1 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY9 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY17 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY25 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY33 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY41 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY49 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY57 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY1 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY9 +
                        coeffs10 * cosCacheX15 * cosCacheY17 +
                        coeffs11 * cosCacheX15 * cosCacheY25 +
                        coeffs12 * cosCacheX15 * cosCacheY33 +
                        coeffs13 * cosCacheX15 * cosCacheY41 +
                        coeffs14 * cosCacheX15 * cosCacheY49 +
                        coeffs15 * cosCacheX15 * cosCacheY57 +
                        coeffs16 * cosCacheX23 * cosCacheY1 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY9 +
                        coeffs18 * cosCacheX23 * cosCacheY17 +
                        coeffs19 * cosCacheX23 * cosCacheY25 +
                        coeffs20 * cosCacheX23 * cosCacheY33 +
                        coeffs21 * cosCacheX23 * cosCacheY41 +
                        coeffs22 * cosCacheX23 * cosCacheY49 +
                        coeffs23 * cosCacheX23 * cosCacheY57 +
                        coeffs24 * cosCacheX31 * cosCacheY1 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY9 +
                        coeffs26 * cosCacheX31 * cosCacheY17 +
                        coeffs27 * cosCacheX31 * cosCacheY25 +
                        coeffs28 * cosCacheX31 * cosCacheY33 +
                        coeffs29 * cosCacheX31 * cosCacheY41 +
                        coeffs30 * cosCacheX31 * cosCacheY49 +
                        coeffs31 * cosCacheX31 * cosCacheY57 +
                        coeffs32 * cosCacheX39 * cosCacheY1 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY9 +
                        coeffs34 * cosCacheX39 * cosCacheY17 +
                        coeffs35 * cosCacheX39 * cosCacheY25 +
                        coeffs36 * cosCacheX39 * cosCacheY33 +
                        coeffs37 * cosCacheX39 * cosCacheY41 +
                        coeffs38 * cosCacheX39 * cosCacheY49 +
                        coeffs39 * cosCacheX39 * cosCacheY57 +
                        coeffs40 * cosCacheX47 * cosCacheY1 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY9 +
                        coeffs42 * cosCacheX47 * cosCacheY17 +
                        coeffs43 * cosCacheX47 * cosCacheY25 +
                        coeffs44 * cosCacheX47 * cosCacheY33 +
                        coeffs45 * cosCacheX47 * cosCacheY41 +
                        coeffs46 * cosCacheX47 * cosCacheY49 +
                        coeffs47 * cosCacheX47 * cosCacheY57 +
                        coeffs48 * cosCacheX55 * cosCacheY1 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY9 +
                        coeffs50 * cosCacheX55 * cosCacheY17 +
                        coeffs51 * cosCacheX55 * cosCacheY25 +
                        coeffs52 * cosCacheX55 * cosCacheY33 +
                        coeffs53 * cosCacheX55 * cosCacheY41 +
                        coeffs54 * cosCacheX55 * cosCacheY49 +
                        coeffs55 * cosCacheX55 * cosCacheY57 +
                        coeffs56 * cosCacheX63 * cosCacheY1 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY9 +
                        coeffs58 * cosCacheX63 * cosCacheY17 +
                        coeffs59 * cosCacheX63 * cosCacheY25 +
                        coeffs60 * cosCacheX63 * cosCacheY33 +
                        coeffs61 * cosCacheX63 * cosCacheY41 +
                        coeffs62 * cosCacheX63 * cosCacheY49 +
                        coeffs63 * cosCacheX63 * cosCacheY57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 2] = (coeffs0 * cosCacheX7 * cosCacheY2 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY10 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY18 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY26 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY34 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY42 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY50 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY58 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY2 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY10 +
                        coeffs10 * cosCacheX15 * cosCacheY18 +
                        coeffs11 * cosCacheX15 * cosCacheY26 +
                        coeffs12 * cosCacheX15 * cosCacheY34 +
                        coeffs13 * cosCacheX15 * cosCacheY42 +
                        coeffs14 * cosCacheX15 * cosCacheY50 +
                        coeffs15 * cosCacheX15 * cosCacheY58 +
                        coeffs16 * cosCacheX23 * cosCacheY2 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY10 +
                        coeffs18 * cosCacheX23 * cosCacheY18 +
                        coeffs19 * cosCacheX23 * cosCacheY26 +
                        coeffs20 * cosCacheX23 * cosCacheY34 +
                        coeffs21 * cosCacheX23 * cosCacheY42 +
                        coeffs22 * cosCacheX23 * cosCacheY50 +
                        coeffs23 * cosCacheX23 * cosCacheY58 +
                        coeffs24 * cosCacheX31 * cosCacheY2 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY10 +
                        coeffs26 * cosCacheX31 * cosCacheY18 +
                        coeffs27 * cosCacheX31 * cosCacheY26 +
                        coeffs28 * cosCacheX31 * cosCacheY34 +
                        coeffs29 * cosCacheX31 * cosCacheY42 +
                        coeffs30 * cosCacheX31 * cosCacheY50 +
                        coeffs31 * cosCacheX31 * cosCacheY58 +
                        coeffs32 * cosCacheX39 * cosCacheY2 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY10 +
                        coeffs34 * cosCacheX39 * cosCacheY18 +
                        coeffs35 * cosCacheX39 * cosCacheY26 +
                        coeffs36 * cosCacheX39 * cosCacheY34 +
                        coeffs37 * cosCacheX39 * cosCacheY42 +
                        coeffs38 * cosCacheX39 * cosCacheY50 +
                        coeffs39 * cosCacheX39 * cosCacheY58 +
                        coeffs40 * cosCacheX47 * cosCacheY2 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY10 +
                        coeffs42 * cosCacheX47 * cosCacheY18 +
                        coeffs43 * cosCacheX47 * cosCacheY26 +
                        coeffs44 * cosCacheX47 * cosCacheY34 +
                        coeffs45 * cosCacheX47 * cosCacheY42 +
                        coeffs46 * cosCacheX47 * cosCacheY50 +
                        coeffs47 * cosCacheX47 * cosCacheY58 +
                        coeffs48 * cosCacheX55 * cosCacheY2 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY10 +
                        coeffs50 * cosCacheX55 * cosCacheY18 +
                        coeffs51 * cosCacheX55 * cosCacheY26 +
                        coeffs52 * cosCacheX55 * cosCacheY34 +
                        coeffs53 * cosCacheX55 * cosCacheY42 +
                        coeffs54 * cosCacheX55 * cosCacheY50 +
                        coeffs55 * cosCacheX55 * cosCacheY58 +
                        coeffs56 * cosCacheX63 * cosCacheY2 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY10 +
                        coeffs58 * cosCacheX63 * cosCacheY18 +
                        coeffs59 * cosCacheX63 * cosCacheY26 +
                        coeffs60 * cosCacheX63 * cosCacheY34 +
                        coeffs61 * cosCacheX63 * cosCacheY42 +
                        coeffs62 * cosCacheX63 * cosCacheY50 +
                        coeffs63 * cosCacheX63 * cosCacheY58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 3] = (coeffs0 * cosCacheX7 * cosCacheY3 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY11 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY19 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY27 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY35 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY43 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY51 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY59 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY3 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY11 +
                        coeffs10 * cosCacheX15 * cosCacheY19 +
                        coeffs11 * cosCacheX15 * cosCacheY27 +
                        coeffs12 * cosCacheX15 * cosCacheY35 +
                        coeffs13 * cosCacheX15 * cosCacheY43 +
                        coeffs14 * cosCacheX15 * cosCacheY51 +
                        coeffs15 * cosCacheX15 * cosCacheY59 +
                        coeffs16 * cosCacheX23 * cosCacheY3 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY11 +
                        coeffs18 * cosCacheX23 * cosCacheY19 +
                        coeffs19 * cosCacheX23 * cosCacheY27 +
                        coeffs20 * cosCacheX23 * cosCacheY35 +
                        coeffs21 * cosCacheX23 * cosCacheY43 +
                        coeffs22 * cosCacheX23 * cosCacheY51 +
                        coeffs23 * cosCacheX23 * cosCacheY59 +
                        coeffs24 * cosCacheX31 * cosCacheY3 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY11 +
                        coeffs26 * cosCacheX31 * cosCacheY19 +
                        coeffs27 * cosCacheX31 * cosCacheY27 +
                        coeffs28 * cosCacheX31 * cosCacheY35 +
                        coeffs29 * cosCacheX31 * cosCacheY43 +
                        coeffs30 * cosCacheX31 * cosCacheY51 +
                        coeffs31 * cosCacheX31 * cosCacheY59 +
                        coeffs32 * cosCacheX39 * cosCacheY3 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY11 +
                        coeffs34 * cosCacheX39 * cosCacheY19 +
                        coeffs35 * cosCacheX39 * cosCacheY27 +
                        coeffs36 * cosCacheX39 * cosCacheY35 +
                        coeffs37 * cosCacheX39 * cosCacheY43 +
                        coeffs38 * cosCacheX39 * cosCacheY51 +
                        coeffs39 * cosCacheX39 * cosCacheY59 +
                        coeffs40 * cosCacheX47 * cosCacheY3 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY11 +
                        coeffs42 * cosCacheX47 * cosCacheY19 +
                        coeffs43 * cosCacheX47 * cosCacheY27 +
                        coeffs44 * cosCacheX47 * cosCacheY35 +
                        coeffs45 * cosCacheX47 * cosCacheY43 +
                        coeffs46 * cosCacheX47 * cosCacheY51 +
                        coeffs47 * cosCacheX47 * cosCacheY59 +
                        coeffs48 * cosCacheX55 * cosCacheY3 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY11 +
                        coeffs50 * cosCacheX55 * cosCacheY19 +
                        coeffs51 * cosCacheX55 * cosCacheY27 +
                        coeffs52 * cosCacheX55 * cosCacheY35 +
                        coeffs53 * cosCacheX55 * cosCacheY43 +
                        coeffs54 * cosCacheX55 * cosCacheY51 +
                        coeffs55 * cosCacheX55 * cosCacheY59 +
                        coeffs56 * cosCacheX63 * cosCacheY3 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY11 +
                        coeffs58 * cosCacheX63 * cosCacheY19 +
                        coeffs59 * cosCacheX63 * cosCacheY27 +
                        coeffs60 * cosCacheX63 * cosCacheY35 +
                        coeffs61 * cosCacheX63 * cosCacheY43 +
                        coeffs62 * cosCacheX63 * cosCacheY51 +
                        coeffs63 * cosCacheX63 * cosCacheY59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 4] = (coeffs0 * cosCacheX7 * cosCacheY4 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY12 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY20 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY28 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY36 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY44 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY52 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY60 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY4 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY12 +
                        coeffs10 * cosCacheX15 * cosCacheY20 +
                        coeffs11 * cosCacheX15 * cosCacheY28 +
                        coeffs12 * cosCacheX15 * cosCacheY36 +
                        coeffs13 * cosCacheX15 * cosCacheY44 +
                        coeffs14 * cosCacheX15 * cosCacheY52 +
                        coeffs15 * cosCacheX15 * cosCacheY60 +
                        coeffs16 * cosCacheX23 * cosCacheY4 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY12 +
                        coeffs18 * cosCacheX23 * cosCacheY20 +
                        coeffs19 * cosCacheX23 * cosCacheY28 +
                        coeffs20 * cosCacheX23 * cosCacheY36 +
                        coeffs21 * cosCacheX23 * cosCacheY44 +
                        coeffs22 * cosCacheX23 * cosCacheY52 +
                        coeffs23 * cosCacheX23 * cosCacheY60 +
                        coeffs24 * cosCacheX31 * cosCacheY4 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY12 +
                        coeffs26 * cosCacheX31 * cosCacheY20 +
                        coeffs27 * cosCacheX31 * cosCacheY28 +
                        coeffs28 * cosCacheX31 * cosCacheY36 +
                        coeffs29 * cosCacheX31 * cosCacheY44 +
                        coeffs30 * cosCacheX31 * cosCacheY52 +
                        coeffs31 * cosCacheX31 * cosCacheY60 +
                        coeffs32 * cosCacheX39 * cosCacheY4 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY12 +
                        coeffs34 * cosCacheX39 * cosCacheY20 +
                        coeffs35 * cosCacheX39 * cosCacheY28 +
                        coeffs36 * cosCacheX39 * cosCacheY36 +
                        coeffs37 * cosCacheX39 * cosCacheY44 +
                        coeffs38 * cosCacheX39 * cosCacheY52 +
                        coeffs39 * cosCacheX39 * cosCacheY60 +
                        coeffs40 * cosCacheX47 * cosCacheY4 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY12 +
                        coeffs42 * cosCacheX47 * cosCacheY20 +
                        coeffs43 * cosCacheX47 * cosCacheY28 +
                        coeffs44 * cosCacheX47 * cosCacheY36 +
                        coeffs45 * cosCacheX47 * cosCacheY44 +
                        coeffs46 * cosCacheX47 * cosCacheY52 +
                        coeffs47 * cosCacheX47 * cosCacheY60 +
                        coeffs48 * cosCacheX55 * cosCacheY4 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY12 +
                        coeffs50 * cosCacheX55 * cosCacheY20 +
                        coeffs51 * cosCacheX55 * cosCacheY28 +
                        coeffs52 * cosCacheX55 * cosCacheY36 +
                        coeffs53 * cosCacheX55 * cosCacheY44 +
                        coeffs54 * cosCacheX55 * cosCacheY52 +
                        coeffs55 * cosCacheX55 * cosCacheY60 +
                        coeffs56 * cosCacheX63 * cosCacheY4 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY12 +
                        coeffs58 * cosCacheX63 * cosCacheY20 +
                        coeffs59 * cosCacheX63 * cosCacheY28 +
                        coeffs60 * cosCacheX63 * cosCacheY36 +
                        coeffs61 * cosCacheX63 * cosCacheY44 +
                        coeffs62 * cosCacheX63 * cosCacheY52 +
                        coeffs63 * cosCacheX63 * cosCacheY60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 5] = (coeffs0 * cosCacheX7 * cosCacheY5 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY13 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY21 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY29 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY37 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY45 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY53 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY61 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY5 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY13 +
                        coeffs10 * cosCacheX15 * cosCacheY21 +
                        coeffs11 * cosCacheX15 * cosCacheY29 +
                        coeffs12 * cosCacheX15 * cosCacheY37 +
                        coeffs13 * cosCacheX15 * cosCacheY45 +
                        coeffs14 * cosCacheX15 * cosCacheY53 +
                        coeffs15 * cosCacheX15 * cosCacheY61 +
                        coeffs16 * cosCacheX23 * cosCacheY5 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY13 +
                        coeffs18 * cosCacheX23 * cosCacheY21 +
                        coeffs19 * cosCacheX23 * cosCacheY29 +
                        coeffs20 * cosCacheX23 * cosCacheY37 +
                        coeffs21 * cosCacheX23 * cosCacheY45 +
                        coeffs22 * cosCacheX23 * cosCacheY53 +
                        coeffs23 * cosCacheX23 * cosCacheY61 +
                        coeffs24 * cosCacheX31 * cosCacheY5 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY13 +
                        coeffs26 * cosCacheX31 * cosCacheY21 +
                        coeffs27 * cosCacheX31 * cosCacheY29 +
                        coeffs28 * cosCacheX31 * cosCacheY37 +
                        coeffs29 * cosCacheX31 * cosCacheY45 +
                        coeffs30 * cosCacheX31 * cosCacheY53 +
                        coeffs31 * cosCacheX31 * cosCacheY61 +
                        coeffs32 * cosCacheX39 * cosCacheY5 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY13 +
                        coeffs34 * cosCacheX39 * cosCacheY21 +
                        coeffs35 * cosCacheX39 * cosCacheY29 +
                        coeffs36 * cosCacheX39 * cosCacheY37 +
                        coeffs37 * cosCacheX39 * cosCacheY45 +
                        coeffs38 * cosCacheX39 * cosCacheY53 +
                        coeffs39 * cosCacheX39 * cosCacheY61 +
                        coeffs40 * cosCacheX47 * cosCacheY5 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY13 +
                        coeffs42 * cosCacheX47 * cosCacheY21 +
                        coeffs43 * cosCacheX47 * cosCacheY29 +
                        coeffs44 * cosCacheX47 * cosCacheY37 +
                        coeffs45 * cosCacheX47 * cosCacheY45 +
                        coeffs46 * cosCacheX47 * cosCacheY53 +
                        coeffs47 * cosCacheX47 * cosCacheY61 +
                        coeffs48 * cosCacheX55 * cosCacheY5 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY13 +
                        coeffs50 * cosCacheX55 * cosCacheY21 +
                        coeffs51 * cosCacheX55 * cosCacheY29 +
                        coeffs52 * cosCacheX55 * cosCacheY37 +
                        coeffs53 * cosCacheX55 * cosCacheY45 +
                        coeffs54 * cosCacheX55 * cosCacheY53 +
                        coeffs55 * cosCacheX55 * cosCacheY61 +
                        coeffs56 * cosCacheX63 * cosCacheY5 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY13 +
                        coeffs58 * cosCacheX63 * cosCacheY21 +
                        coeffs59 * cosCacheX63 * cosCacheY29 +
                        coeffs60 * cosCacheX63 * cosCacheY37 +
                        coeffs61 * cosCacheX63 * cosCacheY45 +
                        coeffs62 * cosCacheX63 * cosCacheY53 +
                        coeffs63 * cosCacheX63 * cosCacheY61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 6] = (coeffs0 * cosCacheX7 * cosCacheY6 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY14 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY22 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY30 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY38 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY46 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY54 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY62 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY6 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY14 +
                        coeffs10 * cosCacheX15 * cosCacheY22 +
                        coeffs11 * cosCacheX15 * cosCacheY30 +
                        coeffs12 * cosCacheX15 * cosCacheY38 +
                        coeffs13 * cosCacheX15 * cosCacheY46 +
                        coeffs14 * cosCacheX15 * cosCacheY54 +
                        coeffs15 * cosCacheX15 * cosCacheY62 +
                        coeffs16 * cosCacheX23 * cosCacheY6 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY14 +
                        coeffs18 * cosCacheX23 * cosCacheY22 +
                        coeffs19 * cosCacheX23 * cosCacheY30 +
                        coeffs20 * cosCacheX23 * cosCacheY38 +
                        coeffs21 * cosCacheX23 * cosCacheY46 +
                        coeffs22 * cosCacheX23 * cosCacheY54 +
                        coeffs23 * cosCacheX23 * cosCacheY62 +
                        coeffs24 * cosCacheX31 * cosCacheY6 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY14 +
                        coeffs26 * cosCacheX31 * cosCacheY22 +
                        coeffs27 * cosCacheX31 * cosCacheY30 +
                        coeffs28 * cosCacheX31 * cosCacheY38 +
                        coeffs29 * cosCacheX31 * cosCacheY46 +
                        coeffs30 * cosCacheX31 * cosCacheY54 +
                        coeffs31 * cosCacheX31 * cosCacheY62 +
                        coeffs32 * cosCacheX39 * cosCacheY6 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY14 +
                        coeffs34 * cosCacheX39 * cosCacheY22 +
                        coeffs35 * cosCacheX39 * cosCacheY30 +
                        coeffs36 * cosCacheX39 * cosCacheY38 +
                        coeffs37 * cosCacheX39 * cosCacheY46 +
                        coeffs38 * cosCacheX39 * cosCacheY54 +
                        coeffs39 * cosCacheX39 * cosCacheY62 +
                        coeffs40 * cosCacheX47 * cosCacheY6 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY14 +
                        coeffs42 * cosCacheX47 * cosCacheY22 +
                        coeffs43 * cosCacheX47 * cosCacheY30 +
                        coeffs44 * cosCacheX47 * cosCacheY38 +
                        coeffs45 * cosCacheX47 * cosCacheY46 +
                        coeffs46 * cosCacheX47 * cosCacheY54 +
                        coeffs47 * cosCacheX47 * cosCacheY62 +
                        coeffs48 * cosCacheX55 * cosCacheY6 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY14 +
                        coeffs50 * cosCacheX55 * cosCacheY22 +
                        coeffs51 * cosCacheX55 * cosCacheY30 +
                        coeffs52 * cosCacheX55 * cosCacheY38 +
                        coeffs53 * cosCacheX55 * cosCacheY46 +
                        coeffs54 * cosCacheX55 * cosCacheY54 +
                        coeffs55 * cosCacheX55 * cosCacheY62 +
                        coeffs56 * cosCacheX63 * cosCacheY6 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY14 +
                        coeffs58 * cosCacheX63 * cosCacheY22 +
                        coeffs59 * cosCacheX63 * cosCacheY30 +
                        coeffs60 * cosCacheX63 * cosCacheY38 +
                        coeffs61 * cosCacheX63 * cosCacheY46 +
                        coeffs62 * cosCacheX63 * cosCacheY54 +
                        coeffs63 * cosCacheX63 * cosCacheY62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 7] = (coeffs0 * cosCacheX7 * cosCacheY7 * Alpha * Alpha +
                        coeffs1 * cosCacheX7 * cosCacheY15 * Alpha +
                        coeffs2 * cosCacheX7 * cosCacheY23 * Alpha +
                        coeffs3 * cosCacheX7 * cosCacheY31 * Alpha +
                        coeffs4 * cosCacheX7 * cosCacheY39 * Alpha +
                        coeffs5 * cosCacheX7 * cosCacheY47 * Alpha +
                        coeffs6 * cosCacheX7 * cosCacheY55 * Alpha +
                        coeffs7 * cosCacheX7 * cosCacheY63 * Alpha +
                        coeffs8 * cosCacheX15 * cosCacheY7 * Alpha +
                        coeffs9 * cosCacheX15 * cosCacheY15 +
                        coeffs10 * cosCacheX15 * cosCacheY23 +
                        coeffs11 * cosCacheX15 * cosCacheY31 +
                        coeffs12 * cosCacheX15 * cosCacheY39 +
                        coeffs13 * cosCacheX15 * cosCacheY47 +
                        coeffs14 * cosCacheX15 * cosCacheY55 +
                        coeffs15 * cosCacheX15 * cosCacheY63 +
                        coeffs16 * cosCacheX23 * cosCacheY7 * Alpha +
                        coeffs17 * cosCacheX23 * cosCacheY15 +
                        coeffs18 * cosCacheX23 * cosCacheY23 +
                        coeffs19 * cosCacheX23 * cosCacheY31 +
                        coeffs20 * cosCacheX23 * cosCacheY39 +
                        coeffs21 * cosCacheX23 * cosCacheY47 +
                        coeffs22 * cosCacheX23 * cosCacheY55 +
                        coeffs23 * cosCacheX23 * cosCacheY63 +
                        coeffs24 * cosCacheX31 * cosCacheY7 * Alpha +
                        coeffs25 * cosCacheX31 * cosCacheY15 +
                        coeffs26 * cosCacheX31 * cosCacheY23 +
                        coeffs27 * cosCacheX31 * cosCacheY31 +
                        coeffs28 * cosCacheX31 * cosCacheY39 +
                        coeffs29 * cosCacheX31 * cosCacheY47 +
                        coeffs30 * cosCacheX31 * cosCacheY55 +
                        coeffs31 * cosCacheX31 * cosCacheY63 +
                        coeffs32 * cosCacheX39 * cosCacheY7 * Alpha +
                        coeffs33 * cosCacheX39 * cosCacheY15 +
                        coeffs34 * cosCacheX39 * cosCacheY23 +
                        coeffs35 * cosCacheX39 * cosCacheY31 +
                        coeffs36 * cosCacheX39 * cosCacheY39 +
                        coeffs37 * cosCacheX39 * cosCacheY47 +
                        coeffs38 * cosCacheX39 * cosCacheY55 +
                        coeffs39 * cosCacheX39 * cosCacheY63 +
                        coeffs40 * cosCacheX47 * cosCacheY7 * Alpha +
                        coeffs41 * cosCacheX47 * cosCacheY15 +
                        coeffs42 * cosCacheX47 * cosCacheY23 +
                        coeffs43 * cosCacheX47 * cosCacheY31 +
                        coeffs44 * cosCacheX47 * cosCacheY39 +
                        coeffs45 * cosCacheX47 * cosCacheY47 +
                        coeffs46 * cosCacheX47 * cosCacheY55 +
                        coeffs47 * cosCacheX47 * cosCacheY63 +
                        coeffs48 * cosCacheX55 * cosCacheY7 * Alpha +
                        coeffs49 * cosCacheX55 * cosCacheY15 +
                        coeffs50 * cosCacheX55 * cosCacheY23 +
                        coeffs51 * cosCacheX55 * cosCacheY31 +
                        coeffs52 * cosCacheX55 * cosCacheY39 +
                        coeffs53 * cosCacheX55 * cosCacheY47 +
                        coeffs54 * cosCacheX55 * cosCacheY55 +
                        coeffs55 * cosCacheX55 * cosCacheY63 +
                        coeffs56 * cosCacheX63 * cosCacheY7 * Alpha +
                        coeffs57 * cosCacheX63 * cosCacheY15 +
                        coeffs58 * cosCacheX63 * cosCacheY23 +
                        coeffs59 * cosCacheX63 * cosCacheY31 +
                        coeffs60 * cosCacheX63 * cosCacheY39 +
                        coeffs61 * cosCacheX63 * cosCacheY47 +
                        coeffs62 * cosCacheX63 * cosCacheY55 +
                        coeffs63 * cosCacheX63 * cosCacheY63) * Beta + JpegProcessor.DctSizeDoubleSquare;
    }
}
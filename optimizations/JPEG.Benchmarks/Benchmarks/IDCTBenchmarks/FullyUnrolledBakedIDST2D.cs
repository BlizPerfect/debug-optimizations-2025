using JPEG.Processor;

namespace JPEG.Benchmarks.Benchmarks.IDCTBenchmarks;

public class FullyUnrolledBakedIDST2D
{
    private const double Alpha = 0.70710678118654746;
    private const double Beta = 0.25;

    private const double cosCache0 = 1.0;
    private const double cosCache1 = 1.0;
    private const double cosCache2 = 1.0;
    private const double cosCache3 = 1.0;
    private const double cosCache4 = 1.0;
    private const double cosCache5 = 1.0;
    private const double cosCache6 = 1.0;
    private const double cosCache7 = 1.0;
    private const double cosCache8 = 0.98078528040323043;
    private const double cosCache9 = 0.83146961230254524;
    private const double cosCache10 = 0.55557023301960229;
    private const double cosCache11 = 0.19509032201612833;
    private const double cosCache12 = -0.19509032201612819;
    private const double cosCache13 = -0.55557023301960196;
    private const double cosCache14 = -0.83146961230254535;
    private const double cosCache15 = -0.98078528040323043;
    private const double cosCache16 = 0.92387953251128674;
    private const double cosCache17 = 0.38268343236508984;
    private const double cosCache18 = -0.38268343236508973;
    private const double cosCache19 = -0.92387953251128674;
    private const double cosCache20 = -0.92387953251128685;
    private const double cosCache21 = -0.38268343236509034;
    private const double cosCache22 = 0.38268343236509;
    private const double cosCache23 = 0.92387953251128652;
    private const double cosCache24 = 0.83146961230254524;
    private const double cosCache25 = -0.19509032201612819;
    private const double cosCache26 = -0.98078528040323043;
    private const double cosCache27 = -0.55557023301960218;
    private const double cosCache28 = 0.55557023301960184;
    private const double cosCache29 = 0.98078528040323043;
    private const double cosCache30 = 0.19509032201612878;
    private const double cosCache31 = -0.83146961230254512;
    private const double cosCache32 = 0.70710678118654757;
    private const double cosCache33 = -0.70710678118654746;
    private const double cosCache34 = -0.70710678118654768;
    private const double cosCache35 = 0.70710678118654735;
    private const double cosCache36 = 0.70710678118654768;
    private const double cosCache37 = -0.70710678118654668;
    private const double cosCache38 = -0.70710678118654713;
    private const double cosCache39 = 0.70710678118654657;
    private const double cosCache40 = 0.55557023301960229;
    private const double cosCache41 = -0.98078528040323043;
    private const double cosCache42 = 0.1950903220161283;
    private const double cosCache43 = 0.83146961230254557;
    private const double cosCache44 = -0.83146961230254512;
    private const double cosCache45 = -0.19509032201612803;
    private const double cosCache46 = 0.98078528040323065;
    private const double cosCache47 = -0.55557023301960151;
    private const double cosCache48 = 0.38268343236508984;
    private const double cosCache49 = -0.92387953251128685;
    private const double cosCache50 = 0.92387953251128652;
    private const double cosCache51 = -0.38268343236508989;
    private const double cosCache52 = -0.38268343236509056;
    private const double cosCache53 = 0.92387953251128674;
    private const double cosCache54 = -0.92387953251128641;
    private const double cosCache55 = 0.38268343236508956;
    private const double cosCache56 = 0.19509032201612833;
    private const double cosCache57 = -0.55557023301960218;
    private const double cosCache58 = 0.83146961230254557;
    private const double cosCache59 = -0.98078528040323065;
    private const double cosCache60 = 0.98078528040323054;
    private const double cosCache61 = -0.83146961230254501;
    private const double cosCache62 = 0.55557023301960151;
    private const double cosCache63 = -0.19509032201612858;
    
    public static void IDCT2D(double[,] coeffs, double[,] output)
    {
        var coeffs0 = coeffs[0, 0];
        var coeffs1 = coeffs[0, 1];
        var coeffs2 = coeffs[0, 2];
        var coeffs3 = coeffs[0, 3];
        var coeffs4 = coeffs[0, 4];
        var coeffs5 = coeffs[0, 5];
        var coeffs6 = coeffs[0, 6];
        var coeffs7 = coeffs[0, 7];
        var coeffs8 = coeffs[1, 0];
        var coeffs9 = coeffs[1, 1];
        var coeffs10 = coeffs[1, 2];
        var coeffs11 = coeffs[1, 3];
        var coeffs12 = coeffs[1, 4];
        var coeffs13 = coeffs[1, 5];
        var coeffs14 = coeffs[1, 6];
        var coeffs15 = coeffs[1, 7];
        var coeffs16 = coeffs[2, 0];
        var coeffs17 = coeffs[2, 1];
        var coeffs18 = coeffs[2, 2];
        var coeffs19 = coeffs[2, 3];
        var coeffs20 = coeffs[2, 4];
        var coeffs21 = coeffs[2, 5];
        var coeffs22 = coeffs[2, 6];
        var coeffs23 = coeffs[2, 7];
        var coeffs24 = coeffs[3, 0];
        var coeffs25 = coeffs[3, 1];
        var coeffs26 = coeffs[3, 2];
        var coeffs27 = coeffs[3, 3];
        var coeffs28 = coeffs[3, 4];
        var coeffs29 = coeffs[3, 5];
        var coeffs30 = coeffs[3, 6];
        var coeffs31 = coeffs[3, 7];
        var coeffs32 = coeffs[4, 0];
        var coeffs33 = coeffs[4, 1];
        var coeffs34 = coeffs[4, 2];
        var coeffs35 = coeffs[4, 3];
        var coeffs36 = coeffs[4, 4];
        var coeffs37 = coeffs[4, 5];
        var coeffs38 = coeffs[4, 6];
        var coeffs39 = coeffs[4, 7];
        var coeffs40 = coeffs[5, 0];
        var coeffs41 = coeffs[5, 1];
        var coeffs42 = coeffs[5, 2];
        var coeffs43 = coeffs[5, 3];
        var coeffs44 = coeffs[5, 4];
        var coeffs45 = coeffs[5, 5];
        var coeffs46 = coeffs[5, 6];
        var coeffs47 = coeffs[5, 7];
        var coeffs48 = coeffs[6, 0];
        var coeffs49 = coeffs[6, 1];
        var coeffs50 = coeffs[6, 2];
        var coeffs51 = coeffs[6, 3];
        var coeffs52 = coeffs[6, 4];
        var coeffs53 = coeffs[6, 5];
        var coeffs54 = coeffs[6, 6];
        var coeffs55 = coeffs[6, 7];
        var coeffs56 = coeffs[7, 0];
        var coeffs57 = coeffs[7, 1];
        var coeffs58 = coeffs[7, 2];
        var coeffs59 = coeffs[7, 3];
        var coeffs60 = coeffs[7, 4];
        var coeffs61 = coeffs[7, 5];
        var coeffs62 = coeffs[7, 6];
        var coeffs63 = coeffs[7, 7];
        output[0, 0] = (coeffs0 * cosCache0 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache8 * Alpha +
                        coeffs2 * cosCache0 * cosCache16 * Alpha +
                        coeffs3 * cosCache0 * cosCache24 * Alpha +
                        coeffs4 * cosCache0 * cosCache32 * Alpha +
                        coeffs5 * cosCache0 * cosCache40 * Alpha +
                        coeffs6 * cosCache0 * cosCache48 * Alpha +
                        coeffs7 * cosCache0 * cosCache56 * Alpha +
                        coeffs8 * cosCache8 * cosCache0 * Alpha +
                        coeffs9 * cosCache8 * cosCache8 +
                        coeffs10 * cosCache8 * cosCache16 +
                        coeffs11 * cosCache8 * cosCache24 +
                        coeffs12 * cosCache8 * cosCache32 +
                        coeffs13 * cosCache8 * cosCache40 +
                        coeffs14 * cosCache8 * cosCache48 +
                        coeffs15 * cosCache8 * cosCache56 +
                        coeffs16 * cosCache16 * cosCache0 * Alpha +
                        coeffs17 * cosCache16 * cosCache8 +
                        coeffs18 * cosCache16 * cosCache16 +
                        coeffs19 * cosCache16 * cosCache24 +
                        coeffs20 * cosCache16 * cosCache32 +
                        coeffs21 * cosCache16 * cosCache40 +
                        coeffs22 * cosCache16 * cosCache48 +
                        coeffs23 * cosCache16 * cosCache56 +
                        coeffs24 * cosCache24 * cosCache0 * Alpha +
                        coeffs25 * cosCache24 * cosCache8 +
                        coeffs26 * cosCache24 * cosCache16 +
                        coeffs27 * cosCache24 * cosCache24 +
                        coeffs28 * cosCache24 * cosCache32 +
                        coeffs29 * cosCache24 * cosCache40 +
                        coeffs30 * cosCache24 * cosCache48 +
                        coeffs31 * cosCache24 * cosCache56 +
                        coeffs32 * cosCache32 * cosCache0 * Alpha +
                        coeffs33 * cosCache32 * cosCache8 +
                        coeffs34 * cosCache32 * cosCache16 +
                        coeffs35 * cosCache32 * cosCache24 +
                        coeffs36 * cosCache32 * cosCache32 +
                        coeffs37 * cosCache32 * cosCache40 +
                        coeffs38 * cosCache32 * cosCache48 +
                        coeffs39 * cosCache32 * cosCache56 +
                        coeffs40 * cosCache40 * cosCache0 * Alpha +
                        coeffs41 * cosCache40 * cosCache8 +
                        coeffs42 * cosCache40 * cosCache16 +
                        coeffs43 * cosCache40 * cosCache24 +
                        coeffs44 * cosCache40 * cosCache32 +
                        coeffs45 * cosCache40 * cosCache40 +
                        coeffs46 * cosCache40 * cosCache48 +
                        coeffs47 * cosCache40 * cosCache56 +
                        coeffs48 * cosCache48 * cosCache0 * Alpha +
                        coeffs49 * cosCache48 * cosCache8 +
                        coeffs50 * cosCache48 * cosCache16 +
                        coeffs51 * cosCache48 * cosCache24 +
                        coeffs52 * cosCache48 * cosCache32 +
                        coeffs53 * cosCache48 * cosCache40 +
                        coeffs54 * cosCache48 * cosCache48 +
                        coeffs55 * cosCache48 * cosCache56 +
                        coeffs56 * cosCache56 * cosCache0 * Alpha +
                        coeffs57 * cosCache56 * cosCache8 +
                        coeffs58 * cosCache56 * cosCache16 +
                        coeffs59 * cosCache56 * cosCache24 +
                        coeffs60 * cosCache56 * cosCache32 +
                        coeffs61 * cosCache56 * cosCache40 +
                        coeffs62 * cosCache56 * cosCache48 +
                        coeffs63 * cosCache56 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 1] = (coeffs0 * cosCache0 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache9 * Alpha +
                        coeffs2 * cosCache0 * cosCache17 * Alpha +
                        coeffs3 * cosCache0 * cosCache25 * Alpha +
                        coeffs4 * cosCache0 * cosCache33 * Alpha +
                        coeffs5 * cosCache0 * cosCache41 * Alpha +
                        coeffs6 * cosCache0 * cosCache49 * Alpha +
                        coeffs7 * cosCache0 * cosCache57 * Alpha +
                        coeffs8 * cosCache8 * cosCache1 * Alpha +
                        coeffs9 * cosCache8 * cosCache9 +
                        coeffs10 * cosCache8 * cosCache17 +
                        coeffs11 * cosCache8 * cosCache25 +
                        coeffs12 * cosCache8 * cosCache33 +
                        coeffs13 * cosCache8 * cosCache41 +
                        coeffs14 * cosCache8 * cosCache49 +
                        coeffs15 * cosCache8 * cosCache57 +
                        coeffs16 * cosCache16 * cosCache1 * Alpha +
                        coeffs17 * cosCache16 * cosCache9 +
                        coeffs18 * cosCache16 * cosCache17 +
                        coeffs19 * cosCache16 * cosCache25 +
                        coeffs20 * cosCache16 * cosCache33 +
                        coeffs21 * cosCache16 * cosCache41 +
                        coeffs22 * cosCache16 * cosCache49 +
                        coeffs23 * cosCache16 * cosCache57 +
                        coeffs24 * cosCache24 * cosCache1 * Alpha +
                        coeffs25 * cosCache24 * cosCache9 +
                        coeffs26 * cosCache24 * cosCache17 +
                        coeffs27 * cosCache24 * cosCache25 +
                        coeffs28 * cosCache24 * cosCache33 +
                        coeffs29 * cosCache24 * cosCache41 +
                        coeffs30 * cosCache24 * cosCache49 +
                        coeffs31 * cosCache24 * cosCache57 +
                        coeffs32 * cosCache32 * cosCache1 * Alpha +
                        coeffs33 * cosCache32 * cosCache9 +
                        coeffs34 * cosCache32 * cosCache17 +
                        coeffs35 * cosCache32 * cosCache25 +
                        coeffs36 * cosCache32 * cosCache33 +
                        coeffs37 * cosCache32 * cosCache41 +
                        coeffs38 * cosCache32 * cosCache49 +
                        coeffs39 * cosCache32 * cosCache57 +
                        coeffs40 * cosCache40 * cosCache1 * Alpha +
                        coeffs41 * cosCache40 * cosCache9 +
                        coeffs42 * cosCache40 * cosCache17 +
                        coeffs43 * cosCache40 * cosCache25 +
                        coeffs44 * cosCache40 * cosCache33 +
                        coeffs45 * cosCache40 * cosCache41 +
                        coeffs46 * cosCache40 * cosCache49 +
                        coeffs47 * cosCache40 * cosCache57 +
                        coeffs48 * cosCache48 * cosCache1 * Alpha +
                        coeffs49 * cosCache48 * cosCache9 +
                        coeffs50 * cosCache48 * cosCache17 +
                        coeffs51 * cosCache48 * cosCache25 +
                        coeffs52 * cosCache48 * cosCache33 +
                        coeffs53 * cosCache48 * cosCache41 +
                        coeffs54 * cosCache48 * cosCache49 +
                        coeffs55 * cosCache48 * cosCache57 +
                        coeffs56 * cosCache56 * cosCache1 * Alpha +
                        coeffs57 * cosCache56 * cosCache9 +
                        coeffs58 * cosCache56 * cosCache17 +
                        coeffs59 * cosCache56 * cosCache25 +
                        coeffs60 * cosCache56 * cosCache33 +
                        coeffs61 * cosCache56 * cosCache41 +
                        coeffs62 * cosCache56 * cosCache49 +
                        coeffs63 * cosCache56 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 2] = (coeffs0 * cosCache0 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache10 * Alpha +
                        coeffs2 * cosCache0 * cosCache18 * Alpha +
                        coeffs3 * cosCache0 * cosCache26 * Alpha +
                        coeffs4 * cosCache0 * cosCache34 * Alpha +
                        coeffs5 * cosCache0 * cosCache42 * Alpha +
                        coeffs6 * cosCache0 * cosCache50 * Alpha +
                        coeffs7 * cosCache0 * cosCache58 * Alpha +
                        coeffs8 * cosCache8 * cosCache2 * Alpha +
                        coeffs9 * cosCache8 * cosCache10 +
                        coeffs10 * cosCache8 * cosCache18 +
                        coeffs11 * cosCache8 * cosCache26 +
                        coeffs12 * cosCache8 * cosCache34 +
                        coeffs13 * cosCache8 * cosCache42 +
                        coeffs14 * cosCache8 * cosCache50 +
                        coeffs15 * cosCache8 * cosCache58 +
                        coeffs16 * cosCache16 * cosCache2 * Alpha +
                        coeffs17 * cosCache16 * cosCache10 +
                        coeffs18 * cosCache16 * cosCache18 +
                        coeffs19 * cosCache16 * cosCache26 +
                        coeffs20 * cosCache16 * cosCache34 +
                        coeffs21 * cosCache16 * cosCache42 +
                        coeffs22 * cosCache16 * cosCache50 +
                        coeffs23 * cosCache16 * cosCache58 +
                        coeffs24 * cosCache24 * cosCache2 * Alpha +
                        coeffs25 * cosCache24 * cosCache10 +
                        coeffs26 * cosCache24 * cosCache18 +
                        coeffs27 * cosCache24 * cosCache26 +
                        coeffs28 * cosCache24 * cosCache34 +
                        coeffs29 * cosCache24 * cosCache42 +
                        coeffs30 * cosCache24 * cosCache50 +
                        coeffs31 * cosCache24 * cosCache58 +
                        coeffs32 * cosCache32 * cosCache2 * Alpha +
                        coeffs33 * cosCache32 * cosCache10 +
                        coeffs34 * cosCache32 * cosCache18 +
                        coeffs35 * cosCache32 * cosCache26 +
                        coeffs36 * cosCache32 * cosCache34 +
                        coeffs37 * cosCache32 * cosCache42 +
                        coeffs38 * cosCache32 * cosCache50 +
                        coeffs39 * cosCache32 * cosCache58 +
                        coeffs40 * cosCache40 * cosCache2 * Alpha +
                        coeffs41 * cosCache40 * cosCache10 +
                        coeffs42 * cosCache40 * cosCache18 +
                        coeffs43 * cosCache40 * cosCache26 +
                        coeffs44 * cosCache40 * cosCache34 +
                        coeffs45 * cosCache40 * cosCache42 +
                        coeffs46 * cosCache40 * cosCache50 +
                        coeffs47 * cosCache40 * cosCache58 +
                        coeffs48 * cosCache48 * cosCache2 * Alpha +
                        coeffs49 * cosCache48 * cosCache10 +
                        coeffs50 * cosCache48 * cosCache18 +
                        coeffs51 * cosCache48 * cosCache26 +
                        coeffs52 * cosCache48 * cosCache34 +
                        coeffs53 * cosCache48 * cosCache42 +
                        coeffs54 * cosCache48 * cosCache50 +
                        coeffs55 * cosCache48 * cosCache58 +
                        coeffs56 * cosCache56 * cosCache2 * Alpha +
                        coeffs57 * cosCache56 * cosCache10 +
                        coeffs58 * cosCache56 * cosCache18 +
                        coeffs59 * cosCache56 * cosCache26 +
                        coeffs60 * cosCache56 * cosCache34 +
                        coeffs61 * cosCache56 * cosCache42 +
                        coeffs62 * cosCache56 * cosCache50 +
                        coeffs63 * cosCache56 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 3] = (coeffs0 * cosCache0 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache11 * Alpha +
                        coeffs2 * cosCache0 * cosCache19 * Alpha +
                        coeffs3 * cosCache0 * cosCache27 * Alpha +
                        coeffs4 * cosCache0 * cosCache35 * Alpha +
                        coeffs5 * cosCache0 * cosCache43 * Alpha +
                        coeffs6 * cosCache0 * cosCache51 * Alpha +
                        coeffs7 * cosCache0 * cosCache59 * Alpha +
                        coeffs8 * cosCache8 * cosCache3 * Alpha +
                        coeffs9 * cosCache8 * cosCache11 +
                        coeffs10 * cosCache8 * cosCache19 +
                        coeffs11 * cosCache8 * cosCache27 +
                        coeffs12 * cosCache8 * cosCache35 +
                        coeffs13 * cosCache8 * cosCache43 +
                        coeffs14 * cosCache8 * cosCache51 +
                        coeffs15 * cosCache8 * cosCache59 +
                        coeffs16 * cosCache16 * cosCache3 * Alpha +
                        coeffs17 * cosCache16 * cosCache11 +
                        coeffs18 * cosCache16 * cosCache19 +
                        coeffs19 * cosCache16 * cosCache27 +
                        coeffs20 * cosCache16 * cosCache35 +
                        coeffs21 * cosCache16 * cosCache43 +
                        coeffs22 * cosCache16 * cosCache51 +
                        coeffs23 * cosCache16 * cosCache59 +
                        coeffs24 * cosCache24 * cosCache3 * Alpha +
                        coeffs25 * cosCache24 * cosCache11 +
                        coeffs26 * cosCache24 * cosCache19 +
                        coeffs27 * cosCache24 * cosCache27 +
                        coeffs28 * cosCache24 * cosCache35 +
                        coeffs29 * cosCache24 * cosCache43 +
                        coeffs30 * cosCache24 * cosCache51 +
                        coeffs31 * cosCache24 * cosCache59 +
                        coeffs32 * cosCache32 * cosCache3 * Alpha +
                        coeffs33 * cosCache32 * cosCache11 +
                        coeffs34 * cosCache32 * cosCache19 +
                        coeffs35 * cosCache32 * cosCache27 +
                        coeffs36 * cosCache32 * cosCache35 +
                        coeffs37 * cosCache32 * cosCache43 +
                        coeffs38 * cosCache32 * cosCache51 +
                        coeffs39 * cosCache32 * cosCache59 +
                        coeffs40 * cosCache40 * cosCache3 * Alpha +
                        coeffs41 * cosCache40 * cosCache11 +
                        coeffs42 * cosCache40 * cosCache19 +
                        coeffs43 * cosCache40 * cosCache27 +
                        coeffs44 * cosCache40 * cosCache35 +
                        coeffs45 * cosCache40 * cosCache43 +
                        coeffs46 * cosCache40 * cosCache51 +
                        coeffs47 * cosCache40 * cosCache59 +
                        coeffs48 * cosCache48 * cosCache3 * Alpha +
                        coeffs49 * cosCache48 * cosCache11 +
                        coeffs50 * cosCache48 * cosCache19 +
                        coeffs51 * cosCache48 * cosCache27 +
                        coeffs52 * cosCache48 * cosCache35 +
                        coeffs53 * cosCache48 * cosCache43 +
                        coeffs54 * cosCache48 * cosCache51 +
                        coeffs55 * cosCache48 * cosCache59 +
                        coeffs56 * cosCache56 * cosCache3 * Alpha +
                        coeffs57 * cosCache56 * cosCache11 +
                        coeffs58 * cosCache56 * cosCache19 +
                        coeffs59 * cosCache56 * cosCache27 +
                        coeffs60 * cosCache56 * cosCache35 +
                        coeffs61 * cosCache56 * cosCache43 +
                        coeffs62 * cosCache56 * cosCache51 +
                        coeffs63 * cosCache56 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 4] = (coeffs0 * cosCache0 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache12 * Alpha +
                        coeffs2 * cosCache0 * cosCache20 * Alpha +
                        coeffs3 * cosCache0 * cosCache28 * Alpha +
                        coeffs4 * cosCache0 * cosCache36 * Alpha +
                        coeffs5 * cosCache0 * cosCache44 * Alpha +
                        coeffs6 * cosCache0 * cosCache52 * Alpha +
                        coeffs7 * cosCache0 * cosCache60 * Alpha +
                        coeffs8 * cosCache8 * cosCache4 * Alpha +
                        coeffs9 * cosCache8 * cosCache12 +
                        coeffs10 * cosCache8 * cosCache20 +
                        coeffs11 * cosCache8 * cosCache28 +
                        coeffs12 * cosCache8 * cosCache36 +
                        coeffs13 * cosCache8 * cosCache44 +
                        coeffs14 * cosCache8 * cosCache52 +
                        coeffs15 * cosCache8 * cosCache60 +
                        coeffs16 * cosCache16 * cosCache4 * Alpha +
                        coeffs17 * cosCache16 * cosCache12 +
                        coeffs18 * cosCache16 * cosCache20 +
                        coeffs19 * cosCache16 * cosCache28 +
                        coeffs20 * cosCache16 * cosCache36 +
                        coeffs21 * cosCache16 * cosCache44 +
                        coeffs22 * cosCache16 * cosCache52 +
                        coeffs23 * cosCache16 * cosCache60 +
                        coeffs24 * cosCache24 * cosCache4 * Alpha +
                        coeffs25 * cosCache24 * cosCache12 +
                        coeffs26 * cosCache24 * cosCache20 +
                        coeffs27 * cosCache24 * cosCache28 +
                        coeffs28 * cosCache24 * cosCache36 +
                        coeffs29 * cosCache24 * cosCache44 +
                        coeffs30 * cosCache24 * cosCache52 +
                        coeffs31 * cosCache24 * cosCache60 +
                        coeffs32 * cosCache32 * cosCache4 * Alpha +
                        coeffs33 * cosCache32 * cosCache12 +
                        coeffs34 * cosCache32 * cosCache20 +
                        coeffs35 * cosCache32 * cosCache28 +
                        coeffs36 * cosCache32 * cosCache36 +
                        coeffs37 * cosCache32 * cosCache44 +
                        coeffs38 * cosCache32 * cosCache52 +
                        coeffs39 * cosCache32 * cosCache60 +
                        coeffs40 * cosCache40 * cosCache4 * Alpha +
                        coeffs41 * cosCache40 * cosCache12 +
                        coeffs42 * cosCache40 * cosCache20 +
                        coeffs43 * cosCache40 * cosCache28 +
                        coeffs44 * cosCache40 * cosCache36 +
                        coeffs45 * cosCache40 * cosCache44 +
                        coeffs46 * cosCache40 * cosCache52 +
                        coeffs47 * cosCache40 * cosCache60 +
                        coeffs48 * cosCache48 * cosCache4 * Alpha +
                        coeffs49 * cosCache48 * cosCache12 +
                        coeffs50 * cosCache48 * cosCache20 +
                        coeffs51 * cosCache48 * cosCache28 +
                        coeffs52 * cosCache48 * cosCache36 +
                        coeffs53 * cosCache48 * cosCache44 +
                        coeffs54 * cosCache48 * cosCache52 +
                        coeffs55 * cosCache48 * cosCache60 +
                        coeffs56 * cosCache56 * cosCache4 * Alpha +
                        coeffs57 * cosCache56 * cosCache12 +
                        coeffs58 * cosCache56 * cosCache20 +
                        coeffs59 * cosCache56 * cosCache28 +
                        coeffs60 * cosCache56 * cosCache36 +
                        coeffs61 * cosCache56 * cosCache44 +
                        coeffs62 * cosCache56 * cosCache52 +
                        coeffs63 * cosCache56 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 5] = (coeffs0 * cosCache0 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache13 * Alpha +
                        coeffs2 * cosCache0 * cosCache21 * Alpha +
                        coeffs3 * cosCache0 * cosCache29 * Alpha +
                        coeffs4 * cosCache0 * cosCache37 * Alpha +
                        coeffs5 * cosCache0 * cosCache45 * Alpha +
                        coeffs6 * cosCache0 * cosCache53 * Alpha +
                        coeffs7 * cosCache0 * cosCache61 * Alpha +
                        coeffs8 * cosCache8 * cosCache5 * Alpha +
                        coeffs9 * cosCache8 * cosCache13 +
                        coeffs10 * cosCache8 * cosCache21 +
                        coeffs11 * cosCache8 * cosCache29 +
                        coeffs12 * cosCache8 * cosCache37 +
                        coeffs13 * cosCache8 * cosCache45 +
                        coeffs14 * cosCache8 * cosCache53 +
                        coeffs15 * cosCache8 * cosCache61 +
                        coeffs16 * cosCache16 * cosCache5 * Alpha +
                        coeffs17 * cosCache16 * cosCache13 +
                        coeffs18 * cosCache16 * cosCache21 +
                        coeffs19 * cosCache16 * cosCache29 +
                        coeffs20 * cosCache16 * cosCache37 +
                        coeffs21 * cosCache16 * cosCache45 +
                        coeffs22 * cosCache16 * cosCache53 +
                        coeffs23 * cosCache16 * cosCache61 +
                        coeffs24 * cosCache24 * cosCache5 * Alpha +
                        coeffs25 * cosCache24 * cosCache13 +
                        coeffs26 * cosCache24 * cosCache21 +
                        coeffs27 * cosCache24 * cosCache29 +
                        coeffs28 * cosCache24 * cosCache37 +
                        coeffs29 * cosCache24 * cosCache45 +
                        coeffs30 * cosCache24 * cosCache53 +
                        coeffs31 * cosCache24 * cosCache61 +
                        coeffs32 * cosCache32 * cosCache5 * Alpha +
                        coeffs33 * cosCache32 * cosCache13 +
                        coeffs34 * cosCache32 * cosCache21 +
                        coeffs35 * cosCache32 * cosCache29 +
                        coeffs36 * cosCache32 * cosCache37 +
                        coeffs37 * cosCache32 * cosCache45 +
                        coeffs38 * cosCache32 * cosCache53 +
                        coeffs39 * cosCache32 * cosCache61 +
                        coeffs40 * cosCache40 * cosCache5 * Alpha +
                        coeffs41 * cosCache40 * cosCache13 +
                        coeffs42 * cosCache40 * cosCache21 +
                        coeffs43 * cosCache40 * cosCache29 +
                        coeffs44 * cosCache40 * cosCache37 +
                        coeffs45 * cosCache40 * cosCache45 +
                        coeffs46 * cosCache40 * cosCache53 +
                        coeffs47 * cosCache40 * cosCache61 +
                        coeffs48 * cosCache48 * cosCache5 * Alpha +
                        coeffs49 * cosCache48 * cosCache13 +
                        coeffs50 * cosCache48 * cosCache21 +
                        coeffs51 * cosCache48 * cosCache29 +
                        coeffs52 * cosCache48 * cosCache37 +
                        coeffs53 * cosCache48 * cosCache45 +
                        coeffs54 * cosCache48 * cosCache53 +
                        coeffs55 * cosCache48 * cosCache61 +
                        coeffs56 * cosCache56 * cosCache5 * Alpha +
                        coeffs57 * cosCache56 * cosCache13 +
                        coeffs58 * cosCache56 * cosCache21 +
                        coeffs59 * cosCache56 * cosCache29 +
                        coeffs60 * cosCache56 * cosCache37 +
                        coeffs61 * cosCache56 * cosCache45 +
                        coeffs62 * cosCache56 * cosCache53 +
                        coeffs63 * cosCache56 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 6] = (coeffs0 * cosCache0 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache14 * Alpha +
                        coeffs2 * cosCache0 * cosCache22 * Alpha +
                        coeffs3 * cosCache0 * cosCache30 * Alpha +
                        coeffs4 * cosCache0 * cosCache38 * Alpha +
                        coeffs5 * cosCache0 * cosCache46 * Alpha +
                        coeffs6 * cosCache0 * cosCache54 * Alpha +
                        coeffs7 * cosCache0 * cosCache62 * Alpha +
                        coeffs8 * cosCache8 * cosCache6 * Alpha +
                        coeffs9 * cosCache8 * cosCache14 +
                        coeffs10 * cosCache8 * cosCache22 +
                        coeffs11 * cosCache8 * cosCache30 +
                        coeffs12 * cosCache8 * cosCache38 +
                        coeffs13 * cosCache8 * cosCache46 +
                        coeffs14 * cosCache8 * cosCache54 +
                        coeffs15 * cosCache8 * cosCache62 +
                        coeffs16 * cosCache16 * cosCache6 * Alpha +
                        coeffs17 * cosCache16 * cosCache14 +
                        coeffs18 * cosCache16 * cosCache22 +
                        coeffs19 * cosCache16 * cosCache30 +
                        coeffs20 * cosCache16 * cosCache38 +
                        coeffs21 * cosCache16 * cosCache46 +
                        coeffs22 * cosCache16 * cosCache54 +
                        coeffs23 * cosCache16 * cosCache62 +
                        coeffs24 * cosCache24 * cosCache6 * Alpha +
                        coeffs25 * cosCache24 * cosCache14 +
                        coeffs26 * cosCache24 * cosCache22 +
                        coeffs27 * cosCache24 * cosCache30 +
                        coeffs28 * cosCache24 * cosCache38 +
                        coeffs29 * cosCache24 * cosCache46 +
                        coeffs30 * cosCache24 * cosCache54 +
                        coeffs31 * cosCache24 * cosCache62 +
                        coeffs32 * cosCache32 * cosCache6 * Alpha +
                        coeffs33 * cosCache32 * cosCache14 +
                        coeffs34 * cosCache32 * cosCache22 +
                        coeffs35 * cosCache32 * cosCache30 +
                        coeffs36 * cosCache32 * cosCache38 +
                        coeffs37 * cosCache32 * cosCache46 +
                        coeffs38 * cosCache32 * cosCache54 +
                        coeffs39 * cosCache32 * cosCache62 +
                        coeffs40 * cosCache40 * cosCache6 * Alpha +
                        coeffs41 * cosCache40 * cosCache14 +
                        coeffs42 * cosCache40 * cosCache22 +
                        coeffs43 * cosCache40 * cosCache30 +
                        coeffs44 * cosCache40 * cosCache38 +
                        coeffs45 * cosCache40 * cosCache46 +
                        coeffs46 * cosCache40 * cosCache54 +
                        coeffs47 * cosCache40 * cosCache62 +
                        coeffs48 * cosCache48 * cosCache6 * Alpha +
                        coeffs49 * cosCache48 * cosCache14 +
                        coeffs50 * cosCache48 * cosCache22 +
                        coeffs51 * cosCache48 * cosCache30 +
                        coeffs52 * cosCache48 * cosCache38 +
                        coeffs53 * cosCache48 * cosCache46 +
                        coeffs54 * cosCache48 * cosCache54 +
                        coeffs55 * cosCache48 * cosCache62 +
                        coeffs56 * cosCache56 * cosCache6 * Alpha +
                        coeffs57 * cosCache56 * cosCache14 +
                        coeffs58 * cosCache56 * cosCache22 +
                        coeffs59 * cosCache56 * cosCache30 +
                        coeffs60 * cosCache56 * cosCache38 +
                        coeffs61 * cosCache56 * cosCache46 +
                        coeffs62 * cosCache56 * cosCache54 +
                        coeffs63 * cosCache56 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[0, 7] = (coeffs0 * cosCache0 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache0 * cosCache15 * Alpha +
                        coeffs2 * cosCache0 * cosCache23 * Alpha +
                        coeffs3 * cosCache0 * cosCache31 * Alpha +
                        coeffs4 * cosCache0 * cosCache39 * Alpha +
                        coeffs5 * cosCache0 * cosCache47 * Alpha +
                        coeffs6 * cosCache0 * cosCache55 * Alpha +
                        coeffs7 * cosCache0 * cosCache63 * Alpha +
                        coeffs8 * cosCache8 * cosCache7 * Alpha +
                        coeffs9 * cosCache8 * cosCache15 +
                        coeffs10 * cosCache8 * cosCache23 +
                        coeffs11 * cosCache8 * cosCache31 +
                        coeffs12 * cosCache8 * cosCache39 +
                        coeffs13 * cosCache8 * cosCache47 +
                        coeffs14 * cosCache8 * cosCache55 +
                        coeffs15 * cosCache8 * cosCache63 +
                        coeffs16 * cosCache16 * cosCache7 * Alpha +
                        coeffs17 * cosCache16 * cosCache15 +
                        coeffs18 * cosCache16 * cosCache23 +
                        coeffs19 * cosCache16 * cosCache31 +
                        coeffs20 * cosCache16 * cosCache39 +
                        coeffs21 * cosCache16 * cosCache47 +
                        coeffs22 * cosCache16 * cosCache55 +
                        coeffs23 * cosCache16 * cosCache63 +
                        coeffs24 * cosCache24 * cosCache7 * Alpha +
                        coeffs25 * cosCache24 * cosCache15 +
                        coeffs26 * cosCache24 * cosCache23 +
                        coeffs27 * cosCache24 * cosCache31 +
                        coeffs28 * cosCache24 * cosCache39 +
                        coeffs29 * cosCache24 * cosCache47 +
                        coeffs30 * cosCache24 * cosCache55 +
                        coeffs31 * cosCache24 * cosCache63 +
                        coeffs32 * cosCache32 * cosCache7 * Alpha +
                        coeffs33 * cosCache32 * cosCache15 +
                        coeffs34 * cosCache32 * cosCache23 +
                        coeffs35 * cosCache32 * cosCache31 +
                        coeffs36 * cosCache32 * cosCache39 +
                        coeffs37 * cosCache32 * cosCache47 +
                        coeffs38 * cosCache32 * cosCache55 +
                        coeffs39 * cosCache32 * cosCache63 +
                        coeffs40 * cosCache40 * cosCache7 * Alpha +
                        coeffs41 * cosCache40 * cosCache15 +
                        coeffs42 * cosCache40 * cosCache23 +
                        coeffs43 * cosCache40 * cosCache31 +
                        coeffs44 * cosCache40 * cosCache39 +
                        coeffs45 * cosCache40 * cosCache47 +
                        coeffs46 * cosCache40 * cosCache55 +
                        coeffs47 * cosCache40 * cosCache63 +
                        coeffs48 * cosCache48 * cosCache7 * Alpha +
                        coeffs49 * cosCache48 * cosCache15 +
                        coeffs50 * cosCache48 * cosCache23 +
                        coeffs51 * cosCache48 * cosCache31 +
                        coeffs52 * cosCache48 * cosCache39 +
                        coeffs53 * cosCache48 * cosCache47 +
                        coeffs54 * cosCache48 * cosCache55 +
                        coeffs55 * cosCache48 * cosCache63 +
                        coeffs56 * cosCache56 * cosCache7 * Alpha +
                        coeffs57 * cosCache56 * cosCache15 +
                        coeffs58 * cosCache56 * cosCache23 +
                        coeffs59 * cosCache56 * cosCache31 +
                        coeffs60 * cosCache56 * cosCache39 +
                        coeffs61 * cosCache56 * cosCache47 +
                        coeffs62 * cosCache56 * cosCache55 +
                        coeffs63 * cosCache56 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 0] = (coeffs0 * cosCache1 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache8 * Alpha +
                        coeffs2 * cosCache1 * cosCache16 * Alpha +
                        coeffs3 * cosCache1 * cosCache24 * Alpha +
                        coeffs4 * cosCache1 * cosCache32 * Alpha +
                        coeffs5 * cosCache1 * cosCache40 * Alpha +
                        coeffs6 * cosCache1 * cosCache48 * Alpha +
                        coeffs7 * cosCache1 * cosCache56 * Alpha +
                        coeffs8 * cosCache9 * cosCache0 * Alpha +
                        coeffs9 * cosCache9 * cosCache8 +
                        coeffs10 * cosCache9 * cosCache16 +
                        coeffs11 * cosCache9 * cosCache24 +
                        coeffs12 * cosCache9 * cosCache32 +
                        coeffs13 * cosCache9 * cosCache40 +
                        coeffs14 * cosCache9 * cosCache48 +
                        coeffs15 * cosCache9 * cosCache56 +
                        coeffs16 * cosCache17 * cosCache0 * Alpha +
                        coeffs17 * cosCache17 * cosCache8 +
                        coeffs18 * cosCache17 * cosCache16 +
                        coeffs19 * cosCache17 * cosCache24 +
                        coeffs20 * cosCache17 * cosCache32 +
                        coeffs21 * cosCache17 * cosCache40 +
                        coeffs22 * cosCache17 * cosCache48 +
                        coeffs23 * cosCache17 * cosCache56 +
                        coeffs24 * cosCache25 * cosCache0 * Alpha +
                        coeffs25 * cosCache25 * cosCache8 +
                        coeffs26 * cosCache25 * cosCache16 +
                        coeffs27 * cosCache25 * cosCache24 +
                        coeffs28 * cosCache25 * cosCache32 +
                        coeffs29 * cosCache25 * cosCache40 +
                        coeffs30 * cosCache25 * cosCache48 +
                        coeffs31 * cosCache25 * cosCache56 +
                        coeffs32 * cosCache33 * cosCache0 * Alpha +
                        coeffs33 * cosCache33 * cosCache8 +
                        coeffs34 * cosCache33 * cosCache16 +
                        coeffs35 * cosCache33 * cosCache24 +
                        coeffs36 * cosCache33 * cosCache32 +
                        coeffs37 * cosCache33 * cosCache40 +
                        coeffs38 * cosCache33 * cosCache48 +
                        coeffs39 * cosCache33 * cosCache56 +
                        coeffs40 * cosCache41 * cosCache0 * Alpha +
                        coeffs41 * cosCache41 * cosCache8 +
                        coeffs42 * cosCache41 * cosCache16 +
                        coeffs43 * cosCache41 * cosCache24 +
                        coeffs44 * cosCache41 * cosCache32 +
                        coeffs45 * cosCache41 * cosCache40 +
                        coeffs46 * cosCache41 * cosCache48 +
                        coeffs47 * cosCache41 * cosCache56 +
                        coeffs48 * cosCache49 * cosCache0 * Alpha +
                        coeffs49 * cosCache49 * cosCache8 +
                        coeffs50 * cosCache49 * cosCache16 +
                        coeffs51 * cosCache49 * cosCache24 +
                        coeffs52 * cosCache49 * cosCache32 +
                        coeffs53 * cosCache49 * cosCache40 +
                        coeffs54 * cosCache49 * cosCache48 +
                        coeffs55 * cosCache49 * cosCache56 +
                        coeffs56 * cosCache57 * cosCache0 * Alpha +
                        coeffs57 * cosCache57 * cosCache8 +
                        coeffs58 * cosCache57 * cosCache16 +
                        coeffs59 * cosCache57 * cosCache24 +
                        coeffs60 * cosCache57 * cosCache32 +
                        coeffs61 * cosCache57 * cosCache40 +
                        coeffs62 * cosCache57 * cosCache48 +
                        coeffs63 * cosCache57 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 1] = (coeffs0 * cosCache1 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache9 * Alpha +
                        coeffs2 * cosCache1 * cosCache17 * Alpha +
                        coeffs3 * cosCache1 * cosCache25 * Alpha +
                        coeffs4 * cosCache1 * cosCache33 * Alpha +
                        coeffs5 * cosCache1 * cosCache41 * Alpha +
                        coeffs6 * cosCache1 * cosCache49 * Alpha +
                        coeffs7 * cosCache1 * cosCache57 * Alpha +
                        coeffs8 * cosCache9 * cosCache1 * Alpha +
                        coeffs9 * cosCache9 * cosCache9 +
                        coeffs10 * cosCache9 * cosCache17 +
                        coeffs11 * cosCache9 * cosCache25 +
                        coeffs12 * cosCache9 * cosCache33 +
                        coeffs13 * cosCache9 * cosCache41 +
                        coeffs14 * cosCache9 * cosCache49 +
                        coeffs15 * cosCache9 * cosCache57 +
                        coeffs16 * cosCache17 * cosCache1 * Alpha +
                        coeffs17 * cosCache17 * cosCache9 +
                        coeffs18 * cosCache17 * cosCache17 +
                        coeffs19 * cosCache17 * cosCache25 +
                        coeffs20 * cosCache17 * cosCache33 +
                        coeffs21 * cosCache17 * cosCache41 +
                        coeffs22 * cosCache17 * cosCache49 +
                        coeffs23 * cosCache17 * cosCache57 +
                        coeffs24 * cosCache25 * cosCache1 * Alpha +
                        coeffs25 * cosCache25 * cosCache9 +
                        coeffs26 * cosCache25 * cosCache17 +
                        coeffs27 * cosCache25 * cosCache25 +
                        coeffs28 * cosCache25 * cosCache33 +
                        coeffs29 * cosCache25 * cosCache41 +
                        coeffs30 * cosCache25 * cosCache49 +
                        coeffs31 * cosCache25 * cosCache57 +
                        coeffs32 * cosCache33 * cosCache1 * Alpha +
                        coeffs33 * cosCache33 * cosCache9 +
                        coeffs34 * cosCache33 * cosCache17 +
                        coeffs35 * cosCache33 * cosCache25 +
                        coeffs36 * cosCache33 * cosCache33 +
                        coeffs37 * cosCache33 * cosCache41 +
                        coeffs38 * cosCache33 * cosCache49 +
                        coeffs39 * cosCache33 * cosCache57 +
                        coeffs40 * cosCache41 * cosCache1 * Alpha +
                        coeffs41 * cosCache41 * cosCache9 +
                        coeffs42 * cosCache41 * cosCache17 +
                        coeffs43 * cosCache41 * cosCache25 +
                        coeffs44 * cosCache41 * cosCache33 +
                        coeffs45 * cosCache41 * cosCache41 +
                        coeffs46 * cosCache41 * cosCache49 +
                        coeffs47 * cosCache41 * cosCache57 +
                        coeffs48 * cosCache49 * cosCache1 * Alpha +
                        coeffs49 * cosCache49 * cosCache9 +
                        coeffs50 * cosCache49 * cosCache17 +
                        coeffs51 * cosCache49 * cosCache25 +
                        coeffs52 * cosCache49 * cosCache33 +
                        coeffs53 * cosCache49 * cosCache41 +
                        coeffs54 * cosCache49 * cosCache49 +
                        coeffs55 * cosCache49 * cosCache57 +
                        coeffs56 * cosCache57 * cosCache1 * Alpha +
                        coeffs57 * cosCache57 * cosCache9 +
                        coeffs58 * cosCache57 * cosCache17 +
                        coeffs59 * cosCache57 * cosCache25 +
                        coeffs60 * cosCache57 * cosCache33 +
                        coeffs61 * cosCache57 * cosCache41 +
                        coeffs62 * cosCache57 * cosCache49 +
                        coeffs63 * cosCache57 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 2] = (coeffs0 * cosCache1 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache10 * Alpha +
                        coeffs2 * cosCache1 * cosCache18 * Alpha +
                        coeffs3 * cosCache1 * cosCache26 * Alpha +
                        coeffs4 * cosCache1 * cosCache34 * Alpha +
                        coeffs5 * cosCache1 * cosCache42 * Alpha +
                        coeffs6 * cosCache1 * cosCache50 * Alpha +
                        coeffs7 * cosCache1 * cosCache58 * Alpha +
                        coeffs8 * cosCache9 * cosCache2 * Alpha +
                        coeffs9 * cosCache9 * cosCache10 +
                        coeffs10 * cosCache9 * cosCache18 +
                        coeffs11 * cosCache9 * cosCache26 +
                        coeffs12 * cosCache9 * cosCache34 +
                        coeffs13 * cosCache9 * cosCache42 +
                        coeffs14 * cosCache9 * cosCache50 +
                        coeffs15 * cosCache9 * cosCache58 +
                        coeffs16 * cosCache17 * cosCache2 * Alpha +
                        coeffs17 * cosCache17 * cosCache10 +
                        coeffs18 * cosCache17 * cosCache18 +
                        coeffs19 * cosCache17 * cosCache26 +
                        coeffs20 * cosCache17 * cosCache34 +
                        coeffs21 * cosCache17 * cosCache42 +
                        coeffs22 * cosCache17 * cosCache50 +
                        coeffs23 * cosCache17 * cosCache58 +
                        coeffs24 * cosCache25 * cosCache2 * Alpha +
                        coeffs25 * cosCache25 * cosCache10 +
                        coeffs26 * cosCache25 * cosCache18 +
                        coeffs27 * cosCache25 * cosCache26 +
                        coeffs28 * cosCache25 * cosCache34 +
                        coeffs29 * cosCache25 * cosCache42 +
                        coeffs30 * cosCache25 * cosCache50 +
                        coeffs31 * cosCache25 * cosCache58 +
                        coeffs32 * cosCache33 * cosCache2 * Alpha +
                        coeffs33 * cosCache33 * cosCache10 +
                        coeffs34 * cosCache33 * cosCache18 +
                        coeffs35 * cosCache33 * cosCache26 +
                        coeffs36 * cosCache33 * cosCache34 +
                        coeffs37 * cosCache33 * cosCache42 +
                        coeffs38 * cosCache33 * cosCache50 +
                        coeffs39 * cosCache33 * cosCache58 +
                        coeffs40 * cosCache41 * cosCache2 * Alpha +
                        coeffs41 * cosCache41 * cosCache10 +
                        coeffs42 * cosCache41 * cosCache18 +
                        coeffs43 * cosCache41 * cosCache26 +
                        coeffs44 * cosCache41 * cosCache34 +
                        coeffs45 * cosCache41 * cosCache42 +
                        coeffs46 * cosCache41 * cosCache50 +
                        coeffs47 * cosCache41 * cosCache58 +
                        coeffs48 * cosCache49 * cosCache2 * Alpha +
                        coeffs49 * cosCache49 * cosCache10 +
                        coeffs50 * cosCache49 * cosCache18 +
                        coeffs51 * cosCache49 * cosCache26 +
                        coeffs52 * cosCache49 * cosCache34 +
                        coeffs53 * cosCache49 * cosCache42 +
                        coeffs54 * cosCache49 * cosCache50 +
                        coeffs55 * cosCache49 * cosCache58 +
                        coeffs56 * cosCache57 * cosCache2 * Alpha +
                        coeffs57 * cosCache57 * cosCache10 +
                        coeffs58 * cosCache57 * cosCache18 +
                        coeffs59 * cosCache57 * cosCache26 +
                        coeffs60 * cosCache57 * cosCache34 +
                        coeffs61 * cosCache57 * cosCache42 +
                        coeffs62 * cosCache57 * cosCache50 +
                        coeffs63 * cosCache57 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 3] = (coeffs0 * cosCache1 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache11 * Alpha +
                        coeffs2 * cosCache1 * cosCache19 * Alpha +
                        coeffs3 * cosCache1 * cosCache27 * Alpha +
                        coeffs4 * cosCache1 * cosCache35 * Alpha +
                        coeffs5 * cosCache1 * cosCache43 * Alpha +
                        coeffs6 * cosCache1 * cosCache51 * Alpha +
                        coeffs7 * cosCache1 * cosCache59 * Alpha +
                        coeffs8 * cosCache9 * cosCache3 * Alpha +
                        coeffs9 * cosCache9 * cosCache11 +
                        coeffs10 * cosCache9 * cosCache19 +
                        coeffs11 * cosCache9 * cosCache27 +
                        coeffs12 * cosCache9 * cosCache35 +
                        coeffs13 * cosCache9 * cosCache43 +
                        coeffs14 * cosCache9 * cosCache51 +
                        coeffs15 * cosCache9 * cosCache59 +
                        coeffs16 * cosCache17 * cosCache3 * Alpha +
                        coeffs17 * cosCache17 * cosCache11 +
                        coeffs18 * cosCache17 * cosCache19 +
                        coeffs19 * cosCache17 * cosCache27 +
                        coeffs20 * cosCache17 * cosCache35 +
                        coeffs21 * cosCache17 * cosCache43 +
                        coeffs22 * cosCache17 * cosCache51 +
                        coeffs23 * cosCache17 * cosCache59 +
                        coeffs24 * cosCache25 * cosCache3 * Alpha +
                        coeffs25 * cosCache25 * cosCache11 +
                        coeffs26 * cosCache25 * cosCache19 +
                        coeffs27 * cosCache25 * cosCache27 +
                        coeffs28 * cosCache25 * cosCache35 +
                        coeffs29 * cosCache25 * cosCache43 +
                        coeffs30 * cosCache25 * cosCache51 +
                        coeffs31 * cosCache25 * cosCache59 +
                        coeffs32 * cosCache33 * cosCache3 * Alpha +
                        coeffs33 * cosCache33 * cosCache11 +
                        coeffs34 * cosCache33 * cosCache19 +
                        coeffs35 * cosCache33 * cosCache27 +
                        coeffs36 * cosCache33 * cosCache35 +
                        coeffs37 * cosCache33 * cosCache43 +
                        coeffs38 * cosCache33 * cosCache51 +
                        coeffs39 * cosCache33 * cosCache59 +
                        coeffs40 * cosCache41 * cosCache3 * Alpha +
                        coeffs41 * cosCache41 * cosCache11 +
                        coeffs42 * cosCache41 * cosCache19 +
                        coeffs43 * cosCache41 * cosCache27 +
                        coeffs44 * cosCache41 * cosCache35 +
                        coeffs45 * cosCache41 * cosCache43 +
                        coeffs46 * cosCache41 * cosCache51 +
                        coeffs47 * cosCache41 * cosCache59 +
                        coeffs48 * cosCache49 * cosCache3 * Alpha +
                        coeffs49 * cosCache49 * cosCache11 +
                        coeffs50 * cosCache49 * cosCache19 +
                        coeffs51 * cosCache49 * cosCache27 +
                        coeffs52 * cosCache49 * cosCache35 +
                        coeffs53 * cosCache49 * cosCache43 +
                        coeffs54 * cosCache49 * cosCache51 +
                        coeffs55 * cosCache49 * cosCache59 +
                        coeffs56 * cosCache57 * cosCache3 * Alpha +
                        coeffs57 * cosCache57 * cosCache11 +
                        coeffs58 * cosCache57 * cosCache19 +
                        coeffs59 * cosCache57 * cosCache27 +
                        coeffs60 * cosCache57 * cosCache35 +
                        coeffs61 * cosCache57 * cosCache43 +
                        coeffs62 * cosCache57 * cosCache51 +
                        coeffs63 * cosCache57 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 4] = (coeffs0 * cosCache1 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache12 * Alpha +
                        coeffs2 * cosCache1 * cosCache20 * Alpha +
                        coeffs3 * cosCache1 * cosCache28 * Alpha +
                        coeffs4 * cosCache1 * cosCache36 * Alpha +
                        coeffs5 * cosCache1 * cosCache44 * Alpha +
                        coeffs6 * cosCache1 * cosCache52 * Alpha +
                        coeffs7 * cosCache1 * cosCache60 * Alpha +
                        coeffs8 * cosCache9 * cosCache4 * Alpha +
                        coeffs9 * cosCache9 * cosCache12 +
                        coeffs10 * cosCache9 * cosCache20 +
                        coeffs11 * cosCache9 * cosCache28 +
                        coeffs12 * cosCache9 * cosCache36 +
                        coeffs13 * cosCache9 * cosCache44 +
                        coeffs14 * cosCache9 * cosCache52 +
                        coeffs15 * cosCache9 * cosCache60 +
                        coeffs16 * cosCache17 * cosCache4 * Alpha +
                        coeffs17 * cosCache17 * cosCache12 +
                        coeffs18 * cosCache17 * cosCache20 +
                        coeffs19 * cosCache17 * cosCache28 +
                        coeffs20 * cosCache17 * cosCache36 +
                        coeffs21 * cosCache17 * cosCache44 +
                        coeffs22 * cosCache17 * cosCache52 +
                        coeffs23 * cosCache17 * cosCache60 +
                        coeffs24 * cosCache25 * cosCache4 * Alpha +
                        coeffs25 * cosCache25 * cosCache12 +
                        coeffs26 * cosCache25 * cosCache20 +
                        coeffs27 * cosCache25 * cosCache28 +
                        coeffs28 * cosCache25 * cosCache36 +
                        coeffs29 * cosCache25 * cosCache44 +
                        coeffs30 * cosCache25 * cosCache52 +
                        coeffs31 * cosCache25 * cosCache60 +
                        coeffs32 * cosCache33 * cosCache4 * Alpha +
                        coeffs33 * cosCache33 * cosCache12 +
                        coeffs34 * cosCache33 * cosCache20 +
                        coeffs35 * cosCache33 * cosCache28 +
                        coeffs36 * cosCache33 * cosCache36 +
                        coeffs37 * cosCache33 * cosCache44 +
                        coeffs38 * cosCache33 * cosCache52 +
                        coeffs39 * cosCache33 * cosCache60 +
                        coeffs40 * cosCache41 * cosCache4 * Alpha +
                        coeffs41 * cosCache41 * cosCache12 +
                        coeffs42 * cosCache41 * cosCache20 +
                        coeffs43 * cosCache41 * cosCache28 +
                        coeffs44 * cosCache41 * cosCache36 +
                        coeffs45 * cosCache41 * cosCache44 +
                        coeffs46 * cosCache41 * cosCache52 +
                        coeffs47 * cosCache41 * cosCache60 +
                        coeffs48 * cosCache49 * cosCache4 * Alpha +
                        coeffs49 * cosCache49 * cosCache12 +
                        coeffs50 * cosCache49 * cosCache20 +
                        coeffs51 * cosCache49 * cosCache28 +
                        coeffs52 * cosCache49 * cosCache36 +
                        coeffs53 * cosCache49 * cosCache44 +
                        coeffs54 * cosCache49 * cosCache52 +
                        coeffs55 * cosCache49 * cosCache60 +
                        coeffs56 * cosCache57 * cosCache4 * Alpha +
                        coeffs57 * cosCache57 * cosCache12 +
                        coeffs58 * cosCache57 * cosCache20 +
                        coeffs59 * cosCache57 * cosCache28 +
                        coeffs60 * cosCache57 * cosCache36 +
                        coeffs61 * cosCache57 * cosCache44 +
                        coeffs62 * cosCache57 * cosCache52 +
                        coeffs63 * cosCache57 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 5] = (coeffs0 * cosCache1 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache13 * Alpha +
                        coeffs2 * cosCache1 * cosCache21 * Alpha +
                        coeffs3 * cosCache1 * cosCache29 * Alpha +
                        coeffs4 * cosCache1 * cosCache37 * Alpha +
                        coeffs5 * cosCache1 * cosCache45 * Alpha +
                        coeffs6 * cosCache1 * cosCache53 * Alpha +
                        coeffs7 * cosCache1 * cosCache61 * Alpha +
                        coeffs8 * cosCache9 * cosCache5 * Alpha +
                        coeffs9 * cosCache9 * cosCache13 +
                        coeffs10 * cosCache9 * cosCache21 +
                        coeffs11 * cosCache9 * cosCache29 +
                        coeffs12 * cosCache9 * cosCache37 +
                        coeffs13 * cosCache9 * cosCache45 +
                        coeffs14 * cosCache9 * cosCache53 +
                        coeffs15 * cosCache9 * cosCache61 +
                        coeffs16 * cosCache17 * cosCache5 * Alpha +
                        coeffs17 * cosCache17 * cosCache13 +
                        coeffs18 * cosCache17 * cosCache21 +
                        coeffs19 * cosCache17 * cosCache29 +
                        coeffs20 * cosCache17 * cosCache37 +
                        coeffs21 * cosCache17 * cosCache45 +
                        coeffs22 * cosCache17 * cosCache53 +
                        coeffs23 * cosCache17 * cosCache61 +
                        coeffs24 * cosCache25 * cosCache5 * Alpha +
                        coeffs25 * cosCache25 * cosCache13 +
                        coeffs26 * cosCache25 * cosCache21 +
                        coeffs27 * cosCache25 * cosCache29 +
                        coeffs28 * cosCache25 * cosCache37 +
                        coeffs29 * cosCache25 * cosCache45 +
                        coeffs30 * cosCache25 * cosCache53 +
                        coeffs31 * cosCache25 * cosCache61 +
                        coeffs32 * cosCache33 * cosCache5 * Alpha +
                        coeffs33 * cosCache33 * cosCache13 +
                        coeffs34 * cosCache33 * cosCache21 +
                        coeffs35 * cosCache33 * cosCache29 +
                        coeffs36 * cosCache33 * cosCache37 +
                        coeffs37 * cosCache33 * cosCache45 +
                        coeffs38 * cosCache33 * cosCache53 +
                        coeffs39 * cosCache33 * cosCache61 +
                        coeffs40 * cosCache41 * cosCache5 * Alpha +
                        coeffs41 * cosCache41 * cosCache13 +
                        coeffs42 * cosCache41 * cosCache21 +
                        coeffs43 * cosCache41 * cosCache29 +
                        coeffs44 * cosCache41 * cosCache37 +
                        coeffs45 * cosCache41 * cosCache45 +
                        coeffs46 * cosCache41 * cosCache53 +
                        coeffs47 * cosCache41 * cosCache61 +
                        coeffs48 * cosCache49 * cosCache5 * Alpha +
                        coeffs49 * cosCache49 * cosCache13 +
                        coeffs50 * cosCache49 * cosCache21 +
                        coeffs51 * cosCache49 * cosCache29 +
                        coeffs52 * cosCache49 * cosCache37 +
                        coeffs53 * cosCache49 * cosCache45 +
                        coeffs54 * cosCache49 * cosCache53 +
                        coeffs55 * cosCache49 * cosCache61 +
                        coeffs56 * cosCache57 * cosCache5 * Alpha +
                        coeffs57 * cosCache57 * cosCache13 +
                        coeffs58 * cosCache57 * cosCache21 +
                        coeffs59 * cosCache57 * cosCache29 +
                        coeffs60 * cosCache57 * cosCache37 +
                        coeffs61 * cosCache57 * cosCache45 +
                        coeffs62 * cosCache57 * cosCache53 +
                        coeffs63 * cosCache57 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 6] = (coeffs0 * cosCache1 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache14 * Alpha +
                        coeffs2 * cosCache1 * cosCache22 * Alpha +
                        coeffs3 * cosCache1 * cosCache30 * Alpha +
                        coeffs4 * cosCache1 * cosCache38 * Alpha +
                        coeffs5 * cosCache1 * cosCache46 * Alpha +
                        coeffs6 * cosCache1 * cosCache54 * Alpha +
                        coeffs7 * cosCache1 * cosCache62 * Alpha +
                        coeffs8 * cosCache9 * cosCache6 * Alpha +
                        coeffs9 * cosCache9 * cosCache14 +
                        coeffs10 * cosCache9 * cosCache22 +
                        coeffs11 * cosCache9 * cosCache30 +
                        coeffs12 * cosCache9 * cosCache38 +
                        coeffs13 * cosCache9 * cosCache46 +
                        coeffs14 * cosCache9 * cosCache54 +
                        coeffs15 * cosCache9 * cosCache62 +
                        coeffs16 * cosCache17 * cosCache6 * Alpha +
                        coeffs17 * cosCache17 * cosCache14 +
                        coeffs18 * cosCache17 * cosCache22 +
                        coeffs19 * cosCache17 * cosCache30 +
                        coeffs20 * cosCache17 * cosCache38 +
                        coeffs21 * cosCache17 * cosCache46 +
                        coeffs22 * cosCache17 * cosCache54 +
                        coeffs23 * cosCache17 * cosCache62 +
                        coeffs24 * cosCache25 * cosCache6 * Alpha +
                        coeffs25 * cosCache25 * cosCache14 +
                        coeffs26 * cosCache25 * cosCache22 +
                        coeffs27 * cosCache25 * cosCache30 +
                        coeffs28 * cosCache25 * cosCache38 +
                        coeffs29 * cosCache25 * cosCache46 +
                        coeffs30 * cosCache25 * cosCache54 +
                        coeffs31 * cosCache25 * cosCache62 +
                        coeffs32 * cosCache33 * cosCache6 * Alpha +
                        coeffs33 * cosCache33 * cosCache14 +
                        coeffs34 * cosCache33 * cosCache22 +
                        coeffs35 * cosCache33 * cosCache30 +
                        coeffs36 * cosCache33 * cosCache38 +
                        coeffs37 * cosCache33 * cosCache46 +
                        coeffs38 * cosCache33 * cosCache54 +
                        coeffs39 * cosCache33 * cosCache62 +
                        coeffs40 * cosCache41 * cosCache6 * Alpha +
                        coeffs41 * cosCache41 * cosCache14 +
                        coeffs42 * cosCache41 * cosCache22 +
                        coeffs43 * cosCache41 * cosCache30 +
                        coeffs44 * cosCache41 * cosCache38 +
                        coeffs45 * cosCache41 * cosCache46 +
                        coeffs46 * cosCache41 * cosCache54 +
                        coeffs47 * cosCache41 * cosCache62 +
                        coeffs48 * cosCache49 * cosCache6 * Alpha +
                        coeffs49 * cosCache49 * cosCache14 +
                        coeffs50 * cosCache49 * cosCache22 +
                        coeffs51 * cosCache49 * cosCache30 +
                        coeffs52 * cosCache49 * cosCache38 +
                        coeffs53 * cosCache49 * cosCache46 +
                        coeffs54 * cosCache49 * cosCache54 +
                        coeffs55 * cosCache49 * cosCache62 +
                        coeffs56 * cosCache57 * cosCache6 * Alpha +
                        coeffs57 * cosCache57 * cosCache14 +
                        coeffs58 * cosCache57 * cosCache22 +
                        coeffs59 * cosCache57 * cosCache30 +
                        coeffs60 * cosCache57 * cosCache38 +
                        coeffs61 * cosCache57 * cosCache46 +
                        coeffs62 * cosCache57 * cosCache54 +
                        coeffs63 * cosCache57 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[1, 7] = (coeffs0 * cosCache1 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache1 * cosCache15 * Alpha +
                        coeffs2 * cosCache1 * cosCache23 * Alpha +
                        coeffs3 * cosCache1 * cosCache31 * Alpha +
                        coeffs4 * cosCache1 * cosCache39 * Alpha +
                        coeffs5 * cosCache1 * cosCache47 * Alpha +
                        coeffs6 * cosCache1 * cosCache55 * Alpha +
                        coeffs7 * cosCache1 * cosCache63 * Alpha +
                        coeffs8 * cosCache9 * cosCache7 * Alpha +
                        coeffs9 * cosCache9 * cosCache15 +
                        coeffs10 * cosCache9 * cosCache23 +
                        coeffs11 * cosCache9 * cosCache31 +
                        coeffs12 * cosCache9 * cosCache39 +
                        coeffs13 * cosCache9 * cosCache47 +
                        coeffs14 * cosCache9 * cosCache55 +
                        coeffs15 * cosCache9 * cosCache63 +
                        coeffs16 * cosCache17 * cosCache7 * Alpha +
                        coeffs17 * cosCache17 * cosCache15 +
                        coeffs18 * cosCache17 * cosCache23 +
                        coeffs19 * cosCache17 * cosCache31 +
                        coeffs20 * cosCache17 * cosCache39 +
                        coeffs21 * cosCache17 * cosCache47 +
                        coeffs22 * cosCache17 * cosCache55 +
                        coeffs23 * cosCache17 * cosCache63 +
                        coeffs24 * cosCache25 * cosCache7 * Alpha +
                        coeffs25 * cosCache25 * cosCache15 +
                        coeffs26 * cosCache25 * cosCache23 +
                        coeffs27 * cosCache25 * cosCache31 +
                        coeffs28 * cosCache25 * cosCache39 +
                        coeffs29 * cosCache25 * cosCache47 +
                        coeffs30 * cosCache25 * cosCache55 +
                        coeffs31 * cosCache25 * cosCache63 +
                        coeffs32 * cosCache33 * cosCache7 * Alpha +
                        coeffs33 * cosCache33 * cosCache15 +
                        coeffs34 * cosCache33 * cosCache23 +
                        coeffs35 * cosCache33 * cosCache31 +
                        coeffs36 * cosCache33 * cosCache39 +
                        coeffs37 * cosCache33 * cosCache47 +
                        coeffs38 * cosCache33 * cosCache55 +
                        coeffs39 * cosCache33 * cosCache63 +
                        coeffs40 * cosCache41 * cosCache7 * Alpha +
                        coeffs41 * cosCache41 * cosCache15 +
                        coeffs42 * cosCache41 * cosCache23 +
                        coeffs43 * cosCache41 * cosCache31 +
                        coeffs44 * cosCache41 * cosCache39 +
                        coeffs45 * cosCache41 * cosCache47 +
                        coeffs46 * cosCache41 * cosCache55 +
                        coeffs47 * cosCache41 * cosCache63 +
                        coeffs48 * cosCache49 * cosCache7 * Alpha +
                        coeffs49 * cosCache49 * cosCache15 +
                        coeffs50 * cosCache49 * cosCache23 +
                        coeffs51 * cosCache49 * cosCache31 +
                        coeffs52 * cosCache49 * cosCache39 +
                        coeffs53 * cosCache49 * cosCache47 +
                        coeffs54 * cosCache49 * cosCache55 +
                        coeffs55 * cosCache49 * cosCache63 +
                        coeffs56 * cosCache57 * cosCache7 * Alpha +
                        coeffs57 * cosCache57 * cosCache15 +
                        coeffs58 * cosCache57 * cosCache23 +
                        coeffs59 * cosCache57 * cosCache31 +
                        coeffs60 * cosCache57 * cosCache39 +
                        coeffs61 * cosCache57 * cosCache47 +
                        coeffs62 * cosCache57 * cosCache55 +
                        coeffs63 * cosCache57 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 0] = (coeffs0 * cosCache2 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache8 * Alpha +
                        coeffs2 * cosCache2 * cosCache16 * Alpha +
                        coeffs3 * cosCache2 * cosCache24 * Alpha +
                        coeffs4 * cosCache2 * cosCache32 * Alpha +
                        coeffs5 * cosCache2 * cosCache40 * Alpha +
                        coeffs6 * cosCache2 * cosCache48 * Alpha +
                        coeffs7 * cosCache2 * cosCache56 * Alpha +
                        coeffs8 * cosCache10 * cosCache0 * Alpha +
                        coeffs9 * cosCache10 * cosCache8 +
                        coeffs10 * cosCache10 * cosCache16 +
                        coeffs11 * cosCache10 * cosCache24 +
                        coeffs12 * cosCache10 * cosCache32 +
                        coeffs13 * cosCache10 * cosCache40 +
                        coeffs14 * cosCache10 * cosCache48 +
                        coeffs15 * cosCache10 * cosCache56 +
                        coeffs16 * cosCache18 * cosCache0 * Alpha +
                        coeffs17 * cosCache18 * cosCache8 +
                        coeffs18 * cosCache18 * cosCache16 +
                        coeffs19 * cosCache18 * cosCache24 +
                        coeffs20 * cosCache18 * cosCache32 +
                        coeffs21 * cosCache18 * cosCache40 +
                        coeffs22 * cosCache18 * cosCache48 +
                        coeffs23 * cosCache18 * cosCache56 +
                        coeffs24 * cosCache26 * cosCache0 * Alpha +
                        coeffs25 * cosCache26 * cosCache8 +
                        coeffs26 * cosCache26 * cosCache16 +
                        coeffs27 * cosCache26 * cosCache24 +
                        coeffs28 * cosCache26 * cosCache32 +
                        coeffs29 * cosCache26 * cosCache40 +
                        coeffs30 * cosCache26 * cosCache48 +
                        coeffs31 * cosCache26 * cosCache56 +
                        coeffs32 * cosCache34 * cosCache0 * Alpha +
                        coeffs33 * cosCache34 * cosCache8 +
                        coeffs34 * cosCache34 * cosCache16 +
                        coeffs35 * cosCache34 * cosCache24 +
                        coeffs36 * cosCache34 * cosCache32 +
                        coeffs37 * cosCache34 * cosCache40 +
                        coeffs38 * cosCache34 * cosCache48 +
                        coeffs39 * cosCache34 * cosCache56 +
                        coeffs40 * cosCache42 * cosCache0 * Alpha +
                        coeffs41 * cosCache42 * cosCache8 +
                        coeffs42 * cosCache42 * cosCache16 +
                        coeffs43 * cosCache42 * cosCache24 +
                        coeffs44 * cosCache42 * cosCache32 +
                        coeffs45 * cosCache42 * cosCache40 +
                        coeffs46 * cosCache42 * cosCache48 +
                        coeffs47 * cosCache42 * cosCache56 +
                        coeffs48 * cosCache50 * cosCache0 * Alpha +
                        coeffs49 * cosCache50 * cosCache8 +
                        coeffs50 * cosCache50 * cosCache16 +
                        coeffs51 * cosCache50 * cosCache24 +
                        coeffs52 * cosCache50 * cosCache32 +
                        coeffs53 * cosCache50 * cosCache40 +
                        coeffs54 * cosCache50 * cosCache48 +
                        coeffs55 * cosCache50 * cosCache56 +
                        coeffs56 * cosCache58 * cosCache0 * Alpha +
                        coeffs57 * cosCache58 * cosCache8 +
                        coeffs58 * cosCache58 * cosCache16 +
                        coeffs59 * cosCache58 * cosCache24 +
                        coeffs60 * cosCache58 * cosCache32 +
                        coeffs61 * cosCache58 * cosCache40 +
                        coeffs62 * cosCache58 * cosCache48 +
                        coeffs63 * cosCache58 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 1] = (coeffs0 * cosCache2 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache9 * Alpha +
                        coeffs2 * cosCache2 * cosCache17 * Alpha +
                        coeffs3 * cosCache2 * cosCache25 * Alpha +
                        coeffs4 * cosCache2 * cosCache33 * Alpha +
                        coeffs5 * cosCache2 * cosCache41 * Alpha +
                        coeffs6 * cosCache2 * cosCache49 * Alpha +
                        coeffs7 * cosCache2 * cosCache57 * Alpha +
                        coeffs8 * cosCache10 * cosCache1 * Alpha +
                        coeffs9 * cosCache10 * cosCache9 +
                        coeffs10 * cosCache10 * cosCache17 +
                        coeffs11 * cosCache10 * cosCache25 +
                        coeffs12 * cosCache10 * cosCache33 +
                        coeffs13 * cosCache10 * cosCache41 +
                        coeffs14 * cosCache10 * cosCache49 +
                        coeffs15 * cosCache10 * cosCache57 +
                        coeffs16 * cosCache18 * cosCache1 * Alpha +
                        coeffs17 * cosCache18 * cosCache9 +
                        coeffs18 * cosCache18 * cosCache17 +
                        coeffs19 * cosCache18 * cosCache25 +
                        coeffs20 * cosCache18 * cosCache33 +
                        coeffs21 * cosCache18 * cosCache41 +
                        coeffs22 * cosCache18 * cosCache49 +
                        coeffs23 * cosCache18 * cosCache57 +
                        coeffs24 * cosCache26 * cosCache1 * Alpha +
                        coeffs25 * cosCache26 * cosCache9 +
                        coeffs26 * cosCache26 * cosCache17 +
                        coeffs27 * cosCache26 * cosCache25 +
                        coeffs28 * cosCache26 * cosCache33 +
                        coeffs29 * cosCache26 * cosCache41 +
                        coeffs30 * cosCache26 * cosCache49 +
                        coeffs31 * cosCache26 * cosCache57 +
                        coeffs32 * cosCache34 * cosCache1 * Alpha +
                        coeffs33 * cosCache34 * cosCache9 +
                        coeffs34 * cosCache34 * cosCache17 +
                        coeffs35 * cosCache34 * cosCache25 +
                        coeffs36 * cosCache34 * cosCache33 +
                        coeffs37 * cosCache34 * cosCache41 +
                        coeffs38 * cosCache34 * cosCache49 +
                        coeffs39 * cosCache34 * cosCache57 +
                        coeffs40 * cosCache42 * cosCache1 * Alpha +
                        coeffs41 * cosCache42 * cosCache9 +
                        coeffs42 * cosCache42 * cosCache17 +
                        coeffs43 * cosCache42 * cosCache25 +
                        coeffs44 * cosCache42 * cosCache33 +
                        coeffs45 * cosCache42 * cosCache41 +
                        coeffs46 * cosCache42 * cosCache49 +
                        coeffs47 * cosCache42 * cosCache57 +
                        coeffs48 * cosCache50 * cosCache1 * Alpha +
                        coeffs49 * cosCache50 * cosCache9 +
                        coeffs50 * cosCache50 * cosCache17 +
                        coeffs51 * cosCache50 * cosCache25 +
                        coeffs52 * cosCache50 * cosCache33 +
                        coeffs53 * cosCache50 * cosCache41 +
                        coeffs54 * cosCache50 * cosCache49 +
                        coeffs55 * cosCache50 * cosCache57 +
                        coeffs56 * cosCache58 * cosCache1 * Alpha +
                        coeffs57 * cosCache58 * cosCache9 +
                        coeffs58 * cosCache58 * cosCache17 +
                        coeffs59 * cosCache58 * cosCache25 +
                        coeffs60 * cosCache58 * cosCache33 +
                        coeffs61 * cosCache58 * cosCache41 +
                        coeffs62 * cosCache58 * cosCache49 +
                        coeffs63 * cosCache58 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 2] = (coeffs0 * cosCache2 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache10 * Alpha +
                        coeffs2 * cosCache2 * cosCache18 * Alpha +
                        coeffs3 * cosCache2 * cosCache26 * Alpha +
                        coeffs4 * cosCache2 * cosCache34 * Alpha +
                        coeffs5 * cosCache2 * cosCache42 * Alpha +
                        coeffs6 * cosCache2 * cosCache50 * Alpha +
                        coeffs7 * cosCache2 * cosCache58 * Alpha +
                        coeffs8 * cosCache10 * cosCache2 * Alpha +
                        coeffs9 * cosCache10 * cosCache10 +
                        coeffs10 * cosCache10 * cosCache18 +
                        coeffs11 * cosCache10 * cosCache26 +
                        coeffs12 * cosCache10 * cosCache34 +
                        coeffs13 * cosCache10 * cosCache42 +
                        coeffs14 * cosCache10 * cosCache50 +
                        coeffs15 * cosCache10 * cosCache58 +
                        coeffs16 * cosCache18 * cosCache2 * Alpha +
                        coeffs17 * cosCache18 * cosCache10 +
                        coeffs18 * cosCache18 * cosCache18 +
                        coeffs19 * cosCache18 * cosCache26 +
                        coeffs20 * cosCache18 * cosCache34 +
                        coeffs21 * cosCache18 * cosCache42 +
                        coeffs22 * cosCache18 * cosCache50 +
                        coeffs23 * cosCache18 * cosCache58 +
                        coeffs24 * cosCache26 * cosCache2 * Alpha +
                        coeffs25 * cosCache26 * cosCache10 +
                        coeffs26 * cosCache26 * cosCache18 +
                        coeffs27 * cosCache26 * cosCache26 +
                        coeffs28 * cosCache26 * cosCache34 +
                        coeffs29 * cosCache26 * cosCache42 +
                        coeffs30 * cosCache26 * cosCache50 +
                        coeffs31 * cosCache26 * cosCache58 +
                        coeffs32 * cosCache34 * cosCache2 * Alpha +
                        coeffs33 * cosCache34 * cosCache10 +
                        coeffs34 * cosCache34 * cosCache18 +
                        coeffs35 * cosCache34 * cosCache26 +
                        coeffs36 * cosCache34 * cosCache34 +
                        coeffs37 * cosCache34 * cosCache42 +
                        coeffs38 * cosCache34 * cosCache50 +
                        coeffs39 * cosCache34 * cosCache58 +
                        coeffs40 * cosCache42 * cosCache2 * Alpha +
                        coeffs41 * cosCache42 * cosCache10 +
                        coeffs42 * cosCache42 * cosCache18 +
                        coeffs43 * cosCache42 * cosCache26 +
                        coeffs44 * cosCache42 * cosCache34 +
                        coeffs45 * cosCache42 * cosCache42 +
                        coeffs46 * cosCache42 * cosCache50 +
                        coeffs47 * cosCache42 * cosCache58 +
                        coeffs48 * cosCache50 * cosCache2 * Alpha +
                        coeffs49 * cosCache50 * cosCache10 +
                        coeffs50 * cosCache50 * cosCache18 +
                        coeffs51 * cosCache50 * cosCache26 +
                        coeffs52 * cosCache50 * cosCache34 +
                        coeffs53 * cosCache50 * cosCache42 +
                        coeffs54 * cosCache50 * cosCache50 +
                        coeffs55 * cosCache50 * cosCache58 +
                        coeffs56 * cosCache58 * cosCache2 * Alpha +
                        coeffs57 * cosCache58 * cosCache10 +
                        coeffs58 * cosCache58 * cosCache18 +
                        coeffs59 * cosCache58 * cosCache26 +
                        coeffs60 * cosCache58 * cosCache34 +
                        coeffs61 * cosCache58 * cosCache42 +
                        coeffs62 * cosCache58 * cosCache50 +
                        coeffs63 * cosCache58 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 3] = (coeffs0 * cosCache2 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache11 * Alpha +
                        coeffs2 * cosCache2 * cosCache19 * Alpha +
                        coeffs3 * cosCache2 * cosCache27 * Alpha +
                        coeffs4 * cosCache2 * cosCache35 * Alpha +
                        coeffs5 * cosCache2 * cosCache43 * Alpha +
                        coeffs6 * cosCache2 * cosCache51 * Alpha +
                        coeffs7 * cosCache2 * cosCache59 * Alpha +
                        coeffs8 * cosCache10 * cosCache3 * Alpha +
                        coeffs9 * cosCache10 * cosCache11 +
                        coeffs10 * cosCache10 * cosCache19 +
                        coeffs11 * cosCache10 * cosCache27 +
                        coeffs12 * cosCache10 * cosCache35 +
                        coeffs13 * cosCache10 * cosCache43 +
                        coeffs14 * cosCache10 * cosCache51 +
                        coeffs15 * cosCache10 * cosCache59 +
                        coeffs16 * cosCache18 * cosCache3 * Alpha +
                        coeffs17 * cosCache18 * cosCache11 +
                        coeffs18 * cosCache18 * cosCache19 +
                        coeffs19 * cosCache18 * cosCache27 +
                        coeffs20 * cosCache18 * cosCache35 +
                        coeffs21 * cosCache18 * cosCache43 +
                        coeffs22 * cosCache18 * cosCache51 +
                        coeffs23 * cosCache18 * cosCache59 +
                        coeffs24 * cosCache26 * cosCache3 * Alpha +
                        coeffs25 * cosCache26 * cosCache11 +
                        coeffs26 * cosCache26 * cosCache19 +
                        coeffs27 * cosCache26 * cosCache27 +
                        coeffs28 * cosCache26 * cosCache35 +
                        coeffs29 * cosCache26 * cosCache43 +
                        coeffs30 * cosCache26 * cosCache51 +
                        coeffs31 * cosCache26 * cosCache59 +
                        coeffs32 * cosCache34 * cosCache3 * Alpha +
                        coeffs33 * cosCache34 * cosCache11 +
                        coeffs34 * cosCache34 * cosCache19 +
                        coeffs35 * cosCache34 * cosCache27 +
                        coeffs36 * cosCache34 * cosCache35 +
                        coeffs37 * cosCache34 * cosCache43 +
                        coeffs38 * cosCache34 * cosCache51 +
                        coeffs39 * cosCache34 * cosCache59 +
                        coeffs40 * cosCache42 * cosCache3 * Alpha +
                        coeffs41 * cosCache42 * cosCache11 +
                        coeffs42 * cosCache42 * cosCache19 +
                        coeffs43 * cosCache42 * cosCache27 +
                        coeffs44 * cosCache42 * cosCache35 +
                        coeffs45 * cosCache42 * cosCache43 +
                        coeffs46 * cosCache42 * cosCache51 +
                        coeffs47 * cosCache42 * cosCache59 +
                        coeffs48 * cosCache50 * cosCache3 * Alpha +
                        coeffs49 * cosCache50 * cosCache11 +
                        coeffs50 * cosCache50 * cosCache19 +
                        coeffs51 * cosCache50 * cosCache27 +
                        coeffs52 * cosCache50 * cosCache35 +
                        coeffs53 * cosCache50 * cosCache43 +
                        coeffs54 * cosCache50 * cosCache51 +
                        coeffs55 * cosCache50 * cosCache59 +
                        coeffs56 * cosCache58 * cosCache3 * Alpha +
                        coeffs57 * cosCache58 * cosCache11 +
                        coeffs58 * cosCache58 * cosCache19 +
                        coeffs59 * cosCache58 * cosCache27 +
                        coeffs60 * cosCache58 * cosCache35 +
                        coeffs61 * cosCache58 * cosCache43 +
                        coeffs62 * cosCache58 * cosCache51 +
                        coeffs63 * cosCache58 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 4] = (coeffs0 * cosCache2 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache12 * Alpha +
                        coeffs2 * cosCache2 * cosCache20 * Alpha +
                        coeffs3 * cosCache2 * cosCache28 * Alpha +
                        coeffs4 * cosCache2 * cosCache36 * Alpha +
                        coeffs5 * cosCache2 * cosCache44 * Alpha +
                        coeffs6 * cosCache2 * cosCache52 * Alpha +
                        coeffs7 * cosCache2 * cosCache60 * Alpha +
                        coeffs8 * cosCache10 * cosCache4 * Alpha +
                        coeffs9 * cosCache10 * cosCache12 +
                        coeffs10 * cosCache10 * cosCache20 +
                        coeffs11 * cosCache10 * cosCache28 +
                        coeffs12 * cosCache10 * cosCache36 +
                        coeffs13 * cosCache10 * cosCache44 +
                        coeffs14 * cosCache10 * cosCache52 +
                        coeffs15 * cosCache10 * cosCache60 +
                        coeffs16 * cosCache18 * cosCache4 * Alpha +
                        coeffs17 * cosCache18 * cosCache12 +
                        coeffs18 * cosCache18 * cosCache20 +
                        coeffs19 * cosCache18 * cosCache28 +
                        coeffs20 * cosCache18 * cosCache36 +
                        coeffs21 * cosCache18 * cosCache44 +
                        coeffs22 * cosCache18 * cosCache52 +
                        coeffs23 * cosCache18 * cosCache60 +
                        coeffs24 * cosCache26 * cosCache4 * Alpha +
                        coeffs25 * cosCache26 * cosCache12 +
                        coeffs26 * cosCache26 * cosCache20 +
                        coeffs27 * cosCache26 * cosCache28 +
                        coeffs28 * cosCache26 * cosCache36 +
                        coeffs29 * cosCache26 * cosCache44 +
                        coeffs30 * cosCache26 * cosCache52 +
                        coeffs31 * cosCache26 * cosCache60 +
                        coeffs32 * cosCache34 * cosCache4 * Alpha +
                        coeffs33 * cosCache34 * cosCache12 +
                        coeffs34 * cosCache34 * cosCache20 +
                        coeffs35 * cosCache34 * cosCache28 +
                        coeffs36 * cosCache34 * cosCache36 +
                        coeffs37 * cosCache34 * cosCache44 +
                        coeffs38 * cosCache34 * cosCache52 +
                        coeffs39 * cosCache34 * cosCache60 +
                        coeffs40 * cosCache42 * cosCache4 * Alpha +
                        coeffs41 * cosCache42 * cosCache12 +
                        coeffs42 * cosCache42 * cosCache20 +
                        coeffs43 * cosCache42 * cosCache28 +
                        coeffs44 * cosCache42 * cosCache36 +
                        coeffs45 * cosCache42 * cosCache44 +
                        coeffs46 * cosCache42 * cosCache52 +
                        coeffs47 * cosCache42 * cosCache60 +
                        coeffs48 * cosCache50 * cosCache4 * Alpha +
                        coeffs49 * cosCache50 * cosCache12 +
                        coeffs50 * cosCache50 * cosCache20 +
                        coeffs51 * cosCache50 * cosCache28 +
                        coeffs52 * cosCache50 * cosCache36 +
                        coeffs53 * cosCache50 * cosCache44 +
                        coeffs54 * cosCache50 * cosCache52 +
                        coeffs55 * cosCache50 * cosCache60 +
                        coeffs56 * cosCache58 * cosCache4 * Alpha +
                        coeffs57 * cosCache58 * cosCache12 +
                        coeffs58 * cosCache58 * cosCache20 +
                        coeffs59 * cosCache58 * cosCache28 +
                        coeffs60 * cosCache58 * cosCache36 +
                        coeffs61 * cosCache58 * cosCache44 +
                        coeffs62 * cosCache58 * cosCache52 +
                        coeffs63 * cosCache58 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 5] = (coeffs0 * cosCache2 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache13 * Alpha +
                        coeffs2 * cosCache2 * cosCache21 * Alpha +
                        coeffs3 * cosCache2 * cosCache29 * Alpha +
                        coeffs4 * cosCache2 * cosCache37 * Alpha +
                        coeffs5 * cosCache2 * cosCache45 * Alpha +
                        coeffs6 * cosCache2 * cosCache53 * Alpha +
                        coeffs7 * cosCache2 * cosCache61 * Alpha +
                        coeffs8 * cosCache10 * cosCache5 * Alpha +
                        coeffs9 * cosCache10 * cosCache13 +
                        coeffs10 * cosCache10 * cosCache21 +
                        coeffs11 * cosCache10 * cosCache29 +
                        coeffs12 * cosCache10 * cosCache37 +
                        coeffs13 * cosCache10 * cosCache45 +
                        coeffs14 * cosCache10 * cosCache53 +
                        coeffs15 * cosCache10 * cosCache61 +
                        coeffs16 * cosCache18 * cosCache5 * Alpha +
                        coeffs17 * cosCache18 * cosCache13 +
                        coeffs18 * cosCache18 * cosCache21 +
                        coeffs19 * cosCache18 * cosCache29 +
                        coeffs20 * cosCache18 * cosCache37 +
                        coeffs21 * cosCache18 * cosCache45 +
                        coeffs22 * cosCache18 * cosCache53 +
                        coeffs23 * cosCache18 * cosCache61 +
                        coeffs24 * cosCache26 * cosCache5 * Alpha +
                        coeffs25 * cosCache26 * cosCache13 +
                        coeffs26 * cosCache26 * cosCache21 +
                        coeffs27 * cosCache26 * cosCache29 +
                        coeffs28 * cosCache26 * cosCache37 +
                        coeffs29 * cosCache26 * cosCache45 +
                        coeffs30 * cosCache26 * cosCache53 +
                        coeffs31 * cosCache26 * cosCache61 +
                        coeffs32 * cosCache34 * cosCache5 * Alpha +
                        coeffs33 * cosCache34 * cosCache13 +
                        coeffs34 * cosCache34 * cosCache21 +
                        coeffs35 * cosCache34 * cosCache29 +
                        coeffs36 * cosCache34 * cosCache37 +
                        coeffs37 * cosCache34 * cosCache45 +
                        coeffs38 * cosCache34 * cosCache53 +
                        coeffs39 * cosCache34 * cosCache61 +
                        coeffs40 * cosCache42 * cosCache5 * Alpha +
                        coeffs41 * cosCache42 * cosCache13 +
                        coeffs42 * cosCache42 * cosCache21 +
                        coeffs43 * cosCache42 * cosCache29 +
                        coeffs44 * cosCache42 * cosCache37 +
                        coeffs45 * cosCache42 * cosCache45 +
                        coeffs46 * cosCache42 * cosCache53 +
                        coeffs47 * cosCache42 * cosCache61 +
                        coeffs48 * cosCache50 * cosCache5 * Alpha +
                        coeffs49 * cosCache50 * cosCache13 +
                        coeffs50 * cosCache50 * cosCache21 +
                        coeffs51 * cosCache50 * cosCache29 +
                        coeffs52 * cosCache50 * cosCache37 +
                        coeffs53 * cosCache50 * cosCache45 +
                        coeffs54 * cosCache50 * cosCache53 +
                        coeffs55 * cosCache50 * cosCache61 +
                        coeffs56 * cosCache58 * cosCache5 * Alpha +
                        coeffs57 * cosCache58 * cosCache13 +
                        coeffs58 * cosCache58 * cosCache21 +
                        coeffs59 * cosCache58 * cosCache29 +
                        coeffs60 * cosCache58 * cosCache37 +
                        coeffs61 * cosCache58 * cosCache45 +
                        coeffs62 * cosCache58 * cosCache53 +
                        coeffs63 * cosCache58 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 6] = (coeffs0 * cosCache2 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache14 * Alpha +
                        coeffs2 * cosCache2 * cosCache22 * Alpha +
                        coeffs3 * cosCache2 * cosCache30 * Alpha +
                        coeffs4 * cosCache2 * cosCache38 * Alpha +
                        coeffs5 * cosCache2 * cosCache46 * Alpha +
                        coeffs6 * cosCache2 * cosCache54 * Alpha +
                        coeffs7 * cosCache2 * cosCache62 * Alpha +
                        coeffs8 * cosCache10 * cosCache6 * Alpha +
                        coeffs9 * cosCache10 * cosCache14 +
                        coeffs10 * cosCache10 * cosCache22 +
                        coeffs11 * cosCache10 * cosCache30 +
                        coeffs12 * cosCache10 * cosCache38 +
                        coeffs13 * cosCache10 * cosCache46 +
                        coeffs14 * cosCache10 * cosCache54 +
                        coeffs15 * cosCache10 * cosCache62 +
                        coeffs16 * cosCache18 * cosCache6 * Alpha +
                        coeffs17 * cosCache18 * cosCache14 +
                        coeffs18 * cosCache18 * cosCache22 +
                        coeffs19 * cosCache18 * cosCache30 +
                        coeffs20 * cosCache18 * cosCache38 +
                        coeffs21 * cosCache18 * cosCache46 +
                        coeffs22 * cosCache18 * cosCache54 +
                        coeffs23 * cosCache18 * cosCache62 +
                        coeffs24 * cosCache26 * cosCache6 * Alpha +
                        coeffs25 * cosCache26 * cosCache14 +
                        coeffs26 * cosCache26 * cosCache22 +
                        coeffs27 * cosCache26 * cosCache30 +
                        coeffs28 * cosCache26 * cosCache38 +
                        coeffs29 * cosCache26 * cosCache46 +
                        coeffs30 * cosCache26 * cosCache54 +
                        coeffs31 * cosCache26 * cosCache62 +
                        coeffs32 * cosCache34 * cosCache6 * Alpha +
                        coeffs33 * cosCache34 * cosCache14 +
                        coeffs34 * cosCache34 * cosCache22 +
                        coeffs35 * cosCache34 * cosCache30 +
                        coeffs36 * cosCache34 * cosCache38 +
                        coeffs37 * cosCache34 * cosCache46 +
                        coeffs38 * cosCache34 * cosCache54 +
                        coeffs39 * cosCache34 * cosCache62 +
                        coeffs40 * cosCache42 * cosCache6 * Alpha +
                        coeffs41 * cosCache42 * cosCache14 +
                        coeffs42 * cosCache42 * cosCache22 +
                        coeffs43 * cosCache42 * cosCache30 +
                        coeffs44 * cosCache42 * cosCache38 +
                        coeffs45 * cosCache42 * cosCache46 +
                        coeffs46 * cosCache42 * cosCache54 +
                        coeffs47 * cosCache42 * cosCache62 +
                        coeffs48 * cosCache50 * cosCache6 * Alpha +
                        coeffs49 * cosCache50 * cosCache14 +
                        coeffs50 * cosCache50 * cosCache22 +
                        coeffs51 * cosCache50 * cosCache30 +
                        coeffs52 * cosCache50 * cosCache38 +
                        coeffs53 * cosCache50 * cosCache46 +
                        coeffs54 * cosCache50 * cosCache54 +
                        coeffs55 * cosCache50 * cosCache62 +
                        coeffs56 * cosCache58 * cosCache6 * Alpha +
                        coeffs57 * cosCache58 * cosCache14 +
                        coeffs58 * cosCache58 * cosCache22 +
                        coeffs59 * cosCache58 * cosCache30 +
                        coeffs60 * cosCache58 * cosCache38 +
                        coeffs61 * cosCache58 * cosCache46 +
                        coeffs62 * cosCache58 * cosCache54 +
                        coeffs63 * cosCache58 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[2, 7] = (coeffs0 * cosCache2 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache2 * cosCache15 * Alpha +
                        coeffs2 * cosCache2 * cosCache23 * Alpha +
                        coeffs3 * cosCache2 * cosCache31 * Alpha +
                        coeffs4 * cosCache2 * cosCache39 * Alpha +
                        coeffs5 * cosCache2 * cosCache47 * Alpha +
                        coeffs6 * cosCache2 * cosCache55 * Alpha +
                        coeffs7 * cosCache2 * cosCache63 * Alpha +
                        coeffs8 * cosCache10 * cosCache7 * Alpha +
                        coeffs9 * cosCache10 * cosCache15 +
                        coeffs10 * cosCache10 * cosCache23 +
                        coeffs11 * cosCache10 * cosCache31 +
                        coeffs12 * cosCache10 * cosCache39 +
                        coeffs13 * cosCache10 * cosCache47 +
                        coeffs14 * cosCache10 * cosCache55 +
                        coeffs15 * cosCache10 * cosCache63 +
                        coeffs16 * cosCache18 * cosCache7 * Alpha +
                        coeffs17 * cosCache18 * cosCache15 +
                        coeffs18 * cosCache18 * cosCache23 +
                        coeffs19 * cosCache18 * cosCache31 +
                        coeffs20 * cosCache18 * cosCache39 +
                        coeffs21 * cosCache18 * cosCache47 +
                        coeffs22 * cosCache18 * cosCache55 +
                        coeffs23 * cosCache18 * cosCache63 +
                        coeffs24 * cosCache26 * cosCache7 * Alpha +
                        coeffs25 * cosCache26 * cosCache15 +
                        coeffs26 * cosCache26 * cosCache23 +
                        coeffs27 * cosCache26 * cosCache31 +
                        coeffs28 * cosCache26 * cosCache39 +
                        coeffs29 * cosCache26 * cosCache47 +
                        coeffs30 * cosCache26 * cosCache55 +
                        coeffs31 * cosCache26 * cosCache63 +
                        coeffs32 * cosCache34 * cosCache7 * Alpha +
                        coeffs33 * cosCache34 * cosCache15 +
                        coeffs34 * cosCache34 * cosCache23 +
                        coeffs35 * cosCache34 * cosCache31 +
                        coeffs36 * cosCache34 * cosCache39 +
                        coeffs37 * cosCache34 * cosCache47 +
                        coeffs38 * cosCache34 * cosCache55 +
                        coeffs39 * cosCache34 * cosCache63 +
                        coeffs40 * cosCache42 * cosCache7 * Alpha +
                        coeffs41 * cosCache42 * cosCache15 +
                        coeffs42 * cosCache42 * cosCache23 +
                        coeffs43 * cosCache42 * cosCache31 +
                        coeffs44 * cosCache42 * cosCache39 +
                        coeffs45 * cosCache42 * cosCache47 +
                        coeffs46 * cosCache42 * cosCache55 +
                        coeffs47 * cosCache42 * cosCache63 +
                        coeffs48 * cosCache50 * cosCache7 * Alpha +
                        coeffs49 * cosCache50 * cosCache15 +
                        coeffs50 * cosCache50 * cosCache23 +
                        coeffs51 * cosCache50 * cosCache31 +
                        coeffs52 * cosCache50 * cosCache39 +
                        coeffs53 * cosCache50 * cosCache47 +
                        coeffs54 * cosCache50 * cosCache55 +
                        coeffs55 * cosCache50 * cosCache63 +
                        coeffs56 * cosCache58 * cosCache7 * Alpha +
                        coeffs57 * cosCache58 * cosCache15 +
                        coeffs58 * cosCache58 * cosCache23 +
                        coeffs59 * cosCache58 * cosCache31 +
                        coeffs60 * cosCache58 * cosCache39 +
                        coeffs61 * cosCache58 * cosCache47 +
                        coeffs62 * cosCache58 * cosCache55 +
                        coeffs63 * cosCache58 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 0] = (coeffs0 * cosCache3 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache8 * Alpha +
                        coeffs2 * cosCache3 * cosCache16 * Alpha +
                        coeffs3 * cosCache3 * cosCache24 * Alpha +
                        coeffs4 * cosCache3 * cosCache32 * Alpha +
                        coeffs5 * cosCache3 * cosCache40 * Alpha +
                        coeffs6 * cosCache3 * cosCache48 * Alpha +
                        coeffs7 * cosCache3 * cosCache56 * Alpha +
                        coeffs8 * cosCache11 * cosCache0 * Alpha +
                        coeffs9 * cosCache11 * cosCache8 +
                        coeffs10 * cosCache11 * cosCache16 +
                        coeffs11 * cosCache11 * cosCache24 +
                        coeffs12 * cosCache11 * cosCache32 +
                        coeffs13 * cosCache11 * cosCache40 +
                        coeffs14 * cosCache11 * cosCache48 +
                        coeffs15 * cosCache11 * cosCache56 +
                        coeffs16 * cosCache19 * cosCache0 * Alpha +
                        coeffs17 * cosCache19 * cosCache8 +
                        coeffs18 * cosCache19 * cosCache16 +
                        coeffs19 * cosCache19 * cosCache24 +
                        coeffs20 * cosCache19 * cosCache32 +
                        coeffs21 * cosCache19 * cosCache40 +
                        coeffs22 * cosCache19 * cosCache48 +
                        coeffs23 * cosCache19 * cosCache56 +
                        coeffs24 * cosCache27 * cosCache0 * Alpha +
                        coeffs25 * cosCache27 * cosCache8 +
                        coeffs26 * cosCache27 * cosCache16 +
                        coeffs27 * cosCache27 * cosCache24 +
                        coeffs28 * cosCache27 * cosCache32 +
                        coeffs29 * cosCache27 * cosCache40 +
                        coeffs30 * cosCache27 * cosCache48 +
                        coeffs31 * cosCache27 * cosCache56 +
                        coeffs32 * cosCache35 * cosCache0 * Alpha +
                        coeffs33 * cosCache35 * cosCache8 +
                        coeffs34 * cosCache35 * cosCache16 +
                        coeffs35 * cosCache35 * cosCache24 +
                        coeffs36 * cosCache35 * cosCache32 +
                        coeffs37 * cosCache35 * cosCache40 +
                        coeffs38 * cosCache35 * cosCache48 +
                        coeffs39 * cosCache35 * cosCache56 +
                        coeffs40 * cosCache43 * cosCache0 * Alpha +
                        coeffs41 * cosCache43 * cosCache8 +
                        coeffs42 * cosCache43 * cosCache16 +
                        coeffs43 * cosCache43 * cosCache24 +
                        coeffs44 * cosCache43 * cosCache32 +
                        coeffs45 * cosCache43 * cosCache40 +
                        coeffs46 * cosCache43 * cosCache48 +
                        coeffs47 * cosCache43 * cosCache56 +
                        coeffs48 * cosCache51 * cosCache0 * Alpha +
                        coeffs49 * cosCache51 * cosCache8 +
                        coeffs50 * cosCache51 * cosCache16 +
                        coeffs51 * cosCache51 * cosCache24 +
                        coeffs52 * cosCache51 * cosCache32 +
                        coeffs53 * cosCache51 * cosCache40 +
                        coeffs54 * cosCache51 * cosCache48 +
                        coeffs55 * cosCache51 * cosCache56 +
                        coeffs56 * cosCache59 * cosCache0 * Alpha +
                        coeffs57 * cosCache59 * cosCache8 +
                        coeffs58 * cosCache59 * cosCache16 +
                        coeffs59 * cosCache59 * cosCache24 +
                        coeffs60 * cosCache59 * cosCache32 +
                        coeffs61 * cosCache59 * cosCache40 +
                        coeffs62 * cosCache59 * cosCache48 +
                        coeffs63 * cosCache59 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 1] = (coeffs0 * cosCache3 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache9 * Alpha +
                        coeffs2 * cosCache3 * cosCache17 * Alpha +
                        coeffs3 * cosCache3 * cosCache25 * Alpha +
                        coeffs4 * cosCache3 * cosCache33 * Alpha +
                        coeffs5 * cosCache3 * cosCache41 * Alpha +
                        coeffs6 * cosCache3 * cosCache49 * Alpha +
                        coeffs7 * cosCache3 * cosCache57 * Alpha +
                        coeffs8 * cosCache11 * cosCache1 * Alpha +
                        coeffs9 * cosCache11 * cosCache9 +
                        coeffs10 * cosCache11 * cosCache17 +
                        coeffs11 * cosCache11 * cosCache25 +
                        coeffs12 * cosCache11 * cosCache33 +
                        coeffs13 * cosCache11 * cosCache41 +
                        coeffs14 * cosCache11 * cosCache49 +
                        coeffs15 * cosCache11 * cosCache57 +
                        coeffs16 * cosCache19 * cosCache1 * Alpha +
                        coeffs17 * cosCache19 * cosCache9 +
                        coeffs18 * cosCache19 * cosCache17 +
                        coeffs19 * cosCache19 * cosCache25 +
                        coeffs20 * cosCache19 * cosCache33 +
                        coeffs21 * cosCache19 * cosCache41 +
                        coeffs22 * cosCache19 * cosCache49 +
                        coeffs23 * cosCache19 * cosCache57 +
                        coeffs24 * cosCache27 * cosCache1 * Alpha +
                        coeffs25 * cosCache27 * cosCache9 +
                        coeffs26 * cosCache27 * cosCache17 +
                        coeffs27 * cosCache27 * cosCache25 +
                        coeffs28 * cosCache27 * cosCache33 +
                        coeffs29 * cosCache27 * cosCache41 +
                        coeffs30 * cosCache27 * cosCache49 +
                        coeffs31 * cosCache27 * cosCache57 +
                        coeffs32 * cosCache35 * cosCache1 * Alpha +
                        coeffs33 * cosCache35 * cosCache9 +
                        coeffs34 * cosCache35 * cosCache17 +
                        coeffs35 * cosCache35 * cosCache25 +
                        coeffs36 * cosCache35 * cosCache33 +
                        coeffs37 * cosCache35 * cosCache41 +
                        coeffs38 * cosCache35 * cosCache49 +
                        coeffs39 * cosCache35 * cosCache57 +
                        coeffs40 * cosCache43 * cosCache1 * Alpha +
                        coeffs41 * cosCache43 * cosCache9 +
                        coeffs42 * cosCache43 * cosCache17 +
                        coeffs43 * cosCache43 * cosCache25 +
                        coeffs44 * cosCache43 * cosCache33 +
                        coeffs45 * cosCache43 * cosCache41 +
                        coeffs46 * cosCache43 * cosCache49 +
                        coeffs47 * cosCache43 * cosCache57 +
                        coeffs48 * cosCache51 * cosCache1 * Alpha +
                        coeffs49 * cosCache51 * cosCache9 +
                        coeffs50 * cosCache51 * cosCache17 +
                        coeffs51 * cosCache51 * cosCache25 +
                        coeffs52 * cosCache51 * cosCache33 +
                        coeffs53 * cosCache51 * cosCache41 +
                        coeffs54 * cosCache51 * cosCache49 +
                        coeffs55 * cosCache51 * cosCache57 +
                        coeffs56 * cosCache59 * cosCache1 * Alpha +
                        coeffs57 * cosCache59 * cosCache9 +
                        coeffs58 * cosCache59 * cosCache17 +
                        coeffs59 * cosCache59 * cosCache25 +
                        coeffs60 * cosCache59 * cosCache33 +
                        coeffs61 * cosCache59 * cosCache41 +
                        coeffs62 * cosCache59 * cosCache49 +
                        coeffs63 * cosCache59 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 2] = (coeffs0 * cosCache3 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache10 * Alpha +
                        coeffs2 * cosCache3 * cosCache18 * Alpha +
                        coeffs3 * cosCache3 * cosCache26 * Alpha +
                        coeffs4 * cosCache3 * cosCache34 * Alpha +
                        coeffs5 * cosCache3 * cosCache42 * Alpha +
                        coeffs6 * cosCache3 * cosCache50 * Alpha +
                        coeffs7 * cosCache3 * cosCache58 * Alpha +
                        coeffs8 * cosCache11 * cosCache2 * Alpha +
                        coeffs9 * cosCache11 * cosCache10 +
                        coeffs10 * cosCache11 * cosCache18 +
                        coeffs11 * cosCache11 * cosCache26 +
                        coeffs12 * cosCache11 * cosCache34 +
                        coeffs13 * cosCache11 * cosCache42 +
                        coeffs14 * cosCache11 * cosCache50 +
                        coeffs15 * cosCache11 * cosCache58 +
                        coeffs16 * cosCache19 * cosCache2 * Alpha +
                        coeffs17 * cosCache19 * cosCache10 +
                        coeffs18 * cosCache19 * cosCache18 +
                        coeffs19 * cosCache19 * cosCache26 +
                        coeffs20 * cosCache19 * cosCache34 +
                        coeffs21 * cosCache19 * cosCache42 +
                        coeffs22 * cosCache19 * cosCache50 +
                        coeffs23 * cosCache19 * cosCache58 +
                        coeffs24 * cosCache27 * cosCache2 * Alpha +
                        coeffs25 * cosCache27 * cosCache10 +
                        coeffs26 * cosCache27 * cosCache18 +
                        coeffs27 * cosCache27 * cosCache26 +
                        coeffs28 * cosCache27 * cosCache34 +
                        coeffs29 * cosCache27 * cosCache42 +
                        coeffs30 * cosCache27 * cosCache50 +
                        coeffs31 * cosCache27 * cosCache58 +
                        coeffs32 * cosCache35 * cosCache2 * Alpha +
                        coeffs33 * cosCache35 * cosCache10 +
                        coeffs34 * cosCache35 * cosCache18 +
                        coeffs35 * cosCache35 * cosCache26 +
                        coeffs36 * cosCache35 * cosCache34 +
                        coeffs37 * cosCache35 * cosCache42 +
                        coeffs38 * cosCache35 * cosCache50 +
                        coeffs39 * cosCache35 * cosCache58 +
                        coeffs40 * cosCache43 * cosCache2 * Alpha +
                        coeffs41 * cosCache43 * cosCache10 +
                        coeffs42 * cosCache43 * cosCache18 +
                        coeffs43 * cosCache43 * cosCache26 +
                        coeffs44 * cosCache43 * cosCache34 +
                        coeffs45 * cosCache43 * cosCache42 +
                        coeffs46 * cosCache43 * cosCache50 +
                        coeffs47 * cosCache43 * cosCache58 +
                        coeffs48 * cosCache51 * cosCache2 * Alpha +
                        coeffs49 * cosCache51 * cosCache10 +
                        coeffs50 * cosCache51 * cosCache18 +
                        coeffs51 * cosCache51 * cosCache26 +
                        coeffs52 * cosCache51 * cosCache34 +
                        coeffs53 * cosCache51 * cosCache42 +
                        coeffs54 * cosCache51 * cosCache50 +
                        coeffs55 * cosCache51 * cosCache58 +
                        coeffs56 * cosCache59 * cosCache2 * Alpha +
                        coeffs57 * cosCache59 * cosCache10 +
                        coeffs58 * cosCache59 * cosCache18 +
                        coeffs59 * cosCache59 * cosCache26 +
                        coeffs60 * cosCache59 * cosCache34 +
                        coeffs61 * cosCache59 * cosCache42 +
                        coeffs62 * cosCache59 * cosCache50 +
                        coeffs63 * cosCache59 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 3] = (coeffs0 * cosCache3 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache11 * Alpha +
                        coeffs2 * cosCache3 * cosCache19 * Alpha +
                        coeffs3 * cosCache3 * cosCache27 * Alpha +
                        coeffs4 * cosCache3 * cosCache35 * Alpha +
                        coeffs5 * cosCache3 * cosCache43 * Alpha +
                        coeffs6 * cosCache3 * cosCache51 * Alpha +
                        coeffs7 * cosCache3 * cosCache59 * Alpha +
                        coeffs8 * cosCache11 * cosCache3 * Alpha +
                        coeffs9 * cosCache11 * cosCache11 +
                        coeffs10 * cosCache11 * cosCache19 +
                        coeffs11 * cosCache11 * cosCache27 +
                        coeffs12 * cosCache11 * cosCache35 +
                        coeffs13 * cosCache11 * cosCache43 +
                        coeffs14 * cosCache11 * cosCache51 +
                        coeffs15 * cosCache11 * cosCache59 +
                        coeffs16 * cosCache19 * cosCache3 * Alpha +
                        coeffs17 * cosCache19 * cosCache11 +
                        coeffs18 * cosCache19 * cosCache19 +
                        coeffs19 * cosCache19 * cosCache27 +
                        coeffs20 * cosCache19 * cosCache35 +
                        coeffs21 * cosCache19 * cosCache43 +
                        coeffs22 * cosCache19 * cosCache51 +
                        coeffs23 * cosCache19 * cosCache59 +
                        coeffs24 * cosCache27 * cosCache3 * Alpha +
                        coeffs25 * cosCache27 * cosCache11 +
                        coeffs26 * cosCache27 * cosCache19 +
                        coeffs27 * cosCache27 * cosCache27 +
                        coeffs28 * cosCache27 * cosCache35 +
                        coeffs29 * cosCache27 * cosCache43 +
                        coeffs30 * cosCache27 * cosCache51 +
                        coeffs31 * cosCache27 * cosCache59 +
                        coeffs32 * cosCache35 * cosCache3 * Alpha +
                        coeffs33 * cosCache35 * cosCache11 +
                        coeffs34 * cosCache35 * cosCache19 +
                        coeffs35 * cosCache35 * cosCache27 +
                        coeffs36 * cosCache35 * cosCache35 +
                        coeffs37 * cosCache35 * cosCache43 +
                        coeffs38 * cosCache35 * cosCache51 +
                        coeffs39 * cosCache35 * cosCache59 +
                        coeffs40 * cosCache43 * cosCache3 * Alpha +
                        coeffs41 * cosCache43 * cosCache11 +
                        coeffs42 * cosCache43 * cosCache19 +
                        coeffs43 * cosCache43 * cosCache27 +
                        coeffs44 * cosCache43 * cosCache35 +
                        coeffs45 * cosCache43 * cosCache43 +
                        coeffs46 * cosCache43 * cosCache51 +
                        coeffs47 * cosCache43 * cosCache59 +
                        coeffs48 * cosCache51 * cosCache3 * Alpha +
                        coeffs49 * cosCache51 * cosCache11 +
                        coeffs50 * cosCache51 * cosCache19 +
                        coeffs51 * cosCache51 * cosCache27 +
                        coeffs52 * cosCache51 * cosCache35 +
                        coeffs53 * cosCache51 * cosCache43 +
                        coeffs54 * cosCache51 * cosCache51 +
                        coeffs55 * cosCache51 * cosCache59 +
                        coeffs56 * cosCache59 * cosCache3 * Alpha +
                        coeffs57 * cosCache59 * cosCache11 +
                        coeffs58 * cosCache59 * cosCache19 +
                        coeffs59 * cosCache59 * cosCache27 +
                        coeffs60 * cosCache59 * cosCache35 +
                        coeffs61 * cosCache59 * cosCache43 +
                        coeffs62 * cosCache59 * cosCache51 +
                        coeffs63 * cosCache59 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 4] = (coeffs0 * cosCache3 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache12 * Alpha +
                        coeffs2 * cosCache3 * cosCache20 * Alpha +
                        coeffs3 * cosCache3 * cosCache28 * Alpha +
                        coeffs4 * cosCache3 * cosCache36 * Alpha +
                        coeffs5 * cosCache3 * cosCache44 * Alpha +
                        coeffs6 * cosCache3 * cosCache52 * Alpha +
                        coeffs7 * cosCache3 * cosCache60 * Alpha +
                        coeffs8 * cosCache11 * cosCache4 * Alpha +
                        coeffs9 * cosCache11 * cosCache12 +
                        coeffs10 * cosCache11 * cosCache20 +
                        coeffs11 * cosCache11 * cosCache28 +
                        coeffs12 * cosCache11 * cosCache36 +
                        coeffs13 * cosCache11 * cosCache44 +
                        coeffs14 * cosCache11 * cosCache52 +
                        coeffs15 * cosCache11 * cosCache60 +
                        coeffs16 * cosCache19 * cosCache4 * Alpha +
                        coeffs17 * cosCache19 * cosCache12 +
                        coeffs18 * cosCache19 * cosCache20 +
                        coeffs19 * cosCache19 * cosCache28 +
                        coeffs20 * cosCache19 * cosCache36 +
                        coeffs21 * cosCache19 * cosCache44 +
                        coeffs22 * cosCache19 * cosCache52 +
                        coeffs23 * cosCache19 * cosCache60 +
                        coeffs24 * cosCache27 * cosCache4 * Alpha +
                        coeffs25 * cosCache27 * cosCache12 +
                        coeffs26 * cosCache27 * cosCache20 +
                        coeffs27 * cosCache27 * cosCache28 +
                        coeffs28 * cosCache27 * cosCache36 +
                        coeffs29 * cosCache27 * cosCache44 +
                        coeffs30 * cosCache27 * cosCache52 +
                        coeffs31 * cosCache27 * cosCache60 +
                        coeffs32 * cosCache35 * cosCache4 * Alpha +
                        coeffs33 * cosCache35 * cosCache12 +
                        coeffs34 * cosCache35 * cosCache20 +
                        coeffs35 * cosCache35 * cosCache28 +
                        coeffs36 * cosCache35 * cosCache36 +
                        coeffs37 * cosCache35 * cosCache44 +
                        coeffs38 * cosCache35 * cosCache52 +
                        coeffs39 * cosCache35 * cosCache60 +
                        coeffs40 * cosCache43 * cosCache4 * Alpha +
                        coeffs41 * cosCache43 * cosCache12 +
                        coeffs42 * cosCache43 * cosCache20 +
                        coeffs43 * cosCache43 * cosCache28 +
                        coeffs44 * cosCache43 * cosCache36 +
                        coeffs45 * cosCache43 * cosCache44 +
                        coeffs46 * cosCache43 * cosCache52 +
                        coeffs47 * cosCache43 * cosCache60 +
                        coeffs48 * cosCache51 * cosCache4 * Alpha +
                        coeffs49 * cosCache51 * cosCache12 +
                        coeffs50 * cosCache51 * cosCache20 +
                        coeffs51 * cosCache51 * cosCache28 +
                        coeffs52 * cosCache51 * cosCache36 +
                        coeffs53 * cosCache51 * cosCache44 +
                        coeffs54 * cosCache51 * cosCache52 +
                        coeffs55 * cosCache51 * cosCache60 +
                        coeffs56 * cosCache59 * cosCache4 * Alpha +
                        coeffs57 * cosCache59 * cosCache12 +
                        coeffs58 * cosCache59 * cosCache20 +
                        coeffs59 * cosCache59 * cosCache28 +
                        coeffs60 * cosCache59 * cosCache36 +
                        coeffs61 * cosCache59 * cosCache44 +
                        coeffs62 * cosCache59 * cosCache52 +
                        coeffs63 * cosCache59 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 5] = (coeffs0 * cosCache3 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache13 * Alpha +
                        coeffs2 * cosCache3 * cosCache21 * Alpha +
                        coeffs3 * cosCache3 * cosCache29 * Alpha +
                        coeffs4 * cosCache3 * cosCache37 * Alpha +
                        coeffs5 * cosCache3 * cosCache45 * Alpha +
                        coeffs6 * cosCache3 * cosCache53 * Alpha +
                        coeffs7 * cosCache3 * cosCache61 * Alpha +
                        coeffs8 * cosCache11 * cosCache5 * Alpha +
                        coeffs9 * cosCache11 * cosCache13 +
                        coeffs10 * cosCache11 * cosCache21 +
                        coeffs11 * cosCache11 * cosCache29 +
                        coeffs12 * cosCache11 * cosCache37 +
                        coeffs13 * cosCache11 * cosCache45 +
                        coeffs14 * cosCache11 * cosCache53 +
                        coeffs15 * cosCache11 * cosCache61 +
                        coeffs16 * cosCache19 * cosCache5 * Alpha +
                        coeffs17 * cosCache19 * cosCache13 +
                        coeffs18 * cosCache19 * cosCache21 +
                        coeffs19 * cosCache19 * cosCache29 +
                        coeffs20 * cosCache19 * cosCache37 +
                        coeffs21 * cosCache19 * cosCache45 +
                        coeffs22 * cosCache19 * cosCache53 +
                        coeffs23 * cosCache19 * cosCache61 +
                        coeffs24 * cosCache27 * cosCache5 * Alpha +
                        coeffs25 * cosCache27 * cosCache13 +
                        coeffs26 * cosCache27 * cosCache21 +
                        coeffs27 * cosCache27 * cosCache29 +
                        coeffs28 * cosCache27 * cosCache37 +
                        coeffs29 * cosCache27 * cosCache45 +
                        coeffs30 * cosCache27 * cosCache53 +
                        coeffs31 * cosCache27 * cosCache61 +
                        coeffs32 * cosCache35 * cosCache5 * Alpha +
                        coeffs33 * cosCache35 * cosCache13 +
                        coeffs34 * cosCache35 * cosCache21 +
                        coeffs35 * cosCache35 * cosCache29 +
                        coeffs36 * cosCache35 * cosCache37 +
                        coeffs37 * cosCache35 * cosCache45 +
                        coeffs38 * cosCache35 * cosCache53 +
                        coeffs39 * cosCache35 * cosCache61 +
                        coeffs40 * cosCache43 * cosCache5 * Alpha +
                        coeffs41 * cosCache43 * cosCache13 +
                        coeffs42 * cosCache43 * cosCache21 +
                        coeffs43 * cosCache43 * cosCache29 +
                        coeffs44 * cosCache43 * cosCache37 +
                        coeffs45 * cosCache43 * cosCache45 +
                        coeffs46 * cosCache43 * cosCache53 +
                        coeffs47 * cosCache43 * cosCache61 +
                        coeffs48 * cosCache51 * cosCache5 * Alpha +
                        coeffs49 * cosCache51 * cosCache13 +
                        coeffs50 * cosCache51 * cosCache21 +
                        coeffs51 * cosCache51 * cosCache29 +
                        coeffs52 * cosCache51 * cosCache37 +
                        coeffs53 * cosCache51 * cosCache45 +
                        coeffs54 * cosCache51 * cosCache53 +
                        coeffs55 * cosCache51 * cosCache61 +
                        coeffs56 * cosCache59 * cosCache5 * Alpha +
                        coeffs57 * cosCache59 * cosCache13 +
                        coeffs58 * cosCache59 * cosCache21 +
                        coeffs59 * cosCache59 * cosCache29 +
                        coeffs60 * cosCache59 * cosCache37 +
                        coeffs61 * cosCache59 * cosCache45 +
                        coeffs62 * cosCache59 * cosCache53 +
                        coeffs63 * cosCache59 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 6] = (coeffs0 * cosCache3 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache14 * Alpha +
                        coeffs2 * cosCache3 * cosCache22 * Alpha +
                        coeffs3 * cosCache3 * cosCache30 * Alpha +
                        coeffs4 * cosCache3 * cosCache38 * Alpha +
                        coeffs5 * cosCache3 * cosCache46 * Alpha +
                        coeffs6 * cosCache3 * cosCache54 * Alpha +
                        coeffs7 * cosCache3 * cosCache62 * Alpha +
                        coeffs8 * cosCache11 * cosCache6 * Alpha +
                        coeffs9 * cosCache11 * cosCache14 +
                        coeffs10 * cosCache11 * cosCache22 +
                        coeffs11 * cosCache11 * cosCache30 +
                        coeffs12 * cosCache11 * cosCache38 +
                        coeffs13 * cosCache11 * cosCache46 +
                        coeffs14 * cosCache11 * cosCache54 +
                        coeffs15 * cosCache11 * cosCache62 +
                        coeffs16 * cosCache19 * cosCache6 * Alpha +
                        coeffs17 * cosCache19 * cosCache14 +
                        coeffs18 * cosCache19 * cosCache22 +
                        coeffs19 * cosCache19 * cosCache30 +
                        coeffs20 * cosCache19 * cosCache38 +
                        coeffs21 * cosCache19 * cosCache46 +
                        coeffs22 * cosCache19 * cosCache54 +
                        coeffs23 * cosCache19 * cosCache62 +
                        coeffs24 * cosCache27 * cosCache6 * Alpha +
                        coeffs25 * cosCache27 * cosCache14 +
                        coeffs26 * cosCache27 * cosCache22 +
                        coeffs27 * cosCache27 * cosCache30 +
                        coeffs28 * cosCache27 * cosCache38 +
                        coeffs29 * cosCache27 * cosCache46 +
                        coeffs30 * cosCache27 * cosCache54 +
                        coeffs31 * cosCache27 * cosCache62 +
                        coeffs32 * cosCache35 * cosCache6 * Alpha +
                        coeffs33 * cosCache35 * cosCache14 +
                        coeffs34 * cosCache35 * cosCache22 +
                        coeffs35 * cosCache35 * cosCache30 +
                        coeffs36 * cosCache35 * cosCache38 +
                        coeffs37 * cosCache35 * cosCache46 +
                        coeffs38 * cosCache35 * cosCache54 +
                        coeffs39 * cosCache35 * cosCache62 +
                        coeffs40 * cosCache43 * cosCache6 * Alpha +
                        coeffs41 * cosCache43 * cosCache14 +
                        coeffs42 * cosCache43 * cosCache22 +
                        coeffs43 * cosCache43 * cosCache30 +
                        coeffs44 * cosCache43 * cosCache38 +
                        coeffs45 * cosCache43 * cosCache46 +
                        coeffs46 * cosCache43 * cosCache54 +
                        coeffs47 * cosCache43 * cosCache62 +
                        coeffs48 * cosCache51 * cosCache6 * Alpha +
                        coeffs49 * cosCache51 * cosCache14 +
                        coeffs50 * cosCache51 * cosCache22 +
                        coeffs51 * cosCache51 * cosCache30 +
                        coeffs52 * cosCache51 * cosCache38 +
                        coeffs53 * cosCache51 * cosCache46 +
                        coeffs54 * cosCache51 * cosCache54 +
                        coeffs55 * cosCache51 * cosCache62 +
                        coeffs56 * cosCache59 * cosCache6 * Alpha +
                        coeffs57 * cosCache59 * cosCache14 +
                        coeffs58 * cosCache59 * cosCache22 +
                        coeffs59 * cosCache59 * cosCache30 +
                        coeffs60 * cosCache59 * cosCache38 +
                        coeffs61 * cosCache59 * cosCache46 +
                        coeffs62 * cosCache59 * cosCache54 +
                        coeffs63 * cosCache59 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[3, 7] = (coeffs0 * cosCache3 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache3 * cosCache15 * Alpha +
                        coeffs2 * cosCache3 * cosCache23 * Alpha +
                        coeffs3 * cosCache3 * cosCache31 * Alpha +
                        coeffs4 * cosCache3 * cosCache39 * Alpha +
                        coeffs5 * cosCache3 * cosCache47 * Alpha +
                        coeffs6 * cosCache3 * cosCache55 * Alpha +
                        coeffs7 * cosCache3 * cosCache63 * Alpha +
                        coeffs8 * cosCache11 * cosCache7 * Alpha +
                        coeffs9 * cosCache11 * cosCache15 +
                        coeffs10 * cosCache11 * cosCache23 +
                        coeffs11 * cosCache11 * cosCache31 +
                        coeffs12 * cosCache11 * cosCache39 +
                        coeffs13 * cosCache11 * cosCache47 +
                        coeffs14 * cosCache11 * cosCache55 +
                        coeffs15 * cosCache11 * cosCache63 +
                        coeffs16 * cosCache19 * cosCache7 * Alpha +
                        coeffs17 * cosCache19 * cosCache15 +
                        coeffs18 * cosCache19 * cosCache23 +
                        coeffs19 * cosCache19 * cosCache31 +
                        coeffs20 * cosCache19 * cosCache39 +
                        coeffs21 * cosCache19 * cosCache47 +
                        coeffs22 * cosCache19 * cosCache55 +
                        coeffs23 * cosCache19 * cosCache63 +
                        coeffs24 * cosCache27 * cosCache7 * Alpha +
                        coeffs25 * cosCache27 * cosCache15 +
                        coeffs26 * cosCache27 * cosCache23 +
                        coeffs27 * cosCache27 * cosCache31 +
                        coeffs28 * cosCache27 * cosCache39 +
                        coeffs29 * cosCache27 * cosCache47 +
                        coeffs30 * cosCache27 * cosCache55 +
                        coeffs31 * cosCache27 * cosCache63 +
                        coeffs32 * cosCache35 * cosCache7 * Alpha +
                        coeffs33 * cosCache35 * cosCache15 +
                        coeffs34 * cosCache35 * cosCache23 +
                        coeffs35 * cosCache35 * cosCache31 +
                        coeffs36 * cosCache35 * cosCache39 +
                        coeffs37 * cosCache35 * cosCache47 +
                        coeffs38 * cosCache35 * cosCache55 +
                        coeffs39 * cosCache35 * cosCache63 +
                        coeffs40 * cosCache43 * cosCache7 * Alpha +
                        coeffs41 * cosCache43 * cosCache15 +
                        coeffs42 * cosCache43 * cosCache23 +
                        coeffs43 * cosCache43 * cosCache31 +
                        coeffs44 * cosCache43 * cosCache39 +
                        coeffs45 * cosCache43 * cosCache47 +
                        coeffs46 * cosCache43 * cosCache55 +
                        coeffs47 * cosCache43 * cosCache63 +
                        coeffs48 * cosCache51 * cosCache7 * Alpha +
                        coeffs49 * cosCache51 * cosCache15 +
                        coeffs50 * cosCache51 * cosCache23 +
                        coeffs51 * cosCache51 * cosCache31 +
                        coeffs52 * cosCache51 * cosCache39 +
                        coeffs53 * cosCache51 * cosCache47 +
                        coeffs54 * cosCache51 * cosCache55 +
                        coeffs55 * cosCache51 * cosCache63 +
                        coeffs56 * cosCache59 * cosCache7 * Alpha +
                        coeffs57 * cosCache59 * cosCache15 +
                        coeffs58 * cosCache59 * cosCache23 +
                        coeffs59 * cosCache59 * cosCache31 +
                        coeffs60 * cosCache59 * cosCache39 +
                        coeffs61 * cosCache59 * cosCache47 +
                        coeffs62 * cosCache59 * cosCache55 +
                        coeffs63 * cosCache59 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 0] = (coeffs0 * cosCache4 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache8 * Alpha +
                        coeffs2 * cosCache4 * cosCache16 * Alpha +
                        coeffs3 * cosCache4 * cosCache24 * Alpha +
                        coeffs4 * cosCache4 * cosCache32 * Alpha +
                        coeffs5 * cosCache4 * cosCache40 * Alpha +
                        coeffs6 * cosCache4 * cosCache48 * Alpha +
                        coeffs7 * cosCache4 * cosCache56 * Alpha +
                        coeffs8 * cosCache12 * cosCache0 * Alpha +
                        coeffs9 * cosCache12 * cosCache8 +
                        coeffs10 * cosCache12 * cosCache16 +
                        coeffs11 * cosCache12 * cosCache24 +
                        coeffs12 * cosCache12 * cosCache32 +
                        coeffs13 * cosCache12 * cosCache40 +
                        coeffs14 * cosCache12 * cosCache48 +
                        coeffs15 * cosCache12 * cosCache56 +
                        coeffs16 * cosCache20 * cosCache0 * Alpha +
                        coeffs17 * cosCache20 * cosCache8 +
                        coeffs18 * cosCache20 * cosCache16 +
                        coeffs19 * cosCache20 * cosCache24 +
                        coeffs20 * cosCache20 * cosCache32 +
                        coeffs21 * cosCache20 * cosCache40 +
                        coeffs22 * cosCache20 * cosCache48 +
                        coeffs23 * cosCache20 * cosCache56 +
                        coeffs24 * cosCache28 * cosCache0 * Alpha +
                        coeffs25 * cosCache28 * cosCache8 +
                        coeffs26 * cosCache28 * cosCache16 +
                        coeffs27 * cosCache28 * cosCache24 +
                        coeffs28 * cosCache28 * cosCache32 +
                        coeffs29 * cosCache28 * cosCache40 +
                        coeffs30 * cosCache28 * cosCache48 +
                        coeffs31 * cosCache28 * cosCache56 +
                        coeffs32 * cosCache36 * cosCache0 * Alpha +
                        coeffs33 * cosCache36 * cosCache8 +
                        coeffs34 * cosCache36 * cosCache16 +
                        coeffs35 * cosCache36 * cosCache24 +
                        coeffs36 * cosCache36 * cosCache32 +
                        coeffs37 * cosCache36 * cosCache40 +
                        coeffs38 * cosCache36 * cosCache48 +
                        coeffs39 * cosCache36 * cosCache56 +
                        coeffs40 * cosCache44 * cosCache0 * Alpha +
                        coeffs41 * cosCache44 * cosCache8 +
                        coeffs42 * cosCache44 * cosCache16 +
                        coeffs43 * cosCache44 * cosCache24 +
                        coeffs44 * cosCache44 * cosCache32 +
                        coeffs45 * cosCache44 * cosCache40 +
                        coeffs46 * cosCache44 * cosCache48 +
                        coeffs47 * cosCache44 * cosCache56 +
                        coeffs48 * cosCache52 * cosCache0 * Alpha +
                        coeffs49 * cosCache52 * cosCache8 +
                        coeffs50 * cosCache52 * cosCache16 +
                        coeffs51 * cosCache52 * cosCache24 +
                        coeffs52 * cosCache52 * cosCache32 +
                        coeffs53 * cosCache52 * cosCache40 +
                        coeffs54 * cosCache52 * cosCache48 +
                        coeffs55 * cosCache52 * cosCache56 +
                        coeffs56 * cosCache60 * cosCache0 * Alpha +
                        coeffs57 * cosCache60 * cosCache8 +
                        coeffs58 * cosCache60 * cosCache16 +
                        coeffs59 * cosCache60 * cosCache24 +
                        coeffs60 * cosCache60 * cosCache32 +
                        coeffs61 * cosCache60 * cosCache40 +
                        coeffs62 * cosCache60 * cosCache48 +
                        coeffs63 * cosCache60 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 1] = (coeffs0 * cosCache4 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache9 * Alpha +
                        coeffs2 * cosCache4 * cosCache17 * Alpha +
                        coeffs3 * cosCache4 * cosCache25 * Alpha +
                        coeffs4 * cosCache4 * cosCache33 * Alpha +
                        coeffs5 * cosCache4 * cosCache41 * Alpha +
                        coeffs6 * cosCache4 * cosCache49 * Alpha +
                        coeffs7 * cosCache4 * cosCache57 * Alpha +
                        coeffs8 * cosCache12 * cosCache1 * Alpha +
                        coeffs9 * cosCache12 * cosCache9 +
                        coeffs10 * cosCache12 * cosCache17 +
                        coeffs11 * cosCache12 * cosCache25 +
                        coeffs12 * cosCache12 * cosCache33 +
                        coeffs13 * cosCache12 * cosCache41 +
                        coeffs14 * cosCache12 * cosCache49 +
                        coeffs15 * cosCache12 * cosCache57 +
                        coeffs16 * cosCache20 * cosCache1 * Alpha +
                        coeffs17 * cosCache20 * cosCache9 +
                        coeffs18 * cosCache20 * cosCache17 +
                        coeffs19 * cosCache20 * cosCache25 +
                        coeffs20 * cosCache20 * cosCache33 +
                        coeffs21 * cosCache20 * cosCache41 +
                        coeffs22 * cosCache20 * cosCache49 +
                        coeffs23 * cosCache20 * cosCache57 +
                        coeffs24 * cosCache28 * cosCache1 * Alpha +
                        coeffs25 * cosCache28 * cosCache9 +
                        coeffs26 * cosCache28 * cosCache17 +
                        coeffs27 * cosCache28 * cosCache25 +
                        coeffs28 * cosCache28 * cosCache33 +
                        coeffs29 * cosCache28 * cosCache41 +
                        coeffs30 * cosCache28 * cosCache49 +
                        coeffs31 * cosCache28 * cosCache57 +
                        coeffs32 * cosCache36 * cosCache1 * Alpha +
                        coeffs33 * cosCache36 * cosCache9 +
                        coeffs34 * cosCache36 * cosCache17 +
                        coeffs35 * cosCache36 * cosCache25 +
                        coeffs36 * cosCache36 * cosCache33 +
                        coeffs37 * cosCache36 * cosCache41 +
                        coeffs38 * cosCache36 * cosCache49 +
                        coeffs39 * cosCache36 * cosCache57 +
                        coeffs40 * cosCache44 * cosCache1 * Alpha +
                        coeffs41 * cosCache44 * cosCache9 +
                        coeffs42 * cosCache44 * cosCache17 +
                        coeffs43 * cosCache44 * cosCache25 +
                        coeffs44 * cosCache44 * cosCache33 +
                        coeffs45 * cosCache44 * cosCache41 +
                        coeffs46 * cosCache44 * cosCache49 +
                        coeffs47 * cosCache44 * cosCache57 +
                        coeffs48 * cosCache52 * cosCache1 * Alpha +
                        coeffs49 * cosCache52 * cosCache9 +
                        coeffs50 * cosCache52 * cosCache17 +
                        coeffs51 * cosCache52 * cosCache25 +
                        coeffs52 * cosCache52 * cosCache33 +
                        coeffs53 * cosCache52 * cosCache41 +
                        coeffs54 * cosCache52 * cosCache49 +
                        coeffs55 * cosCache52 * cosCache57 +
                        coeffs56 * cosCache60 * cosCache1 * Alpha +
                        coeffs57 * cosCache60 * cosCache9 +
                        coeffs58 * cosCache60 * cosCache17 +
                        coeffs59 * cosCache60 * cosCache25 +
                        coeffs60 * cosCache60 * cosCache33 +
                        coeffs61 * cosCache60 * cosCache41 +
                        coeffs62 * cosCache60 * cosCache49 +
                        coeffs63 * cosCache60 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 2] = (coeffs0 * cosCache4 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache10 * Alpha +
                        coeffs2 * cosCache4 * cosCache18 * Alpha +
                        coeffs3 * cosCache4 * cosCache26 * Alpha +
                        coeffs4 * cosCache4 * cosCache34 * Alpha +
                        coeffs5 * cosCache4 * cosCache42 * Alpha +
                        coeffs6 * cosCache4 * cosCache50 * Alpha +
                        coeffs7 * cosCache4 * cosCache58 * Alpha +
                        coeffs8 * cosCache12 * cosCache2 * Alpha +
                        coeffs9 * cosCache12 * cosCache10 +
                        coeffs10 * cosCache12 * cosCache18 +
                        coeffs11 * cosCache12 * cosCache26 +
                        coeffs12 * cosCache12 * cosCache34 +
                        coeffs13 * cosCache12 * cosCache42 +
                        coeffs14 * cosCache12 * cosCache50 +
                        coeffs15 * cosCache12 * cosCache58 +
                        coeffs16 * cosCache20 * cosCache2 * Alpha +
                        coeffs17 * cosCache20 * cosCache10 +
                        coeffs18 * cosCache20 * cosCache18 +
                        coeffs19 * cosCache20 * cosCache26 +
                        coeffs20 * cosCache20 * cosCache34 +
                        coeffs21 * cosCache20 * cosCache42 +
                        coeffs22 * cosCache20 * cosCache50 +
                        coeffs23 * cosCache20 * cosCache58 +
                        coeffs24 * cosCache28 * cosCache2 * Alpha +
                        coeffs25 * cosCache28 * cosCache10 +
                        coeffs26 * cosCache28 * cosCache18 +
                        coeffs27 * cosCache28 * cosCache26 +
                        coeffs28 * cosCache28 * cosCache34 +
                        coeffs29 * cosCache28 * cosCache42 +
                        coeffs30 * cosCache28 * cosCache50 +
                        coeffs31 * cosCache28 * cosCache58 +
                        coeffs32 * cosCache36 * cosCache2 * Alpha +
                        coeffs33 * cosCache36 * cosCache10 +
                        coeffs34 * cosCache36 * cosCache18 +
                        coeffs35 * cosCache36 * cosCache26 +
                        coeffs36 * cosCache36 * cosCache34 +
                        coeffs37 * cosCache36 * cosCache42 +
                        coeffs38 * cosCache36 * cosCache50 +
                        coeffs39 * cosCache36 * cosCache58 +
                        coeffs40 * cosCache44 * cosCache2 * Alpha +
                        coeffs41 * cosCache44 * cosCache10 +
                        coeffs42 * cosCache44 * cosCache18 +
                        coeffs43 * cosCache44 * cosCache26 +
                        coeffs44 * cosCache44 * cosCache34 +
                        coeffs45 * cosCache44 * cosCache42 +
                        coeffs46 * cosCache44 * cosCache50 +
                        coeffs47 * cosCache44 * cosCache58 +
                        coeffs48 * cosCache52 * cosCache2 * Alpha +
                        coeffs49 * cosCache52 * cosCache10 +
                        coeffs50 * cosCache52 * cosCache18 +
                        coeffs51 * cosCache52 * cosCache26 +
                        coeffs52 * cosCache52 * cosCache34 +
                        coeffs53 * cosCache52 * cosCache42 +
                        coeffs54 * cosCache52 * cosCache50 +
                        coeffs55 * cosCache52 * cosCache58 +
                        coeffs56 * cosCache60 * cosCache2 * Alpha +
                        coeffs57 * cosCache60 * cosCache10 +
                        coeffs58 * cosCache60 * cosCache18 +
                        coeffs59 * cosCache60 * cosCache26 +
                        coeffs60 * cosCache60 * cosCache34 +
                        coeffs61 * cosCache60 * cosCache42 +
                        coeffs62 * cosCache60 * cosCache50 +
                        coeffs63 * cosCache60 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 3] = (coeffs0 * cosCache4 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache11 * Alpha +
                        coeffs2 * cosCache4 * cosCache19 * Alpha +
                        coeffs3 * cosCache4 * cosCache27 * Alpha +
                        coeffs4 * cosCache4 * cosCache35 * Alpha +
                        coeffs5 * cosCache4 * cosCache43 * Alpha +
                        coeffs6 * cosCache4 * cosCache51 * Alpha +
                        coeffs7 * cosCache4 * cosCache59 * Alpha +
                        coeffs8 * cosCache12 * cosCache3 * Alpha +
                        coeffs9 * cosCache12 * cosCache11 +
                        coeffs10 * cosCache12 * cosCache19 +
                        coeffs11 * cosCache12 * cosCache27 +
                        coeffs12 * cosCache12 * cosCache35 +
                        coeffs13 * cosCache12 * cosCache43 +
                        coeffs14 * cosCache12 * cosCache51 +
                        coeffs15 * cosCache12 * cosCache59 +
                        coeffs16 * cosCache20 * cosCache3 * Alpha +
                        coeffs17 * cosCache20 * cosCache11 +
                        coeffs18 * cosCache20 * cosCache19 +
                        coeffs19 * cosCache20 * cosCache27 +
                        coeffs20 * cosCache20 * cosCache35 +
                        coeffs21 * cosCache20 * cosCache43 +
                        coeffs22 * cosCache20 * cosCache51 +
                        coeffs23 * cosCache20 * cosCache59 +
                        coeffs24 * cosCache28 * cosCache3 * Alpha +
                        coeffs25 * cosCache28 * cosCache11 +
                        coeffs26 * cosCache28 * cosCache19 +
                        coeffs27 * cosCache28 * cosCache27 +
                        coeffs28 * cosCache28 * cosCache35 +
                        coeffs29 * cosCache28 * cosCache43 +
                        coeffs30 * cosCache28 * cosCache51 +
                        coeffs31 * cosCache28 * cosCache59 +
                        coeffs32 * cosCache36 * cosCache3 * Alpha +
                        coeffs33 * cosCache36 * cosCache11 +
                        coeffs34 * cosCache36 * cosCache19 +
                        coeffs35 * cosCache36 * cosCache27 +
                        coeffs36 * cosCache36 * cosCache35 +
                        coeffs37 * cosCache36 * cosCache43 +
                        coeffs38 * cosCache36 * cosCache51 +
                        coeffs39 * cosCache36 * cosCache59 +
                        coeffs40 * cosCache44 * cosCache3 * Alpha +
                        coeffs41 * cosCache44 * cosCache11 +
                        coeffs42 * cosCache44 * cosCache19 +
                        coeffs43 * cosCache44 * cosCache27 +
                        coeffs44 * cosCache44 * cosCache35 +
                        coeffs45 * cosCache44 * cosCache43 +
                        coeffs46 * cosCache44 * cosCache51 +
                        coeffs47 * cosCache44 * cosCache59 +
                        coeffs48 * cosCache52 * cosCache3 * Alpha +
                        coeffs49 * cosCache52 * cosCache11 +
                        coeffs50 * cosCache52 * cosCache19 +
                        coeffs51 * cosCache52 * cosCache27 +
                        coeffs52 * cosCache52 * cosCache35 +
                        coeffs53 * cosCache52 * cosCache43 +
                        coeffs54 * cosCache52 * cosCache51 +
                        coeffs55 * cosCache52 * cosCache59 +
                        coeffs56 * cosCache60 * cosCache3 * Alpha +
                        coeffs57 * cosCache60 * cosCache11 +
                        coeffs58 * cosCache60 * cosCache19 +
                        coeffs59 * cosCache60 * cosCache27 +
                        coeffs60 * cosCache60 * cosCache35 +
                        coeffs61 * cosCache60 * cosCache43 +
                        coeffs62 * cosCache60 * cosCache51 +
                        coeffs63 * cosCache60 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 4] = (coeffs0 * cosCache4 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache12 * Alpha +
                        coeffs2 * cosCache4 * cosCache20 * Alpha +
                        coeffs3 * cosCache4 * cosCache28 * Alpha +
                        coeffs4 * cosCache4 * cosCache36 * Alpha +
                        coeffs5 * cosCache4 * cosCache44 * Alpha +
                        coeffs6 * cosCache4 * cosCache52 * Alpha +
                        coeffs7 * cosCache4 * cosCache60 * Alpha +
                        coeffs8 * cosCache12 * cosCache4 * Alpha +
                        coeffs9 * cosCache12 * cosCache12 +
                        coeffs10 * cosCache12 * cosCache20 +
                        coeffs11 * cosCache12 * cosCache28 +
                        coeffs12 * cosCache12 * cosCache36 +
                        coeffs13 * cosCache12 * cosCache44 +
                        coeffs14 * cosCache12 * cosCache52 +
                        coeffs15 * cosCache12 * cosCache60 +
                        coeffs16 * cosCache20 * cosCache4 * Alpha +
                        coeffs17 * cosCache20 * cosCache12 +
                        coeffs18 * cosCache20 * cosCache20 +
                        coeffs19 * cosCache20 * cosCache28 +
                        coeffs20 * cosCache20 * cosCache36 +
                        coeffs21 * cosCache20 * cosCache44 +
                        coeffs22 * cosCache20 * cosCache52 +
                        coeffs23 * cosCache20 * cosCache60 +
                        coeffs24 * cosCache28 * cosCache4 * Alpha +
                        coeffs25 * cosCache28 * cosCache12 +
                        coeffs26 * cosCache28 * cosCache20 +
                        coeffs27 * cosCache28 * cosCache28 +
                        coeffs28 * cosCache28 * cosCache36 +
                        coeffs29 * cosCache28 * cosCache44 +
                        coeffs30 * cosCache28 * cosCache52 +
                        coeffs31 * cosCache28 * cosCache60 +
                        coeffs32 * cosCache36 * cosCache4 * Alpha +
                        coeffs33 * cosCache36 * cosCache12 +
                        coeffs34 * cosCache36 * cosCache20 +
                        coeffs35 * cosCache36 * cosCache28 +
                        coeffs36 * cosCache36 * cosCache36 +
                        coeffs37 * cosCache36 * cosCache44 +
                        coeffs38 * cosCache36 * cosCache52 +
                        coeffs39 * cosCache36 * cosCache60 +
                        coeffs40 * cosCache44 * cosCache4 * Alpha +
                        coeffs41 * cosCache44 * cosCache12 +
                        coeffs42 * cosCache44 * cosCache20 +
                        coeffs43 * cosCache44 * cosCache28 +
                        coeffs44 * cosCache44 * cosCache36 +
                        coeffs45 * cosCache44 * cosCache44 +
                        coeffs46 * cosCache44 * cosCache52 +
                        coeffs47 * cosCache44 * cosCache60 +
                        coeffs48 * cosCache52 * cosCache4 * Alpha +
                        coeffs49 * cosCache52 * cosCache12 +
                        coeffs50 * cosCache52 * cosCache20 +
                        coeffs51 * cosCache52 * cosCache28 +
                        coeffs52 * cosCache52 * cosCache36 +
                        coeffs53 * cosCache52 * cosCache44 +
                        coeffs54 * cosCache52 * cosCache52 +
                        coeffs55 * cosCache52 * cosCache60 +
                        coeffs56 * cosCache60 * cosCache4 * Alpha +
                        coeffs57 * cosCache60 * cosCache12 +
                        coeffs58 * cosCache60 * cosCache20 +
                        coeffs59 * cosCache60 * cosCache28 +
                        coeffs60 * cosCache60 * cosCache36 +
                        coeffs61 * cosCache60 * cosCache44 +
                        coeffs62 * cosCache60 * cosCache52 +
                        coeffs63 * cosCache60 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 5] = (coeffs0 * cosCache4 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache13 * Alpha +
                        coeffs2 * cosCache4 * cosCache21 * Alpha +
                        coeffs3 * cosCache4 * cosCache29 * Alpha +
                        coeffs4 * cosCache4 * cosCache37 * Alpha +
                        coeffs5 * cosCache4 * cosCache45 * Alpha +
                        coeffs6 * cosCache4 * cosCache53 * Alpha +
                        coeffs7 * cosCache4 * cosCache61 * Alpha +
                        coeffs8 * cosCache12 * cosCache5 * Alpha +
                        coeffs9 * cosCache12 * cosCache13 +
                        coeffs10 * cosCache12 * cosCache21 +
                        coeffs11 * cosCache12 * cosCache29 +
                        coeffs12 * cosCache12 * cosCache37 +
                        coeffs13 * cosCache12 * cosCache45 +
                        coeffs14 * cosCache12 * cosCache53 +
                        coeffs15 * cosCache12 * cosCache61 +
                        coeffs16 * cosCache20 * cosCache5 * Alpha +
                        coeffs17 * cosCache20 * cosCache13 +
                        coeffs18 * cosCache20 * cosCache21 +
                        coeffs19 * cosCache20 * cosCache29 +
                        coeffs20 * cosCache20 * cosCache37 +
                        coeffs21 * cosCache20 * cosCache45 +
                        coeffs22 * cosCache20 * cosCache53 +
                        coeffs23 * cosCache20 * cosCache61 +
                        coeffs24 * cosCache28 * cosCache5 * Alpha +
                        coeffs25 * cosCache28 * cosCache13 +
                        coeffs26 * cosCache28 * cosCache21 +
                        coeffs27 * cosCache28 * cosCache29 +
                        coeffs28 * cosCache28 * cosCache37 +
                        coeffs29 * cosCache28 * cosCache45 +
                        coeffs30 * cosCache28 * cosCache53 +
                        coeffs31 * cosCache28 * cosCache61 +
                        coeffs32 * cosCache36 * cosCache5 * Alpha +
                        coeffs33 * cosCache36 * cosCache13 +
                        coeffs34 * cosCache36 * cosCache21 +
                        coeffs35 * cosCache36 * cosCache29 +
                        coeffs36 * cosCache36 * cosCache37 +
                        coeffs37 * cosCache36 * cosCache45 +
                        coeffs38 * cosCache36 * cosCache53 +
                        coeffs39 * cosCache36 * cosCache61 +
                        coeffs40 * cosCache44 * cosCache5 * Alpha +
                        coeffs41 * cosCache44 * cosCache13 +
                        coeffs42 * cosCache44 * cosCache21 +
                        coeffs43 * cosCache44 * cosCache29 +
                        coeffs44 * cosCache44 * cosCache37 +
                        coeffs45 * cosCache44 * cosCache45 +
                        coeffs46 * cosCache44 * cosCache53 +
                        coeffs47 * cosCache44 * cosCache61 +
                        coeffs48 * cosCache52 * cosCache5 * Alpha +
                        coeffs49 * cosCache52 * cosCache13 +
                        coeffs50 * cosCache52 * cosCache21 +
                        coeffs51 * cosCache52 * cosCache29 +
                        coeffs52 * cosCache52 * cosCache37 +
                        coeffs53 * cosCache52 * cosCache45 +
                        coeffs54 * cosCache52 * cosCache53 +
                        coeffs55 * cosCache52 * cosCache61 +
                        coeffs56 * cosCache60 * cosCache5 * Alpha +
                        coeffs57 * cosCache60 * cosCache13 +
                        coeffs58 * cosCache60 * cosCache21 +
                        coeffs59 * cosCache60 * cosCache29 +
                        coeffs60 * cosCache60 * cosCache37 +
                        coeffs61 * cosCache60 * cosCache45 +
                        coeffs62 * cosCache60 * cosCache53 +
                        coeffs63 * cosCache60 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 6] = (coeffs0 * cosCache4 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache14 * Alpha +
                        coeffs2 * cosCache4 * cosCache22 * Alpha +
                        coeffs3 * cosCache4 * cosCache30 * Alpha +
                        coeffs4 * cosCache4 * cosCache38 * Alpha +
                        coeffs5 * cosCache4 * cosCache46 * Alpha +
                        coeffs6 * cosCache4 * cosCache54 * Alpha +
                        coeffs7 * cosCache4 * cosCache62 * Alpha +
                        coeffs8 * cosCache12 * cosCache6 * Alpha +
                        coeffs9 * cosCache12 * cosCache14 +
                        coeffs10 * cosCache12 * cosCache22 +
                        coeffs11 * cosCache12 * cosCache30 +
                        coeffs12 * cosCache12 * cosCache38 +
                        coeffs13 * cosCache12 * cosCache46 +
                        coeffs14 * cosCache12 * cosCache54 +
                        coeffs15 * cosCache12 * cosCache62 +
                        coeffs16 * cosCache20 * cosCache6 * Alpha +
                        coeffs17 * cosCache20 * cosCache14 +
                        coeffs18 * cosCache20 * cosCache22 +
                        coeffs19 * cosCache20 * cosCache30 +
                        coeffs20 * cosCache20 * cosCache38 +
                        coeffs21 * cosCache20 * cosCache46 +
                        coeffs22 * cosCache20 * cosCache54 +
                        coeffs23 * cosCache20 * cosCache62 +
                        coeffs24 * cosCache28 * cosCache6 * Alpha +
                        coeffs25 * cosCache28 * cosCache14 +
                        coeffs26 * cosCache28 * cosCache22 +
                        coeffs27 * cosCache28 * cosCache30 +
                        coeffs28 * cosCache28 * cosCache38 +
                        coeffs29 * cosCache28 * cosCache46 +
                        coeffs30 * cosCache28 * cosCache54 +
                        coeffs31 * cosCache28 * cosCache62 +
                        coeffs32 * cosCache36 * cosCache6 * Alpha +
                        coeffs33 * cosCache36 * cosCache14 +
                        coeffs34 * cosCache36 * cosCache22 +
                        coeffs35 * cosCache36 * cosCache30 +
                        coeffs36 * cosCache36 * cosCache38 +
                        coeffs37 * cosCache36 * cosCache46 +
                        coeffs38 * cosCache36 * cosCache54 +
                        coeffs39 * cosCache36 * cosCache62 +
                        coeffs40 * cosCache44 * cosCache6 * Alpha +
                        coeffs41 * cosCache44 * cosCache14 +
                        coeffs42 * cosCache44 * cosCache22 +
                        coeffs43 * cosCache44 * cosCache30 +
                        coeffs44 * cosCache44 * cosCache38 +
                        coeffs45 * cosCache44 * cosCache46 +
                        coeffs46 * cosCache44 * cosCache54 +
                        coeffs47 * cosCache44 * cosCache62 +
                        coeffs48 * cosCache52 * cosCache6 * Alpha +
                        coeffs49 * cosCache52 * cosCache14 +
                        coeffs50 * cosCache52 * cosCache22 +
                        coeffs51 * cosCache52 * cosCache30 +
                        coeffs52 * cosCache52 * cosCache38 +
                        coeffs53 * cosCache52 * cosCache46 +
                        coeffs54 * cosCache52 * cosCache54 +
                        coeffs55 * cosCache52 * cosCache62 +
                        coeffs56 * cosCache60 * cosCache6 * Alpha +
                        coeffs57 * cosCache60 * cosCache14 +
                        coeffs58 * cosCache60 * cosCache22 +
                        coeffs59 * cosCache60 * cosCache30 +
                        coeffs60 * cosCache60 * cosCache38 +
                        coeffs61 * cosCache60 * cosCache46 +
                        coeffs62 * cosCache60 * cosCache54 +
                        coeffs63 * cosCache60 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[4, 7] = (coeffs0 * cosCache4 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache4 * cosCache15 * Alpha +
                        coeffs2 * cosCache4 * cosCache23 * Alpha +
                        coeffs3 * cosCache4 * cosCache31 * Alpha +
                        coeffs4 * cosCache4 * cosCache39 * Alpha +
                        coeffs5 * cosCache4 * cosCache47 * Alpha +
                        coeffs6 * cosCache4 * cosCache55 * Alpha +
                        coeffs7 * cosCache4 * cosCache63 * Alpha +
                        coeffs8 * cosCache12 * cosCache7 * Alpha +
                        coeffs9 * cosCache12 * cosCache15 +
                        coeffs10 * cosCache12 * cosCache23 +
                        coeffs11 * cosCache12 * cosCache31 +
                        coeffs12 * cosCache12 * cosCache39 +
                        coeffs13 * cosCache12 * cosCache47 +
                        coeffs14 * cosCache12 * cosCache55 +
                        coeffs15 * cosCache12 * cosCache63 +
                        coeffs16 * cosCache20 * cosCache7 * Alpha +
                        coeffs17 * cosCache20 * cosCache15 +
                        coeffs18 * cosCache20 * cosCache23 +
                        coeffs19 * cosCache20 * cosCache31 +
                        coeffs20 * cosCache20 * cosCache39 +
                        coeffs21 * cosCache20 * cosCache47 +
                        coeffs22 * cosCache20 * cosCache55 +
                        coeffs23 * cosCache20 * cosCache63 +
                        coeffs24 * cosCache28 * cosCache7 * Alpha +
                        coeffs25 * cosCache28 * cosCache15 +
                        coeffs26 * cosCache28 * cosCache23 +
                        coeffs27 * cosCache28 * cosCache31 +
                        coeffs28 * cosCache28 * cosCache39 +
                        coeffs29 * cosCache28 * cosCache47 +
                        coeffs30 * cosCache28 * cosCache55 +
                        coeffs31 * cosCache28 * cosCache63 +
                        coeffs32 * cosCache36 * cosCache7 * Alpha +
                        coeffs33 * cosCache36 * cosCache15 +
                        coeffs34 * cosCache36 * cosCache23 +
                        coeffs35 * cosCache36 * cosCache31 +
                        coeffs36 * cosCache36 * cosCache39 +
                        coeffs37 * cosCache36 * cosCache47 +
                        coeffs38 * cosCache36 * cosCache55 +
                        coeffs39 * cosCache36 * cosCache63 +
                        coeffs40 * cosCache44 * cosCache7 * Alpha +
                        coeffs41 * cosCache44 * cosCache15 +
                        coeffs42 * cosCache44 * cosCache23 +
                        coeffs43 * cosCache44 * cosCache31 +
                        coeffs44 * cosCache44 * cosCache39 +
                        coeffs45 * cosCache44 * cosCache47 +
                        coeffs46 * cosCache44 * cosCache55 +
                        coeffs47 * cosCache44 * cosCache63 +
                        coeffs48 * cosCache52 * cosCache7 * Alpha +
                        coeffs49 * cosCache52 * cosCache15 +
                        coeffs50 * cosCache52 * cosCache23 +
                        coeffs51 * cosCache52 * cosCache31 +
                        coeffs52 * cosCache52 * cosCache39 +
                        coeffs53 * cosCache52 * cosCache47 +
                        coeffs54 * cosCache52 * cosCache55 +
                        coeffs55 * cosCache52 * cosCache63 +
                        coeffs56 * cosCache60 * cosCache7 * Alpha +
                        coeffs57 * cosCache60 * cosCache15 +
                        coeffs58 * cosCache60 * cosCache23 +
                        coeffs59 * cosCache60 * cosCache31 +
                        coeffs60 * cosCache60 * cosCache39 +
                        coeffs61 * cosCache60 * cosCache47 +
                        coeffs62 * cosCache60 * cosCache55 +
                        coeffs63 * cosCache60 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 0] = (coeffs0 * cosCache5 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache8 * Alpha +
                        coeffs2 * cosCache5 * cosCache16 * Alpha +
                        coeffs3 * cosCache5 * cosCache24 * Alpha +
                        coeffs4 * cosCache5 * cosCache32 * Alpha +
                        coeffs5 * cosCache5 * cosCache40 * Alpha +
                        coeffs6 * cosCache5 * cosCache48 * Alpha +
                        coeffs7 * cosCache5 * cosCache56 * Alpha +
                        coeffs8 * cosCache13 * cosCache0 * Alpha +
                        coeffs9 * cosCache13 * cosCache8 +
                        coeffs10 * cosCache13 * cosCache16 +
                        coeffs11 * cosCache13 * cosCache24 +
                        coeffs12 * cosCache13 * cosCache32 +
                        coeffs13 * cosCache13 * cosCache40 +
                        coeffs14 * cosCache13 * cosCache48 +
                        coeffs15 * cosCache13 * cosCache56 +
                        coeffs16 * cosCache21 * cosCache0 * Alpha +
                        coeffs17 * cosCache21 * cosCache8 +
                        coeffs18 * cosCache21 * cosCache16 +
                        coeffs19 * cosCache21 * cosCache24 +
                        coeffs20 * cosCache21 * cosCache32 +
                        coeffs21 * cosCache21 * cosCache40 +
                        coeffs22 * cosCache21 * cosCache48 +
                        coeffs23 * cosCache21 * cosCache56 +
                        coeffs24 * cosCache29 * cosCache0 * Alpha +
                        coeffs25 * cosCache29 * cosCache8 +
                        coeffs26 * cosCache29 * cosCache16 +
                        coeffs27 * cosCache29 * cosCache24 +
                        coeffs28 * cosCache29 * cosCache32 +
                        coeffs29 * cosCache29 * cosCache40 +
                        coeffs30 * cosCache29 * cosCache48 +
                        coeffs31 * cosCache29 * cosCache56 +
                        coeffs32 * cosCache37 * cosCache0 * Alpha +
                        coeffs33 * cosCache37 * cosCache8 +
                        coeffs34 * cosCache37 * cosCache16 +
                        coeffs35 * cosCache37 * cosCache24 +
                        coeffs36 * cosCache37 * cosCache32 +
                        coeffs37 * cosCache37 * cosCache40 +
                        coeffs38 * cosCache37 * cosCache48 +
                        coeffs39 * cosCache37 * cosCache56 +
                        coeffs40 * cosCache45 * cosCache0 * Alpha +
                        coeffs41 * cosCache45 * cosCache8 +
                        coeffs42 * cosCache45 * cosCache16 +
                        coeffs43 * cosCache45 * cosCache24 +
                        coeffs44 * cosCache45 * cosCache32 +
                        coeffs45 * cosCache45 * cosCache40 +
                        coeffs46 * cosCache45 * cosCache48 +
                        coeffs47 * cosCache45 * cosCache56 +
                        coeffs48 * cosCache53 * cosCache0 * Alpha +
                        coeffs49 * cosCache53 * cosCache8 +
                        coeffs50 * cosCache53 * cosCache16 +
                        coeffs51 * cosCache53 * cosCache24 +
                        coeffs52 * cosCache53 * cosCache32 +
                        coeffs53 * cosCache53 * cosCache40 +
                        coeffs54 * cosCache53 * cosCache48 +
                        coeffs55 * cosCache53 * cosCache56 +
                        coeffs56 * cosCache61 * cosCache0 * Alpha +
                        coeffs57 * cosCache61 * cosCache8 +
                        coeffs58 * cosCache61 * cosCache16 +
                        coeffs59 * cosCache61 * cosCache24 +
                        coeffs60 * cosCache61 * cosCache32 +
                        coeffs61 * cosCache61 * cosCache40 +
                        coeffs62 * cosCache61 * cosCache48 +
                        coeffs63 * cosCache61 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 1] = (coeffs0 * cosCache5 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache9 * Alpha +
                        coeffs2 * cosCache5 * cosCache17 * Alpha +
                        coeffs3 * cosCache5 * cosCache25 * Alpha +
                        coeffs4 * cosCache5 * cosCache33 * Alpha +
                        coeffs5 * cosCache5 * cosCache41 * Alpha +
                        coeffs6 * cosCache5 * cosCache49 * Alpha +
                        coeffs7 * cosCache5 * cosCache57 * Alpha +
                        coeffs8 * cosCache13 * cosCache1 * Alpha +
                        coeffs9 * cosCache13 * cosCache9 +
                        coeffs10 * cosCache13 * cosCache17 +
                        coeffs11 * cosCache13 * cosCache25 +
                        coeffs12 * cosCache13 * cosCache33 +
                        coeffs13 * cosCache13 * cosCache41 +
                        coeffs14 * cosCache13 * cosCache49 +
                        coeffs15 * cosCache13 * cosCache57 +
                        coeffs16 * cosCache21 * cosCache1 * Alpha +
                        coeffs17 * cosCache21 * cosCache9 +
                        coeffs18 * cosCache21 * cosCache17 +
                        coeffs19 * cosCache21 * cosCache25 +
                        coeffs20 * cosCache21 * cosCache33 +
                        coeffs21 * cosCache21 * cosCache41 +
                        coeffs22 * cosCache21 * cosCache49 +
                        coeffs23 * cosCache21 * cosCache57 +
                        coeffs24 * cosCache29 * cosCache1 * Alpha +
                        coeffs25 * cosCache29 * cosCache9 +
                        coeffs26 * cosCache29 * cosCache17 +
                        coeffs27 * cosCache29 * cosCache25 +
                        coeffs28 * cosCache29 * cosCache33 +
                        coeffs29 * cosCache29 * cosCache41 +
                        coeffs30 * cosCache29 * cosCache49 +
                        coeffs31 * cosCache29 * cosCache57 +
                        coeffs32 * cosCache37 * cosCache1 * Alpha +
                        coeffs33 * cosCache37 * cosCache9 +
                        coeffs34 * cosCache37 * cosCache17 +
                        coeffs35 * cosCache37 * cosCache25 +
                        coeffs36 * cosCache37 * cosCache33 +
                        coeffs37 * cosCache37 * cosCache41 +
                        coeffs38 * cosCache37 * cosCache49 +
                        coeffs39 * cosCache37 * cosCache57 +
                        coeffs40 * cosCache45 * cosCache1 * Alpha +
                        coeffs41 * cosCache45 * cosCache9 +
                        coeffs42 * cosCache45 * cosCache17 +
                        coeffs43 * cosCache45 * cosCache25 +
                        coeffs44 * cosCache45 * cosCache33 +
                        coeffs45 * cosCache45 * cosCache41 +
                        coeffs46 * cosCache45 * cosCache49 +
                        coeffs47 * cosCache45 * cosCache57 +
                        coeffs48 * cosCache53 * cosCache1 * Alpha +
                        coeffs49 * cosCache53 * cosCache9 +
                        coeffs50 * cosCache53 * cosCache17 +
                        coeffs51 * cosCache53 * cosCache25 +
                        coeffs52 * cosCache53 * cosCache33 +
                        coeffs53 * cosCache53 * cosCache41 +
                        coeffs54 * cosCache53 * cosCache49 +
                        coeffs55 * cosCache53 * cosCache57 +
                        coeffs56 * cosCache61 * cosCache1 * Alpha +
                        coeffs57 * cosCache61 * cosCache9 +
                        coeffs58 * cosCache61 * cosCache17 +
                        coeffs59 * cosCache61 * cosCache25 +
                        coeffs60 * cosCache61 * cosCache33 +
                        coeffs61 * cosCache61 * cosCache41 +
                        coeffs62 * cosCache61 * cosCache49 +
                        coeffs63 * cosCache61 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 2] = (coeffs0 * cosCache5 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache10 * Alpha +
                        coeffs2 * cosCache5 * cosCache18 * Alpha +
                        coeffs3 * cosCache5 * cosCache26 * Alpha +
                        coeffs4 * cosCache5 * cosCache34 * Alpha +
                        coeffs5 * cosCache5 * cosCache42 * Alpha +
                        coeffs6 * cosCache5 * cosCache50 * Alpha +
                        coeffs7 * cosCache5 * cosCache58 * Alpha +
                        coeffs8 * cosCache13 * cosCache2 * Alpha +
                        coeffs9 * cosCache13 * cosCache10 +
                        coeffs10 * cosCache13 * cosCache18 +
                        coeffs11 * cosCache13 * cosCache26 +
                        coeffs12 * cosCache13 * cosCache34 +
                        coeffs13 * cosCache13 * cosCache42 +
                        coeffs14 * cosCache13 * cosCache50 +
                        coeffs15 * cosCache13 * cosCache58 +
                        coeffs16 * cosCache21 * cosCache2 * Alpha +
                        coeffs17 * cosCache21 * cosCache10 +
                        coeffs18 * cosCache21 * cosCache18 +
                        coeffs19 * cosCache21 * cosCache26 +
                        coeffs20 * cosCache21 * cosCache34 +
                        coeffs21 * cosCache21 * cosCache42 +
                        coeffs22 * cosCache21 * cosCache50 +
                        coeffs23 * cosCache21 * cosCache58 +
                        coeffs24 * cosCache29 * cosCache2 * Alpha +
                        coeffs25 * cosCache29 * cosCache10 +
                        coeffs26 * cosCache29 * cosCache18 +
                        coeffs27 * cosCache29 * cosCache26 +
                        coeffs28 * cosCache29 * cosCache34 +
                        coeffs29 * cosCache29 * cosCache42 +
                        coeffs30 * cosCache29 * cosCache50 +
                        coeffs31 * cosCache29 * cosCache58 +
                        coeffs32 * cosCache37 * cosCache2 * Alpha +
                        coeffs33 * cosCache37 * cosCache10 +
                        coeffs34 * cosCache37 * cosCache18 +
                        coeffs35 * cosCache37 * cosCache26 +
                        coeffs36 * cosCache37 * cosCache34 +
                        coeffs37 * cosCache37 * cosCache42 +
                        coeffs38 * cosCache37 * cosCache50 +
                        coeffs39 * cosCache37 * cosCache58 +
                        coeffs40 * cosCache45 * cosCache2 * Alpha +
                        coeffs41 * cosCache45 * cosCache10 +
                        coeffs42 * cosCache45 * cosCache18 +
                        coeffs43 * cosCache45 * cosCache26 +
                        coeffs44 * cosCache45 * cosCache34 +
                        coeffs45 * cosCache45 * cosCache42 +
                        coeffs46 * cosCache45 * cosCache50 +
                        coeffs47 * cosCache45 * cosCache58 +
                        coeffs48 * cosCache53 * cosCache2 * Alpha +
                        coeffs49 * cosCache53 * cosCache10 +
                        coeffs50 * cosCache53 * cosCache18 +
                        coeffs51 * cosCache53 * cosCache26 +
                        coeffs52 * cosCache53 * cosCache34 +
                        coeffs53 * cosCache53 * cosCache42 +
                        coeffs54 * cosCache53 * cosCache50 +
                        coeffs55 * cosCache53 * cosCache58 +
                        coeffs56 * cosCache61 * cosCache2 * Alpha +
                        coeffs57 * cosCache61 * cosCache10 +
                        coeffs58 * cosCache61 * cosCache18 +
                        coeffs59 * cosCache61 * cosCache26 +
                        coeffs60 * cosCache61 * cosCache34 +
                        coeffs61 * cosCache61 * cosCache42 +
                        coeffs62 * cosCache61 * cosCache50 +
                        coeffs63 * cosCache61 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 3] = (coeffs0 * cosCache5 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache11 * Alpha +
                        coeffs2 * cosCache5 * cosCache19 * Alpha +
                        coeffs3 * cosCache5 * cosCache27 * Alpha +
                        coeffs4 * cosCache5 * cosCache35 * Alpha +
                        coeffs5 * cosCache5 * cosCache43 * Alpha +
                        coeffs6 * cosCache5 * cosCache51 * Alpha +
                        coeffs7 * cosCache5 * cosCache59 * Alpha +
                        coeffs8 * cosCache13 * cosCache3 * Alpha +
                        coeffs9 * cosCache13 * cosCache11 +
                        coeffs10 * cosCache13 * cosCache19 +
                        coeffs11 * cosCache13 * cosCache27 +
                        coeffs12 * cosCache13 * cosCache35 +
                        coeffs13 * cosCache13 * cosCache43 +
                        coeffs14 * cosCache13 * cosCache51 +
                        coeffs15 * cosCache13 * cosCache59 +
                        coeffs16 * cosCache21 * cosCache3 * Alpha +
                        coeffs17 * cosCache21 * cosCache11 +
                        coeffs18 * cosCache21 * cosCache19 +
                        coeffs19 * cosCache21 * cosCache27 +
                        coeffs20 * cosCache21 * cosCache35 +
                        coeffs21 * cosCache21 * cosCache43 +
                        coeffs22 * cosCache21 * cosCache51 +
                        coeffs23 * cosCache21 * cosCache59 +
                        coeffs24 * cosCache29 * cosCache3 * Alpha +
                        coeffs25 * cosCache29 * cosCache11 +
                        coeffs26 * cosCache29 * cosCache19 +
                        coeffs27 * cosCache29 * cosCache27 +
                        coeffs28 * cosCache29 * cosCache35 +
                        coeffs29 * cosCache29 * cosCache43 +
                        coeffs30 * cosCache29 * cosCache51 +
                        coeffs31 * cosCache29 * cosCache59 +
                        coeffs32 * cosCache37 * cosCache3 * Alpha +
                        coeffs33 * cosCache37 * cosCache11 +
                        coeffs34 * cosCache37 * cosCache19 +
                        coeffs35 * cosCache37 * cosCache27 +
                        coeffs36 * cosCache37 * cosCache35 +
                        coeffs37 * cosCache37 * cosCache43 +
                        coeffs38 * cosCache37 * cosCache51 +
                        coeffs39 * cosCache37 * cosCache59 +
                        coeffs40 * cosCache45 * cosCache3 * Alpha +
                        coeffs41 * cosCache45 * cosCache11 +
                        coeffs42 * cosCache45 * cosCache19 +
                        coeffs43 * cosCache45 * cosCache27 +
                        coeffs44 * cosCache45 * cosCache35 +
                        coeffs45 * cosCache45 * cosCache43 +
                        coeffs46 * cosCache45 * cosCache51 +
                        coeffs47 * cosCache45 * cosCache59 +
                        coeffs48 * cosCache53 * cosCache3 * Alpha +
                        coeffs49 * cosCache53 * cosCache11 +
                        coeffs50 * cosCache53 * cosCache19 +
                        coeffs51 * cosCache53 * cosCache27 +
                        coeffs52 * cosCache53 * cosCache35 +
                        coeffs53 * cosCache53 * cosCache43 +
                        coeffs54 * cosCache53 * cosCache51 +
                        coeffs55 * cosCache53 * cosCache59 +
                        coeffs56 * cosCache61 * cosCache3 * Alpha +
                        coeffs57 * cosCache61 * cosCache11 +
                        coeffs58 * cosCache61 * cosCache19 +
                        coeffs59 * cosCache61 * cosCache27 +
                        coeffs60 * cosCache61 * cosCache35 +
                        coeffs61 * cosCache61 * cosCache43 +
                        coeffs62 * cosCache61 * cosCache51 +
                        coeffs63 * cosCache61 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 4] = (coeffs0 * cosCache5 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache12 * Alpha +
                        coeffs2 * cosCache5 * cosCache20 * Alpha +
                        coeffs3 * cosCache5 * cosCache28 * Alpha +
                        coeffs4 * cosCache5 * cosCache36 * Alpha +
                        coeffs5 * cosCache5 * cosCache44 * Alpha +
                        coeffs6 * cosCache5 * cosCache52 * Alpha +
                        coeffs7 * cosCache5 * cosCache60 * Alpha +
                        coeffs8 * cosCache13 * cosCache4 * Alpha +
                        coeffs9 * cosCache13 * cosCache12 +
                        coeffs10 * cosCache13 * cosCache20 +
                        coeffs11 * cosCache13 * cosCache28 +
                        coeffs12 * cosCache13 * cosCache36 +
                        coeffs13 * cosCache13 * cosCache44 +
                        coeffs14 * cosCache13 * cosCache52 +
                        coeffs15 * cosCache13 * cosCache60 +
                        coeffs16 * cosCache21 * cosCache4 * Alpha +
                        coeffs17 * cosCache21 * cosCache12 +
                        coeffs18 * cosCache21 * cosCache20 +
                        coeffs19 * cosCache21 * cosCache28 +
                        coeffs20 * cosCache21 * cosCache36 +
                        coeffs21 * cosCache21 * cosCache44 +
                        coeffs22 * cosCache21 * cosCache52 +
                        coeffs23 * cosCache21 * cosCache60 +
                        coeffs24 * cosCache29 * cosCache4 * Alpha +
                        coeffs25 * cosCache29 * cosCache12 +
                        coeffs26 * cosCache29 * cosCache20 +
                        coeffs27 * cosCache29 * cosCache28 +
                        coeffs28 * cosCache29 * cosCache36 +
                        coeffs29 * cosCache29 * cosCache44 +
                        coeffs30 * cosCache29 * cosCache52 +
                        coeffs31 * cosCache29 * cosCache60 +
                        coeffs32 * cosCache37 * cosCache4 * Alpha +
                        coeffs33 * cosCache37 * cosCache12 +
                        coeffs34 * cosCache37 * cosCache20 +
                        coeffs35 * cosCache37 * cosCache28 +
                        coeffs36 * cosCache37 * cosCache36 +
                        coeffs37 * cosCache37 * cosCache44 +
                        coeffs38 * cosCache37 * cosCache52 +
                        coeffs39 * cosCache37 * cosCache60 +
                        coeffs40 * cosCache45 * cosCache4 * Alpha +
                        coeffs41 * cosCache45 * cosCache12 +
                        coeffs42 * cosCache45 * cosCache20 +
                        coeffs43 * cosCache45 * cosCache28 +
                        coeffs44 * cosCache45 * cosCache36 +
                        coeffs45 * cosCache45 * cosCache44 +
                        coeffs46 * cosCache45 * cosCache52 +
                        coeffs47 * cosCache45 * cosCache60 +
                        coeffs48 * cosCache53 * cosCache4 * Alpha +
                        coeffs49 * cosCache53 * cosCache12 +
                        coeffs50 * cosCache53 * cosCache20 +
                        coeffs51 * cosCache53 * cosCache28 +
                        coeffs52 * cosCache53 * cosCache36 +
                        coeffs53 * cosCache53 * cosCache44 +
                        coeffs54 * cosCache53 * cosCache52 +
                        coeffs55 * cosCache53 * cosCache60 +
                        coeffs56 * cosCache61 * cosCache4 * Alpha +
                        coeffs57 * cosCache61 * cosCache12 +
                        coeffs58 * cosCache61 * cosCache20 +
                        coeffs59 * cosCache61 * cosCache28 +
                        coeffs60 * cosCache61 * cosCache36 +
                        coeffs61 * cosCache61 * cosCache44 +
                        coeffs62 * cosCache61 * cosCache52 +
                        coeffs63 * cosCache61 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 5] = (coeffs0 * cosCache5 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache13 * Alpha +
                        coeffs2 * cosCache5 * cosCache21 * Alpha +
                        coeffs3 * cosCache5 * cosCache29 * Alpha +
                        coeffs4 * cosCache5 * cosCache37 * Alpha +
                        coeffs5 * cosCache5 * cosCache45 * Alpha +
                        coeffs6 * cosCache5 * cosCache53 * Alpha +
                        coeffs7 * cosCache5 * cosCache61 * Alpha +
                        coeffs8 * cosCache13 * cosCache5 * Alpha +
                        coeffs9 * cosCache13 * cosCache13 +
                        coeffs10 * cosCache13 * cosCache21 +
                        coeffs11 * cosCache13 * cosCache29 +
                        coeffs12 * cosCache13 * cosCache37 +
                        coeffs13 * cosCache13 * cosCache45 +
                        coeffs14 * cosCache13 * cosCache53 +
                        coeffs15 * cosCache13 * cosCache61 +
                        coeffs16 * cosCache21 * cosCache5 * Alpha +
                        coeffs17 * cosCache21 * cosCache13 +
                        coeffs18 * cosCache21 * cosCache21 +
                        coeffs19 * cosCache21 * cosCache29 +
                        coeffs20 * cosCache21 * cosCache37 +
                        coeffs21 * cosCache21 * cosCache45 +
                        coeffs22 * cosCache21 * cosCache53 +
                        coeffs23 * cosCache21 * cosCache61 +
                        coeffs24 * cosCache29 * cosCache5 * Alpha +
                        coeffs25 * cosCache29 * cosCache13 +
                        coeffs26 * cosCache29 * cosCache21 +
                        coeffs27 * cosCache29 * cosCache29 +
                        coeffs28 * cosCache29 * cosCache37 +
                        coeffs29 * cosCache29 * cosCache45 +
                        coeffs30 * cosCache29 * cosCache53 +
                        coeffs31 * cosCache29 * cosCache61 +
                        coeffs32 * cosCache37 * cosCache5 * Alpha +
                        coeffs33 * cosCache37 * cosCache13 +
                        coeffs34 * cosCache37 * cosCache21 +
                        coeffs35 * cosCache37 * cosCache29 +
                        coeffs36 * cosCache37 * cosCache37 +
                        coeffs37 * cosCache37 * cosCache45 +
                        coeffs38 * cosCache37 * cosCache53 +
                        coeffs39 * cosCache37 * cosCache61 +
                        coeffs40 * cosCache45 * cosCache5 * Alpha +
                        coeffs41 * cosCache45 * cosCache13 +
                        coeffs42 * cosCache45 * cosCache21 +
                        coeffs43 * cosCache45 * cosCache29 +
                        coeffs44 * cosCache45 * cosCache37 +
                        coeffs45 * cosCache45 * cosCache45 +
                        coeffs46 * cosCache45 * cosCache53 +
                        coeffs47 * cosCache45 * cosCache61 +
                        coeffs48 * cosCache53 * cosCache5 * Alpha +
                        coeffs49 * cosCache53 * cosCache13 +
                        coeffs50 * cosCache53 * cosCache21 +
                        coeffs51 * cosCache53 * cosCache29 +
                        coeffs52 * cosCache53 * cosCache37 +
                        coeffs53 * cosCache53 * cosCache45 +
                        coeffs54 * cosCache53 * cosCache53 +
                        coeffs55 * cosCache53 * cosCache61 +
                        coeffs56 * cosCache61 * cosCache5 * Alpha +
                        coeffs57 * cosCache61 * cosCache13 +
                        coeffs58 * cosCache61 * cosCache21 +
                        coeffs59 * cosCache61 * cosCache29 +
                        coeffs60 * cosCache61 * cosCache37 +
                        coeffs61 * cosCache61 * cosCache45 +
                        coeffs62 * cosCache61 * cosCache53 +
                        coeffs63 * cosCache61 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 6] = (coeffs0 * cosCache5 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache14 * Alpha +
                        coeffs2 * cosCache5 * cosCache22 * Alpha +
                        coeffs3 * cosCache5 * cosCache30 * Alpha +
                        coeffs4 * cosCache5 * cosCache38 * Alpha +
                        coeffs5 * cosCache5 * cosCache46 * Alpha +
                        coeffs6 * cosCache5 * cosCache54 * Alpha +
                        coeffs7 * cosCache5 * cosCache62 * Alpha +
                        coeffs8 * cosCache13 * cosCache6 * Alpha +
                        coeffs9 * cosCache13 * cosCache14 +
                        coeffs10 * cosCache13 * cosCache22 +
                        coeffs11 * cosCache13 * cosCache30 +
                        coeffs12 * cosCache13 * cosCache38 +
                        coeffs13 * cosCache13 * cosCache46 +
                        coeffs14 * cosCache13 * cosCache54 +
                        coeffs15 * cosCache13 * cosCache62 +
                        coeffs16 * cosCache21 * cosCache6 * Alpha +
                        coeffs17 * cosCache21 * cosCache14 +
                        coeffs18 * cosCache21 * cosCache22 +
                        coeffs19 * cosCache21 * cosCache30 +
                        coeffs20 * cosCache21 * cosCache38 +
                        coeffs21 * cosCache21 * cosCache46 +
                        coeffs22 * cosCache21 * cosCache54 +
                        coeffs23 * cosCache21 * cosCache62 +
                        coeffs24 * cosCache29 * cosCache6 * Alpha +
                        coeffs25 * cosCache29 * cosCache14 +
                        coeffs26 * cosCache29 * cosCache22 +
                        coeffs27 * cosCache29 * cosCache30 +
                        coeffs28 * cosCache29 * cosCache38 +
                        coeffs29 * cosCache29 * cosCache46 +
                        coeffs30 * cosCache29 * cosCache54 +
                        coeffs31 * cosCache29 * cosCache62 +
                        coeffs32 * cosCache37 * cosCache6 * Alpha +
                        coeffs33 * cosCache37 * cosCache14 +
                        coeffs34 * cosCache37 * cosCache22 +
                        coeffs35 * cosCache37 * cosCache30 +
                        coeffs36 * cosCache37 * cosCache38 +
                        coeffs37 * cosCache37 * cosCache46 +
                        coeffs38 * cosCache37 * cosCache54 +
                        coeffs39 * cosCache37 * cosCache62 +
                        coeffs40 * cosCache45 * cosCache6 * Alpha +
                        coeffs41 * cosCache45 * cosCache14 +
                        coeffs42 * cosCache45 * cosCache22 +
                        coeffs43 * cosCache45 * cosCache30 +
                        coeffs44 * cosCache45 * cosCache38 +
                        coeffs45 * cosCache45 * cosCache46 +
                        coeffs46 * cosCache45 * cosCache54 +
                        coeffs47 * cosCache45 * cosCache62 +
                        coeffs48 * cosCache53 * cosCache6 * Alpha +
                        coeffs49 * cosCache53 * cosCache14 +
                        coeffs50 * cosCache53 * cosCache22 +
                        coeffs51 * cosCache53 * cosCache30 +
                        coeffs52 * cosCache53 * cosCache38 +
                        coeffs53 * cosCache53 * cosCache46 +
                        coeffs54 * cosCache53 * cosCache54 +
                        coeffs55 * cosCache53 * cosCache62 +
                        coeffs56 * cosCache61 * cosCache6 * Alpha +
                        coeffs57 * cosCache61 * cosCache14 +
                        coeffs58 * cosCache61 * cosCache22 +
                        coeffs59 * cosCache61 * cosCache30 +
                        coeffs60 * cosCache61 * cosCache38 +
                        coeffs61 * cosCache61 * cosCache46 +
                        coeffs62 * cosCache61 * cosCache54 +
                        coeffs63 * cosCache61 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[5, 7] = (coeffs0 * cosCache5 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache5 * cosCache15 * Alpha +
                        coeffs2 * cosCache5 * cosCache23 * Alpha +
                        coeffs3 * cosCache5 * cosCache31 * Alpha +
                        coeffs4 * cosCache5 * cosCache39 * Alpha +
                        coeffs5 * cosCache5 * cosCache47 * Alpha +
                        coeffs6 * cosCache5 * cosCache55 * Alpha +
                        coeffs7 * cosCache5 * cosCache63 * Alpha +
                        coeffs8 * cosCache13 * cosCache7 * Alpha +
                        coeffs9 * cosCache13 * cosCache15 +
                        coeffs10 * cosCache13 * cosCache23 +
                        coeffs11 * cosCache13 * cosCache31 +
                        coeffs12 * cosCache13 * cosCache39 +
                        coeffs13 * cosCache13 * cosCache47 +
                        coeffs14 * cosCache13 * cosCache55 +
                        coeffs15 * cosCache13 * cosCache63 +
                        coeffs16 * cosCache21 * cosCache7 * Alpha +
                        coeffs17 * cosCache21 * cosCache15 +
                        coeffs18 * cosCache21 * cosCache23 +
                        coeffs19 * cosCache21 * cosCache31 +
                        coeffs20 * cosCache21 * cosCache39 +
                        coeffs21 * cosCache21 * cosCache47 +
                        coeffs22 * cosCache21 * cosCache55 +
                        coeffs23 * cosCache21 * cosCache63 +
                        coeffs24 * cosCache29 * cosCache7 * Alpha +
                        coeffs25 * cosCache29 * cosCache15 +
                        coeffs26 * cosCache29 * cosCache23 +
                        coeffs27 * cosCache29 * cosCache31 +
                        coeffs28 * cosCache29 * cosCache39 +
                        coeffs29 * cosCache29 * cosCache47 +
                        coeffs30 * cosCache29 * cosCache55 +
                        coeffs31 * cosCache29 * cosCache63 +
                        coeffs32 * cosCache37 * cosCache7 * Alpha +
                        coeffs33 * cosCache37 * cosCache15 +
                        coeffs34 * cosCache37 * cosCache23 +
                        coeffs35 * cosCache37 * cosCache31 +
                        coeffs36 * cosCache37 * cosCache39 +
                        coeffs37 * cosCache37 * cosCache47 +
                        coeffs38 * cosCache37 * cosCache55 +
                        coeffs39 * cosCache37 * cosCache63 +
                        coeffs40 * cosCache45 * cosCache7 * Alpha +
                        coeffs41 * cosCache45 * cosCache15 +
                        coeffs42 * cosCache45 * cosCache23 +
                        coeffs43 * cosCache45 * cosCache31 +
                        coeffs44 * cosCache45 * cosCache39 +
                        coeffs45 * cosCache45 * cosCache47 +
                        coeffs46 * cosCache45 * cosCache55 +
                        coeffs47 * cosCache45 * cosCache63 +
                        coeffs48 * cosCache53 * cosCache7 * Alpha +
                        coeffs49 * cosCache53 * cosCache15 +
                        coeffs50 * cosCache53 * cosCache23 +
                        coeffs51 * cosCache53 * cosCache31 +
                        coeffs52 * cosCache53 * cosCache39 +
                        coeffs53 * cosCache53 * cosCache47 +
                        coeffs54 * cosCache53 * cosCache55 +
                        coeffs55 * cosCache53 * cosCache63 +
                        coeffs56 * cosCache61 * cosCache7 * Alpha +
                        coeffs57 * cosCache61 * cosCache15 +
                        coeffs58 * cosCache61 * cosCache23 +
                        coeffs59 * cosCache61 * cosCache31 +
                        coeffs60 * cosCache61 * cosCache39 +
                        coeffs61 * cosCache61 * cosCache47 +
                        coeffs62 * cosCache61 * cosCache55 +
                        coeffs63 * cosCache61 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 0] = (coeffs0 * cosCache6 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache8 * Alpha +
                        coeffs2 * cosCache6 * cosCache16 * Alpha +
                        coeffs3 * cosCache6 * cosCache24 * Alpha +
                        coeffs4 * cosCache6 * cosCache32 * Alpha +
                        coeffs5 * cosCache6 * cosCache40 * Alpha +
                        coeffs6 * cosCache6 * cosCache48 * Alpha +
                        coeffs7 * cosCache6 * cosCache56 * Alpha +
                        coeffs8 * cosCache14 * cosCache0 * Alpha +
                        coeffs9 * cosCache14 * cosCache8 +
                        coeffs10 * cosCache14 * cosCache16 +
                        coeffs11 * cosCache14 * cosCache24 +
                        coeffs12 * cosCache14 * cosCache32 +
                        coeffs13 * cosCache14 * cosCache40 +
                        coeffs14 * cosCache14 * cosCache48 +
                        coeffs15 * cosCache14 * cosCache56 +
                        coeffs16 * cosCache22 * cosCache0 * Alpha +
                        coeffs17 * cosCache22 * cosCache8 +
                        coeffs18 * cosCache22 * cosCache16 +
                        coeffs19 * cosCache22 * cosCache24 +
                        coeffs20 * cosCache22 * cosCache32 +
                        coeffs21 * cosCache22 * cosCache40 +
                        coeffs22 * cosCache22 * cosCache48 +
                        coeffs23 * cosCache22 * cosCache56 +
                        coeffs24 * cosCache30 * cosCache0 * Alpha +
                        coeffs25 * cosCache30 * cosCache8 +
                        coeffs26 * cosCache30 * cosCache16 +
                        coeffs27 * cosCache30 * cosCache24 +
                        coeffs28 * cosCache30 * cosCache32 +
                        coeffs29 * cosCache30 * cosCache40 +
                        coeffs30 * cosCache30 * cosCache48 +
                        coeffs31 * cosCache30 * cosCache56 +
                        coeffs32 * cosCache38 * cosCache0 * Alpha +
                        coeffs33 * cosCache38 * cosCache8 +
                        coeffs34 * cosCache38 * cosCache16 +
                        coeffs35 * cosCache38 * cosCache24 +
                        coeffs36 * cosCache38 * cosCache32 +
                        coeffs37 * cosCache38 * cosCache40 +
                        coeffs38 * cosCache38 * cosCache48 +
                        coeffs39 * cosCache38 * cosCache56 +
                        coeffs40 * cosCache46 * cosCache0 * Alpha +
                        coeffs41 * cosCache46 * cosCache8 +
                        coeffs42 * cosCache46 * cosCache16 +
                        coeffs43 * cosCache46 * cosCache24 +
                        coeffs44 * cosCache46 * cosCache32 +
                        coeffs45 * cosCache46 * cosCache40 +
                        coeffs46 * cosCache46 * cosCache48 +
                        coeffs47 * cosCache46 * cosCache56 +
                        coeffs48 * cosCache54 * cosCache0 * Alpha +
                        coeffs49 * cosCache54 * cosCache8 +
                        coeffs50 * cosCache54 * cosCache16 +
                        coeffs51 * cosCache54 * cosCache24 +
                        coeffs52 * cosCache54 * cosCache32 +
                        coeffs53 * cosCache54 * cosCache40 +
                        coeffs54 * cosCache54 * cosCache48 +
                        coeffs55 * cosCache54 * cosCache56 +
                        coeffs56 * cosCache62 * cosCache0 * Alpha +
                        coeffs57 * cosCache62 * cosCache8 +
                        coeffs58 * cosCache62 * cosCache16 +
                        coeffs59 * cosCache62 * cosCache24 +
                        coeffs60 * cosCache62 * cosCache32 +
                        coeffs61 * cosCache62 * cosCache40 +
                        coeffs62 * cosCache62 * cosCache48 +
                        coeffs63 * cosCache62 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 1] = (coeffs0 * cosCache6 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache9 * Alpha +
                        coeffs2 * cosCache6 * cosCache17 * Alpha +
                        coeffs3 * cosCache6 * cosCache25 * Alpha +
                        coeffs4 * cosCache6 * cosCache33 * Alpha +
                        coeffs5 * cosCache6 * cosCache41 * Alpha +
                        coeffs6 * cosCache6 * cosCache49 * Alpha +
                        coeffs7 * cosCache6 * cosCache57 * Alpha +
                        coeffs8 * cosCache14 * cosCache1 * Alpha +
                        coeffs9 * cosCache14 * cosCache9 +
                        coeffs10 * cosCache14 * cosCache17 +
                        coeffs11 * cosCache14 * cosCache25 +
                        coeffs12 * cosCache14 * cosCache33 +
                        coeffs13 * cosCache14 * cosCache41 +
                        coeffs14 * cosCache14 * cosCache49 +
                        coeffs15 * cosCache14 * cosCache57 +
                        coeffs16 * cosCache22 * cosCache1 * Alpha +
                        coeffs17 * cosCache22 * cosCache9 +
                        coeffs18 * cosCache22 * cosCache17 +
                        coeffs19 * cosCache22 * cosCache25 +
                        coeffs20 * cosCache22 * cosCache33 +
                        coeffs21 * cosCache22 * cosCache41 +
                        coeffs22 * cosCache22 * cosCache49 +
                        coeffs23 * cosCache22 * cosCache57 +
                        coeffs24 * cosCache30 * cosCache1 * Alpha +
                        coeffs25 * cosCache30 * cosCache9 +
                        coeffs26 * cosCache30 * cosCache17 +
                        coeffs27 * cosCache30 * cosCache25 +
                        coeffs28 * cosCache30 * cosCache33 +
                        coeffs29 * cosCache30 * cosCache41 +
                        coeffs30 * cosCache30 * cosCache49 +
                        coeffs31 * cosCache30 * cosCache57 +
                        coeffs32 * cosCache38 * cosCache1 * Alpha +
                        coeffs33 * cosCache38 * cosCache9 +
                        coeffs34 * cosCache38 * cosCache17 +
                        coeffs35 * cosCache38 * cosCache25 +
                        coeffs36 * cosCache38 * cosCache33 +
                        coeffs37 * cosCache38 * cosCache41 +
                        coeffs38 * cosCache38 * cosCache49 +
                        coeffs39 * cosCache38 * cosCache57 +
                        coeffs40 * cosCache46 * cosCache1 * Alpha +
                        coeffs41 * cosCache46 * cosCache9 +
                        coeffs42 * cosCache46 * cosCache17 +
                        coeffs43 * cosCache46 * cosCache25 +
                        coeffs44 * cosCache46 * cosCache33 +
                        coeffs45 * cosCache46 * cosCache41 +
                        coeffs46 * cosCache46 * cosCache49 +
                        coeffs47 * cosCache46 * cosCache57 +
                        coeffs48 * cosCache54 * cosCache1 * Alpha +
                        coeffs49 * cosCache54 * cosCache9 +
                        coeffs50 * cosCache54 * cosCache17 +
                        coeffs51 * cosCache54 * cosCache25 +
                        coeffs52 * cosCache54 * cosCache33 +
                        coeffs53 * cosCache54 * cosCache41 +
                        coeffs54 * cosCache54 * cosCache49 +
                        coeffs55 * cosCache54 * cosCache57 +
                        coeffs56 * cosCache62 * cosCache1 * Alpha +
                        coeffs57 * cosCache62 * cosCache9 +
                        coeffs58 * cosCache62 * cosCache17 +
                        coeffs59 * cosCache62 * cosCache25 +
                        coeffs60 * cosCache62 * cosCache33 +
                        coeffs61 * cosCache62 * cosCache41 +
                        coeffs62 * cosCache62 * cosCache49 +
                        coeffs63 * cosCache62 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 2] = (coeffs0 * cosCache6 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache10 * Alpha +
                        coeffs2 * cosCache6 * cosCache18 * Alpha +
                        coeffs3 * cosCache6 * cosCache26 * Alpha +
                        coeffs4 * cosCache6 * cosCache34 * Alpha +
                        coeffs5 * cosCache6 * cosCache42 * Alpha +
                        coeffs6 * cosCache6 * cosCache50 * Alpha +
                        coeffs7 * cosCache6 * cosCache58 * Alpha +
                        coeffs8 * cosCache14 * cosCache2 * Alpha +
                        coeffs9 * cosCache14 * cosCache10 +
                        coeffs10 * cosCache14 * cosCache18 +
                        coeffs11 * cosCache14 * cosCache26 +
                        coeffs12 * cosCache14 * cosCache34 +
                        coeffs13 * cosCache14 * cosCache42 +
                        coeffs14 * cosCache14 * cosCache50 +
                        coeffs15 * cosCache14 * cosCache58 +
                        coeffs16 * cosCache22 * cosCache2 * Alpha +
                        coeffs17 * cosCache22 * cosCache10 +
                        coeffs18 * cosCache22 * cosCache18 +
                        coeffs19 * cosCache22 * cosCache26 +
                        coeffs20 * cosCache22 * cosCache34 +
                        coeffs21 * cosCache22 * cosCache42 +
                        coeffs22 * cosCache22 * cosCache50 +
                        coeffs23 * cosCache22 * cosCache58 +
                        coeffs24 * cosCache30 * cosCache2 * Alpha +
                        coeffs25 * cosCache30 * cosCache10 +
                        coeffs26 * cosCache30 * cosCache18 +
                        coeffs27 * cosCache30 * cosCache26 +
                        coeffs28 * cosCache30 * cosCache34 +
                        coeffs29 * cosCache30 * cosCache42 +
                        coeffs30 * cosCache30 * cosCache50 +
                        coeffs31 * cosCache30 * cosCache58 +
                        coeffs32 * cosCache38 * cosCache2 * Alpha +
                        coeffs33 * cosCache38 * cosCache10 +
                        coeffs34 * cosCache38 * cosCache18 +
                        coeffs35 * cosCache38 * cosCache26 +
                        coeffs36 * cosCache38 * cosCache34 +
                        coeffs37 * cosCache38 * cosCache42 +
                        coeffs38 * cosCache38 * cosCache50 +
                        coeffs39 * cosCache38 * cosCache58 +
                        coeffs40 * cosCache46 * cosCache2 * Alpha +
                        coeffs41 * cosCache46 * cosCache10 +
                        coeffs42 * cosCache46 * cosCache18 +
                        coeffs43 * cosCache46 * cosCache26 +
                        coeffs44 * cosCache46 * cosCache34 +
                        coeffs45 * cosCache46 * cosCache42 +
                        coeffs46 * cosCache46 * cosCache50 +
                        coeffs47 * cosCache46 * cosCache58 +
                        coeffs48 * cosCache54 * cosCache2 * Alpha +
                        coeffs49 * cosCache54 * cosCache10 +
                        coeffs50 * cosCache54 * cosCache18 +
                        coeffs51 * cosCache54 * cosCache26 +
                        coeffs52 * cosCache54 * cosCache34 +
                        coeffs53 * cosCache54 * cosCache42 +
                        coeffs54 * cosCache54 * cosCache50 +
                        coeffs55 * cosCache54 * cosCache58 +
                        coeffs56 * cosCache62 * cosCache2 * Alpha +
                        coeffs57 * cosCache62 * cosCache10 +
                        coeffs58 * cosCache62 * cosCache18 +
                        coeffs59 * cosCache62 * cosCache26 +
                        coeffs60 * cosCache62 * cosCache34 +
                        coeffs61 * cosCache62 * cosCache42 +
                        coeffs62 * cosCache62 * cosCache50 +
                        coeffs63 * cosCache62 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 3] = (coeffs0 * cosCache6 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache11 * Alpha +
                        coeffs2 * cosCache6 * cosCache19 * Alpha +
                        coeffs3 * cosCache6 * cosCache27 * Alpha +
                        coeffs4 * cosCache6 * cosCache35 * Alpha +
                        coeffs5 * cosCache6 * cosCache43 * Alpha +
                        coeffs6 * cosCache6 * cosCache51 * Alpha +
                        coeffs7 * cosCache6 * cosCache59 * Alpha +
                        coeffs8 * cosCache14 * cosCache3 * Alpha +
                        coeffs9 * cosCache14 * cosCache11 +
                        coeffs10 * cosCache14 * cosCache19 +
                        coeffs11 * cosCache14 * cosCache27 +
                        coeffs12 * cosCache14 * cosCache35 +
                        coeffs13 * cosCache14 * cosCache43 +
                        coeffs14 * cosCache14 * cosCache51 +
                        coeffs15 * cosCache14 * cosCache59 +
                        coeffs16 * cosCache22 * cosCache3 * Alpha +
                        coeffs17 * cosCache22 * cosCache11 +
                        coeffs18 * cosCache22 * cosCache19 +
                        coeffs19 * cosCache22 * cosCache27 +
                        coeffs20 * cosCache22 * cosCache35 +
                        coeffs21 * cosCache22 * cosCache43 +
                        coeffs22 * cosCache22 * cosCache51 +
                        coeffs23 * cosCache22 * cosCache59 +
                        coeffs24 * cosCache30 * cosCache3 * Alpha +
                        coeffs25 * cosCache30 * cosCache11 +
                        coeffs26 * cosCache30 * cosCache19 +
                        coeffs27 * cosCache30 * cosCache27 +
                        coeffs28 * cosCache30 * cosCache35 +
                        coeffs29 * cosCache30 * cosCache43 +
                        coeffs30 * cosCache30 * cosCache51 +
                        coeffs31 * cosCache30 * cosCache59 +
                        coeffs32 * cosCache38 * cosCache3 * Alpha +
                        coeffs33 * cosCache38 * cosCache11 +
                        coeffs34 * cosCache38 * cosCache19 +
                        coeffs35 * cosCache38 * cosCache27 +
                        coeffs36 * cosCache38 * cosCache35 +
                        coeffs37 * cosCache38 * cosCache43 +
                        coeffs38 * cosCache38 * cosCache51 +
                        coeffs39 * cosCache38 * cosCache59 +
                        coeffs40 * cosCache46 * cosCache3 * Alpha +
                        coeffs41 * cosCache46 * cosCache11 +
                        coeffs42 * cosCache46 * cosCache19 +
                        coeffs43 * cosCache46 * cosCache27 +
                        coeffs44 * cosCache46 * cosCache35 +
                        coeffs45 * cosCache46 * cosCache43 +
                        coeffs46 * cosCache46 * cosCache51 +
                        coeffs47 * cosCache46 * cosCache59 +
                        coeffs48 * cosCache54 * cosCache3 * Alpha +
                        coeffs49 * cosCache54 * cosCache11 +
                        coeffs50 * cosCache54 * cosCache19 +
                        coeffs51 * cosCache54 * cosCache27 +
                        coeffs52 * cosCache54 * cosCache35 +
                        coeffs53 * cosCache54 * cosCache43 +
                        coeffs54 * cosCache54 * cosCache51 +
                        coeffs55 * cosCache54 * cosCache59 +
                        coeffs56 * cosCache62 * cosCache3 * Alpha +
                        coeffs57 * cosCache62 * cosCache11 +
                        coeffs58 * cosCache62 * cosCache19 +
                        coeffs59 * cosCache62 * cosCache27 +
                        coeffs60 * cosCache62 * cosCache35 +
                        coeffs61 * cosCache62 * cosCache43 +
                        coeffs62 * cosCache62 * cosCache51 +
                        coeffs63 * cosCache62 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 4] = (coeffs0 * cosCache6 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache12 * Alpha +
                        coeffs2 * cosCache6 * cosCache20 * Alpha +
                        coeffs3 * cosCache6 * cosCache28 * Alpha +
                        coeffs4 * cosCache6 * cosCache36 * Alpha +
                        coeffs5 * cosCache6 * cosCache44 * Alpha +
                        coeffs6 * cosCache6 * cosCache52 * Alpha +
                        coeffs7 * cosCache6 * cosCache60 * Alpha +
                        coeffs8 * cosCache14 * cosCache4 * Alpha +
                        coeffs9 * cosCache14 * cosCache12 +
                        coeffs10 * cosCache14 * cosCache20 +
                        coeffs11 * cosCache14 * cosCache28 +
                        coeffs12 * cosCache14 * cosCache36 +
                        coeffs13 * cosCache14 * cosCache44 +
                        coeffs14 * cosCache14 * cosCache52 +
                        coeffs15 * cosCache14 * cosCache60 +
                        coeffs16 * cosCache22 * cosCache4 * Alpha +
                        coeffs17 * cosCache22 * cosCache12 +
                        coeffs18 * cosCache22 * cosCache20 +
                        coeffs19 * cosCache22 * cosCache28 +
                        coeffs20 * cosCache22 * cosCache36 +
                        coeffs21 * cosCache22 * cosCache44 +
                        coeffs22 * cosCache22 * cosCache52 +
                        coeffs23 * cosCache22 * cosCache60 +
                        coeffs24 * cosCache30 * cosCache4 * Alpha +
                        coeffs25 * cosCache30 * cosCache12 +
                        coeffs26 * cosCache30 * cosCache20 +
                        coeffs27 * cosCache30 * cosCache28 +
                        coeffs28 * cosCache30 * cosCache36 +
                        coeffs29 * cosCache30 * cosCache44 +
                        coeffs30 * cosCache30 * cosCache52 +
                        coeffs31 * cosCache30 * cosCache60 +
                        coeffs32 * cosCache38 * cosCache4 * Alpha +
                        coeffs33 * cosCache38 * cosCache12 +
                        coeffs34 * cosCache38 * cosCache20 +
                        coeffs35 * cosCache38 * cosCache28 +
                        coeffs36 * cosCache38 * cosCache36 +
                        coeffs37 * cosCache38 * cosCache44 +
                        coeffs38 * cosCache38 * cosCache52 +
                        coeffs39 * cosCache38 * cosCache60 +
                        coeffs40 * cosCache46 * cosCache4 * Alpha +
                        coeffs41 * cosCache46 * cosCache12 +
                        coeffs42 * cosCache46 * cosCache20 +
                        coeffs43 * cosCache46 * cosCache28 +
                        coeffs44 * cosCache46 * cosCache36 +
                        coeffs45 * cosCache46 * cosCache44 +
                        coeffs46 * cosCache46 * cosCache52 +
                        coeffs47 * cosCache46 * cosCache60 +
                        coeffs48 * cosCache54 * cosCache4 * Alpha +
                        coeffs49 * cosCache54 * cosCache12 +
                        coeffs50 * cosCache54 * cosCache20 +
                        coeffs51 * cosCache54 * cosCache28 +
                        coeffs52 * cosCache54 * cosCache36 +
                        coeffs53 * cosCache54 * cosCache44 +
                        coeffs54 * cosCache54 * cosCache52 +
                        coeffs55 * cosCache54 * cosCache60 +
                        coeffs56 * cosCache62 * cosCache4 * Alpha +
                        coeffs57 * cosCache62 * cosCache12 +
                        coeffs58 * cosCache62 * cosCache20 +
                        coeffs59 * cosCache62 * cosCache28 +
                        coeffs60 * cosCache62 * cosCache36 +
                        coeffs61 * cosCache62 * cosCache44 +
                        coeffs62 * cosCache62 * cosCache52 +
                        coeffs63 * cosCache62 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 5] = (coeffs0 * cosCache6 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache13 * Alpha +
                        coeffs2 * cosCache6 * cosCache21 * Alpha +
                        coeffs3 * cosCache6 * cosCache29 * Alpha +
                        coeffs4 * cosCache6 * cosCache37 * Alpha +
                        coeffs5 * cosCache6 * cosCache45 * Alpha +
                        coeffs6 * cosCache6 * cosCache53 * Alpha +
                        coeffs7 * cosCache6 * cosCache61 * Alpha +
                        coeffs8 * cosCache14 * cosCache5 * Alpha +
                        coeffs9 * cosCache14 * cosCache13 +
                        coeffs10 * cosCache14 * cosCache21 +
                        coeffs11 * cosCache14 * cosCache29 +
                        coeffs12 * cosCache14 * cosCache37 +
                        coeffs13 * cosCache14 * cosCache45 +
                        coeffs14 * cosCache14 * cosCache53 +
                        coeffs15 * cosCache14 * cosCache61 +
                        coeffs16 * cosCache22 * cosCache5 * Alpha +
                        coeffs17 * cosCache22 * cosCache13 +
                        coeffs18 * cosCache22 * cosCache21 +
                        coeffs19 * cosCache22 * cosCache29 +
                        coeffs20 * cosCache22 * cosCache37 +
                        coeffs21 * cosCache22 * cosCache45 +
                        coeffs22 * cosCache22 * cosCache53 +
                        coeffs23 * cosCache22 * cosCache61 +
                        coeffs24 * cosCache30 * cosCache5 * Alpha +
                        coeffs25 * cosCache30 * cosCache13 +
                        coeffs26 * cosCache30 * cosCache21 +
                        coeffs27 * cosCache30 * cosCache29 +
                        coeffs28 * cosCache30 * cosCache37 +
                        coeffs29 * cosCache30 * cosCache45 +
                        coeffs30 * cosCache30 * cosCache53 +
                        coeffs31 * cosCache30 * cosCache61 +
                        coeffs32 * cosCache38 * cosCache5 * Alpha +
                        coeffs33 * cosCache38 * cosCache13 +
                        coeffs34 * cosCache38 * cosCache21 +
                        coeffs35 * cosCache38 * cosCache29 +
                        coeffs36 * cosCache38 * cosCache37 +
                        coeffs37 * cosCache38 * cosCache45 +
                        coeffs38 * cosCache38 * cosCache53 +
                        coeffs39 * cosCache38 * cosCache61 +
                        coeffs40 * cosCache46 * cosCache5 * Alpha +
                        coeffs41 * cosCache46 * cosCache13 +
                        coeffs42 * cosCache46 * cosCache21 +
                        coeffs43 * cosCache46 * cosCache29 +
                        coeffs44 * cosCache46 * cosCache37 +
                        coeffs45 * cosCache46 * cosCache45 +
                        coeffs46 * cosCache46 * cosCache53 +
                        coeffs47 * cosCache46 * cosCache61 +
                        coeffs48 * cosCache54 * cosCache5 * Alpha +
                        coeffs49 * cosCache54 * cosCache13 +
                        coeffs50 * cosCache54 * cosCache21 +
                        coeffs51 * cosCache54 * cosCache29 +
                        coeffs52 * cosCache54 * cosCache37 +
                        coeffs53 * cosCache54 * cosCache45 +
                        coeffs54 * cosCache54 * cosCache53 +
                        coeffs55 * cosCache54 * cosCache61 +
                        coeffs56 * cosCache62 * cosCache5 * Alpha +
                        coeffs57 * cosCache62 * cosCache13 +
                        coeffs58 * cosCache62 * cosCache21 +
                        coeffs59 * cosCache62 * cosCache29 +
                        coeffs60 * cosCache62 * cosCache37 +
                        coeffs61 * cosCache62 * cosCache45 +
                        coeffs62 * cosCache62 * cosCache53 +
                        coeffs63 * cosCache62 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 6] = (coeffs0 * cosCache6 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache14 * Alpha +
                        coeffs2 * cosCache6 * cosCache22 * Alpha +
                        coeffs3 * cosCache6 * cosCache30 * Alpha +
                        coeffs4 * cosCache6 * cosCache38 * Alpha +
                        coeffs5 * cosCache6 * cosCache46 * Alpha +
                        coeffs6 * cosCache6 * cosCache54 * Alpha +
                        coeffs7 * cosCache6 * cosCache62 * Alpha +
                        coeffs8 * cosCache14 * cosCache6 * Alpha +
                        coeffs9 * cosCache14 * cosCache14 +
                        coeffs10 * cosCache14 * cosCache22 +
                        coeffs11 * cosCache14 * cosCache30 +
                        coeffs12 * cosCache14 * cosCache38 +
                        coeffs13 * cosCache14 * cosCache46 +
                        coeffs14 * cosCache14 * cosCache54 +
                        coeffs15 * cosCache14 * cosCache62 +
                        coeffs16 * cosCache22 * cosCache6 * Alpha +
                        coeffs17 * cosCache22 * cosCache14 +
                        coeffs18 * cosCache22 * cosCache22 +
                        coeffs19 * cosCache22 * cosCache30 +
                        coeffs20 * cosCache22 * cosCache38 +
                        coeffs21 * cosCache22 * cosCache46 +
                        coeffs22 * cosCache22 * cosCache54 +
                        coeffs23 * cosCache22 * cosCache62 +
                        coeffs24 * cosCache30 * cosCache6 * Alpha +
                        coeffs25 * cosCache30 * cosCache14 +
                        coeffs26 * cosCache30 * cosCache22 +
                        coeffs27 * cosCache30 * cosCache30 +
                        coeffs28 * cosCache30 * cosCache38 +
                        coeffs29 * cosCache30 * cosCache46 +
                        coeffs30 * cosCache30 * cosCache54 +
                        coeffs31 * cosCache30 * cosCache62 +
                        coeffs32 * cosCache38 * cosCache6 * Alpha +
                        coeffs33 * cosCache38 * cosCache14 +
                        coeffs34 * cosCache38 * cosCache22 +
                        coeffs35 * cosCache38 * cosCache30 +
                        coeffs36 * cosCache38 * cosCache38 +
                        coeffs37 * cosCache38 * cosCache46 +
                        coeffs38 * cosCache38 * cosCache54 +
                        coeffs39 * cosCache38 * cosCache62 +
                        coeffs40 * cosCache46 * cosCache6 * Alpha +
                        coeffs41 * cosCache46 * cosCache14 +
                        coeffs42 * cosCache46 * cosCache22 +
                        coeffs43 * cosCache46 * cosCache30 +
                        coeffs44 * cosCache46 * cosCache38 +
                        coeffs45 * cosCache46 * cosCache46 +
                        coeffs46 * cosCache46 * cosCache54 +
                        coeffs47 * cosCache46 * cosCache62 +
                        coeffs48 * cosCache54 * cosCache6 * Alpha +
                        coeffs49 * cosCache54 * cosCache14 +
                        coeffs50 * cosCache54 * cosCache22 +
                        coeffs51 * cosCache54 * cosCache30 +
                        coeffs52 * cosCache54 * cosCache38 +
                        coeffs53 * cosCache54 * cosCache46 +
                        coeffs54 * cosCache54 * cosCache54 +
                        coeffs55 * cosCache54 * cosCache62 +
                        coeffs56 * cosCache62 * cosCache6 * Alpha +
                        coeffs57 * cosCache62 * cosCache14 +
                        coeffs58 * cosCache62 * cosCache22 +
                        coeffs59 * cosCache62 * cosCache30 +
                        coeffs60 * cosCache62 * cosCache38 +
                        coeffs61 * cosCache62 * cosCache46 +
                        coeffs62 * cosCache62 * cosCache54 +
                        coeffs63 * cosCache62 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[6, 7] = (coeffs0 * cosCache6 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache6 * cosCache15 * Alpha +
                        coeffs2 * cosCache6 * cosCache23 * Alpha +
                        coeffs3 * cosCache6 * cosCache31 * Alpha +
                        coeffs4 * cosCache6 * cosCache39 * Alpha +
                        coeffs5 * cosCache6 * cosCache47 * Alpha +
                        coeffs6 * cosCache6 * cosCache55 * Alpha +
                        coeffs7 * cosCache6 * cosCache63 * Alpha +
                        coeffs8 * cosCache14 * cosCache7 * Alpha +
                        coeffs9 * cosCache14 * cosCache15 +
                        coeffs10 * cosCache14 * cosCache23 +
                        coeffs11 * cosCache14 * cosCache31 +
                        coeffs12 * cosCache14 * cosCache39 +
                        coeffs13 * cosCache14 * cosCache47 +
                        coeffs14 * cosCache14 * cosCache55 +
                        coeffs15 * cosCache14 * cosCache63 +
                        coeffs16 * cosCache22 * cosCache7 * Alpha +
                        coeffs17 * cosCache22 * cosCache15 +
                        coeffs18 * cosCache22 * cosCache23 +
                        coeffs19 * cosCache22 * cosCache31 +
                        coeffs20 * cosCache22 * cosCache39 +
                        coeffs21 * cosCache22 * cosCache47 +
                        coeffs22 * cosCache22 * cosCache55 +
                        coeffs23 * cosCache22 * cosCache63 +
                        coeffs24 * cosCache30 * cosCache7 * Alpha +
                        coeffs25 * cosCache30 * cosCache15 +
                        coeffs26 * cosCache30 * cosCache23 +
                        coeffs27 * cosCache30 * cosCache31 +
                        coeffs28 * cosCache30 * cosCache39 +
                        coeffs29 * cosCache30 * cosCache47 +
                        coeffs30 * cosCache30 * cosCache55 +
                        coeffs31 * cosCache30 * cosCache63 +
                        coeffs32 * cosCache38 * cosCache7 * Alpha +
                        coeffs33 * cosCache38 * cosCache15 +
                        coeffs34 * cosCache38 * cosCache23 +
                        coeffs35 * cosCache38 * cosCache31 +
                        coeffs36 * cosCache38 * cosCache39 +
                        coeffs37 * cosCache38 * cosCache47 +
                        coeffs38 * cosCache38 * cosCache55 +
                        coeffs39 * cosCache38 * cosCache63 +
                        coeffs40 * cosCache46 * cosCache7 * Alpha +
                        coeffs41 * cosCache46 * cosCache15 +
                        coeffs42 * cosCache46 * cosCache23 +
                        coeffs43 * cosCache46 * cosCache31 +
                        coeffs44 * cosCache46 * cosCache39 +
                        coeffs45 * cosCache46 * cosCache47 +
                        coeffs46 * cosCache46 * cosCache55 +
                        coeffs47 * cosCache46 * cosCache63 +
                        coeffs48 * cosCache54 * cosCache7 * Alpha +
                        coeffs49 * cosCache54 * cosCache15 +
                        coeffs50 * cosCache54 * cosCache23 +
                        coeffs51 * cosCache54 * cosCache31 +
                        coeffs52 * cosCache54 * cosCache39 +
                        coeffs53 * cosCache54 * cosCache47 +
                        coeffs54 * cosCache54 * cosCache55 +
                        coeffs55 * cosCache54 * cosCache63 +
                        coeffs56 * cosCache62 * cosCache7 * Alpha +
                        coeffs57 * cosCache62 * cosCache15 +
                        coeffs58 * cosCache62 * cosCache23 +
                        coeffs59 * cosCache62 * cosCache31 +
                        coeffs60 * cosCache62 * cosCache39 +
                        coeffs61 * cosCache62 * cosCache47 +
                        coeffs62 * cosCache62 * cosCache55 +
                        coeffs63 * cosCache62 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 0] = (coeffs0 * cosCache7 * cosCache0 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache8 * Alpha +
                        coeffs2 * cosCache7 * cosCache16 * Alpha +
                        coeffs3 * cosCache7 * cosCache24 * Alpha +
                        coeffs4 * cosCache7 * cosCache32 * Alpha +
                        coeffs5 * cosCache7 * cosCache40 * Alpha +
                        coeffs6 * cosCache7 * cosCache48 * Alpha +
                        coeffs7 * cosCache7 * cosCache56 * Alpha +
                        coeffs8 * cosCache15 * cosCache0 * Alpha +
                        coeffs9 * cosCache15 * cosCache8 +
                        coeffs10 * cosCache15 * cosCache16 +
                        coeffs11 * cosCache15 * cosCache24 +
                        coeffs12 * cosCache15 * cosCache32 +
                        coeffs13 * cosCache15 * cosCache40 +
                        coeffs14 * cosCache15 * cosCache48 +
                        coeffs15 * cosCache15 * cosCache56 +
                        coeffs16 * cosCache23 * cosCache0 * Alpha +
                        coeffs17 * cosCache23 * cosCache8 +
                        coeffs18 * cosCache23 * cosCache16 +
                        coeffs19 * cosCache23 * cosCache24 +
                        coeffs20 * cosCache23 * cosCache32 +
                        coeffs21 * cosCache23 * cosCache40 +
                        coeffs22 * cosCache23 * cosCache48 +
                        coeffs23 * cosCache23 * cosCache56 +
                        coeffs24 * cosCache31 * cosCache0 * Alpha +
                        coeffs25 * cosCache31 * cosCache8 +
                        coeffs26 * cosCache31 * cosCache16 +
                        coeffs27 * cosCache31 * cosCache24 +
                        coeffs28 * cosCache31 * cosCache32 +
                        coeffs29 * cosCache31 * cosCache40 +
                        coeffs30 * cosCache31 * cosCache48 +
                        coeffs31 * cosCache31 * cosCache56 +
                        coeffs32 * cosCache39 * cosCache0 * Alpha +
                        coeffs33 * cosCache39 * cosCache8 +
                        coeffs34 * cosCache39 * cosCache16 +
                        coeffs35 * cosCache39 * cosCache24 +
                        coeffs36 * cosCache39 * cosCache32 +
                        coeffs37 * cosCache39 * cosCache40 +
                        coeffs38 * cosCache39 * cosCache48 +
                        coeffs39 * cosCache39 * cosCache56 +
                        coeffs40 * cosCache47 * cosCache0 * Alpha +
                        coeffs41 * cosCache47 * cosCache8 +
                        coeffs42 * cosCache47 * cosCache16 +
                        coeffs43 * cosCache47 * cosCache24 +
                        coeffs44 * cosCache47 * cosCache32 +
                        coeffs45 * cosCache47 * cosCache40 +
                        coeffs46 * cosCache47 * cosCache48 +
                        coeffs47 * cosCache47 * cosCache56 +
                        coeffs48 * cosCache55 * cosCache0 * Alpha +
                        coeffs49 * cosCache55 * cosCache8 +
                        coeffs50 * cosCache55 * cosCache16 +
                        coeffs51 * cosCache55 * cosCache24 +
                        coeffs52 * cosCache55 * cosCache32 +
                        coeffs53 * cosCache55 * cosCache40 +
                        coeffs54 * cosCache55 * cosCache48 +
                        coeffs55 * cosCache55 * cosCache56 +
                        coeffs56 * cosCache63 * cosCache0 * Alpha +
                        coeffs57 * cosCache63 * cosCache8 +
                        coeffs58 * cosCache63 * cosCache16 +
                        coeffs59 * cosCache63 * cosCache24 +
                        coeffs60 * cosCache63 * cosCache32 +
                        coeffs61 * cosCache63 * cosCache40 +
                        coeffs62 * cosCache63 * cosCache48 +
                        coeffs63 * cosCache63 * cosCache56) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 1] = (coeffs0 * cosCache7 * cosCache1 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache9 * Alpha +
                        coeffs2 * cosCache7 * cosCache17 * Alpha +
                        coeffs3 * cosCache7 * cosCache25 * Alpha +
                        coeffs4 * cosCache7 * cosCache33 * Alpha +
                        coeffs5 * cosCache7 * cosCache41 * Alpha +
                        coeffs6 * cosCache7 * cosCache49 * Alpha +
                        coeffs7 * cosCache7 * cosCache57 * Alpha +
                        coeffs8 * cosCache15 * cosCache1 * Alpha +
                        coeffs9 * cosCache15 * cosCache9 +
                        coeffs10 * cosCache15 * cosCache17 +
                        coeffs11 * cosCache15 * cosCache25 +
                        coeffs12 * cosCache15 * cosCache33 +
                        coeffs13 * cosCache15 * cosCache41 +
                        coeffs14 * cosCache15 * cosCache49 +
                        coeffs15 * cosCache15 * cosCache57 +
                        coeffs16 * cosCache23 * cosCache1 * Alpha +
                        coeffs17 * cosCache23 * cosCache9 +
                        coeffs18 * cosCache23 * cosCache17 +
                        coeffs19 * cosCache23 * cosCache25 +
                        coeffs20 * cosCache23 * cosCache33 +
                        coeffs21 * cosCache23 * cosCache41 +
                        coeffs22 * cosCache23 * cosCache49 +
                        coeffs23 * cosCache23 * cosCache57 +
                        coeffs24 * cosCache31 * cosCache1 * Alpha +
                        coeffs25 * cosCache31 * cosCache9 +
                        coeffs26 * cosCache31 * cosCache17 +
                        coeffs27 * cosCache31 * cosCache25 +
                        coeffs28 * cosCache31 * cosCache33 +
                        coeffs29 * cosCache31 * cosCache41 +
                        coeffs30 * cosCache31 * cosCache49 +
                        coeffs31 * cosCache31 * cosCache57 +
                        coeffs32 * cosCache39 * cosCache1 * Alpha +
                        coeffs33 * cosCache39 * cosCache9 +
                        coeffs34 * cosCache39 * cosCache17 +
                        coeffs35 * cosCache39 * cosCache25 +
                        coeffs36 * cosCache39 * cosCache33 +
                        coeffs37 * cosCache39 * cosCache41 +
                        coeffs38 * cosCache39 * cosCache49 +
                        coeffs39 * cosCache39 * cosCache57 +
                        coeffs40 * cosCache47 * cosCache1 * Alpha +
                        coeffs41 * cosCache47 * cosCache9 +
                        coeffs42 * cosCache47 * cosCache17 +
                        coeffs43 * cosCache47 * cosCache25 +
                        coeffs44 * cosCache47 * cosCache33 +
                        coeffs45 * cosCache47 * cosCache41 +
                        coeffs46 * cosCache47 * cosCache49 +
                        coeffs47 * cosCache47 * cosCache57 +
                        coeffs48 * cosCache55 * cosCache1 * Alpha +
                        coeffs49 * cosCache55 * cosCache9 +
                        coeffs50 * cosCache55 * cosCache17 +
                        coeffs51 * cosCache55 * cosCache25 +
                        coeffs52 * cosCache55 * cosCache33 +
                        coeffs53 * cosCache55 * cosCache41 +
                        coeffs54 * cosCache55 * cosCache49 +
                        coeffs55 * cosCache55 * cosCache57 +
                        coeffs56 * cosCache63 * cosCache1 * Alpha +
                        coeffs57 * cosCache63 * cosCache9 +
                        coeffs58 * cosCache63 * cosCache17 +
                        coeffs59 * cosCache63 * cosCache25 +
                        coeffs60 * cosCache63 * cosCache33 +
                        coeffs61 * cosCache63 * cosCache41 +
                        coeffs62 * cosCache63 * cosCache49 +
                        coeffs63 * cosCache63 * cosCache57) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 2] = (coeffs0 * cosCache7 * cosCache2 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache10 * Alpha +
                        coeffs2 * cosCache7 * cosCache18 * Alpha +
                        coeffs3 * cosCache7 * cosCache26 * Alpha +
                        coeffs4 * cosCache7 * cosCache34 * Alpha +
                        coeffs5 * cosCache7 * cosCache42 * Alpha +
                        coeffs6 * cosCache7 * cosCache50 * Alpha +
                        coeffs7 * cosCache7 * cosCache58 * Alpha +
                        coeffs8 * cosCache15 * cosCache2 * Alpha +
                        coeffs9 * cosCache15 * cosCache10 +
                        coeffs10 * cosCache15 * cosCache18 +
                        coeffs11 * cosCache15 * cosCache26 +
                        coeffs12 * cosCache15 * cosCache34 +
                        coeffs13 * cosCache15 * cosCache42 +
                        coeffs14 * cosCache15 * cosCache50 +
                        coeffs15 * cosCache15 * cosCache58 +
                        coeffs16 * cosCache23 * cosCache2 * Alpha +
                        coeffs17 * cosCache23 * cosCache10 +
                        coeffs18 * cosCache23 * cosCache18 +
                        coeffs19 * cosCache23 * cosCache26 +
                        coeffs20 * cosCache23 * cosCache34 +
                        coeffs21 * cosCache23 * cosCache42 +
                        coeffs22 * cosCache23 * cosCache50 +
                        coeffs23 * cosCache23 * cosCache58 +
                        coeffs24 * cosCache31 * cosCache2 * Alpha +
                        coeffs25 * cosCache31 * cosCache10 +
                        coeffs26 * cosCache31 * cosCache18 +
                        coeffs27 * cosCache31 * cosCache26 +
                        coeffs28 * cosCache31 * cosCache34 +
                        coeffs29 * cosCache31 * cosCache42 +
                        coeffs30 * cosCache31 * cosCache50 +
                        coeffs31 * cosCache31 * cosCache58 +
                        coeffs32 * cosCache39 * cosCache2 * Alpha +
                        coeffs33 * cosCache39 * cosCache10 +
                        coeffs34 * cosCache39 * cosCache18 +
                        coeffs35 * cosCache39 * cosCache26 +
                        coeffs36 * cosCache39 * cosCache34 +
                        coeffs37 * cosCache39 * cosCache42 +
                        coeffs38 * cosCache39 * cosCache50 +
                        coeffs39 * cosCache39 * cosCache58 +
                        coeffs40 * cosCache47 * cosCache2 * Alpha +
                        coeffs41 * cosCache47 * cosCache10 +
                        coeffs42 * cosCache47 * cosCache18 +
                        coeffs43 * cosCache47 * cosCache26 +
                        coeffs44 * cosCache47 * cosCache34 +
                        coeffs45 * cosCache47 * cosCache42 +
                        coeffs46 * cosCache47 * cosCache50 +
                        coeffs47 * cosCache47 * cosCache58 +
                        coeffs48 * cosCache55 * cosCache2 * Alpha +
                        coeffs49 * cosCache55 * cosCache10 +
                        coeffs50 * cosCache55 * cosCache18 +
                        coeffs51 * cosCache55 * cosCache26 +
                        coeffs52 * cosCache55 * cosCache34 +
                        coeffs53 * cosCache55 * cosCache42 +
                        coeffs54 * cosCache55 * cosCache50 +
                        coeffs55 * cosCache55 * cosCache58 +
                        coeffs56 * cosCache63 * cosCache2 * Alpha +
                        coeffs57 * cosCache63 * cosCache10 +
                        coeffs58 * cosCache63 * cosCache18 +
                        coeffs59 * cosCache63 * cosCache26 +
                        coeffs60 * cosCache63 * cosCache34 +
                        coeffs61 * cosCache63 * cosCache42 +
                        coeffs62 * cosCache63 * cosCache50 +
                        coeffs63 * cosCache63 * cosCache58) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 3] = (coeffs0 * cosCache7 * cosCache3 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache11 * Alpha +
                        coeffs2 * cosCache7 * cosCache19 * Alpha +
                        coeffs3 * cosCache7 * cosCache27 * Alpha +
                        coeffs4 * cosCache7 * cosCache35 * Alpha +
                        coeffs5 * cosCache7 * cosCache43 * Alpha +
                        coeffs6 * cosCache7 * cosCache51 * Alpha +
                        coeffs7 * cosCache7 * cosCache59 * Alpha +
                        coeffs8 * cosCache15 * cosCache3 * Alpha +
                        coeffs9 * cosCache15 * cosCache11 +
                        coeffs10 * cosCache15 * cosCache19 +
                        coeffs11 * cosCache15 * cosCache27 +
                        coeffs12 * cosCache15 * cosCache35 +
                        coeffs13 * cosCache15 * cosCache43 +
                        coeffs14 * cosCache15 * cosCache51 +
                        coeffs15 * cosCache15 * cosCache59 +
                        coeffs16 * cosCache23 * cosCache3 * Alpha +
                        coeffs17 * cosCache23 * cosCache11 +
                        coeffs18 * cosCache23 * cosCache19 +
                        coeffs19 * cosCache23 * cosCache27 +
                        coeffs20 * cosCache23 * cosCache35 +
                        coeffs21 * cosCache23 * cosCache43 +
                        coeffs22 * cosCache23 * cosCache51 +
                        coeffs23 * cosCache23 * cosCache59 +
                        coeffs24 * cosCache31 * cosCache3 * Alpha +
                        coeffs25 * cosCache31 * cosCache11 +
                        coeffs26 * cosCache31 * cosCache19 +
                        coeffs27 * cosCache31 * cosCache27 +
                        coeffs28 * cosCache31 * cosCache35 +
                        coeffs29 * cosCache31 * cosCache43 +
                        coeffs30 * cosCache31 * cosCache51 +
                        coeffs31 * cosCache31 * cosCache59 +
                        coeffs32 * cosCache39 * cosCache3 * Alpha +
                        coeffs33 * cosCache39 * cosCache11 +
                        coeffs34 * cosCache39 * cosCache19 +
                        coeffs35 * cosCache39 * cosCache27 +
                        coeffs36 * cosCache39 * cosCache35 +
                        coeffs37 * cosCache39 * cosCache43 +
                        coeffs38 * cosCache39 * cosCache51 +
                        coeffs39 * cosCache39 * cosCache59 +
                        coeffs40 * cosCache47 * cosCache3 * Alpha +
                        coeffs41 * cosCache47 * cosCache11 +
                        coeffs42 * cosCache47 * cosCache19 +
                        coeffs43 * cosCache47 * cosCache27 +
                        coeffs44 * cosCache47 * cosCache35 +
                        coeffs45 * cosCache47 * cosCache43 +
                        coeffs46 * cosCache47 * cosCache51 +
                        coeffs47 * cosCache47 * cosCache59 +
                        coeffs48 * cosCache55 * cosCache3 * Alpha +
                        coeffs49 * cosCache55 * cosCache11 +
                        coeffs50 * cosCache55 * cosCache19 +
                        coeffs51 * cosCache55 * cosCache27 +
                        coeffs52 * cosCache55 * cosCache35 +
                        coeffs53 * cosCache55 * cosCache43 +
                        coeffs54 * cosCache55 * cosCache51 +
                        coeffs55 * cosCache55 * cosCache59 +
                        coeffs56 * cosCache63 * cosCache3 * Alpha +
                        coeffs57 * cosCache63 * cosCache11 +
                        coeffs58 * cosCache63 * cosCache19 +
                        coeffs59 * cosCache63 * cosCache27 +
                        coeffs60 * cosCache63 * cosCache35 +
                        coeffs61 * cosCache63 * cosCache43 +
                        coeffs62 * cosCache63 * cosCache51 +
                        coeffs63 * cosCache63 * cosCache59) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 4] = (coeffs0 * cosCache7 * cosCache4 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache12 * Alpha +
                        coeffs2 * cosCache7 * cosCache20 * Alpha +
                        coeffs3 * cosCache7 * cosCache28 * Alpha +
                        coeffs4 * cosCache7 * cosCache36 * Alpha +
                        coeffs5 * cosCache7 * cosCache44 * Alpha +
                        coeffs6 * cosCache7 * cosCache52 * Alpha +
                        coeffs7 * cosCache7 * cosCache60 * Alpha +
                        coeffs8 * cosCache15 * cosCache4 * Alpha +
                        coeffs9 * cosCache15 * cosCache12 +
                        coeffs10 * cosCache15 * cosCache20 +
                        coeffs11 * cosCache15 * cosCache28 +
                        coeffs12 * cosCache15 * cosCache36 +
                        coeffs13 * cosCache15 * cosCache44 +
                        coeffs14 * cosCache15 * cosCache52 +
                        coeffs15 * cosCache15 * cosCache60 +
                        coeffs16 * cosCache23 * cosCache4 * Alpha +
                        coeffs17 * cosCache23 * cosCache12 +
                        coeffs18 * cosCache23 * cosCache20 +
                        coeffs19 * cosCache23 * cosCache28 +
                        coeffs20 * cosCache23 * cosCache36 +
                        coeffs21 * cosCache23 * cosCache44 +
                        coeffs22 * cosCache23 * cosCache52 +
                        coeffs23 * cosCache23 * cosCache60 +
                        coeffs24 * cosCache31 * cosCache4 * Alpha +
                        coeffs25 * cosCache31 * cosCache12 +
                        coeffs26 * cosCache31 * cosCache20 +
                        coeffs27 * cosCache31 * cosCache28 +
                        coeffs28 * cosCache31 * cosCache36 +
                        coeffs29 * cosCache31 * cosCache44 +
                        coeffs30 * cosCache31 * cosCache52 +
                        coeffs31 * cosCache31 * cosCache60 +
                        coeffs32 * cosCache39 * cosCache4 * Alpha +
                        coeffs33 * cosCache39 * cosCache12 +
                        coeffs34 * cosCache39 * cosCache20 +
                        coeffs35 * cosCache39 * cosCache28 +
                        coeffs36 * cosCache39 * cosCache36 +
                        coeffs37 * cosCache39 * cosCache44 +
                        coeffs38 * cosCache39 * cosCache52 +
                        coeffs39 * cosCache39 * cosCache60 +
                        coeffs40 * cosCache47 * cosCache4 * Alpha +
                        coeffs41 * cosCache47 * cosCache12 +
                        coeffs42 * cosCache47 * cosCache20 +
                        coeffs43 * cosCache47 * cosCache28 +
                        coeffs44 * cosCache47 * cosCache36 +
                        coeffs45 * cosCache47 * cosCache44 +
                        coeffs46 * cosCache47 * cosCache52 +
                        coeffs47 * cosCache47 * cosCache60 +
                        coeffs48 * cosCache55 * cosCache4 * Alpha +
                        coeffs49 * cosCache55 * cosCache12 +
                        coeffs50 * cosCache55 * cosCache20 +
                        coeffs51 * cosCache55 * cosCache28 +
                        coeffs52 * cosCache55 * cosCache36 +
                        coeffs53 * cosCache55 * cosCache44 +
                        coeffs54 * cosCache55 * cosCache52 +
                        coeffs55 * cosCache55 * cosCache60 +
                        coeffs56 * cosCache63 * cosCache4 * Alpha +
                        coeffs57 * cosCache63 * cosCache12 +
                        coeffs58 * cosCache63 * cosCache20 +
                        coeffs59 * cosCache63 * cosCache28 +
                        coeffs60 * cosCache63 * cosCache36 +
                        coeffs61 * cosCache63 * cosCache44 +
                        coeffs62 * cosCache63 * cosCache52 +
                        coeffs63 * cosCache63 * cosCache60) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 5] = (coeffs0 * cosCache7 * cosCache5 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache13 * Alpha +
                        coeffs2 * cosCache7 * cosCache21 * Alpha +
                        coeffs3 * cosCache7 * cosCache29 * Alpha +
                        coeffs4 * cosCache7 * cosCache37 * Alpha +
                        coeffs5 * cosCache7 * cosCache45 * Alpha +
                        coeffs6 * cosCache7 * cosCache53 * Alpha +
                        coeffs7 * cosCache7 * cosCache61 * Alpha +
                        coeffs8 * cosCache15 * cosCache5 * Alpha +
                        coeffs9 * cosCache15 * cosCache13 +
                        coeffs10 * cosCache15 * cosCache21 +
                        coeffs11 * cosCache15 * cosCache29 +
                        coeffs12 * cosCache15 * cosCache37 +
                        coeffs13 * cosCache15 * cosCache45 +
                        coeffs14 * cosCache15 * cosCache53 +
                        coeffs15 * cosCache15 * cosCache61 +
                        coeffs16 * cosCache23 * cosCache5 * Alpha +
                        coeffs17 * cosCache23 * cosCache13 +
                        coeffs18 * cosCache23 * cosCache21 +
                        coeffs19 * cosCache23 * cosCache29 +
                        coeffs20 * cosCache23 * cosCache37 +
                        coeffs21 * cosCache23 * cosCache45 +
                        coeffs22 * cosCache23 * cosCache53 +
                        coeffs23 * cosCache23 * cosCache61 +
                        coeffs24 * cosCache31 * cosCache5 * Alpha +
                        coeffs25 * cosCache31 * cosCache13 +
                        coeffs26 * cosCache31 * cosCache21 +
                        coeffs27 * cosCache31 * cosCache29 +
                        coeffs28 * cosCache31 * cosCache37 +
                        coeffs29 * cosCache31 * cosCache45 +
                        coeffs30 * cosCache31 * cosCache53 +
                        coeffs31 * cosCache31 * cosCache61 +
                        coeffs32 * cosCache39 * cosCache5 * Alpha +
                        coeffs33 * cosCache39 * cosCache13 +
                        coeffs34 * cosCache39 * cosCache21 +
                        coeffs35 * cosCache39 * cosCache29 +
                        coeffs36 * cosCache39 * cosCache37 +
                        coeffs37 * cosCache39 * cosCache45 +
                        coeffs38 * cosCache39 * cosCache53 +
                        coeffs39 * cosCache39 * cosCache61 +
                        coeffs40 * cosCache47 * cosCache5 * Alpha +
                        coeffs41 * cosCache47 * cosCache13 +
                        coeffs42 * cosCache47 * cosCache21 +
                        coeffs43 * cosCache47 * cosCache29 +
                        coeffs44 * cosCache47 * cosCache37 +
                        coeffs45 * cosCache47 * cosCache45 +
                        coeffs46 * cosCache47 * cosCache53 +
                        coeffs47 * cosCache47 * cosCache61 +
                        coeffs48 * cosCache55 * cosCache5 * Alpha +
                        coeffs49 * cosCache55 * cosCache13 +
                        coeffs50 * cosCache55 * cosCache21 +
                        coeffs51 * cosCache55 * cosCache29 +
                        coeffs52 * cosCache55 * cosCache37 +
                        coeffs53 * cosCache55 * cosCache45 +
                        coeffs54 * cosCache55 * cosCache53 +
                        coeffs55 * cosCache55 * cosCache61 +
                        coeffs56 * cosCache63 * cosCache5 * Alpha +
                        coeffs57 * cosCache63 * cosCache13 +
                        coeffs58 * cosCache63 * cosCache21 +
                        coeffs59 * cosCache63 * cosCache29 +
                        coeffs60 * cosCache63 * cosCache37 +
                        coeffs61 * cosCache63 * cosCache45 +
                        coeffs62 * cosCache63 * cosCache53 +
                        coeffs63 * cosCache63 * cosCache61) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 6] = (coeffs0 * cosCache7 * cosCache6 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache14 * Alpha +
                        coeffs2 * cosCache7 * cosCache22 * Alpha +
                        coeffs3 * cosCache7 * cosCache30 * Alpha +
                        coeffs4 * cosCache7 * cosCache38 * Alpha +
                        coeffs5 * cosCache7 * cosCache46 * Alpha +
                        coeffs6 * cosCache7 * cosCache54 * Alpha +
                        coeffs7 * cosCache7 * cosCache62 * Alpha +
                        coeffs8 * cosCache15 * cosCache6 * Alpha +
                        coeffs9 * cosCache15 * cosCache14 +
                        coeffs10 * cosCache15 * cosCache22 +
                        coeffs11 * cosCache15 * cosCache30 +
                        coeffs12 * cosCache15 * cosCache38 +
                        coeffs13 * cosCache15 * cosCache46 +
                        coeffs14 * cosCache15 * cosCache54 +
                        coeffs15 * cosCache15 * cosCache62 +
                        coeffs16 * cosCache23 * cosCache6 * Alpha +
                        coeffs17 * cosCache23 * cosCache14 +
                        coeffs18 * cosCache23 * cosCache22 +
                        coeffs19 * cosCache23 * cosCache30 +
                        coeffs20 * cosCache23 * cosCache38 +
                        coeffs21 * cosCache23 * cosCache46 +
                        coeffs22 * cosCache23 * cosCache54 +
                        coeffs23 * cosCache23 * cosCache62 +
                        coeffs24 * cosCache31 * cosCache6 * Alpha +
                        coeffs25 * cosCache31 * cosCache14 +
                        coeffs26 * cosCache31 * cosCache22 +
                        coeffs27 * cosCache31 * cosCache30 +
                        coeffs28 * cosCache31 * cosCache38 +
                        coeffs29 * cosCache31 * cosCache46 +
                        coeffs30 * cosCache31 * cosCache54 +
                        coeffs31 * cosCache31 * cosCache62 +
                        coeffs32 * cosCache39 * cosCache6 * Alpha +
                        coeffs33 * cosCache39 * cosCache14 +
                        coeffs34 * cosCache39 * cosCache22 +
                        coeffs35 * cosCache39 * cosCache30 +
                        coeffs36 * cosCache39 * cosCache38 +
                        coeffs37 * cosCache39 * cosCache46 +
                        coeffs38 * cosCache39 * cosCache54 +
                        coeffs39 * cosCache39 * cosCache62 +
                        coeffs40 * cosCache47 * cosCache6 * Alpha +
                        coeffs41 * cosCache47 * cosCache14 +
                        coeffs42 * cosCache47 * cosCache22 +
                        coeffs43 * cosCache47 * cosCache30 +
                        coeffs44 * cosCache47 * cosCache38 +
                        coeffs45 * cosCache47 * cosCache46 +
                        coeffs46 * cosCache47 * cosCache54 +
                        coeffs47 * cosCache47 * cosCache62 +
                        coeffs48 * cosCache55 * cosCache6 * Alpha +
                        coeffs49 * cosCache55 * cosCache14 +
                        coeffs50 * cosCache55 * cosCache22 +
                        coeffs51 * cosCache55 * cosCache30 +
                        coeffs52 * cosCache55 * cosCache38 +
                        coeffs53 * cosCache55 * cosCache46 +
                        coeffs54 * cosCache55 * cosCache54 +
                        coeffs55 * cosCache55 * cosCache62 +
                        coeffs56 * cosCache63 * cosCache6 * Alpha +
                        coeffs57 * cosCache63 * cosCache14 +
                        coeffs58 * cosCache63 * cosCache22 +
                        coeffs59 * cosCache63 * cosCache30 +
                        coeffs60 * cosCache63 * cosCache38 +
                        coeffs61 * cosCache63 * cosCache46 +
                        coeffs62 * cosCache63 * cosCache54 +
                        coeffs63 * cosCache63 * cosCache62) * Beta + JpegProcessor.DctSizeDoubleSquare;
        output[7, 7] = (coeffs0 * cosCache7 * cosCache7 * Alpha * Alpha +
                        coeffs1 * cosCache7 * cosCache15 * Alpha +
                        coeffs2 * cosCache7 * cosCache23 * Alpha +
                        coeffs3 * cosCache7 * cosCache31 * Alpha +
                        coeffs4 * cosCache7 * cosCache39 * Alpha +
                        coeffs5 * cosCache7 * cosCache47 * Alpha +
                        coeffs6 * cosCache7 * cosCache55 * Alpha +
                        coeffs7 * cosCache7 * cosCache63 * Alpha +
                        coeffs8 * cosCache15 * cosCache7 * Alpha +
                        coeffs9 * cosCache15 * cosCache15 +
                        coeffs10 * cosCache15 * cosCache23 +
                        coeffs11 * cosCache15 * cosCache31 +
                        coeffs12 * cosCache15 * cosCache39 +
                        coeffs13 * cosCache15 * cosCache47 +
                        coeffs14 * cosCache15 * cosCache55 +
                        coeffs15 * cosCache15 * cosCache63 +
                        coeffs16 * cosCache23 * cosCache7 * Alpha +
                        coeffs17 * cosCache23 * cosCache15 +
                        coeffs18 * cosCache23 * cosCache23 +
                        coeffs19 * cosCache23 * cosCache31 +
                        coeffs20 * cosCache23 * cosCache39 +
                        coeffs21 * cosCache23 * cosCache47 +
                        coeffs22 * cosCache23 * cosCache55 +
                        coeffs23 * cosCache23 * cosCache63 +
                        coeffs24 * cosCache31 * cosCache7 * Alpha +
                        coeffs25 * cosCache31 * cosCache15 +
                        coeffs26 * cosCache31 * cosCache23 +
                        coeffs27 * cosCache31 * cosCache31 +
                        coeffs28 * cosCache31 * cosCache39 +
                        coeffs29 * cosCache31 * cosCache47 +
                        coeffs30 * cosCache31 * cosCache55 +
                        coeffs31 * cosCache31 * cosCache63 +
                        coeffs32 * cosCache39 * cosCache7 * Alpha +
                        coeffs33 * cosCache39 * cosCache15 +
                        coeffs34 * cosCache39 * cosCache23 +
                        coeffs35 * cosCache39 * cosCache31 +
                        coeffs36 * cosCache39 * cosCache39 +
                        coeffs37 * cosCache39 * cosCache47 +
                        coeffs38 * cosCache39 * cosCache55 +
                        coeffs39 * cosCache39 * cosCache63 +
                        coeffs40 * cosCache47 * cosCache7 * Alpha +
                        coeffs41 * cosCache47 * cosCache15 +
                        coeffs42 * cosCache47 * cosCache23 +
                        coeffs43 * cosCache47 * cosCache31 +
                        coeffs44 * cosCache47 * cosCache39 +
                        coeffs45 * cosCache47 * cosCache47 +
                        coeffs46 * cosCache47 * cosCache55 +
                        coeffs47 * cosCache47 * cosCache63 +
                        coeffs48 * cosCache55 * cosCache7 * Alpha +
                        coeffs49 * cosCache55 * cosCache15 +
                        coeffs50 * cosCache55 * cosCache23 +
                        coeffs51 * cosCache55 * cosCache31 +
                        coeffs52 * cosCache55 * cosCache39 +
                        coeffs53 * cosCache55 * cosCache47 +
                        coeffs54 * cosCache55 * cosCache55 +
                        coeffs55 * cosCache55 * cosCache63 +
                        coeffs56 * cosCache63 * cosCache7 * Alpha +
                        coeffs57 * cosCache63 * cosCache15 +
                        coeffs58 * cosCache63 * cosCache23 +
                        coeffs59 * cosCache63 * cosCache31 +
                        coeffs60 * cosCache63 * cosCache39 +
                        coeffs61 * cosCache63 * cosCache47 +
                        coeffs62 * cosCache63 * cosCache55 +
                        coeffs63 * cosCache63 * cosCache63) * Beta + JpegProcessor.DctSizeDoubleSquare;
    }
}
namespace JPEG.Benchmarks.Benchmarks.DSTBenchmarks;

public class FullyUnrolledDST2D
{
    private const float Alpha = 0.70710678118654746f;
    private const float Beta = 0.25f;
    private const float cosCache8 = 0.98078528040323043f;
    private const float cosCache9 = 0.83146961230254524f;
    private const float cosCache10 = 0.55557023301960229f;
    private const float cosCache11 = 0.19509032201612833f;
    private const float cosCache12 = -0.19509032201612819f;
    private const float cosCache13 = -0.55557023301960196f;
    private const float cosCache14 = -0.83146961230254535f;
    private const float cosCache15 = -0.98078528040323043f;
    private const float cosCache16 = 0.92387953251128674f;
    private const float cosCache17 = 0.38268343236508984f;
    private const float cosCache18 = -0.38268343236508973f;
    private const float cosCache19 = -0.92387953251128674f;
    private const float cosCache20 = -0.92387953251128685f;
    private const float cosCache21 = -0.38268343236509034f;
    private const float cosCache22 = 0.38268343236509f;
    private const float cosCache23 = 0.92387953251128652f;
    private const float cosCache24 = 0.83146961230254524f;
    private const float cosCache25 = -0.19509032201612819f;
    private const float cosCache26 = -0.98078528040323043f;
    private const float cosCache27 = -0.55557023301960218f;
    private const float cosCache28 = 0.55557023301960184f;
    private const float cosCache29 = 0.98078528040323043f;
    private const float cosCache30 = 0.19509032201612878f;
    private const float cosCache31 = -0.83146961230254512f;
    private const float cosCache32 = 0.70710678118654757f;
    private const float cosCache33 = -0.70710678118654746f;
    private const float cosCache34 = -0.70710678118654768f;
    private const float cosCache35 = 0.70710678118654735f;
    private const float cosCache36 = 0.70710678118654768f;
    private const float cosCache37 = -0.70710678118654668f;
    private const float cosCache38 = -0.70710678118654713f;
    private const float cosCache39 = 0.70710678118654657f;
    private const float cosCache40 = 0.55557023301960229f;
    private const float cosCache41 = -0.98078528040323043f;
    private const float cosCache42 = 0.1950903220161283f;
    private const float cosCache43 = 0.83146961230254557f;
    private const float cosCache44 = -0.83146961230254512f;
    private const float cosCache45 = -0.19509032201612803f;
    private const float cosCache46 = 0.98078528040323065f;
    private const float cosCache47 = -0.55557023301960151f;
    private const float cosCache48 = 0.38268343236508984f;
    private const float cosCache49 = -0.92387953251128685f;
    private const float cosCache50 = 0.92387953251128652f;
    private const float cosCache51 = -0.38268343236508989f;
    private const float cosCache52 = -0.38268343236509056f;
    private const float cosCache53 = 0.92387953251128674f;
    private const float cosCache54 = -0.92387953251128641f;
    private const float cosCache55 = 0.38268343236508956f;
    private const float cosCache56 = 0.19509032201612833f;
    private const float cosCache57 = -0.55557023301960218f;
    private const float cosCache58 = 0.83146961230254557f;
    private const float cosCache59 = -0.98078528040323065f;
    private const float cosCache60 = 0.98078528040323054f;
    private const float cosCache61 = -0.83146961230254501f;
    private const float cosCache62 = 0.55557023301960151f;
    private const float cosCache63 = -0.19509032201612858f;

    public static void DCT2D(Span<double> input, Span<double> result)
    {
        var input0 = input[0];
        var input1 = input[1];
        var input2 = input[2];
        var input3 = input[3];
        var input4 = input[4];
        var input5 = input[5];
        var input6 = input[6];
        var input7 = input[7];
        var input8 = input[8];
        var input9 = input[9];
        var input10 = input[10];
        var input11 = input[11];
        var input12 = input[12];
        var input13 = input[13];
        var input14 = input[14];
        var input15 = input[15];
        var input16 = input[16];
        var input17 = input[17];
        var input18 = input[18];
        var input19 = input[19];
        var input20 = input[20];
        var input21 = input[21];
        var input22 = input[22];
        var input23 = input[23];
        var input24 = input[24];
        var input25 = input[25];
        var input26 = input[26];
        var input27 = input[27];
        var input28 = input[28];
        var input29 = input[29];
        var input30 = input[30];
        var input31 = input[31];
        var input32 = input[32];
        var input33 = input[33];
        var input34 = input[34];
        var input35 = input[35];
        var input36 = input[36];
        var input37 = input[37];
        var input38 = input[38];
        var input39 = input[39];
        var input40 = input[40];
        var input41 = input[41];
        var input42 = input[42];
        var input43 = input[43];
        var input44 = input[44];
        var input45 = input[45];
        var input46 = input[46];
        var input47 = input[47];
        var input48 = input[48];
        var input49 = input[49];
        var input50 = input[50];
        var input51 = input[51];
        var input52 = input[52];
        var input53 = input[53];
        var input54 = input[54];
        var input55 = input[55];
        var input56 = input[56];
        var input57 = input[57];
        var input58 = input[58];
        var input59 = input[59];
        var input60 = input[60];
        var input61 = input[61];
        var input62 = input[62];
        var input63 = input[63];
        result[0] = (input0 + input1 + input2 + input3 + input4 + input5 + input6 + input7 + input8 + input9 +
                     input10 + input11 + input12 + input13 + input14 + input15 + input16 + input17 + input18 +
                     input19 + input20 + input21 + input22 + input23 + input24 + input25 + input26 + input27 +
                     input28 + input29 + input30 + input31 + input32 + input33 + input34 + input35 + input36 +
                     input37 + input38 + input39 + input40 + input41 + input42 + input43 + input44 + input45 +
                     input46 + input47 + input48 + input49 + input50 + input51 + input52 + input53 + input54 +
                     input55 + input56 + input57 + input58 + input59 + input60 + input61 + input62 + input63) *
                    Beta * Alpha * Alpha;
        result[1] = (input0 * cosCache8 + input1 * cosCache9 + input2 * cosCache10 + input3 * cosCache11 +
                     input4 * cosCache12 + input5 * cosCache13 + input6 * cosCache14 + input7 * cosCache15 +
                     input8 * cosCache8 + input9 * cosCache9 + input10 * cosCache10 + input11 * cosCache11 +
                     input12 * cosCache12 + input13 * cosCache13 + input14 * cosCache14 + input15 * cosCache15 +
                     input16 * cosCache8 + input17 * cosCache9 + input18 * cosCache10 + input19 * cosCache11 +
                     input20 * cosCache12 + input21 * cosCache13 + input22 * cosCache14 + input23 * cosCache15 +
                     input24 * cosCache8 + input25 * cosCache9 + input26 * cosCache10 + input27 * cosCache11 +
                     input28 * cosCache12 + input29 * cosCache13 + input30 * cosCache14 + input31 * cosCache15 +
                     input32 * cosCache8 + input33 * cosCache9 + input34 * cosCache10 + input35 * cosCache11 +
                     input36 * cosCache12 + input37 * cosCache13 + input38 * cosCache14 + input39 * cosCache15 +
                     input40 * cosCache8 + input41 * cosCache9 + input42 * cosCache10 + input43 * cosCache11 +
                     input44 * cosCache12 + input45 * cosCache13 + input46 * cosCache14 + input47 * cosCache15 +
                     input48 * cosCache8 + input49 * cosCache9 + input50 * cosCache10 + input51 * cosCache11 +
                     input52 * cosCache12 + input53 * cosCache13 + input54 * cosCache14 + input55 * cosCache15 +
                     input56 * cosCache8 + input57 * cosCache9 + input58 * cosCache10 + input59 * cosCache11 +
                     input60 * cosCache12 + input61 * cosCache13 + input62 * cosCache14 + input63 * cosCache15) *
                    Beta * Alpha;
        result[2] = (input0 * cosCache16 + input1 * cosCache17 + input2 * cosCache18 + input3 * cosCache19 +
                     input4 * cosCache20 + input5 * cosCache21 + input6 * cosCache22 + input7 * cosCache23 +
                     input8 * cosCache16 + input9 * cosCache17 + input10 * cosCache18 + input11 * cosCache19 +
                     input12 * cosCache20 + input13 * cosCache21 + input14 * cosCache22 + input15 * cosCache23 +
                     input16 * cosCache16 + input17 * cosCache17 + input18 * cosCache18 + input19 * cosCache19 +
                     input20 * cosCache20 + input21 * cosCache21 + input22 * cosCache22 + input23 * cosCache23 +
                     input24 * cosCache16 + input25 * cosCache17 + input26 * cosCache18 + input27 * cosCache19 +
                     input28 * cosCache20 + input29 * cosCache21 + input30 * cosCache22 + input31 * cosCache23 +
                     input32 * cosCache16 + input33 * cosCache17 + input34 * cosCache18 + input35 * cosCache19 +
                     input36 * cosCache20 + input37 * cosCache21 + input38 * cosCache22 + input39 * cosCache23 +
                     input40 * cosCache16 + input41 * cosCache17 + input42 * cosCache18 + input43 * cosCache19 +
                     input44 * cosCache20 + input45 * cosCache21 + input46 * cosCache22 + input47 * cosCache23 +
                     input48 * cosCache16 + input49 * cosCache17 + input50 * cosCache18 + input51 * cosCache19 +
                     input52 * cosCache20 + input53 * cosCache21 + input54 * cosCache22 + input55 * cosCache23 +
                     input56 * cosCache16 + input57 * cosCache17 + input58 * cosCache18 + input59 * cosCache19 +
                     input60 * cosCache20 + input61 * cosCache21 + input62 * cosCache22 + input63 * cosCache23) *
                    Beta * Alpha;
        result[3] = (input0 * cosCache24 + input1 * cosCache25 + input2 * cosCache26 + input3 * cosCache27 +
                     input4 * cosCache28 + input5 * cosCache29 + input6 * cosCache30 + input7 * cosCache31 +
                     input8 * cosCache24 + input9 * cosCache25 + input10 * cosCache26 + input11 * cosCache27 +
                     input12 * cosCache28 + input13 * cosCache29 + input14 * cosCache30 + input15 * cosCache31 +
                     input16 * cosCache24 + input17 * cosCache25 + input18 * cosCache26 + input19 * cosCache27 +
                     input20 * cosCache28 + input21 * cosCache29 + input22 * cosCache30 + input23 * cosCache31 +
                     input24 * cosCache24 + input25 * cosCache25 + input26 * cosCache26 + input27 * cosCache27 +
                     input28 * cosCache28 + input29 * cosCache29 + input30 * cosCache30 + input31 * cosCache31 +
                     input32 * cosCache24 + input33 * cosCache25 + input34 * cosCache26 + input35 * cosCache27 +
                     input36 * cosCache28 + input37 * cosCache29 + input38 * cosCache30 + input39 * cosCache31 +
                     input40 * cosCache24 + input41 * cosCache25 + input42 * cosCache26 + input43 * cosCache27 +
                     input44 * cosCache28 + input45 * cosCache29 + input46 * cosCache30 + input47 * cosCache31 +
                     input48 * cosCache24 + input49 * cosCache25 + input50 * cosCache26 + input51 * cosCache27 +
                     input52 * cosCache28 + input53 * cosCache29 + input54 * cosCache30 + input55 * cosCache31 +
                     input56 * cosCache24 + input57 * cosCache25 + input58 * cosCache26 + input59 * cosCache27 +
                     input60 * cosCache28 + input61 * cosCache29 + input62 * cosCache30 + input63 * cosCache31) *
                    Beta * Alpha;
        result[4] = (input0 * cosCache32 + input1 * cosCache33 + input2 * cosCache34 + input3 * cosCache35 +
                     input4 * cosCache36 + input5 * cosCache37 + input6 * cosCache38 + input7 * cosCache39 +
                     input8 * cosCache32 + input9 * cosCache33 + input10 * cosCache34 + input11 * cosCache35 +
                     input12 * cosCache36 + input13 * cosCache37 + input14 * cosCache38 + input15 * cosCache39 +
                     input16 * cosCache32 + input17 * cosCache33 + input18 * cosCache34 + input19 * cosCache35 +
                     input20 * cosCache36 + input21 * cosCache37 + input22 * cosCache38 + input23 * cosCache39 +
                     input24 * cosCache32 + input25 * cosCache33 + input26 * cosCache34 + input27 * cosCache35 +
                     input28 * cosCache36 + input29 * cosCache37 + input30 * cosCache38 + input31 * cosCache39 +
                     input32 * cosCache32 + input33 * cosCache33 + input34 * cosCache34 + input35 * cosCache35 +
                     input36 * cosCache36 + input37 * cosCache37 + input38 * cosCache38 + input39 * cosCache39 +
                     input40 * cosCache32 + input41 * cosCache33 + input42 * cosCache34 + input43 * cosCache35 +
                     input44 * cosCache36 + input45 * cosCache37 + input46 * cosCache38 + input47 * cosCache39 +
                     input48 * cosCache32 + input49 * cosCache33 + input50 * cosCache34 + input51 * cosCache35 +
                     input52 * cosCache36 + input53 * cosCache37 + input54 * cosCache38 + input55 * cosCache39 +
                     input56 * cosCache32 + input57 * cosCache33 + input58 * cosCache34 + input59 * cosCache35 +
                     input60 * cosCache36 + input61 * cosCache37 + input62 * cosCache38 + input63 * cosCache39) *
                    Beta * Alpha;
        result[5] = (input0 * cosCache40 + input1 * cosCache41 + input2 * cosCache42 + input3 * cosCache43 +
                     input4 * cosCache44 + input5 * cosCache45 + input6 * cosCache46 + input7 * cosCache47 +
                     input8 * cosCache40 + input9 * cosCache41 + input10 * cosCache42 + input11 * cosCache43 +
                     input12 * cosCache44 + input13 * cosCache45 + input14 * cosCache46 + input15 * cosCache47 +
                     input16 * cosCache40 + input17 * cosCache41 + input18 * cosCache42 + input19 * cosCache43 +
                     input20 * cosCache44 + input21 * cosCache45 + input22 * cosCache46 + input23 * cosCache47 +
                     input24 * cosCache40 + input25 * cosCache41 + input26 * cosCache42 + input27 * cosCache43 +
                     input28 * cosCache44 + input29 * cosCache45 + input30 * cosCache46 + input31 * cosCache47 +
                     input32 * cosCache40 + input33 * cosCache41 + input34 * cosCache42 + input35 * cosCache43 +
                     input36 * cosCache44 + input37 * cosCache45 + input38 * cosCache46 + input39 * cosCache47 +
                     input40 * cosCache40 + input41 * cosCache41 + input42 * cosCache42 + input43 * cosCache43 +
                     input44 * cosCache44 + input45 * cosCache45 + input46 * cosCache46 + input47 * cosCache47 +
                     input48 * cosCache40 + input49 * cosCache41 + input50 * cosCache42 + input51 * cosCache43 +
                     input52 * cosCache44 + input53 * cosCache45 + input54 * cosCache46 + input55 * cosCache47 +
                     input56 * cosCache40 + input57 * cosCache41 + input58 * cosCache42 + input59 * cosCache43 +
                     input60 * cosCache44 + input61 * cosCache45 + input62 * cosCache46 + input63 * cosCache47) *
                    Beta * Alpha;
        result[6] = (input0 * cosCache48 + input1 * cosCache49 + input2 * cosCache50 + input3 * cosCache51 +
                     input4 * cosCache52 + input5 * cosCache53 + input6 * cosCache54 + input7 * cosCache55 +
                     input8 * cosCache48 + input9 * cosCache49 + input10 * cosCache50 + input11 * cosCache51 +
                     input12 * cosCache52 + input13 * cosCache53 + input14 * cosCache54 + input15 * cosCache55 +
                     input16 * cosCache48 + input17 * cosCache49 + input18 * cosCache50 + input19 * cosCache51 +
                     input20 * cosCache52 + input21 * cosCache53 + input22 * cosCache54 + input23 * cosCache55 +
                     input24 * cosCache48 + input25 * cosCache49 + input26 * cosCache50 + input27 * cosCache51 +
                     input28 * cosCache52 + input29 * cosCache53 + input30 * cosCache54 + input31 * cosCache55 +
                     input32 * cosCache48 + input33 * cosCache49 + input34 * cosCache50 + input35 * cosCache51 +
                     input36 * cosCache52 + input37 * cosCache53 + input38 * cosCache54 + input39 * cosCache55 +
                     input40 * cosCache48 + input41 * cosCache49 + input42 * cosCache50 + input43 * cosCache51 +
                     input44 * cosCache52 + input45 * cosCache53 + input46 * cosCache54 + input47 * cosCache55 +
                     input48 * cosCache48 + input49 * cosCache49 + input50 * cosCache50 + input51 * cosCache51 +
                     input52 * cosCache52 + input53 * cosCache53 + input54 * cosCache54 + input55 * cosCache55 +
                     input56 * cosCache48 + input57 * cosCache49 + input58 * cosCache50 + input59 * cosCache51 +
                     input60 * cosCache52 + input61 * cosCache53 + input62 * cosCache54 + input63 * cosCache55) *
                    Beta * Alpha;
        result[7] = (input0 * cosCache56 + input1 * cosCache57 + input2 * cosCache58 + input3 * cosCache59 +
                     input4 * cosCache60 + input5 * cosCache61 + input6 * cosCache62 + input7 * cosCache63 +
                     input8 * cosCache56 + input9 * cosCache57 + input10 * cosCache58 + input11 * cosCache59 +
                     input12 * cosCache60 + input13 * cosCache61 + input14 * cosCache62 + input15 * cosCache63 +
                     input16 * cosCache56 + input17 * cosCache57 + input18 * cosCache58 + input19 * cosCache59 +
                     input20 * cosCache60 + input21 * cosCache61 + input22 * cosCache62 + input23 * cosCache63 +
                     input24 * cosCache56 + input25 * cosCache57 + input26 * cosCache58 + input27 * cosCache59 +
                     input28 * cosCache60 + input29 * cosCache61 + input30 * cosCache62 + input31 * cosCache63 +
                     input32 * cosCache56 + input33 * cosCache57 + input34 * cosCache58 + input35 * cosCache59 +
                     input36 * cosCache60 + input37 * cosCache61 + input38 * cosCache62 + input39 * cosCache63 +
                     input40 * cosCache56 + input41 * cosCache57 + input42 * cosCache58 + input43 * cosCache59 +
                     input44 * cosCache60 + input45 * cosCache61 + input46 * cosCache62 + input47 * cosCache63 +
                     input48 * cosCache56 + input49 * cosCache57 + input50 * cosCache58 + input51 * cosCache59 +
                     input52 * cosCache60 + input53 * cosCache61 + input54 * cosCache62 + input55 * cosCache63 +
                     input56 * cosCache56 + input57 * cosCache57 + input58 * cosCache58 + input59 * cosCache59 +
                     input60 * cosCache60 + input61 * cosCache61 + input62 * cosCache62 + input63 * cosCache63) *
                    Beta * Alpha;
        result[8] = (input0 * cosCache8 + input1 * cosCache8 + input2 * cosCache8 + input3 * cosCache8 +
                     input4 * cosCache8 + input5 * cosCache8 + input6 * cosCache8 + input7 * cosCache8 +
                     input8 * cosCache9 + input9 * cosCache9 + input10 * cosCache9 + input11 * cosCache9 +
                     input12 * cosCache9 + input13 * cosCache9 + input14 * cosCache9 + input15 * cosCache9 +
                     input16 * cosCache10 + input17 * cosCache10 + input18 * cosCache10 + input19 * cosCache10 +
                     input20 * cosCache10 + input21 * cosCache10 + input22 * cosCache10 + input23 * cosCache10 +
                     input24 * cosCache11 + input25 * cosCache11 + input26 * cosCache11 + input27 * cosCache11 +
                     input28 * cosCache11 + input29 * cosCache11 + input30 * cosCache11 + input31 * cosCache11 +
                     input32 * cosCache12 + input33 * cosCache12 + input34 * cosCache12 + input35 * cosCache12 +
                     input36 * cosCache12 + input37 * cosCache12 + input38 * cosCache12 + input39 * cosCache12 +
                     input40 * cosCache13 + input41 * cosCache13 + input42 * cosCache13 + input43 * cosCache13 +
                     input44 * cosCache13 + input45 * cosCache13 + input46 * cosCache13 + input47 * cosCache13 +
                     input48 * cosCache14 + input49 * cosCache14 + input50 * cosCache14 + input51 * cosCache14 +
                     input52 * cosCache14 + input53 * cosCache14 + input54 * cosCache14 + input55 * cosCache14 +
                     input56 * cosCache15 + input57 * cosCache15 + input58 * cosCache15 + input59 * cosCache15 +
                     input60 * cosCache15 + input61 * cosCache15 + input62 * cosCache15 + input63 * cosCache15) *
                    Beta * Alpha;
        result[9] = (input0 * cosCache8 * cosCache8 + input1 * cosCache8 * cosCache9 +
                     input2 * cosCache8 * cosCache10 + input3 * cosCache8 * cosCache11 +
                     input4 * cosCache8 * cosCache12 + input5 * cosCache8 * cosCache13 +
                     input6 * cosCache8 * cosCache14 + input7 * cosCache8 * cosCache15 +
                     input8 * cosCache9 * cosCache8 + input9 * cosCache9 * cosCache9 +
                     input10 * cosCache9 * cosCache10 + input11 * cosCache9 * cosCache11 +
                     input12 * cosCache9 * cosCache12 + input13 * cosCache9 * cosCache13 +
                     input14 * cosCache9 * cosCache14 + input15 * cosCache9 * cosCache15 +
                     input16 * cosCache10 * cosCache8 + input17 * cosCache10 * cosCache9 +
                     input18 * cosCache10 * cosCache10 + input19 * cosCache10 * cosCache11 +
                     input20 * cosCache10 * cosCache12 + input21 * cosCache10 * cosCache13 +
                     input22 * cosCache10 * cosCache14 + input23 * cosCache10 * cosCache15 +
                     input24 * cosCache11 * cosCache8 + input25 * cosCache11 * cosCache9 +
                     input26 * cosCache11 * cosCache10 + input27 * cosCache11 * cosCache11 +
                     input28 * cosCache11 * cosCache12 + input29 * cosCache11 * cosCache13 +
                     input30 * cosCache11 * cosCache14 + input31 * cosCache11 * cosCache15 +
                     input32 * cosCache12 * cosCache8 + input33 * cosCache12 * cosCache9 +
                     input34 * cosCache12 * cosCache10 + input35 * cosCache12 * cosCache11 +
                     input36 * cosCache12 * cosCache12 + input37 * cosCache12 * cosCache13 +
                     input38 * cosCache12 * cosCache14 + input39 * cosCache12 * cosCache15 +
                     input40 * cosCache13 * cosCache8 + input41 * cosCache13 * cosCache9 +
                     input42 * cosCache13 * cosCache10 + input43 * cosCache13 * cosCache11 +
                     input44 * cosCache13 * cosCache12 + input45 * cosCache13 * cosCache13 +
                     input46 * cosCache13 * cosCache14 + input47 * cosCache13 * cosCache15 +
                     input48 * cosCache14 * cosCache8 + input49 * cosCache14 * cosCache9 +
                     input50 * cosCache14 * cosCache10 + input51 * cosCache14 * cosCache11 +
                     input52 * cosCache14 * cosCache12 + input53 * cosCache14 * cosCache13 +
                     input54 * cosCache14 * cosCache14 + input55 * cosCache14 * cosCache15 +
                     input56 * cosCache15 * cosCache8 + input57 * cosCache15 * cosCache9 +
                     input58 * cosCache15 * cosCache10 + input59 * cosCache15 * cosCache11 +
                     input60 * cosCache15 * cosCache12 + input61 * cosCache15 * cosCache13 +
                     input62 * cosCache15 * cosCache14 + input63 * cosCache15 * cosCache15) * Beta;
        result[10] = (input0 * cosCache8 * cosCache16 + input1 * cosCache8 * cosCache17 +
                      input2 * cosCache8 * cosCache18 + input3 * cosCache8 * cosCache19 +
                      input4 * cosCache8 * cosCache20 + input5 * cosCache8 * cosCache21 +
                      input6 * cosCache8 * cosCache22 + input7 * cosCache8 * cosCache23 +
                      input8 * cosCache9 * cosCache16 + input9 * cosCache9 * cosCache17 +
                      input10 * cosCache9 * cosCache18 + input11 * cosCache9 * cosCache19 +
                      input12 * cosCache9 * cosCache20 + input13 * cosCache9 * cosCache21 +
                      input14 * cosCache9 * cosCache22 + input15 * cosCache9 * cosCache23 +
                      input16 * cosCache10 * cosCache16 + input17 * cosCache10 * cosCache17 +
                      input18 * cosCache10 * cosCache18 + input19 * cosCache10 * cosCache19 +
                      input20 * cosCache10 * cosCache20 + input21 * cosCache10 * cosCache21 +
                      input22 * cosCache10 * cosCache22 + input23 * cosCache10 * cosCache23 +
                      input24 * cosCache11 * cosCache16 + input25 * cosCache11 * cosCache17 +
                      input26 * cosCache11 * cosCache18 + input27 * cosCache11 * cosCache19 +
                      input28 * cosCache11 * cosCache20 + input29 * cosCache11 * cosCache21 +
                      input30 * cosCache11 * cosCache22 + input31 * cosCache11 * cosCache23 +
                      input32 * cosCache12 * cosCache16 + input33 * cosCache12 * cosCache17 +
                      input34 * cosCache12 * cosCache18 + input35 * cosCache12 * cosCache19 +
                      input36 * cosCache12 * cosCache20 + input37 * cosCache12 * cosCache21 +
                      input38 * cosCache12 * cosCache22 + input39 * cosCache12 * cosCache23 +
                      input40 * cosCache13 * cosCache16 + input41 * cosCache13 * cosCache17 +
                      input42 * cosCache13 * cosCache18 + input43 * cosCache13 * cosCache19 +
                      input44 * cosCache13 * cosCache20 + input45 * cosCache13 * cosCache21 +
                      input46 * cosCache13 * cosCache22 + input47 * cosCache13 * cosCache23 +
                      input48 * cosCache14 * cosCache16 + input49 * cosCache14 * cosCache17 +
                      input50 * cosCache14 * cosCache18 + input51 * cosCache14 * cosCache19 +
                      input52 * cosCache14 * cosCache20 + input53 * cosCache14 * cosCache21 +
                      input54 * cosCache14 * cosCache22 + input55 * cosCache14 * cosCache23 +
                      input56 * cosCache15 * cosCache16 + input57 * cosCache15 * cosCache17 +
                      input58 * cosCache15 * cosCache18 + input59 * cosCache15 * cosCache19 +
                      input60 * cosCache15 * cosCache20 + input61 * cosCache15 * cosCache21 +
                      input62 * cosCache15 * cosCache22 + input63 * cosCache15 * cosCache23) * Beta;
        result[11] = (input0 * cosCache8 * cosCache24 + input1 * cosCache8 * cosCache25 +
                      input2 * cosCache8 * cosCache26 + input3 * cosCache8 * cosCache27 +
                      input4 * cosCache8 * cosCache28 + input5 * cosCache8 * cosCache29 +
                      input6 * cosCache8 * cosCache30 + input7 * cosCache8 * cosCache31 +
                      input8 * cosCache9 * cosCache24 + input9 * cosCache9 * cosCache25 +
                      input10 * cosCache9 * cosCache26 + input11 * cosCache9 * cosCache27 +
                      input12 * cosCache9 * cosCache28 + input13 * cosCache9 * cosCache29 +
                      input14 * cosCache9 * cosCache30 + input15 * cosCache9 * cosCache31 +
                      input16 * cosCache10 * cosCache24 + input17 * cosCache10 * cosCache25 +
                      input18 * cosCache10 * cosCache26 + input19 * cosCache10 * cosCache27 +
                      input20 * cosCache10 * cosCache28 + input21 * cosCache10 * cosCache29 +
                      input22 * cosCache10 * cosCache30 + input23 * cosCache10 * cosCache31 +
                      input24 * cosCache11 * cosCache24 + input25 * cosCache11 * cosCache25 +
                      input26 * cosCache11 * cosCache26 + input27 * cosCache11 * cosCache27 +
                      input28 * cosCache11 * cosCache28 + input29 * cosCache11 * cosCache29 +
                      input30 * cosCache11 * cosCache30 + input31 * cosCache11 * cosCache31 +
                      input32 * cosCache12 * cosCache24 + input33 * cosCache12 * cosCache25 +
                      input34 * cosCache12 * cosCache26 + input35 * cosCache12 * cosCache27 +
                      input36 * cosCache12 * cosCache28 + input37 * cosCache12 * cosCache29 +
                      input38 * cosCache12 * cosCache30 + input39 * cosCache12 * cosCache31 +
                      input40 * cosCache13 * cosCache24 + input41 * cosCache13 * cosCache25 +
                      input42 * cosCache13 * cosCache26 + input43 * cosCache13 * cosCache27 +
                      input44 * cosCache13 * cosCache28 + input45 * cosCache13 * cosCache29 +
                      input46 * cosCache13 * cosCache30 + input47 * cosCache13 * cosCache31 +
                      input48 * cosCache14 * cosCache24 + input49 * cosCache14 * cosCache25 +
                      input50 * cosCache14 * cosCache26 + input51 * cosCache14 * cosCache27 +
                      input52 * cosCache14 * cosCache28 + input53 * cosCache14 * cosCache29 +
                      input54 * cosCache14 * cosCache30 + input55 * cosCache14 * cosCache31 +
                      input56 * cosCache15 * cosCache24 + input57 * cosCache15 * cosCache25 +
                      input58 * cosCache15 * cosCache26 + input59 * cosCache15 * cosCache27 +
                      input60 * cosCache15 * cosCache28 + input61 * cosCache15 * cosCache29 +
                      input62 * cosCache15 * cosCache30 + input63 * cosCache15 * cosCache31) * Beta;
        result[12] = (input0 * cosCache8 * cosCache32 + input1 * cosCache8 * cosCache33 +
                      input2 * cosCache8 * cosCache34 + input3 * cosCache8 * cosCache35 +
                      input4 * cosCache8 * cosCache36 + input5 * cosCache8 * cosCache37 +
                      input6 * cosCache8 * cosCache38 + input7 * cosCache8 * cosCache39 +
                      input8 * cosCache9 * cosCache32 + input9 * cosCache9 * cosCache33 +
                      input10 * cosCache9 * cosCache34 + input11 * cosCache9 * cosCache35 +
                      input12 * cosCache9 * cosCache36 + input13 * cosCache9 * cosCache37 +
                      input14 * cosCache9 * cosCache38 + input15 * cosCache9 * cosCache39 +
                      input16 * cosCache10 * cosCache32 + input17 * cosCache10 * cosCache33 +
                      input18 * cosCache10 * cosCache34 + input19 * cosCache10 * cosCache35 +
                      input20 * cosCache10 * cosCache36 + input21 * cosCache10 * cosCache37 +
                      input22 * cosCache10 * cosCache38 + input23 * cosCache10 * cosCache39 +
                      input24 * cosCache11 * cosCache32 + input25 * cosCache11 * cosCache33 +
                      input26 * cosCache11 * cosCache34 + input27 * cosCache11 * cosCache35 +
                      input28 * cosCache11 * cosCache36 + input29 * cosCache11 * cosCache37 +
                      input30 * cosCache11 * cosCache38 + input31 * cosCache11 * cosCache39 +
                      input32 * cosCache12 * cosCache32 + input33 * cosCache12 * cosCache33 +
                      input34 * cosCache12 * cosCache34 + input35 * cosCache12 * cosCache35 +
                      input36 * cosCache12 * cosCache36 + input37 * cosCache12 * cosCache37 +
                      input38 * cosCache12 * cosCache38 + input39 * cosCache12 * cosCache39 +
                      input40 * cosCache13 * cosCache32 + input41 * cosCache13 * cosCache33 +
                      input42 * cosCache13 * cosCache34 + input43 * cosCache13 * cosCache35 +
                      input44 * cosCache13 * cosCache36 + input45 * cosCache13 * cosCache37 +
                      input46 * cosCache13 * cosCache38 + input47 * cosCache13 * cosCache39 +
                      input48 * cosCache14 * cosCache32 + input49 * cosCache14 * cosCache33 +
                      input50 * cosCache14 * cosCache34 + input51 * cosCache14 * cosCache35 +
                      input52 * cosCache14 * cosCache36 + input53 * cosCache14 * cosCache37 +
                      input54 * cosCache14 * cosCache38 + input55 * cosCache14 * cosCache39 +
                      input56 * cosCache15 * cosCache32 + input57 * cosCache15 * cosCache33 +
                      input58 * cosCache15 * cosCache34 + input59 * cosCache15 * cosCache35 +
                      input60 * cosCache15 * cosCache36 + input61 * cosCache15 * cosCache37 +
                      input62 * cosCache15 * cosCache38 + input63 * cosCache15 * cosCache39) * Beta;
        result[13] = (input0 * cosCache8 * cosCache40 + input1 * cosCache8 * cosCache41 +
                      input2 * cosCache8 * cosCache42 + input3 * cosCache8 * cosCache43 +
                      input4 * cosCache8 * cosCache44 + input5 * cosCache8 * cosCache45 +
                      input6 * cosCache8 * cosCache46 + input7 * cosCache8 * cosCache47 +
                      input8 * cosCache9 * cosCache40 + input9 * cosCache9 * cosCache41 +
                      input10 * cosCache9 * cosCache42 + input11 * cosCache9 * cosCache43 +
                      input12 * cosCache9 * cosCache44 + input13 * cosCache9 * cosCache45 +
                      input14 * cosCache9 * cosCache46 + input15 * cosCache9 * cosCache47 +
                      input16 * cosCache10 * cosCache40 + input17 * cosCache10 * cosCache41 +
                      input18 * cosCache10 * cosCache42 + input19 * cosCache10 * cosCache43 +
                      input20 * cosCache10 * cosCache44 + input21 * cosCache10 * cosCache45 +
                      input22 * cosCache10 * cosCache46 + input23 * cosCache10 * cosCache47 +
                      input24 * cosCache11 * cosCache40 + input25 * cosCache11 * cosCache41 +
                      input26 * cosCache11 * cosCache42 + input27 * cosCache11 * cosCache43 +
                      input28 * cosCache11 * cosCache44 + input29 * cosCache11 * cosCache45 +
                      input30 * cosCache11 * cosCache46 + input31 * cosCache11 * cosCache47 +
                      input32 * cosCache12 * cosCache40 + input33 * cosCache12 * cosCache41 +
                      input34 * cosCache12 * cosCache42 + input35 * cosCache12 * cosCache43 +
                      input36 * cosCache12 * cosCache44 + input37 * cosCache12 * cosCache45 +
                      input38 * cosCache12 * cosCache46 + input39 * cosCache12 * cosCache47 +
                      input40 * cosCache13 * cosCache40 + input41 * cosCache13 * cosCache41 +
                      input42 * cosCache13 * cosCache42 + input43 * cosCache13 * cosCache43 +
                      input44 * cosCache13 * cosCache44 + input45 * cosCache13 * cosCache45 +
                      input46 * cosCache13 * cosCache46 + input47 * cosCache13 * cosCache47 +
                      input48 * cosCache14 * cosCache40 + input49 * cosCache14 * cosCache41 +
                      input50 * cosCache14 * cosCache42 + input51 * cosCache14 * cosCache43 +
                      input52 * cosCache14 * cosCache44 + input53 * cosCache14 * cosCache45 +
                      input54 * cosCache14 * cosCache46 + input55 * cosCache14 * cosCache47 +
                      input56 * cosCache15 * cosCache40 + input57 * cosCache15 * cosCache41 +
                      input58 * cosCache15 * cosCache42 + input59 * cosCache15 * cosCache43 +
                      input60 * cosCache15 * cosCache44 + input61 * cosCache15 * cosCache45 +
                      input62 * cosCache15 * cosCache46 + input63 * cosCache15 * cosCache47) * Beta;
        result[14] = (input0 * cosCache8 * cosCache48 + input1 * cosCache8 * cosCache49 +
                      input2 * cosCache8 * cosCache50 + input3 * cosCache8 * cosCache51 +
                      input4 * cosCache8 * cosCache52 + input5 * cosCache8 * cosCache53 +
                      input6 * cosCache8 * cosCache54 + input7 * cosCache8 * cosCache55 +
                      input8 * cosCache9 * cosCache48 + input9 * cosCache9 * cosCache49 +
                      input10 * cosCache9 * cosCache50 + input11 * cosCache9 * cosCache51 +
                      input12 * cosCache9 * cosCache52 + input13 * cosCache9 * cosCache53 +
                      input14 * cosCache9 * cosCache54 + input15 * cosCache9 * cosCache55 +
                      input16 * cosCache10 * cosCache48 + input17 * cosCache10 * cosCache49 +
                      input18 * cosCache10 * cosCache50 + input19 * cosCache10 * cosCache51 +
                      input20 * cosCache10 * cosCache52 + input21 * cosCache10 * cosCache53 +
                      input22 * cosCache10 * cosCache54 + input23 * cosCache10 * cosCache55 +
                      input24 * cosCache11 * cosCache48 + input25 * cosCache11 * cosCache49 +
                      input26 * cosCache11 * cosCache50 + input27 * cosCache11 * cosCache51 +
                      input28 * cosCache11 * cosCache52 + input29 * cosCache11 * cosCache53 +
                      input30 * cosCache11 * cosCache54 + input31 * cosCache11 * cosCache55 +
                      input32 * cosCache12 * cosCache48 + input33 * cosCache12 * cosCache49 +
                      input34 * cosCache12 * cosCache50 + input35 * cosCache12 * cosCache51 +
                      input36 * cosCache12 * cosCache52 + input37 * cosCache12 * cosCache53 +
                      input38 * cosCache12 * cosCache54 + input39 * cosCache12 * cosCache55 +
                      input40 * cosCache13 * cosCache48 + input41 * cosCache13 * cosCache49 +
                      input42 * cosCache13 * cosCache50 + input43 * cosCache13 * cosCache51 +
                      input44 * cosCache13 * cosCache52 + input45 * cosCache13 * cosCache53 +
                      input46 * cosCache13 * cosCache54 + input47 * cosCache13 * cosCache55 +
                      input48 * cosCache14 * cosCache48 + input49 * cosCache14 * cosCache49 +
                      input50 * cosCache14 * cosCache50 + input51 * cosCache14 * cosCache51 +
                      input52 * cosCache14 * cosCache52 + input53 * cosCache14 * cosCache53 +
                      input54 * cosCache14 * cosCache54 + input55 * cosCache14 * cosCache55 +
                      input56 * cosCache15 * cosCache48 + input57 * cosCache15 * cosCache49 +
                      input58 * cosCache15 * cosCache50 + input59 * cosCache15 * cosCache51 +
                      input60 * cosCache15 * cosCache52 + input61 * cosCache15 * cosCache53 +
                      input62 * cosCache15 * cosCache54 + input63 * cosCache15 * cosCache55) * Beta;
        result[15] = (input0 * cosCache8 * cosCache56 + input1 * cosCache8 * cosCache57 +
                      input2 * cosCache8 * cosCache58 + input3 * cosCache8 * cosCache59 +
                      input4 * cosCache8 * cosCache60 + input5 * cosCache8 * cosCache61 +
                      input6 * cosCache8 * cosCache62 + input7 * cosCache8 * cosCache63 +
                      input8 * cosCache9 * cosCache56 + input9 * cosCache9 * cosCache57 +
                      input10 * cosCache9 * cosCache58 + input11 * cosCache9 * cosCache59 +
                      input12 * cosCache9 * cosCache60 + input13 * cosCache9 * cosCache61 +
                      input14 * cosCache9 * cosCache62 + input15 * cosCache9 * cosCache63 +
                      input16 * cosCache10 * cosCache56 + input17 * cosCache10 * cosCache57 +
                      input18 * cosCache10 * cosCache58 + input19 * cosCache10 * cosCache59 +
                      input20 * cosCache10 * cosCache60 + input21 * cosCache10 * cosCache61 +
                      input22 * cosCache10 * cosCache62 + input23 * cosCache10 * cosCache63 +
                      input24 * cosCache11 * cosCache56 + input25 * cosCache11 * cosCache57 +
                      input26 * cosCache11 * cosCache58 + input27 * cosCache11 * cosCache59 +
                      input28 * cosCache11 * cosCache60 + input29 * cosCache11 * cosCache61 +
                      input30 * cosCache11 * cosCache62 + input31 * cosCache11 * cosCache63 +
                      input32 * cosCache12 * cosCache56 + input33 * cosCache12 * cosCache57 +
                      input34 * cosCache12 * cosCache58 + input35 * cosCache12 * cosCache59 +
                      input36 * cosCache12 * cosCache60 + input37 * cosCache12 * cosCache61 +
                      input38 * cosCache12 * cosCache62 + input39 * cosCache12 * cosCache63 +
                      input40 * cosCache13 * cosCache56 + input41 * cosCache13 * cosCache57 +
                      input42 * cosCache13 * cosCache58 + input43 * cosCache13 * cosCache59 +
                      input44 * cosCache13 * cosCache60 + input45 * cosCache13 * cosCache61 +
                      input46 * cosCache13 * cosCache62 + input47 * cosCache13 * cosCache63 +
                      input48 * cosCache14 * cosCache56 + input49 * cosCache14 * cosCache57 +
                      input50 * cosCache14 * cosCache58 + input51 * cosCache14 * cosCache59 +
                      input52 * cosCache14 * cosCache60 + input53 * cosCache14 * cosCache61 +
                      input54 * cosCache14 * cosCache62 + input55 * cosCache14 * cosCache63 +
                      input56 * cosCache15 * cosCache56 + input57 * cosCache15 * cosCache57 +
                      input58 * cosCache15 * cosCache58 + input59 * cosCache15 * cosCache59 +
                      input60 * cosCache15 * cosCache60 + input61 * cosCache15 * cosCache61 +
                      input62 * cosCache15 * cosCache62 + input63 * cosCache15 * cosCache63) * Beta;
        result[16] = (input0 * cosCache16 + input1 * cosCache16 + input2 * cosCache16 + input3 * cosCache16 +
                      input4 * cosCache16 + input5 * cosCache16 + input6 * cosCache16 + input7 * cosCache16 +
                      input8 * cosCache17 + input9 * cosCache17 + input10 * cosCache17 + input11 * cosCache17 +
                      input12 * cosCache17 + input13 * cosCache17 + input14 * cosCache17 + input15 * cosCache17 +
                      input16 * cosCache18 + input17 * cosCache18 + input18 * cosCache18 + input19 * cosCache18 +
                      input20 * cosCache18 + input21 * cosCache18 + input22 * cosCache18 + input23 * cosCache18 +
                      input24 * cosCache19 + input25 * cosCache19 + input26 * cosCache19 + input27 * cosCache19 +
                      input28 * cosCache19 + input29 * cosCache19 + input30 * cosCache19 + input31 * cosCache19 +
                      input32 * cosCache20 + input33 * cosCache20 + input34 * cosCache20 + input35 * cosCache20 +
                      input36 * cosCache20 + input37 * cosCache20 + input38 * cosCache20 + input39 * cosCache20 +
                      input40 * cosCache21 + input41 * cosCache21 + input42 * cosCache21 + input43 * cosCache21 +
                      input44 * cosCache21 + input45 * cosCache21 + input46 * cosCache21 + input47 * cosCache21 +
                      input48 * cosCache22 + input49 * cosCache22 + input50 * cosCache22 + input51 * cosCache22 +
                      input52 * cosCache22 + input53 * cosCache22 + input54 * cosCache22 + input55 * cosCache22 +
                      input56 * cosCache23 + input57 * cosCache23 + input58 * cosCache23 + input59 * cosCache23 +
                      input60 * cosCache23 + input61 * cosCache23 + input62 * cosCache23 + input63 * cosCache23) *
                     Beta * Alpha;
        result[17] = (input0 * cosCache16 * cosCache8 + input1 * cosCache16 * cosCache9 +
                      input2 * cosCache16 * cosCache10 + input3 * cosCache16 * cosCache11 +
                      input4 * cosCache16 * cosCache12 + input5 * cosCache16 * cosCache13 +
                      input6 * cosCache16 * cosCache14 + input7 * cosCache16 * cosCache15 +
                      input8 * cosCache17 * cosCache8 + input9 * cosCache17 * cosCache9 +
                      input10 * cosCache17 * cosCache10 + input11 * cosCache17 * cosCache11 +
                      input12 * cosCache17 * cosCache12 + input13 * cosCache17 * cosCache13 +
                      input14 * cosCache17 * cosCache14 + input15 * cosCache17 * cosCache15 +
                      input16 * cosCache18 * cosCache8 + input17 * cosCache18 * cosCache9 +
                      input18 * cosCache18 * cosCache10 + input19 * cosCache18 * cosCache11 +
                      input20 * cosCache18 * cosCache12 + input21 * cosCache18 * cosCache13 +
                      input22 * cosCache18 * cosCache14 + input23 * cosCache18 * cosCache15 +
                      input24 * cosCache19 * cosCache8 + input25 * cosCache19 * cosCache9 +
                      input26 * cosCache19 * cosCache10 + input27 * cosCache19 * cosCache11 +
                      input28 * cosCache19 * cosCache12 + input29 * cosCache19 * cosCache13 +
                      input30 * cosCache19 * cosCache14 + input31 * cosCache19 * cosCache15 +
                      input32 * cosCache20 * cosCache8 + input33 * cosCache20 * cosCache9 +
                      input34 * cosCache20 * cosCache10 + input35 * cosCache20 * cosCache11 +
                      input36 * cosCache20 * cosCache12 + input37 * cosCache20 * cosCache13 +
                      input38 * cosCache20 * cosCache14 + input39 * cosCache20 * cosCache15 +
                      input40 * cosCache21 * cosCache8 + input41 * cosCache21 * cosCache9 +
                      input42 * cosCache21 * cosCache10 + input43 * cosCache21 * cosCache11 +
                      input44 * cosCache21 * cosCache12 + input45 * cosCache21 * cosCache13 +
                      input46 * cosCache21 * cosCache14 + input47 * cosCache21 * cosCache15 +
                      input48 * cosCache22 * cosCache8 + input49 * cosCache22 * cosCache9 +
                      input50 * cosCache22 * cosCache10 + input51 * cosCache22 * cosCache11 +
                      input52 * cosCache22 * cosCache12 + input53 * cosCache22 * cosCache13 +
                      input54 * cosCache22 * cosCache14 + input55 * cosCache22 * cosCache15 +
                      input56 * cosCache23 * cosCache8 + input57 * cosCache23 * cosCache9 +
                      input58 * cosCache23 * cosCache10 + input59 * cosCache23 * cosCache11 +
                      input60 * cosCache23 * cosCache12 + input61 * cosCache23 * cosCache13 +
                      input62 * cosCache23 * cosCache14 + input63 * cosCache23 * cosCache15) * Beta;
        result[18] = (input0 * cosCache16 * cosCache16 + input1 * cosCache16 * cosCache17 +
                      input2 * cosCache16 * cosCache18 + input3 * cosCache16 * cosCache19 +
                      input4 * cosCache16 * cosCache20 + input5 * cosCache16 * cosCache21 +
                      input6 * cosCache16 * cosCache22 + input7 * cosCache16 * cosCache23 +
                      input8 * cosCache17 * cosCache16 + input9 * cosCache17 * cosCache17 +
                      input10 * cosCache17 * cosCache18 + input11 * cosCache17 * cosCache19 +
                      input12 * cosCache17 * cosCache20 + input13 * cosCache17 * cosCache21 +
                      input14 * cosCache17 * cosCache22 + input15 * cosCache17 * cosCache23 +
                      input16 * cosCache18 * cosCache16 + input17 * cosCache18 * cosCache17 +
                      input18 * cosCache18 * cosCache18 + input19 * cosCache18 * cosCache19 +
                      input20 * cosCache18 * cosCache20 + input21 * cosCache18 * cosCache21 +
                      input22 * cosCache18 * cosCache22 + input23 * cosCache18 * cosCache23 +
                      input24 * cosCache19 * cosCache16 + input25 * cosCache19 * cosCache17 +
                      input26 * cosCache19 * cosCache18 + input27 * cosCache19 * cosCache19 +
                      input28 * cosCache19 * cosCache20 + input29 * cosCache19 * cosCache21 +
                      input30 * cosCache19 * cosCache22 + input31 * cosCache19 * cosCache23 +
                      input32 * cosCache20 * cosCache16 + input33 * cosCache20 * cosCache17 +
                      input34 * cosCache20 * cosCache18 + input35 * cosCache20 * cosCache19 +
                      input36 * cosCache20 * cosCache20 + input37 * cosCache20 * cosCache21 +
                      input38 * cosCache20 * cosCache22 + input39 * cosCache20 * cosCache23 +
                      input40 * cosCache21 * cosCache16 + input41 * cosCache21 * cosCache17 +
                      input42 * cosCache21 * cosCache18 + input43 * cosCache21 * cosCache19 +
                      input44 * cosCache21 * cosCache20 + input45 * cosCache21 * cosCache21 +
                      input46 * cosCache21 * cosCache22 + input47 * cosCache21 * cosCache23 +
                      input48 * cosCache22 * cosCache16 + input49 * cosCache22 * cosCache17 +
                      input50 * cosCache22 * cosCache18 + input51 * cosCache22 * cosCache19 +
                      input52 * cosCache22 * cosCache20 + input53 * cosCache22 * cosCache21 +
                      input54 * cosCache22 * cosCache22 + input55 * cosCache22 * cosCache23 +
                      input56 * cosCache23 * cosCache16 + input57 * cosCache23 * cosCache17 +
                      input58 * cosCache23 * cosCache18 + input59 * cosCache23 * cosCache19 +
                      input60 * cosCache23 * cosCache20 + input61 * cosCache23 * cosCache21 +
                      input62 * cosCache23 * cosCache22 + input63 * cosCache23 * cosCache23) * Beta;
        result[19] = (input0 * cosCache16 * cosCache24 + input1 * cosCache16 * cosCache25 +
                      input2 * cosCache16 * cosCache26 + input3 * cosCache16 * cosCache27 +
                      input4 * cosCache16 * cosCache28 + input5 * cosCache16 * cosCache29 +
                      input6 * cosCache16 * cosCache30 + input7 * cosCache16 * cosCache31 +
                      input8 * cosCache17 * cosCache24 + input9 * cosCache17 * cosCache25 +
                      input10 * cosCache17 * cosCache26 + input11 * cosCache17 * cosCache27 +
                      input12 * cosCache17 * cosCache28 + input13 * cosCache17 * cosCache29 +
                      input14 * cosCache17 * cosCache30 + input15 * cosCache17 * cosCache31 +
                      input16 * cosCache18 * cosCache24 + input17 * cosCache18 * cosCache25 +
                      input18 * cosCache18 * cosCache26 + input19 * cosCache18 * cosCache27 +
                      input20 * cosCache18 * cosCache28 + input21 * cosCache18 * cosCache29 +
                      input22 * cosCache18 * cosCache30 + input23 * cosCache18 * cosCache31 +
                      input24 * cosCache19 * cosCache24 + input25 * cosCache19 * cosCache25 +
                      input26 * cosCache19 * cosCache26 + input27 * cosCache19 * cosCache27 +
                      input28 * cosCache19 * cosCache28 + input29 * cosCache19 * cosCache29 +
                      input30 * cosCache19 * cosCache30 + input31 * cosCache19 * cosCache31 +
                      input32 * cosCache20 * cosCache24 + input33 * cosCache20 * cosCache25 +
                      input34 * cosCache20 * cosCache26 + input35 * cosCache20 * cosCache27 +
                      input36 * cosCache20 * cosCache28 + input37 * cosCache20 * cosCache29 +
                      input38 * cosCache20 * cosCache30 + input39 * cosCache20 * cosCache31 +
                      input40 * cosCache21 * cosCache24 + input41 * cosCache21 * cosCache25 +
                      input42 * cosCache21 * cosCache26 + input43 * cosCache21 * cosCache27 +
                      input44 * cosCache21 * cosCache28 + input45 * cosCache21 * cosCache29 +
                      input46 * cosCache21 * cosCache30 + input47 * cosCache21 * cosCache31 +
                      input48 * cosCache22 * cosCache24 + input49 * cosCache22 * cosCache25 +
                      input50 * cosCache22 * cosCache26 + input51 * cosCache22 * cosCache27 +
                      input52 * cosCache22 * cosCache28 + input53 * cosCache22 * cosCache29 +
                      input54 * cosCache22 * cosCache30 + input55 * cosCache22 * cosCache31 +
                      input56 * cosCache23 * cosCache24 + input57 * cosCache23 * cosCache25 +
                      input58 * cosCache23 * cosCache26 + input59 * cosCache23 * cosCache27 +
                      input60 * cosCache23 * cosCache28 + input61 * cosCache23 * cosCache29 +
                      input62 * cosCache23 * cosCache30 + input63 * cosCache23 * cosCache31) * Beta;
        result[20] = (input0 * cosCache16 * cosCache32 + input1 * cosCache16 * cosCache33 +
                      input2 * cosCache16 * cosCache34 + input3 * cosCache16 * cosCache35 +
                      input4 * cosCache16 * cosCache36 + input5 * cosCache16 * cosCache37 +
                      input6 * cosCache16 * cosCache38 + input7 * cosCache16 * cosCache39 +
                      input8 * cosCache17 * cosCache32 + input9 * cosCache17 * cosCache33 +
                      input10 * cosCache17 * cosCache34 + input11 * cosCache17 * cosCache35 +
                      input12 * cosCache17 * cosCache36 + input13 * cosCache17 * cosCache37 +
                      input14 * cosCache17 * cosCache38 + input15 * cosCache17 * cosCache39 +
                      input16 * cosCache18 * cosCache32 + input17 * cosCache18 * cosCache33 +
                      input18 * cosCache18 * cosCache34 + input19 * cosCache18 * cosCache35 +
                      input20 * cosCache18 * cosCache36 + input21 * cosCache18 * cosCache37 +
                      input22 * cosCache18 * cosCache38 + input23 * cosCache18 * cosCache39 +
                      input24 * cosCache19 * cosCache32 + input25 * cosCache19 * cosCache33 +
                      input26 * cosCache19 * cosCache34 + input27 * cosCache19 * cosCache35 +
                      input28 * cosCache19 * cosCache36 + input29 * cosCache19 * cosCache37 +
                      input30 * cosCache19 * cosCache38 + input31 * cosCache19 * cosCache39 +
                      input32 * cosCache20 * cosCache32 + input33 * cosCache20 * cosCache33 +
                      input34 * cosCache20 * cosCache34 + input35 * cosCache20 * cosCache35 +
                      input36 * cosCache20 * cosCache36 + input37 * cosCache20 * cosCache37 +
                      input38 * cosCache20 * cosCache38 + input39 * cosCache20 * cosCache39 +
                      input40 * cosCache21 * cosCache32 + input41 * cosCache21 * cosCache33 +
                      input42 * cosCache21 * cosCache34 + input43 * cosCache21 * cosCache35 +
                      input44 * cosCache21 * cosCache36 + input45 * cosCache21 * cosCache37 +
                      input46 * cosCache21 * cosCache38 + input47 * cosCache21 * cosCache39 +
                      input48 * cosCache22 * cosCache32 + input49 * cosCache22 * cosCache33 +
                      input50 * cosCache22 * cosCache34 + input51 * cosCache22 * cosCache35 +
                      input52 * cosCache22 * cosCache36 + input53 * cosCache22 * cosCache37 +
                      input54 * cosCache22 * cosCache38 + input55 * cosCache22 * cosCache39 +
                      input56 * cosCache23 * cosCache32 + input57 * cosCache23 * cosCache33 +
                      input58 * cosCache23 * cosCache34 + input59 * cosCache23 * cosCache35 +
                      input60 * cosCache23 * cosCache36 + input61 * cosCache23 * cosCache37 +
                      input62 * cosCache23 * cosCache38 + input63 * cosCache23 * cosCache39) * Beta;
        result[21] = (input0 * cosCache16 * cosCache40 + input1 * cosCache16 * cosCache41 +
                      input2 * cosCache16 * cosCache42 + input3 * cosCache16 * cosCache43 +
                      input4 * cosCache16 * cosCache44 + input5 * cosCache16 * cosCache45 +
                      input6 * cosCache16 * cosCache46 + input7 * cosCache16 * cosCache47 +
                      input8 * cosCache17 * cosCache40 + input9 * cosCache17 * cosCache41 +
                      input10 * cosCache17 * cosCache42 + input11 * cosCache17 * cosCache43 +
                      input12 * cosCache17 * cosCache44 + input13 * cosCache17 * cosCache45 +
                      input14 * cosCache17 * cosCache46 + input15 * cosCache17 * cosCache47 +
                      input16 * cosCache18 * cosCache40 + input17 * cosCache18 * cosCache41 +
                      input18 * cosCache18 * cosCache42 + input19 * cosCache18 * cosCache43 +
                      input20 * cosCache18 * cosCache44 + input21 * cosCache18 * cosCache45 +
                      input22 * cosCache18 * cosCache46 + input23 * cosCache18 * cosCache47 +
                      input24 * cosCache19 * cosCache40 + input25 * cosCache19 * cosCache41 +
                      input26 * cosCache19 * cosCache42 + input27 * cosCache19 * cosCache43 +
                      input28 * cosCache19 * cosCache44 + input29 * cosCache19 * cosCache45 +
                      input30 * cosCache19 * cosCache46 + input31 * cosCache19 * cosCache47 +
                      input32 * cosCache20 * cosCache40 + input33 * cosCache20 * cosCache41 +
                      input34 * cosCache20 * cosCache42 + input35 * cosCache20 * cosCache43 +
                      input36 * cosCache20 * cosCache44 + input37 * cosCache20 * cosCache45 +
                      input38 * cosCache20 * cosCache46 + input39 * cosCache20 * cosCache47 +
                      input40 * cosCache21 * cosCache40 + input41 * cosCache21 * cosCache41 +
                      input42 * cosCache21 * cosCache42 + input43 * cosCache21 * cosCache43 +
                      input44 * cosCache21 * cosCache44 + input45 * cosCache21 * cosCache45 +
                      input46 * cosCache21 * cosCache46 + input47 * cosCache21 * cosCache47 +
                      input48 * cosCache22 * cosCache40 + input49 * cosCache22 * cosCache41 +
                      input50 * cosCache22 * cosCache42 + input51 * cosCache22 * cosCache43 +
                      input52 * cosCache22 * cosCache44 + input53 * cosCache22 * cosCache45 +
                      input54 * cosCache22 * cosCache46 + input55 * cosCache22 * cosCache47 +
                      input56 * cosCache23 * cosCache40 + input57 * cosCache23 * cosCache41 +
                      input58 * cosCache23 * cosCache42 + input59 * cosCache23 * cosCache43 +
                      input60 * cosCache23 * cosCache44 + input61 * cosCache23 * cosCache45 +
                      input62 * cosCache23 * cosCache46 + input63 * cosCache23 * cosCache47) * Beta;
        result[22] = (input0 * cosCache16 * cosCache48 + input1 * cosCache16 * cosCache49 +
                      input2 * cosCache16 * cosCache50 + input3 * cosCache16 * cosCache51 +
                      input4 * cosCache16 * cosCache52 + input5 * cosCache16 * cosCache53 +
                      input6 * cosCache16 * cosCache54 + input7 * cosCache16 * cosCache55 +
                      input8 * cosCache17 * cosCache48 + input9 * cosCache17 * cosCache49 +
                      input10 * cosCache17 * cosCache50 + input11 * cosCache17 * cosCache51 +
                      input12 * cosCache17 * cosCache52 + input13 * cosCache17 * cosCache53 +
                      input14 * cosCache17 * cosCache54 + input15 * cosCache17 * cosCache55 +
                      input16 * cosCache18 * cosCache48 + input17 * cosCache18 * cosCache49 +
                      input18 * cosCache18 * cosCache50 + input19 * cosCache18 * cosCache51 +
                      input20 * cosCache18 * cosCache52 + input21 * cosCache18 * cosCache53 +
                      input22 * cosCache18 * cosCache54 + input23 * cosCache18 * cosCache55 +
                      input24 * cosCache19 * cosCache48 + input25 * cosCache19 * cosCache49 +
                      input26 * cosCache19 * cosCache50 + input27 * cosCache19 * cosCache51 +
                      input28 * cosCache19 * cosCache52 + input29 * cosCache19 * cosCache53 +
                      input30 * cosCache19 * cosCache54 + input31 * cosCache19 * cosCache55 +
                      input32 * cosCache20 * cosCache48 + input33 * cosCache20 * cosCache49 +
                      input34 * cosCache20 * cosCache50 + input35 * cosCache20 * cosCache51 +
                      input36 * cosCache20 * cosCache52 + input37 * cosCache20 * cosCache53 +
                      input38 * cosCache20 * cosCache54 + input39 * cosCache20 * cosCache55 +
                      input40 * cosCache21 * cosCache48 + input41 * cosCache21 * cosCache49 +
                      input42 * cosCache21 * cosCache50 + input43 * cosCache21 * cosCache51 +
                      input44 * cosCache21 * cosCache52 + input45 * cosCache21 * cosCache53 +
                      input46 * cosCache21 * cosCache54 + input47 * cosCache21 * cosCache55 +
                      input48 * cosCache22 * cosCache48 + input49 * cosCache22 * cosCache49 +
                      input50 * cosCache22 * cosCache50 + input51 * cosCache22 * cosCache51 +
                      input52 * cosCache22 * cosCache52 + input53 * cosCache22 * cosCache53 +
                      input54 * cosCache22 * cosCache54 + input55 * cosCache22 * cosCache55 +
                      input56 * cosCache23 * cosCache48 + input57 * cosCache23 * cosCache49 +
                      input58 * cosCache23 * cosCache50 + input59 * cosCache23 * cosCache51 +
                      input60 * cosCache23 * cosCache52 + input61 * cosCache23 * cosCache53 +
                      input62 * cosCache23 * cosCache54 + input63 * cosCache23 * cosCache55) * Beta;
        result[23] = (input0 * cosCache16 * cosCache56 + input1 * cosCache16 * cosCache57 +
                      input2 * cosCache16 * cosCache58 + input3 * cosCache16 * cosCache59 +
                      input4 * cosCache16 * cosCache60 + input5 * cosCache16 * cosCache61 +
                      input6 * cosCache16 * cosCache62 + input7 * cosCache16 * cosCache63 +
                      input8 * cosCache17 * cosCache56 + input9 * cosCache17 * cosCache57 +
                      input10 * cosCache17 * cosCache58 + input11 * cosCache17 * cosCache59 +
                      input12 * cosCache17 * cosCache60 + input13 * cosCache17 * cosCache61 +
                      input14 * cosCache17 * cosCache62 + input15 * cosCache17 * cosCache63 +
                      input16 * cosCache18 * cosCache56 + input17 * cosCache18 * cosCache57 +
                      input18 * cosCache18 * cosCache58 + input19 * cosCache18 * cosCache59 +
                      input20 * cosCache18 * cosCache60 + input21 * cosCache18 * cosCache61 +
                      input22 * cosCache18 * cosCache62 + input23 * cosCache18 * cosCache63 +
                      input24 * cosCache19 * cosCache56 + input25 * cosCache19 * cosCache57 +
                      input26 * cosCache19 * cosCache58 + input27 * cosCache19 * cosCache59 +
                      input28 * cosCache19 * cosCache60 + input29 * cosCache19 * cosCache61 +
                      input30 * cosCache19 * cosCache62 + input31 * cosCache19 * cosCache63 +
                      input32 * cosCache20 * cosCache56 + input33 * cosCache20 * cosCache57 +
                      input34 * cosCache20 * cosCache58 + input35 * cosCache20 * cosCache59 +
                      input36 * cosCache20 * cosCache60 + input37 * cosCache20 * cosCache61 +
                      input38 * cosCache20 * cosCache62 + input39 * cosCache20 * cosCache63 +
                      input40 * cosCache21 * cosCache56 + input41 * cosCache21 * cosCache57 +
                      input42 * cosCache21 * cosCache58 + input43 * cosCache21 * cosCache59 +
                      input44 * cosCache21 * cosCache60 + input45 * cosCache21 * cosCache61 +
                      input46 * cosCache21 * cosCache62 + input47 * cosCache21 * cosCache63 +
                      input48 * cosCache22 * cosCache56 + input49 * cosCache22 * cosCache57 +
                      input50 * cosCache22 * cosCache58 + input51 * cosCache22 * cosCache59 +
                      input52 * cosCache22 * cosCache60 + input53 * cosCache22 * cosCache61 +
                      input54 * cosCache22 * cosCache62 + input55 * cosCache22 * cosCache63 +
                      input56 * cosCache23 * cosCache56 + input57 * cosCache23 * cosCache57 +
                      input58 * cosCache23 * cosCache58 + input59 * cosCache23 * cosCache59 +
                      input60 * cosCache23 * cosCache60 + input61 * cosCache23 * cosCache61 +
                      input62 * cosCache23 * cosCache62 + input63 * cosCache23 * cosCache63) * Beta;
        result[24] = (input0 * cosCache24 + input1 * cosCache24 + input2 * cosCache24 + input3 * cosCache24 +
                      input4 * cosCache24 + input5 * cosCache24 + input6 * cosCache24 + input7 * cosCache24 +
                      input8 * cosCache25 + input9 * cosCache25 + input10 * cosCache25 + input11 * cosCache25 +
                      input12 * cosCache25 + input13 * cosCache25 + input14 * cosCache25 + input15 * cosCache25 +
                      input16 * cosCache26 + input17 * cosCache26 + input18 * cosCache26 + input19 * cosCache26 +
                      input20 * cosCache26 + input21 * cosCache26 + input22 * cosCache26 + input23 * cosCache26 +
                      input24 * cosCache27 + input25 * cosCache27 + input26 * cosCache27 + input27 * cosCache27 +
                      input28 * cosCache27 + input29 * cosCache27 + input30 * cosCache27 + input31 * cosCache27 +
                      input32 * cosCache28 + input33 * cosCache28 + input34 * cosCache28 + input35 * cosCache28 +
                      input36 * cosCache28 + input37 * cosCache28 + input38 * cosCache28 + input39 * cosCache28 +
                      input40 * cosCache29 + input41 * cosCache29 + input42 * cosCache29 + input43 * cosCache29 +
                      input44 * cosCache29 + input45 * cosCache29 + input46 * cosCache29 + input47 * cosCache29 +
                      input48 * cosCache30 + input49 * cosCache30 + input50 * cosCache30 + input51 * cosCache30 +
                      input52 * cosCache30 + input53 * cosCache30 + input54 * cosCache30 + input55 * cosCache30 +
                      input56 * cosCache31 + input57 * cosCache31 + input58 * cosCache31 + input59 * cosCache31 +
                      input60 * cosCache31 + input61 * cosCache31 + input62 * cosCache31 + input63 * cosCache31) *
                     Beta * Alpha;
        result[25] = (input0 * cosCache24 * cosCache8 + input1 * cosCache24 * cosCache9 +
                      input2 * cosCache24 * cosCache10 + input3 * cosCache24 * cosCache11 +
                      input4 * cosCache24 * cosCache12 + input5 * cosCache24 * cosCache13 +
                      input6 * cosCache24 * cosCache14 + input7 * cosCache24 * cosCache15 +
                      input8 * cosCache25 * cosCache8 + input9 * cosCache25 * cosCache9 +
                      input10 * cosCache25 * cosCache10 + input11 * cosCache25 * cosCache11 +
                      input12 * cosCache25 * cosCache12 + input13 * cosCache25 * cosCache13 +
                      input14 * cosCache25 * cosCache14 + input15 * cosCache25 * cosCache15 +
                      input16 * cosCache26 * cosCache8 + input17 * cosCache26 * cosCache9 +
                      input18 * cosCache26 * cosCache10 + input19 * cosCache26 * cosCache11 +
                      input20 * cosCache26 * cosCache12 + input21 * cosCache26 * cosCache13 +
                      input22 * cosCache26 * cosCache14 + input23 * cosCache26 * cosCache15 +
                      input24 * cosCache27 * cosCache8 + input25 * cosCache27 * cosCache9 +
                      input26 * cosCache27 * cosCache10 + input27 * cosCache27 * cosCache11 +
                      input28 * cosCache27 * cosCache12 + input29 * cosCache27 * cosCache13 +
                      input30 * cosCache27 * cosCache14 + input31 * cosCache27 * cosCache15 +
                      input32 * cosCache28 * cosCache8 + input33 * cosCache28 * cosCache9 +
                      input34 * cosCache28 * cosCache10 + input35 * cosCache28 * cosCache11 +
                      input36 * cosCache28 * cosCache12 + input37 * cosCache28 * cosCache13 +
                      input38 * cosCache28 * cosCache14 + input39 * cosCache28 * cosCache15 +
                      input40 * cosCache29 * cosCache8 + input41 * cosCache29 * cosCache9 +
                      input42 * cosCache29 * cosCache10 + input43 * cosCache29 * cosCache11 +
                      input44 * cosCache29 * cosCache12 + input45 * cosCache29 * cosCache13 +
                      input46 * cosCache29 * cosCache14 + input47 * cosCache29 * cosCache15 +
                      input48 * cosCache30 * cosCache8 + input49 * cosCache30 * cosCache9 +
                      input50 * cosCache30 * cosCache10 + input51 * cosCache30 * cosCache11 +
                      input52 * cosCache30 * cosCache12 + input53 * cosCache30 * cosCache13 +
                      input54 * cosCache30 * cosCache14 + input55 * cosCache30 * cosCache15 +
                      input56 * cosCache31 * cosCache8 + input57 * cosCache31 * cosCache9 +
                      input58 * cosCache31 * cosCache10 + input59 * cosCache31 * cosCache11 +
                      input60 * cosCache31 * cosCache12 + input61 * cosCache31 * cosCache13 +
                      input62 * cosCache31 * cosCache14 + input63 * cosCache31 * cosCache15) * Beta;
        result[26] = (input0 * cosCache24 * cosCache16 + input1 * cosCache24 * cosCache17 +
                      input2 * cosCache24 * cosCache18 + input3 * cosCache24 * cosCache19 +
                      input4 * cosCache24 * cosCache20 + input5 * cosCache24 * cosCache21 +
                      input6 * cosCache24 * cosCache22 + input7 * cosCache24 * cosCache23 +
                      input8 * cosCache25 * cosCache16 + input9 * cosCache25 * cosCache17 +
                      input10 * cosCache25 * cosCache18 + input11 * cosCache25 * cosCache19 +
                      input12 * cosCache25 * cosCache20 + input13 * cosCache25 * cosCache21 +
                      input14 * cosCache25 * cosCache22 + input15 * cosCache25 * cosCache23 +
                      input16 * cosCache26 * cosCache16 + input17 * cosCache26 * cosCache17 +
                      input18 * cosCache26 * cosCache18 + input19 * cosCache26 * cosCache19 +
                      input20 * cosCache26 * cosCache20 + input21 * cosCache26 * cosCache21 +
                      input22 * cosCache26 * cosCache22 + input23 * cosCache26 * cosCache23 +
                      input24 * cosCache27 * cosCache16 + input25 * cosCache27 * cosCache17 +
                      input26 * cosCache27 * cosCache18 + input27 * cosCache27 * cosCache19 +
                      input28 * cosCache27 * cosCache20 + input29 * cosCache27 * cosCache21 +
                      input30 * cosCache27 * cosCache22 + input31 * cosCache27 * cosCache23 +
                      input32 * cosCache28 * cosCache16 + input33 * cosCache28 * cosCache17 +
                      input34 * cosCache28 * cosCache18 + input35 * cosCache28 * cosCache19 +
                      input36 * cosCache28 * cosCache20 + input37 * cosCache28 * cosCache21 +
                      input38 * cosCache28 * cosCache22 + input39 * cosCache28 * cosCache23 +
                      input40 * cosCache29 * cosCache16 + input41 * cosCache29 * cosCache17 +
                      input42 * cosCache29 * cosCache18 + input43 * cosCache29 * cosCache19 +
                      input44 * cosCache29 * cosCache20 + input45 * cosCache29 * cosCache21 +
                      input46 * cosCache29 * cosCache22 + input47 * cosCache29 * cosCache23 +
                      input48 * cosCache30 * cosCache16 + input49 * cosCache30 * cosCache17 +
                      input50 * cosCache30 * cosCache18 + input51 * cosCache30 * cosCache19 +
                      input52 * cosCache30 * cosCache20 + input53 * cosCache30 * cosCache21 +
                      input54 * cosCache30 * cosCache22 + input55 * cosCache30 * cosCache23 +
                      input56 * cosCache31 * cosCache16 + input57 * cosCache31 * cosCache17 +
                      input58 * cosCache31 * cosCache18 + input59 * cosCache31 * cosCache19 +
                      input60 * cosCache31 * cosCache20 + input61 * cosCache31 * cosCache21 +
                      input62 * cosCache31 * cosCache22 + input63 * cosCache31 * cosCache23) * Beta;
        result[27] = (input0 * cosCache24 * cosCache24 + input1 * cosCache24 * cosCache25 +
                      input2 * cosCache24 * cosCache26 + input3 * cosCache24 * cosCache27 +
                      input4 * cosCache24 * cosCache28 + input5 * cosCache24 * cosCache29 +
                      input6 * cosCache24 * cosCache30 + input7 * cosCache24 * cosCache31 +
                      input8 * cosCache25 * cosCache24 + input9 * cosCache25 * cosCache25 +
                      input10 * cosCache25 * cosCache26 + input11 * cosCache25 * cosCache27 +
                      input12 * cosCache25 * cosCache28 + input13 * cosCache25 * cosCache29 +
                      input14 * cosCache25 * cosCache30 + input15 * cosCache25 * cosCache31 +
                      input16 * cosCache26 * cosCache24 + input17 * cosCache26 * cosCache25 +
                      input18 * cosCache26 * cosCache26 + input19 * cosCache26 * cosCache27 +
                      input20 * cosCache26 * cosCache28 + input21 * cosCache26 * cosCache29 +
                      input22 * cosCache26 * cosCache30 + input23 * cosCache26 * cosCache31 +
                      input24 * cosCache27 * cosCache24 + input25 * cosCache27 * cosCache25 +
                      input26 * cosCache27 * cosCache26 + input27 * cosCache27 * cosCache27 +
                      input28 * cosCache27 * cosCache28 + input29 * cosCache27 * cosCache29 +
                      input30 * cosCache27 * cosCache30 + input31 * cosCache27 * cosCache31 +
                      input32 * cosCache28 * cosCache24 + input33 * cosCache28 * cosCache25 +
                      input34 * cosCache28 * cosCache26 + input35 * cosCache28 * cosCache27 +
                      input36 * cosCache28 * cosCache28 + input37 * cosCache28 * cosCache29 +
                      input38 * cosCache28 * cosCache30 + input39 * cosCache28 * cosCache31 +
                      input40 * cosCache29 * cosCache24 + input41 * cosCache29 * cosCache25 +
                      input42 * cosCache29 * cosCache26 + input43 * cosCache29 * cosCache27 +
                      input44 * cosCache29 * cosCache28 + input45 * cosCache29 * cosCache29 +
                      input46 * cosCache29 * cosCache30 + input47 * cosCache29 * cosCache31 +
                      input48 * cosCache30 * cosCache24 + input49 * cosCache30 * cosCache25 +
                      input50 * cosCache30 * cosCache26 + input51 * cosCache30 * cosCache27 +
                      input52 * cosCache30 * cosCache28 + input53 * cosCache30 * cosCache29 +
                      input54 * cosCache30 * cosCache30 + input55 * cosCache30 * cosCache31 +
                      input56 * cosCache31 * cosCache24 + input57 * cosCache31 * cosCache25 +
                      input58 * cosCache31 * cosCache26 + input59 * cosCache31 * cosCache27 +
                      input60 * cosCache31 * cosCache28 + input61 * cosCache31 * cosCache29 +
                      input62 * cosCache31 * cosCache30 + input63 * cosCache31 * cosCache31) * Beta;
        result[28] = (input0 * cosCache24 * cosCache32 + input1 * cosCache24 * cosCache33 +
                      input2 * cosCache24 * cosCache34 + input3 * cosCache24 * cosCache35 +
                      input4 * cosCache24 * cosCache36 + input5 * cosCache24 * cosCache37 +
                      input6 * cosCache24 * cosCache38 + input7 * cosCache24 * cosCache39 +
                      input8 * cosCache25 * cosCache32 + input9 * cosCache25 * cosCache33 +
                      input10 * cosCache25 * cosCache34 + input11 * cosCache25 * cosCache35 +
                      input12 * cosCache25 * cosCache36 + input13 * cosCache25 * cosCache37 +
                      input14 * cosCache25 * cosCache38 + input15 * cosCache25 * cosCache39 +
                      input16 * cosCache26 * cosCache32 + input17 * cosCache26 * cosCache33 +
                      input18 * cosCache26 * cosCache34 + input19 * cosCache26 * cosCache35 +
                      input20 * cosCache26 * cosCache36 + input21 * cosCache26 * cosCache37 +
                      input22 * cosCache26 * cosCache38 + input23 * cosCache26 * cosCache39 +
                      input24 * cosCache27 * cosCache32 + input25 * cosCache27 * cosCache33 +
                      input26 * cosCache27 * cosCache34 + input27 * cosCache27 * cosCache35 +
                      input28 * cosCache27 * cosCache36 + input29 * cosCache27 * cosCache37 +
                      input30 * cosCache27 * cosCache38 + input31 * cosCache27 * cosCache39 +
                      input32 * cosCache28 * cosCache32 + input33 * cosCache28 * cosCache33 +
                      input34 * cosCache28 * cosCache34 + input35 * cosCache28 * cosCache35 +
                      input36 * cosCache28 * cosCache36 + input37 * cosCache28 * cosCache37 +
                      input38 * cosCache28 * cosCache38 + input39 * cosCache28 * cosCache39 +
                      input40 * cosCache29 * cosCache32 + input41 * cosCache29 * cosCache33 +
                      input42 * cosCache29 * cosCache34 + input43 * cosCache29 * cosCache35 +
                      input44 * cosCache29 * cosCache36 + input45 * cosCache29 * cosCache37 +
                      input46 * cosCache29 * cosCache38 + input47 * cosCache29 * cosCache39 +
                      input48 * cosCache30 * cosCache32 + input49 * cosCache30 * cosCache33 +
                      input50 * cosCache30 * cosCache34 + input51 * cosCache30 * cosCache35 +
                      input52 * cosCache30 * cosCache36 + input53 * cosCache30 * cosCache37 +
                      input54 * cosCache30 * cosCache38 + input55 * cosCache30 * cosCache39 +
                      input56 * cosCache31 * cosCache32 + input57 * cosCache31 * cosCache33 +
                      input58 * cosCache31 * cosCache34 + input59 * cosCache31 * cosCache35 +
                      input60 * cosCache31 * cosCache36 + input61 * cosCache31 * cosCache37 +
                      input62 * cosCache31 * cosCache38 + input63 * cosCache31 * cosCache39) * Beta;
        result[29] = (input0 * cosCache24 * cosCache40 + input1 * cosCache24 * cosCache41 +
                      input2 * cosCache24 * cosCache42 + input3 * cosCache24 * cosCache43 +
                      input4 * cosCache24 * cosCache44 + input5 * cosCache24 * cosCache45 +
                      input6 * cosCache24 * cosCache46 + input7 * cosCache24 * cosCache47 +
                      input8 * cosCache25 * cosCache40 + input9 * cosCache25 * cosCache41 +
                      input10 * cosCache25 * cosCache42 + input11 * cosCache25 * cosCache43 +
                      input12 * cosCache25 * cosCache44 + input13 * cosCache25 * cosCache45 +
                      input14 * cosCache25 * cosCache46 + input15 * cosCache25 * cosCache47 +
                      input16 * cosCache26 * cosCache40 + input17 * cosCache26 * cosCache41 +
                      input18 * cosCache26 * cosCache42 + input19 * cosCache26 * cosCache43 +
                      input20 * cosCache26 * cosCache44 + input21 * cosCache26 * cosCache45 +
                      input22 * cosCache26 * cosCache46 + input23 * cosCache26 * cosCache47 +
                      input24 * cosCache27 * cosCache40 + input25 * cosCache27 * cosCache41 +
                      input26 * cosCache27 * cosCache42 + input27 * cosCache27 * cosCache43 +
                      input28 * cosCache27 * cosCache44 + input29 * cosCache27 * cosCache45 +
                      input30 * cosCache27 * cosCache46 + input31 * cosCache27 * cosCache47 +
                      input32 * cosCache28 * cosCache40 + input33 * cosCache28 * cosCache41 +
                      input34 * cosCache28 * cosCache42 + input35 * cosCache28 * cosCache43 +
                      input36 * cosCache28 * cosCache44 + input37 * cosCache28 * cosCache45 +
                      input38 * cosCache28 * cosCache46 + input39 * cosCache28 * cosCache47 +
                      input40 * cosCache29 * cosCache40 + input41 * cosCache29 * cosCache41 +
                      input42 * cosCache29 * cosCache42 + input43 * cosCache29 * cosCache43 +
                      input44 * cosCache29 * cosCache44 + input45 * cosCache29 * cosCache45 +
                      input46 * cosCache29 * cosCache46 + input47 * cosCache29 * cosCache47 +
                      input48 * cosCache30 * cosCache40 + input49 * cosCache30 * cosCache41 +
                      input50 * cosCache30 * cosCache42 + input51 * cosCache30 * cosCache43 +
                      input52 * cosCache30 * cosCache44 + input53 * cosCache30 * cosCache45 +
                      input54 * cosCache30 * cosCache46 + input55 * cosCache30 * cosCache47 +
                      input56 * cosCache31 * cosCache40 + input57 * cosCache31 * cosCache41 +
                      input58 * cosCache31 * cosCache42 + input59 * cosCache31 * cosCache43 +
                      input60 * cosCache31 * cosCache44 + input61 * cosCache31 * cosCache45 +
                      input62 * cosCache31 * cosCache46 + input63 * cosCache31 * cosCache47) * Beta;
        result[30] = (input0 * cosCache24 * cosCache48 + input1 * cosCache24 * cosCache49 +
                      input2 * cosCache24 * cosCache50 + input3 * cosCache24 * cosCache51 +
                      input4 * cosCache24 * cosCache52 + input5 * cosCache24 * cosCache53 +
                      input6 * cosCache24 * cosCache54 + input7 * cosCache24 * cosCache55 +
                      input8 * cosCache25 * cosCache48 + input9 * cosCache25 * cosCache49 +
                      input10 * cosCache25 * cosCache50 + input11 * cosCache25 * cosCache51 +
                      input12 * cosCache25 * cosCache52 + input13 * cosCache25 * cosCache53 +
                      input14 * cosCache25 * cosCache54 + input15 * cosCache25 * cosCache55 +
                      input16 * cosCache26 * cosCache48 + input17 * cosCache26 * cosCache49 +
                      input18 * cosCache26 * cosCache50 + input19 * cosCache26 * cosCache51 +
                      input20 * cosCache26 * cosCache52 + input21 * cosCache26 * cosCache53 +
                      input22 * cosCache26 * cosCache54 + input23 * cosCache26 * cosCache55 +
                      input24 * cosCache27 * cosCache48 + input25 * cosCache27 * cosCache49 +
                      input26 * cosCache27 * cosCache50 + input27 * cosCache27 * cosCache51 +
                      input28 * cosCache27 * cosCache52 + input29 * cosCache27 * cosCache53 +
                      input30 * cosCache27 * cosCache54 + input31 * cosCache27 * cosCache55 +
                      input32 * cosCache28 * cosCache48 + input33 * cosCache28 * cosCache49 +
                      input34 * cosCache28 * cosCache50 + input35 * cosCache28 * cosCache51 +
                      input36 * cosCache28 * cosCache52 + input37 * cosCache28 * cosCache53 +
                      input38 * cosCache28 * cosCache54 + input39 * cosCache28 * cosCache55 +
                      input40 * cosCache29 * cosCache48 + input41 * cosCache29 * cosCache49 +
                      input42 * cosCache29 * cosCache50 + input43 * cosCache29 * cosCache51 +
                      input44 * cosCache29 * cosCache52 + input45 * cosCache29 * cosCache53 +
                      input46 * cosCache29 * cosCache54 + input47 * cosCache29 * cosCache55 +
                      input48 * cosCache30 * cosCache48 + input49 * cosCache30 * cosCache49 +
                      input50 * cosCache30 * cosCache50 + input51 * cosCache30 * cosCache51 +
                      input52 * cosCache30 * cosCache52 + input53 * cosCache30 * cosCache53 +
                      input54 * cosCache30 * cosCache54 + input55 * cosCache30 * cosCache55 +
                      input56 * cosCache31 * cosCache48 + input57 * cosCache31 * cosCache49 +
                      input58 * cosCache31 * cosCache50 + input59 * cosCache31 * cosCache51 +
                      input60 * cosCache31 * cosCache52 + input61 * cosCache31 * cosCache53 +
                      input62 * cosCache31 * cosCache54 + input63 * cosCache31 * cosCache55) * Beta;
        result[31] = (input0 * cosCache24 * cosCache56 + input1 * cosCache24 * cosCache57 +
                      input2 * cosCache24 * cosCache58 + input3 * cosCache24 * cosCache59 +
                      input4 * cosCache24 * cosCache60 + input5 * cosCache24 * cosCache61 +
                      input6 * cosCache24 * cosCache62 + input7 * cosCache24 * cosCache63 +
                      input8 * cosCache25 * cosCache56 + input9 * cosCache25 * cosCache57 +
                      input10 * cosCache25 * cosCache58 + input11 * cosCache25 * cosCache59 +
                      input12 * cosCache25 * cosCache60 + input13 * cosCache25 * cosCache61 +
                      input14 * cosCache25 * cosCache62 + input15 * cosCache25 * cosCache63 +
                      input16 * cosCache26 * cosCache56 + input17 * cosCache26 * cosCache57 +
                      input18 * cosCache26 * cosCache58 + input19 * cosCache26 * cosCache59 +
                      input20 * cosCache26 * cosCache60 + input21 * cosCache26 * cosCache61 +
                      input22 * cosCache26 * cosCache62 + input23 * cosCache26 * cosCache63 +
                      input24 * cosCache27 * cosCache56 + input25 * cosCache27 * cosCache57 +
                      input26 * cosCache27 * cosCache58 + input27 * cosCache27 * cosCache59 +
                      input28 * cosCache27 * cosCache60 + input29 * cosCache27 * cosCache61 +
                      input30 * cosCache27 * cosCache62 + input31 * cosCache27 * cosCache63 +
                      input32 * cosCache28 * cosCache56 + input33 * cosCache28 * cosCache57 +
                      input34 * cosCache28 * cosCache58 + input35 * cosCache28 * cosCache59 +
                      input36 * cosCache28 * cosCache60 + input37 * cosCache28 * cosCache61 +
                      input38 * cosCache28 * cosCache62 + input39 * cosCache28 * cosCache63 +
                      input40 * cosCache29 * cosCache56 + input41 * cosCache29 * cosCache57 +
                      input42 * cosCache29 * cosCache58 + input43 * cosCache29 * cosCache59 +
                      input44 * cosCache29 * cosCache60 + input45 * cosCache29 * cosCache61 +
                      input46 * cosCache29 * cosCache62 + input47 * cosCache29 * cosCache63 +
                      input48 * cosCache30 * cosCache56 + input49 * cosCache30 * cosCache57 +
                      input50 * cosCache30 * cosCache58 + input51 * cosCache30 * cosCache59 +
                      input52 * cosCache30 * cosCache60 + input53 * cosCache30 * cosCache61 +
                      input54 * cosCache30 * cosCache62 + input55 * cosCache30 * cosCache63 +
                      input56 * cosCache31 * cosCache56 + input57 * cosCache31 * cosCache57 +
                      input58 * cosCache31 * cosCache58 + input59 * cosCache31 * cosCache59 +
                      input60 * cosCache31 * cosCache60 + input61 * cosCache31 * cosCache61 +
                      input62 * cosCache31 * cosCache62 + input63 * cosCache31 * cosCache63) * Beta;
        result[32] = (input0 * cosCache32 + input1 * cosCache32 + input2 * cosCache32 + input3 * cosCache32 +
                      input4 * cosCache32 + input5 * cosCache32 + input6 * cosCache32 + input7 * cosCache32 +
                      input8 * cosCache33 + input9 * cosCache33 + input10 * cosCache33 + input11 * cosCache33 +
                      input12 * cosCache33 + input13 * cosCache33 + input14 * cosCache33 + input15 * cosCache33 +
                      input16 * cosCache34 + input17 * cosCache34 + input18 * cosCache34 + input19 * cosCache34 +
                      input20 * cosCache34 + input21 * cosCache34 + input22 * cosCache34 + input23 * cosCache34 +
                      input24 * cosCache35 + input25 * cosCache35 + input26 * cosCache35 + input27 * cosCache35 +
                      input28 * cosCache35 + input29 * cosCache35 + input30 * cosCache35 + input31 * cosCache35 +
                      input32 * cosCache36 + input33 * cosCache36 + input34 * cosCache36 + input35 * cosCache36 +
                      input36 * cosCache36 + input37 * cosCache36 + input38 * cosCache36 + input39 * cosCache36 +
                      input40 * cosCache37 + input41 * cosCache37 + input42 * cosCache37 + input43 * cosCache37 +
                      input44 * cosCache37 + input45 * cosCache37 + input46 * cosCache37 + input47 * cosCache37 +
                      input48 * cosCache38 + input49 * cosCache38 + input50 * cosCache38 + input51 * cosCache38 +
                      input52 * cosCache38 + input53 * cosCache38 + input54 * cosCache38 + input55 * cosCache38 +
                      input56 * cosCache39 + input57 * cosCache39 + input58 * cosCache39 + input59 * cosCache39 +
                      input60 * cosCache39 + input61 * cosCache39 + input62 * cosCache39 + input63 * cosCache39) *
                     Beta * Alpha;
        result[33] = (input0 * cosCache32 * cosCache8 + input1 * cosCache32 * cosCache9 +
                      input2 * cosCache32 * cosCache10 + input3 * cosCache32 * cosCache11 +
                      input4 * cosCache32 * cosCache12 + input5 * cosCache32 * cosCache13 +
                      input6 * cosCache32 * cosCache14 + input7 * cosCache32 * cosCache15 +
                      input8 * cosCache33 * cosCache8 + input9 * cosCache33 * cosCache9 +
                      input10 * cosCache33 * cosCache10 + input11 * cosCache33 * cosCache11 +
                      input12 * cosCache33 * cosCache12 + input13 * cosCache33 * cosCache13 +
                      input14 * cosCache33 * cosCache14 + input15 * cosCache33 * cosCache15 +
                      input16 * cosCache34 * cosCache8 + input17 * cosCache34 * cosCache9 +
                      input18 * cosCache34 * cosCache10 + input19 * cosCache34 * cosCache11 +
                      input20 * cosCache34 * cosCache12 + input21 * cosCache34 * cosCache13 +
                      input22 * cosCache34 * cosCache14 + input23 * cosCache34 * cosCache15 +
                      input24 * cosCache35 * cosCache8 + input25 * cosCache35 * cosCache9 +
                      input26 * cosCache35 * cosCache10 + input27 * cosCache35 * cosCache11 +
                      input28 * cosCache35 * cosCache12 + input29 * cosCache35 * cosCache13 +
                      input30 * cosCache35 * cosCache14 + input31 * cosCache35 * cosCache15 +
                      input32 * cosCache36 * cosCache8 + input33 * cosCache36 * cosCache9 +
                      input34 * cosCache36 * cosCache10 + input35 * cosCache36 * cosCache11 +
                      input36 * cosCache36 * cosCache12 + input37 * cosCache36 * cosCache13 +
                      input38 * cosCache36 * cosCache14 + input39 * cosCache36 * cosCache15 +
                      input40 * cosCache37 * cosCache8 + input41 * cosCache37 * cosCache9 +
                      input42 * cosCache37 * cosCache10 + input43 * cosCache37 * cosCache11 +
                      input44 * cosCache37 * cosCache12 + input45 * cosCache37 * cosCache13 +
                      input46 * cosCache37 * cosCache14 + input47 * cosCache37 * cosCache15 +
                      input48 * cosCache38 * cosCache8 + input49 * cosCache38 * cosCache9 +
                      input50 * cosCache38 * cosCache10 + input51 * cosCache38 * cosCache11 +
                      input52 * cosCache38 * cosCache12 + input53 * cosCache38 * cosCache13 +
                      input54 * cosCache38 * cosCache14 + input55 * cosCache38 * cosCache15 +
                      input56 * cosCache39 * cosCache8 + input57 * cosCache39 * cosCache9 +
                      input58 * cosCache39 * cosCache10 + input59 * cosCache39 * cosCache11 +
                      input60 * cosCache39 * cosCache12 + input61 * cosCache39 * cosCache13 +
                      input62 * cosCache39 * cosCache14 + input63 * cosCache39 * cosCache15) * Beta;
        result[34] = (input0 * cosCache32 * cosCache16 + input1 * cosCache32 * cosCache17 +
                      input2 * cosCache32 * cosCache18 + input3 * cosCache32 * cosCache19 +
                      input4 * cosCache32 * cosCache20 + input5 * cosCache32 * cosCache21 +
                      input6 * cosCache32 * cosCache22 + input7 * cosCache32 * cosCache23 +
                      input8 * cosCache33 * cosCache16 + input9 * cosCache33 * cosCache17 +
                      input10 * cosCache33 * cosCache18 + input11 * cosCache33 * cosCache19 +
                      input12 * cosCache33 * cosCache20 + input13 * cosCache33 * cosCache21 +
                      input14 * cosCache33 * cosCache22 + input15 * cosCache33 * cosCache23 +
                      input16 * cosCache34 * cosCache16 + input17 * cosCache34 * cosCache17 +
                      input18 * cosCache34 * cosCache18 + input19 * cosCache34 * cosCache19 +
                      input20 * cosCache34 * cosCache20 + input21 * cosCache34 * cosCache21 +
                      input22 * cosCache34 * cosCache22 + input23 * cosCache34 * cosCache23 +
                      input24 * cosCache35 * cosCache16 + input25 * cosCache35 * cosCache17 +
                      input26 * cosCache35 * cosCache18 + input27 * cosCache35 * cosCache19 +
                      input28 * cosCache35 * cosCache20 + input29 * cosCache35 * cosCache21 +
                      input30 * cosCache35 * cosCache22 + input31 * cosCache35 * cosCache23 +
                      input32 * cosCache36 * cosCache16 + input33 * cosCache36 * cosCache17 +
                      input34 * cosCache36 * cosCache18 + input35 * cosCache36 * cosCache19 +
                      input36 * cosCache36 * cosCache20 + input37 * cosCache36 * cosCache21 +
                      input38 * cosCache36 * cosCache22 + input39 * cosCache36 * cosCache23 +
                      input40 * cosCache37 * cosCache16 + input41 * cosCache37 * cosCache17 +
                      input42 * cosCache37 * cosCache18 + input43 * cosCache37 * cosCache19 +
                      input44 * cosCache37 * cosCache20 + input45 * cosCache37 * cosCache21 +
                      input46 * cosCache37 * cosCache22 + input47 * cosCache37 * cosCache23 +
                      input48 * cosCache38 * cosCache16 + input49 * cosCache38 * cosCache17 +
                      input50 * cosCache38 * cosCache18 + input51 * cosCache38 * cosCache19 +
                      input52 * cosCache38 * cosCache20 + input53 * cosCache38 * cosCache21 +
                      input54 * cosCache38 * cosCache22 + input55 * cosCache38 * cosCache23 +
                      input56 * cosCache39 * cosCache16 + input57 * cosCache39 * cosCache17 +
                      input58 * cosCache39 * cosCache18 + input59 * cosCache39 * cosCache19 +
                      input60 * cosCache39 * cosCache20 + input61 * cosCache39 * cosCache21 +
                      input62 * cosCache39 * cosCache22 + input63 * cosCache39 * cosCache23) * Beta;
        result[35] = (input0 * cosCache32 * cosCache24 + input1 * cosCache32 * cosCache25 +
                      input2 * cosCache32 * cosCache26 + input3 * cosCache32 * cosCache27 +
                      input4 * cosCache32 * cosCache28 + input5 * cosCache32 * cosCache29 +
                      input6 * cosCache32 * cosCache30 + input7 * cosCache32 * cosCache31 +
                      input8 * cosCache33 * cosCache24 + input9 * cosCache33 * cosCache25 +
                      input10 * cosCache33 * cosCache26 + input11 * cosCache33 * cosCache27 +
                      input12 * cosCache33 * cosCache28 + input13 * cosCache33 * cosCache29 +
                      input14 * cosCache33 * cosCache30 + input15 * cosCache33 * cosCache31 +
                      input16 * cosCache34 * cosCache24 + input17 * cosCache34 * cosCache25 +
                      input18 * cosCache34 * cosCache26 + input19 * cosCache34 * cosCache27 +
                      input20 * cosCache34 * cosCache28 + input21 * cosCache34 * cosCache29 +
                      input22 * cosCache34 * cosCache30 + input23 * cosCache34 * cosCache31 +
                      input24 * cosCache35 * cosCache24 + input25 * cosCache35 * cosCache25 +
                      input26 * cosCache35 * cosCache26 + input27 * cosCache35 * cosCache27 +
                      input28 * cosCache35 * cosCache28 + input29 * cosCache35 * cosCache29 +
                      input30 * cosCache35 * cosCache30 + input31 * cosCache35 * cosCache31 +
                      input32 * cosCache36 * cosCache24 + input33 * cosCache36 * cosCache25 +
                      input34 * cosCache36 * cosCache26 + input35 * cosCache36 * cosCache27 +
                      input36 * cosCache36 * cosCache28 + input37 * cosCache36 * cosCache29 +
                      input38 * cosCache36 * cosCache30 + input39 * cosCache36 * cosCache31 +
                      input40 * cosCache37 * cosCache24 + input41 * cosCache37 * cosCache25 +
                      input42 * cosCache37 * cosCache26 + input43 * cosCache37 * cosCache27 +
                      input44 * cosCache37 * cosCache28 + input45 * cosCache37 * cosCache29 +
                      input46 * cosCache37 * cosCache30 + input47 * cosCache37 * cosCache31 +
                      input48 * cosCache38 * cosCache24 + input49 * cosCache38 * cosCache25 +
                      input50 * cosCache38 * cosCache26 + input51 * cosCache38 * cosCache27 +
                      input52 * cosCache38 * cosCache28 + input53 * cosCache38 * cosCache29 +
                      input54 * cosCache38 * cosCache30 + input55 * cosCache38 * cosCache31 +
                      input56 * cosCache39 * cosCache24 + input57 * cosCache39 * cosCache25 +
                      input58 * cosCache39 * cosCache26 + input59 * cosCache39 * cosCache27 +
                      input60 * cosCache39 * cosCache28 + input61 * cosCache39 * cosCache29 +
                      input62 * cosCache39 * cosCache30 + input63 * cosCache39 * cosCache31) * Beta;
        result[36] = (input0 * cosCache32 * cosCache32 + input1 * cosCache32 * cosCache33 +
                      input2 * cosCache32 * cosCache34 + input3 * cosCache32 * cosCache35 +
                      input4 * cosCache32 * cosCache36 + input5 * cosCache32 * cosCache37 +
                      input6 * cosCache32 * cosCache38 + input7 * cosCache32 * cosCache39 +
                      input8 * cosCache33 * cosCache32 + input9 * cosCache33 * cosCache33 +
                      input10 * cosCache33 * cosCache34 + input11 * cosCache33 * cosCache35 +
                      input12 * cosCache33 * cosCache36 + input13 * cosCache33 * cosCache37 +
                      input14 * cosCache33 * cosCache38 + input15 * cosCache33 * cosCache39 +
                      input16 * cosCache34 * cosCache32 + input17 * cosCache34 * cosCache33 +
                      input18 * cosCache34 * cosCache34 + input19 * cosCache34 * cosCache35 +
                      input20 * cosCache34 * cosCache36 + input21 * cosCache34 * cosCache37 +
                      input22 * cosCache34 * cosCache38 + input23 * cosCache34 * cosCache39 +
                      input24 * cosCache35 * cosCache32 + input25 * cosCache35 * cosCache33 +
                      input26 * cosCache35 * cosCache34 + input27 * cosCache35 * cosCache35 +
                      input28 * cosCache35 * cosCache36 + input29 * cosCache35 * cosCache37 +
                      input30 * cosCache35 * cosCache38 + input31 * cosCache35 * cosCache39 +
                      input32 * cosCache36 * cosCache32 + input33 * cosCache36 * cosCache33 +
                      input34 * cosCache36 * cosCache34 + input35 * cosCache36 * cosCache35 +
                      input36 * cosCache36 * cosCache36 + input37 * cosCache36 * cosCache37 +
                      input38 * cosCache36 * cosCache38 + input39 * cosCache36 * cosCache39 +
                      input40 * cosCache37 * cosCache32 + input41 * cosCache37 * cosCache33 +
                      input42 * cosCache37 * cosCache34 + input43 * cosCache37 * cosCache35 +
                      input44 * cosCache37 * cosCache36 + input45 * cosCache37 * cosCache37 +
                      input46 * cosCache37 * cosCache38 + input47 * cosCache37 * cosCache39 +
                      input48 * cosCache38 * cosCache32 + input49 * cosCache38 * cosCache33 +
                      input50 * cosCache38 * cosCache34 + input51 * cosCache38 * cosCache35 +
                      input52 * cosCache38 * cosCache36 + input53 * cosCache38 * cosCache37 +
                      input54 * cosCache38 * cosCache38 + input55 * cosCache38 * cosCache39 +
                      input56 * cosCache39 * cosCache32 + input57 * cosCache39 * cosCache33 +
                      input58 * cosCache39 * cosCache34 + input59 * cosCache39 * cosCache35 +
                      input60 * cosCache39 * cosCache36 + input61 * cosCache39 * cosCache37 +
                      input62 * cosCache39 * cosCache38 + input63 * cosCache39 * cosCache39) * Beta;
        result[37] = (input0 * cosCache32 * cosCache40 + input1 * cosCache32 * cosCache41 +
                      input2 * cosCache32 * cosCache42 + input3 * cosCache32 * cosCache43 +
                      input4 * cosCache32 * cosCache44 + input5 * cosCache32 * cosCache45 +
                      input6 * cosCache32 * cosCache46 + input7 * cosCache32 * cosCache47 +
                      input8 * cosCache33 * cosCache40 + input9 * cosCache33 * cosCache41 +
                      input10 * cosCache33 * cosCache42 + input11 * cosCache33 * cosCache43 +
                      input12 * cosCache33 * cosCache44 + input13 * cosCache33 * cosCache45 +
                      input14 * cosCache33 * cosCache46 + input15 * cosCache33 * cosCache47 +
                      input16 * cosCache34 * cosCache40 + input17 * cosCache34 * cosCache41 +
                      input18 * cosCache34 * cosCache42 + input19 * cosCache34 * cosCache43 +
                      input20 * cosCache34 * cosCache44 + input21 * cosCache34 * cosCache45 +
                      input22 * cosCache34 * cosCache46 + input23 * cosCache34 * cosCache47 +
                      input24 * cosCache35 * cosCache40 + input25 * cosCache35 * cosCache41 +
                      input26 * cosCache35 * cosCache42 + input27 * cosCache35 * cosCache43 +
                      input28 * cosCache35 * cosCache44 + input29 * cosCache35 * cosCache45 +
                      input30 * cosCache35 * cosCache46 + input31 * cosCache35 * cosCache47 +
                      input32 * cosCache36 * cosCache40 + input33 * cosCache36 * cosCache41 +
                      input34 * cosCache36 * cosCache42 + input35 * cosCache36 * cosCache43 +
                      input36 * cosCache36 * cosCache44 + input37 * cosCache36 * cosCache45 +
                      input38 * cosCache36 * cosCache46 + input39 * cosCache36 * cosCache47 +
                      input40 * cosCache37 * cosCache40 + input41 * cosCache37 * cosCache41 +
                      input42 * cosCache37 * cosCache42 + input43 * cosCache37 * cosCache43 +
                      input44 * cosCache37 * cosCache44 + input45 * cosCache37 * cosCache45 +
                      input46 * cosCache37 * cosCache46 + input47 * cosCache37 * cosCache47 +
                      input48 * cosCache38 * cosCache40 + input49 * cosCache38 * cosCache41 +
                      input50 * cosCache38 * cosCache42 + input51 * cosCache38 * cosCache43 +
                      input52 * cosCache38 * cosCache44 + input53 * cosCache38 * cosCache45 +
                      input54 * cosCache38 * cosCache46 + input55 * cosCache38 * cosCache47 +
                      input56 * cosCache39 * cosCache40 + input57 * cosCache39 * cosCache41 +
                      input58 * cosCache39 * cosCache42 + input59 * cosCache39 * cosCache43 +
                      input60 * cosCache39 * cosCache44 + input61 * cosCache39 * cosCache45 +
                      input62 * cosCache39 * cosCache46 + input63 * cosCache39 * cosCache47) * Beta;
        result[38] = (input0 * cosCache32 * cosCache48 + input1 * cosCache32 * cosCache49 +
                      input2 * cosCache32 * cosCache50 + input3 * cosCache32 * cosCache51 +
                      input4 * cosCache32 * cosCache52 + input5 * cosCache32 * cosCache53 +
                      input6 * cosCache32 * cosCache54 + input7 * cosCache32 * cosCache55 +
                      input8 * cosCache33 * cosCache48 + input9 * cosCache33 * cosCache49 +
                      input10 * cosCache33 * cosCache50 + input11 * cosCache33 * cosCache51 +
                      input12 * cosCache33 * cosCache52 + input13 * cosCache33 * cosCache53 +
                      input14 * cosCache33 * cosCache54 + input15 * cosCache33 * cosCache55 +
                      input16 * cosCache34 * cosCache48 + input17 * cosCache34 * cosCache49 +
                      input18 * cosCache34 * cosCache50 + input19 * cosCache34 * cosCache51 +
                      input20 * cosCache34 * cosCache52 + input21 * cosCache34 * cosCache53 +
                      input22 * cosCache34 * cosCache54 + input23 * cosCache34 * cosCache55 +
                      input24 * cosCache35 * cosCache48 + input25 * cosCache35 * cosCache49 +
                      input26 * cosCache35 * cosCache50 + input27 * cosCache35 * cosCache51 +
                      input28 * cosCache35 * cosCache52 + input29 * cosCache35 * cosCache53 +
                      input30 * cosCache35 * cosCache54 + input31 * cosCache35 * cosCache55 +
                      input32 * cosCache36 * cosCache48 + input33 * cosCache36 * cosCache49 +
                      input34 * cosCache36 * cosCache50 + input35 * cosCache36 * cosCache51 +
                      input36 * cosCache36 * cosCache52 + input37 * cosCache36 * cosCache53 +
                      input38 * cosCache36 * cosCache54 + input39 * cosCache36 * cosCache55 +
                      input40 * cosCache37 * cosCache48 + input41 * cosCache37 * cosCache49 +
                      input42 * cosCache37 * cosCache50 + input43 * cosCache37 * cosCache51 +
                      input44 * cosCache37 * cosCache52 + input45 * cosCache37 * cosCache53 +
                      input46 * cosCache37 * cosCache54 + input47 * cosCache37 * cosCache55 +
                      input48 * cosCache38 * cosCache48 + input49 * cosCache38 * cosCache49 +
                      input50 * cosCache38 * cosCache50 + input51 * cosCache38 * cosCache51 +
                      input52 * cosCache38 * cosCache52 + input53 * cosCache38 * cosCache53 +
                      input54 * cosCache38 * cosCache54 + input55 * cosCache38 * cosCache55 +
                      input56 * cosCache39 * cosCache48 + input57 * cosCache39 * cosCache49 +
                      input58 * cosCache39 * cosCache50 + input59 * cosCache39 * cosCache51 +
                      input60 * cosCache39 * cosCache52 + input61 * cosCache39 * cosCache53 +
                      input62 * cosCache39 * cosCache54 + input63 * cosCache39 * cosCache55) * Beta;
        result[39] = (input0 * cosCache32 * cosCache56 + input1 * cosCache32 * cosCache57 +
                      input2 * cosCache32 * cosCache58 + input3 * cosCache32 * cosCache59 +
                      input4 * cosCache32 * cosCache60 + input5 * cosCache32 * cosCache61 +
                      input6 * cosCache32 * cosCache62 + input7 * cosCache32 * cosCache63 +
                      input8 * cosCache33 * cosCache56 + input9 * cosCache33 * cosCache57 +
                      input10 * cosCache33 * cosCache58 + input11 * cosCache33 * cosCache59 +
                      input12 * cosCache33 * cosCache60 + input13 * cosCache33 * cosCache61 +
                      input14 * cosCache33 * cosCache62 + input15 * cosCache33 * cosCache63 +
                      input16 * cosCache34 * cosCache56 + input17 * cosCache34 * cosCache57 +
                      input18 * cosCache34 * cosCache58 + input19 * cosCache34 * cosCache59 +
                      input20 * cosCache34 * cosCache60 + input21 * cosCache34 * cosCache61 +
                      input22 * cosCache34 * cosCache62 + input23 * cosCache34 * cosCache63 +
                      input24 * cosCache35 * cosCache56 + input25 * cosCache35 * cosCache57 +
                      input26 * cosCache35 * cosCache58 + input27 * cosCache35 * cosCache59 +
                      input28 * cosCache35 * cosCache60 + input29 * cosCache35 * cosCache61 +
                      input30 * cosCache35 * cosCache62 + input31 * cosCache35 * cosCache63 +
                      input32 * cosCache36 * cosCache56 + input33 * cosCache36 * cosCache57 +
                      input34 * cosCache36 * cosCache58 + input35 * cosCache36 * cosCache59 +
                      input36 * cosCache36 * cosCache60 + input37 * cosCache36 * cosCache61 +
                      input38 * cosCache36 * cosCache62 + input39 * cosCache36 * cosCache63 +
                      input40 * cosCache37 * cosCache56 + input41 * cosCache37 * cosCache57 +
                      input42 * cosCache37 * cosCache58 + input43 * cosCache37 * cosCache59 +
                      input44 * cosCache37 * cosCache60 + input45 * cosCache37 * cosCache61 +
                      input46 * cosCache37 * cosCache62 + input47 * cosCache37 * cosCache63 +
                      input48 * cosCache38 * cosCache56 + input49 * cosCache38 * cosCache57 +
                      input50 * cosCache38 * cosCache58 + input51 * cosCache38 * cosCache59 +
                      input52 * cosCache38 * cosCache60 + input53 * cosCache38 * cosCache61 +
                      input54 * cosCache38 * cosCache62 + input55 * cosCache38 * cosCache63 +
                      input56 * cosCache39 * cosCache56 + input57 * cosCache39 * cosCache57 +
                      input58 * cosCache39 * cosCache58 + input59 * cosCache39 * cosCache59 +
                      input60 * cosCache39 * cosCache60 + input61 * cosCache39 * cosCache61 +
                      input62 * cosCache39 * cosCache62 + input63 * cosCache39 * cosCache63) * Beta;
        result[40] = (input0 * cosCache40 + input1 * cosCache40 + input2 * cosCache40 + input3 * cosCache40 +
                      input4 * cosCache40 + input5 * cosCache40 + input6 * cosCache40 + input7 * cosCache40 +
                      input8 * cosCache41 + input9 * cosCache41 + input10 * cosCache41 + input11 * cosCache41 +
                      input12 * cosCache41 + input13 * cosCache41 + input14 * cosCache41 + input15 * cosCache41 +
                      input16 * cosCache42 + input17 * cosCache42 + input18 * cosCache42 + input19 * cosCache42 +
                      input20 * cosCache42 + input21 * cosCache42 + input22 * cosCache42 + input23 * cosCache42 +
                      input24 * cosCache43 + input25 * cosCache43 + input26 * cosCache43 + input27 * cosCache43 +
                      input28 * cosCache43 + input29 * cosCache43 + input30 * cosCache43 + input31 * cosCache43 +
                      input32 * cosCache44 + input33 * cosCache44 + input34 * cosCache44 + input35 * cosCache44 +
                      input36 * cosCache44 + input37 * cosCache44 + input38 * cosCache44 + input39 * cosCache44 +
                      input40 * cosCache45 + input41 * cosCache45 + input42 * cosCache45 + input43 * cosCache45 +
                      input44 * cosCache45 + input45 * cosCache45 + input46 * cosCache45 + input47 * cosCache45 +
                      input48 * cosCache46 + input49 * cosCache46 + input50 * cosCache46 + input51 * cosCache46 +
                      input52 * cosCache46 + input53 * cosCache46 + input54 * cosCache46 + input55 * cosCache46 +
                      input56 * cosCache47 + input57 * cosCache47 + input58 * cosCache47 + input59 * cosCache47 +
                      input60 * cosCache47 + input61 * cosCache47 + input62 * cosCache47 + input63 * cosCache47) *
                     Beta * Alpha;
        result[41] = (input0 * cosCache40 * cosCache8 + input1 * cosCache40 * cosCache9 +
                      input2 * cosCache40 * cosCache10 + input3 * cosCache40 * cosCache11 +
                      input4 * cosCache40 * cosCache12 + input5 * cosCache40 * cosCache13 +
                      input6 * cosCache40 * cosCache14 + input7 * cosCache40 * cosCache15 +
                      input8 * cosCache41 * cosCache8 + input9 * cosCache41 * cosCache9 +
                      input10 * cosCache41 * cosCache10 + input11 * cosCache41 * cosCache11 +
                      input12 * cosCache41 * cosCache12 + input13 * cosCache41 * cosCache13 +
                      input14 * cosCache41 * cosCache14 + input15 * cosCache41 * cosCache15 +
                      input16 * cosCache42 * cosCache8 + input17 * cosCache42 * cosCache9 +
                      input18 * cosCache42 * cosCache10 + input19 * cosCache42 * cosCache11 +
                      input20 * cosCache42 * cosCache12 + input21 * cosCache42 * cosCache13 +
                      input22 * cosCache42 * cosCache14 + input23 * cosCache42 * cosCache15 +
                      input24 * cosCache43 * cosCache8 + input25 * cosCache43 * cosCache9 +
                      input26 * cosCache43 * cosCache10 + input27 * cosCache43 * cosCache11 +
                      input28 * cosCache43 * cosCache12 + input29 * cosCache43 * cosCache13 +
                      input30 * cosCache43 * cosCache14 + input31 * cosCache43 * cosCache15 +
                      input32 * cosCache44 * cosCache8 + input33 * cosCache44 * cosCache9 +
                      input34 * cosCache44 * cosCache10 + input35 * cosCache44 * cosCache11 +
                      input36 * cosCache44 * cosCache12 + input37 * cosCache44 * cosCache13 +
                      input38 * cosCache44 * cosCache14 + input39 * cosCache44 * cosCache15 +
                      input40 * cosCache45 * cosCache8 + input41 * cosCache45 * cosCache9 +
                      input42 * cosCache45 * cosCache10 + input43 * cosCache45 * cosCache11 +
                      input44 * cosCache45 * cosCache12 + input45 * cosCache45 * cosCache13 +
                      input46 * cosCache45 * cosCache14 + input47 * cosCache45 * cosCache15 +
                      input48 * cosCache46 * cosCache8 + input49 * cosCache46 * cosCache9 +
                      input50 * cosCache46 * cosCache10 + input51 * cosCache46 * cosCache11 +
                      input52 * cosCache46 * cosCache12 + input53 * cosCache46 * cosCache13 +
                      input54 * cosCache46 * cosCache14 + input55 * cosCache46 * cosCache15 +
                      input56 * cosCache47 * cosCache8 + input57 * cosCache47 * cosCache9 +
                      input58 * cosCache47 * cosCache10 + input59 * cosCache47 * cosCache11 +
                      input60 * cosCache47 * cosCache12 + input61 * cosCache47 * cosCache13 +
                      input62 * cosCache47 * cosCache14 + input63 * cosCache47 * cosCache15) * Beta;
        result[42] = (input0 * cosCache40 * cosCache16 + input1 * cosCache40 * cosCache17 +
                      input2 * cosCache40 * cosCache18 + input3 * cosCache40 * cosCache19 +
                      input4 * cosCache40 * cosCache20 + input5 * cosCache40 * cosCache21 +
                      input6 * cosCache40 * cosCache22 + input7 * cosCache40 * cosCache23 +
                      input8 * cosCache41 * cosCache16 + input9 * cosCache41 * cosCache17 +
                      input10 * cosCache41 * cosCache18 + input11 * cosCache41 * cosCache19 +
                      input12 * cosCache41 * cosCache20 + input13 * cosCache41 * cosCache21 +
                      input14 * cosCache41 * cosCache22 + input15 * cosCache41 * cosCache23 +
                      input16 * cosCache42 * cosCache16 + input17 * cosCache42 * cosCache17 +
                      input18 * cosCache42 * cosCache18 + input19 * cosCache42 * cosCache19 +
                      input20 * cosCache42 * cosCache20 + input21 * cosCache42 * cosCache21 +
                      input22 * cosCache42 * cosCache22 + input23 * cosCache42 * cosCache23 +
                      input24 * cosCache43 * cosCache16 + input25 * cosCache43 * cosCache17 +
                      input26 * cosCache43 * cosCache18 + input27 * cosCache43 * cosCache19 +
                      input28 * cosCache43 * cosCache20 + input29 * cosCache43 * cosCache21 +
                      input30 * cosCache43 * cosCache22 + input31 * cosCache43 * cosCache23 +
                      input32 * cosCache44 * cosCache16 + input33 * cosCache44 * cosCache17 +
                      input34 * cosCache44 * cosCache18 + input35 * cosCache44 * cosCache19 +
                      input36 * cosCache44 * cosCache20 + input37 * cosCache44 * cosCache21 +
                      input38 * cosCache44 * cosCache22 + input39 * cosCache44 * cosCache23 +
                      input40 * cosCache45 * cosCache16 + input41 * cosCache45 * cosCache17 +
                      input42 * cosCache45 * cosCache18 + input43 * cosCache45 * cosCache19 +
                      input44 * cosCache45 * cosCache20 + input45 * cosCache45 * cosCache21 +
                      input46 * cosCache45 * cosCache22 + input47 * cosCache45 * cosCache23 +
                      input48 * cosCache46 * cosCache16 + input49 * cosCache46 * cosCache17 +
                      input50 * cosCache46 * cosCache18 + input51 * cosCache46 * cosCache19 +
                      input52 * cosCache46 * cosCache20 + input53 * cosCache46 * cosCache21 +
                      input54 * cosCache46 * cosCache22 + input55 * cosCache46 * cosCache23 +
                      input56 * cosCache47 * cosCache16 + input57 * cosCache47 * cosCache17 +
                      input58 * cosCache47 * cosCache18 + input59 * cosCache47 * cosCache19 +
                      input60 * cosCache47 * cosCache20 + input61 * cosCache47 * cosCache21 +
                      input62 * cosCache47 * cosCache22 + input63 * cosCache47 * cosCache23) * Beta;
        result[43] = (input0 * cosCache40 * cosCache24 + input1 * cosCache40 * cosCache25 +
                      input2 * cosCache40 * cosCache26 + input3 * cosCache40 * cosCache27 +
                      input4 * cosCache40 * cosCache28 + input5 * cosCache40 * cosCache29 +
                      input6 * cosCache40 * cosCache30 + input7 * cosCache40 * cosCache31 +
                      input8 * cosCache41 * cosCache24 + input9 * cosCache41 * cosCache25 +
                      input10 * cosCache41 * cosCache26 + input11 * cosCache41 * cosCache27 +
                      input12 * cosCache41 * cosCache28 + input13 * cosCache41 * cosCache29 +
                      input14 * cosCache41 * cosCache30 + input15 * cosCache41 * cosCache31 +
                      input16 * cosCache42 * cosCache24 + input17 * cosCache42 * cosCache25 +
                      input18 * cosCache42 * cosCache26 + input19 * cosCache42 * cosCache27 +
                      input20 * cosCache42 * cosCache28 + input21 * cosCache42 * cosCache29 +
                      input22 * cosCache42 * cosCache30 + input23 * cosCache42 * cosCache31 +
                      input24 * cosCache43 * cosCache24 + input25 * cosCache43 * cosCache25 +
                      input26 * cosCache43 * cosCache26 + input27 * cosCache43 * cosCache27 +
                      input28 * cosCache43 * cosCache28 + input29 * cosCache43 * cosCache29 +
                      input30 * cosCache43 * cosCache30 + input31 * cosCache43 * cosCache31 +
                      input32 * cosCache44 * cosCache24 + input33 * cosCache44 * cosCache25 +
                      input34 * cosCache44 * cosCache26 + input35 * cosCache44 * cosCache27 +
                      input36 * cosCache44 * cosCache28 + input37 * cosCache44 * cosCache29 +
                      input38 * cosCache44 * cosCache30 + input39 * cosCache44 * cosCache31 +
                      input40 * cosCache45 * cosCache24 + input41 * cosCache45 * cosCache25 +
                      input42 * cosCache45 * cosCache26 + input43 * cosCache45 * cosCache27 +
                      input44 * cosCache45 * cosCache28 + input45 * cosCache45 * cosCache29 +
                      input46 * cosCache45 * cosCache30 + input47 * cosCache45 * cosCache31 +
                      input48 * cosCache46 * cosCache24 + input49 * cosCache46 * cosCache25 +
                      input50 * cosCache46 * cosCache26 + input51 * cosCache46 * cosCache27 +
                      input52 * cosCache46 * cosCache28 + input53 * cosCache46 * cosCache29 +
                      input54 * cosCache46 * cosCache30 + input55 * cosCache46 * cosCache31 +
                      input56 * cosCache47 * cosCache24 + input57 * cosCache47 * cosCache25 +
                      input58 * cosCache47 * cosCache26 + input59 * cosCache47 * cosCache27 +
                      input60 * cosCache47 * cosCache28 + input61 * cosCache47 * cosCache29 +
                      input62 * cosCache47 * cosCache30 + input63 * cosCache47 * cosCache31) * Beta;
        result[44] = (input0 * cosCache40 * cosCache32 + input1 * cosCache40 * cosCache33 +
                      input2 * cosCache40 * cosCache34 + input3 * cosCache40 * cosCache35 +
                      input4 * cosCache40 * cosCache36 + input5 * cosCache40 * cosCache37 +
                      input6 * cosCache40 * cosCache38 + input7 * cosCache40 * cosCache39 +
                      input8 * cosCache41 * cosCache32 + input9 * cosCache41 * cosCache33 +
                      input10 * cosCache41 * cosCache34 + input11 * cosCache41 * cosCache35 +
                      input12 * cosCache41 * cosCache36 + input13 * cosCache41 * cosCache37 +
                      input14 * cosCache41 * cosCache38 + input15 * cosCache41 * cosCache39 +
                      input16 * cosCache42 * cosCache32 + input17 * cosCache42 * cosCache33 +
                      input18 * cosCache42 * cosCache34 + input19 * cosCache42 * cosCache35 +
                      input20 * cosCache42 * cosCache36 + input21 * cosCache42 * cosCache37 +
                      input22 * cosCache42 * cosCache38 + input23 * cosCache42 * cosCache39 +
                      input24 * cosCache43 * cosCache32 + input25 * cosCache43 * cosCache33 +
                      input26 * cosCache43 * cosCache34 + input27 * cosCache43 * cosCache35 +
                      input28 * cosCache43 * cosCache36 + input29 * cosCache43 * cosCache37 +
                      input30 * cosCache43 * cosCache38 + input31 * cosCache43 * cosCache39 +
                      input32 * cosCache44 * cosCache32 + input33 * cosCache44 * cosCache33 +
                      input34 * cosCache44 * cosCache34 + input35 * cosCache44 * cosCache35 +
                      input36 * cosCache44 * cosCache36 + input37 * cosCache44 * cosCache37 +
                      input38 * cosCache44 * cosCache38 + input39 * cosCache44 * cosCache39 +
                      input40 * cosCache45 * cosCache32 + input41 * cosCache45 * cosCache33 +
                      input42 * cosCache45 * cosCache34 + input43 * cosCache45 * cosCache35 +
                      input44 * cosCache45 * cosCache36 + input45 * cosCache45 * cosCache37 +
                      input46 * cosCache45 * cosCache38 + input47 * cosCache45 * cosCache39 +
                      input48 * cosCache46 * cosCache32 + input49 * cosCache46 * cosCache33 +
                      input50 * cosCache46 * cosCache34 + input51 * cosCache46 * cosCache35 +
                      input52 * cosCache46 * cosCache36 + input53 * cosCache46 * cosCache37 +
                      input54 * cosCache46 * cosCache38 + input55 * cosCache46 * cosCache39 +
                      input56 * cosCache47 * cosCache32 + input57 * cosCache47 * cosCache33 +
                      input58 * cosCache47 * cosCache34 + input59 * cosCache47 * cosCache35 +
                      input60 * cosCache47 * cosCache36 + input61 * cosCache47 * cosCache37 +
                      input62 * cosCache47 * cosCache38 + input63 * cosCache47 * cosCache39) * Beta;
        result[45] = (input0 * cosCache40 * cosCache40 + input1 * cosCache40 * cosCache41 +
                      input2 * cosCache40 * cosCache42 + input3 * cosCache40 * cosCache43 +
                      input4 * cosCache40 * cosCache44 + input5 * cosCache40 * cosCache45 +
                      input6 * cosCache40 * cosCache46 + input7 * cosCache40 * cosCache47 +
                      input8 * cosCache41 * cosCache40 + input9 * cosCache41 * cosCache41 +
                      input10 * cosCache41 * cosCache42 + input11 * cosCache41 * cosCache43 +
                      input12 * cosCache41 * cosCache44 + input13 * cosCache41 * cosCache45 +
                      input14 * cosCache41 * cosCache46 + input15 * cosCache41 * cosCache47 +
                      input16 * cosCache42 * cosCache40 + input17 * cosCache42 * cosCache41 +
                      input18 * cosCache42 * cosCache42 + input19 * cosCache42 * cosCache43 +
                      input20 * cosCache42 * cosCache44 + input21 * cosCache42 * cosCache45 +
                      input22 * cosCache42 * cosCache46 + input23 * cosCache42 * cosCache47 +
                      input24 * cosCache43 * cosCache40 + input25 * cosCache43 * cosCache41 +
                      input26 * cosCache43 * cosCache42 + input27 * cosCache43 * cosCache43 +
                      input28 * cosCache43 * cosCache44 + input29 * cosCache43 * cosCache45 +
                      input30 * cosCache43 * cosCache46 + input31 * cosCache43 * cosCache47 +
                      input32 * cosCache44 * cosCache40 + input33 * cosCache44 * cosCache41 +
                      input34 * cosCache44 * cosCache42 + input35 * cosCache44 * cosCache43 +
                      input36 * cosCache44 * cosCache44 + input37 * cosCache44 * cosCache45 +
                      input38 * cosCache44 * cosCache46 + input39 * cosCache44 * cosCache47 +
                      input40 * cosCache45 * cosCache40 + input41 * cosCache45 * cosCache41 +
                      input42 * cosCache45 * cosCache42 + input43 * cosCache45 * cosCache43 +
                      input44 * cosCache45 * cosCache44 + input45 * cosCache45 * cosCache45 +
                      input46 * cosCache45 * cosCache46 + input47 * cosCache45 * cosCache47 +
                      input48 * cosCache46 * cosCache40 + input49 * cosCache46 * cosCache41 +
                      input50 * cosCache46 * cosCache42 + input51 * cosCache46 * cosCache43 +
                      input52 * cosCache46 * cosCache44 + input53 * cosCache46 * cosCache45 +
                      input54 * cosCache46 * cosCache46 + input55 * cosCache46 * cosCache47 +
                      input56 * cosCache47 * cosCache40 + input57 * cosCache47 * cosCache41 +
                      input58 * cosCache47 * cosCache42 + input59 * cosCache47 * cosCache43 +
                      input60 * cosCache47 * cosCache44 + input61 * cosCache47 * cosCache45 +
                      input62 * cosCache47 * cosCache46 + input63 * cosCache47 * cosCache47) * Beta;
        result[46] = (input0 * cosCache40 * cosCache48 + input1 * cosCache40 * cosCache49 +
                      input2 * cosCache40 * cosCache50 + input3 * cosCache40 * cosCache51 +
                      input4 * cosCache40 * cosCache52 + input5 * cosCache40 * cosCache53 +
                      input6 * cosCache40 * cosCache54 + input7 * cosCache40 * cosCache55 +
                      input8 * cosCache41 * cosCache48 + input9 * cosCache41 * cosCache49 +
                      input10 * cosCache41 * cosCache50 + input11 * cosCache41 * cosCache51 +
                      input12 * cosCache41 * cosCache52 + input13 * cosCache41 * cosCache53 +
                      input14 * cosCache41 * cosCache54 + input15 * cosCache41 * cosCache55 +
                      input16 * cosCache42 * cosCache48 + input17 * cosCache42 * cosCache49 +
                      input18 * cosCache42 * cosCache50 + input19 * cosCache42 * cosCache51 +
                      input20 * cosCache42 * cosCache52 + input21 * cosCache42 * cosCache53 +
                      input22 * cosCache42 * cosCache54 + input23 * cosCache42 * cosCache55 +
                      input24 * cosCache43 * cosCache48 + input25 * cosCache43 * cosCache49 +
                      input26 * cosCache43 * cosCache50 + input27 * cosCache43 * cosCache51 +
                      input28 * cosCache43 * cosCache52 + input29 * cosCache43 * cosCache53 +
                      input30 * cosCache43 * cosCache54 + input31 * cosCache43 * cosCache55 +
                      input32 * cosCache44 * cosCache48 + input33 * cosCache44 * cosCache49 +
                      input34 * cosCache44 * cosCache50 + input35 * cosCache44 * cosCache51 +
                      input36 * cosCache44 * cosCache52 + input37 * cosCache44 * cosCache53 +
                      input38 * cosCache44 * cosCache54 + input39 * cosCache44 * cosCache55 +
                      input40 * cosCache45 * cosCache48 + input41 * cosCache45 * cosCache49 +
                      input42 * cosCache45 * cosCache50 + input43 * cosCache45 * cosCache51 +
                      input44 * cosCache45 * cosCache52 + input45 * cosCache45 * cosCache53 +
                      input46 * cosCache45 * cosCache54 + input47 * cosCache45 * cosCache55 +
                      input48 * cosCache46 * cosCache48 + input49 * cosCache46 * cosCache49 +
                      input50 * cosCache46 * cosCache50 + input51 * cosCache46 * cosCache51 +
                      input52 * cosCache46 * cosCache52 + input53 * cosCache46 * cosCache53 +
                      input54 * cosCache46 * cosCache54 + input55 * cosCache46 * cosCache55 +
                      input56 * cosCache47 * cosCache48 + input57 * cosCache47 * cosCache49 +
                      input58 * cosCache47 * cosCache50 + input59 * cosCache47 * cosCache51 +
                      input60 * cosCache47 * cosCache52 + input61 * cosCache47 * cosCache53 +
                      input62 * cosCache47 * cosCache54 + input63 * cosCache47 * cosCache55) * Beta;
        result[47] = (input0 * cosCache40 * cosCache56 + input1 * cosCache40 * cosCache57 +
                      input2 * cosCache40 * cosCache58 + input3 * cosCache40 * cosCache59 +
                      input4 * cosCache40 * cosCache60 + input5 * cosCache40 * cosCache61 +
                      input6 * cosCache40 * cosCache62 + input7 * cosCache40 * cosCache63 +
                      input8 * cosCache41 * cosCache56 + input9 * cosCache41 * cosCache57 +
                      input10 * cosCache41 * cosCache58 + input11 * cosCache41 * cosCache59 +
                      input12 * cosCache41 * cosCache60 + input13 * cosCache41 * cosCache61 +
                      input14 * cosCache41 * cosCache62 + input15 * cosCache41 * cosCache63 +
                      input16 * cosCache42 * cosCache56 + input17 * cosCache42 * cosCache57 +
                      input18 * cosCache42 * cosCache58 + input19 * cosCache42 * cosCache59 +
                      input20 * cosCache42 * cosCache60 + input21 * cosCache42 * cosCache61 +
                      input22 * cosCache42 * cosCache62 + input23 * cosCache42 * cosCache63 +
                      input24 * cosCache43 * cosCache56 + input25 * cosCache43 * cosCache57 +
                      input26 * cosCache43 * cosCache58 + input27 * cosCache43 * cosCache59 +
                      input28 * cosCache43 * cosCache60 + input29 * cosCache43 * cosCache61 +
                      input30 * cosCache43 * cosCache62 + input31 * cosCache43 * cosCache63 +
                      input32 * cosCache44 * cosCache56 + input33 * cosCache44 * cosCache57 +
                      input34 * cosCache44 * cosCache58 + input35 * cosCache44 * cosCache59 +
                      input36 * cosCache44 * cosCache60 + input37 * cosCache44 * cosCache61 +
                      input38 * cosCache44 * cosCache62 + input39 * cosCache44 * cosCache63 +
                      input40 * cosCache45 * cosCache56 + input41 * cosCache45 * cosCache57 +
                      input42 * cosCache45 * cosCache58 + input43 * cosCache45 * cosCache59 +
                      input44 * cosCache45 * cosCache60 + input45 * cosCache45 * cosCache61 +
                      input46 * cosCache45 * cosCache62 + input47 * cosCache45 * cosCache63 +
                      input48 * cosCache46 * cosCache56 + input49 * cosCache46 * cosCache57 +
                      input50 * cosCache46 * cosCache58 + input51 * cosCache46 * cosCache59 +
                      input52 * cosCache46 * cosCache60 + input53 * cosCache46 * cosCache61 +
                      input54 * cosCache46 * cosCache62 + input55 * cosCache46 * cosCache63 +
                      input56 * cosCache47 * cosCache56 + input57 * cosCache47 * cosCache57 +
                      input58 * cosCache47 * cosCache58 + input59 * cosCache47 * cosCache59 +
                      input60 * cosCache47 * cosCache60 + input61 * cosCache47 * cosCache61 +
                      input62 * cosCache47 * cosCache62 + input63 * cosCache47 * cosCache63) * Beta;
        result[48] = (input0 * cosCache48 + input1 * cosCache48 + input2 * cosCache48 + input3 * cosCache48 +
                      input4 * cosCache48 + input5 * cosCache48 + input6 * cosCache48 + input7 * cosCache48 +
                      input8 * cosCache49 + input9 * cosCache49 + input10 * cosCache49 + input11 * cosCache49 +
                      input12 * cosCache49 + input13 * cosCache49 + input14 * cosCache49 + input15 * cosCache49 +
                      input16 * cosCache50 + input17 * cosCache50 + input18 * cosCache50 + input19 * cosCache50 +
                      input20 * cosCache50 + input21 * cosCache50 + input22 * cosCache50 + input23 * cosCache50 +
                      input24 * cosCache51 + input25 * cosCache51 + input26 * cosCache51 + input27 * cosCache51 +
                      input28 * cosCache51 + input29 * cosCache51 + input30 * cosCache51 + input31 * cosCache51 +
                      input32 * cosCache52 + input33 * cosCache52 + input34 * cosCache52 + input35 * cosCache52 +
                      input36 * cosCache52 + input37 * cosCache52 + input38 * cosCache52 + input39 * cosCache52 +
                      input40 * cosCache53 + input41 * cosCache53 + input42 * cosCache53 + input43 * cosCache53 +
                      input44 * cosCache53 + input45 * cosCache53 + input46 * cosCache53 + input47 * cosCache53 +
                      input48 * cosCache54 + input49 * cosCache54 + input50 * cosCache54 + input51 * cosCache54 +
                      input52 * cosCache54 + input53 * cosCache54 + input54 * cosCache54 + input55 * cosCache54 +
                      input56 * cosCache55 + input57 * cosCache55 + input58 * cosCache55 + input59 * cosCache55 +
                      input60 * cosCache55 + input61 * cosCache55 + input62 * cosCache55 + input63 * cosCache55) *
                     Beta * Alpha;
        result[49] = (input0 * cosCache48 * cosCache8 + input1 * cosCache48 * cosCache9 +
                      input2 * cosCache48 * cosCache10 + input3 * cosCache48 * cosCache11 +
                      input4 * cosCache48 * cosCache12 + input5 * cosCache48 * cosCache13 +
                      input6 * cosCache48 * cosCache14 + input7 * cosCache48 * cosCache15 +
                      input8 * cosCache49 * cosCache8 + input9 * cosCache49 * cosCache9 +
                      input10 * cosCache49 * cosCache10 + input11 * cosCache49 * cosCache11 +
                      input12 * cosCache49 * cosCache12 + input13 * cosCache49 * cosCache13 +
                      input14 * cosCache49 * cosCache14 + input15 * cosCache49 * cosCache15 +
                      input16 * cosCache50 * cosCache8 + input17 * cosCache50 * cosCache9 +
                      input18 * cosCache50 * cosCache10 + input19 * cosCache50 * cosCache11 +
                      input20 * cosCache50 * cosCache12 + input21 * cosCache50 * cosCache13 +
                      input22 * cosCache50 * cosCache14 + input23 * cosCache50 * cosCache15 +
                      input24 * cosCache51 * cosCache8 + input25 * cosCache51 * cosCache9 +
                      input26 * cosCache51 * cosCache10 + input27 * cosCache51 * cosCache11 +
                      input28 * cosCache51 * cosCache12 + input29 * cosCache51 * cosCache13 +
                      input30 * cosCache51 * cosCache14 + input31 * cosCache51 * cosCache15 +
                      input32 * cosCache52 * cosCache8 + input33 * cosCache52 * cosCache9 +
                      input34 * cosCache52 * cosCache10 + input35 * cosCache52 * cosCache11 +
                      input36 * cosCache52 * cosCache12 + input37 * cosCache52 * cosCache13 +
                      input38 * cosCache52 * cosCache14 + input39 * cosCache52 * cosCache15 +
                      input40 * cosCache53 * cosCache8 + input41 * cosCache53 * cosCache9 +
                      input42 * cosCache53 * cosCache10 + input43 * cosCache53 * cosCache11 +
                      input44 * cosCache53 * cosCache12 + input45 * cosCache53 * cosCache13 +
                      input46 * cosCache53 * cosCache14 + input47 * cosCache53 * cosCache15 +
                      input48 * cosCache54 * cosCache8 + input49 * cosCache54 * cosCache9 +
                      input50 * cosCache54 * cosCache10 + input51 * cosCache54 * cosCache11 +
                      input52 * cosCache54 * cosCache12 + input53 * cosCache54 * cosCache13 +
                      input54 * cosCache54 * cosCache14 + input55 * cosCache54 * cosCache15 +
                      input56 * cosCache55 * cosCache8 + input57 * cosCache55 * cosCache9 +
                      input58 * cosCache55 * cosCache10 + input59 * cosCache55 * cosCache11 +
                      input60 * cosCache55 * cosCache12 + input61 * cosCache55 * cosCache13 +
                      input62 * cosCache55 * cosCache14 + input63 * cosCache55 * cosCache15) * Beta;
        result[50] = (input0 * cosCache48 * cosCache16 + input1 * cosCache48 * cosCache17 +
                      input2 * cosCache48 * cosCache18 + input3 * cosCache48 * cosCache19 +
                      input4 * cosCache48 * cosCache20 + input5 * cosCache48 * cosCache21 +
                      input6 * cosCache48 * cosCache22 + input7 * cosCache48 * cosCache23 +
                      input8 * cosCache49 * cosCache16 + input9 * cosCache49 * cosCache17 +
                      input10 * cosCache49 * cosCache18 + input11 * cosCache49 * cosCache19 +
                      input12 * cosCache49 * cosCache20 + input13 * cosCache49 * cosCache21 +
                      input14 * cosCache49 * cosCache22 + input15 * cosCache49 * cosCache23 +
                      input16 * cosCache50 * cosCache16 + input17 * cosCache50 * cosCache17 +
                      input18 * cosCache50 * cosCache18 + input19 * cosCache50 * cosCache19 +
                      input20 * cosCache50 * cosCache20 + input21 * cosCache50 * cosCache21 +
                      input22 * cosCache50 * cosCache22 + input23 * cosCache50 * cosCache23 +
                      input24 * cosCache51 * cosCache16 + input25 * cosCache51 * cosCache17 +
                      input26 * cosCache51 * cosCache18 + input27 * cosCache51 * cosCache19 +
                      input28 * cosCache51 * cosCache20 + input29 * cosCache51 * cosCache21 +
                      input30 * cosCache51 * cosCache22 + input31 * cosCache51 * cosCache23 +
                      input32 * cosCache52 * cosCache16 + input33 * cosCache52 * cosCache17 +
                      input34 * cosCache52 * cosCache18 + input35 * cosCache52 * cosCache19 +
                      input36 * cosCache52 * cosCache20 + input37 * cosCache52 * cosCache21 +
                      input38 * cosCache52 * cosCache22 + input39 * cosCache52 * cosCache23 +
                      input40 * cosCache53 * cosCache16 + input41 * cosCache53 * cosCache17 +
                      input42 * cosCache53 * cosCache18 + input43 * cosCache53 * cosCache19 +
                      input44 * cosCache53 * cosCache20 + input45 * cosCache53 * cosCache21 +
                      input46 * cosCache53 * cosCache22 + input47 * cosCache53 * cosCache23 +
                      input48 * cosCache54 * cosCache16 + input49 * cosCache54 * cosCache17 +
                      input50 * cosCache54 * cosCache18 + input51 * cosCache54 * cosCache19 +
                      input52 * cosCache54 * cosCache20 + input53 * cosCache54 * cosCache21 +
                      input54 * cosCache54 * cosCache22 + input55 * cosCache54 * cosCache23 +
                      input56 * cosCache55 * cosCache16 + input57 * cosCache55 * cosCache17 +
                      input58 * cosCache55 * cosCache18 + input59 * cosCache55 * cosCache19 +
                      input60 * cosCache55 * cosCache20 + input61 * cosCache55 * cosCache21 +
                      input62 * cosCache55 * cosCache22 + input63 * cosCache55 * cosCache23) * Beta;
        result[51] = (input0 * cosCache48 * cosCache24 + input1 * cosCache48 * cosCache25 +
                      input2 * cosCache48 * cosCache26 + input3 * cosCache48 * cosCache27 +
                      input4 * cosCache48 * cosCache28 + input5 * cosCache48 * cosCache29 +
                      input6 * cosCache48 * cosCache30 + input7 * cosCache48 * cosCache31 +
                      input8 * cosCache49 * cosCache24 + input9 * cosCache49 * cosCache25 +
                      input10 * cosCache49 * cosCache26 + input11 * cosCache49 * cosCache27 +
                      input12 * cosCache49 * cosCache28 + input13 * cosCache49 * cosCache29 +
                      input14 * cosCache49 * cosCache30 + input15 * cosCache49 * cosCache31 +
                      input16 * cosCache50 * cosCache24 + input17 * cosCache50 * cosCache25 +
                      input18 * cosCache50 * cosCache26 + input19 * cosCache50 * cosCache27 +
                      input20 * cosCache50 * cosCache28 + input21 * cosCache50 * cosCache29 +
                      input22 * cosCache50 * cosCache30 + input23 * cosCache50 * cosCache31 +
                      input24 * cosCache51 * cosCache24 + input25 * cosCache51 * cosCache25 +
                      input26 * cosCache51 * cosCache26 + input27 * cosCache51 * cosCache27 +
                      input28 * cosCache51 * cosCache28 + input29 * cosCache51 * cosCache29 +
                      input30 * cosCache51 * cosCache30 + input31 * cosCache51 * cosCache31 +
                      input32 * cosCache52 * cosCache24 + input33 * cosCache52 * cosCache25 +
                      input34 * cosCache52 * cosCache26 + input35 * cosCache52 * cosCache27 +
                      input36 * cosCache52 * cosCache28 + input37 * cosCache52 * cosCache29 +
                      input38 * cosCache52 * cosCache30 + input39 * cosCache52 * cosCache31 +
                      input40 * cosCache53 * cosCache24 + input41 * cosCache53 * cosCache25 +
                      input42 * cosCache53 * cosCache26 + input43 * cosCache53 * cosCache27 +
                      input44 * cosCache53 * cosCache28 + input45 * cosCache53 * cosCache29 +
                      input46 * cosCache53 * cosCache30 + input47 * cosCache53 * cosCache31 +
                      input48 * cosCache54 * cosCache24 + input49 * cosCache54 * cosCache25 +
                      input50 * cosCache54 * cosCache26 + input51 * cosCache54 * cosCache27 +
                      input52 * cosCache54 * cosCache28 + input53 * cosCache54 * cosCache29 +
                      input54 * cosCache54 * cosCache30 + input55 * cosCache54 * cosCache31 +
                      input56 * cosCache55 * cosCache24 + input57 * cosCache55 * cosCache25 +
                      input58 * cosCache55 * cosCache26 + input59 * cosCache55 * cosCache27 +
                      input60 * cosCache55 * cosCache28 + input61 * cosCache55 * cosCache29 +
                      input62 * cosCache55 * cosCache30 + input63 * cosCache55 * cosCache31) * Beta;
        result[52] = (input0 * cosCache48 * cosCache32 + input1 * cosCache48 * cosCache33 +
                      input2 * cosCache48 * cosCache34 + input3 * cosCache48 * cosCache35 +
                      input4 * cosCache48 * cosCache36 + input5 * cosCache48 * cosCache37 +
                      input6 * cosCache48 * cosCache38 + input7 * cosCache48 * cosCache39 +
                      input8 * cosCache49 * cosCache32 + input9 * cosCache49 * cosCache33 +
                      input10 * cosCache49 * cosCache34 + input11 * cosCache49 * cosCache35 +
                      input12 * cosCache49 * cosCache36 + input13 * cosCache49 * cosCache37 +
                      input14 * cosCache49 * cosCache38 + input15 * cosCache49 * cosCache39 +
                      input16 * cosCache50 * cosCache32 + input17 * cosCache50 * cosCache33 +
                      input18 * cosCache50 * cosCache34 + input19 * cosCache50 * cosCache35 +
                      input20 * cosCache50 * cosCache36 + input21 * cosCache50 * cosCache37 +
                      input22 * cosCache50 * cosCache38 + input23 * cosCache50 * cosCache39 +
                      input24 * cosCache51 * cosCache32 + input25 * cosCache51 * cosCache33 +
                      input26 * cosCache51 * cosCache34 + input27 * cosCache51 * cosCache35 +
                      input28 * cosCache51 * cosCache36 + input29 * cosCache51 * cosCache37 +
                      input30 * cosCache51 * cosCache38 + input31 * cosCache51 * cosCache39 +
                      input32 * cosCache52 * cosCache32 + input33 * cosCache52 * cosCache33 +
                      input34 * cosCache52 * cosCache34 + input35 * cosCache52 * cosCache35 +
                      input36 * cosCache52 * cosCache36 + input37 * cosCache52 * cosCache37 +
                      input38 * cosCache52 * cosCache38 + input39 * cosCache52 * cosCache39 +
                      input40 * cosCache53 * cosCache32 + input41 * cosCache53 * cosCache33 +
                      input42 * cosCache53 * cosCache34 + input43 * cosCache53 * cosCache35 +
                      input44 * cosCache53 * cosCache36 + input45 * cosCache53 * cosCache37 +
                      input46 * cosCache53 * cosCache38 + input47 * cosCache53 * cosCache39 +
                      input48 * cosCache54 * cosCache32 + input49 * cosCache54 * cosCache33 +
                      input50 * cosCache54 * cosCache34 + input51 * cosCache54 * cosCache35 +
                      input52 * cosCache54 * cosCache36 + input53 * cosCache54 * cosCache37 +
                      input54 * cosCache54 * cosCache38 + input55 * cosCache54 * cosCache39 +
                      input56 * cosCache55 * cosCache32 + input57 * cosCache55 * cosCache33 +
                      input58 * cosCache55 * cosCache34 + input59 * cosCache55 * cosCache35 +
                      input60 * cosCache55 * cosCache36 + input61 * cosCache55 * cosCache37 +
                      input62 * cosCache55 * cosCache38 + input63 * cosCache55 * cosCache39) * Beta;
        result[53] = (input0 * cosCache48 * cosCache40 + input1 * cosCache48 * cosCache41 +
                      input2 * cosCache48 * cosCache42 + input3 * cosCache48 * cosCache43 +
                      input4 * cosCache48 * cosCache44 + input5 * cosCache48 * cosCache45 +
                      input6 * cosCache48 * cosCache46 + input7 * cosCache48 * cosCache47 +
                      input8 * cosCache49 * cosCache40 + input9 * cosCache49 * cosCache41 +
                      input10 * cosCache49 * cosCache42 + input11 * cosCache49 * cosCache43 +
                      input12 * cosCache49 * cosCache44 + input13 * cosCache49 * cosCache45 +
                      input14 * cosCache49 * cosCache46 + input15 * cosCache49 * cosCache47 +
                      input16 * cosCache50 * cosCache40 + input17 * cosCache50 * cosCache41 +
                      input18 * cosCache50 * cosCache42 + input19 * cosCache50 * cosCache43 +
                      input20 * cosCache50 * cosCache44 + input21 * cosCache50 * cosCache45 +
                      input22 * cosCache50 * cosCache46 + input23 * cosCache50 * cosCache47 +
                      input24 * cosCache51 * cosCache40 + input25 * cosCache51 * cosCache41 +
                      input26 * cosCache51 * cosCache42 + input27 * cosCache51 * cosCache43 +
                      input28 * cosCache51 * cosCache44 + input29 * cosCache51 * cosCache45 +
                      input30 * cosCache51 * cosCache46 + input31 * cosCache51 * cosCache47 +
                      input32 * cosCache52 * cosCache40 + input33 * cosCache52 * cosCache41 +
                      input34 * cosCache52 * cosCache42 + input35 * cosCache52 * cosCache43 +
                      input36 * cosCache52 * cosCache44 + input37 * cosCache52 * cosCache45 +
                      input38 * cosCache52 * cosCache46 + input39 * cosCache52 * cosCache47 +
                      input40 * cosCache53 * cosCache40 + input41 * cosCache53 * cosCache41 +
                      input42 * cosCache53 * cosCache42 + input43 * cosCache53 * cosCache43 +
                      input44 * cosCache53 * cosCache44 + input45 * cosCache53 * cosCache45 +
                      input46 * cosCache53 * cosCache46 + input47 * cosCache53 * cosCache47 +
                      input48 * cosCache54 * cosCache40 + input49 * cosCache54 * cosCache41 +
                      input50 * cosCache54 * cosCache42 + input51 * cosCache54 * cosCache43 +
                      input52 * cosCache54 * cosCache44 + input53 * cosCache54 * cosCache45 +
                      input54 * cosCache54 * cosCache46 + input55 * cosCache54 * cosCache47 +
                      input56 * cosCache55 * cosCache40 + input57 * cosCache55 * cosCache41 +
                      input58 * cosCache55 * cosCache42 + input59 * cosCache55 * cosCache43 +
                      input60 * cosCache55 * cosCache44 + input61 * cosCache55 * cosCache45 +
                      input62 * cosCache55 * cosCache46 + input63 * cosCache55 * cosCache47) * Beta;
        result[54] = (input0 * cosCache48 * cosCache48 + input1 * cosCache48 * cosCache49 +
                      input2 * cosCache48 * cosCache50 + input3 * cosCache48 * cosCache51 +
                      input4 * cosCache48 * cosCache52 + input5 * cosCache48 * cosCache53 +
                      input6 * cosCache48 * cosCache54 + input7 * cosCache48 * cosCache55 +
                      input8 * cosCache49 * cosCache48 + input9 * cosCache49 * cosCache49 +
                      input10 * cosCache49 * cosCache50 + input11 * cosCache49 * cosCache51 +
                      input12 * cosCache49 * cosCache52 + input13 * cosCache49 * cosCache53 +
                      input14 * cosCache49 * cosCache54 + input15 * cosCache49 * cosCache55 +
                      input16 * cosCache50 * cosCache48 + input17 * cosCache50 * cosCache49 +
                      input18 * cosCache50 * cosCache50 + input19 * cosCache50 * cosCache51 +
                      input20 * cosCache50 * cosCache52 + input21 * cosCache50 * cosCache53 +
                      input22 * cosCache50 * cosCache54 + input23 * cosCache50 * cosCache55 +
                      input24 * cosCache51 * cosCache48 + input25 * cosCache51 * cosCache49 +
                      input26 * cosCache51 * cosCache50 + input27 * cosCache51 * cosCache51 +
                      input28 * cosCache51 * cosCache52 + input29 * cosCache51 * cosCache53 +
                      input30 * cosCache51 * cosCache54 + input31 * cosCache51 * cosCache55 +
                      input32 * cosCache52 * cosCache48 + input33 * cosCache52 * cosCache49 +
                      input34 * cosCache52 * cosCache50 + input35 * cosCache52 * cosCache51 +
                      input36 * cosCache52 * cosCache52 + input37 * cosCache52 * cosCache53 +
                      input38 * cosCache52 * cosCache54 + input39 * cosCache52 * cosCache55 +
                      input40 * cosCache53 * cosCache48 + input41 * cosCache53 * cosCache49 +
                      input42 * cosCache53 * cosCache50 + input43 * cosCache53 * cosCache51 +
                      input44 * cosCache53 * cosCache52 + input45 * cosCache53 * cosCache53 +
                      input46 * cosCache53 * cosCache54 + input47 * cosCache53 * cosCache55 +
                      input48 * cosCache54 * cosCache48 + input49 * cosCache54 * cosCache49 +
                      input50 * cosCache54 * cosCache50 + input51 * cosCache54 * cosCache51 +
                      input52 * cosCache54 * cosCache52 + input53 * cosCache54 * cosCache53 +
                      input54 * cosCache54 * cosCache54 + input55 * cosCache54 * cosCache55 +
                      input56 * cosCache55 * cosCache48 + input57 * cosCache55 * cosCache49 +
                      input58 * cosCache55 * cosCache50 + input59 * cosCache55 * cosCache51 +
                      input60 * cosCache55 * cosCache52 + input61 * cosCache55 * cosCache53 +
                      input62 * cosCache55 * cosCache54 + input63 * cosCache55 * cosCache55) * Beta;
        result[55] = (input0 * cosCache48 * cosCache56 + input1 * cosCache48 * cosCache57 +
                      input2 * cosCache48 * cosCache58 + input3 * cosCache48 * cosCache59 +
                      input4 * cosCache48 * cosCache60 + input5 * cosCache48 * cosCache61 +
                      input6 * cosCache48 * cosCache62 + input7 * cosCache48 * cosCache63 +
                      input8 * cosCache49 * cosCache56 + input9 * cosCache49 * cosCache57 +
                      input10 * cosCache49 * cosCache58 + input11 * cosCache49 * cosCache59 +
                      input12 * cosCache49 * cosCache60 + input13 * cosCache49 * cosCache61 +
                      input14 * cosCache49 * cosCache62 + input15 * cosCache49 * cosCache63 +
                      input16 * cosCache50 * cosCache56 + input17 * cosCache50 * cosCache57 +
                      input18 * cosCache50 * cosCache58 + input19 * cosCache50 * cosCache59 +
                      input20 * cosCache50 * cosCache60 + input21 * cosCache50 * cosCache61 +
                      input22 * cosCache50 * cosCache62 + input23 * cosCache50 * cosCache63 +
                      input24 * cosCache51 * cosCache56 + input25 * cosCache51 * cosCache57 +
                      input26 * cosCache51 * cosCache58 + input27 * cosCache51 * cosCache59 +
                      input28 * cosCache51 * cosCache60 + input29 * cosCache51 * cosCache61 +
                      input30 * cosCache51 * cosCache62 + input31 * cosCache51 * cosCache63 +
                      input32 * cosCache52 * cosCache56 + input33 * cosCache52 * cosCache57 +
                      input34 * cosCache52 * cosCache58 + input35 * cosCache52 * cosCache59 +
                      input36 * cosCache52 * cosCache60 + input37 * cosCache52 * cosCache61 +
                      input38 * cosCache52 * cosCache62 + input39 * cosCache52 * cosCache63 +
                      input40 * cosCache53 * cosCache56 + input41 * cosCache53 * cosCache57 +
                      input42 * cosCache53 * cosCache58 + input43 * cosCache53 * cosCache59 +
                      input44 * cosCache53 * cosCache60 + input45 * cosCache53 * cosCache61 +
                      input46 * cosCache53 * cosCache62 + input47 * cosCache53 * cosCache63 +
                      input48 * cosCache54 * cosCache56 + input49 * cosCache54 * cosCache57 +
                      input50 * cosCache54 * cosCache58 + input51 * cosCache54 * cosCache59 +
                      input52 * cosCache54 * cosCache60 + input53 * cosCache54 * cosCache61 +
                      input54 * cosCache54 * cosCache62 + input55 * cosCache54 * cosCache63 +
                      input56 * cosCache55 * cosCache56 + input57 * cosCache55 * cosCache57 +
                      input58 * cosCache55 * cosCache58 + input59 * cosCache55 * cosCache59 +
                      input60 * cosCache55 * cosCache60 + input61 * cosCache55 * cosCache61 +
                      input62 * cosCache55 * cosCache62 + input63 * cosCache55 * cosCache63) * Beta;
        result[56] = (input0 * cosCache56 + input1 * cosCache56 + input2 * cosCache56 + input3 * cosCache56 +
                      input4 * cosCache56 + input5 * cosCache56 + input6 * cosCache56 + input7 * cosCache56 +
                      input8 * cosCache57 + input9 * cosCache57 + input10 * cosCache57 + input11 * cosCache57 +
                      input12 * cosCache57 + input13 * cosCache57 + input14 * cosCache57 + input15 * cosCache57 +
                      input16 * cosCache58 + input17 * cosCache58 + input18 * cosCache58 + input19 * cosCache58 +
                      input20 * cosCache58 + input21 * cosCache58 + input22 * cosCache58 + input23 * cosCache58 +
                      input24 * cosCache59 + input25 * cosCache59 + input26 * cosCache59 + input27 * cosCache59 +
                      input28 * cosCache59 + input29 * cosCache59 + input30 * cosCache59 + input31 * cosCache59 +
                      input32 * cosCache60 + input33 * cosCache60 + input34 * cosCache60 + input35 * cosCache60 +
                      input36 * cosCache60 + input37 * cosCache60 + input38 * cosCache60 + input39 * cosCache60 +
                      input40 * cosCache61 + input41 * cosCache61 + input42 * cosCache61 + input43 * cosCache61 +
                      input44 * cosCache61 + input45 * cosCache61 + input46 * cosCache61 + input47 * cosCache61 +
                      input48 * cosCache62 + input49 * cosCache62 + input50 * cosCache62 + input51 * cosCache62 +
                      input52 * cosCache62 + input53 * cosCache62 + input54 * cosCache62 + input55 * cosCache62 +
                      input56 * cosCache63 + input57 * cosCache63 + input58 * cosCache63 + input59 * cosCache63 +
                      input60 * cosCache63 + input61 * cosCache63 + input62 * cosCache63 + input63 * cosCache63) *
                     Beta * Alpha;
        result[57] = (input0 * cosCache56 * cosCache8 + input1 * cosCache56 * cosCache9 +
                      input2 * cosCache56 * cosCache10 + input3 * cosCache56 * cosCache11 +
                      input4 * cosCache56 * cosCache12 + input5 * cosCache56 * cosCache13 +
                      input6 * cosCache56 * cosCache14 + input7 * cosCache56 * cosCache15 +
                      input8 * cosCache57 * cosCache8 + input9 * cosCache57 * cosCache9 +
                      input10 * cosCache57 * cosCache10 + input11 * cosCache57 * cosCache11 +
                      input12 * cosCache57 * cosCache12 + input13 * cosCache57 * cosCache13 +
                      input14 * cosCache57 * cosCache14 + input15 * cosCache57 * cosCache15 +
                      input16 * cosCache58 * cosCache8 + input17 * cosCache58 * cosCache9 +
                      input18 * cosCache58 * cosCache10 + input19 * cosCache58 * cosCache11 +
                      input20 * cosCache58 * cosCache12 + input21 * cosCache58 * cosCache13 +
                      input22 * cosCache58 * cosCache14 + input23 * cosCache58 * cosCache15 +
                      input24 * cosCache59 * cosCache8 + input25 * cosCache59 * cosCache9 +
                      input26 * cosCache59 * cosCache10 + input27 * cosCache59 * cosCache11 +
                      input28 * cosCache59 * cosCache12 + input29 * cosCache59 * cosCache13 +
                      input30 * cosCache59 * cosCache14 + input31 * cosCache59 * cosCache15 +
                      input32 * cosCache60 * cosCache8 + input33 * cosCache60 * cosCache9 +
                      input34 * cosCache60 * cosCache10 + input35 * cosCache60 * cosCache11 +
                      input36 * cosCache60 * cosCache12 + input37 * cosCache60 * cosCache13 +
                      input38 * cosCache60 * cosCache14 + input39 * cosCache60 * cosCache15 +
                      input40 * cosCache61 * cosCache8 + input41 * cosCache61 * cosCache9 +
                      input42 * cosCache61 * cosCache10 + input43 * cosCache61 * cosCache11 +
                      input44 * cosCache61 * cosCache12 + input45 * cosCache61 * cosCache13 +
                      input46 * cosCache61 * cosCache14 + input47 * cosCache61 * cosCache15 +
                      input48 * cosCache62 * cosCache8 + input49 * cosCache62 * cosCache9 +
                      input50 * cosCache62 * cosCache10 + input51 * cosCache62 * cosCache11 +
                      input52 * cosCache62 * cosCache12 + input53 * cosCache62 * cosCache13 +
                      input54 * cosCache62 * cosCache14 + input55 * cosCache62 * cosCache15 +
                      input56 * cosCache63 * cosCache8 + input57 * cosCache63 * cosCache9 +
                      input58 * cosCache63 * cosCache10 + input59 * cosCache63 * cosCache11 +
                      input60 * cosCache63 * cosCache12 + input61 * cosCache63 * cosCache13 +
                      input62 * cosCache63 * cosCache14 + input63 * cosCache63 * cosCache15) * Beta;
        result[58] = (input0 * cosCache56 * cosCache16 + input1 * cosCache56 * cosCache17 +
                      input2 * cosCache56 * cosCache18 + input3 * cosCache56 * cosCache19 +
                      input4 * cosCache56 * cosCache20 + input5 * cosCache56 * cosCache21 +
                      input6 * cosCache56 * cosCache22 + input7 * cosCache56 * cosCache23 +
                      input8 * cosCache57 * cosCache16 + input9 * cosCache57 * cosCache17 +
                      input10 * cosCache57 * cosCache18 + input11 * cosCache57 * cosCache19 +
                      input12 * cosCache57 * cosCache20 + input13 * cosCache57 * cosCache21 +
                      input14 * cosCache57 * cosCache22 + input15 * cosCache57 * cosCache23 +
                      input16 * cosCache58 * cosCache16 + input17 * cosCache58 * cosCache17 +
                      input18 * cosCache58 * cosCache18 + input19 * cosCache58 * cosCache19 +
                      input20 * cosCache58 * cosCache20 + input21 * cosCache58 * cosCache21 +
                      input22 * cosCache58 * cosCache22 + input23 * cosCache58 * cosCache23 +
                      input24 * cosCache59 * cosCache16 + input25 * cosCache59 * cosCache17 +
                      input26 * cosCache59 * cosCache18 + input27 * cosCache59 * cosCache19 +
                      input28 * cosCache59 * cosCache20 + input29 * cosCache59 * cosCache21 +
                      input30 * cosCache59 * cosCache22 + input31 * cosCache59 * cosCache23 +
                      input32 * cosCache60 * cosCache16 + input33 * cosCache60 * cosCache17 +
                      input34 * cosCache60 * cosCache18 + input35 * cosCache60 * cosCache19 +
                      input36 * cosCache60 * cosCache20 + input37 * cosCache60 * cosCache21 +
                      input38 * cosCache60 * cosCache22 + input39 * cosCache60 * cosCache23 +
                      input40 * cosCache61 * cosCache16 + input41 * cosCache61 * cosCache17 +
                      input42 * cosCache61 * cosCache18 + input43 * cosCache61 * cosCache19 +
                      input44 * cosCache61 * cosCache20 + input45 * cosCache61 * cosCache21 +
                      input46 * cosCache61 * cosCache22 + input47 * cosCache61 * cosCache23 +
                      input48 * cosCache62 * cosCache16 + input49 * cosCache62 * cosCache17 +
                      input50 * cosCache62 * cosCache18 + input51 * cosCache62 * cosCache19 +
                      input52 * cosCache62 * cosCache20 + input53 * cosCache62 * cosCache21 +
                      input54 * cosCache62 * cosCache22 + input55 * cosCache62 * cosCache23 +
                      input56 * cosCache63 * cosCache16 + input57 * cosCache63 * cosCache17 +
                      input58 * cosCache63 * cosCache18 + input59 * cosCache63 * cosCache19 +
                      input60 * cosCache63 * cosCache20 + input61 * cosCache63 * cosCache21 +
                      input62 * cosCache63 * cosCache22 + input63 * cosCache63 * cosCache23) * Beta;
        result[59] = (input0 * cosCache56 * cosCache24 + input1 * cosCache56 * cosCache25 +
                      input2 * cosCache56 * cosCache26 + input3 * cosCache56 * cosCache27 +
                      input4 * cosCache56 * cosCache28 + input5 * cosCache56 * cosCache29 +
                      input6 * cosCache56 * cosCache30 + input7 * cosCache56 * cosCache31 +
                      input8 * cosCache57 * cosCache24 + input9 * cosCache57 * cosCache25 +
                      input10 * cosCache57 * cosCache26 + input11 * cosCache57 * cosCache27 +
                      input12 * cosCache57 * cosCache28 + input13 * cosCache57 * cosCache29 +
                      input14 * cosCache57 * cosCache30 + input15 * cosCache57 * cosCache31 +
                      input16 * cosCache58 * cosCache24 + input17 * cosCache58 * cosCache25 +
                      input18 * cosCache58 * cosCache26 + input19 * cosCache58 * cosCache27 +
                      input20 * cosCache58 * cosCache28 + input21 * cosCache58 * cosCache29 +
                      input22 * cosCache58 * cosCache30 + input23 * cosCache58 * cosCache31 +
                      input24 * cosCache59 * cosCache24 + input25 * cosCache59 * cosCache25 +
                      input26 * cosCache59 * cosCache26 + input27 * cosCache59 * cosCache27 +
                      input28 * cosCache59 * cosCache28 + input29 * cosCache59 * cosCache29 +
                      input30 * cosCache59 * cosCache30 + input31 * cosCache59 * cosCache31 +
                      input32 * cosCache60 * cosCache24 + input33 * cosCache60 * cosCache25 +
                      input34 * cosCache60 * cosCache26 + input35 * cosCache60 * cosCache27 +
                      input36 * cosCache60 * cosCache28 + input37 * cosCache60 * cosCache29 +
                      input38 * cosCache60 * cosCache30 + input39 * cosCache60 * cosCache31 +
                      input40 * cosCache61 * cosCache24 + input41 * cosCache61 * cosCache25 +
                      input42 * cosCache61 * cosCache26 + input43 * cosCache61 * cosCache27 +
                      input44 * cosCache61 * cosCache28 + input45 * cosCache61 * cosCache29 +
                      input46 * cosCache61 * cosCache30 + input47 * cosCache61 * cosCache31 +
                      input48 * cosCache62 * cosCache24 + input49 * cosCache62 * cosCache25 +
                      input50 * cosCache62 * cosCache26 + input51 * cosCache62 * cosCache27 +
                      input52 * cosCache62 * cosCache28 + input53 * cosCache62 * cosCache29 +
                      input54 * cosCache62 * cosCache30 + input55 * cosCache62 * cosCache31 +
                      input56 * cosCache63 * cosCache24 + input57 * cosCache63 * cosCache25 +
                      input58 * cosCache63 * cosCache26 + input59 * cosCache63 * cosCache27 +
                      input60 * cosCache63 * cosCache28 + input61 * cosCache63 * cosCache29 +
                      input62 * cosCache63 * cosCache30 + input63 * cosCache63 * cosCache31) * Beta;
        result[60] = (input0 * cosCache56 * cosCache32 + input1 * cosCache56 * cosCache33 +
                      input2 * cosCache56 * cosCache34 + input3 * cosCache56 * cosCache35 +
                      input4 * cosCache56 * cosCache36 + input5 * cosCache56 * cosCache37 +
                      input6 * cosCache56 * cosCache38 + input7 * cosCache56 * cosCache39 +
                      input8 * cosCache57 * cosCache32 + input9 * cosCache57 * cosCache33 +
                      input10 * cosCache57 * cosCache34 + input11 * cosCache57 * cosCache35 +
                      input12 * cosCache57 * cosCache36 + input13 * cosCache57 * cosCache37 +
                      input14 * cosCache57 * cosCache38 + input15 * cosCache57 * cosCache39 +
                      input16 * cosCache58 * cosCache32 + input17 * cosCache58 * cosCache33 +
                      input18 * cosCache58 * cosCache34 + input19 * cosCache58 * cosCache35 +
                      input20 * cosCache58 * cosCache36 + input21 * cosCache58 * cosCache37 +
                      input22 * cosCache58 * cosCache38 + input23 * cosCache58 * cosCache39 +
                      input24 * cosCache59 * cosCache32 + input25 * cosCache59 * cosCache33 +
                      input26 * cosCache59 * cosCache34 + input27 * cosCache59 * cosCache35 +
                      input28 * cosCache59 * cosCache36 + input29 * cosCache59 * cosCache37 +
                      input30 * cosCache59 * cosCache38 + input31 * cosCache59 * cosCache39 +
                      input32 * cosCache60 * cosCache32 + input33 * cosCache60 * cosCache33 +
                      input34 * cosCache60 * cosCache34 + input35 * cosCache60 * cosCache35 +
                      input36 * cosCache60 * cosCache36 + input37 * cosCache60 * cosCache37 +
                      input38 * cosCache60 * cosCache38 + input39 * cosCache60 * cosCache39 +
                      input40 * cosCache61 * cosCache32 + input41 * cosCache61 * cosCache33 +
                      input42 * cosCache61 * cosCache34 + input43 * cosCache61 * cosCache35 +
                      input44 * cosCache61 * cosCache36 + input45 * cosCache61 * cosCache37 +
                      input46 * cosCache61 * cosCache38 + input47 * cosCache61 * cosCache39 +
                      input48 * cosCache62 * cosCache32 + input49 * cosCache62 * cosCache33 +
                      input50 * cosCache62 * cosCache34 + input51 * cosCache62 * cosCache35 +
                      input52 * cosCache62 * cosCache36 + input53 * cosCache62 * cosCache37 +
                      input54 * cosCache62 * cosCache38 + input55 * cosCache62 * cosCache39 +
                      input56 * cosCache63 * cosCache32 + input57 * cosCache63 * cosCache33 +
                      input58 * cosCache63 * cosCache34 + input59 * cosCache63 * cosCache35 +
                      input60 * cosCache63 * cosCache36 + input61 * cosCache63 * cosCache37 +
                      input62 * cosCache63 * cosCache38 + input63 * cosCache63 * cosCache39) * Beta;
        result[61] = (input0 * cosCache56 * cosCache40 + input1 * cosCache56 * cosCache41 +
                      input2 * cosCache56 * cosCache42 + input3 * cosCache56 * cosCache43 +
                      input4 * cosCache56 * cosCache44 + input5 * cosCache56 * cosCache45 +
                      input6 * cosCache56 * cosCache46 + input7 * cosCache56 * cosCache47 +
                      input8 * cosCache57 * cosCache40 + input9 * cosCache57 * cosCache41 +
                      input10 * cosCache57 * cosCache42 + input11 * cosCache57 * cosCache43 +
                      input12 * cosCache57 * cosCache44 + input13 * cosCache57 * cosCache45 +
                      input14 * cosCache57 * cosCache46 + input15 * cosCache57 * cosCache47 +
                      input16 * cosCache58 * cosCache40 + input17 * cosCache58 * cosCache41 +
                      input18 * cosCache58 * cosCache42 + input19 * cosCache58 * cosCache43 +
                      input20 * cosCache58 * cosCache44 + input21 * cosCache58 * cosCache45 +
                      input22 * cosCache58 * cosCache46 + input23 * cosCache58 * cosCache47 +
                      input24 * cosCache59 * cosCache40 + input25 * cosCache59 * cosCache41 +
                      input26 * cosCache59 * cosCache42 + input27 * cosCache59 * cosCache43 +
                      input28 * cosCache59 * cosCache44 + input29 * cosCache59 * cosCache45 +
                      input30 * cosCache59 * cosCache46 + input31 * cosCache59 * cosCache47 +
                      input32 * cosCache60 * cosCache40 + input33 * cosCache60 * cosCache41 +
                      input34 * cosCache60 * cosCache42 + input35 * cosCache60 * cosCache43 +
                      input36 * cosCache60 * cosCache44 + input37 * cosCache60 * cosCache45 +
                      input38 * cosCache60 * cosCache46 + input39 * cosCache60 * cosCache47 +
                      input40 * cosCache61 * cosCache40 + input41 * cosCache61 * cosCache41 +
                      input42 * cosCache61 * cosCache42 + input43 * cosCache61 * cosCache43 +
                      input44 * cosCache61 * cosCache44 + input45 * cosCache61 * cosCache45 +
                      input46 * cosCache61 * cosCache46 + input47 * cosCache61 * cosCache47 +
                      input48 * cosCache62 * cosCache40 + input49 * cosCache62 * cosCache41 +
                      input50 * cosCache62 * cosCache42 + input51 * cosCache62 * cosCache43 +
                      input52 * cosCache62 * cosCache44 + input53 * cosCache62 * cosCache45 +
                      input54 * cosCache62 * cosCache46 + input55 * cosCache62 * cosCache47 +
                      input56 * cosCache63 * cosCache40 + input57 * cosCache63 * cosCache41 +
                      input58 * cosCache63 * cosCache42 + input59 * cosCache63 * cosCache43 +
                      input60 * cosCache63 * cosCache44 + input61 * cosCache63 * cosCache45 +
                      input62 * cosCache63 * cosCache46 + input63 * cosCache63 * cosCache47) * Beta;
        result[62] = (input0 * cosCache56 * cosCache48 + input1 * cosCache56 * cosCache49 +
                      input2 * cosCache56 * cosCache50 + input3 * cosCache56 * cosCache51 +
                      input4 * cosCache56 * cosCache52 + input5 * cosCache56 * cosCache53 +
                      input6 * cosCache56 * cosCache54 + input7 * cosCache56 * cosCache55 +
                      input8 * cosCache57 * cosCache48 + input9 * cosCache57 * cosCache49 +
                      input10 * cosCache57 * cosCache50 + input11 * cosCache57 * cosCache51 +
                      input12 * cosCache57 * cosCache52 + input13 * cosCache57 * cosCache53 +
                      input14 * cosCache57 * cosCache54 + input15 * cosCache57 * cosCache55 +
                      input16 * cosCache58 * cosCache48 + input17 * cosCache58 * cosCache49 +
                      input18 * cosCache58 * cosCache50 + input19 * cosCache58 * cosCache51 +
                      input20 * cosCache58 * cosCache52 + input21 * cosCache58 * cosCache53 +
                      input22 * cosCache58 * cosCache54 + input23 * cosCache58 * cosCache55 +
                      input24 * cosCache59 * cosCache48 + input25 * cosCache59 * cosCache49 +
                      input26 * cosCache59 * cosCache50 + input27 * cosCache59 * cosCache51 +
                      input28 * cosCache59 * cosCache52 + input29 * cosCache59 * cosCache53 +
                      input30 * cosCache59 * cosCache54 + input31 * cosCache59 * cosCache55 +
                      input32 * cosCache60 * cosCache48 + input33 * cosCache60 * cosCache49 +
                      input34 * cosCache60 * cosCache50 + input35 * cosCache60 * cosCache51 +
                      input36 * cosCache60 * cosCache52 + input37 * cosCache60 * cosCache53 +
                      input38 * cosCache60 * cosCache54 + input39 * cosCache60 * cosCache55 +
                      input40 * cosCache61 * cosCache48 + input41 * cosCache61 * cosCache49 +
                      input42 * cosCache61 * cosCache50 + input43 * cosCache61 * cosCache51 +
                      input44 * cosCache61 * cosCache52 + input45 * cosCache61 * cosCache53 +
                      input46 * cosCache61 * cosCache54 + input47 * cosCache61 * cosCache55 +
                      input48 * cosCache62 * cosCache48 + input49 * cosCache62 * cosCache49 +
                      input50 * cosCache62 * cosCache50 + input51 * cosCache62 * cosCache51 +
                      input52 * cosCache62 * cosCache52 + input53 * cosCache62 * cosCache53 +
                      input54 * cosCache62 * cosCache54 + input55 * cosCache62 * cosCache55 +
                      input56 * cosCache63 * cosCache48 + input57 * cosCache63 * cosCache49 +
                      input58 * cosCache63 * cosCache50 + input59 * cosCache63 * cosCache51 +
                      input60 * cosCache63 * cosCache52 + input61 * cosCache63 * cosCache53 +
                      input62 * cosCache63 * cosCache54 + input63 * cosCache63 * cosCache55) * Beta;
        result[63] = (input0 * cosCache56 * cosCache56 + input1 * cosCache56 * cosCache57 +
                      input2 * cosCache56 * cosCache58 + input3 * cosCache56 * cosCache59 +
                      input4 * cosCache56 * cosCache60 + input5 * cosCache56 * cosCache61 +
                      input6 * cosCache56 * cosCache62 + input7 * cosCache56 * cosCache63 +
                      input8 * cosCache57 * cosCache56 + input9 * cosCache57 * cosCache57 +
                      input10 * cosCache57 * cosCache58 + input11 * cosCache57 * cosCache59 +
                      input12 * cosCache57 * cosCache60 + input13 * cosCache57 * cosCache61 +
                      input14 * cosCache57 * cosCache62 + input15 * cosCache57 * cosCache63 +
                      input16 * cosCache58 * cosCache56 + input17 * cosCache58 * cosCache57 +
                      input18 * cosCache58 * cosCache58 + input19 * cosCache58 * cosCache59 +
                      input20 * cosCache58 * cosCache60 + input21 * cosCache58 * cosCache61 +
                      input22 * cosCache58 * cosCache62 + input23 * cosCache58 * cosCache63 +
                      input24 * cosCache59 * cosCache56 + input25 * cosCache59 * cosCache57 +
                      input26 * cosCache59 * cosCache58 + input27 * cosCache59 * cosCache59 +
                      input28 * cosCache59 * cosCache60 + input29 * cosCache59 * cosCache61 +
                      input30 * cosCache59 * cosCache62 + input31 * cosCache59 * cosCache63 +
                      input32 * cosCache60 * cosCache56 + input33 * cosCache60 * cosCache57 +
                      input34 * cosCache60 * cosCache58 + input35 * cosCache60 * cosCache59 +
                      input36 * cosCache60 * cosCache60 + input37 * cosCache60 * cosCache61 +
                      input38 * cosCache60 * cosCache62 + input39 * cosCache60 * cosCache63 +
                      input40 * cosCache61 * cosCache56 + input41 * cosCache61 * cosCache57 +
                      input42 * cosCache61 * cosCache58 + input43 * cosCache61 * cosCache59 +
                      input44 * cosCache61 * cosCache60 + input45 * cosCache61 * cosCache61 +
                      input46 * cosCache61 * cosCache62 + input47 * cosCache61 * cosCache63 +
                      input48 * cosCache62 * cosCache56 + input49 * cosCache62 * cosCache57 +
                      input50 * cosCache62 * cosCache58 + input51 * cosCache62 * cosCache59 +
                      input52 * cosCache62 * cosCache60 + input53 * cosCache62 * cosCache61 +
                      input54 * cosCache62 * cosCache62 + input55 * cosCache62 * cosCache63 +
                      input56 * cosCache63 * cosCache56 + input57 * cosCache63 * cosCache57 +
                      input58 * cosCache63 * cosCache58 + input59 * cosCache63 * cosCache59 +
                      input60 * cosCache63 * cosCache60 + input61 * cosCache63 * cosCache61 +
                      input62 * cosCache63 * cosCache62 + input63 * cosCache63 * cosCache63) * Beta;
    }
}
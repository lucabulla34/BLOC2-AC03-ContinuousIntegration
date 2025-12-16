using System;

namespace xUnitTestLibrary
{
    public static class TestsLibrary
    {
        public static int SumNumbers(int firstValue, int secondValue, int thirdValue)
        {
            if (firstValue <= 0) return 0;
            if (secondValue <= 0) return firstValue;
            if (thirdValue <= 0) return firstValue + secondValue;
            return firstValue + secondValue + thirdValue;
        }

        public static string DescriptionResult(int result)
        {
            const string EqualZero = "El resultat és zero.";
            const string PositiveResult = "El resultat és positiu.";
            const string NegativeResult = "El resultat és negatiu.";

            if (result == 0) return EqualZero;
            if (result > 0) return PositiveResult;
            return NegativeResult;
        }
    }
}
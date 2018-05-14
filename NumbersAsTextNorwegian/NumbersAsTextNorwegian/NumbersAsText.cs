using System;
using System.Collections.Generic;

namespace NumbersAsTextNorwegian
{
    public static class NumbersAsText
    {

        public static IDictionary<int, string> Numbers = new Dictionary<int, string>()
        {
            {1, "en"},
            {2, "to"},
            {3, "tre"},
            {4, "fire"},
            {5, "fem"},
            {6, "seks"},
            {7, "sju"},
            {8, "åtte"},
            {9, "ni"},
            {10, "ti"},
            {11, "elleve"},
            {12, "tolv"},
            {13, "tretten"},
            {14, "fjorten"},
            {15, "femten"},
            {16, "seksten"},
            {17, "sytten"},
            {18, "atten"},
            {19, "nitten"},
            {20, "tyve"},
            {30, "tretti"},
            {40, "førti"},
            {50, "femti"},
            {60, "seksti"},
            {70, "sytti"},
            {80, "åtti"},
            {90, "nitti"},
        };



        public static string AsText(int number)
        {
            return ConvertNumberToText(number).Trim();
        }

        public static string ConvertNumberToText(int number, string prefix = "")
        {

            if (number == 0)
                return string.Empty;

            if (number < 20)
                return string.IsNullOrWhiteSpace(prefix) ?  Numbers[number] : $"{prefix} {Numbers[number]}";

            if (number < 100)
                return $"{(string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix)} {Numbers[number -(number%10)] }" + ConvertNumberToText(number % 10);

            if (number < 1000)
                return $"{GetNumberOrDefault(number, 100) } hundre " + ConvertNumberToText(number % 100, "og");

            if (number < 10000)
                return $"{GetNumberOrDefault(number, 1000) } tusen " + ConvertNumberToText(number % 1000, "og");

            if (number < 100000)
            {
                var tens = (number - (number % 10000)) / 1000;
                var includeSuffix = number % 10000 < 1000;

                return $"{(string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix)} {Numbers[tens] }{(includeSuffix ? " tusen " : string.Empty)}" + ConvertNumberToText(number % 10000);
            }

            if (number < 1000000)
                return $"{ GetNumberOrDefault(number, 100000) } hundre " + ConvertNumberToText(number % 100000, "og");

            return string.Empty;
        }

        private static string GetNumberOrDefault(int number, int mod, string defaultValue = "ett")
        {
            return (number / mod == 1 ? defaultValue : Numbers[number / mod]);
        }
        

    }
}

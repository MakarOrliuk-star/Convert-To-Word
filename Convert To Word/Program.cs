using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Convert_To_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  [TestCase(double.NaN, ExpectedResult = "NaN")]
                [TestCase(double.NegativeInfinity, ExpectedResult = "Negative Infinity")]
                [TestCase(double.PositiveInfinity, ExpectedResult = "Positive Infinity")]
                [TestCase(-0.0d, ExpectedResult = "Minus zero")]
             */
        }
        private static readonly Dictionary<char, string> Words = new Dictionary<char, string>
        {
            { '0', "zero" },
            { '1', "one" },
            { '2', "two" },
            { '3', "three" },
            { '4', "four" },
            { '5', "five" },
            { '6', "six" },
            { '7', "seven" },
            { '8', "eight" },
            { '9', "nine" },
            { '+', "plus" },
            { '-', "minus" },
            { '.', "point" },
            { 'E', "E" },
        };
        public string TransformToWords(double number)
        {
            switch (number)
            {
                case double.NaN: return "NaN";
                case double.NegativeInfinity: return "Negative Infinity";
                case double.PositiveInfinity: return "Positive Infinity";
                case double.Epsilon: return "Double Epsilon";
            }

            NumberFormatInfo formatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
            };

            var stringRepresentation = number.ToString(formatInfo);
            var resultStringBuilder = new StringBuilder();
            foreach (var character in stringRepresentation)
            {
                resultStringBuilder.Append(Words[character]);
                resultStringBuilder.Append(" ");
            }

            resultStringBuilder = resultStringBuilder.Replace(resultStringBuilder[0], char.ToUpper(resultStringBuilder[0], CultureInfo.InvariantCulture), 0, 1);
            return resultStringBuilder.ToString().Trim();
        }
    }
}

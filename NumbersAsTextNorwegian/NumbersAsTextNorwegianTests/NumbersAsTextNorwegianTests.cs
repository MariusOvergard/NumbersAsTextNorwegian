using System;
using NFluent;
using NumbersAsTextNorwegian;
using Xunit;

namespace NumbersAsTextNorwegianTests
{
    public class NumbersAsTextNorwegianTests
    {
        [Theory]
        [InlineData(1, "en")]
        [InlineData(2, "to")]
        [InlineData(3, "tre")]
        [InlineData(4, "fire")]
        [InlineData(5, "fem")]

        public void CheckThatSimpleNumbersAreReplaced(int value, string expected)
        {
            var valueAsString = NumbersAsText.AsText(value);
            Check.That(valueAsString).Equals(expected);
        }

        [Theory]
        [InlineData(100, "ett hundre")]
        [InlineData(200, "to hundre")]
        [InlineData(212, "to hundre og tolv")]
        [InlineData(1000, "ett tusen")]
        [InlineData(1001, "ett tusen og en")]
        [InlineData(1984, "ett tusen ni hundre og åttifire")]
        [InlineData(342122, "tre hundre og førtito tusen ett hundre og tyveto")]
        [InlineData(340000, "tre hundre og førti tusen")]
        [InlineData(340022, "tre hundre og førti tusen og tyveto")]

        public void CheckThatComplexNumbersAreReplaced(int value, string expected)
        {
            var valueAsString = NumbersAsText.AsText(value);
            Check.That(valueAsString).Equals(expected);
        }
    }
}

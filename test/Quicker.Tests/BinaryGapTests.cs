using Quicker.Algorithms.BinaryGap;
using Xunit;

namespace Quicker.Tests
{
    public class BinaryGapTests
    {
        [Theory]

        // test cases for unset bit gap
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Unset, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Unset, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Unset, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Unset, 30)]
        [InlineData(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 24)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 16)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Unset, 8)]
        [InlineData(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Unset, 8)]
        [InlineData(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Unset, 5)]
        [InlineData(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Unset, 1)]

        // test cases for set bit gap
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Set, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Set, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Set, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Set, 4)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Set, 4)]
        [InlineData(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Set, 4)]
        [InlineData(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Set, 1)]
        [InlineData(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Set, 6)]
        public void BinaryGapMaxLengthByShifting_Returns_Expected_Result(int value, BinaryGapBit bit, int expected)
        {
            // act
            int actual = BinaryGapAlgorithm.MaxLengthByShifting(value, bit);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]

        // test cases for unset bit gap
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Unset, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Unset, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Unset, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Unset, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Unset, 30)]
        [InlineData(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 24)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 16)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Unset, 8)]
        [InlineData(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Unset, 8)]
        [InlineData(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Unset, 5)]
        [InlineData(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Unset, 1)]

        // test cases for set bit gap
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Set, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Set, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Set, 0)]
        [InlineData(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Set, 0)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Set, 4)]
        [InlineData(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Set, 4)]
        [InlineData(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Set, 4)]
        [InlineData(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Set, 1)]
        [InlineData(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Set, 6)]
        public void BinaryGapMaxLengthByIterating_Returns_Expected_Result(int value, BinaryGapBit bit, int expected)
        {
            // act
            int actual = BinaryGapAlgorithm.MaxLengthByIterating(value, bit);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}

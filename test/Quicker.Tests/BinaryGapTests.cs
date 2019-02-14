using NUnit.Framework;
using Quicker.Algorithms.BinaryGap;

namespace Quicker.Tests
{
    [TestFixture]
    public class BinaryGapTests
    {
        // test cases for unset bit gap
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Unset, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Unset, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Unset, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Unset, 30)]
        [TestCase(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 24)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 16)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Unset, 8)]
        [TestCase(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Unset, 8)]
        [TestCase(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Unset, 5)]
        [TestCase(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Unset, 1)]

        // test cases for set bit gap
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Set, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Set, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Set, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Set, 4)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Set, 4)]
        [TestCase(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Set, 4)]
        [TestCase(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Set, 1)]
        [TestCase(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Set, 6)]
        public void BinaryGapMaxLengthByShifting_Returns_Expected_Result(int value, BinaryGapBit bit, int expected)
        {
            // act
            int actual = BinaryGapAlgorithm.MaxLengthByShifting(value, bit);

            // assert
            Assert.AreEqual(expected, actual);
        }

        // test cases for unset bit gap
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Unset, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Unset, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Unset, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Unset, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Unset, 30)]
        [TestCase(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 24)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Unset, 16)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Unset, 8)]
        [TestCase(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Unset, 8)]
        [TestCase(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Unset, 5)]
        [TestCase(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Unset, 1)]

        // test cases for set bit gap
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0000, BinaryGapBit.Set, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0001, BinaryGapBit.Set, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0011, BinaryGapBit.Set, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0111, BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), BinaryGapBit.Set, 0)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), BinaryGapBit.Set, 4)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), BinaryGapBit.Set, 4)]
        [TestCase(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), BinaryGapBit.Set, 4)]
        [TestCase(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), BinaryGapBit.Set, 1)]
        [TestCase(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Set, 6)]
        public void BinaryGapMaxLengthByIterating_Returns_Expected_Result(int value, BinaryGapBit bit, int expected)
        {
            // act
            int actual = BinaryGapAlgorithm.MaxLengthByIterating(value, bit);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

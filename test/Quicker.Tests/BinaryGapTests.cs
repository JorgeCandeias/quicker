using NUnit.Framework;

namespace Quicker.Tests
{
    [TestFixture]
    public class BinaryGapTests
    {
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0000, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0001, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0011, 0)]
        [TestCase(0b0000_0000_0000_0000_0000_0000_0000_0111, 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0000), 0)]
        [TestCase(unchecked((int)0b1100_0000_0000_0000_0000_0000_0000_0000), 0)]
        [TestCase(unchecked((int)0b1110_0000_0000_0000_0000_0000_0000_0000), 0)]
        [TestCase(unchecked((int)0b1111_1111_1111_1111_1111_1111_1111_1111), 0)]
        [TestCase(unchecked((int)0b1000_0000_0000_0000_0000_0000_0000_0001), 30)]
        [TestCase(unchecked((int)0b1111_0000_0000_0000_0000_0000_0000_1111), 24)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_0000_0000_0000_1111), 16)]
        [TestCase(unchecked((int)0b1111_0000_1111_0000_1111_0000_0000_1111), 8)]
        [TestCase(unchecked((int)0b1111_0000_0000_1111_0000_1111_0000_1111), 8)]
        [TestCase(unchecked((int)0b1111_0100_1000_1000_0100_0001_0011_1111), 5)]
        public void BinaryGapMaxLengthEfficient_Returns_Expected_Result(int value, int expected)
        {
            // act
            int actual = value.BinaryGapMaxLengthEfficient();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

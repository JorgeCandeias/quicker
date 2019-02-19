using Quicker.Algorithms.Pairing;
using Xunit;

namespace Quicker.Tests
{
    public class PairingTests
    {
        [Theory]
        [InlineData(new[] { 1, 1 }, null)]
        [InlineData(new[] { 1, 1, 2 }, 2)]
        [InlineData(new[] { 1, 1, 2, 2, 3 }, 3)]
        [InlineData(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [InlineData(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByIterating_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.Equal(expected, PairingAlgorithm.FindOddOneOutByIterating(values));
        }

        [Theory]
        [InlineData(new[] { 1, 1 }, null)]
        [InlineData(new[] { 1, 1, 2 }, 2)]
        [InlineData(new[] { 1, 1, 2, 2, 3 }, 3)]
        [InlineData(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [InlineData(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByHashing_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.Equal(expected, PairingAlgorithm.FindOddOneOutByHashing(values));
        }

        [Theory]
        [InlineData(new[] { 1, 1 }, null)]
        [InlineData(new[] { 1, 1, 2 }, 2)]
        [InlineData(new[] { 1, 1, 2, 2, 3 }, 3)]
        [InlineData(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [InlineData(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByOrdering_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.Equal(expected, PairingAlgorithm.FindOddOneOutByOrdering(values));
        }

        [Theory]
        [InlineData(new[] { 1, 1 }, null)]
        [InlineData(new[] { 1, 1, 2 }, 2)]
        [InlineData(new[] { 1, 1, 2, 2, 3 }, 3)]
        [InlineData(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [InlineData(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutHybrid_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.Equal(expected, PairingAlgorithm.FindOddOneOutHybrid(values));
        }
    }
}

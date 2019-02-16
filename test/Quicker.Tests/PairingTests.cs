using NUnit.Framework;
using Quicker.Algorithms.Pairing;

namespace Quicker.Tests
{
    public class PairingTests
    {
        [TestCase(new[] { 1, 1 }, null)]
        [TestCase(new[] { 1, 1, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, 3)]
        [TestCase(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [TestCase(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByIterating_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.AreEqual(expected, PairingAlgorithm.FindOddOneOutByIterating(values));
        }

        [TestCase(new[] { 1, 1 }, null)]
        [TestCase(new[] { 1, 1, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, 3)]
        [TestCase(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [TestCase(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByHashing_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.AreEqual(expected, PairingAlgorithm.FindOddOneOutByHashing(values));
        }

        [TestCase(new[] { 1, 1 }, null)]
        [TestCase(new[] { 1, 1, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, 3)]
        [TestCase(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [TestCase(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByOrdering_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.AreEqual(expected, PairingAlgorithm.FindOddOneOutByOrdering(values));
        }

        [TestCase(new[] { 1, 1 }, null)]
        [TestCase(new[] { 1, 1, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, 3)]
        [TestCase(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [TestCase(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutHybrid_Returns_Expected_Result(int[] values, int? expected)
        {
            Assert.AreEqual(expected, PairingAlgorithm.FindOddOneOutHybrid(values));
        }
    }
}

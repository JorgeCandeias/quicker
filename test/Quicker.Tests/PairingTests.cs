using NUnit.Framework;
using Quicker.Algorithms.Pairing;
using System.Collections.Generic;

namespace Quicker.Tests
{
    public class PairingTests
    {
        [TestCase(new[] { 1, 1 }, null)]
        [TestCase(new[] { 1, 1, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, 3)]
        [TestCase(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [TestCase(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindOddOneOutByIterating_Returns_Expected_Result(IEnumerable<int> values, int? expected)
        {
            Assert.AreEqual(expected, PairingAlgorithm.FindOddOneOutByIterating(values));
        }

        [TestCase(new[] { 1, 1 }, null)]
        [TestCase(new[] { 1, 1, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2, 3 }, 3)]
        [TestCase(new[] { 4, 1, 1, 2, 2, 3, 3 }, 4)]
        [TestCase(new[] { 4, 4, 1, 1, 5, 2, 2, 3, 3 }, 5)]
        public void FindFirstOddOneOutByHashing_Returns_Expected_Result(IEnumerable<int> values, int? expected)
        {
            Assert.AreEqual(expected, PairingAlgorithm.FindFirstOddOneOutByHashing(values));
        }
    }
}

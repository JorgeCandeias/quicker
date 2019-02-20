using Quicker.Algorithms.CyclicRotation;
using System;
using System.Linq;
using Xunit;

namespace Quicker.Tests
{
    public class CyclicRotationTests
    {
        [Theory]
        [InlineData(new int[] { 0 }, 0, new int[] { 0 })]
        [InlineData(new int[] { 0 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 0, 1 }, 1, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 })]
        public void CyclicRotation_RotateByRemainderIndexing_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByRemainderIndexing(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }
    }
}

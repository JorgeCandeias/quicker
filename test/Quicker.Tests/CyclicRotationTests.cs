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
        [InlineData(new int[] { 1 }, 0, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 0, new int[] { 2 })]
        [InlineData(new int[] { 0 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 1, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, 1, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 2, 3, 4, 5, 0, 1 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void CyclicRotation_RotateByRemainderIndexing_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByRemainderIndexing(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 0, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 0, new int[] { 2 })]
        [InlineData(new int[] { 0 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 1, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, 1, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 2, 3, 4, 5, 0, 1 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void CyclicRotation_RotateByArrayCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByArrayCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 0, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 0, new int[] { 2 })]
        [InlineData(new int[] { 0 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 1, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, 1, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 2, 3, 4, 5, 0, 1 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void CyclicRotation_RotateByBufferCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByBufferCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 0, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 0, new int[] { 2 })]
        [InlineData(new int[] { 0 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 1, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, 1, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 2, 3, 4, 5, 0, 1 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void CyclicRotation_RotateBySpanCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateBySpanCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new int[] { 0 }, 0, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 0, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 0, new int[] { 2 })]
        [InlineData(new int[] { 0 }, 1, new int[] { 0 })]
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(new int[] { 2 }, 1, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, 1, new int[] { 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 2, 3, 4, 5, 0, 1 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 6, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void CyclicRotation_RotateByUnsafeCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByUnsafeCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }
    }
}

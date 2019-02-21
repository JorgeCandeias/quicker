using Quicker.Algorithms.CyclicRotation;
using System;
using System.Linq;
using Xunit;

namespace Quicker.Tests
{
    public class CyclicRotationTests
    {
        public class T1
        {
            public T1(int value)
            {
                Value = value;
            }

            public int Value { get; }
        }

        public class ValueTestData : TheoryData<int[], int, int[]>
        {
            public ValueTestData()
            {
                Add(new int[] { 0 }, 0, new int[] { 0 });
                Add(new int[] { 1 }, 0, new int[] { 1 });
                Add(new int[] { 2 }, 0, new int[] { 2 });
                Add(new int[] { 0 }, 1, new int[] { 0 });
                Add(new int[] { 1 }, 1, new int[] { 1 });
                Add(new int[] { 2 }, 1, new int[] { 2 });
                Add(new int[] { 0, 1 }, 1, new int[] { 1, 0 });
                Add(new int[] { 0, 1, 2, 3, 4, 5 }, 1, new int[] { 5, 0, 1, 2, 3, 4 });
                Add(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 4, 5, 0, 1, 2, 3 });
                Add(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 3, 4, 5, 0, 1, 2 });
                Add(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 2, 3, 4, 5, 0, 1 });
                Add(new int[] { 0, 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4, 5, 0 });
                Add(new int[] { 0, 1, 2, 3, 4, 5 }, 6, new int[] { 0, 1, 2, 3, 4, 5 });
            }
        }

        public class ReferenceTestData : TheoryData<T1[], int, T1[]>
        {
            public ReferenceTestData()
            {
                Add(new T1[] { new T1(0) }, 0, new T1[] { 0 });
                Add(new T1[] { 1 }, 0, new T1[] { 1 });
                Add(new T1[] { 2 }, 0, new T1[] { 2 });
                Add(new T1[] { 0 }, 1, new T1[] { 0 });
                Add(new T1[] { 1 }, 1, new T1[] { 1 });
                Add(new T1[] { 2 }, 1, new T1[] { 2 });
                Add(new T1[] { 0, 1 }, 1, new T1[] { 1, 0 });
                Add(new T1[] { 0, 1, 2, 3, 4, 5 }, 1, new T1[] { 5, 0, 1, 2, 3, 4 });
                Add(new T1[] { 0, 1, 2, 3, 4, 5 }, 2, new T1[] { 4, 5, 0, 1, 2, 3 });
                Add(new T1[] { 0, 1, 2, 3, 4, 5 }, 3, new T1[] { 3, 4, 5, 0, 1, 2 });
                Add(new T1[] { 0, 1, 2, 3, 4, 5 }, 4, new T1[] { 2, 3, 4, 5, 0, 1 });
                Add(new T1[] { 0, 1, 2, 3, 4, 5 }, 5, new T1[] { 1, 2, 3, 4, 5, 0 });
                Add(new T1[] { 0, 1, 2, 3, 4, 5 }, 6, new T1[] { 0, 1, 2, 3, 4, 5 });
            }
        }

        [Theory]
        [ClassData(typeof(ValueTestData))]
        [ClassData(typeof(ReferenceTestData))]
        public void CyclicRotation_RotateByRemainderIndexing_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByRemainderIndexing(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [ClassData(typeof(ValueTestData))]
        public void CyclicRotation_RotateByArrayCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByArrayCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [ClassData(typeof(ValueTestData))]
        public void CyclicRotation_RotateByBufferCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByBufferCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [ClassData(typeof(ValueTestData))]
        public void CyclicRotation_RotateBySpanCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateBySpanCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Theory]
        [ClassData(typeof(ValueTestData))]
        public void CyclicRotation_RotateByUnsafeCopy_Returns_Expected_Result(int[] input, int distance, int[] expected)
        {
            // act
            var result = CyclicRotationAlgorithm.RotateByUnsafeCopy(input, distance);

            // assert
            Assert.True(result.SequenceEqual(expected));
        }
    }
}

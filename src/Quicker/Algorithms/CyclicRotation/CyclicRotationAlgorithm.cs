using System;

namespace Quicker.Algorithms.CyclicRotation
{
    public static class CyclicRotationAlgorithm
    {
        public static T[] RotateByRemainderIndexing<T>(T[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));

            // special cases
            var result = new T[input.Length];
            if (input.Length < 2) return result;
            if (distance == 0) return result;

            // rotate
            for (int i = 0; i < input.Length; ++i)
            {
                int j = (i + distance) % input.Length;
                result[j] = input[i];
            }
            return result;
        }
    }
}

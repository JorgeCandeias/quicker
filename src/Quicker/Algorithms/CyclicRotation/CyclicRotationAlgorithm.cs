using System;
using System.Runtime.CompilerServices;

namespace Quicker.Algorithms.CyclicRotation
{
    public static class CyclicRotationAlgorithm
    {
        public static int[] RotateByRemainderIndexing(int[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));
            if (input.Length == 0) return new int[0];

            // rotate
            var result = new int[input.Length];
            for (int i = 0; i < input.Length; ++i)
            {
                int j = (i + distance) % input.Length;
                result[j] = input[i];
            }
            return result;
        }

        public static int[] RotateByArrayCopy(int[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));
            if (input.Length == 0) return new int[0];

            // rotate
            var result = new int[input.Length];
            int diff = distance % input.Length;
            Array.Copy(input, 0, result, diff, input.Length - diff);
            Array.Copy(input, input.Length - diff, result, 0, diff);
            return result;
        }

        public static int[] RotateByBufferCopy(int[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));
            if (input.Length == 0) return new int[0];

            // rotate
            var size = sizeof(int);
            var result = new int[input.Length];
            int diff = distance % input.Length;
            Buffer.BlockCopy(input, 0, result, diff * size, (input.Length - diff) * size);
            Buffer.BlockCopy(input, (input.Length - diff) * size, result, 0, diff * size);
            return result;
        }

        public static int[] RotateBySpanCopy(int[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));
            if (input.Length == 0) return new int[0];

            // rotate
            var result = new int[input.Length];
            var target = new Span<int>(result);
            var diff = distance % input.Length;
            var source1 = new Span<int>(input, 0, input.Length - diff);
            source1.CopyTo(target.Slice(diff, input.Length - diff));
            var source2 = new Span<int>(input, input.Length - diff, diff);
            source2.CopyTo(target.Slice(0, diff));

            return result;
        }

        public unsafe static int[] RotateByUnsafeCopy(int[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));
            if (input.Length == 0) return new int[0];

            // prepare to rotate
            var result = new int[input.Length];
            var size = Unsafe.SizeOf<int>();
            var diff = distance % input.Length;

            // pin memory locations
            using (var target1 = result.AsMemory(diff, input.Length - diff).Pin())
            using (var slice1 = input.AsMemory(0, input.Length - diff).Pin())
            using (var target2 = result.AsMemory(0, diff).Pin())
            using (var slice2 = input.AsMemory(input.Length - diff, diff).Pin())
            {
                // copy the underlying memory in the array
                Unsafe.CopyBlock(target1.Pointer, slice1.Pointer, (uint)((input.Length - diff) * size));
                Unsafe.CopyBlock(target2.Pointer, slice2.Pointer, (uint)(diff * size));
            }

            return result;
        }
    }
}

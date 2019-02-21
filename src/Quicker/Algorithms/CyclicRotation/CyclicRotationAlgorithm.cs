using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Quicker.Algorithms.CyclicRotation
{
    public static class CyclicRotationAlgorithm
    {
        public static T[] RotateByRemainderIndexing<T>(T[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));

            // rotate
            var result = new T[input.Length];
            for (int i = 0; i < input.Length; ++i)
            {
                int j = (i + distance) % input.Length;
                result[j] = input[i];
            }
            return result;
        }

        public static T[] RotateByArrayCopy<T>(T[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));

            // rotate
            var result = new T[input.Length];
            int diff = distance % input.Length;
            Array.Copy(input, 0, result, diff, input.Length - diff);
            Array.Copy(input, input.Length - diff, result, 0, diff);
            return result;
        }

        public static T[] RotateByBufferCopy<T>(T[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));

            // rotate
            var size = Marshal.SizeOf<T>();
            var result = new T[input.Length];
            int diff = distance % input.Length;
            Buffer.BlockCopy(input, 0, result, diff * size, (input.Length - diff) * size);
            Buffer.BlockCopy(input, (input.Length - diff) * size, result, 0, diff * size);
            return result;
        }

        public static T[] RotateBySpanCopy<T>(T[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));

            // rotate
            var result = new T[input.Length];
            var target = new Span<T>(result);
            var diff = distance % input.Length;
            var source1 = new Span<T>(input, 0, input.Length - diff);
            source1.CopyTo(target.Slice(diff, input.Length - diff));
            var source2 = new Span<T>(input, input.Length - diff, diff);
            source2.CopyTo(target.Slice(0, diff));

            return result;
        }

        public unsafe static T[] RotateByUnsafeCopy<T>(T[] input, int distance)
        {
            // validate
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (distance < 0) throw new ArgumentOutOfRangeException(nameof(distance));

            // rotate
            var result = new T[input.Length];
            var size = Marshal.SizeOf<T>();
            var diff = distance % input.Length;
            using (var target1 = result.AsMemory(diff, input.Length - diff).Pin())
            using (var slice1 = input.AsMemory(0, input.Length - diff).Pin())
            using (var target2 = result.AsMemory(0, diff).Pin())
            using (var slice2 = input.AsMemory(input.Length - diff, diff).Pin())
            {
                void* t1 = target1.Pointer;
                void* s1 = slice1.Pointer;
                Unsafe.CopyBlock(t1, s1, (uint)((input.Length - diff) * size));
                Unsafe.CopyBlock(target2.Pointer, slice2.Pointer, (uint)(diff * size));
            }

            return result;
        }
    }
}

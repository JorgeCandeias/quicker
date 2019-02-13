using System;

namespace Quicker
{
    public enum BinaryGapMethod
    {
        /// <summary>
        /// Use an efficient approach of shifting the value and applying a mask.
        /// </summary>
        Shift = 0,

        /// <summary>
        /// Use a simple approach of iterating individual bits in the int via its string representation.
        /// Useful for performance baselining only.
        /// </summary>
        Iterate = -1
    }

    public enum BinaryGapBit
    {
        /// <summary>
        /// Look for gaps where the bits are unset.
        /// </summary>
        Unset = 0,

        /// <summary>
        /// Look for gaps where the bits are set.
        /// </summary>
        Set = 1
    }

    public static class BinaryGapExtensions
    {
        /// <summary>
        /// Finds the length of the maximum binary bag in the given number by using the given method.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="method">The algorithm method. Defaults to <see cref="BinaryGapMethod.Shift"/></param>
        /// <returns>The length of the maximum binary gap or zero if there is none.</returns>
        public static int BinaryGapMaxLength(this int value, BinaryGapMethod method = BinaryGapMethod.Shift, BinaryGapBit gapBit = BinaryGapBit.Unset)
        {
            switch (method)
            {
                case BinaryGapMethod.Shift:
                    return BinaryGapMaxLengthByShifting(value);

                case BinaryGapMethod.Iterate:
                    return BinaryGapMaxLengthByIterating(value);

                default:
                    throw new ArgumentException(nameof(method));
            }
        }

        /// <summary>
        /// Finds the length of the maximum binary gap in the given number by using an efficient algorithm.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns></returns>
        public static int BinaryGapMaxLengthByIterating(this int value, BinaryGapBit bit = BinaryGapBit.Unset)
        {
            // trackers
            int max_gap = 0;
            int gap = 0;
            char mask = bit == BinaryGapBit.Unset ? '1' : '0';

            // convert the value to a binary string
            var binary = Convert.ToString(value, 2);

            // iterate until the first set bit
            int i = 0;
            while (i < binary.Length && binary[i] != mask)
            {
                ++i;
            }

            // we are either at the first set bit or have run out of bits
            for (; i < binary.Length; ++i)
            {
                // check if the current bit is set
                if (binary[i] == mask)
                {
                    // check if the current gap is greater than the max candidate
                    if (gap > max_gap)
                    {
                        // promote the current gap count to max candidate
                        max_gap = gap;
                    }

                    // close the running gap count
                    gap = 0;
                }
                else
                {
                    // if zero then increase the running gap count
                    ++gap;
                }
            }

            // at this point we have the greatest gap length or zero
            return max_gap;
        }

        /// <summary>
        /// Finds the length of the maximum binary gap in the given number by using an efficient algorithm.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns></returns>
        public static int BinaryGapMaxLengthByShifting(this int value, BinaryGapBit bit = BinaryGapBit.Unset)
        {
            // trackers
            int max_gap = 0;
            int gap = 0;
            int mask = 1;

            // if searching for gaps of ones just flip the bits in the search space
            if (bit == BinaryGapBit.Set)
            {
                value = ~value;
            }

            // shift until the first set bit
            while ((mask & value) == 0 && mask != 0)
            {
                mask <<= 1;
            }

            // shift one more time to skip it
            // this avoid a duplicate comparison on the next step
            mask <<= 1;

            // we are either at the first set bit or have run out of bits
            for (; mask != 0; mask <<= 1)
            {
                // check if the current bit is set
                if ((mask & value) == mask)
                {
                    // check if the current gap is greater than the max candidate
                    if (gap > max_gap)
                    {
                        // promote the current gap count to max candidate
                        max_gap = gap;
                    }

                    // close the running gap count
                    gap = 0;
                }
                else
                {
                    // if zero then increase the running gap count
                    ++gap;
                }
            }

            // at this point we have the greatest gap length or zero
            return max_gap;
        }
    }
}

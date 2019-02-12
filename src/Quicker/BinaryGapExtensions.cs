using System;

namespace Quicker
{
    public enum BinaryGapMethod
    {
        /// <summary>
        /// Use an efficient approach.
        /// </summary>
        Efficient = 0,

        /// <summary>
        /// Use a simple approach.
        /// Useful for performance comparison only.
        /// </summary>
        Simple = -1
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
        /// <param name="method">The algorithm method. Defaults to <see cref="BinaryGapMethod.Efficient"/></param>
        /// <returns>The length of the maximum binary gap or zero if there is none.</returns>
        public static int BinaryGapMaxLength(this int value, BinaryGapMethod method = BinaryGapMethod.Efficient, BinaryGapBit gapBit = BinaryGapBit.Unset)
        {
            switch (method)
            {
                case BinaryGapMethod.Efficient:
                    return BinaryGapMaxLengthEfficient(value);

                default:
                    throw new ArgumentException(nameof(method));
            }
        }

        /// <summary>
        /// Finds the length of the maximum binary gap in the given number by using an efficient algorithm.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns></returns>
        public static int BinaryGapMaxLengthEfficient(this int value, BinaryGapBit bit = BinaryGapBit.Unset)
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
            while (mask != 0 && (mask & value) == 0)
            {
                mask <<= 1;
            }

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

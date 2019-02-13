using System;

namespace Quicker.Algorithms
{
    public static class BinaryGapAlgorithm
    {
        /// <summary>
        /// Finds the length of the maximum binary gap in the given number by using an efficient algorithm.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns></returns>
        public static int MaxLengthByIterating(int value, BinaryGapBit bit = BinaryGapBit.Unset)
        {
            // trackers
            int max_gap = 0;
            int gap = 0;
            char mask = bit == BinaryGapBit.Unset ? '1' : '0';

            // convert the value to a binary string
            string binary = Convert.ToString(value, 2);

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
        public static int MaxLengthByShifting(int value, BinaryGapBit bit = BinaryGapBit.Unset)
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

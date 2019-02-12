using System;
using System.Collections.Generic;
using System.Text;

namespace Quicker
{
    public static class BinaryGapExtensions
    {
        /// <summary>
        /// Finds the length of the maximum binary gap in the given number by using an efficient algorithm.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <returns></returns>
        public static int BinaryGapMaxLengthEfficient(this int value)
        {
            // trackers
            int max_gap = 0;
            int gap = 0;
            int mask = 1;

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

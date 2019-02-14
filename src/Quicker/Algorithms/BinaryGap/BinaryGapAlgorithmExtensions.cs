using System;

namespace Quicker.Algorithms.BinaryGap
{
    /// <summary>
    /// Helper extensions to faciliate fluent code.
    /// </summary>
    public static class BinaryGapAlgorithmExtensions
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
                    return BinaryGapAlgorithm.MaxLengthByShifting(value, gapBit);

                case BinaryGapMethod.Iterate:
                    return BinaryGapAlgorithm.MaxLengthByIterating(value, gapBit);

                default:
                    throw new ArgumentException(nameof(method));
            }
        }
    }
}

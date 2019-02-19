namespace Quicker.Algorithms.BinaryGap
{
    /// <summary>
    /// Helper extensions to faciliate fluent code.
    /// </summary>
    public static class BinaryGapAlgorithmExtensions
    {
        /// <summary>
        /// Finds the length of the maximum binary bag in the given number.
        /// </summary>
        /// <param name="value">The number to evaluate.</param>
        /// <returns>The length of the maximum binary gap or zero if there is none.</returns>
        public static int BinaryGapMaxLength(this int value, BinaryGapBit gapBit = BinaryGapBit.Unset)
        {
            return BinaryGapAlgorithm.MaxLengthByShifting(value, gapBit);
        }
    }
}

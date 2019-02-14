namespace Quicker.Algorithms.BinaryGap
{
    /// <summary>
    /// Defines what method to use for the binary gap algorithm.
    /// </summary>
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
}

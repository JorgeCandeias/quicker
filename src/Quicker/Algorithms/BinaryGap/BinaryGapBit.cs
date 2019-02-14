namespace Quicker.Algorithms.BinaryGap
{
    /// <summary>
    /// Whether to search for unset (zero) or set (one) binary gaps.
    /// </summary>
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
}

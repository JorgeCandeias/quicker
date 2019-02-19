using System;

namespace Quicker.Algorithms.Pairing
{
    /// <summary>
    /// Faciliates use of the <see cref="PairingAlgorithm"/> in Linq expression.
    /// </summary>
    public static class PairingAlgorithmExtensions
    {
        /// <summary>
        /// Finds the odd one out in the given sequence.
        /// </summary>
        /// <param name="values">The sequence to evaluate.</param>
        /// <param name="orderingThreshold">The collection size threshold from which to use the ordering-based algorithm.</param>
        /// <param name="hashingThreshold">The collection size threshold from which to use the hashing-based algorithm.</param>
        /// <returns>The odd one out or <see cref="null"/> if none is found.</returns>
        public static int? FindOddOneOut(this int[] values, int orderingThreshold = 10, int hashingThreshold = 10000)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            return PairingAlgorithm.FindOddOneOutHybrid(values, orderingThreshold, hashingThreshold);
        }
    }
}

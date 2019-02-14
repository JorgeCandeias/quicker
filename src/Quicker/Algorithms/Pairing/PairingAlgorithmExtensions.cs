namespace Quicker.Algorithms.Pairing
{
    /// <summary>
    /// Faciliates use of the <see cref="PairingAlgorithm"/> in Linq expression.
    /// </summary>
    public static class PairingAlgorithmExtensions
    {
        public static int? FindOddOneOut(this int[] values)
        {
            return PairingAlgorithm.FindOddOneOutByHashing(values);
        }
    }
}

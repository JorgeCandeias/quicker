using System;
using System.Collections.Generic;
using System.Linq;

namespace Quicker.Algorithms.Pairing
{
    public class PairingAlgorithm
    {
        public static int? FindOddOneOutHybrid(int[] values, int orderingThreshold = 10, int hashingThreshold = 10000)
        {
            if (values.Length > hashingThreshold) return FindOddOneOutByHashing(values);
            if (values.Length > orderingThreshold) return FindOddOneOutByOrdering(values);
            return FindOddOneOutByIterating(values);
        }

        public static int? FindOddOneOutByIterating(int[] values)
        {
            // keep track of items already tested
            var tested = new HashSet<int>();

            // check each item in the array
            for (int i = 0; i < values.Length; ++i)
            {
                // check if we have tested this value already
                if (tested.Contains(values[i]))
                {
                    continue;
                }

                // count the number of times this value shows in the array
                int count = 0;
                for (int j = 0; j < values.Length; ++j)
                {
                    if (values[i] == values[j])
                    {
                        ++count;
                    }
                }

                // check if it appears an odd number of times
                if (count % 2 != 0)
                {
                    return values[i];
                }

                // mark this value as tested
                tested.Add(values[i]);
            }

            // we did not find an unpaired item
            return null;
        }

        public static int? FindOddOneOutByOrdering(int[] values)
        {
            // we need at least one item for this algorithm to make sense
            int count = 0;
            int? last_value = null;

            // copy and sort the array
            var sorted = new int[values.Length];
            Array.Copy(values, sorted, values.Length);
            Array.Sort(sorted);

            // look for odd occurrences of a value until we find one
            for (int i = 0; i < sorted.Length; ++i)
            {
                if (sorted[i] == last_value)
                {
                    ++count;
                }
                else
                {
                    if (count % 2 != 0)
                    {
                        return sorted[i];
                    }
                    else
                    {
                        count = 1;
                        last_value = sorted[i];
                    }
                }
            }

            // extra check for the last value
            return (count % 2 != 0 ? last_value : null);
        }

        public static int? FindOddOneOutByHashing(int[] values)
        {
            // prepare a lookup for on-the-go checks
            var candidates = new HashSet<int>();

            // check each item in the enumeration
            for (int i = 0; i < values.Length; ++i)
            {
                // check if we have found this value once before
                if (candidates.Contains(values[i]))
                {
                    // if yes then it is no longer a candidate for odd occurrences
                    candidates.Remove(values[i]);
                }
                else
                {
                    // if not then it is either the first time it appears in the enumeration
                    // or all previous appearances have found a pair
                    // in that case we add it to the lookup as a new candidate for odd occurences
                    candidates.Add(values[i]);
                }
            }

            // check if any candidate survived
            if (candidates.Count > 0)
            {
                return candidates.First();
            }
            else
            {
                return null;
            }
        }
    }
}

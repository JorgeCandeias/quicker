using System.Collections.Generic;
using System.Linq;

namespace Quicker.Algorithms.Pairing
{
    public class PairingAlgorithm
    {
        public static int? FindOddOneOutByIterating(IEnumerable<int> values)
        {
            // convert to array to avoid iterating the enumerable twice
            var array = values.ToArray();

            // check each item in the array
            foreach (int value in array)
            {
                // count the number of times this value shows in the array
                int count = 0;
                foreach (int other in array)
                {
                    if (other == value)
                    {
                        ++count;
                    }
                }

                // check if it appears an odd number of times
                if (count % 2 != 0)
                {
                    return value;
                }
            }

            // we did not find an unpaired item
            return null;
        }

        public static int? FindFirstOddOneOutByHashing(IEnumerable<int> values)
        {
            // prepare a lookup for on-the-go checks
            var found = new HashSet<int>();

            // check each item in the enumeration
            foreach (int value in values)
            {
                // check if we have found this value once before
                if (found.Contains(value))
                {
                    // if yes then it is no longer a candidate for odd occurrences
                    found.Remove(value);
                }
                else
                {
                    // if not then it is either the first time it appears in the enumeration
                    // or all previous appearances have found a pair
                    // in that case we add it to the lookup as a new candidate for odd occurences
                    found.Add(value);
                }
            }

            // check if any candidate survived
            if (found.Count > 0)
            {
                return found.First();
            }
            else
            {
                return null;
            }
        }
    }
}

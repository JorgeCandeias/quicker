using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;
using Quicker.Algorithms.Pairing;
using System.Linq;

namespace Quicker.Benchmarks
{
    public class PairingBenchmarks
    {
        /// <summary>
        /// In a worst case scenario, the odd value out is at the end of the input.
        /// </summary>
        [RankColumn(NumeralSystem.Stars)]
        [MarkdownExporterAttribute.GitHub]
        public class PairingBenchmarksWorstCase
        {
            [Params(1, 11, 101, 1001, 10001, 100001)]
            public int N { get; set; }

            [GlobalSetup]
            public void Setup()
            {
                int div = N < 2 ? 1 : N / 2;
                _input = Enumerable
                    .Range(0, N - 1)
                    .Select(x => x % div)
                    .Concat(new[] { N })
                    .ToArray();
            }

            private int[] _input;

            [Benchmark(Baseline = true)]
            public int? FindOddOneOutByIterating()
            {
                return PairingAlgorithm.FindOddOneOutByIterating(_input);
            }

            [Benchmark]
            public int? FindOddOneOutByOrdering()
            {
                return PairingAlgorithm.FindOddOneOutByOrdering(_input);
            }

            [Benchmark]
            public int? FindOddOneOutByHashing()
            {
                return PairingAlgorithm.FindOddOneOutByHashing(_input);
            }
        }

        /// <summary>
        /// In a best case scenario, the odd value out is at the beginning of the input.
        /// </summary>
        [RankColumn(NumeralSystem.Stars)]
        [MarkdownExporterAttribute.GitHub]
        public class PairingBenchmarksBestCase
        {
            [Params(1, 11, 101, 1001, 10001, 100001)]
            public int N { get; set; }

            [GlobalSetup]
            public void Setup()
            {
                int div = N < 2 ? 1 : N / 2;
                _input = Enumerable
                    .Range(0, N)
                    .Select(x => x % div)
                    .ToArray();
            }

            private int[] _input;

            [Benchmark(Baseline = true)]
            public int? FindOddOneOutByIterating()
            {
                return PairingAlgorithm.FindOddOneOutByIterating(_input);
            }

            [Benchmark]
            public int? FindOddOneOutByOrdering()
            {
                return PairingAlgorithm.FindOddOneOutByOrdering(_input);
            }

            [Benchmark]
            public int? FindOddOneOutByHashing()
            {
                return PairingAlgorithm.FindOddOneOutByHashing(_input);
            }
        }
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using Quicker.Algorithms.CyclicRotation;
using System.Linq;

namespace Quicker.Benchmarks
{
    [RankColumn(NumeralSystem.Stars)]
    [MarkdownExporter]
    [MemoryDiagnoser]
    public class CyclicRotationBenchmark
    {
        [Params(10, 100, 1000, 10000, 100000, 1000000, 10000000)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            input = Enumerable.Range(1, N).ToArray();
            distance = N % 2 + 1;
        }

        private int[] input;
        private int distance;

        [Benchmark(Baseline = true)]
        public int[] RotateByRemainderIndexing()
        {
            return CyclicRotationAlgorithm.RotateByRemainderIndexing(input, distance);
        }

        [Benchmark]
        public int[] RotateByArrayCopy()
        {
            return CyclicRotationAlgorithm.RotateByArrayCopy(input, distance);
        }

        [Benchmark]
        public int[] RotateByBufferCopy()
        {
            return CyclicRotationAlgorithm.RotateByBufferCopy(input, distance);
        }

        [Benchmark]
        public int[] RotateBySpanCopy()
        {
            return CyclicRotationAlgorithm.RotateBySpanCopy(input, distance);
        }

        [Benchmark]
        public int[] RotateByUnsafeCopy()
        {
            return CyclicRotationAlgorithm.RotateByUnsafeCopy(input, distance);
        }
    }
}

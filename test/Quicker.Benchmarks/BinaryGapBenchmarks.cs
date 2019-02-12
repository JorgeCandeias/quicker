using BenchmarkDotNet.Attributes;

namespace Quicker.Benchmarks
{
    public class BinaryGapBenchmarks
    {
        [Benchmark]
        public int BinaryGapMaxLength()
        {
            return 1234567890.BinaryGapMaxLength(BinaryGapMethod.Efficient, BinaryGapBit.Unset);
        }
    }
}

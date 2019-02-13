using BenchmarkDotNet.Attributes;

namespace Quicker.Benchmarks
{
    [AsciiDocExporter]
    public class BinaryGapBenchmarks
    {
        [Benchmark(Baseline = true)]
        public int BinaryGapMaxLengthByIterating()
        {
            return 0b1011_0111_0111_1011_1110_1111_110_1111.BinaryGapMaxLengthByIterating(BinaryGapBit.Unset);
        }

        [Benchmark]
        public int BinaryGapMaxLengthByShifting()
        {
            return 0b1011_0111_0111_1011_1110_1111_110_1111.BinaryGapMaxLengthByShifting(BinaryGapBit.Unset);
        }
    }
}
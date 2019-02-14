using BenchmarkDotNet.Attributes;
using Quicker.Algorithms.BinaryGap;

namespace Quicker.Benchmarks
{
    [AsciiDocExporter]
    [CsvExporter, CsvMeasurementsExporter, JsonExporter]
    public class BinaryGapBenchmarks
    {
        [Benchmark(Baseline = true)]
        public int BinaryGapMaxLengthByIterating()
        {
            return BinaryGapAlgorithm.MaxLengthByIterating(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Unset);
        }

        [Benchmark]
        public int BinaryGapMaxLengthByShifting()
        {
            return BinaryGapAlgorithm.MaxLengthByShifting(0b1011_0111_0111_1011_1110_1111_110_1111, BinaryGapBit.Unset);
        }
    }
}
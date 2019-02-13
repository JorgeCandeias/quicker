using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;

namespace Quicker.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summaries = BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args, new DebugBuildConfig());

            foreach (var summary in summaries)
            {
                foreach (var benchmarkCase in summary.BenchmarksCases)
                {
                    var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
                    var stats = summary[benchmarkCase].ResultStatistics;
                }
            }

            Console.ReadLine();
        }
    }
}

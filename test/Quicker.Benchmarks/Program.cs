using BenchmarkDotNet.Running;
using System;

namespace Quicker.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args);

            Console.ReadLine();
        }
    }
}

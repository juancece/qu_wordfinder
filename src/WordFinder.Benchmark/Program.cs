using BenchmarkDotNet.Running;

namespace WordFinder.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<WordFinderBenchmark>();
        }
    }
}

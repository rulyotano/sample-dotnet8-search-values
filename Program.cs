// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using sample_dotnet8_search_values;

BenchmarkRunner.Run(typeof(Benchmarks).Assembly);

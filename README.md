# sample-dotnet8-search-values

Benchmark to measure how fast is the new `SearchValues` from dotnet8.

## Benchmark results

```
BenchmarkDotNet v0.13.10, macOS Sonoma 14.1 (23B74) [Darwin 23.1.0]
Intel Core i5-4570R CPU 2.70GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

| Method                                  | TestStringSize | Mean       | Error     | StdDev    |
|---------------------------------------- |--------------- |-----------:|----------:|----------:|
| OnlyContainsValidChars_Classic          | 100            | 101.449 ns | 2.0565 ns | 3.0781 ns |
| OnlyContainsValidChars_Span             | 100            | 101.138 ns | 2.0527 ns | 1.7141 ns |
| OnlyContainsValidChars_SpanSearchValues | 100            |   4.843 ns | 0.0338 ns | 0.0300 ns |
| OnlyContainsValidChars_Classic          | 10000          | 135.025 ns | 2.2359 ns | 1.9821 ns |
| OnlyContainsValidChars_Span             | 10000          |  98.559 ns | 1.3836 ns | 1.2265 ns |
| OnlyContainsValidChars_SpanSearchValues | 10000          |   4.817 ns | 0.0212 ns | 0.0188 ns |

// * Hints *
Outliers
  Benchmarks.OnlyContainsValidChars_Classic: Default          -> 4 outliers were removed (114.86 ns..166.15 ns)
  Benchmarks.OnlyContainsValidChars_Span: Default             -> 2 outliers were removed (109.43 ns, 115.48 ns)
  Benchmarks.OnlyContainsValidChars_SpanSearchValues: Default -> 1 outlier  was  removed (7.17 ns)
  Benchmarks.OnlyContainsValidChars_Classic: Default          -> 1 outlier  was  removed (145.00 ns)
  Benchmarks.OnlyContainsValidChars_Span: Default             -> 1 outlier  was  removed (109.41 ns)
  Benchmarks.OnlyContainsValidChars_SpanSearchValues: Default -> 1 outlier  was  removed (7.08 ns)

// * Legends *
  TestStringSize : Value of the 'TestStringSize' parameter
  Mean           : Arithmetic mean of all measurements
  Error          : Half of 99.9% confidence interval
  StdDev         : Standard deviation of all measurements
  1 ns           : 1 Nanosecond (0.000000001 sec)
```

## Conclusions
Search values is fast! 🤣
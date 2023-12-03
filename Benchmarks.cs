using System.Buffers;
using BenchmarkDotNet.Attributes;
using Bogus.DataSets;

namespace sample_dotnet8_search_values;

public class Benchmarks
{
  private string? _searchString;
  private const string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ012345689_";
  private SearchValues<char> validCharsSearchValues = SearchValues.Create(ValidChars);

  [Params(100, 10000)]
  public int TestStringSize { get; set; }

  [GlobalSetup]
  public void Setup()
  {
    _searchString = new Bogus.Randomizer().AlphaNumeric(TestStringSize);
    System.Console.WriteLine(_searchString);
  }

  [Benchmark]
  public bool OnlyContainsValidChars_Classic()
  {
    for (int i = 0; i < _searchString.Length; i++)
    {
      if (!ValidChars.Contains(_searchString[i])) return false;
    }
    return true;
  }

  [Benchmark]
  public bool OnlyContainsValidChars_Span()
  {
    return _searchString.AsSpan().IndexOfAnyExcept(ValidChars.AsSpan()) == -1;
  }

  [Benchmark]
  public bool OnlyContainsValidChars_SpanSearchValues()
  {
    return _searchString.AsSpan().IndexOfAnyExcept(validCharsSearchValues) == -1;
  }
}

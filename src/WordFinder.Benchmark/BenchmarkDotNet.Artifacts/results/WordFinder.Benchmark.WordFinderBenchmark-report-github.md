```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4112/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13900H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                     | Mean      | Error     | StdDev    | Gen0   | Allocated |
|--------------------------- |----------:|----------:|----------:|-------:|----------:|
| BenchmarkWordFinderHashSet |  6.283 μs | 0.0664 μs | 0.0589 μs | 0.0229 |     296 B |
| BenchmarkWordFinderTrie    | 22.438 μs | 0.3863 μs | 0.3614 μs | 2.9297 |   36768 B |

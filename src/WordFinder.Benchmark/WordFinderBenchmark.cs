using BenchmarkDotNet.Attributes;
using WordFinder.Implements;

namespace WordFinder.Benchmark;

[MemoryDiagnoser]
public class WordFinderBenchmark
{
    private IEnumerable<string> matrix;
    private IEnumerable<string> wordstream;
    private WordFinderHashSet wordFinderHashSet;
    private WordFinderTrie wordFinderTrie;

    public WordFinderBenchmark()
    {
        matrix = GenerateMatrix(64, 64);
        wordstream = GenerateWordStream(1000);

        wordFinderHashSet = new WordFinderHashSet(matrix);
        wordFinderTrie = new WordFinderTrie(matrix);
    }

    private IEnumerable<string> GenerateMatrix(int rows, int cols)
    {
        var random = new Random();
        var matrix = new List<string>();

        for (var i = 0; i < rows; i++)
        {
            var row = new char[cols];
            for (var j = 0; j < cols; j++)
            {
                row[j] = (char)('A' + random.Next(0, 26));
            }
            matrix.Add(new string(row));
        }

        return matrix;
    }

    private IEnumerable<string> GenerateWordStream(int count)
    {
        var random = new Random();
        var wordstream = new List<string>();

        for (var i = 0; i < count; i++)
        {
            var wordLength = random.Next(3, 10);
            var word = new char[wordLength];
            for (var j = 0; j < wordLength; j++)
            {
                word[j] = (char)('A' + random.Next(0, 26));
            }
            wordstream.Add(new string(word));
        }

        return wordstream;
    }

    [Benchmark]
    public void BenchmarkWordFinderHashSet()
    {
        wordFinderHashSet.Find(wordstream);
    }

    [Benchmark]
    public void BenchmarkWordFinderTrie()
    {
        wordFinderTrie.Find(wordstream);
    }
}
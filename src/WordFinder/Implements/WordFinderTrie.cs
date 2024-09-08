using WordFinder.Helper;
using WordFinder.Interfaces;

namespace WordFinder.Implements;
public class WordFinderTrie : IWordFinder
{
    private TrieNode root;

    public WordFinderTrie(IEnumerable<string> matrix)
    {
        if (matrix == null || !matrix.Any())
            throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null or empty.");
        
        if (matrix.Count() > 64 || matrix.First().Length > 64)
            throw new ArgumentException("Matrix dimensions cannot exceed 64x64.");
        
        root = new TrieNode();
        InitializeMatrix(matrix);
    }

    private void InitializeMatrix(IEnumerable<string> matrix)
    {
        foreach (var row in matrix)
        {
            root.AddWord(row);
        }

        int colCount = matrix.First().Length;
        for (int col = 0; col < colCount; col++)
        {
            var columnWord = new char[matrix.Count()];
            int rowIndex = 0;
            foreach (var row in matrix)
            {
                columnWord[rowIndex++] = row[col];
            }
            root.AddWord(new string(columnWord));
        }
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        if (wordstream == null)
            throw new ArgumentNullException(nameof(wordstream), "Word stream cannot be null.");

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (var word in wordstream)
        {
            if (root.SearchWord(word))
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount[word] = 0;
                }
                wordCount[word]++;
            }
        }

        var topWords = wordCount.OrderByDescending(pair => pair.Value)
                                .Take(10)
                                .Select(pair => pair.Key)
                                .ToList();

        return topWords.Any() ? topWords : Enumerable.Empty<string>();
    }
}

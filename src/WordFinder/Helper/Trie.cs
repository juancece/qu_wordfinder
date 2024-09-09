namespace WordFinder.Helper;

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode(' ');
    }

    public void Insert(string word)
    {
        word = word.ToLower();
        TrieNode current = root;
        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TrieNode(c);
            }
            current = current.Children[c];
        }
        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        word = word.ToLower();
        TrieNode current = root;
        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                return false;
            }
            current = current.Children[c];
        }
        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        prefix = prefix.ToLower();
        TrieNode current = root;
        foreach (char c in prefix)
        {
            if (!current.Children.ContainsKey(c))
            {
                return false;
            }
            current = current.Children[c];
        }
        return true;
    }
}
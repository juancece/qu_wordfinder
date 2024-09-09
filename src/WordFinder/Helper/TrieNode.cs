namespace WordFinder.Helper;

public class TrieNode
{
    public char Value { get; set; }
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }  // Indicates the end of a word

    public TrieNode(char value)
    {
        Value = value;
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}
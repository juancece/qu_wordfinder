using FluentAssertions;
using WordFinder.Implements;

namespace WordFinder.Tests;

public class WordFinderTrieTests
{
    [Fact]
    public void Constructor_NullMatrix_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string> matrix = null;

        // Act
        Action act = () => new WordFinderTrie(matrix);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Matrix cannot be null or empty. (Parameter 'matrix')");
    }

    [Fact]
    public void Constructor_EmptyMatrix_ThrowsArgumentNullException()
    {
        // Arrange
        var matrix = Enumerable.Empty<string>();

        // Act
        Action act = () => new WordFinderTrie(matrix);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Matrix cannot be null or empty. (Parameter 'matrix')");
    }

    [Fact]
    public void Constructor_MatrixExceeds64x64_ThrowsArgumentException()
    {
        // Arrange
        var matrix = Enumerable.Repeat(new string('A', 65), 65);

        // Act
        Action act = () => new WordFinderTrie(matrix);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Matrix dimensions cannot exceed 64x64.");
    }

    [Fact]
    public void Find_NullWordStream_ThrowsArgumentNullException()
    {
        // Arrange
        var matrix = new List<string> { "TEST" };
        var wordFinder = new WordFinderTrie(matrix);

        // Act
        Action act = () => wordFinder.Find(null);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Word stream cannot be null. (Parameter 'wordstream')");
    }

    [Fact]
    public void Find_ValidWordStream_ReturnsTopWords()
    {
        // Arrange
        var matrix = new List<string> { "TEST", "WORD", "FIND" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = new List<string> { "TEST", "WORD", "FIND", "NOTFOUND" };

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().Contain(new List<string> { "TEST", "WORD", "FIND" });
        result.Should().NotContain("NOTFOUND");
    }

    [Fact]
    public void Find_WordStreamWithDuplicates_ReturnsTopWords()
    {
        // Arrange
        var matrix = new List<string> { "TEST", "WORD", "FIND" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = new List<string> { "TEST", "WORD", "FIND", "TEST", "WORD", "TEST" };

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().Contain(new List<string> { "TEST", "WORD", "FIND" });
    }

    [Fact]
    public void Find_WordStreamWithSpecialCharacters_ReturnsTopWords()
    {
        // Arrange
        var matrix = new List<string> { "T@ST", "W#RD", "F!ND" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = new List<string> { "T@ST", "W#RD", "F!ND", "NOTFOUND" };

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().Contain(new List<string> { "T@ST", "W#RD", "F!ND" });
        result.Should().NotContain("NOTFOUND");
    }
    
    [Fact]
    public void Find_EmptyWordStream_ReturnsEmpty()
    {
        // Arrange
        var matrix = new List<string> { "TEST", "WORD", "FIND" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = Enumerable.Empty<string>();

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void Find_SingleCharacterMatrixAndWordStream_ReturnsCorrectly()
    {
        // Arrange
        var matrix = new List<string> { "A" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = new List<string> { "A" };

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().Contain(new List<string> { "A" });
    }

    [Fact]
    public void Find_MatrixWithMixedCase_ReturnsCorrectly()
    {
        // Arrange
        var matrix = new List<string> { "Test", "Word", "Find" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = new List<string> { "test", "word", "find" };

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().Contain(new List<string> { "test", "word", "find" });
    }

    [Fact]
    public void Find_MatrixWithOverlappingWords_ReturnsCorrectly()
    {
        // Arrange
        var matrix = new List<string> { "TEST", "ESTW", "STWO", "TWOR" };
        var wordFinder = new WordFinderTrie(matrix);
        var wordStream = new List<string> { "TEST", "ESTW", "STWO", "TWOR" };

        // Act
        var result = wordFinder.Find(wordStream);

        // Assert
        result.Should().Contain(new List<string> { "TEST", "ESTW", "STWO", "TWOR" });
    }
}
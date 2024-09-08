using FluentAssertions;
using WordFinder.Implements;
using WordFinder.Interfaces;

namespace WordFinder.Tests;

public class WordFinderHashSetTests
{
    [Fact]
    public void Constructor_NullMatrix_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string> matrix = null;

        // Act
        Action act = () => new WordFinderHashSet(matrix);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Matrix cannot be null or empty. (Parameter 'matrix')");
    }

    [Fact]
    public void Constructor_EmptyMatrix_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string> matrix = new List<string>();

        // Act
        Action act = () => new WordFinderHashSet(matrix);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Matrix cannot be null or empty. (Parameter 'matrix')");
    }

    [Fact]
    public void Constructor_MatrixExceeds64x64_ThrowsArgumentException()
    {
        // Arrange
        IEnumerable<string> matrix = new List<string>
        {
            "a".PadRight(65, 'a')
        };

        // Act
        Action act = () => new WordFinderHashSet(matrix);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Matrix dimensions cannot exceed 64x64.");
    }

    [Fact]
    public void Constructor_MatrixIs64x64_DoesNotThrowException()
    {
        // Arrange
        IEnumerable<string> matrix = new List<string>
        {
            "a".PadRight(64, 'a')
        };

        // Act
        Action act = () => new WordFinderHashSet(matrix);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void Constructor_ValidMatrix_InitializesCorrectly()
    {
        // Arrange
        var matrix = new List<string> { "word1", "word2", "word3" };

        // Act
        IWordFinder wordFinder = new WordFinderHashSet(matrix);

        // Assert
        wordFinder.Should().NotBeNull();
    }

    [Fact]
    public void Find_WordStreamIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var matrix = new List<string> { "word1", "word2", "word3" };
        IWordFinder wordFinder = new WordFinderHashSet(matrix);
        IEnumerable<string> wordstream = null;

        // Act
        Action act = () => wordFinder.Find(wordstream);

        // Assert
        act.Should().Throw<ArgumentNullException>()
            .WithMessage("Word stream cannot be null. (Parameter 'wordstream')");
    }

    [Fact]
    public void Find_EmptyWordStream_ReturnsEmpty()
    {
        // Arrange
        var matrix = new List<string> { "word1", "word2", "word3" };
        IWordFinder wordFinder = new WordFinderHashSet(matrix);
        var wordstream = Enumerable.Empty<string>();

        // Act
        var result = wordFinder.Find(wordstream);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void Find_WordsNotInMatrixWords_ReturnsEmpty()
    {
        // Arrange
        var matrix = new List<string> { "word1", "word2", "word3" };
        IWordFinder wordFinder = new WordFinderHashSet(matrix);
        var wordstream = new List<string> { "word4", "word5", "word6" };

        // Act
        var result = wordFinder.Find(wordstream);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void Find_WordsInMatrixWords_ReturnsTopWords()
    {
        // Arrange
        var matrix = new List<string> { "word1", "word2", "word3" };
        IWordFinder wordFinder = new WordFinderHashSet(matrix);
        var wordstream = new List<string> { "word1", "word2", "word3", "word1", "word2", "word1" };

        // Act
        var result = wordFinder.Find(wordstream);

        // Assert
        result.Should().ContainInOrder("word1", "word2", "word3");
    }

    [Fact]
    public void Find_MoreThanTenWordsInMatrixWords_ReturnsTopTenWords()
    {
        // Arrange
        var matrix = new List<string>
            {
                "word1", "word2", "word3", "word4", "word5", "word6", "word7", "word8", "word9", "word10", "word11"
            };
        IWordFinder wordFinder = new WordFinderHashSet(matrix);
        var wordstream = new List<string>
            {
                "word1", "word2", "word3", "word4", "word5", "word6", "word7", "word8", "word9", "word10", "word11",
                "word1", "word2", "word3", "word4", "word5", "word6", "word7", "word8", "word9", "word10"
            };

        // Act
        var result = wordFinder.Find(wordstream);

        // Assert
        result.Should().HaveCount(10);
    }
}
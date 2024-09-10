# WordFinder Class for QU Technical Evaluation

This repository contains the implementation of the `WordFinder` class, designed as part of a technical evaluation for QU. The `WordFinder` class is implemented in C# and is designed to efficiently search words in a matrix. This project includes an interface (`IWordFinder`) and two distinct implementations that demonstrate different data structure strategies: using a `HashSet<string>` and a trie structure.

## Overview

The `WordFinder` class is tasked with searching a character matrix for words provided in a stream. The class identifies words that appear horizontally (left to right) and vertically (top to bottom) within the matrix. The main objectives of this project are to assess code quality, performance efficiency, and the implementation of efficient data structures under the constraints of a 64x64 matrix size.

## Implementations

1. **WordFinderHashSet** - This implementation uses a `HashSet<string>` to store and search words within the matrix. It is designed for simplicity and quick access.
2. **WordFinderTrie** - This implementation utilizes a trie (prefix tree) to manage matrix words, optimizing memory usage and supporting efficient prefix-based searches.

## Features

- Search horizontal and vertical words within a matrix.
- Handle matrices up to 64x64 in size.
- Return the top 10 most repeated words found in the matrix from a given word stream.
- Ensure high performance for large word streams.

## Requirements

- **The matrix input**: A set of strings representing a character matrix with a size that does not exceed 64x64. All strings contain the same number of characters.
- **wordstream input**: A set of strings.
- **Constrains**:matrix dimensions (64x64).
- **Functional requirements**:
  - Words are searched horizontally (left to right) and vertically (top to bottom).
  - The method should return the top 10 most repeated words found in the matrix from the word stream.
  - Each word in the word stream found in the matrix is counted only once, regardless of its frequency in the stream.
- **Performance Requirements**:
  - Given the potentially large size of the word stream and the matrix dimensions, the solution should be implemented in a high-performance manner in terms of both algorithm efficiency and resource utilization.

## Data Characteristics

- **Matrix size**:
  - Up to 64x64 characters, leading to a maximum of 64 horizontal and 64 vertical strings to check.
- **Word Stream**:
  - Potentially large and of unknown size, requiring efficient search capabilities.

## Data Structure Considerations

In the course of researching various alternatives to optimize memory and execution performance, I found two structures, the HashSet and the Trie.

1. **HashSet**:
    Definition - an unordered collection of unique elements. Prevents duplicate elements from being placed into the collection.
   - *Pros*: Average O(1) time complexity for lookups; straightforward implementation.
   - *Cons*: Potentially high memory usage as each word is stored individually; does not take advantage of common prefixes.

2. **Trie**:
    Definition - is a tree-like data structure that is often used to store and retrieve strings quickly.
   - *Pros*: Efficient in memory usage when words share common prefixes; facilitates faster searches for datasets with many common prefixes.
   - *Cons*: Higher initial setup cost; more complex implementation; potentially slower for small datasets due to overhead.

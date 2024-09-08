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

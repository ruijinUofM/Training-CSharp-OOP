# 19. Indexers and Operator Overloading

## Feature

Indexers (`this[int row, int col]`), operator overloading (`+`, `*`, `==`, `!=`).

## Case study

A `Matrix` class backed by a 2D array. Supports element access via indexer, addition (`+`), scalar multiplication (`*`), and equality comparison (`==`, `!=`).

## Required class and behavior

- **Matrix**:
  - `Rows`, `Cols` (int) — read-only dimensions; set via constructor.
  - `Matrix(int rows, int cols)` — constructs a zero-initialized matrix.
  - Element access — supports `m[row, col]` for both reading and writing. (C# has a specific member syntax for this — it is not a normal property.)
  - Supports `+` between two matrices (element-wise sum; throw if dimensions differ).
  - Supports `*` between a matrix and a double scalar (scales all elements).
  - Supports `==` and `!=` for element-wise equality. (Defining `==` requires also defining `!=` — compiler enforces this.)
  - `Equals(object?)` and `GetHashCode()` — must be overridden to match the `==` behavior.

Note: `+`, `*`, `==`, `!=` each require a specific C# keyword to declare as a type-level operation rather than an instance method.

## Things to watch for

- Indexer syntax: `public double this[int row, int col] { get => ...; set => ...; }`.
- `operator +` must be `static` and return a new `Matrix` (don't mutate in place).
- If you define `==`, you must also define `!=` (and vice versa) — compiler error otherwise.
- Override `Equals` and `GetHashCode` when overloading `==` — otherwise `==` and `Equals` have inconsistent behavior.
- `Matrix + Matrix` requires same dimensions; throw if they don't match.
- `double[,]` is a 2D array: `new double[rows, cols]`, accessed as `_data[row, col]`.

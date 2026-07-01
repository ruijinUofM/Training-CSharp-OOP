# 19. Indexers and Operator Overloading

## Feature

Indexers and operator overloading — element access syntax and type-level arithmetic/comparison operations.

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

- C# has a specific member syntax for element access that uses `this` with index parameters — look up how to declare an indexer for a multi-dimensional grid.
- Operator methods must be declared with a specific keyword and are always static; they return a new instance (don't mutate).
- If you define `==`, you must also define `!=` (and vice versa) — compiler error otherwise.
- Override `Equals` and `GetHashCode` when overloading `==` — otherwise `==` and `Equals` have inconsistent behavior.
- `Matrix + Matrix` requires same dimensions; throw if they don't match.
- `double[,]` is a 2D array: `new double[rows, cols]`, accessed as `_data[row, col]`.

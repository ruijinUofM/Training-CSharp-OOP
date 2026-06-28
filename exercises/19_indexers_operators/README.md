# 19. Indexers and Operator Overloading

## Feature

Indexers (`this[int row, int col]`), operator overloading (`+`, `*`, `==`, `!=`).

## Case study

A `Matrix` class backed by a 2D array. Supports element access via indexer, addition (`+`), scalar multiplication (`*`), and equality comparison (`==`, `!=`).

## Required API

```csharp
class Matrix
{
    public int Rows { get; }
    public int Cols { get; }
    public Matrix(int rows, int cols)   // zero-initialized

    public double this[int row, int col] { get; set; }  // indexer

    public static Matrix operator +(Matrix a, Matrix b)   // element-wise sum
    public static Matrix operator *(Matrix m, double scalar)  // scale all elements
    public static bool operator ==(Matrix a, Matrix b)   // element-wise equality
    public static bool operator !=(Matrix a, Matrix b)
    public override bool Equals(object? obj)
    public override int GetHashCode()
}
```

## Things to watch for

- Indexer syntax: `public double this[int row, int col] { get => ...; set => ...; }`.
- `operator +` must be `static` and return a new `Matrix` (don't mutate in place).
- If you define `==`, you must also define `!=` (and vice versa) — compiler error otherwise.
- Override `Equals` and `GetHashCode` when overloading `==` — otherwise `==` and `Equals` have inconsistent behavior.
- `Matrix + Matrix` requires same dimensions; throw if they don't match.
- `double[,]` is a 2D array: `new double[rows, cols]`, accessed as `_data[row, col]`.

# 19. Indexers and Operator Overloading

## Feature

Indexers and operator overloading — element access syntax and type-level arithmetic/comparison operations.

## When to use it / When to avoid it

Indexers and operator overloading exist to let a type use the same syntax as the domain concept it models — `matrix[r, c]` for element access, `a + b` for vectors/money/matrices — so code reads like the math or the collection it represents.

- **Use it when**: the type genuinely behaves like a collection (an indexer) or has well-understood, unambiguous arithmetic/comparison semantics in its domain (vectors, complex numbers, money).
- **Avoid it when**: the operator's meaning would surprise a reader — e.g. `+` that mutates instead of returning a new value, or that doesn't correspond to real addition. If the operation isn't a natural, obvious fit for operator syntax, a clearly named method (`matrix.Add(other)`) communicates intent better than forcing it onto `+`.

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Grid
{
    private readonly double[,] _data;
    public int Rows { get; }
    public int Cols { get; }

    public Grid(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        _data = new double[rows, cols];
    }

    // indexer — "this[...]" instead of a method/property name
    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    // operator overloads — always "public static", named "operator <symbol>"
    public static Grid operator +(Grid a, Grid b)
    {
        var result = new Grid(a.Rows, a.Cols);
        for (int r = 0; r < a.Rows; r++)
            for (int c = 0; c < a.Cols; c++)
                result[r, c] = a[r, c] + b[r, c];
        return result;
    }

    public static Grid operator *(Grid g, double scalar) => g;   // scale elements...

    // "==" requires "!=" too, plus Equals/GetHashCode overrides for consistency
    public static bool operator ==(Grid a, Grid b) => true;   // compare elements...
    public static bool operator !=(Grid a, Grid b) => !(a == b);
    public override bool Equals(object? obj) => obj is Grid g && this == g;
    public override int GetHashCode() => HashCode.Combine(Rows, Cols);
}

// usage
var g = new Grid(2, 2);
g[0, 1] = 5.0;
var sum = g + g;
```

</details>

## Things to watch for

- C# has a specific member syntax for element access that uses `this` with index parameters — look up how to declare an indexer for a multi-dimensional grid.
- Operator methods must be declared with a specific keyword and are always static; they return a new instance (don't mutate).
- If you define `==`, you must also define `!=` (and vice versa) — compiler error otherwise.
- Override `Equals` and `GetHashCode` when overloading `==` — otherwise `==` and `Equals` have inconsistent behavior.
- `Matrix + Matrix` requires same dimensions; throw if they don't match.
- `double[,]` is a 2D array: `new double[rows, cols]`, accessed as `_data[row, col]`.

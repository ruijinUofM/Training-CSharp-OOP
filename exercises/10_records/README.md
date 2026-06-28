# 10. Records

## Feature

`record` (reference type with value equality), `record struct` (value type), `with` expression (non-destructive mutation), positional records, deconstruction.

## Case study

`Point(X, Y)` — a record with a `DistanceTo` method. `Color(R, G, B)` — a `record struct` with a `ToHex()` method.

## Required API

```csharp
record Point(double X, double Y)
{
    public double DistanceTo(Point other)
    // Math.Sqrt((X - other.X)^2 + (Y - other.Y)^2)
}

record struct Color(byte R, byte G, byte B)
{
    public string ToHex() => $"#{R:X2}{G:X2}{B:X2}";
}
```

## Things to watch for

- `record Point(double X, double Y)` is a positional record — the compiler auto-generates a constructor, `init` properties, `Equals`, `GetHashCode`, `ToString`, and a `Deconstruct` method.
- Value equality: `new Point(1, 2) == new Point(1, 2)` is `true` (unlike classes where `==` checks reference).
- `with` expression: `var p2 = p with { Y = 99 };` — creates a new record with Y changed; original is unchanged.
- `record struct Color` is a value type record (stack-allocated, value semantics like a struct, but with generated equality and `with`).
- `{R:X2}` formats a byte as exactly two uppercase hex digits.
- Deconstruction: `var (x, y) = new Point(3, 4);` just works.

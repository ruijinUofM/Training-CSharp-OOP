# 10. Records

## Feature

`record` (reference type with value equality), `record struct` (value type), `with` expression (non-destructive mutation), positional records, deconstruction.

## Case study

`Point(X, Y)` — a record with a `DistanceTo` method. `Color(R, G, B)` — a `record struct` with a `ToHex()` method.

## Required types and behavior

- **Point** — a REFERENCE type with two double coordinates (X, Y).
  - Uses value equality: two Points with identical coordinates are equal.
  - Supports non-destructive mutation (create a copy with one field changed).
  - Supports deconstruction: `var (x, y) = somePoint;`
  - `DistanceTo(Point other)` → double — Euclidean distance.

- **Color** — a VALUE type (not a reference type) with three byte components (R, G, B).
  - Also uses value equality and supports non-destructive mutation.
  - `ToHex()` → string — returns `"#RRGGBB"` in uppercase hex.

Note: look up the C# syntax for declaring immutable data types with auto-generated equality, `ToString`, and deconstruction — for both reference and value variants.

## Things to watch for

- `record Point(double X, double Y)` is a positional record — the compiler auto-generates a constructor, `init` properties, `Equals`, `GetHashCode`, `ToString`, and a `Deconstruct` method.
- Value equality: `new Point(1, 2) == new Point(1, 2)` is `true` (unlike classes where `==` checks reference).
- `with` expression: `var p2 = p with { Y = 99 };` — creates a new record with Y changed; original is unchanged.
- `record struct Color` is a value type record (stack-allocated, value semantics like a struct, but with generated equality and `with`).
- `{R:X2}` formats a byte as exactly two uppercase hex digits.
- Deconstruction: `var (x, y) = new Point(3, 4);` just works.

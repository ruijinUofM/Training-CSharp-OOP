# 10. Records

## Feature

Records — immutable data types with auto-generated value equality, `ToString`, and deconstruction — for both reference and value variants, plus non-destructive mutation.

## Case study

`Point(X, Y)` — a record with a `DistanceTo` method. `Color(R, G, B)` — a value-type record with a `ToHex()` method.

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

- C# has a concise positional syntax for record declarations where the compiler auto-generates a constructor, properties, `Equals`, `GetHashCode`, `ToString`, and a `Deconstruct` method.
- Value equality: `new Point(1, 2) == new Point(1, 2)` is `true` (unlike classes where `==` checks reference).
- Non-destructive mutation: C# records have a specific expression for creating a new record with one or more fields changed while leaving the original unchanged.
- The value-type variant of a record uses a specific keyword combination — look it up.
- `{R:X2}` formats a byte as exactly two uppercase hex digits.
- Deconstruction: `var (x, y) = new Point(3, 4);` just works.

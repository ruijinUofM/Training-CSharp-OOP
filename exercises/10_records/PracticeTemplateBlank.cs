// Records -- Point and Color, written from scratch.
//
// Required types and behavior:
//
//   Point — a REFERENCE type with two double coordinates (X, Y).
//       Uses value equality: two Points with identical coordinates are equal.
//       Supports non-destructive mutation (create a copy with one field changed).
//       Supports deconstruction: var (x, y) = somePoint;
//       DistanceTo(Point other) → double — Euclidean distance.
//
//   Color — a VALUE type (not a reference type) with three byte components (R, G, B).
//       Also uses value equality and supports non-destructive mutation.
//       ToHex() → string — returns "#RRGGBB" in uppercase hex.
//
// Note: C# has a concise syntax for declaring immutable data types with auto-generated
//       equality, ToString, and deconstruction — both as reference types and value types.
//       Look up what keyword(s) enable this.

namespace Kata;

// Write your implementation below.

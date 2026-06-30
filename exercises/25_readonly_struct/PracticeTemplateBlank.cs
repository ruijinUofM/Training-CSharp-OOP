using Xunit;

// readonly struct — Immutable Value Types
//
// 'readonly struct' enforces: all fields are readonly; methods return new values
// instead of mutating. This avoids the mutable-struct gotcha where modifying
// list[0].Field silently modifies a copy.
// Combined with 'in' parameters: zero-copy, zero defensive-copy.
//
// Implement Vector2 as a fully immutable value type:
//   X, Y (double) — set at construction; cannot be changed afterward.
//   Vector2(double x, double y) — constructor.
//   Length (double, computed) — Math.Sqrt(X*X + Y*Y).
//   Add(Vector2 other) → Vector2 — returns a new Vector2(X+other.X, Y+other.Y);
//       does NOT mutate this instance.
//   Scale(double factor) → Vector2 — returns a new Vector2(X*factor, Y*factor);
//       does NOT mutate this instance.
//   Equals(Vector2 other) → bool — X == other.X && Y == other.Y.
//   Zero (static) → Vector2 — returns (0, 0).
//
// Note: look up the C# keyword that enforces full immutability on a value type,
//       preventing any field mutation and triggering defensive-copy removal.

// Write your implementation below.

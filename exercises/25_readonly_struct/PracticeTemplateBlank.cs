using Xunit;

// readonly struct — Immutable Value Types
//
// 'readonly struct' enforces: all fields are readonly; methods return new values
// instead of mutating. This avoids the mutable-struct gotcha where modifying
// list[0].Field silently modifies a copy.
// Combined with 'in' parameters: zero-copy, zero defensive-copy.
//
// Implement:
//   public readonly struct Vector2 {
//       public double X { get; init; }
//       public double Y { get; init; }
//       public Vector2(double x, double y);
//       public double Length { get; }           // Math.Sqrt(X*X + Y*Y)
//       public Vector2 Add(Vector2 other);      // new Vector2(X+other.X, Y+other.Y)
//       public Vector2 Scale(double factor);    // new Vector2(X*factor, Y*factor)
//       public bool Equals(Vector2 other);      // X == other.X && Y == other.Y
//       public static Vector2 Zero => new Vector2(0, 0);
//   }

// Write your implementation below.

// Records -- Point and Color, written from scratch.
//
// Required API:
//
//   record Point(double X, double Y)   // positional record (reference type)
//   {
//       public double DistanceTo(Point other)
//           // Math.Sqrt((X-other.X)^2 + (Y-other.Y)^2)
//   }
//
//   record struct Color(byte R, byte G, byte B)  // value-type record
//   {
//       public string ToHex()   // "#RRGGBB" uppercase hex
//   }
//
// Behavior notes:
//   - new Point(1,2) == new Point(1,2) is true (value equality)
//   - p with { Y = 99 } creates a modified copy
//   - var (x, y) = new Point(3, 4); works via auto-generated Deconstruct

namespace Kata;

// Write your implementation below.

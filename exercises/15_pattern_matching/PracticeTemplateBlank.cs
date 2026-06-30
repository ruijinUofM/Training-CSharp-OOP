// Pattern Matching -- ShapeMath, written from scratch.
//
// Required types and behavior:
//
//   Shape — a base type that cannot be instantiated directly; uses value equality;
//       supports deconstruction in pattern matching.
//   Circle : Shape — has one component: Radius (double).
//   Rectangle : Shape — has two components: Width, Height (double).
//   Triangle : Shape — has three components: A, B, C (double) — side lengths.
//
//   Note: use C#'s concise immutable data type syntax. The base Shape should not
//         be directly instantiable.
//
//   ShapeMath — static class:
//       Area(Shape) → double — dispatches on shape type using a switch expression
//           with positional patterns:
//           Circle(r):      Math.PI * r * r
//           Rectangle(w,h): w * h
//           Triangle(a,b,c): Heron's formula — s=(a+b+c)/2; sqrt(s*(s-a)*(s-b)*(s-c))
//           unknown:        throw ArgumentException
//       Classify(int) → string — using relational patterns:
//           < 0  → "negative", 0 → "zero", 1–9 → "small", >= 10 → "large"
//
// Heron's formula: s = (a+b+c)/2; Math.Sqrt(s*(s-a)*(s-b)*(s-c))

namespace Kata;

// Write your implementation below.

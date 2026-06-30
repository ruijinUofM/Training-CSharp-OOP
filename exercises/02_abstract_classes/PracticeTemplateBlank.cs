// Abstract Classes -- Shape/Circle/Rectangle, written from scratch.
//
// Required classes and behavior:
//
//   Shape — base class; cannot be instantiated directly.
//       Area() → double — every concrete subclass must provide this.
//       Perimeter() → double — every concrete subclass must provide this.
//       Describe() → string — returns "I am a {TypeName} with area {Area():F2}";
//           subclasses may optionally provide their own version.
//
//   Circle : Shape — concrete; takes a radius.
//       Radius (double) — read-only; set via constructor.
//       Area() — Math.PI * Radius * Radius.
//       Perimeter() — 2 * Math.PI * Radius.
//
//   Rectangle : Shape — concrete; takes width and height.
//       Width, Height (double) — read-only; set via constructor.
//       Area() — Width * Height.
//       Perimeter() — 2 * (Width + Height).

namespace Kata;

// Write your implementation below.

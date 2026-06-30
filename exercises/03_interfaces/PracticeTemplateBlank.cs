// Interfaces -- IDrawable + IResizable, written from scratch.
//
// Required classes and behavior:
//
//   IDrawable — contract with one method: Draw().
//   IResizable — contract with one method: Resize(double factor).
//
//   Circle — fulfills both IDrawable and IResizable contracts.
//       Radius (double) — readable from outside; only changeable from within
//           the class or via Resize.
//       Circle(double radius) — constructor.
//       Draw() — prints "Drawing circle r={Radius}".
//       Resize(double factor) — multiplies Radius by factor.
//
//   Square — fulfills both IDrawable and IResizable contracts.
//       Side (double) — readable from outside; only changeable from within
//           the class or via Resize.
//       Square(double side) — constructor.
//       Draw() — prints "Drawing square s={Side}".
//       Resize(double factor) — multiplies Side by factor.

namespace Kata;

// Write your implementation below.

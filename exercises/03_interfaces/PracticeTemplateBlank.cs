// Interfaces -- IDrawable + IResizable, written from scratch.
//
// Required API:
//
//   interface IDrawable { void Draw(); }
//   interface IResizable { void Resize(double factor); }
//
//   class Circle : IDrawable, IResizable
//   {
//       public double Radius { get; private set; }
//       public Circle(double radius)
//       public void Draw()               // prints "Drawing circle r={Radius}"
//       public void Resize(double factor) // Radius *= factor
//   }
//
//   class Square : IDrawable, IResizable
//   {
//       public double Side { get; private set; }
//       public Square(double side)
//       public void Draw()               // prints "Drawing square s={Side}"
//       public void Resize(double factor) // Side *= factor
//   }

namespace Kata;

// Write your implementation below.

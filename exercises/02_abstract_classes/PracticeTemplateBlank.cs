// Abstract Classes -- Shape/Circle/Rectangle, written from scratch.
//
// Required API:
//
//   abstract class Shape
//   {
//       public abstract double Area();
//       public abstract double Perimeter();
//       public virtual string Describe()  // "I am a {TypeName} with area {Area():F2}"
//   }
//
//   class Circle : Shape
//   {
//       public double Radius { get; }
//       public Circle(double radius)
//       public override double Area()       // Math.PI * Radius^2
//       public override double Perimeter()  // 2 * Math.PI * Radius
//   }
//
//   class Rectangle : Shape
//   {
//       public double Width { get; }
//       public double Height { get; }
//       public Rectangle(double width, double height)
//       public override double Area()       // Width * Height
//       public override double Perimeter()  // 2 * (Width + Height)
//   }

namespace Kata;

// Write your implementation below.

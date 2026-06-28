// Pattern Matching -- ShapeMath, written from scratch.
//
// Required API:
//
//   abstract record Shape;
//   record Circle(double Radius) : Shape;
//   record Rectangle(double Width, double Height) : Shape;
//   record Triangle(double A, double B, double C) : Shape;
//
//   static class ShapeMath
//   {
//       public static double Area(Shape shape)   // switch expression with positional patterns
//           // Circle(r)     => Math.PI * r * r
//           // Rectangle(w,h) => w * h
//           // Triangle(a,b,c) => Heron's formula
//           // _             => throw ArgumentException
//
//       public static string Classify(int n)     // relational patterns
//           // < 0 => "negative", 0 => "zero", 1-9 => "small", >=10 => "large"
//   }
//
// Heron's formula: s = (a+b+c)/2; Math.Sqrt(s*(s-a)*(s-b)*(s-c))

namespace Kata;

// Write your implementation below.

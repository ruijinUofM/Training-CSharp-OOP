// Indexers and Operator Overloading -- Matrix, written from scratch.
//
// Required class and behavior:
//
//   Matrix:
//       Rows, Cols (int) — read-only dimensions; set via constructor.
//       Matrix(int rows, int cols) — constructs a zero-initialized matrix.
//       Element access — supports m[row, col] for both reading and writing.
//           (C# has a specific member syntax for this; it is not a normal property.)
//       Supports + between two matrices (element-wise sum; throws if dimensions differ).
//       Supports * between a matrix and a double scalar (scales all elements).
//       Supports == and != for element-wise equality comparison.
//           (Defining == requires also defining != — compiler enforces this.)
//       Equals(object?) and GetHashCode() — must be overridden for consistency
//           with the == behavior.
//
// Note: +, *, ==, != each require a specific C# keyword to declare as a type-level
//       operation rather than an instance method.

namespace Kata;

// Write your implementation below.

// Indexers and Operator Overloading -- Matrix, written from scratch.
//
// Required API:
//
//   class Matrix
//   {
//       public int Rows { get; }
//       public int Cols { get; }
//       public Matrix(int rows, int cols)   // zero-initialized double[rows, cols]
//
//       public double this[int row, int col] { get; set; }   // indexer
//
//       public static Matrix operator +(Matrix a, Matrix b)  // element-wise
//       public static Matrix operator *(Matrix m, double scalar)
//       public static bool operator ==(Matrix a, Matrix b)   // element-wise equality
//       public static bool operator !=(Matrix a, Matrix b)
//       public override bool Equals(object? obj)
//       public override int GetHashCode()
//   }
//
// Notes:
//   - double[,] 2D array: new double[rows, cols]; _data[r, c]
//   - Must define both == and != together (compiler requirement)
//   - Override Equals when overloading ==

namespace Kata;

// Write your implementation below.

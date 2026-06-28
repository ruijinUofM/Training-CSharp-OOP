namespace Kata;

class Matrix
{
    private readonly double[,] _data;
    public int Rows { get; }
    public int Cols { get; }

    public Matrix(int rows, int cols)
    { throw new NotImplementedException(); }

    public double this[int row, int col]
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }

    public static Matrix operator +(Matrix a, Matrix b) { throw new NotImplementedException(); }
    public static Matrix operator *(Matrix m, double scalar) { throw new NotImplementedException(); }
    public static bool operator ==(Matrix a, Matrix b) { throw new NotImplementedException(); }
    public static bool operator !=(Matrix a, Matrix b) { throw new NotImplementedException(); }
    public override bool Equals(object? obj) { throw new NotImplementedException(); }
    public override int GetHashCode() { throw new NotImplementedException(); }
}

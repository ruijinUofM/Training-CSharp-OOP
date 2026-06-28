namespace Kata;

class Matrix
{
    private readonly double[,] _data;
    public int Rows { get; }
    public int Cols { get; }

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        _data = new double[rows, cols];
    }

    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new ArgumentException("Matrix dimensions must match for addition");
        var result = new Matrix(a.Rows, a.Cols);
        for (int r = 0; r < a.Rows; r++)
            for (int c = 0; c < a.Cols; c++)
                result[r, c] = a[r, c] + b[r, c];
        return result;
    }

    public static Matrix operator *(Matrix m, double scalar)
    {
        var result = new Matrix(m.Rows, m.Cols);
        for (int r = 0; r < m.Rows; r++)
            for (int c = 0; c < m.Cols; c++)
                result[r, c] = m[r, c] * scalar;
        return result;
    }

    public static bool operator ==(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols) return false;
        for (int r = 0; r < a.Rows; r++)
            for (int c = 0; c < a.Cols; c++)
                if (a[r, c] != b[r, c]) return false;
        return true;
    }

    public static bool operator !=(Matrix a, Matrix b) => !(a == b);

    public override bool Equals(object? obj) => obj is Matrix m && this == m;
    public override int GetHashCode() => HashCode.Combine(Rows, Cols, _data);
}

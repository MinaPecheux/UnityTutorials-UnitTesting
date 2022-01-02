public class Matrix
{
    private float[,] _coefficients;
    private int _nRows;
    private int _nCols;

    /* CONSTRUCTORS */
    public Matrix(float[,] coefficients)
    {
        _coefficients = coefficients;
        _nRows = coefficients.GetUpperBound(0) + 1;
        _nCols = coefficients.GetUpperBound(1) + 1;
    }

    public Matrix(int m, int n)
    {
        _nRows = m;
        _nCols = n;
        _coefficients = new float[m, n];
    }

    public Matrix(Matrix a)
    {
        _nRows = a._nRows;
        _nCols = a._nCols;
        _coefficients = new float[a._nRows, a._nCols];
        for (int row = 0; row < a._nRows; row++)
            for (int col = 0; col < a._nCols; col++)
                _coefficients[row, col] = a._coefficients[row, col];
    }

    /* UTILS */
    public override string ToString() => $"<{_nRows}x{_nCols}>";

    /* GETTERS */
    public int Rows => _nRows;
    public int Cols => _nCols;
    public int NCoeffs => _nRows * _nCols;

    /* OPERATORS */
    public float this[int m, int n]
    {
        get => _coefficients[m, n];
        set => _coefficients[m, n] = value;
    }

    public static Matrix operator +(Matrix a) => new Matrix(a);
    public static Matrix operator -(Matrix a)
    {
        float[,] c = new float[a._nRows, a._nCols];
        for (int row = 0; row < a._nRows; row++)
            for (int col = 0; col < a._nCols; col++)
                c[row, col] = -a._coefficients[row, col];
        return new Matrix(c);
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a._nRows != b._nRows || a._nCols != b._nCols)
            throw new System.InvalidOperationException(
                $"Cannot add matrices with different sizes (A: {a}, B: {b})"
            );

        float[,] c = new float[a._nRows, a._nCols];
        for (int row = 0; row < a._nRows; row++)
            for (int col = 0; col < a._nCols; col++)
                c[row, col] = a._coefficients[row, col] + b._coefficients[row, col];
        return new Matrix(c);
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a._nRows != b._nRows || a._nCols != b._nCols)
            throw new System.InvalidOperationException(
                $"Cannot subtract matrices with different sizes (A: {a}, B: {b})"
            );

        float[,] c = new float[a._nRows, a._nCols];
        for (int row = 0; row < a._nRows; row++)
            for (int col = 0; col < a._nCols; col++)
                c[row, col] = a._coefficients[row, col] - b._coefficients[row, col];
        return new Matrix(c);
    }

    public static Matrix operator *(float f, Matrix a)
    {
        float[,] c = new float[a._nRows, a._nCols];
        for (int row = 0; row < a._nRows; row++)
            for (int col = 0; col < a._nCols; col++)
                c[row, col] = f * a._coefficients[row, col];
        return new Matrix(c);
    }
    public static Matrix operator *(Matrix a, float f) => f * a;

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a._nCols != b._nRows)
            throw new System.InvalidOperationException(
                $"Cannot multiply matrices with incompatible sizes (A: {a}, B: {b})"
            );

        float[,] c = new float[a._nRows, b._nCols];
        for (int row = 0; row < a._nRows; row++)
            for (int col = 0; col < b._nCols; col++)
                for (int k = 0; k < a._nCols; k++)
                    c[row, col] += a[row, k] * b[k, col];
        return new Matrix(c);
    }

}

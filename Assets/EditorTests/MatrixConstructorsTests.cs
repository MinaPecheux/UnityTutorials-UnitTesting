using NUnit.Framework;

public class MatrixConstructorsTests
{
    [Test]
    public void ShouldCreateMatrixWithCoefficients()
    {
        float[,] coeffs = new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        };
        Matrix m = new Matrix(coeffs);
        Assert.IsNotNull(m);
    }

    [Test]
    public void ShouldCreateMatrixWithZeros()
    {
        Matrix m = new Matrix(2, 2);
        Assert.IsNotNull(m);
    }

    [Test]
    public void ShouldCreateMatrixByCopy()
    {
        Matrix m = new Matrix(2, 2);
        Matrix m2 = new Matrix(m);

        // check matrices are different objects
        Assert.AreNotSame(m, m2);

        // check coefficients are the same
        Assert.AreEqual(m2[0, 0], 0);
        Assert.AreEqual(m2[0, 1], 0);
        Assert.AreEqual(m2[1, 0], 0);
        Assert.AreEqual(m2[1, 1], 0);
    }

}

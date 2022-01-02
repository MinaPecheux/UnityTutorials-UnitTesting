using NUnit.Framework;

public class MatrixGettersTests
{
    [Test]
    public void ShouldGetNumberOfRows()
    {
        Matrix m = new Matrix(3, 2);
        Assert.AreEqual(m.Rows, 3);
    }

    [Test]
    public void ShouldGetNumberOfColumns()
    {
        Matrix m = new Matrix(3, 2);
        Assert.AreEqual(m.Cols, 2);
    }

    [Test]
    public void ShouldGetNumberOfCoefficients()
    {
        Matrix m = new Matrix(3, 2);
        Assert.AreEqual(m.NCoeffs, 6);
    }

}

using NUnit.Framework;

public class MatrixOperatorsTests
{

    [Test]
    public void ShouldReturnNegativeMatrix()
    {
        Matrix m = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });

        Matrix m2 = -m;
        // check matrices are different objects
        Assert.AreNotSame(m, m2);

        // check coefficients are valid
        Assert.AreEqual(m2[0, 0], 1);
        Assert.AreEqual(m2[0, 1], 0);
        Assert.AreEqual(m2[1, 0], 0);
        Assert.AreEqual(m2[1, 1], -2);
    }










    /* Binary operations */
    [Test]
    public void ShouldRaiseErrorForAdd()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1, 2 },
            { -1, -2, 0 }
        });

        Assert.Throws<System.InvalidOperationException>(
            () => { Matrix _ = m1 + m2; },
            "Cannot add matrices with different sizes (A: <2x2>, B: <2x3>)");
    }

    [Test]
    public void ShouldAddMatrices()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1 },
            { -1, -2 }
        });

        Matrix mAdd = m1 + m2;

        Assert.AreEqual(mAdd[0, 0], 2);
        Assert.AreEqual(mAdd[0, 1], 1);
        Assert.AreEqual(mAdd[1, 0], -1);
        Assert.AreEqual(mAdd[1, 1], 0);
    }

    [Test]
    public void ShouldRaiseErrorForSub()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1, 2 },
            { -1, -2, 0 }
        });

        Assert.Throws<System.InvalidOperationException>(
            () => { Matrix _ = m1 - m2; },
            "Cannot subtract matrices with different sizes (A: <2x2>, B: <2x3>)");
    }

    [Test]
    public void ShouldSubtractMatrices()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1 },
            { -1, -2 }
        });

        Matrix mSub = m1 - m2;

        Assert.AreEqual(mSub[0, 0], -4);
        Assert.AreEqual(mSub[0, 1], -1);
        Assert.AreEqual(mSub[1, 0], 1);
        Assert.AreEqual(mSub[1, 1], 4);
    }

    [Test]
    public void ShouldMultiplyMatrixWithFloat()
    {
        Matrix m = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });

        Matrix mMult = m * 3;

        Assert.AreEqual(mMult[0, 0], -3);
        Assert.AreEqual(mMult[0, 1], 0);
        Assert.AreEqual(mMult[1, 0], 0);
        Assert.AreEqual(mMult[1, 1], 6);
    }

    [Test]
    public void ShouldRaiseErrorForMult()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1, 2 },
            { -1, -2, 0 },
            { 0, 0, 1 }
        });

        Assert.Throws<System.InvalidOperationException>(
            () => { Matrix _ = m1 * m2; },
            "Cannot multiply matrices with incompatible sizes (A: <2x2>, B: <3x3>)");
    }

    [Test]
    public void ShouldMultiplyMatricesSameSize()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0 },
            { 0, 2 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1 },
            { -1, -2 }
        });

        Matrix mMult = m1 * m2;

        // check result matrix size
        Assert.AreEqual(mMult.Rows, 2);
        Assert.AreEqual(mMult.Cols, 2);

        // check coefficients are valid
        Assert.AreEqual(mMult[0, 0], -3);
        Assert.AreEqual(mMult[0, 1], -1);
        Assert.AreEqual(mMult[1, 0], -2);
        Assert.AreEqual(mMult[1, 1], -4);
    }

    [Test]
    public void ShouldMultiplyMatricesMatchingSizes()
    {
        Matrix m1 = new Matrix(new float[,]
        {
            { -1, 0, 4 },
            { 0, 2, -3 }
        });
        Matrix m2 = new Matrix(new float[,]
        {
            { 3, 1 },
            { -1, -2 },
            { 0, 2 }
        });

        Matrix mMult = m1 * m2;

        // check result matrix size
        Assert.AreEqual(mMult.Rows, 2);
        Assert.AreEqual(mMult.Cols, 2);

        // check coefficients are valid
        Assert.AreEqual(mMult[0, 0], -3);
        Assert.AreEqual(mMult[0, 1], 7);
        Assert.AreEqual(mMult[1, 0], -2);
        Assert.AreEqual(mMult[1, 1], -10);
    }

}

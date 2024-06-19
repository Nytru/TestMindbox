using FiguresLibrary.Figures;

namespace FiguresTests;

[TestClass]
public class TriangleTest
{
    [TestMethod]
    [DataRow(3, 3, 3)]
    [DataRow(3, 4, 5)]
    [DataRow(3, 4, 6.999999)]
    public void Correct_Triangle_Create(double a, double b, double c)
    {
        _ = new Triangle(a, b, c);
    }

    [TestMethod]
    [DataRow(3, 4, 7)]
    [DataRow(3, 4, double.NaN)]
    [DataRow(3, 4, 0)]
    [DataRow(3, 4, double.PositiveInfinity)]
    [DataRow(3, 4, double.NegativeInfinity)]
    public void Failed_Triangle_Create_Sides(double a, double b, double c)
    {
        Assert.ThrowsException<ArgumentException>(() => _ = new Triangle(a, b, c));
    }

    [TestMethod]
    [DataRow(3, 4, 5)]
    [DataRow(3.0001, 4.0001, 5.00014)]
    public void Is_Triangle_Right(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.IsTrue(triangle.IsRight);
    }
}
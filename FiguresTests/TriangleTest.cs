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
    [DataRow(3, 4, 0)]
    [DataRow(3, 4, double.NaN)]
    [DataRow(3, 4, double.PositiveInfinity)]
    [DataRow(3, 4, double.NegativeInfinity)]
    public void Failed_Triangle_Create_Sides(double a, double b, double c)
    {
        Assert.ThrowsException<ArgumentException>(() => _ = new Triangle(a, b, c));
    }

    [TestMethod]
    [DataRow(3, 4, 5)]
    [DataRow(3.000000001, 4.000000001, 5.000000001)]
    [DataRow(5, 12, 13)]
    public void Triangle_Is_Right(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.IsTrue(triangle.IsRight);
    }

    [TestMethod]
    [DataRow(9, 16, 25)]
    [DataRow(3, 3, 3)]
    [DataRow(3, 4, 5.01)]
    public void Triangle_Not_Right(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.IsFalse(triangle.IsRight);
    }

    [TestMethod]
    [DataRow(3, 4, 5)]
    [DataRow(1, 1, 1)]
    [DataRow(double.Epsilon, double.Epsilon, double.Epsilon)]
    [DataRow(double.MaxValue, double.MaxValue, double.MaxValue)]
    public void Correct_Triangle_Area_Calculation(double a, double b, double c)
    {
        var p = (a + b + c) / 2;
        var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        var triangle = new Triangle(a, b, c);

        Assert.AreEqual(triangle.Area, area);
    }
}
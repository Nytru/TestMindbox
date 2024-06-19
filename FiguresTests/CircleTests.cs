using FiguresLibrary.Figures;

namespace FiguresTests;

[TestClass]
public class CircleTests
{
    [TestMethod]
    [DataRow(3)]
    [DataRow(3.0000001)]
    [DataRow(double.Epsilon)]
    public void Correct_Circle_Create(double r)
    {
        _ = new Circle(r);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-5)]
    [DataRow(double.NaN)]
    [DataRow(double.PositiveInfinity)]
    public void Failed_Circle_Create(double r)
    {
        Assert.ThrowsException<ArgumentException>(() => _ = new Circle(r));
    }

    [TestMethod]
    [DataRow(5)]
    [DataRow(double.Epsilon)]
    [DataRow(1)]
    [DataRow(double.MaxValue)]
    public void Correct_Circle_Area_Calculation(double r)
    {
        var area = Math.PI * r * r;
        var circle = new Circle(r);
        Assert.AreEqual(circle.Area, area);
    }
}

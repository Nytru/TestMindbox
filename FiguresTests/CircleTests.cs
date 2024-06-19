using FiguresLibrary.Figures;

namespace FiguresTests;

[TestClass]
public class CircleTests
{
    [TestMethod]
    [DataRow(3)]
    [DataRow(3.0000001)]
    [DataRow(0.0000001)]
    public void Correct_Triangle_Create(double r)
    {
        _ = new Circle(r);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-5)]
    [DataRow(double.NaN)]
    [DataRow(double.PositiveInfinity)]
    public void Failed_Triangle_Create(double r)
    {
        Assert.ThrowsException<ArgumentException>(() => _ = new Circle(r));
    }
}
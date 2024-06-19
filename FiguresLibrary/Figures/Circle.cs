using FiguresLibrary.Interfaces;

namespace FiguresLibrary.Figures;

public record Circle : IFigure
{
    public double Area { get; }
    public double Radius { get; }

    public Circle(double radius)
    {
        ValidateAndThrow(radius);

        Radius = radius;
        Area = Math.PI * radius * radius;
    }

    private static void ValidateAndThrow(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("radius must be grater than zero", nameof(radius));
        }

        if (double.IsInfinity(radius))
        {
            throw new ArgumentException("side of triangle must not be an infinite", nameof(radius));
        }

        if (double.IsNaN(radius))
        {
            throw new ArgumentException("side of triangle must be a number", nameof(radius));
        }
    }
}

using FiguresLibrary.Interfaces;

namespace FiguresLibrary.Figures;

public record Triangle : IFigure
{
    private const double Precision = 0.0000001;

    public double Area { get; }
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public bool IsRight =>
        Math.Abs(A * A + B * B - C * C) < Precision ||
        Math.Abs(A * A + C * C - B * B) < Precision ||
        Math.Abs(B * B + C * C - A * A) < Precision;

    public Triangle(double a, double b, double c)
    {
        ValidateAndThrow(a, b, c);

        A = a;
        B = b;
        C = c;
        var p = (A + B + C) / 2;
        Area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    private static void ValidateAndThrow(double a, double b, double c)
    {
        const string errorMessage = "Sum of two sides of a triangle must be greater than the third side";

        ValidateAndThrow(a);
        ValidateAndThrow(b);
        ValidateAndThrow(c);

        if (a + b <= c)
            throw new ArgumentException(errorMessage);

        if (a + c <= b)
            throw new ArgumentException(errorMessage);

        if (b + c <= a)
            throw new ArgumentException(errorMessage);
    }

    private static void ValidateAndThrow(double side)
    {
        if (side <= 0)
            throw new ArgumentException("side of triangle must be grater than zero", nameof(side));

        if (double.IsInfinity(side))
            throw new ArgumentException("side of triangle must not be an infinite", nameof(side));

        if (double.IsNaN(side))
            throw new ArgumentException("side of triangle must be a number", nameof(side));
    }
}

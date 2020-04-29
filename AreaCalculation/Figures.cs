using System;

namespace AreaCalculation
{
    public abstract class Figure
    {
       public abstract double CalculateSquare();
    }

    public class FigureException : Exception
    {
        public FigureException(string message)
            : base(message)
        {
        }
    }

    public class Triangle : Figure
    {
        private double _a, _b, _c;
        private double _p;

        public override double CalculateSquare()
        {
            _p = (_a + _b + _c) / 2;
            return Math.Sqrt(_p * (_p - _a) * (_p - _b) * (_p - _c));
        }

        public bool IsRectangular()
        {
            double tolerance = 0.00001;
            if (_c > _b && _c > _a)
                return Math.Abs(_c * _c - (_a * _a + _b * _b)) < tolerance;
            if (_b > _c && _b > _a)
                return Math.Abs(_b * _b - (_a * _a + _c * _c)) < tolerance;
            return Math.Abs(_a * _a - (_c * _c + _b * _b)) < tolerance;
        }

        public Triangle(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0)
            {
                _a = a;
                _b = b;
                _c = c;
            }
            else
                throw new FigureException($"There is no triangle with such sides: {a}, {b}, {c}");
        }
    }

    public class Circle : Figure
    {
        private double _radius;

        public override double CalculateSquare()
        {
            return Math.PI * _radius * _radius;
        }

        public Circle(double radius)
        {
            if (radius > 0)
                _radius = radius;
            else
                throw new FigureException($"There is no circle with this radius: {radius}");
        }
    }
}
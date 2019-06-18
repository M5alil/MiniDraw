using System;
using System.Collections.Generic;
using System.Text;

namespace Geomtry
{
    public class Circle : I2DShape, IDrawable, IEquatable<Circle>
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public List<Point> SolvingStartPoints
        {
            get => new List<Point>()
            {
            new Point(Center.X + Radius, Center.Y),
            new Point(Center.X - Radius, Center.Y),
            new Point(Center.X, Center.Y + Radius),
            new Point(Center.X, Center.Y - Radius),
            new Point(Math.Cos(45 * Math.PI/180) * Radius + Center.X, Math.Sin(45 * Math.PI/180) * Radius + Center.Y),
            new Point(-1 * Math.Cos(45 * Math.PI/180) * Radius + Center.X, Math.Sin(45 * Math.PI/180) * Radius + Center.Y),
            new Point(Math.Cos(45 * Math.PI/180) * Radius + Center.X, Math.Sin(45 * Math.PI/180) * Radius + Center.Y),
            new Point(Math.Cos(45 * Math.PI/180) * Radius + Center.X, -1 * Math.Sin(45 * Math.PI/180) * Radius + Center.Y),
            };
        }

        public Circle(Point center, double radius)
        {
            Center = center ?? throw new ArgumentNullException(nameof(center));
            Radius = radius;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public List<I2DShape> SolveForX(double y)
        {
            List<I2DShape> _return = new List<I2DShape>();

            double ShouldBePositiveValue = Math.Pow(Radius, 2) - Math.Pow((y - Center.Y), 2);
            if (ShouldBePositiveValue < 0)
                return _return;
            double x = Math.Sqrt(ShouldBePositiveValue) + Center.X;
            double _x = -1 * Math.Sqrt(ShouldBePositiveValue) + Center.X;
            _return.Add(new Point(x, y));
            if (x != _x)
                _return.Add(new Point(_x, y));
            return _return;
        }

        public List<I2DShape> SolveForY(double x)
        {
            List<I2DShape> _return = new List<I2DShape>();

            double ShouldBePositiveValue = Math.Pow(Radius, 2) - Math.Pow((x - Center.X), 2);
            if (ShouldBePositiveValue < 0)
                return _return;
            double y = Math.Sqrt(ShouldBePositiveValue) + Center.Y;
            double _y = -1 * Math.Sqrt(ShouldBePositiveValue) + Center.Y;
            _return.Add(new Point(x, y));
            if (y != _y)
                _return.Add(new Point(x, _y));
            return _return;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Circle);
        }

        public bool Equals(Circle other)
        {
            return other != null &&
                   EqualityComparer<Point>.Default.Equals(Center, other.Center) &&
                   Radius == other.Radius;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Center, Radius);
        }

        public List<Point> getIntersectionWith(I2DShape shape)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Circle circle1, Circle circle2)
        {
            return EqualityComparer<Circle>.Default.Equals(circle1, circle2);
        }

        public static bool operator !=(Circle circle1, Circle circle2)
        {
            return !(circle1 == circle2);
        }
    }
}

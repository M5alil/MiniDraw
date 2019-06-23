using System;
using System.Collections.Generic;
using System.Linq;

namespace Geomtry
{
    interface IPoint : IVertex, IDrawable, I2DShape
    {

    }
    public class Point : IPoint, IEquatable<Point>
    {
        public Point() : this(0, 0, 0) { }
        public Point(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //public List<Point> SolvingStartPoints
        //{
        //    get { return new List<Point> { this }; }
        //}

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        public bool Equals(Point other)
        {
            return other != null &&
                   Math.Abs(X - other.X) < 0.000001 &&
                   Math.Abs(Y - other.Y) < 0.000001 &&
                   Math.Abs(Z - other.Z) < 0.000001;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        //public List<Point> GetIntersectionWith(I2DShape shape)
        //{
        //    List<Point> points = shape.SolveForY(this.X).Cast<Point>().ToList();
        //    if(points.Count == 0)
        //        return new List<Point>();
        //    Point x = points[0];
        //    if (x == this)
        //        return new List<Point> { this };
        //    else
        //        return new List<Point>();
        //}

        //public List<I2DShape> SolveForX(double y)
        //{
        //    if (y == Y)
        //    {
        //        return new List<I2DShape>
        //        {
        //            this
        //        };
        //    }
        //    else
        //        return new List<I2DShape>();
        //}

        //public List<I2DShape> SolveForY(double x)
        //{
        //    if (x == X)
        //    {
        //        return new List<I2DShape>
        //        {
        //            this
        //        };
        //    }
        //    else
        //        return new List<I2DShape>();
        //}

        public override string ToString()
        {
            return "X = " + X + ", Y = " + Y + ", Z = " + Z;
        }

        //public double? GetEquationDiffAtX(Point P)
        //{
        //    return 0;
        //}

        public static bool operator ==(Point point1, Point point2) => EqualityComparer<Point>.Default.Equals(point1, point2);

        public static bool operator !=(Point point1, Point point2) => !(point1 == point2);

        public static Point operator -(Point LHS, Point RHS) => new Point(LHS.X - RHS.X, LHS.Y - RHS.Y, LHS.Z - RHS.Z);

        public static Point operator +(Point LHS, Point RHS) => new Point(LHS.X + RHS.X, LHS.Y + RHS.Y, LHS.Z + RHS.Z);

        public double LengthToOrigin =>
             Math.Sqrt(Math.Pow(this.X,2) + Math.Pow(this.Y,2) + Math.Pow(this.Z,2));
        
    }
}
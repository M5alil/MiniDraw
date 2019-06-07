using System;
using System.Collections.Generic;

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
                   X - other.X < 0.000001 &&
                   Y - other.Y < 0.000001 &&
                   Z - other.Z < 0.000001 ;
        }

        public List<I2DShape> SolveForX(double y)
        {
            if (y == Y)
            {
                List<I2DShape> _return = new List<I2DShape>();
                _return.Add(this);
                return _return;
            }
            else
                return new List<I2DShape>();
        }

        public List<I2DShape> SolveForY(double x)
        {
            if (x == X)
            {
                List<I2DShape> _return = new List<I2DShape>();
                _return.Add(this);
                return _return;
            }
            else
                return new List<I2DShape>();
        }

        public override string ToString()
        {
            return "X = " + X + ", Y = " + Y + ", Z = " + Z;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return EqualityComparer<Point>.Default.Equals(point1, point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace Geomtry
{
    public class Line : I2DShape, IDrawable, IEquatable<Line>
    {
        public enum Incline
        {
            Horizontal, Vertical, PositiveInclined, NegativeInclined
        }
        private Point _startPoint;
        private Point _endPoint;
        public Incline incline { get; private set; }
        public double? Slope { get; }
        public Point StartPoint { get => _startPoint; set => _startPoint = value; }
        public Point EndPoint { get => _endPoint; set => _endPoint = value; }

        public Line(Point point1, Point point2)
        {
            if (point1.X - point2.X == 0)
                Slope = null;
            else
                Slope = (point1.Y - point2.Y) / (point1.X - point2.X);

            if (point1.X == point2.X)
                incline = Incline.Vertical;
            else if (point1.Y == point2.Y)
                incline = Incline.Horizontal;
            else if (Slope > 0)
                incline = Incline.PositiveInclined;
            else if (Slope < 0)
                incline = Incline.NegativeInclined;

            point1 = point1 ?? new Point();
            point2 = point2 ?? new Point();
            if (point1.X <= point2.X)
            {
                StartPoint = point1;
                EndPoint = point2;
            }
            else
            {
                StartPoint = point2;
                EndPoint = point1;
            }
        }

        public void Draw()
        {
            StartPoint.Draw();
            EndPoint.Draw();
        }

        public List<I2DShape> SolveForY(double x)
        {
            if (x >= StartPoint.X && x <= EndPoint.X)
            {

                if (this.incline == Incline.Vertical && StartPoint.X == x)
                    return new List<I2DShape>() { this };
                else
                    return new List<I2DShape>()
                    {
                        new Point(x,(double)Slope*(x-StartPoint.X)+StartPoint.Y)
                    };
            }
            else return new List<I2DShape>();
        }

        public List<I2DShape> SolveForX(double y)
        {
            if (y >= StartPoint.Y && y <= EndPoint.Y)
            {
                if (this.incline == Incline.Horizontal && StartPoint.Y == y)
                    return new List<I2DShape>() { this };
                else
                    return new List<I2DShape>()
                    {
                        new Point( (y-StartPoint.Y)/(double)Slope + StartPoint.X, y )
                    };
            }
            else return new List<I2DShape>();
        }

        public override string ToString()
        {
            return "StartPoint = " + StartPoint.ToString() + ", EndPoint = " + EndPoint.ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Line);
        }

        public bool Equals(Line other)
        {
            bool _return = false;
            if (this.Slope == null && other.Slope == null)
                _return = true;
            else
                _return = Slope - other.Slope < 0.000001;
            return other != null &&
                   StartPoint.Equals(other.StartPoint) &&
                   EndPoint.Equals(other.EndPoint) &&
                   incline == other.incline &&
                   _return;
        }
    }
}

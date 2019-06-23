using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geomtry
{
    public class Circle : AbsShape, IDrawable, IEquatable<Circle>
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public override List<Point> SolvingStartPoints
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

        public override List<I2DShape> SolveForX(double y)
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

        public override List<I2DShape> SolveForY(double x)
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

        public override List<Point> GetIntersectionWith(AbsShape shape)
        {
            List<Point> _return = new List<Point>();
            for (int i = 0; i < SolvingStartPoints.Count; i++)
            {
                Point P1 = GetIntersectBetween(this, shape, SolvingStartPoints[i]);
                if (!_return.Contains(P1) && P1 != null)
                    _return.Add(P1);
                Point P2 = GetIntersectBetween(shape, this, SolvingStartPoints[i]);
                if (!_return.Contains(P2) && P2 != null)
                    _return.Add(P2);
            }
            return _return;
        }
        /*
        static Point GetIntersectBetween1(ISolvable L1, ISolvable L2, Point StartPoint)
        {
            Point _return = null;


            Point Po = StartPoint;
            //return r is null ? null : (double?)r.OrderBy((Y) => { return (Math.Abs(Y - StartPoint.Y)); }).ToList()[0];
            double GetNearestY(List<Point> Answers)
            {
                double _Y = Answers.OrderBy((Y) => { return (Math.Abs(Y.Y - StartPoint.Y)); }).FirstOrDefault().Y;
                return _Y;
            }

            double Difference = double.MaxValue;
            bool isConverging = false;
            do
            {
                double? y_1 = L1.GetEquationDiffAtX(Po);
                if (y_1 == double.PositiveInfinity || y_1 == double.NegativeInfinity)
                {
                    List<Point> l = L2.SolveForY(Po.X).OfType<Point>().ToList();
                    _return = l.FirstOrDefault();
                    break;
                }

                double? y_2 = L2.GetEquationDiffAtX(Po);
                if (y_2 == double.PositiveInfinity || y_2 == double.NegativeInfinity)
                {
                    List<Point> l = L1.SolveForY(Po.X).OfType<Point>().ToList();
                    _return = l.FirstOrDefault();
                    break;
                }

                List<Point> L1Results = L1.SolveForY(Po.X).OfType<Point>().ToList();
                List<Point> L2Results = L2.SolveForY(Po.X).OfType<Point>().ToList();
                if (L1Results.Count == 0 || L2Results.Count == 0)
                    return null;

                double TX = GetNearestY(L1Results) - GetNearestY(L2Results);
                double T_X = (double)y_1 - (double)y_2;
                double Xo = Po.X;
                double X1 = Xo - TX / T_X;
                if (X1 == double.PositiveInfinity || X1 == double.NegativeInfinity)
                    return null;
                isConverging = Math.Abs(X1 - Xo) < Difference;
                Difference = Math.Abs(X1 - Xo);
                Po = new Point(X1, GetNearestY(L1.SolveForY(X1).OfType<Point>().ToList()));
                if (Difference < 0.0000001)
                {
                    //double Y = ;
                    _return = Po;
                    break;
                }
            } while (isConverging && Difference > 0.0000001);
            return _return;
        }
        */
        public override double GetEquationDiffAtX(Point P)
        {
            //throw new NotImplementedException();
            //List<double> _return = new List<double>();
            double Y = this.SolveForY(P.X).OfType<Point>().OrderBy((Po) => Math.Abs(Po.Y - P.Y)).FirstOrDefault().Y;
            double result = -1 * (P.X - Center.X) / (Y - Center.Y);
            return result;
            //return result;
        }

        public override string ToString()
        {
            return $"center = {Center}, radius = {Radius}. ";
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

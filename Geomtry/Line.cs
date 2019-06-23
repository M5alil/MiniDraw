using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Geomtry
{
    public class Line : AbsShape, IDrawable, IEquatable<Line>
    {
        public enum Inclined
        {
            Horizontal, Vertical, PositiveInclined, NegativeInclined
        }
        private Point _startPoint;
        private Point _endPoint;
        public Inclined Incline { get; private set; }
        public double Slope { get; }
        public Point StartPoint { get => _startPoint; private set => _startPoint = value; }
        public Point EndPoint { get => _endPoint; private set => _endPoint = value; }
        public Point MidPoint => new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
        public override List<Point> SolvingStartPoints => new List<Point>() { StartPoint, EndPoint, MidPoint };
        public Line(Point point1, Point point2)
        {

            //if (point1.X - point2.X == 0)
            //    Slope = double.PositiveInfinity;
            //else
                Slope = (point1.Y - point2.Y) / (point1.X - point2.X);

            if (point1.X == point2.X)
                Incline = Inclined.Vertical;
            else if (point1.Y == point2.Y)
                Incline = Inclined.Horizontal;
            else if (Slope > 0)
                Incline = Inclined.PositiveInclined;
            else if (Slope < 0)
                Incline = Inclined.NegativeInclined;

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

        public override List<I2DShape> SolveForY(double x)
        {
            if (x >= StartPoint.X && x <= EndPoint.X)
            {

                if (this.Incline == Inclined.Vertical && StartPoint.X == x)
                    return new List<I2DShape>() { this };
                else
                    return new List<I2DShape>()
                    {
                        new Point(x,Slope*(x-StartPoint.X)+StartPoint.Y)
                    };
            }
            else return new List<I2DShape>();
        }

        public override List<I2DShape> SolveForX(double y)
        {
            if (y >= Math.Min(StartPoint.Y, EndPoint.Y) && y <= Math.Max(StartPoint.Y, EndPoint.Y))
            {
                if (this.Incline == Inclined.Horizontal && StartPoint.Y == y)
                    return new List<I2DShape>() { this };
                else
                {
                    if (Slope == double.NegativeInfinity || Slope == double.PositiveInfinity)
                        return new List<I2DShape>()
                        {
                            new Point( StartPoint.X, y )
                        };

                    else
                        return new List<I2DShape>()
                        {
                            new Point( (y-StartPoint.Y)/(double)Slope + StartPoint.X, y )
                        };
                }
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
            if ((this.Slope == double.PositiveInfinity && other.Slope == double.PositiveInfinity )|| (this.Slope == double.NegativeInfinity && other.Slope == double.NegativeInfinity))
                _return = true;
            else
                _return = Math.Abs(Slope - other.Slope) < 0.000001;
            return other != null &&
                   StartPoint.Equals(other.StartPoint) &&
                   EndPoint.Equals(other.EndPoint) &&
                   Incline == other.Incline &&
                   _return;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Incline, Slope, StartPoint, EndPoint);
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
        static Point GetIntersectBetween(ISolvable L1, ISolvable L2, Point StartPoint)
        {
            Point _return = null;

            Point P1 = StartPoint;
            bool isConverging = false;
            double Difference = double.MaxValue;
            do
            {
                List<Point> Points = L2.SolveForX(P1.Y).OfType<Point>().Cast<Point>().ToList();
                Point P2;
                if (Points.Count > 0)
                {
                    List<Point> Ps = L1.SolveForY(Points[0].X).OfType<Point>().Cast<Point>().ToList();
                    if (Ps.Count > 0) P2 = Ps[0];
                    else break;
                }
                else break;

                isConverging = (P1 - P2).LengthToOrigin < Difference;
                Difference = (P1 - P2).LengthToOrigin;
                P1 = P2;

                if (Difference < 0.0000001)
                { _return = P1; break; }
            } while (isConverging && Difference > 0.0000001);

            do
            {
                List<Point> Points = L2.SolveForY(P1.X).OfType<Point>().Cast<Point>().ToList();
                Point P2;
                if (Points.Count > 0)
                {
                    List<Point> Ps = L1.SolveForX(Points[0].Y).OfType<Point>().Cast<Point>().ToList();
                    if (Ps.Count > 0) P2 = Ps[0];
                    else break;
                }
                else break;

                isConverging = (P1 - P2).LengthToOrigin < Difference;
                Difference = (P1 - P2).LengthToOrigin;
                P1 = P2;

                if (Difference < 0.0000001)
                { _return = P1; break; }
            } while (isConverging && Difference > 0.0000001);


            return _return;
        }
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
                    List<Point> l =  L2.SolveForY(Po.X).OfType<Point>().ToList();
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
                double X1 = Xo - TX / T_X ;
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
        private double? GetEquationDiffAtX(double X)
        {
            return GetEquationDiffAtX(new Point(X, 0));
        }
        public override double GetEquationDiffAtX(Point P)
        {
            return Slope;
        }

        public static bool operator ==(Line line1, Line line2)
        {
            return EqualityComparer<Line>.Default.Equals(line1, line2);
        }

        public static bool operator !=(Line line1, Line line2)
        {
            return !(line1 == line2);
        }
    }
}

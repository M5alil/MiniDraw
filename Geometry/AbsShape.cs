using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geomtry
{
    public abstract class AbsShape : ISolvable
    {
        public abstract List<Point> SolvingStartPoints { get; }

        static protected Point GetIntersectBetween(AbsShape LHS, AbsShape RHS, Point StartPoint, double Diff = double.MaxValue)
        {
            double F_x = LHS.GetEquationDiffAtX(StartPoint);
            double G_x = RHS.GetEquationDiffAtX(StartPoint);

            double T_x = F_x - G_x;
            if (double.IsInfinity(F_x))
            {
                Point Fx = RHS?.SolveForY(StartPoint.X)?.OfType<Point>()?.OrderBy((P) => Math.Abs(P.Y - StartPoint.Y))?.FirstOrDefault();
                if ((Fx - StartPoint).LengthToOrigin < 0.00000001)
                {
                    if (LHS.isSolvedWithPoint(Fx) && RHS.isSolvedWithPoint(Fx))
                        return Fx;
                    else return null;
                }
                else if (Diff <= (Fx - StartPoint).LengthToOrigin) { return null; }
                else
                    return GetIntersectBetween(LHS, RHS, Fx, (Fx - StartPoint).LengthToOrigin);
            }
            else if (double.IsInfinity(G_x))
            {
                Point Fx = LHS?.SolveForY(StartPoint.X)?.OfType<Point>()?.OrderBy((P) => Math.Abs(P.Y - StartPoint.Y))?.FirstOrDefault();
                if ((Fx - StartPoint).LengthToOrigin < 0.00000001)
                {
                    if (LHS.isSolvedWithPoint(Fx) && RHS.isSolvedWithPoint(Fx))
                        return Fx;
                    else return null;
                }
                else if (Diff <= (Fx - StartPoint).LengthToOrigin) { return null; }
                else
                    return GetIntersectBetween(LHS, RHS, Fx, (Fx - StartPoint).LengthToOrigin);
            }
            else
            {
                Point Fx = LHS?.SolveForY(StartPoint.X)?.OfType<Point>()?.OrderBy((P) => Math.Abs(P.Y - StartPoint.Y))?.FirstOrDefault();
                if (Fx == null) return null;
                Point Gx = RHS?.SolveForY(StartPoint.X)?.OfType<Point>()?.OrderBy((P) => Math.Abs(P.Y - StartPoint.Y))?.FirstOrDefault();
                if (Gx == null) return null;

                double Tx = Fx.Y - Gx.Y;


                double Xn = StartPoint.X - Tx / T_x;
                Point P1 = LHS?.SolveForY(Xn)?.OfType<Point>()?.OrderBy((P) => Math.Abs(P.Y - StartPoint.Y))?.FirstOrDefault();
                if (P1 == null) return null;
                Point P2 = RHS?.SolveForY(Xn)?.OfType<Point>()?.OrderBy((P) => Math.Abs(P.Y - StartPoint.Y))?.FirstOrDefault();
                if (P2 == null) return null;
                Point _R = new Point(Xn, (P1.Y + P2.Y) / 2);
                if ((_R - StartPoint).LengthToOrigin < 0.00000001)
                {
                    return _R;
                }
                else
                    return GetIntersectBetween(LHS, RHS, _R);
            }
        }

        public bool isSolvedWithPoint (Point P)
        {
            bool _return = false;
            Point P1 = SolveForY(P.X).OfType<Point>().OrderBy(t => t.Y).Where(t => t.Y == P.Y).FirstOrDefault();
            Point P2 = SolveForX(P.Y).OfType<Point>().OrderBy(t => t.X).Where(t => t.X == P.X).FirstOrDefault();
            if (!(P1 is null) || !(P2 is null))
            {
                _return = true;
            }
            return _return;
        }
        public abstract double GetEquationDiffAtX(Point P);
        public abstract List<Point> GetIntersectionWith(AbsShape shape);
        public abstract List<I2DShape> SolveForX(double y);
        public abstract List<I2DShape> SolveForY(double x);
    }
}

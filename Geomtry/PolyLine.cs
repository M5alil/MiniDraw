using System;
using System.Collections.Generic;

namespace Geomtry
{
    class PolyLine : IDrawable, ISolvable
    {
        public List<Line> Lines { get; set; }

        public List<Point> SolvingStartPoints
        {
            get
            {
                List<Point> _return = new List<Point>();
                foreach (var line in Lines)
                {
                    _return.AddRange(line.SolvingStartPoints);
                }
                return _return;
            }
        }

        public void Draw()
        {
            foreach (Line line in Lines)
            {
                line.Draw();
            }
        }

        public double GetEquationDiffAtX(Point P)
        {
            throw new NotImplementedException();
        }

        public List<Point> GetIntersectionWith(ISolvable shape)
        {
            throw new NotImplementedException();
        }

        public List<I2DShape> SolveForX(double y)
        {
            List<I2DShape> _return = new List<I2DShape>();
            foreach (var Line in Lines)
            {
                _return.AddRange(Line.SolveForX(y));
            }
            return _return;
        }

        public List<I2DShape> SolveForY(double x)
        {
            List<I2DShape> _return = new List<I2DShape>();
            foreach (var Line in Lines)
            {
                _return.AddRange(Line.SolveForY(x));
            }
            return _return;
        }

    }
}

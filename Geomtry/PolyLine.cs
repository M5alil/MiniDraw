using System;
using System.Collections.Generic;

namespace Geomtry
{
    class PolyLine : IDrawable, I2DShape
    {
        public List<Line> Lines { get; set; }

        public void Draw()
        {
            foreach (Line line in Lines)
            {
                line.Draw();
            }
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

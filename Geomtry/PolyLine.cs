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
            throw new NotImplementedException();
        }

        public List<I2DShape> SolveForY(double x)
        {
            throw new NotImplementedException();
        }
    }
}

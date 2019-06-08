using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Geomtry;
namespace GeometryTest
{
    public class CanvasTest
    {
        Canvas canvas;
        public CanvasTest()
        {
            List<Line> lines = new List<Line>()
            {
                new Line(new Point(0, 0), new Point(6, 6)) ,
                new Line(new Point(0, 6), new Point(6, 0))
            };

            canvas = new Canvas();
            foreach (var line in lines)
            {
                canvas.AddShape(line);
            }

        }
    }
}

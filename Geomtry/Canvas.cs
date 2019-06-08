using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geomtry
{
    public class Canvas
    {
        List<I2DShape> Shapes { get; }
        public Canvas()
        {
            Shapes = new List<I2DShape>();
        }
        public void AddShape (I2DShape shape)
        {
            Shapes.Add(shape);
        }
        static public List<I2DShape> getIntersections(I2DShape LHS, I2DShape RHS)
        {
            List<>
            List<I2DShape> _return = new List<I2DShape>();
            List<Point> startSolvingPoints = LHS.StartSolvingPoints;
            startSolvingPoints.AddRange(RHS.StartSolvingPoints);

            
            return _return;
        }
    }
}

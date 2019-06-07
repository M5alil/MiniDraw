using System;
using System.Collections.Generic;
using System.Text;
using Geomtry;
using Xunit;
using System.Linq;
namespace GeometryTest
{
    public class CircleTest
    {
        List<Circle> circles;
        List<double> Xs;
        List<List<List<I2DShape>>> ExpectedReturns;
        public CircleTest()
        {
            this.circles = new List<Circle>()
            {
                new Circle(new Point( 0, 0),5),
                new Circle(new Point( 0, 5),5),
                new Circle(new Point( 0,-5),5),
                new Circle(new Point( 5, 0),5),
                new Circle(new Point(-5, 0),5),
                new Circle(new Point( 5, 5),5)
            };
            Xs = new List<double>()
            {
                -5,-4,-3,-2,-1,0,1,2,3,4,5
            };
            ExpectedReturns = new List<List<List<I2DShape>>>()
            {
                //Circle[0]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(){ new Point(-5, 0) },
                    new List<I2DShape>(){ new Point(-4, 3), new Point(-4,-3) },
                    new List<I2DShape>(){ new Point(-3, 4), new Point(-3,-4) },
                    new List<I2DShape>(){ new Point(-2, 4.582576), new Point(-2,-4.582576) },
                    new List<I2DShape>(){ new Point(-1, 4.898979), new Point(-1,-4.898979) },
                    new List<I2DShape>(){ new Point( 0, 5), new Point( 0,-5) },
                    new List<I2DShape>(){ new Point( 1, 4.898979), new Point( 1,-4.898979) },
                    new List<I2DShape>(){ new Point( 2, 4.582576), new Point( 2,-4.582576) },
                    new List<I2DShape>(){ new Point( 3, 4), new Point( 3,-4) },
                    new List<I2DShape>(){ new Point( 4, 3), new Point( 4,-3) },
                    new List<I2DShape>(){ new Point( 5, 0) }
                },
                //Circle[1]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(){ new Point(-5, 0+5) },
                    new List<I2DShape>(){ new Point(-4, 3+5), new Point(-4,-3+5) },
                    new List<I2DShape>(){ new Point(-3, 4+5), new Point(-3,-4+5) },
                    new List<I2DShape>(){ new Point(-2, 4.582576+5), new Point(-2,-4.582576+5) },
                    new List<I2DShape>(){ new Point(-1, 4.898979+5), new Point(-1,-4.898979+5) },
                    new List<I2DShape>(){ new Point( 0, 5+5), new Point( 0,-5+5) },
                    new List<I2DShape>(){ new Point( 1, 4.898979+5), new Point( 1,-4.898979+5) },
                    new List<I2DShape>(){ new Point( 2, 4.582576+5), new Point( 2,-4.582576+5) },
                    new List<I2DShape>(){ new Point( 3, 4+5), new Point( 3,-4+5) },
                    new List<I2DShape>(){ new Point( 4, 3+5), new Point( 4,-3+5) },
                    new List<I2DShape>(){ new Point( 5, 0+5) }
                },
                //Circle[2]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(){ new Point(-5, 0-5) },
                    new List<I2DShape>(){ new Point(-4, 3-5), new Point(-4,-3-5) },
                    new List<I2DShape>(){ new Point(-3, 4-5), new Point(-3,-4-5) },
                    new List<I2DShape>(){ new Point(-2, 4.582576-5), new Point(-2,-4.582576-5) },
                    new List<I2DShape>(){ new Point(-1, 4.898979-5), new Point(-1,-4.898979-5) },
                    new List<I2DShape>(){ new Point( 0, 5-5), new Point( 0,-5-5) },
                    new List<I2DShape>(){ new Point( 1, 4.898979-5), new Point( 1,-4.898979-5) },
                    new List<I2DShape>(){ new Point( 2, 4.582576-5), new Point( 2,-4.582576-5) },
                    new List<I2DShape>(){ new Point( 3, 4-5), new Point( 3,-4-5) },
                    new List<I2DShape>(){ new Point( 4, 3-5), new Point( 4,-3-5) },
                    new List<I2DShape>(){ new Point( 5, 0-5) }
                },
                //Circle[3]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(){ new Point( 0, 0) },
                    new List<I2DShape>(){ new Point( 1, 3), new Point(-4,-3) },
                    new List<I2DShape>(){ new Point( 2, 4), new Point(-3,-4) },
                    new List<I2DShape>(){ new Point( 3, 4.582576), new Point(-2,-4.582576) },
                    new List<I2DShape>(){ new Point( 4, 4.898979), new Point(-1,-4.898979) },
                    new List<I2DShape>(){ new Point( 5, 5), new Point( 0,-5) }
                },
                //Circle[4]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(){ new Point(-5, 5), new Point(-5,-5) },
                    new List<I2DShape>(){ new Point(-4, 4.898979), new Point(-4,-4.898979) },
                    new List<I2DShape>(){ new Point(-3, 4.582576), new Point(-3,-4.582576) },
                    new List<I2DShape>(){ new Point(-2, 4), new Point(-2,-4) },
                    new List<I2DShape>(){ new Point(-1, 3), new Point(-1,-3) },
                    new List<I2DShape>(){ new Point(0, 0) },
                    new List<I2DShape>(){},
                    new List<I2DShape>(){},
                    new List<I2DShape>(){},
                    new List<I2DShape>(){},
                    new List<I2DShape>(){}
                },
                //Circle[5]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(){ new Point( 0, 0+5) },
                    new List<I2DShape>(){ new Point( 1, 3+5), new Point(-4,-3+5) },
                    new List<I2DShape>(){ new Point( 2, 4+5), new Point(-3,-4+5) },
                    new List<I2DShape>(){ new Point( 3, 4.582576+5), new Point(-2,-4.582576+5) },
                    new List<I2DShape>(){ new Point( 4, 4.898979+5), new Point(-1,-4.898979+5) },
                    new List<I2DShape>(){ new Point( 5, 5+5), new Point( 0,-5+5) }
                }
            };
        }
        [Fact]
        public void SolveForY_Returns()
        {
            for (int i = 0; i < circles.Count; i++)
            {
                for (int j = 0; j < Xs.Count; j++)
                {
                    List<I2DShape> shapes = circles[i].SolveForY(Xs[j]);
                    List<I2DShape> ExpectedYs = ExpectedReturns[i][j];
                    List<Point> ExpectedPoints = ExpectedYs.Cast<Point>().ToList();
                    Assert.Equal(ExpectedPoints.Count, shapes.Count);
                    for (int k = 0; k < shapes.Count; k++)
                    {
                        Assert.Equal(ExpectedPoints[k], shapes[k]);
                    }
                }
            }

        }
    }
}

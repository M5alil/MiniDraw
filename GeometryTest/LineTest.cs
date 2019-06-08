using Geomtry;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometryTest
{
    public class LineTest
    {
        List<Line> lines;
        List<Line.Inclined> Expectedinclines;
        List<double?> ExpectedSlopes;
        List<double> Xs;
        List<List<List<I2DShape>>> ExpectedLinesReturnsForXs;
        public LineTest()
        {
            lines = new List<Line>() {
            new Line(
                new Point(1, 5),
                new Point(1, 9)),
            new Line(
                new Point(1, 2),
                new Point(7, 2)),
            new Line(
                new Point(1, 1),
                new Point(8, 8)),
            new Line(
                new Point(1, 8),
                new Point(8, 1)),
            new Line(
                new Point(-2, -5),
                new Point(-7, 5)),
            };
            Expectedinclines = new List<Line.Inclined>()
            {
                Line.Inclined.Vertical,
                Line.Inclined.Horizontal,
                Line.Inclined.PositiveInclined,
                Line.Inclined.NegativeInclined,
                Line.Inclined.NegativeInclined
            };
            ExpectedSlopes = new List<double?>()
            {
                null,
                0,
                1,
                -1,
                -2
            };
            Xs = new List<double>()
            {
                0,1,2,3,4,5,6
            };
            ExpectedLinesReturnsForXs = new List<List<List<I2DShape>>>()
            {
                //lines[0]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(){ new Line(
                        new Point(1, 5),
                        new Point(1, 9))},
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>()
                },
                //lines[1]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(){new Point(1,2)},
                    new List<I2DShape>(){new Point(2,2)},
                    new List<I2DShape>(){new Point(3,2)},
                    new List<I2DShape>(){new Point(4,2)},
                    new List<I2DShape>(){new Point(5,2)},
                    new List<I2DShape>(){new Point(6,2)}
                },
                //lines[2]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(){new Point(1,1)},
                    new List<I2DShape>(){new Point(2,2)},
                    new List<I2DShape>(){new Point(3,3)},
                    new List<I2DShape>(){new Point(4,4)},
                    new List<I2DShape>(){new Point(5,5)},
                    new List<I2DShape>(){new Point(6,6)}
                },
                //lines[3]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(){new Point(1,8)},
                    new List<I2DShape>(){new Point(2,7)},
                    new List<I2DShape>(){new Point(3,6)},
                    new List<I2DShape>(){new Point(4,5)},
                    new List<I2DShape>(){new Point(5,4)},
                    new List<I2DShape>(){new Point(6,3)}
                },
                //lines[4]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>()
                }
            };
        }
        [Fact]
        public void Line_Incline()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Assert.Equal(Expectedinclines[i], lines[i].Incline);
            }
        }
        [Fact]
        public void Line_Slope()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Assert.Equal(ExpectedSlopes[i], lines[i].Slope);
            }
        }
        [Fact]
        public void SolveForY_LineReturns()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < Xs.Count; j++)
                {
                    List<I2DShape> shapes = lines[i].SolveForY(Xs[j]);
                    List<I2DShape> ExpectedYs = ExpectedLinesReturnsForXs[i][j];
                    Assert.Equal(ExpectedYs.Count, shapes.Count);
                    for (int k = 0; k < shapes.Count; k++)
                    {
                        Point P = shapes[k] as Point;
                        if (P != null)
                            Assert.Equal(ExpectedYs[k], P);
                        else
                        {
                            bool TF = ExpectedYs[k].Equals(shapes[k]);
                            Assert.True(TF);
                        }
                    }
                }
            }
        }
    }
}

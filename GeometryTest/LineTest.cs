﻿using Geomtry;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeometryTest
{
    public class LineTest
    {
        List<Line> lines;
        readonly List<Line.Inclined> Expectedinclines;
        readonly List<double?> ExpectedSlopes;
        List<double> Xs;
        readonly List<List<List<I2DShape>>> ExpectedLinesReturnsForXs;
        public LineTest()
        {
            lines = new List<Line>() {
            new Line(
                new Point(1, 5),
                new Point(1, 9)),
            new Line(
                new Point(0, 2),
                new Point(7, 2)),
            new Line(
                new Point(1, 1),
                new Point(9, 9)),
            new Line(
                new Point(1, 8),
                new Point(8, 1)),
            new Line(
                new Point(-2, -5),
                new Point(-7, 5)),
            new Line(
                new Point(0,0),
                new Point(3,9)),
            new Line(
                new Point(2,9),
                new Point(6,0))
            };
            Expectedinclines = new List<Line.Inclined>()
            {
                Line.Inclined.Vertical,
                Line.Inclined.Horizontal,
                Line.Inclined.PositiveInclined,
                Line.Inclined.NegativeInclined,
                Line.Inclined.NegativeInclined,
                Line.Inclined.PositiveInclined,
                Line.Inclined.NegativeInclined


            };
            ExpectedSlopes = new List<double?>()
            {
                double.NegativeInfinity,
                0,
                1,
                -1,
                -2,
                3,
                -2.25
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
                    new List<I2DShape>(){new Point(0,2) },
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
                },
                //lines[5]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(){new Point () },
                    new List<I2DShape>(){ new Point(1,3)},
                    new List<I2DShape>(){ new Point(2,6)},
                    new List<I2DShape>(){new Point(3,9)},
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>()
                },
                //lines[6]
                new List<List<I2DShape>>()
                {
                    new List<I2DShape>(),
                    new List<I2DShape>(),
                    new List<I2DShape>(){new Point(2,9)},
                    new List<I2DShape>(){new Point(3,9-2.25)},
                    new List<I2DShape>(){new Point(4,9-2*2.25)},
                    new List<I2DShape>(){new Point(5,9-3*2.25)},
                    new List<I2DShape>(){new Point(6,0)}
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
                            Assert.Equal(ExpectedYs[k], shapes[k]);
                            //bool TF = ExpectedYs[k].Equals();
                            //Assert.True(TF);
                        }
                    }
                }
            }
        }

        [Fact]
        public void GetIntersectionWith_L1_L5()
        {
            List<Point> points = lines[1].GetIntersectionWith(lines[5]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(2 / 3f, 2), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L1_L6()
        {
            List<Point> points = lines[1].GetIntersectionWith(lines[6]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(5.1111111, 2), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L2_L6()
        {
            List<Point> points = lines[2].GetIntersectionWith(lines[6]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(4.1538459, 4.1538459), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L3_L6()
        {
            List<Point> points = lines[3].GetIntersectionWith(lines[6]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(3.6, 5.4), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L5_L6()
        {
            List<Point> points = lines[5].GetIntersectionWith(lines[6]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(2.57142855, 7.714285755), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L2_L3()
        {
            List<Point> points = lines[2].GetIntersectionWith(lines[3]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(4.5, 4.5), points[0]);
        }
        [Fact]
        public void GetIntersectionWith_L1_L3()
        {
            List<Point> points = lines[1].GetIntersectionWith(lines[3]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(7, 2), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L1_L2()
        {
            List<Point> points = lines[1].GetIntersectionWith(lines[2]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(2, 2), points[0]);
        }

        [Fact]
        public void GetIntersectionWith_L0_L3()
        {
            List<Point> points = lines[0].GetIntersectionWith(lines[3]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(1, 8), points[0]);
        }
        [Fact]
        public void GetIntersectionWith_L3_L5()
        {
            List<Point> points = lines[3].GetIntersectionWith(lines[5]);
            Assert.NotEmpty(points);
            Assert.Single(points);
            Assert.Equal(new Point(2.25, 6.75), points[0]);
        }
    }
}

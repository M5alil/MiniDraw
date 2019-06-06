using System;
using Xunit;
using Geomtry;
using System.Collections.Generic;
using System.Linq;

namespace GeometryTest
{
    public class PointTest
    {
        Point p1;
        Point p2;
        Point p3;
        public PointTest()
        {
            p1 = new Point();
            p2 = new Point(1, 2, 3);
            p3 = new Point(1, 2);
        }
        [Fact]
        public void defaultConstructorTest()
        {
            Point p = new Point();
            Assert.True(p.X == 0);
            Assert.True(p.Y == 0);
            Assert.True(p.Z == 0);
        }
        [Fact]
        public void parameterConstructorTest()
        {
            Point p = new Point(1, 2, 3);
            Point p1 = new Point(1, 2);

            Assert.True(p.X == 1);
            Assert.True(p.Y == 2);
            Assert.True(p.Z == 3);

            Assert.Equal(1, p1.X);
            Assert.Equal(2, p1.Y);
            Assert.Equal(0, p1.Z);
        }
        [Fact]
        public void SolveForY_returnsPoint()
        {
            List<I2DShape> solutions = p2.SolveForY(1);
            List<Point> solutions_as_points = solutions.Cast<Point>().ToList();
            Assert.Single(solutions_as_points);
            Point p1 = solutions_as_points[0];
            Assert.Equal(1, p1.X);
            Assert.Equal(2, p1.Y);
            Assert.Equal(3, p1.Z);
        }

        [Fact]
        public void SolveForY_returnsNull()
        {
            List<I2DShape> solutions = p2.SolveForY(5);
            List<Point> solutions_as_points = solutions.Cast<Point>().ToList();
            Assert.Empty(solutions_as_points);
        }

        [Fact]
        public void SolveForX_returnsPoint()
        {
            List<I2DShape> solutions = p2.SolveForX(2);
            List<Point> solutions_as_points = solutions.Cast<Point>().ToList();
            Assert.Single(solutions_as_points);
            Point p1 = solutions_as_points[0];
            Assert.Equal(1, p1.X);
            Assert.Equal(2, p1.Y);
            Assert.Equal(3, p1.Z);

        }
        [Fact]
        public void SolveForX_returnsNull()
        {
            List<I2DShape> solutions = p2.SolveForX(1);
            List<Point> solutions_as_points = solutions.Cast<Point>().ToList();
            Assert.Empty(solutions_as_points);
        }

    }
}

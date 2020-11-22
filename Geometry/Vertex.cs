using System;
using System.Collections.Generic;
using System.Text;

namespace Geomtry
{
    interface IVertex
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
    class Vertex : IVertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

     interface IDrawable
    {
        void Draw();
    }
}

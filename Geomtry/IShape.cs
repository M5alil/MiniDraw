using System;
using System.Collections.Generic;
using System.Text;

namespace Geomtry
{
    public interface I2DShape
    {
        List<I2DShape> SolveForY(double x);
        List<I2DShape> SolveForX(double y);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace item11
{
    public class ComputeShape
    {
        public static double ComputeArea(myEllipse e) => e.RadiusX * e.RadiusY * Math.PI;

        public static void Flatten(myEllipse e)
        {
            e.RadiusX /= 2;
            e.RadiusY *= 2;
        }
    }
}

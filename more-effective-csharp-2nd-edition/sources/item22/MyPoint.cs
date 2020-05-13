using System;
using System.Collections.Generic;
using System.Text;

namespace item22
{
    public class MyPoint
    {
        public string Scale(int xScale, int yScale)
        {
            return $"X:{xScale.GetType()},Y:{yScale.GetType()}";
        }

        public string Scale(double xScale, double yScale)
        {
            return $"X:{xScale.GetType()},Y:{yScale.GetType()}";
        }

        public string Scale(int scale)
        {
            return $"{scale.GetType()}";
        }
    }

    public class MyPoint3D : MyPoint
    {
        public string Scale(double scale)
        {
            return $"{scale.GetType()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace item11
{
    public class Circle
    {
        public Point center { get; }
        public double radius { get; }

        public Circle(Point c, double r)
        {
            center = c;
            radius = r;
        }
        public Circle(int x, int y, double r)
        {
            center = new Point(x, y);
            radius = r;
        }

        static public implicit operator myEllipse(Circle c)
        {
            return new myEllipse(c.center, c.radius, c.radius);
        }
    }

    public class myEllipse
    {
        public Point center;
        public double RadiusX, RadiusY;

        public myEllipse(myEllipse e)
        {
            center = e.center;
            RadiusX = e.RadiusX;
            RadiusY = e.RadiusY;
        }

        public myEllipse(Point c, double x, double y)
        {
            center = c;
            RadiusX = x;
            RadiusY = y;
        }
    }
}

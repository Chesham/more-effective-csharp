using System;

namespace item18
{
    public class ShapeEventArgs : EventArgs
    {
        public double newArea { get; set; }

        public ShapeEventArgs(double d)
        {
            newArea = d;
        }
    }

    // Base class event publisher
    public abstract class Shape
    {
        protected double area;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public event EventHandler<ShapeEventArgs> ShapeChanged;
        public Shape()
        {
            ShapeChanged += HandleShapeChanged;
        }
        private void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            Area=e.newArea;
        }
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            ShapeChanged?.Invoke(this, e);
        }
    }

    public class Circle : Shape
    {
        private double radius;
        public void Update(double d)
        {
            radius = d;
            area = 3.14 * radius * radius;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            e.newArea *= 2;
            base.OnShapeChanged(e);
        }
    }
    
    public class Rectangle : Shape
    {
        private double length;
        private double width;
        public void Update(double length, double width)
        {
            this.length = length;
            this.width = width;
            area = length * width;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        public void OnShapeChanged2(object sender, ShapeEventArgs e)
        {
            e.newArea *= 3;
            base.OnShapeChanged(e);
        }
    }
}


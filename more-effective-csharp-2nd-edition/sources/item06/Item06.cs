using System;

namespace item06
{
    public class MyPoint
    {
        public int X { set; get; }
        public int Y { set; get; }
        public double Distance => Math.Sqrt(X * X + Y * Y);
    }

    public class MyPointV2
    {
        private int xValue;
        public int X
        {
            set
            {
                xValue = value;
            }
            get => xValue;
        }
        private int yValue;
        public int Y
        {
            set
            {
                yValue = value;
            }
            get => yValue;
        }
        private double? distance;
        public double Distance
        {
            get
            {
                if(!distance.HasValue)
                    distance = Math.Sqrt(X * X + Y * Y);
                return distance.Value;
            }
        }
    }
}

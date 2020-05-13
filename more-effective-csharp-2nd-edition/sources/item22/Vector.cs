using System;
using System.Collections.Generic;
using System.Linq;

namespace item22
{
    public class Vector
    {
        private List<double> values = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //加一個元素到序列
        public void Add(double number) => values.Add(number);

        public int Count() => values.Count();
        //加值到序列中的每個項目
        public void Add(IEnumerable<double> sequence)
        {
            int idx = 0;
            foreach (var value in sequence)
            {
                if (idx == values.Count)
                {
                    return;
                }
                values[idx++] += value;
            }
        }

        public double this[int index]
        {
            get { return this.values[index]; }
        }


        public string Scale(short scaleFactor)
        {
            return $"{scaleFactor.GetType()}";
        }

        public string Scale(int scaleFactor)
        {
            return $"{scaleFactor.GetType()}";
        }

        public string Scale(float scaleFactor)
        {
            return $"{scaleFactor.GetType()}";
        }

        public string Scale(double scaleFactor)
        {
            return $"{scaleFactor.GetType()}";
        }

        public string ScaleV2(float scaleFactor)
        {
            return $"{scaleFactor.GetType()}";
        }

        public string ScaleV2(double scaleFactor)
        {
            return $"{scaleFactor.GetType()}";
        }
    }


}

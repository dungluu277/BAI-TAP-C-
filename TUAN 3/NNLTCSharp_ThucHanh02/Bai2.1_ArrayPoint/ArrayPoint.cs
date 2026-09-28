using System;
using System.Collections;

namespace Tuan02.TH2
{
    class ArrayPoint
    {
        private ArrayList points; 

        public ArrayPoint()
        {
            points = new ArrayList();
        }

        public int Count => points.Count;

        public Point this[int i]
        {
            get => (Point)points[i]!;
            set => points[i] = value;
        }

        public void Add(Point p) => points.Add(p);

        public void Output()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine($"  ArrayPoint[{i}] = {this[i]}");
        }
    }
}

using System;
namespace Tuan02.TH2
{
    class Point
    {
        private double x;
        private double y;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Input()
        {
            Console.WriteLine("Nhap x: ");
            x = double.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap y: ");
            y = double.Parse(Console.ReadLine()!);
        }
        public void Output()
        {
            Console.WriteLine($"({x}, {y})");
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }
        public static Point operator -(Point a)
        {
            return new Point (-a.x, -a.y);
        }

        public double KhoangCach(Point b)
        {
            return Math.Sqrt(
                Math.Pow(x-b.x, 2)+
                Math.Pow(y-b.y, 2)
            );
        }
        public static double KhoangCach(Point a, Point b)
        {
            return Math.Sqrt(
                Math.Pow(a.x - b.x, 2)+
                Math.Pow(a.y - b.y, 2)
            );
        }

        public Point TrungDiem(Point b)
        {
            return new Point(
                (x + b.x) / 2,
                (y + b.y) / 2
            );
        }
        public static Point TrungDiem(Point a, Point b)
        {
            return new Point(
                (a.x + b.x) / 2,
                (a.y + b.y) / 2
            );
        }
    }

    class Bai1
    {
        public static void Main (string[] args)
        {
            Point A = new Point();
            Point B = new Point();
            Console.WriteLine("Nhap diem A ");
            A.Input();
            Console.WriteLine("Nhap diem B ");
            B.Input();
            Console.WriteLine($"\nA = {A}");
            Console.WriteLine($"B = {B}");
            Console.WriteLine($"A + B = {A + B}");
            Console.WriteLine($"A - B = {A - B}");
            Console.WriteLine($"-A = {-A}");

            Console.WriteLine(
                $"Khoang cach A-B (thanh vien): {A.KhoangCach(B)}"
            );
            Console.WriteLine(
                $"Khoang cach A-B (tinh): {Point.KhoangCach(A,B)}"
            );
            Point I1 = A.TrungDiem(B);
            Console.WriteLine($"Trung diem (thanh vien): {I1}");
            Point I2 = Point.TrungDiem(A, B);
            Console.WriteLine($"Trung diem (tinh): {I2}");
        }
    }
}
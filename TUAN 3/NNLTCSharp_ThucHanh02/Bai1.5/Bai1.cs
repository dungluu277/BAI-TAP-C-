using System;
namespace Tuan02.TH2
{
    class DonThuc
    {
        private double a;
        private int n;
        public DonThuc()
        {
            a = 0;
            n = 0;
        }
        public DonThuc(double a, int n)
        {
            this.a = a;
            this.n = n;
        }
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        public double TinhGiaTri(double x)
        {
            return a * Math.Pow(x, n);
        }
        public DonThuc DaoHam()
        {
            if (n == 0)
                return new DonThuc(0, 0);
            return new DonThuc(a * n, n - 1);
        }
        public override string ToString()
        {
            return $"{a}x^{n}";
        }
    }
    class Bai15
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("nhap he so a: ");
            double a = double.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap so mu n: ");
            int n = int.Parse(Console.ReadLine()!);
            DonThuc P = new DonThuc(a, n);
            Console.WriteLine("Nhap x: ");
            double x = double.Parse(Console.ReadLine()!);
            Console.WriteLine($"P(x) = {P}");
            Console.WriteLine($"Gia tri tai x = {x}: {P.TinhGiaTri(x)}");
            DonThuc Q = P.DaoHam();
            Console.WriteLine($"Dao ham P'(x) = {Q}");
        }
    }
}
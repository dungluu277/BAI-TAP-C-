using System;
namespace Tuan02.TH2
{
    class PhanSo
    {
        private int tu;
        private int mau;
        public PhanSo()
        {
            tu = 0;
            mau = 1;
        }
        public PhanSo(int tu, int mau)
        {
            this.tu = tu;
            this.mau = mau;
            RutGon();
        }
        public PhanSo(PhanSo p)
        {
            tu = p.tu;
            mau = p.mau;
        }
        private void RutGon()
        {
            int a = Math.Abs(tu);
            int b = Math.Abs(mau);
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            if (a != 0)
            {
                tu /= a;
                mau /= a;
            }
            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }
        }
        public override string ToString()
        {
            return $"{tu}/{mau}";
        }
        public static PhanSo operator +(PhanSo a)
        {
            return new PhanSo(a.tu, a.mau);
        }
        public static PhanSo operator -(PhanSo a)
        {
            return new PhanSo(-a.tu, -a.mau);
        }
        
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(
                a.tu * b.mau + b.tu * a.mau,
                a.mau * b.mau
            );
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(
                a.tu * b.mau - b.tu * a.mau,
                a.mau * b.mau
            );
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(
                a.tu * b.tu,
                a.mau * b.mau
            );
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            return new PhanSo(
                a.tu * b.mau,
                a.mau * b.tu
            );
        }

        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau > b.tu * a.mau;
        }
        public static bool operator <(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau < b.tu * a.mau;
        }
        public static bool operator >=(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau >= b.tu * a.mau;
        }
        public static bool operator <=(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau <= b.tu * a.mau;
        }
        public static bool operator ==(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau == b.tu * a.mau;
        }
        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            if (obj is PhanSo p)
                return this == p;

            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(tu, mau);
        }
    }
    class Bai14
    {
        public static void Main (string[] args)
        {
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(3, 4);

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");

            Console.WriteLine($"a + b = {a + b}");
            Console.WriteLine($"a - b = {a - b}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a / b = {a / b}");
            Console.WriteLine($"-a = {-a}");
            Console.WriteLine($"a > b = {a > b}");
            Console.WriteLine($"a < b = {a < b}");
            Console.WriteLine($"a >= b = {a >= b}");
            Console.WriteLine($"a <= b = {a <= b}");
            Console.WriteLine($"a == b = {a == b}");
            Console.WriteLine($"a != b = {a != b}");
        }
    }
}
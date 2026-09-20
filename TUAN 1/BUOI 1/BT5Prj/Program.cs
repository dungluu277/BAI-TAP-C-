// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;

class DienTichTamGiac
{
    static void Main()
    {
        double a, b, c, p, S;

        Console.Write("Nhap do dai canh a: ");
        a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap do dai canh b: ");
        b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap do dai canh c: ");
        c = Convert.ToDouble(Console.ReadLine());

        p = (a + b + c) / 2;
        S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        Console.WriteLine("Dien tich tam giac S = " + Math.Round(S, 2));
    }
}


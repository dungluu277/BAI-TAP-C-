// See https://aka.ms/new-console-template for more information
using System;

class HinhTron
{
    static void Main()
    {
        double R, S, P;

        Console.Write("Nhap ban kinh R: ");
        R = Convert.ToDouble(Console.ReadLine());

        S = 3.14 * R * R;
        P = 2 * 3.14 * R;

        Console.WriteLine("Dien tich S = " + Math.Round(S, 1));
        Console.WriteLine("Chu vi P = " + Math.Round(P, 1));
    }
}

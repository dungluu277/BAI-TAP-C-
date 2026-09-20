// See https://aka.ms/new-console-template for more information
using System;

class DoiSangGiay
{
    static void Main()
    {
        int h, m, s, tong;

        Console.Write("Nhap so gio: ");
        h = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nhap so phut: ");
        m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nhap so giay: ");
        s = Convert.ToInt32(Console.ReadLine());

        tong = h * 3600 + m * 60 + s;

        Console.WriteLine("Tong so giay cua " + h + ":" + m + ":" + s + " la " + tong + " giay");
    }
}

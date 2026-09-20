// See https://aka.ms/new-console-template for more information
using System;

class DoiSangGioPhutGiay
{
    static void Main()
    {
        Console.Write("Nhap vao tong so giay: ");
        int t = int.Parse(Console.ReadLine());

        int h = t / 3600;
        int m = (t % 3600) / 60;
        int s = t % 60;

        Console.WriteLine(t + " giay co dang " + h + ":" + m + ":" + s);
    }
}

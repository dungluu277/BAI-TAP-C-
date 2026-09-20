using System;

class TinhMu
{
    static void Main()
    {
        double a, ketQua;
        int n;

        Console.Write("Nhap so thuc a: ");
        a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap so mu n: ");
        n = Convert.ToInt32(Console.ReadLine());

        ketQua = Math.Pow(a, n);

        Console.WriteLine("Ket qua " + a + "^" + n + " = " + ketQua);
    }
}
using System;

public class PTBac2Console : ConsoleMenu
{
    public PTBac2Console() : base(
        "Menu",
        "1. Chức năng 1",
        "2. Chức năng 2",
        "0. Thoát chương trình")
    {
        Choose += HandleChoice;
    }

    private void HandleChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                GiaiPhuongTrinhBac2();
                break;
            case 2:
                Console.WriteLine("Bạn đã chọn chức năng 2.");
                Console.WriteLine("Nhấn phím bất kỳ để quay lại menu.");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                Console.ReadKey();
                break;
        }
    }

    private void GiaiPhuongTrinhBac2()
    {
        Console.Clear();
        Console.WriteLine("Giải phương trình bậc 2: ax^2 + bx + c = 0");
        Console.Write("Nhập a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double delta = b * b - 4 * a * c;

        if (a == 0)
        {
            if (b == 0)
            {
                Console.WriteLine(c == 0 ? "Phương trình có vô số nghiệm." : "Phương trình vô nghiệm.");
            }
            else
            {
                Console.WriteLine($"Phương trình bậc nhất có nghiệm x = {-c / b}.");
            }
        }
        else if (delta < 0)
        {
            Console.WriteLine("Phương trình vô nghiệm trong tập số thực.");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Phương trình có nghiệm kép x = {x}.");
        }
        else
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Phương trình có hai nghiệm: x1 = {x1}, x2 = {x2}.");
        }

        Console.WriteLine("Nhấn phím bất kỳ để quay lại menu.");
        Console.ReadKey();
    }
}

using System;
class Program
{
    static void Main()
    {
        List <ThiSinh> danhsach = new List<ThiSinh>();
        Console.WriteLine("Nhap vao so luong thi sinh: ");
        int n = int.Parse(Console.ReadLine()!);
        for (int i = 0;i < n; i++)
        {
            Console.WriteLine($"Thi sinh thu {i+1}");
            Console.WriteLine("Loat 1: Chuyen; Loai 2: Sieu Cup");
            int loai = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap vao SBD cua thi sinh: ");
            int sbd = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap vao ho ten: ");
            string hoten = Console.ReadLine()!;
            Console.WriteLine("Nhap vao diem bai 1: ");
            int bai1 = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap vao diem bai 2: ");
            int bai2 = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap vao diem bai 3: ");
            int bai3 = int.Parse(Console.ReadLine()!);
            if (loai == 1)
            {
                Console.WriteLine("Diem mon anh: ");
                int anh = int.Parse(Console.ReadLine()!);
                danhsach.Add(new Chuyen(sbd, hoten, bai1, bai2, bai3, anh));
            }
            else if (loai == 2)
            {
                Console.WriteLine("Nhap vao diem CSDL");
                int csdl = int.Parse(Console.ReadLine()!);
                danhsach.Add(new SieuCup(sbd, hoten, bai1, bai2, bai3, csdl));
            }
            foreach (ThiSinh ts in danhsach)
            {
                ts.Xuat();
            }
        }
    }
}

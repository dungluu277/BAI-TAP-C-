using System;
class Program
{
    static void Main()
    {
        List<NhanVien> danhSach = new List<NhanVien>();
        Console.WriteLine("Nhap vao so luong nhan vien: ");
        int n = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhan vien thu {i+1}:");
            Console.WriteLine("Loat: 1: Kinh Doanh; 2: San Xuat");
            int loai = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap vao ma nhanh vien: ");
            string ma = Console.ReadLine()!;
            Console.WriteLine("Nhap vao ho ten: ");
            string hoten = Console.ReadLine()!;
            if (loai == 1)
            {
                Console.WriteLine("Luong co ban: ");
                decimal luongCB = decimal.Parse(Console.ReadLine()!);
                Console.WriteLine("Nhap vao so luong hop dong: ");
                int soHD = int.Parse(Console.ReadLine()!);
                danhSach.Add(new NhanVienKinhDoanh(ma,hoten,luongCB,soHD));
            }
            else
            {
                Console.WriteLine("So luong san pham: ");
                int SLsanpham = int.Parse(Console.ReadLine()!);
                danhSach.Add(new NhanVienSanXuat(ma,hoten,SLsanpham)); 
            }
            foreach (NhanVien nv in danhSach)
            {
                nv.Xuat();
            }
        }
    }
}
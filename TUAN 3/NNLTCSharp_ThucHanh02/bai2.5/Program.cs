using System;
class NhanVien
{
    public string HoTen { get; set; } = string.Empty;
    public double MucLuong { get; set; }
    public int SoNgayVang { get; set; }
    public double LuongThucNhan()
    {
        return MucLuong - SoNgayVang * 100000;
    }
    public void Input()
    {
        Console.Write("Họ tên: ");
        HoTen = Console.ReadLine()!;
        Console.Write("Mức lương: ");
        MucLuong = double.Parse(Console.ReadLine()!);
        Console.Write("Số ngày vắng: ");
        SoNgayVang = int.Parse(Console.ReadLine()!);
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Số nhân viên: ");
        int n = int.Parse(Console.ReadLine()!);
        NhanVien[] ds = new NhanVien[n];
        double tong = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhân viên {i + 1}");
            ds[i] = new NhanVien();
            ds[i].Input();
            tong += ds[i].LuongThucNhan();
        }
        Console.WriteLine($"\nTổng lương phòng ban = {tong:N0} VNĐ");
    }
}


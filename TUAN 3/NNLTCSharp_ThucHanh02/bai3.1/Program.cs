using System;
class SinhVien : IComparable<SinhVien>
{
    public string HoTen { get; set; }
    public double Diem { get; set; }
    public SinhVien(string ten, double diem)
    {
        HoTen = ten;
        Diem = diem;
    }
    public int CompareTo(SinhVien other)
    {
        return Diem.CompareTo(other.Diem);
    }
    public override string ToString()
    {
        return $"{HoTen} - {Diem}";
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Nhập số lượng sinh viên: ");
        int n = int.Parse(Console.ReadLine()!);
        SinhVien[] ds = new SinhVien[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập sinh viên thứ {i + 1}:");
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine()!;
            Console.Write("Điểm: ");
            double diem = double.Parse(Console.ReadLine()!);
            ds[i] = new SinhVien(hoTen, diem);
        }

        Console.WriteLine("\n--- DANH SACH BAN DAU ---");
        foreach (SinhVien sv in ds)
        {
            Console.WriteLine(sv);
        }

        Array.Sort(ds);
        Console.WriteLine("\n--- DANH SAU KHI SAP XEP ---");
        foreach (SinhVien sv in ds)
        {
            Console.WriteLine(sv);
        }
        Console.ReadKey();
    }
}

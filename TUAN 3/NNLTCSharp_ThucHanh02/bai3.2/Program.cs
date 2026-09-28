using System;
interface ISoSanh<T>
{
    int Compare(T a, T b);
}
class SinhVien
{
    public string HoTen { get; set; }
    public double Diem { get; set; }
    public SinhVien(string ten, double diem)
    {
        HoTen = ten; Diem = diem;
    }
    public override string ToString() => $"{HoTen} - {Diem}";
}
class SoSanhDiem : ISoSanh<SinhVien>
{
    public int Compare(SinhVien a, SinhVien b)
    {
        return a.Diem.CompareTo(b.Diem);
    }
}
class SapXep
{
    public static void Sort<T>(T[] a, ISoSanh<T> ss)
    {
        for (int i = 0; i < a.Length - 1; i++)
            for (int j = i + 1; j < a.Length; j++)
                if (ss.Compare(a[i], a[j]) > 0)
                {
                    T temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
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

        SapXep.Sort(ds, new SoSanhDiem());
        Console.WriteLine("\n--- DANH SAU KHI SAP XEP ---");
        foreach (SinhVien sv in ds)
        {
            Console.WriteLine(sv);
        }
        Console.ReadKey();
    }
}

using System;
class PhanSo
{
    public long TuSo { get; set; }
    public long MauSo { get; set; }
    public PhanSo(long tu = 0, long mau = 1)
    {
        if (mau == 0) throw new ArgumentException("Mẫu số không được bằng 0.");
        TuSo = tu;
        MauSo = mau;
        RutGon();
    }
    static long UCLN(long a, long b)
    {
        a = Math.Abs(a); b = Math.Abs(b);
        while (b != 0) { long r = a % b; a = b; b = r; }
        return a == 0 ? 1 : a;
    }
    void RutGon()
    {
        if (MauSo < 0) { TuSo = -TuSo; MauSo = -MauSo; }
        long g = UCLN(TuSo, MauSo);
        TuSo /= g; MauSo /= g;
    }
    public static PhanSo operator +(PhanSo a, PhanSo b)
        => new PhanSo(a.TuSo*b.MauSo + b.TuSo*a.MauSo, a.MauSo*b.MauSo);

    public override string ToString()
        => MauSo == 1 ? TuSo.ToString() : $"{TuSo}/{MauSo}";
}
class DayPhanSo
{
    private PhanSo[] a;
    public DayPhanSo(int n)
    {
        a = new PhanSo[n];
    }
    public PhanSo this[int i]
    {
        get => a[i];
        set => a[i] = value;
    }
    public void Input()
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"Phân số {i + 1} (tu mau): ");
            string[] s = Console.ReadLine()!.Split();
            a[i] = new PhanSo(long.Parse(s[0]), long.Parse(s[1]));
        }
    }
    public PhanSo Tong()
    {
        PhanSo sum = new PhanSo();
        foreach (PhanSo p in a)
            sum += p;
        return sum;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine()!);
        DayPhanSo ds = new DayPhanSo(n);
        ds.Input();
        Console.WriteLine("Tổng = " + ds.Tong());
    }
}

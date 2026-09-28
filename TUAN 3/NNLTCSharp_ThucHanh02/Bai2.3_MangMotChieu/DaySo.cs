namespace Bai2_3;

public class DaySo
{
    private int[] a;

    public DaySo(int n) { a = new int[n]; }

    public DaySo(int[] mang) { a = (int[])mang.Clone(); }

    public DaySo(DaySo other) { a = (int[])other.a.Clone(); } 

    public int Length => a.Length;

    public int this[int i]
    {
        get => a[i];
        set => a[i] = value;
    }

    public void Nhap()
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"  a[{i}] = ");
            a[i] = int.Parse(Console.ReadLine() ?? "0");
        }
    }

    public void Xuat()
    {
        Console.WriteLine("  [" + string.Join(", ", a) + "]");
    }

    public List<int> TimSoChan()
    {
        var result = new List<int>();
        foreach (var x in a)
            if (x % 2 == 0) result.Add(x);
        return result;
    }
}

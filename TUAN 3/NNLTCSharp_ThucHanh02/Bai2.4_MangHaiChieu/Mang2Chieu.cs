namespace Bai2_4;

public class Mang2Chieu
{
    private int[,] a;
    private int n, m;

    public Mang2Chieu(int n, int m)
    {
        this.n = n; this.m = m;
        a = new int[n, m];
    }

    public Mang2Chieu(Mang2Chieu other) 
    {
        n = other.n; m = other.m;
        a = (int[,])other.a.Clone();
    }

    public int SoDong => n;
    public int SoCot => m;

    public int this[int i, int j]
    {
        get => a[i, j];
        set => a[i, j] = value;
    }

    public void Nhap()
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                Console.Write($"  a[{i},{j}] = ");
                a[i, j] = int.Parse(Console.ReadLine() ?? "0");
            }
    }

    public void Xuat()
    {
        for (int i = 0; i < n; i++)
        {
            var hang = new List<int>();
            for (int j = 0; j < m; j++) hang.Add(a[i, j]);
            Console.WriteLine("  " + string.Join("\t", hang));
        }
    }

    private static bool LaSoNguyenTo(int x)
    {
        if (x < 2) return false;
        for (int i = 2; i * i <= x; i++)
            if (x % i == 0) return false;
        return true;
    }
    public List<(int hang, int cot, int giaTri)> TimSoNguyenTo()
    {
        var result = new List<(int, int, int)>();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (LaSoNguyenTo(a[i, j]))
                    result.Add((i, j, a[i, j]));
        return result;
    }
}

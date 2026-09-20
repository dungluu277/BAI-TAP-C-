using System.Numerics;

Console.Write("Moi ban nhap k: ");
int k = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap n: ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (k < 0 || n < 0 || k > n)
{
    Console.WriteLine("Du lieu khong hop le. Can thoa 0 <= k <= n.");
    return;
}

k = Math.Min(k, n - k);
BigInteger combination = 1;

for (int i = 1; i <= k; i++)
{
    combination = combination * (n - k + i) / i;
}

Console.WriteLine($"C({k}, {n}) = {combination}.");
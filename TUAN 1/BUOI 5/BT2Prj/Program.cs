Console.Write("Moi ban nhap so nguyen duong n: ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (n <= 0)
{
    Console.WriteLine("n phai la so nguyen duong.");
    return;
}

double sum1 = 0;
double sum2 = 0;

for (int i = 1; i <= n; i++)
{
    sum1 += 1.0 / i;
    int denominator = n - i + 1;
    sum2 += (i % 2 == 1 ? 1.0 : -1.0) / denominator;
}

Console.WriteLine($"S1({n}) = {sum1}");
Console.WriteLine($"S2({n}) = {sum2}");
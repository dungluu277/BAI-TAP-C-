Console.Write("Moi ban nhap n: ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (n <= 0)
{
    Console.WriteLine("n phai la so tu nhien duong.");
    return;
}

int divisorSum = n == 1 ? 0 : 1;
List<int> properDivisors = n == 1 ? new() : new() { 1 };

for (int divisor = 2; divisor <= n / divisor; divisor++)
{
    if (n % divisor != 0)
    {
        continue;
    }

    int pairedDivisor = n / divisor;
    divisorSum += divisor;
    properDivisors.Add(divisor);

    if (pairedDivisor != divisor && pairedDivisor != n)
    {
        divisorSum += pairedDivisor;
        properDivisors.Add(pairedDivisor);
    }
}

properDivisors.Sort();
if (divisorSum == n)
{
    Console.WriteLine($"{n} = {string.Join(" + ", properDivisors)} la so hoan hao.");
}
else
{
    Console.WriteLine($"{n} khong la so hoan hao.");
}
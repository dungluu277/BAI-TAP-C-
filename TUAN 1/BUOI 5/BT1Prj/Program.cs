Console.Write("Moi ban nhap so nguyen duong n (1 <= n <= 12): ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (n < 1 || n > 12)
{
    Console.WriteLine("n khong hop le.");
    return;
}

long factorial = 1;
for (int i = 1; i <= n; i++)
{
    factorial *= i;
}

Console.WriteLine($"{n}! = {string.Join(".", Enumerable.Range(1, n))} = {factorial}");
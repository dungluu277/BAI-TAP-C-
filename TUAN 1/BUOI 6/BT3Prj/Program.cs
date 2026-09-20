Console.Write("Moi ban nhap so nguyen n (n > 1): ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (n <= 1)
{
    Console.WriteLine("n phai lon hon 1.");
    return;
}

int remaining = n;
List<string> factors = new();

for (int divisor = 2; divisor <= remaining / divisor; divisor++)
{
    int exponent = 0;
    while (remaining % divisor == 0)
    {
        remaining /= divisor;
        exponent++;
    }

    if (exponent > 0)
    {
        factors.Add(exponent == 1 ? divisor.ToString() : $"{divisor}^{exponent}");
    }
}

if (remaining > 1)
{
    factors.Add(remaining.ToString());
}

Console.WriteLine($"{n} = {string.Join(" x ", factors)}");
Console.Write("Moi ban nhap tu so: ");
long numerator = long.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap mau so: ");
long denominator = long.Parse(Console.ReadLine() ?? "0");

if (denominator == 0)
{
    Console.WriteLine("Mau so phai khac 0.");
    return;
}

if (numerator == 0)
{
    Console.WriteLine($"Phan so {numerator}/{denominator} duoc rut gon thanh 0.");
    return;
}

long greatestCommonDivisor = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
numerator /= greatestCommonDivisor;
denominator /= greatestCommonDivisor;

if (denominator < 0)
{
    numerator = -numerator;
    denominator = -denominator;
}

Console.WriteLine($"Phan so duoc rut gon thanh {numerator}/{denominator}.");

static long GreatestCommonDivisor(long first, long second)
{
    while (second != 0)
    {
        (first, second) = (second, first % second);
    }

    return first;
}
Console.Write("Moi ban nhap so n: ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (n <= 0)
{
    Console.WriteLine("n phai la so nguyen duong.");
    return;
}

List<int> perfectNumbers = new();
for (int number = n; number >= 2; number--)
{
    if (IsPerfectNumber(number))
    {
        perfectNumbers.Add(number);
    }
}

Console.WriteLine(perfectNumbers.Count == 0
    ? $"Khong co so hoan hao trong doan [1, {n}]."
    : $"Cac so hoan hao trong doan [1, {n}] theo thu tu giam dan: {string.Join(", ", perfectNumbers)}");

static bool IsPerfectNumber(int number)
{
    int sum = 1;
    for (int divisor = 2; divisor <= number / divisor; divisor++)
    {
        if (number % divisor != 0)
        {
            continue;
        }

        sum += divisor;
        int pairedDivisor = number / divisor;
        if (pairedDivisor != divisor)
        {
            sum += pairedDivisor;
        }
    }

    return number > 1 && sum == number;
}
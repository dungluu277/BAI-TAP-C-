Console.Write("Moi ban nhap so luong phan tu: ");
int count = int.Parse(Console.ReadLine() ?? "0");

if (count <= 0 || count > 500)
{
    Console.WriteLine("So luong phan tu phai nam trong khoang 1 den 500.");
    return;
}

int negativeCount = 0;
int zeroCount = 0;
int positiveCount = 0;

for (int index = 0; index < count; index++)
{
    Console.Write($"Phan tu {index}: ");
    double value = double.Parse(Console.ReadLine() ?? "0");

    if (value > 0)
    {
        positiveCount++;
    }
    else if (value < 0)
    {
        negativeCount++;
    }
    else
    {
        zeroCount++;
    }
}

Console.WriteLine($"Day so co {negativeCount} so am, {zeroCount} so khong va {positiveCount} so duong.");
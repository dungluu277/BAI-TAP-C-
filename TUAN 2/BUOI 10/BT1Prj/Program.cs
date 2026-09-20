Console.Write("Moi ban nhap so luong phan tu: ");
int n = int.Parse(Console.ReadLine() ?? "0");
if (n < 3 || n > 500)
{
    Console.WriteLine("n phai nam trong khoang tu 3 den 500.");
    return;
}

double[] numbers = ReadArray(n);
double sum = 0;
int count = 0;
for (int i = 1; i < n - 1; i++)
{
    bool isExtremum = (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
        || (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1]);
    if (isExtremum)
    {
        sum += numbers[i];
        count++;
    }
}

Console.WriteLine(count == 0
    ? "Day khong co phan tu cuc tri."
    : $"Trung binh cong cac phan tu cuc tri la {sum / count}.");

static double[] ReadArray(int length)
{
    double[] result = new double[length];
    for (int i = 0; i < length; i++)
    {
        Console.Write($"Phan tu {i}: ");
        result[i] = double.Parse(Console.ReadLine() ?? "0");
    }
    return result;
}
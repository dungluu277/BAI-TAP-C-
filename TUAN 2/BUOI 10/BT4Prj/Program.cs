Console.Write("Moi ban nhap so luong phan tu: ");
int n = int.Parse(Console.ReadLine() ?? "0");
if (n <= 0 || n > 500)
{
    Console.WriteLine("n phai nam trong khoang tu 1 den 500.");
    return;
}

double[] numbers = new double[n];
for (int i = 0; i < n; i++)
{
    numbers[i] = double.Parse(Console.ReadLine() ?? "0");
}

Console.Write("Moi ban nhap so k: ");
double target = double.Parse(Console.ReadLine() ?? "0");
double prefixSum = 0;
int bestStart = -1;
int bestEnd = -1;
Dictionary<double, int> firstPrefixIndex = new() { [0] = -1 };

for (int i = 0; i < n; i++)
{
    prefixSum += numbers[i];
    double requiredPrefix = prefixSum - target;
    if (firstPrefixIndex.TryGetValue(requiredPrefix, out int startIndex))
    {
        if (i - startIndex > bestEnd - bestStart)
        {
            bestStart = startIndex + 1;
            bestEnd = i;
        }
    }

    if (!firstPrefixIndex.ContainsKey(prefixSum))
    {
        firstPrefixIndex[prefixSum] = i;
    }
}

Console.WriteLine(bestStart == -1
    ? "Khong tim thay doan co tong bang k."
    : $"Doan [{bestStart}, {bestEnd}] dai nhat co tong bang {target}: {string.Join(" ", numbers[bestStart..(bestEnd + 1)])}");
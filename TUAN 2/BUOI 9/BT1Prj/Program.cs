Console.Write("Moi ban nhap so luong phan tu: ");
int count = int.Parse(Console.ReadLine() ?? "0");

if (count <= 0 || count > 500)
{
    Console.WriteLine("So luong phan tu phai nam trong khoang 1 den 500.");
    return;
}

int[] numbers = new int[count];
for (int index = 0; index < count; index++)
{
    Console.Write($"Phan tu {index}: ");
    numbers[index] = int.Parse(Console.ReadLine() ?? "0");
}

List<int> evenNumbers = new();
for (int index = count - 1; index >= 0; index--)
{
    if (numbers[index] % 2 == 0)
    {
        evenNumbers.Add(numbers[index]);
    }
}

Console.WriteLine(evenNumbers.Count == 0
    ? "Mang khong co phan tu chan."
    : $"Cac phan tu chan trong mang: {string.Join(" ", evenNumbers)}");
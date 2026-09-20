Console.Write("Moi ban nhap so luong phan tu: ");
int count = int.Parse(Console.ReadLine() ?? "0");
if (count <= 0 || count > 500)
{
    Console.WriteLine("So luong phan tu phai nam trong khoang 1 den 500.");
    return;
}

int[] numbers = new int[count];
for (int i = 0; i < count; i++)
{
    Console.Write($"Phan tu {i}: ");
    numbers[i] = int.Parse(Console.ReadLine() ?? "0");
}

List<int> result = new();
for (int i = 0; i < numbers.Length; i++)
{
    result.Add(numbers[i]);
    if (i < numbers.Length - 1 && numbers[i] % 2 == 0 && numbers[i + 1] % 2 == 0)
    {
        result.Add(1);
    }
}

Console.WriteLine($"Day so sau khi them so le: {string.Join(" ", result)}");
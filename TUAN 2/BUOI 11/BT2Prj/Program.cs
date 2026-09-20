int[] numbers = ReadArray();
int[] remaining = numbers.Where(number => number % 2 != 0).ToArray();

Console.WriteLine($"Day so sau khi xoa phan tu chan: {string.Join(" ", remaining)}");

static int[] ReadArray()
{
    Console.Write("Moi ban nhap so luong phan tu: ");
    int count = int.Parse(Console.ReadLine() ?? "0");
    if (count <= 0 || count > 500)
    {
        throw new ArgumentException("So luong phan tu phai nam trong khoang 1 den 500.");
    }

    int[] result = new int[count];
    for (int i = 0; i < count; i++)
    {
        Console.Write($"Phan tu {i}: ");
        result[i] = int.Parse(Console.ReadLine() ?? "0");
    }
    return result;
}
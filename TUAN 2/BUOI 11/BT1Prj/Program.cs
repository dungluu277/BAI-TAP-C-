int[] numbers = ReadArray();
List<int> evenNumbers = numbers.Where(number => number % 2 == 0).OrderBy(number => number).ToList();
List<int> oddNumbers = numbers.Where(number => number % 2 != 0).OrderByDescending(number => number).ToList();

evenNumbers.AddRange(oddNumbers);
Console.WriteLine($"Day so sau khi sap xep: {string.Join(" ", evenNumbers)}");

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
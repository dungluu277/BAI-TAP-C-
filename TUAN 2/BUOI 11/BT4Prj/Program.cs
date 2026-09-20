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

Array.Reverse(numbers);
Console.WriteLine($"Day so sau khi dao: {string.Join(" ", numbers)}");
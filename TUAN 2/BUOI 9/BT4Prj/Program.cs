Console.Write("Moi ban nhap so luong phan tu: ");
int count = int.Parse(Console.ReadLine() ?? "0");

if (count <= 0 || count > 500)
{
    Console.WriteLine("So luong phan tu phai nam trong khoang 1 den 500.");
    return;
}

double[] numbers = new double[count];
for (int index = 0; index < count; index++)
{
    Console.Write($"Phan tu {index}: ");
    numbers[index] = double.Parse(Console.ReadLine() ?? "0");
}

Console.Write("Moi ban nhap gia tri x can tim: ");
double target = double.Parse(Console.ReadLine() ?? "0");

int firstIndex = -1;
int lastIndex = -1;
int occurrences = 0;
for (int index = 0; index < count; index++)
{
    if (numbers[index] != target)
    {
        continue;
    }

    firstIndex = firstIndex == -1 ? index : firstIndex;
    lastIndex = index;
    occurrences++;
}

if (occurrences == 0)
{
    Console.WriteLine($"Gia tri {target} khong ton tai trong day so.");
}
else
{
    Console.WriteLine($"Gia tri {target} xuat hien {occurrences} lan o vi tri dau tien {firstIndex} va cuoi cung {lastIndex}.");
}
Console.Write("Moi ban nhap so luong phan tu: ");
int count = int.Parse(Console.ReadLine() ?? "0");

if (count <= 0 || count > 500)
{
    Console.WriteLine("So luong phan tu phai nam trong khoang 1 den 500.");
    return;
}

int firstEvenIndex = -1;
int lastEvenIndex = -1;
int firstEvenValue = 0;
int lastEvenValue = 0;

for (int index = 0; index < count; index++)
{
    Console.Write($"Phan tu {index}: ");
    int value = int.Parse(Console.ReadLine() ?? "0");

    if (value % 2 != 0)
    {
        continue;
    }

    if (firstEvenIndex == -1)
    {
        firstEvenIndex = index;
        firstEvenValue = value;
    }

    lastEvenIndex = index;
    lastEvenValue = value;
}

if (firstEvenIndex == -1)
{
    Console.WriteLine("Mang khong co gia tri chan.");
}
else
{
    Console.WriteLine($"Gia tri chan dau tien o vi tri {firstEvenIndex} co gia tri {firstEvenValue}.");
    Console.WriteLine($"Gia tri chan cuoi cung o vi tri {lastEvenIndex} co gia tri {lastEvenValue}.");
}
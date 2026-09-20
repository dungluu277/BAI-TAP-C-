Console.Write("Moi ban nhap so luong phan tu: ");
int n = int.Parse(Console.ReadLine() ?? "0");
if (n <= 0 || n > 500)
{
    Console.WriteLine("n phai nam trong khoang tu 1 den 500.");
    return;
}

double previous = double.Parse(Console.ReadLine() ?? "0");
int count = 0;
for (int i = 1; i < n; i++)
{
    double current = double.Parse(Console.ReadLine() ?? "0");
    if (previous * current < 0)
    {
        count++;
    }
    previous = current;
}

Console.WriteLine($"So luong cac phan tu ke nhau ma trai dau: {count}.");
Console.Write("Moi ban nhap so luong phan tu: ");
int n = int.Parse(Console.ReadLine() ?? "0");
if (n <= 0 || n > 500)
{
    Console.WriteLine("n phai nam trong khoang tu 1 den 500.");
    return;
}

double previous = double.Parse(Console.ReadLine() ?? "0");
bool alternating = true;
for (int i = 1; i < n; i++)
{
    double current = double.Parse(Console.ReadLine() ?? "0");
    if (previous * current >= 0)
    {
        alternating = false;
    }
    previous = current;
}

Console.WriteLine(alternating ? "Day tren la day dan dau." : "Day tren khong phai la day dan dau.");
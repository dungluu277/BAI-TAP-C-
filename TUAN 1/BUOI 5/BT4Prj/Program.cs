Console.Write("Moi ban nhap so thuc a: ");
double a = double.Parse(Console.ReadLine() ?? "0");

if (a < 0)
{
    Console.WriteLine("a phai khong am.");
    return;
}

double sum = 0;
int n = 0;

do
{
    n++;
    sum += 1.0 / n;
}
while (sum <= a);

Console.WriteLine($"So nguyen duong n nho nhat la {n}.");
Console.WriteLine($"Tong 1 + 1/2 + ... + 1/{n} = {sum}");
Console.Write("Moi ban nhap chi so nuoc thang truoc (m3): ");
double oldIndex = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap chi so nuoc thang nay (m3): ");
double newIndex = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap so nguoi dang ky: ");
int people = int.Parse(Console.ReadLine() ?? "0");

if (oldIndex < 0 || newIndex < oldIndex || people <= 0)
{
    Console.WriteLine("Du lieu khong hop le.");
    return;
}

double consumed = newIndex - oldIndex;
double firstLevel = Math.Min(consumed, 4 * people);
double secondLevel = Math.Min(Math.Max(consumed - 4 * people, 0), 2 * people);
double thirdLevel = Math.Max(consumed - 6 * people, 0);

double waterCost = firstLevel * 4400 + secondLevel * 8300 + thirdLevel * 10500;
double totalCost = waterCost * 1.05 * 1.10;

Console.WriteLine($"So m3 tieu thu trong thang la {consumed:F2} m3.");
Console.WriteLine($"So tien phai tra la {totalCost:N0} dong.");
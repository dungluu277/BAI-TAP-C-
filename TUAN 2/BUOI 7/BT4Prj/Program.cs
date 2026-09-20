Console.Write("Moi ban nhap ngay: ");
int day = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap thang: ");
int month = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap nam: ");
int year = int.Parse(Console.ReadLine() ?? "0");

if (!DateTime.TryParse($"{year}-{month}-{day}", out DateTime date))
{
    Console.WriteLine("Ngay thang nam khong hop le.");
    return;
}

DateTime previousDay = date.AddDays(-1);
Console.WriteLine($"Ngay truoc ngay {day}/{month}/{year} la ngay {previousDay.Day}/{previousDay.Month}/{previousDay.Year}.");
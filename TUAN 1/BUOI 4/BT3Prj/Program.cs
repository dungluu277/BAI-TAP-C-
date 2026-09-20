Console.Write("Moi ban nhap ngay, thang, nam: ");
string[] input = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

int day = int.Parse(input[0]);
int month = int.Parse(input[1]);
int year = int.Parse(input[2]);

if (!DateTime.TryParse($"{year}-{month}-{day}", out DateTime date))
{
    Console.WriteLine("Ngay thang nam khong hop le.");
    return;
}

DateTime nextDay = date.AddDays(1);
Console.WriteLine($"Ngay sau ngay {day}/{month}/{year} la ngay {nextDay.Day}/{nextDay.Month}/{nextDay.Year}.");
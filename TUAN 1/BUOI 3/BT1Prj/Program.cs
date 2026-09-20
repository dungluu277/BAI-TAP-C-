Console.Write("Moi ban nhap 5 so a, b, c, d, e: ");
string[] input = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

double[] numbers = input.Select(double.Parse).ToArray();
double maximum = numbers[0];
double minimum = numbers[0];

foreach (double number in numbers.Skip(1))
{
    if (number > maximum)
    {
        maximum = number;
    }

    if (number < minimum)
    {
        minimum = number;
    }
}

Console.WriteLine($"Gia tri lon nhat la {maximum}.");
Console.WriteLine($"Gia tri nho nhat la {minimum}.");
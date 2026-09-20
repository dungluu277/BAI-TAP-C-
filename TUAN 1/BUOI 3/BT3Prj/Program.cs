Console.Write("Moi ban nhap 3 so thuc a, b, c: ");
string[] input = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

double a = double.Parse(input[0]);
double b = double.Parse(input[1]);
double c = double.Parse(input[2]);

if (a == 0)
{
    if (b == 0)
    {
        Console.WriteLine(c == 0
            ? "Phuong trinh co vo so nghiem."
            : "Phuong trinh vo nghiem.");
    }
    else
    {
        Console.WriteLine($"Phuong trinh co mot nghiem x = {-c / b:F2}.");
    }
}
else
{
    double delta = b * b - 4 * a * c;

    if (delta < 0)
    {
        Console.WriteLine("Phuong trinh vo nghiem.");
    }
    else if (delta == 0)
    {
        double root = -b / (2 * a);
        Console.WriteLine($"Phuong trinh co nghiem kep x = {root:F2}.");
    }
    else
    {
        double squareRoot = Math.Sqrt(delta);
        double firstRoot = (-b + squareRoot) / (2 * a);
        double secondRoot = (-b - squareRoot) / (2 * a);

        Console.WriteLine("Phuong trinh co 2 nghiem:");
        Console.WriteLine($"x1 = {firstRoot:F2}");
        Console.WriteLine($"x2 = {secondRoot:F2}");
    }
}
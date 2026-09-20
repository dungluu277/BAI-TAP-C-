Console.Write("Moi ban nhap so thuc x: ");
double x = double.Parse(Console.ReadLine() ?? "0");

double f1 = x <= 0
    ? 0
    : x <= 1
        ? x
        : Math.Pow(x, 4);

double denominator = x * x + 4 * x + 5;
double f2 = x <= 2 ? denominator : 1 / denominator;

Console.WriteLine($"f1({x}) = {f1}");
Console.WriteLine($"f2({x}) = {f2}");
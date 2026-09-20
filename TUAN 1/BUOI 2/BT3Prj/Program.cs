Console.Write("Moi ban nhap so thuc x: ");
double x = double.Parse(Console.ReadLine() ?? "0");

double result = ((-4 * x + 3) * x + 2) * x + 1;

Console.WriteLine($"f({x}) = {result}");

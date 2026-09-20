Console.Write("Moi ban nhap so thuc a: ");
double a = double.Parse(Console.ReadLine() ?? "0");

double a2 = a * a;
double a4 = a2 * a2;
double a5 = a4 * a;
double a8 = a4 * a4;
double a16 = a8 * a8;
double a17 = a16 * a;

Console.WriteLine($"Ket qua: {a}^2 = {a2}, {a}^5 = {a5}, {a}^17 = {a17}");

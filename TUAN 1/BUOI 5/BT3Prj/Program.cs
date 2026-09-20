Console.Write("Moi ban nhap so a: ");
double a = double.Parse(Console.ReadLine() ?? "0");

Console.Write("Moi ban nhap sai so epsilon (0 < epsilon <= 0.1): ");
double epsilon = double.Parse(Console.ReadLine() ?? "0");

if (a <= 0 || epsilon <= 0 || epsilon > 0.1)
{
    Console.WriteLine("Du lieu khong hop le.");
    return;
}

double sum = 0;
int n = 0;
double term;

do
{
    term = 1 / (a + n);
    sum += term;
    n++;
}
while (term >= epsilon);

Console.WriteLine($"Gia tri cua S(a = {a}, epsilon = {epsilon}) = {sum}");
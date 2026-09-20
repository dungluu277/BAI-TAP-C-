Console.Write("Moi ban nhap do sai so epsilon: ");
double epsilon = double.Parse(Console.ReadLine() ?? "0");

if (epsilon <= 0)
{
    Console.WriteLine("epsilon phai lon hon 0.");
    return;
}

double pi = 0;
int termIndex = 0;
double term;

do
{
    term = 4.0 / (2 * termIndex + 1);
    pi += termIndex % 2 == 0 ? term : -term;
    termIndex++;
}
while (4.0 / (2 * termIndex + 1) >= epsilon);

double actualError = Math.Abs(Math.PI - pi);
Console.WriteLine($"So pi tinh duoc chinh xac {epsilon} la {pi}.");
Console.WriteLine($"Do sai so thuc te la {actualError}.");
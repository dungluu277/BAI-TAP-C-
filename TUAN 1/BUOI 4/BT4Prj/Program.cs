Console.Write("Moi ban nhap ba so thuc a, b, c: ");
string[] input = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

double a = double.Parse(input[0]);
double b = double.Parse(input[1]);
double c = double.Parse(input[2]);

const double epsilon = 1e-9;
bool isTriangle = a > 0 && b > 0 && c > 0
    && a + b > c
    && a + c > b
    && b + c > a;

if (!isTriangle)
{
    Console.WriteLine("Ba so khong tao thanh tam giac.");
    return;
}

double[] sides = { a, b, c };
Array.Sort(sides);
bool isRight = Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < epsilon;
bool isEquilateral = Math.Abs(a - b) < epsilon && Math.Abs(b - c) < epsilon;
bool isIsosceles = Math.Abs(a - b) < epsilon
    || Math.Abs(a - c) < epsilon
    || Math.Abs(b - c) < epsilon;

string type = isEquilateral
    ? "tam giac deu"
    : isRight && isIsosceles
        ? "tam giac vuong can"
        : isRight
            ? "tam giac vuong"
            : isIsosceles
                ? "tam giac can"
                : "tam giac thuong";

Console.WriteLine($"Ba so ({a}, {b}, {c}) tao thanh {type}.");
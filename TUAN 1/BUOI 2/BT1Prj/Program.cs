Console.Write("Moi ban nhap so a, b: ");
string[] input = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

int a = int.Parse(input[0]);
int b = int.Parse(input[1]);

long count = b - a + 1L;
long sum = count * (a + (long)b) / 2;

Console.WriteLine($"Tong cua cac so trong doan [{a}, {b}] la {sum}.");

Console.Write("Moi ban nhap chieu cao h: ");
int height = int.Parse(Console.ReadLine() ?? "0");

if (height < 2)
{
    Console.WriteLine("Chieu cao phai lon hon hoac bang 2.");
    return;
}

Console.WriteLine($"Chu I va U ung voi h = {height} la:");
string fullLine = string.Join(' ', Enumerable.Repeat("*", height));
string middleLine = "*" + new string(' ', 2 * height - 3) + "*";

Console.WriteLine($"{fullLine}   {fullLine}");
for (int row = 2; row < height; row++)
{
    Console.WriteLine($"{middleLine}   {middleLine}");
}

Console.WriteLine($"{fullLine}   {fullLine}");
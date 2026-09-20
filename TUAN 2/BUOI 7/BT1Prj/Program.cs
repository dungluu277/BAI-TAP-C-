Console.Write("Moi ban nhap chieu cao h: ");
int height = int.Parse(Console.ReadLine() ?? "0");

if (height < 1)
{
    Console.WriteLine("Chieu cao phai la so nguyen duong.");
    return;
}

Console.WriteLine($"Hinh tam giac voi h = {height}:");
for (int row = 1; row <= height; row++)
{
    int spaces = height - row;
    int width = 2 * row - 1;
    string line = new string(' ', spaces);

    for (int column = 1; column <= width; column++)
    {
        bool isBorder = row == height || column == 1 || column == width;
        line += isBorder ? "*" : " ";
    }

    Console.WriteLine(line);
}

Console.WriteLine($"Hinh vuong voi h = {height}:");
string fullRow = new string('*', height);
string emptyRow = height == 1 ? "*" : $"*{new string(' ', height - 2)}*";

for (int row = 1; row <= height; row++)
{
    Console.WriteLine(row == 1 || row == height ? fullRow : emptyRow);
}
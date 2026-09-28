using Tuan02.TH2;

var ap = new ArrayPoint();

Console.Write("Nhap so luong Point: ");
int n = int.Parse(Console.ReadLine() ?? "0");

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"-- Point thu {i + 1} --");

    var p = new Point();
    p.Input();

    ap.Add(p);
}

Console.WriteLine();
Console.WriteLine("Danh sach Point trong ArrayPoint:");
ap.Output();

Console.WriteLine();
Console.Write($"Nhap chi so i can xem (0..{ap.Count - 1}): ");
int idx = int.Parse(Console.ReadLine() ?? "0");
if (idx >= 0 && idx < ap.Count)
    Console.WriteLine($"=> Truy cap qua Indexer: ArrayPoint[{idx}] = {ap[idx]}");
else
    Console.WriteLine("Chi so khong hop le.");

using Bai2_3;

Console.Write("Nhap so phan tu n: ");
int n = int.Parse(Console.ReadLine() ?? "0");

DaySo ds = new DaySo(n);

Console.WriteLine("Nhap day so:");
ds.Nhap();
Console.WriteLine();
Console.WriteLine("Day so (Xuat()):");
ds.Xuat();

Console.WriteLine();
Console.Write($"Nhap chi so i can xem (0..{ds.Length - 1}): ");
int idx = int.Parse(Console.ReadLine() ?? "0");
if (idx >= 0 && idx < ds.Length)
    Console.WriteLine($"=> Truy cap qua Indexer: ds[{idx}] = {ds[idx]}");

Console.WriteLine();
Console.WriteLine("Cac so chan trong day (TimSoChan()):");
Console.WriteLine("  " + string.Join(", ", ds.TimSoChan()));

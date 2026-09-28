using Bai2_4;

Console.Write("So dong n: ");
int n = int.Parse(Console.ReadLine() ?? "0");

Console.Write("So cot m: ");
int m = int.Parse(Console.ReadLine() ?? "0");

Mang2Chieu m2 = new Mang2Chieu(n, m);

Console.WriteLine("Nhap tung phan tu:");
m2.Nhap();

Console.WriteLine();
Console.WriteLine("Mang (Xuat()):");
m2.Xuat();

Console.WriteLine();
Console.Write($"Nhap toa do (i,j) can xem, cach nhau dau cach (0..{m2.SoDong - 1} 0..{m2.SoCot - 1}): ");
var parts = (Console.ReadLine() ?? "0 0").Split(' ', StringSplitOptions.RemoveEmptyEntries);
int ii = int.Parse(parts[0]), jj = int.Parse(parts[1]);
Console.WriteLine($"=> Truy cap qua Indexer: m2[{ii},{jj}] = {m2[ii, jj]}");

Console.WriteLine();
Console.WriteLine("Cac so nguyen to trong mang (TimSoNguyenTo()):");
foreach (var (hang, cot, giaTri) in m2.TimSoNguyenTo())
    Console.WriteLine($"  a[{hang},{cot}] = {giaTri}");

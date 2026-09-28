using Tuan02.TH2;

Console.Write("Nhap bac cua da thuc (n): ");
int bac = int.Parse(Console.ReadLine() ?? "0");

DaThuc dt = new DaThuc(bac);

Console.WriteLine("Nhap cac he so:");
dt.Nhap();

Console.WriteLine();
Console.WriteLine("Da thuc (Xuat()):");
dt.Xuat();

Console.WriteLine();
Console.Write($"Nhap chi so i can xem don thuc thanh phan (0..{dt.Bac}): ");
int idx = int.Parse(Console.ReadLine() ?? "0");
if (idx >= 0 && idx <= dt.Bac)
    Console.WriteLine($"=> Truy cap qua Indexer: don thuc thu {idx} la {dt[idx]} (he so A={dt[idx].A}, so mu N={dt[idx].N})");

Console.WriteLine();
Console.Write("Nhap gia tri x can tinh P(x) (tu ban phim): ");
double x = double.Parse(Console.ReadLine() ?? "0");
Console.WriteLine($"=> P({x}) = {dt.TinhGiaTri(x)}   (tinh bang cach cong tung DonThuc.TinhGiaTri)");

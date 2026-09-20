Console.Write("Moi ban nhap thang: ");
int month = int.Parse(Console.ReadLine() ?? "0");

if (month is >= 1 and <= 12)
{
	int quarter = (month - 1) / 3 + 1;
	Console.WriteLine($"Thang {month} thuoc qui {quarter}.");
}
else
{
	Console.WriteLine("Thang khong hop le.");
}

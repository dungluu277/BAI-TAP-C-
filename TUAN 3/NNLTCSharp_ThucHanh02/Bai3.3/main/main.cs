using XuLy = chucnang.chucnang;

int[] soNguyen = { 5, 1, 4, 2, 3 };
XuLy xuLy = new XuLy();

xuLy.SapXep(soNguyen, (a, b) => a.CompareTo(b));

Console.WriteLine(string.Join(" ", soNguyen));

<Query Kind="Program" />


// ---------- Bài 4.1 & 6.1: các lớp dữ liệu ----------
class MonHoc
{
	public string MaMon { get; set; } = "";
	public string TenMon { get; set; } = "";
	public string He { get; set; } = "";
	public byte SoTiet { get; set; }
}

class He
{
	public string MaHe { get; set; } = "";
	public string TenHe { get; set; } = "";
}

List<MonHoc> DS_Mon() => new List<MonHoc>
{
		new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#",                              He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET",                        He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms",                  He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms",          He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript",He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET",        He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản",        He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao",       He = "KTV", SoTiet = 64 },
		new MonHoc { MaMon = "JLCB",  TenMon = "Joomla cơ bản",                            He = "CD",  SoTiet = 72 },
		new MonHoc { MaMon = "LINQ",  TenMon = "Language-Integrated Query",                He = "CD",  SoTiet = 64 },
		new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET",            He = "CD",  SoTiet = 40 },
		new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms",              He = "CD",  SoTiet = 40 },
		new MonHoc { MaMon = "CC++",  TenMon = "Lập trình hướng đối tượng với C/C++",      He = "CD",  SoTiet = 128 },
		new MonHoc { MaMon = "JQUE",  TenMon = "JQuery",                                   He = "CD",  SoTiet = 22 },
		new MonHoc { MaMon = "XML",   TenMon = "Công nghệ XML",                            He = "CD",  SoTiet = 32 },
		new MonHoc { MaMon = "CRYS",  TenMon = "Crystal Report trong Visual Studio",       He = "CD",  SoTiet = 32 },
		new MonHoc { MaMon = "BWEB",  TenMon = "HTML, CSS và JavaScript",                  He = "CD",  SoTiet = 32 },
		// Môn chưa khai báo hệ (He rỗng) và số tiết = 0
		new MonHoc { MaMon = "XYZ",   TenMon = "Chưa đặt tên môn",                         He = "",    SoTiet = 0 },
};

List<He> DS_He() => new List<He>
{
	new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
	new He { MaHe = "CD",  TenHe = "Chuyên đề" },
	new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" },
};

void Main()
{
	Bai21(); Bai22(); Bai31(); Bai32(); Bai41(); Bai51(); Bai52(); Bai61(); Bai62();
}

// ===================== Bài 2.1 =====================
void Bai21()
{
	"===== Bài 2.1 - Mảng số nguyên =====".Dump();
	int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

	"2.1a - Chia hết cho 4 và 3 (Query Syntax)".Dump();
	(from x in mangSo where x % 4 == 0 && x % 3 == 0 select x).Dump();
	"2.1a - Chia hết cho 4 và 3 (Method Syntax)".Dump();
	mangSo.Where(x => x % 4 == 0 && x % 3 == 0).Dump();

	"2.1b - Nhỏ hơn hoặc bằng 3".Dump();
	mangSo.Where(x => x <= 3).Dump();

	"2.1c - Chẵn chia đôi, lẻ giữ nguyên (dự kiến 25,21,8,3,9,4,6,7,12,0)".Dump();
	mangSo.Select(x => x % 2 == 0 ? x / 2 : x).Dump();
}

// ===================== Bài 2.2 =====================
void Bai22()
{
	"===== Bài 2.2 - Mảng chuỗi =====".Dump();
	string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
		"Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

	"2.2a - 4 ký tự, sắp tăng theo ký tự đầu".Dump();
	mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]).Dump();

	"2.2b - <chữ thường> - <CHỮ HOA>".Dump();
	mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}").Dump();

	"2.2c - Chứa ký tự 'u'".Dump();
	mangChuoi.Where(s => s.Contains('u')).Dump();

	"2.2d - Bắt đầu bằng chữ in hoa".Dump();
	string.Join(" ", mangChuoi.Where(s => char.IsUpper(s[0]))).Dump();
}

// ===================== Bài 3.1 =====================
void Bai31()
{
	"===== Bài 3.1 - Thống kê mảng số =====".Dump();
	int[] so = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

	"3.1a - Tổng số phần tử / chẵn / lẻ".Dump();
	new { Tong = so.Count(), Chan = so.Count(x => x % 2 == 0), Le = so.Count(x => x % 2 != 0) }.Dump();

	"3.1b - Tổng / lớn nhất / nhỏ nhất".Dump();
	new { Tong = so.Sum(), Max = so.Max(), Min = so.Min() }.Dump();

	"3.1c - Số giá trị khác nhau".Dump();
	so.Distinct().Count().Dump();

	"3.1d - Nhóm theo số dư khi chia cho 5".Dump();
	so.GroupBy(x => x % 5).OrderBy(g => g.Key).Dump();
}

// ===================== Bài 3.2 =====================
void Bai32()
{
	"===== Bài 3.2 - Thống kê mảng chuỗi =====".Dump();
	string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
		"Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
		"Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

	"3.2a - Chuỗi ngắn nhất".Dump();
	int ngan = monAn.Min(s => s.Length);
	monAn.Where(s => s.Length == ngan).Dump();

	"3.2a - Chuỗi dài nhất".Dump();
	int dai = monAn.Max(s => s.Length);
	monAn.Where(s => s.Length == dai).Dump();

	"3.2b - Nhóm theo từ đầu tiên của tên món".Dump();
	monAn.GroupBy(s => s.Split(' ')[0]).Dump();

	"3.2c - Số phần tử có từ đầu tiên là \"Bánh\"".Dump();
	monAn.Count(s => s.Split(' ')[0] == "Bánh").Dump();
}

// ===================== Bài 4.1 =====================
void Bai41()
{
	"===== Bài 4.1 - Danh sách môn học (DS_Mon) =====".Dump();
	var dsMon = DS_Mon();
	("Tổng số môn: " + dsMon.Count).Dump();
	dsMon.Dump();
}

// ===================== Bài 5.1 =====================
void Bai51()
{
	"===== Bài 5.1 - Truy vấn cơ bản List<MonHoc> =====".Dump();
	var dsMon = DS_Mon();

	"5.1a - Tên môn bắt đầu bằng \"Lập trình\"".Dump();
	dsMon.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon).Dump();

	"5.1b - Hệ CD, số tiết giảm dần rồi mã môn tăng dần".Dump();
	dsMon.Where(m => m.He == "CD").OrderByDescending(m => m.SoTiet).ThenBy(m => m.MaMon).Dump();

	"5.1c - Tên môn chứa \"web\", chỉ lấy Tên môn và Hệ".Dump();
	dsMon.Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
	     .Select(m => new { m.TenMon, m.He }).Dump();

	"5.1d - Hệ KTV, sắp tăng theo Mã môn".Dump();
	dsMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon).Dump();
}

// ===================== Bài 5.2 =====================
void Bai52()
{
	"===== Bài 5.2 - Thống kê List<MonHoc> =====".Dump();
	var dsMon = DS_Mon();

	"5.2a - Tổng số môn".Dump();
	dsMon.Count().Dump();

	"5.2b - Số môn bắt đầu bằng \"Lập trình\"".Dump();
	dsMon.Count(m => m.TenMon.StartsWith("Lập trình")).Dump();

	"5.2c - Tổng số tiết hệ KTV".Dump();
	dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet).Dump();

	"5.2d - Tổng số môn của mỗi hệ".Dump();
	dsMon.GroupBy(m => m.He).Select(g => new { He = g.Key, TongSoMon = g.Count() }).Dump();

	"5.2e - Nhóm theo Số tiết, giảm dần".Dump();
	dsMon.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key)
	     .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() }).Dump();

	"5.2f - Môn có số tiết cao nhất".Dump();
	byte maxTiet = dsMon.Max(m => m.SoTiet);
	dsMon.Where(m => m.SoTiet == maxTiet).Dump();

	"5.2g - Thống kê theo Hệ".Dump();
	dsMon.GroupBy(m => m.He).Select(g => new
	{
		He = g.Key,
		TongSoMon = g.Count(),
		TongSoTiet = g.Sum(m => m.SoTiet),
		TietCaoNhat = g.Max(m => m.SoTiet),
		TietThapNhat = g.Min(m => m.SoTiet)
	}).Dump();

	"5.2h - Các môn phân nhóm theo Hệ".Dump();
	dsMon.GroupBy(m => m.He).Dump();

	"5.2i - Các môn phân nhóm theo Số tiết (tăng dần)".Dump();
	dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key).Dump();

	"5.2j - Hệ KTV nhóm theo học phần HP2..HP5, sắp theo Mã môn".Dump();
	dsMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon)
	     .GroupBy(m => m.MaMon.Substring(0, 3)).Dump();

	"5.2k - Nhóm theo Hệ, Số tiết > 40, mỗi nhóm sắp theo Mã môn".Dump();
	(from m in dsMon
	 where m.SoTiet > 40
	 orderby m.MaMon
	 group m by m.He).Dump();
}

// ===================== Bài 6.1 =====================
void Bai61()
{
	"===== Bài 6.1 - Lớp He và DS_He() =====".Dump();
	var dsHe = DS_He();
	("Tổng số hệ: " + dsHe.Count).Dump();
	dsHe.Dump();
	"6.1 - Mã hệ - Tên hệ".Dump();
	(from h in dsHe select $"{h.MaHe} - {h.TenHe}").Dump();
}

// ===================== Bài 6.2 =====================
void Bai62()
{
	"===== Bài 6.2 - Join hai nguồn dữ liệu =====".Dump();
	var dsMon = DS_Mon();
	var dsHe = DS_He();

	"6.2a - Inner join: Tên hệ, Mã môn, Tên môn".Dump();
	(from h in dsHe
	 join m in dsMon on h.MaHe equals m.He
	 select new { h.TenHe, m.MaMon, m.TenMon }).Dump();

	"6.2b - Left outer join (GroupJoin + DefaultIfEmpty): cả hệ chưa có môn".Dump();
	var leftJoin = (from h in dsHe
	                join m in dsMon on h.MaHe equals m.He into nhom
	                from m in nhom.DefaultIfEmpty()
	                select new { h.TenHe, MaMon = m?.MaMon ?? "(chưa có môn)", TenMon = m?.TenMon ?? "" }).ToList();
	leftJoin.Dump();

	"6.2c - Cả hệ chưa có môn và môn chưa khai báo hệ".Dump();
	var monKhongHe = (from m in dsMon
	                  where !dsHe.Any(h => h.MaHe == m.He)
	                  select new { TenHe = "(chưa khai báo hệ)", m.MaMon, m.TenMon }).ToList();
	leftJoin.Concat(monKhongHe).Dump();

	"6.2d - Chỉ hệ chưa có môn và môn chưa khai báo hệ".Dump();
	var heKhongMon = from h in dsHe
	                 where !dsMon.Any(m => m.He == h.MaHe)
	                 select new { h.TenHe, MaMon = "(chưa có môn)", TenMon = "" };
	heKhongMon.Concat(monKhongHe).Dump();

	"6.2e - 5 môn có số tiết giảm dần".Dump();
	(from m in dsMon
	 join h in dsHe on m.He equals h.MaHe
	 orderby m.SoTiet descending, m.MaMon
	 select new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet }).Take(5).Dump();

	"6.2f - Tổng số môn của mỗi hệ (kể cả hệ 0 môn)".Dump();
	(from h in dsHe
	 join m in dsMon on h.MaHe equals m.He into nhom
	 select new { h.MaHe, h.TenHe, TongSoMon = nhom.Count() }).Dump();

	"6.2g - Số loại Số tiết khác nhau".Dump();
	dsMon.Select(m => m.SoTiet).Distinct().Count().Dump();

	"6.2h - Môn đầu tiên có tên bắt đầu bằng \"Lập trình\"".Dump();
	dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình")).Dump();

	"6.2i - Các môn theo từng hệ, đánh số thứ tự trong nhóm".Dump();
	dsMon.GroupBy(m => m.He)
	     .Select(g => new { He = g.Key, DS = g.Select((m, i) => new { STT = i + 1, m.MaMon, m.TenMon }) }).Dump();
}

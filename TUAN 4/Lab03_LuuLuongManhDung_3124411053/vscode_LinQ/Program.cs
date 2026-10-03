using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiThucHanhLINQ;

class Program
{
    static void Main()
    {
        // Để console hiển thị đúng tiếng Việt có dấu
        Console.OutputEncoding = Encoding.UTF8;

        // Gọi lần lượt các hàm bài tập
        Bai21();
        Bai22();
        Bai31();
        Bai32();
        Bai41();
        Bai51();
        Bai52();
        Bai62();
    }

    // ---------------------------------------------------------------
    // Các hàm hỗ trợ in kết quả (chỉ dùng foreach để xuất, đúng yêu cầu)
    // ---------------------------------------------------------------

    // In tiêu đề của một bài
    static void TieuDeBai(string s)
    {
        Console.WriteLine();
        Console.WriteLine("==================== " + s + " ====================");
    }

    // In nhãn cho từng câu
    static void Nhan(string s) => Console.WriteLine("\n>> " + s);

    // In mỗi phần tử của một dãy trên một dòng
    static void InDS<T>(IEnumerable<T> ds)
    {
        foreach (var x in ds) Console.WriteLine("   " + x);
    }

    // Hiển thị mã hệ; hệ rỗng thì ghi chú "chưa khai báo"
    static string HeHienThi(string he) => string.IsNullOrEmpty(he) ? "(chưa khai báo hệ)" : he;

    // ===============================================================
    // Bài 2.1 - Truy vấn mảng số nguyên
    // ===============================================================
    static void Bai21()
    {
        TieuDeBai("Bài 2.1 - Truy vấn mảng số nguyên");
        int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };
        Console.WriteLine("Mảng: " + string.Join(", ", mangSo));

        // a. Phần tử chia hết cho 4 và 3 (tức chia hết cho 12). Lưu ý 0 cũng chia hết.
        Nhan("a. Phần tử chia hết cho 4 và 3 (Query Syntax)");
        var a1 = from x in mangSo
                 where x % 4 == 0 && x % 3 == 0
                 select x;
        InDS(a1);

        Nhan("a. Phần tử chia hết cho 4 và 3 (Method Syntax)");
        var a2 = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
        InDS(a2);

        // b. Phần tử nhỏ hơn hoặc bằng 3
        Nhan("b. Phần tử <= 3 (Query Syntax)");
        var b1 = from x in mangSo
                 where x <= 3
                 select x;
        InDS(b1);

        Nhan("b. Phần tử <= 3 (Method Syntax)");
        var b2 = mangSo.Where(x => x <= 3);
        InDS(b2);

        // c. Dãy mới: số chẵn chia đôi, số lẻ giữ nguyên -> dùng select với toán tử ?:
        Nhan("c. Số chẵn chia đôi, số lẻ giữ nguyên (Query Syntax)");
        var c1 = from x in mangSo
                 select x % 2 == 0 ? x / 2 : x;
        Console.WriteLine("   " + string.Join(", ", c1));

        Nhan("c. Số chẵn chia đôi, số lẻ giữ nguyên (Method Syntax)");
        var c2 = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
        Console.WriteLine("   " + string.Join(", ", c2));
        Console.WriteLine("   (Kết quả dự kiến: 25, 21, 8, 3, 9, 4, 6, 7, 12, 0)");
    }

    // ===============================================================
    // Bài 2.2 - Truy vấn mảng chuỗi
    // ===============================================================
    static void Bai22()
    {
        TieuDeBai("Bài 2.2 - Truy vấn mảng chuỗi");
        string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
            "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

        // a. Phần tử có 4 ký tự, sắp xếp tăng dần theo ký tự đầu tiên
        //    (OrderBy là sắp xếp ổn định nên các phần tử trùng ký tự đầu giữ thứ tự ban đầu)
        Nhan("a. Phần tử có 4 ký tự, sắp tăng theo ký tự đầu (Query Syntax)");
        var a1 = from s in mangChuoi
                 where s.Length == 4
                 orderby s[0]
                 select s;
        InDS(a1);

        Nhan("a. Phần tử có 4 ký tự, sắp tăng theo ký tự đầu (Method Syntax)");
        var a2 = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
        InDS(a2);

        // b. Biến đổi thành "<chữ thường> - <CHỮ HOA>"
        Nhan("b. Dạng <chữ thường> - <CHỮ HOA> (Query Syntax)");
        var b1 = from s in mangChuoi
                 select s.ToLower() + " - " + s.ToUpper();
        InDS(b1);

        Nhan("b. Dạng <chữ thường> - <CHỮ HOA> (Method Syntax)");
        var b2 = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
        InDS(b2);

        // c. Phần tử chứa ký tự 'u' (chữ u không dấu; "Thúy" chứa 'ú' nên không tính)
        Nhan("c. Phần tử chứa ký tự 'u' (Query Syntax)");
        var c1 = from s in mangChuoi
                 where s.Contains('u')
                 select s;
        InDS(c1);

        Nhan("c. Phần tử chứa ký tự 'u' (Method Syntax)");
        var c2 = mangChuoi.Where(s => s.Contains('u'));
        InDS(c2);

        // d. Chọn các phần tử bắt đầu bằng chữ in hoa -> "Thúy Kiều Thúy Vân"
        Nhan("d. Phần tử bắt đầu bằng chữ in hoa (Query Syntax)");
        var d1 = from s in mangChuoi
                 where char.IsUpper(s[0])
                 select s;
        Console.WriteLine("   " + string.Join(" ", d1));

        Nhan("d. Phần tử bắt đầu bằng chữ in hoa (Method Syntax)");
        var d2 = mangChuoi.Where(s => char.IsUpper(s[0]));
        Console.WriteLine("   " + string.Join(" ", d2));
    }

    // ===============================================================
    // Bài 3.1 - Thống kê mảng số
    // ===============================================================
    static void Bai31()
    {
        TieuDeBai("Bài 3.1 - Thống kê mảng số");
        int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };
        Console.WriteLine("Mảng: " + string.Join(", ", mangSo));

        // a. Tổng số phần tử, số chẵn, số lẻ -> dùng Count() (có/không có điều kiện)
        Nhan("a. Tổng số phần tử / số chẵn / số lẻ");
        Console.WriteLine($"   Tổng số phần tử: {mangSo.Count()}");
        Console.WriteLine($"   Số phần tử chẵn: {mangSo.Count(x => x % 2 == 0)}");
        Console.WriteLine($"   Số phần tử lẻ  : {mangSo.Count(x => x % 2 != 0)}");

        // b. Tổng, lớn nhất, nhỏ nhất -> Sum, Max, Min
        Nhan("b. Tổng / lớn nhất / nhỏ nhất");
        Console.WriteLine($"   Tổng các giá trị: {mangSo.Sum()}");
        Console.WriteLine($"   Giá trị lớn nhất: {mangSo.Max()}");
        Console.WriteLine($"   Giá trị nhỏ nhất: {mangSo.Min()}");

        // c. Số giá trị khác nhau -> Distinct().Count()
        Nhan("c. Số giá trị khác nhau");
        Console.WriteLine($"   Các giá trị khác nhau: {string.Join(", ", mangSo.Distinct())}");
        Console.WriteLine($"   Số giá trị khác nhau : {mangSo.Distinct().Count()}");

        // d. Phân nhóm theo số dư khi chia cho 5
        Nhan("d. Phân nhóm theo số dư khi chia cho 5 (Query Syntax)");
        var d1 = from x in mangSo
                 group x by x % 5 into g
                 orderby g.Key
                 select g;
        foreach (var g in d1)
            Console.WriteLine($"   Dư {g.Key}: {string.Join(", ", g)}");

        Nhan("d. Phân nhóm theo số dư khi chia cho 5 (Method Syntax)");
        var d2 = mangSo.GroupBy(x => x % 5).OrderBy(g => g.Key);
        foreach (var g in d2)
            Console.WriteLine($"   Dư {g.Key}: {string.Join(", ", g)}");
    }

    // ===============================================================
    // Bài 3.2 - Thống kê mảng chuỗi
    // ===============================================================
    static void Bai32()
    {
        TieuDeBai("Bài 3.2 - Thống kê mảng chuỗi");
        string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
            "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
            "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

        // a. Phần tử ngắn nhất và dài nhất: tìm độ dài Min/Max rồi lọc các phần tử có độ dài đó
        Nhan("a. Phần tử ngắn nhất và dài nhất");
        int ngan = monAn.Min(s => s.Length);
        int dai = monAn.Max(s => s.Length);
        Console.WriteLine($"   Ngắn nhất ({ngan} ký tự):");
        InDS(monAn.Where(s => s.Length == ngan));
        Console.WriteLine($"   Dài nhất ({dai} ký tự):");
        InDS(monAn.Where(s => s.Length == dai));

        // b. Phân nhóm theo từ đầu tiên của tên món (tách chuỗi bằng khoảng trắng)
        Nhan("b. Phân nhóm theo từ đầu tiên (Query Syntax)");
        var b1 = from s in monAn
                 group s by s.Split(' ')[0] into g
                 select g;
        foreach (var g in b1)
        {
            Console.WriteLine($"   [{g.Key}] ({g.Count()} món)");
            foreach (var m in g) Console.WriteLine("       - " + m);
        }

        Nhan("b. Phân nhóm theo từ đầu tiên (Method Syntax)");
        foreach (var g in monAn.GroupBy(s => s.Split(' ')[0]))
            Console.WriteLine($"   [{g.Key}]: {string.Join("; ", g)}");

        // c. Đếm phần tử có từ đầu tiên là "Bánh"
        Nhan("c. Số phần tử có từ đầu tiên là \"Bánh\"");
        int demBanh = monAn.Count(s => s.Split(' ')[0] == "Bánh");
        Console.WriteLine($"   Kết quả: {demBanh}");
    }

    // ===============================================================
    // Bài 4.1 - Kiểm tra nguồn dữ liệu List<MonHoc>
    // ===============================================================
    static void Bai41()
    {
        TieuDeBai("Bài 4.1 - Danh sách môn học (DuLieu.DS_Mon)");
        var ds = DuLieu.DS_Mon();
        Console.WriteLine($"Tổng số môn: {ds.Count}");
        InDS(ds);
    }

    // ===============================================================
    // Bài 5.1 - Truy vấn cơ bản trên List<MonHoc>
    // ===============================================================
    static void Bai51()
    {
        TieuDeBai("Bài 5.1 - Truy vấn cơ bản List<MonHoc>");
        List<MonHoc> dsMon = DuLieu.DS_Mon();

        // a. Tên môn bắt đầu bằng "Lập trình"
        Nhan("a. Tên môn bắt đầu bằng \"Lập trình\" (Query Syntax)");
        var a1 = from m in dsMon
                 where m.TenMon.StartsWith("Lập trình")
                 select m.TenMon;
        InDS(a1);

        Nhan("a. Tên môn bắt đầu bằng \"Lập trình\" (Method Syntax)");
        InDS(dsMon.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon));

        // b. Hệ CD: số tiết giảm dần, rồi mã môn tăng dần
        Nhan("b. Hệ CD, số tiết giảm dần rồi mã môn tăng dần (Query Syntax)");
        var b1 = from m in dsMon
                 where m.He == "CD"
                 orderby m.SoTiet descending, m.MaMon
                 select m;
        InDS(b1);

        Nhan("b. Hệ CD, số tiết giảm dần rồi mã môn tăng dần (Method Syntax)");
        InDS(dsMon.Where(m => m.He == "CD")
                  .OrderByDescending(m => m.SoTiet)
                  .ThenBy(m => m.MaMon));

        // c. Tên môn chứa "web" (không phân biệt hoa/thường), chỉ lấy Tên môn và Hệ
        //    -> select tạo kiểu ẩn danh (anonymous type) chỉ gồm 2 thuộc tính
        Nhan("c. Tên môn chứa \"web\", chỉ lấy Tên môn và Hệ (Query Syntax)");
        var c1 = from m in dsMon
                 where m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase)
                 select new { m.TenMon, m.He };
        InDS(c1);

        Nhan("c. Tên môn chứa \"web\", chỉ lấy Tên môn và Hệ (Method Syntax)");
        InDS(dsMon.Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                  .Select(m => new { m.TenMon, m.He }));

        // d. Hệ KTV, sắp tăng theo mã môn
        Nhan("d. Hệ KTV, sắp tăng theo Mã môn (Query Syntax)");
        var d1 = from m in dsMon
                 where m.He == "KTV"
                 orderby m.MaMon
                 select m;
        InDS(d1);

        Nhan("d. Hệ KTV, sắp tăng theo Mã môn (Method Syntax)");
        InDS(dsMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon));
    }

    // ===============================================================
    // Bài 5.2 - Thống kê trên List<MonHoc>
    // ===============================================================
    static void Bai52()
    {
        TieuDeBai("Bài 5.2 - Thống kê List<MonHoc>");
        List<MonHoc> dsMon = DuLieu.DS_Mon();

        // a. Tổng số môn
        Nhan("a. Tổng số môn hiện có");
        Console.WriteLine($"   {dsMon.Count()}");

        // b. Đếm môn bắt đầu bằng "Lập trình"
        Nhan("b. Số môn có tên bắt đầu bằng \"Lập trình\"");
        Console.WriteLine($"   {dsMon.Count(m => m.TenMon.StartsWith("Lập trình"))}");

        // c. Tổng số tiết hệ KTV
        Nhan("c. Tổng số tiết của hệ KTV");
        Console.WriteLine($"   {dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet)}");

        // d. Tổng số môn của mỗi hệ
        Nhan("d. Tổng số môn của mỗi hệ (Query Syntax)");
        var d1 = from m in dsMon
                 group m by m.He into g
                 select new { He = g.Key, TongSoMon = g.Count() };
        foreach (var x in d1)
            Console.WriteLine($"   Hệ: {HeHienThi(x.He),-20} Tổng số môn: {x.TongSoMon}");

        Nhan("d. Tổng số môn của mỗi hệ (Method Syntax)");
        var d2 = dsMon.GroupBy(m => m.He).Select(g => new { He = g.Key, TongSoMon = g.Count() });
        foreach (var x in d2)
            Console.WriteLine($"   Hệ: {HeHienThi(x.He),-20} Tổng số môn: {x.TongSoMon}");

        // e. Nhóm theo số tiết, giảm dần theo số tiết
        Nhan("e. Nhóm theo Số tiết, sắp giảm dần (Query Syntax)");
        var e1 = from m in dsMon
                 group m by m.SoTiet into g
                 orderby g.Key descending
                 select new { SoTiet = g.Key, TongSoMon = g.Count() };
        foreach (var x in e1)
            Console.WriteLine($"   Số tiết: {x.SoTiet,3}   Tổng số môn: {x.TongSoMon}");

        Nhan("e. Nhóm theo Số tiết, sắp giảm dần (Method Syntax)");
        var e2 = dsMon.GroupBy(m => m.SoTiet)
                      .OrderByDescending(g => g.Key)
                      .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() });
        foreach (var x in e2)
            Console.WriteLine($"   Số tiết: {x.SoTiet,3}   Tổng số môn: {x.TongSoMon}");

        // f. Môn có số tiết cao nhất (dùng Max rồi lọc; có thể có nhiều môn cùng số tiết cao nhất)
        Nhan("f. Môn học có số tiết cao nhất");
        byte maxTiet = dsMon.Max(m => m.SoTiet);
        InDS(dsMon.Where(m => m.SoTiet == maxTiet));

        // g. Thống kê theo hệ: tổng môn, tổng tiết, cao nhất, thấp nhất
        Nhan("g. Thống kê theo Hệ");
        var g1 = from m in dsMon
                 group m by m.He into g
                 select new
                 {
                     He = g.Key,
                     TongSoMon = g.Count(),
                     TongSoTiet = g.Sum(m => m.SoTiet),
                     TietCaoNhat = g.Max(m => m.SoTiet),
                     TietThapNhat = g.Min(m => m.SoTiet)
                 };
        foreach (var x in g1)
            Console.WriteLine($"   {HeHienThi(x.He),-20} Môn: {x.TongSoMon,2} | Tổng tiết: {x.TongSoTiet,4} | Cao nhất: {x.TietCaoNhat,3} | Thấp nhất: {x.TietThapNhat,3}");

        // h. Liệt kê môn học phân nhóm theo Hệ
        Nhan("h. Các môn học phân nhóm theo Hệ");
        foreach (var g in dsMon.GroupBy(m => m.He))
        {
            Console.WriteLine($"   Hệ {HeHienThi(g.Key)}:");
            foreach (var m in g) Console.WriteLine("      " + m);
        }

        // i. Phân nhóm theo Số tiết, tăng dần theo Số tiết
        Nhan("i. Các môn học phân nhóm theo Số tiết (tăng dần)");
        foreach (var g in dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
        {
            Console.WriteLine($"   Số tiết {g.Key}:");
            foreach (var m in g) Console.WriteLine("      " + m);
        }

        // j. Hệ KTV, phân nhóm theo học phần (3 ký tự đầu của mã môn: HP2, HP3, HP4, HP5)
        Nhan("j. Hệ KTV phân nhóm theo học phần, sắp theo Mã môn");
        var j1 = dsMon.Where(m => m.He == "KTV")
                      .OrderBy(m => m.MaMon)
                      .GroupBy(m => m.MaMon.Substring(0, 3));
        foreach (var g in j1)
        {
            Console.WriteLine($"   Học phần {g.Key}:");
            foreach (var m in g) Console.WriteLine("      " + m);
        }

        // k. Nhóm theo Hệ, chỉ lấy môn có số tiết > 40, mỗi nhóm sắp theo Mã môn
        Nhan("k. Nhóm theo Hệ, chỉ lấy Số tiết > 40, mỗi nhóm sắp theo Mã môn");
        var k1 = from m in dsMon
                 where m.SoTiet > 40
                 orderby m.MaMon
                 group m by m.He;
        foreach (var g in k1)
        {
            Console.WriteLine($"   Hệ {HeHienThi(g.Key)}:");
            foreach (var m in g) Console.WriteLine("      " + m);
        }
    }

    // ===============================================================
    // Bài 6.2 - Join và các toán tử tập hợp (hai nguồn dữ liệu)
    // ===============================================================
    static void Bai62()
    {
        TieuDeBai("Bài 6.2 - Join hai nguồn dữ liệu");
        List<MonHoc> dsMon = DuLieu.DS_Mon();
        List<He> dsHe = DuLieu.DS_He();

        // a. Inner join: chỉ giữ các cặp Hệ - Môn khớp khóa MaHe = He
        Nhan("a. Inner join: Tên hệ, Mã môn, Tên môn (Query Syntax)");
        var a1 = from h in dsHe
                 join m in dsMon on h.MaHe equals m.He
                 select new { h.TenHe, m.MaMon, m.TenMon };
        InDS(a1);

        Nhan("a. Inner join (Method Syntax)");
        var a2 = dsHe.Join(dsMon, h => h.MaHe, m => m.He,
                           (h, m) => new { h.TenHe, m.MaMon, m.TenMon });
        Console.WriteLine($"   Số dòng kết quả: {a2.Count()}");

        // b. Left outer join: GroupJoin + DefaultIfEmpty -> giữ cả hệ chưa có môn (QT)
        Nhan("b. Left outer join: liệt kê cả hệ chưa có môn học");
        var b1 = from h in dsHe
                 join m in dsMon on h.MaHe equals m.He into nhomMon
                 from m in nhomMon.DefaultIfEmpty()   // hệ không có môn -> m = null
                 select new
                 {
                     h.TenHe,
                     MaMon = m?.MaMon ?? "(chưa có môn)",
                     TenMon = m?.TenMon ?? ""
                 };
        InDS(b1);

        // c. Full outer join = left join (b) + các môn chưa khai báo hệ
        Nhan("c. Full outer join: cả hệ chưa có môn và môn chưa khai báo hệ");
        var monKhongHe = from m in dsMon
                         where !dsHe.Any(h => h.MaHe == m.He)
                         select new { TenHe = "(chưa khai báo hệ)", m.MaMon, m.TenMon };
        var c1 = b1.Concat(monKhongHe);
        InDS(c1);

        // d. Chỉ những hệ chưa có môn và những môn chưa khai báo hệ
        Nhan("d. Chỉ hệ chưa có môn và môn chưa khai báo hệ");
        var heKhongMon = from h in dsHe
                         where !dsMon.Any(m => m.He == h.MaHe)
                         select new { h.TenHe, MaMon = "(chưa có môn)", TenMon = "" };
        var d1 = heKhongMon.Concat(monKhongHe);
        InDS(d1);

        // e. 5 môn có số tiết giảm dần: OrderByDescending + Take(5)
        Nhan("e. Top 5 môn có số tiết giảm dần");
        var e1 = (from m in dsMon
                  join h in dsHe on m.He equals h.MaHe
                  orderby m.SoTiet descending, m.MaMon
                  select new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet }).Take(5);
        InDS(e1);

        // f. Tổng số môn của mỗi hệ, kể cả hệ chưa có môn (count = 0) nhờ GroupJoin
        Nhan("f. Tổng số môn của mỗi hệ (GroupJoin)");
        var f1 = from h in dsHe
                 join m in dsMon on h.MaHe equals m.He into nhomMon
                 select new { h.MaHe, h.TenHe, TongSoMon = nhomMon.Count() };
        InDS(f1);

        // g. Số loại Số tiết khác nhau
        Nhan("g. Số loại Số tiết khác nhau");
        var cacLoai = dsMon.Select(m => m.SoTiet).Distinct().OrderBy(t => t);
        Console.WriteLine($"   Các loại: {string.Join(", ", cacLoai)}");
        Console.WriteLine($"   Số loại : {cacLoai.Count()}");

        // h. Môn đầu tiên có tên bắt đầu bằng "Lập trình" (FirstOrDefault tránh lỗi nếu không có)
        Nhan("h. Môn học đầu tiên có tên bắt đầu bằng \"Lập trình\"");
        var h1 = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
        Console.WriteLine("   " + (h1?.ToString() ?? "(không có)"));

        // i. Liệt kê môn theo từng hệ, đánh số thứ tự trong mỗi nhóm
        //    Select có tham số index (i) giúp đánh số bắt đầu từ 1 trong từng nhóm
        Nhan("i. Các môn theo từng hệ, có số thứ tự trong nhóm");
        var i1 = dsMon.GroupBy(m => m.He);
        foreach (var g in i1)
        {
            Console.WriteLine($"   Hệ {HeHienThi(g.Key)}:");
            var danhSo = g.Select((m, stt) => $"{stt + 1,2}. {m.MaMon,-7} {m.TenMon}");
            foreach (var dong in danhSo) Console.WriteLine("      " + dong);
        }
    }
}

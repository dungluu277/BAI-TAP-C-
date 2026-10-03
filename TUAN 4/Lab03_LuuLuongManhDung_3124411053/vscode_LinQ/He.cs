namespace BaiThucHanhLINQ;

/// <summary>
/// Bài 6.1 - Lớp He: đại diện cho một hệ đào tạo (KTV, CD, QT).
/// </summary>
public class He
{
    public string MaHe { get; set; } = "";   // Mã hệ (khóa để join với MonHoc.He)
    public string TenHe { get; set; } = "";  // Tên hệ
}

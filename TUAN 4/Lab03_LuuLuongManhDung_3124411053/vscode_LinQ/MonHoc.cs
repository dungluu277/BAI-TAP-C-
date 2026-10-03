namespace BaiThucHanhLINQ;

/// <summary>
/// Bài 4.1 - Lớp MonHoc: đại diện cho một môn học.
/// </summary>
public class MonHoc
{
    public string MaMon { get; set; } = "";   // Mã môn, ví dụ: HP2_1
    public string TenMon { get; set; } = "";  // Tên môn
    public string He { get; set; } = "";      // Mã hệ: KTV, CD, QT... ("" nếu chưa khai báo hệ)
    public byte SoTiet { get; set; }          // Số tiết

    // Ghi đè ToString để in một môn học ra màn hình cho gọn
    public override string ToString()
        => $"{MaMon,-7} | {TenMon,-45} | {(He == "" ? "(trống)" : He),-7} | {SoTiet,3} tiết";
}

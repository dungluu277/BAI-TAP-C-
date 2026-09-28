using System;
class NhanVienKinhDoanh : NhanVien
{
    public decimal LuongCoBan {get;set;}
    public int SoHopDong{get;set;}
    public NhanVienKinhDoanh(string maNV, string hoTen, decimal luongCoBan, int soHopDong) : base(maNV, hoTen)
    {
        LuongCoBan = luongCoBan;
        SoHopDong = soHopDong;
    }
    public override decimal TinhLuong()
    {
        return LuongCoBan + SoHopDong * 500000;
    }
}

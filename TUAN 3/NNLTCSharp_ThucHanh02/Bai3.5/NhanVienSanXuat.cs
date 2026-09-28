using System;
class NhanVienSanXuat : NhanVien
{
    public int SoLuongSanPham {get;set;}
    public NhanVienSanXuat(string maNV, string hoTen, int soLuongSanPham) : base(maNV, hoTen)
    {
        SoLuongSanPham = soLuongSanPham;
    }
    public override decimal TinhLuong()
    {
        if (SoLuongSanPham > 0 && SoLuongSanPham <= 3000)
        return SoLuongSanPham * 1000;
        else
        return SoLuongSanPham * 1000 + (SoLuongSanPham*1000/100*5);
    }
}
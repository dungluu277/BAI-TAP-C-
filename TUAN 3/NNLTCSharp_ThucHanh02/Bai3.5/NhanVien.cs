using System;
using System.Collections.Generic;
public abstract class NhanVien
{
    public string MaNV {get; set; }
    public string HoTen {get; set; }
    public NhanVien(string maNV, string hoTen)
    {
        MaNV = maNV;
        HoTen = hoTen;
    }
    public abstract decimal TinhLuong();
    public void Xuat()
    {
        Console.WriteLine($"Ma: {MaNV} | Ho ten: {HoTen} | Luong: {TinhLuong(): N0} VND ");
    }
}

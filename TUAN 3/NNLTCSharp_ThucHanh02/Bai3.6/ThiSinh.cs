using System;
using System.Collections.Generic;

public abstract class ThiSinh
{
    public int  SBD {get;set;}
    public string HoTen {get;set;}
    public int Bai1 {get;set;}
    public int Bai2 {get;set;}
    public int Bai3 {get;set;}
    public ThiSinh(int sBD, string hoTen, int bai1, int bai2, int bai3)
    {
        SBD = sBD;
        HoTen = hoTen;
        Bai1 = bai1;
        Bai2 = bai2;
        Bai3 = bai3;
    }
    public abstract decimal TinhDiem();
    public void Xuat()
    {
        Console.WriteLine($"SBD: {SBD} | Ho ten: {HoTen} | Tong diem: {TinhDiem()}");
    }
    
}
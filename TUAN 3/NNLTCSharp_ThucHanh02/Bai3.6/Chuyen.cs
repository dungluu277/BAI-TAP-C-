using System;
class Chuyen : ThiSinh
{
    public int DiemMonAnh{get;set;}
    public Chuyen(int sBD, string hoTen, int bai1, int bai2, int bai3,int diemMonAnh) : base(sBD,hoTen,bai1,bai2,bai3)
    {
        DiemMonAnh = diemMonAnh;
    }
    public override decimal TinhDiem()
    {
        if (DiemMonAnh<=8 && DiemMonAnh >= 7)
            return Bai1+Bai2+Bai3+1;
        else if (DiemMonAnh>=9 && DiemMonAnh<=10)
            return Bai1+Bai2+Bai3+2;
        else
            return Bai1+Bai2+Bai3;
    }
}
using System;
class SieuCup : ThiSinh
{
    public int DiemCSDL {get;set;}
    public SieuCup(int sBD, string hoTen, int bai1,int bai2,int bai3,int diemCSDL) : base(sBD,hoTen,bai1,bai2,bai3)
    {
        DiemCSDL = diemCSDL;
    }
    public override decimal TinhDiem()
    {
        return Bai1+Bai2+Bai3+DiemCSDL;
    }
}
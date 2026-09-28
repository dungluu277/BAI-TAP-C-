using System;
namespace Tuan02.TH2
{
    class SinhVien
    {
        private string hoTen = string.Empty;
        private int namSinh;

        public SinhVien()
        {
        }

        public SinhVien(string hoTen, int namSinh)
        {
            this.hoTen = hoTen;
            this.namSinh = namSinh;
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        public int TinhTuoi()
        {
            return DateTime.Now.Year - namSinh;
        }

        public void XuatThongTin()
        {
            Console.WriteLine($"ho ten sinh vien: {hoTen}");
            Console.WriteLine($"nam sinh cua sinh vien: {namSinh}");
            Console.WriteLine($"Tuoi cua sinh vien la: {TinhTuoi()}");
        }
    }
    class Bai2
    {
        public static void Main(string[] args)
        {
            SinhVien sv = new SinhVien();
            Console.WriteLine("Nhap hoten sinh vien: ");
            sv.HoTen = Console.ReadLine()!;
            Console.WriteLine("Nhap nam sinh cua sinh vien: ");
            sv.NamSinh = int.Parse(Console.ReadLine()!);
            Console.WriteLine("\nTHONG TIN SINH VIEN: ");
            sv.XuatThongTin();
        }
    }
}
using System;
using System.Text;

namespace CSharp_ThucHanh01.BaiTap
{
    public static class BaiTap
    {
        public static void Bai1()
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine();
            Console.WriteLine("Ho ten vua nhap: " + hoTen);
            Console.WriteLine();

        }

        public static void Bai2()
        {
            Console.Write("Nhap ho ten cua ban: ");
            string hoTen = Console.ReadLine();
            Console.WriteLine("Chao ban " + hoTen + "!");
        }

        public static void Bai3()
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            long ketQua = 1;
            for (int i = 0; i < y; i++)
                ketQua *= x;

            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }

        public static void Bai4()
        {
            Console.Write("Nhap so nguyen x: ");
            string sx = Console.ReadLine();

            Console.Write("Nhap so nguyen y: ");
            string sy = Console.ReadLine();

            if (!int.TryParse(sx, out int x))
            {
                Console.WriteLine("Loi: x khong phai la so nguyen.");
                return;
            }

            if (!int.TryParse(sy, out int y))
            {
                Console.WriteLine("Loi: y khong phai la so nguyen.");
                return;
            }

            if (y < 0)
            {
                Console.WriteLine("Loi: y phai >= 0 de tinh x^y bang so nguyen.");
                return;
            }

            long ketQua = 1;
            for (int i = 0; i < y; i++)
                ketQua *= x;

            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }
        public static void Bai5()
        {
            double x = 0, y = 0;
            bool daNhap = false;

            while (true)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        Console.Write("Nhap x: ");
                        while (!double.TryParse(Console.ReadLine(), out x))
                            Console.Write("Nhap lai x: ");

                        Console.Write("Nhap y: ");
                        while (!double.TryParse(Console.ReadLine(), out y))
                            Console.Write("Nhap lai y: ");

                        daNhap = true;
                        Console.WriteLine("Da nhap x = {0}, y = {1}", x, y);
                        break;

                    case "2":
                        if (!daNhap)
                        {
                            Console.WriteLine("Hay chon 1 de nhap x, y truoc.");
                        }
                        else if (x == 0 && y < 0)
                        {
                            Console.WriteLine("Khong tinh duoc 0 mu so am.");
                        }
                        else
                        {
                            Console.WriteLine("x^y = " + Math.Pow(x, y));
                        }
                        break;

                    case "3":
                        if (!daNhap)
                        {
                            Console.WriteLine("Hay chon 1 de nhap x, y truoc.");
                        }
                        else
                        {
                            if (x < 0 || y < 0)
                                Console.WriteLine("Khong tinh duoc can bac hai cua so am trong so thuc.");
                            else
                            {
                                Console.WriteLine("Can bac 2 cua x = " + Math.Sqrt(x));
                                Console.WriteLine("Can bac 2 cua y = " + Math.Sqrt(y));
                            }
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }

                Console.WriteLine();
            }
        }
        public static int TimMax(int a, int b, int c)
        {
            int max = a;
            if (b > max) max = b;
            if (c > max) max = c;
            return max;
        }

        public static void Bai6()
        {
            Console.Write("Nhap a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Nhap c: ");
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine("Gia tri lon nhat: " + TimMax(a, b, c));
        }

        public static bool LaSoNguyenTo(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static void Bai7()
        {
            Console.WriteLine("BAI 7");
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());

            if (LaSoNguyenTo(n))
                Console.WriteLine(n + " la so nguyen to.");
            else
                Console.WriteLine(n + " khong phai la so nguyen to.");
        }

        public static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        public static void Bai8()
        {
            Console.WriteLine("BAI 8");
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Truoc khi hoan vi: a = {0}, b = {1}", a, b);
            HoanVi(ref a, ref b);
            Console.WriteLine("Sau khi hoan vi: a = {0}, b = {1}", a, b);
        }

        public static void TimMaxMin(double a, double b, double c, out double max, out double min)
        {
            max = a;
            min = a;

            if (b > max) max = b;
            if (c > max) max = c;

            if (b < min) min = b;
            if (c < min) min = c;
        }

        public static void Bai9()
        {
            Console.WriteLine("BAI 9");
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Nhap c: ");
            double c = double.Parse(Console.ReadLine());

            TimMaxMin(a, b, c, out double max, out double min);

            Console.WriteLine("Gia tri lon nhat: " + max);
            Console.WriteLine("Gia tri nho nhat: " + min);
        }

        public static bool LaChuoiDoiXung(string s)
        {
            if (s == null)
                return false;

            int trai = 0;
            int phai = s.Length - 1;

            while (trai < phai)
            {
                if (s[trai] != s[phai])
                    return false;

                trai++;
                phai--;
            }

            return true;
        }

        public static void Bai10()
        {
            Console.WriteLine("BAI 10");
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();

            if (LaChuoiDoiXung(s))
                Console.WriteLine("Chuoi doi xung.");
            else
                Console.WriteLine("Chuoi khong doi xung.");
        }

        public static string DaoChuoi(string s)
        {
            if (s == null)
                return "";

            StringBuilder sb = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);

            return sb.ToString();
        }

        public static void Bai11()
        {
            Console.WriteLine("BAI 11");
            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine();

            Console.WriteLine("Chuoi dao: " + DaoChuoi(s));
        }

        public static void Bai12()
        {
            Console.WriteLine("BAI 12");
            Console.Write("Nhap chuoi gom nhieu tu: ");
            string s = Console.ReadLine();

            string chuoiThuong = s.ToLower();
            string chuoiHoa = s.ToUpper();
            string[] tu = s.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine("Chuoi thuong: " + chuoiThuong);
            Console.WriteLine("Chuoi hoa: " + chuoiHoa);
            Console.WriteLine("So tu trong chuoi: " + tu.Length);
        }

        public class SinhVien
        {
            private string maSinhVien;
            private string hoTen;
            private string diaChi;
            private int namThu;

            public SinhVien()
            {
            }

            public SinhVien(string maSinhVien, string hoTen, string diaChi, int namThu)
            {
                this.maSinhVien = maSinhVien;
                this.hoTen = hoTen;
                this.diaChi = diaChi;
                this.namThu = namThu;
            }

            public void Nhap()
            {
                Console.Write("Ma sinh vien: ");
                maSinhVien = Console.ReadLine();

                Console.Write("Ho ten: ");
                hoTen = Console.ReadLine();

                Console.Write("Dia chi: ");
                diaChi = Console.ReadLine();

                Console.Write("Sinh vien nam thu may: ");
                while (!int.TryParse(Console.ReadLine(), out namThu))
                    Console.Write("Nhap lai nam thu: ");
            }

            public void Xuat()
            {
                Console.WriteLine("Ma sinh vien: " + maSinhVien);
                Console.WriteLine("Ho ten: " + hoTen);
                Console.WriteLine("Dia chi: " + diaChi);
                Console.WriteLine("Nam thu: " + namThu);
            }
        }

        public static void Bai13()
        {
            Console.WriteLine("BAI 13");
            SinhVien sv = new SinhVien();
            sv.Nhap();

            Console.WriteLine();
            Console.WriteLine("THONG TIN SINH VIEN");
            sv.Xuat();
        }
        public class NhanVien
        {
            private string hoTen;
            private double mucLuong;
            private int soNgayVang;

            public NhanVien()
            {
            }

            public void Nhap()
            {
                Console.Write("Ho ten: ");
                hoTen = Console.ReadLine();

                Console.Write("Muc luong: ");
                while (!double.TryParse(Console.ReadLine(), out mucLuong))
                    Console.Write("Nhap lai muc luong: ");

                Console.Write("So ngay vang: ");
                while (!int.TryParse(Console.ReadLine(), out soNgayVang))
                    Console.Write("Nhap lai so ngay vang: ");
            }

            public double TinhLuong()
            {
                return mucLuong - soNgayVang * 100000;
            }

            public void Xuat()
            {
                Console.WriteLine("Ho ten: " + hoTen);
                Console.WriteLine("Muc luong ban dau: " + mucLuong + " VNĐ");
                Console.WriteLine("So ngay vang: " + soNgayVang);
                Console.WriteLine("Luong thuc nhan: " + TinhLuong() + " VNĐ");
            }
        }

        public static void Bai14()
        {
            Console.WriteLine("BAI 14");
            NhanVien nv = new NhanVien();
            nv.Nhap();

            Console.WriteLine();
            Console.WriteLine("THONG TIN NHAN VIEN");
            nv.Xuat();
        }

        // Bai 15: Cac phuong thuc thanh vien cho mang so nguyen.
        public static void NhapMang(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("a[{0}] = ", i);
                while (!int.TryParse(Console.ReadLine(), out a[i]))
                    Console.Write("Nhap lai a[{0}] = ", i);
            }
        }

        public static void XuatMang(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        public static void TimMinMax(int[] a, out int min, out int max)
        {
            min = a[0];
            max = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
                if (a[i] > max) max = a[i];
            }
        }

        public static int[] LaySoNguyenTo(int[] a)
        {
            int dem = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (LaSoNguyenTo(a[i]))
                    dem++;
            }

            int[] ketQua = new int[dem];
            int viTri = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (LaSoNguyenTo(a[i]))
                {
                    ketQua[viTri] = a[i];
                    viTri++;
                }
            }

            return ketQua;
        }

        public static void Bai15()
        {
            Console.WriteLine("BAI 15");
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("n phai > 0.");
                return;
            }

            int[] a = new int[n];
            NhapMang(a);

            Console.Write("Mang vua nhap: ");
            XuatMang(a);

            TimMinMax(a, out int min, out int max);
            Console.WriteLine("Phan tu nho nhat: " + min);
            Console.WriteLine("Phan tu lon nhat: " + max);

            int[] soNguyenTo = LaySoNguyenTo(a);
            Console.Write("Mang cac so nguyen to: ");

            if (soNguyenTo.Length == 0)
                Console.WriteLine("Khong co.");
            else
                XuatMang(soNguyenTo);
        }

        public static void Bai16()
        {
            Console.WriteLine("BAI 16");
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("n phai > 0.");
                return;
            }

            string[] hoTen = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Ho ten nguoi thu {0}: ", i + 1);
                hoTen[i] = Console.ReadLine();
            }

            Array.Sort(hoTen, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine();
            Console.WriteLine("Danh sach sau khi sap xep tang dan:");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0}. {1}", i + 1, hoTen[i]);
        }

        public static void Bai17()
        {
            Console.WriteLine("BAI 17");
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Nhap m: ");
            int m = int.Parse(Console.ReadLine());

            if (n <= 0 || m <= 0)
            {
                Console.WriteLine("n va m phai > 0.");
                return;
            }

            int[,] a = new int[n, m];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    a[i, j] = random.Next(10, 101);
            }

            Console.WriteLine();
            Console.WriteLine("Mang A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }

            int soChanCount = 0;
            int soLeCount = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] % 2 == 0)
                        soChanCount++;
                    else
                        soLeCount++;
                }
            }

            int[] soChan = new int[soChanCount];
            int[] soLe = new int[soLeCount];

            int vtChan = 0;
            int vtLe = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        soChan[vtChan] = a[i, j];
                        vtChan++;
                    }
                    else
                    {
                        soLe[vtLe] = a[i, j];
                        vtLe++;
                    }
                }
            }

            Console.WriteLine();
            Console.Write("Mang cac so chan: ");
            XuatMang(soChan);

            Console.Write("Mang cac so le: ");
            XuatMang(soLe);
        }
    }
}

using System;
using BT = CSharp_ThucHanh01.BaiTap.BaiTap;

namespace CSharp_ThucHanh01
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== THUC HANH NGON NGU LAP TRINH C# =====");
                Console.WriteLine("1. Bai 1 - Ma nguon chuong trinh");
                Console.WriteLine("2. Bai 2 - Xuat va nhap chuoi");
                Console.WriteLine("3. Bai 3 - Nhap so nguyen");
                Console.WriteLine("4. Bai 4 - Kiem tra so nguyen");
                Console.WriteLine("5. Bai 5 - Menu tinh toan");
                Console.WriteLine("6. Bai 6 - Tim lon nhat 3 so nguyen");
                Console.WriteLine("7. Bai 7 - Kiem tra so nguyen to");
                Console.WriteLine("8. Bai 8 - Hoan vi 2 so thuc");
                Console.WriteLine("9. Bai 9 - Tim lon nhat va nho nhat");
                Console.WriteLine("10. Bai 10 - Chuoi doi xung");
                Console.WriteLine("11. Bai 11 - Dao chuoi");
                Console.WriteLine("12. Bai 12 - Chuoi thuong, hoa, dem tu");
                Console.WriteLine("13. Bai 13 - Nhap xuat sinh vien");
                Console.WriteLine("14. Bai 14 - Tinh luong nhan vien");
                Console.WriteLine("15. Bai 15 - Mang so nguyen");
                Console.WriteLine("16. Bai 16 - Sap xep mang ho ten");
                Console.WriteLine("17. Bai 17 - Mang 2 chieu ngau nhien");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon bai: ");

                string chon = Console.ReadLine();
                Console.Clear();

                switch (chon)
                {
                    case "1": BT.Bai1(); break;
                    case "2": BT.Bai2(); break;
                    case "3": BT.Bai3(); break;
                    case "4": BT.Bai4(); break;
                    case "5": BT.Bai5(); break;
                    case "6": BT.Bai6(); break;
                    case "7": BT.Bai7(); break;
                    case "8": BT.Bai8(); break;
                    case "9": BT.Bai9(); break;
                    case "10": BT.Bai10(); break;
                    case "11": BT.Bai11(); break;
                    case "12": BT.Bai12(); break;
                    case "13": BT.Bai13(); break;
                    case "14": BT.Bai14(); break;
                    case "15": BT.Bai15(); break;
                    case "16": BT.Bai16(); break;
                    case "17": BT.Bai17(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le."); break;
                }

                Console.WriteLine();
                Console.WriteLine("Nhan Enter de quay lai menu...");
                Console.ReadLine();
            }
        }
    }
}

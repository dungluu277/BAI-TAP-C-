using System;
using System.Collections.Generic;

namespace Tuan02.TH2
{
    class DaThuc
    {
        private DonThuc[] cacDonThuc; 
        public DaThuc(int bac)
        {
            cacDonThuc = new DonThuc[bac + 1];
            for (int i = 0; i <= bac; i++)
                cacDonThuc[i] = new DonThuc(0, i);
        }

        public DaThuc(DaThuc other) 
        {
            cacDonThuc = new DonThuc[other.cacDonThuc.Length];
            for (int i = 0; i < cacDonThuc.Length; i++)
                cacDonThuc[i] = new DonThuc(other.cacDonThuc[i].A, other.cacDonThuc[i].N);
        }

        public int Bac => cacDonThuc.Length - 1;

        public DonThuc this[int i]
        {
            get => cacDonThuc[i];
            set => cacDonThuc[i] = value;
        }
        public void Nhap()
        {
            for (int i = 0; i <= Bac; i++)
            {
                Console.WriteLine($"Nhap he so a{i} (cua x^{i}): ");
                double heSo = double.Parse(Console.ReadLine()!);
                cacDonThuc[i] = new DonThuc(heSo, i);
            }
        }

        public void Xuat()
        {
            Console.WriteLine("P(x) = " + ToString());
        }

        public override string ToString()
        {
            var parts = new List<string>();
            foreach (var dt in cacDonThuc)
            {
                if (dt.A == 0) continue;
                parts.Add(dt.ToString());
            }
            return parts.Count == 0 ? "0" : string.Join(" + ", parts);
        }

        public double TinhGiaTri(double x)
        {
            double tong = 0;
            foreach (var dt in cacDonThuc)
                tong += dt.TinhGiaTri(x);
            return tong;
        }
    }
}

using System;
namespace Tuan02.TH2
{
    class Person
    {
        private int id;
        private string name;
        private int yob;
        private int yod;

        public Person()
        {
            id = 0;
            name = " ";
            yob = 0;
            yod = 0;
        }
        public Person(Person p)
        {
            id = p.id;
            name = p.name;
            yob = p.yob;
            yod = p.yod;
        }
        public void Input()
        {
            Console.WriteLine("Nhap id: ");
            id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap ho ten: ");
            name = Console.ReadLine()!;
            Console.WriteLine("Nhap nam sinh: ");
            yob = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Nhap nam mat (0 neu con song): ");
            yod = int.Parse(Console.ReadLine()!);
        }

        public void Output()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Ho ten: {name}");
            Console.WriteLine($"Nam sinh: {yob}");
            if (IsLiving())
                Console.WriteLine("Tinh trang: con song");
            else
                Console.WriteLine($"Nam mat: {yod}");
        }
        public bool IsLiving()
        {
            return yod == 0;
        }
    }
}

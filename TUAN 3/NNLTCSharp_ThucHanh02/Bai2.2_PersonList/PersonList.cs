using System;
using System.Collections.Generic;

namespace Tuan02.TH2
{
        class PersonList
    {
        private List<Person> ds;

        public PersonList() { ds = new List<Person>(); }

        public PersonList(PersonList other)
        {
            ds = new List<Person>();
            foreach (var p in other.ds) ds.Add(new Person(p));
        }

        public int Count => ds.Count;

        public void Input()
        {
            Console.Write("Nhap so nguoi: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"-- Nguoi thu {i + 1} --");
                var p = new Person();
                p.Input();
                ds.Add(p);
            }
        }

        public void Output()
        {
            foreach (var p in ds)
            {
                p.Output();
                Console.WriteLine("---");
            }
        }
        public void Add(Person x) => ds.Add(x);

        public PersonList LivingPeople()
        {
            var result = new PersonList();
            foreach (var p in ds)
                if (p.IsLiving())
                    result.Add(new Person(p));
            return result;
        }
    }
}

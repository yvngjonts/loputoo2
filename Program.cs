using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisesta number");
            Console.WriteLine("1. SwitchMethod");

            int number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                SwitchMethod();
            }
            else
            {
                Console.WriteLine("vale valik");
            }

        }
        static void SwitchMethod()
            {
            Console.WriteLine("Jonne, Lõputöö");
            Console.WriteLine("1. ThenBy LINQ");
            Console.WriteLine("2. OrderBy LINQ");
            Console.WriteLine("3. Salvestamine");
            Console.WriteLine("4. NumbriPüramiid");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Tee valik numbrina");
            Console.WriteLine("--------------------------------------------");


            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ThenByLINQ();
                    break;

                case 2:
                    OrderByLINQ();
                    break;

                case 3:
                    Salvestamine();
                    break;

                case 4:
                    NumbriPüramiid();
                    break;

                default:
                    Console.WriteLine("Ei teinud valikut");
                    break;
            }
        }

        public static void ThenByLINQ()
        {

            var thenByResult = PeopleList.peoples
                .OrderBy(p => p.Name)
                .ThenBy(y => y.Age);

            Console.WriteLine("ThenBy järgi");
            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }
        public static void OrderByLINQ()
        {
            Console.WriteLine("OrderByLINQ");

            IList<Person> person = new List<Person>()
            {
                new Person() {Id = 1, Name = "Juku", Age = 10},
                new Person() {Id = 2, Name = "Juhan", Age = 11},
                new Person() {Id = 3, Name = "Maali", Age = 9},
                new Person() {Id = 4, Name = "Aksel", Age = 10},
            };

            var persons = from s in person
                          select new
                          {
                              Id = s.Id,
                              Name = s.Name,
                              Age = s.Age,
                          };

            foreach (var item in persons)
            {
                Console.WriteLine("Id on " + item.Id + " ja nimi on " + item.Name);
            }

            Console.WriteLine("LINQ Select e teine variant teha LINQ päringut");

            var result = person

                .OrderBy(p => p.Name)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age
                });

            foreach (var item in result)
            {
                Console.WriteLine("Id on " + item.Id + " ja nimi on " + item.Name);
            }

            Console.WriteLine("Kasutame GroupBy-d sorteerimiseks");

            var groupBy = person
                .GroupBy(x => x.Age);

            foreach (var item in groupBy)
            {
                Console.WriteLine("Vanuse grupp on: {0}", item.Key);
            }
        }
        public static void Salvestamine()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:/Users/Opilane/Desktop/tuttavad.txt"))
                {
                    string rida = sr.ReadToEnd();
                    string[] nimed = rida.Split('\n');
                    foreach (string name in nimed)
                    {
                        Console.WriteLine(name);
                    }

                    Array.Sort(nimed);
                    //sorteerida nimed t'hestikulises j'rjestus
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Sorteeritud....");
                    foreach (string name in nimed)
                    {
                        Console.WriteLine(name);
                    }
                    sr.Close();

                    //kirjutada kogu see info failile, mille nimi on tuttavad1

                    using (StreamWriter kirjuta = new StreamWriter("C:/Users/Ingvar/Desktop/tuttavad1.txt", true))
                    {
                        int i = 1;
                        Console.WriteLine("Sorteeritud fail nimekirja");
                        foreach (string name in nimed)
                        {
                            kirjuta.WriteLine(i + " " + name);
                            i++;
                        }
                        //kirjuta.WriteLine("");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Seda faili ei eksisteeri, palun proovige uuesti");
                Console.WriteLine(e.Message);
            }
        }
        public static void NumbriPüramiid()
        {
            int i, j, rows;
            int t = 1;
            Console.WriteLine("Numbri püramiid");
            Console.WriteLine("Sisesta ridade arv");

            rows = Convert.ToInt32(Console.ReadLine());


            for (i = 0; i <= rows; i++)
            {
                for (j = 1; j <= rows - i; j++)
                {
                    Console.Write(" ");
                }
                for (j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("{0} ", t++);
                }
                Console.Write("\n");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericApplicationCs
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = { 645.41, 37.59, 76.41, 5.31, -34.23, 1.11, 1.10, 23.46, 635.47, -876.32, 467.83, 62.25 };
            var people = new (string x, int y)[] {("Hal", 20), ("Susann", 31), ("Dwight", 19), ("Kassandra", 21), ("Lawrence", 25),
            ("Cindy", 22), ("Cory", 27), ("Mac", 19), ("Romana", 27), ("Doretha", 32), ("Danna", 20),
             ("Zara", 23), ("Rosalyn", 26), ("Risa", 24), ("Benny", 28), ("Juan", 33), ("Natalie", 25)};

            Number numbers_ = new Number(numbers);
            Tuple people_ = new Tuple(people);

            Console.WriteLine("\n\nOrder numbers in ascending order");
            PerformOperation(numbers_);


            Console.WriteLine("\n\nShort people in alphabetial order (lexicographically) per name");
            PerformOperation(people_);

            Console.WriteLine("\n\nShort people in descending order by age, were a person with the same age should\n be ordered alphabetically (lexicographically)");
            people_.Op = true;
            PerformOperation(people_);
            Console.ReadKey();
        }

        public static void PerformOperation(dynamic t)
        {
            t.ShortF();
        }
    }



    public class Number
    {
        public double[] numbers;
        public Number(double[] numbers)
        {
            this.numbers = numbers;
        }

        public void ShortF()
        {
            var m = (from d in numbers orderby d select d);
            foreach (float i in m)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    class Tuple
    {
        private (string x, int y)[] list;
        private bool op;

        public Tuple((string x, int y)[] list, bool op = false)
        {
            this.list = list;
            this.Op = op;
        }

        public bool Op { get => op; set => op = value; }

        public void ShortF()
        {
            var m = (Op ? list.OrderByDescending(d => d.y).ThenBy(d => d.x).ToList() : list.OrderBy(d => d.x).ToList());

            foreach ((string x, int y) i in m)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

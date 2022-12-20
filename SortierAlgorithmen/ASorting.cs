using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    abstract class ASorting
    {
        public abstract void Ascending();
        public abstract void Descending();
        public abstract void Zigzag();

        public virtual void PrintSortedList(List<int> numbers)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Sorted List: ");

            foreach(int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key");
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}

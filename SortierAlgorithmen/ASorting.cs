using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    abstract class ASorting
    {
        public abstract List<int> Ascending(List<int> numbers);
        public abstract List<int> Descending(List<int> numbers);
        public virtual List<int> Zigzag(List<int> ascList)
        {
            List<int> zigzagList = new List<int>();

            int min = 0;
            int max = ascList.Count - 1;

            while (max > min)
            {
                zigzagList.Add(ascList[max]);
                max--;
                zigzagList.Add(ascList[min]);
                min++;
            }

            return zigzagList;
        }
        
        public virtual void PrintSortedList(List<int> numbers)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("\nSorted List: ");

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

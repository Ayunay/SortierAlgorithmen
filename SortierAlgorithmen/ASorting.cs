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
        /// <summary>
        /// Zigzag = biggest number - smallest - 2nd biggest - 2nd smallest - 3rd biggest - 3rd smallest - ...
        /// </summary>
        /// <param name="ascList">When Calling: The unsorted List</param>
        /// <returns></returns>
        public virtual List<int> Zigzag(List<int> ascList)
        {
            List<int> zigzagList = new List<int>();

            int min = 0;
            int max = ascList.Count - 1;

            while (max > min)                   // until min and max cross each other
            {
                zigzagList.Add(ascList[max]);   // add the next biggest number
                max--;
                zigzagList.Add(ascList[min]);   // then the next smallest number
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

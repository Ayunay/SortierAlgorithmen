using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class Bubblesort : ASorting
    {
        //List<int> numbers = new List<int>();

        //public Bubblesort(List<int> numbers)
        //{
        //    this.numbers = numbers;
        //}

        public override List<int> Ascending(List<int> numbers)
        {
            int i = 0;

            while (i < numbers.Count-1)
            {
                if (numbers[i] <= numbers[i + 1]) i++;   // go ahead when numbers are in right order
                else                                    // switch the two numbers if they are in false order
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;

                    i = 0;                              // and go back to the beginning
                }
            }

            return numbers;
        }

        public override List<int> Descending(List<int> numbers)
        {
            int i = 0;

            while (i < numbers.Count - 1)
            {
                if (numbers[i] >= numbers[i + 1]) i++;   // go ahead when numbers are in right order
                else                                    // switch the two numbers if they are in false order
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;

                    i = 0;                              // and go back to the beginning
                }
            }

            return numbers;
        }

        public override List<int> Zigzag(List<int> numbers)
        {
            List<int> ascList = Ascending(numbers);

            foreach (int number in ascList)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("");

            List<int> descList = Descending(numbers);

            foreach (int number in ascList)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("");

            List<int> sortedList = numbers;

            Console.WriteLine("\n");

            foreach (int number in ascList)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("");

            foreach (int number in descList)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("");

            int j = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.Write(i % 2);
                if(i%2 == 0)                        // every even i / element
                {
                    Console.WriteLine("  " + j + "  " + descList[j] + "  " + descList[i]);
                    sortedList[i] = descList[j];    // take a number of the Descending (greater)
                }
                else if (i%2 == 1)                                // every uneven i / element
                {
                    Console.WriteLine("  " + j + "  " + ascList[j] + "  " + ascList[i]);
                    sortedList[i] = ascList[j];     // take a number of the Ascending (lower)
                    j++;
                }
            }

            return sortedList;
        }

        public override void PrintSortedList(List<int> list)
        {
            base.PrintSortedList(list);
        }
    }
}

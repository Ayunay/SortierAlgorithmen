using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    /// <summary>
    /// A left sorted side and a right unsorted side (2 Lists).
    /// The lowest/biggest element of the right side is searched and added to the left side.
    /// Continue like this until no elememt is left on the right side, then the left side should be sorted.
    /// </summary>
    internal class Selectionsort : ASorting
    {
        public override List<int> Ascending(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>();
            int numberAmount = numbers.Count;

            for(int i = 0; i < numberAmount; i++)
            {
                int index = 0;
                int value = 0;
                bool first = true;

                for (int j = 0; j < numbers.Count; j++) // goes through every element of the right side
                {
                    if (first)                          // if its the first element to compare, save the data for later use
                    {
                        index = j;
                        value = numbers[j];
                        first = false;
                    }
                    else if (numbers[j] < value)        // if the element is smaller than the others already compares, save its data
                    {
                        index = j;
                        value = numbers[j];
                    }
                }
                sortedNumbers.Add(numbers[index]);      // to insert add it to the sorted list
                numbers.RemoveAt(index);                // and remove it from the right unsorted list
            }

            return sortedNumbers;
        }

        public override List<int> Descending(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>();
            int numberAmount = numbers.Count;

            for (int i = 0; i < numberAmount; i++)
            {
                int index = 0;
                int value = 0;
                bool first = true;

                for (int j = 0; j < numbers.Count; j++) // goes through every element of the right side
                {
                    if (first)                          // if its the first element to compare, save the data for later use
                    {
                        index = j;
                        value = numbers[j];
                        first = false;
                    }
                    else if (numbers[j] > value)        // if the element is bigger than the others already compares, save its data
                    {
                        index = j;
                        value = numbers[j];
                    }
                }
                sortedNumbers.Add(numbers[index]);      // to insert add it to the sorted list
                numbers.RemoveAt(index);                // and remove it from the right unsorted list
            }


            return sortedNumbers;
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
                if (i % 2 == 0)                        // every even i / element
                {
                    Console.WriteLine("  " + j + "  " + descList[j] + "  " + descList[i]);
                    sortedList[i] = descList[j];    // take a number of the Descending (greater)
                }
                else if (i % 2 == 1)                                // every uneven i / element
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

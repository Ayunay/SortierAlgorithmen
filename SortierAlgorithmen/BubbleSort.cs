using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    /// <summary>
    /// Sort from left to right in pairs.
    /// When a pair has to be switched, then start again from the left side.
    /// its done, when it reaches the right side, because that means every pair is sorted right
    /// </summary>
    internal class Bubblesort : ASorting
    {
        public override List<int> Ascending(List<int> numbers)
        {
            int i = 0;

            while (i < numbers.Count-1)
            {
                if (numbers[i] <= numbers[i + 1]) i++;  // go ahead when numbers are in right order
                else                                    // switch the two numbers if they are in false order
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;

                    i = 0;                              // and go back to the first number in the list
                }
            }

            return numbers;
        }

        public override List<int> Descending(List<int> numbers)
        {
            int i = 0;

            while (i < numbers.Count - 1)
            {
                if (numbers[i] >= numbers[i + 1]) i++;  // go ahead when numbers are in right order
                else                                    // switch the two numbers if they are in false order
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;

                    i = 0;                              // and go back to the first number in the list
                }
            }

            return numbers;
        }

        public override List<int> Zigzag(List<int> numbers)
        {
            List<int> ascList = Ascending(numbers);
            return base.Zigzag(ascList);
        }

        public override void PrintSortedList(List<int> list)
        {
            base.PrintSortedList(list);
        }
    }
}

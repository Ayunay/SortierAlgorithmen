using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    /// <summary>
    /// A left sorted side and a right unsorted side (2 Lists).
    /// One Element from the right side is compared with all Elements of the left side to sort it in its right place.
    /// Continue like this until no elememt is left on the right side, then the left side should be sorted.
    /// </summary>
    internal class Insertionsort : ASorting
    {
        public override List<int> Ascending(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>();

            sortedNumbers.Add(numbers[0]);

            int i = 1;  //start at the second element because we just added the first
            
            while (i < numbers.Count)   // goes through every element of the right list "numbers"
            {
                int index = sortedNumbers.Count;    // set for checking if i need to insert of add an element    
                int value = sortedNumbers[0];       // set for the first comparison
                int j = 0;
                bool insert = false;

                while (j < sortedNumbers.Count)  // and compares it to every element of the left side
                {
                    if (numbers[i] < sortedNumbers[j])  // if the number on the left is smaller than the from the right
                    {
                        index = j;
                        insert = true;                  // insert it on this position

                        j = sortedNumbers.Count;
                    }
                    else j++;
                }

                // and places it into the left side (sorted)
                if(insert) sortedNumbers.Insert(index, numbers[i]);
                else sortedNumbers.Add(numbers[i]);

                i++;
            }

            return sortedNumbers;
        }

        public override List<int> Descending(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>();

            sortedNumbers.Add(numbers[0]);

            int i = 1;  //start at the second element because we just added the first

            while (i < numbers.Count)   // goes through every element of the right list "numbers"
            {
                int index = sortedNumbers.Count;    // set for checking if i need to insert of add an element    
                int value = sortedNumbers[0];       // set for the first comparison
                int j = 0;
                bool insert = false;

                while (j < sortedNumbers.Count)  // and compares it to every element of the left side
                {
                    if (numbers[i] > sortedNumbers[j])  // if the number on the left is bigger than the from the right
                    {
                        index = j;
                        insert = true;                  // insert it on this position

                        j = sortedNumbers.Count;
                    }
                    else j++;
                }

                // and places it into the left side (sorted)
                if (insert) sortedNumbers.Insert(index, numbers[i]);
                else sortedNumbers.Add(numbers[i]);

                i++;
            }

            return sortedNumbers;
        }

        /// <summary>
        /// Combines the Ascending and Descending List to a Zigzag List
        /// </summary>
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

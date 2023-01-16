using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class ChooseMethod
    {
        Outsorced outsorced = new Outsorced();

        /// <summary>
        /// The user should choose an Algorithm to sort the list
        /// </summary>
        /// <returns>Algorithm (string)</returns>
        public string ChooseAlgorithm()
        {
            string algo = "";

            Console.WriteLine("Choose the Algorithm you want to sort the list with:\n" +
                              "1. Bubblesort\n" +
                              "2. Insertionsort\n" +
                              "3. Selectionsort");

            int selection = outsorced.UserInput(3);

            switch (selection)
            {
                case 1:
                    algo = "Bubblesort";
                    break;

                case 2:
                    algo = "Insertionsort";
                    break;

                case 3:
                    algo = "Selectionsort";
                    break;
            }

            return algo;
        }

        /// <summary>
        /// The user should choose a type how to sort the list
        /// </summary>
        /// <returns>Sorting Type (string)</returns>
        public string ChooseSorting()
        {
            string sort = "";

            Console.WriteLine("Choose the way you want to sort your list:\n" +
                              "1. Ascending\n" +
                              "2. Descending\n" +
                              "3. Zigzag (e.g. 6  1  5  2  4  3)");

            int selection = outsorced.UserInput(3);

            switch (selection)
            {
                case 1:
                    sort = "Ascending";
                    break;

                case 2:
                    sort = "Descending";
                    break;

                case 3:
                    sort = "Zigzag";
                    break;
            }

            return sort;
        }

        /// <summary>
        /// Call the Method to sort the list, depending on the chosen algorithm and sorting type
        /// </summary>
        /// <param name="algorithm">The chosen algorithm</param>
        /// <param name="sorting">The chosen sorting type</param>
        /// <param name="numbers">The unsorted List with all inserted numbers</param>
        public void SortList(string algorithm, string sorting, List<int> numbers)
        {
            List<int> sortedList = new List<int>(numbers.Count);

            // which algorithm should be used?
            switch (algorithm)
            {
                case "Bubblesort":
                    Bubblesort bubble = new Bubblesort();               // create an Object from this algorithm class
                    // which sorting type should be used?
                    switch (sorting)
                    {
                        case "Ascending":
                            sortedList = bubble.Ascending(numbers);     // and call the Method of the sorting type
                            break;

                        case "Descending":
                            sortedList = bubble.Descending(numbers);
                            break;

                        case "Zigzag":
                            sortedList = bubble.Zigzag(numbers);
                            break;
                    }
                    bubble.PrintSortedList(sortedList);    // "numbers" variable irrelevant here but i need it because of virtual function
                    break;

                case "Insertionsort":
                    Insertionsort insertion = new Insertionsort();
                    switch (sorting)
                    {
                        case "Ascending":
                            sortedList = insertion.Ascending(numbers);
                            break;

                        case "Descending":
                            sortedList = insertion.Descending(numbers);
                            break;

                        case "Zigzag":
                            sortedList = insertion.Zigzag(numbers);
                            break;
                    }
                    insertion.PrintSortedList(sortedList);
                    break;

                case "Selectionsort":
                    Selectionsort selection = new Selectionsort();
                    switch (sorting)
                    {
                        case "Ascending":
                            sortedList = selection.Ascending(numbers);
                            break;

                        case "Descending":
                            sortedList = selection.Descending(numbers);
                            break;

                        case "Zigzag":
                            sortedList = selection.Zigzag(numbers);
                            break;
                    }
                    selection.PrintSortedList(sortedList);
                    break;
            }
        }
    }
}

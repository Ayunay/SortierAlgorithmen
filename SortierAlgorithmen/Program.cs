using System;

namespace SortierAlgorithmen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameFlow = true;

            while (gameFlow)
            {
                Outsorced outsorced = new Outsorced();
                
                // Menu "Do you want to play the Game or exit?"
                gameFlow = outsorced.MenuSelector();

                if (gameFlow)
                {
                    PrepareGame(outsorced);
                }
                Console.Clear();
            }
        }

        /// <summary>
        /// Preparation: Create a List and save the List, Algorithm, Sorting Type
        /// </summary>
        /// <param name="outsorced"></param>
        static private void PrepareGame(Outsorced outsorced)
        {
            Preparation prep = new Preparation();

            // Choose everything (write down a list of numbers and chose the algorithm and sorting type)
            List<int> numbers = prep.CreateList();
            string algorithm = prep.ChooseAlgorithm();
            string sorting = prep.ChooseSorting();

            // Write everything down ...
            outsorced.WriteColor(false, ConsoleColor.Blue, $"List: ");
            foreach (int number in numbers)
            {
                outsorced.WriteColor(false, ConsoleColor.Blue, $"{number} ");           // the list
            }
            outsorced.WriteColor(true, ConsoleColor.Blue, $"\nAlgorithm: {algorithm}"); // the algorithm

            outsorced.WriteColor(true, ConsoleColor.Blue, $"Sorting: {sorting}");       // the type of sorting

            Console.ReadKey();

            // Sort the List
            SortList(algorithm, sorting, numbers);
        }

        /// <summary>
        /// Call the Method to sort the list, depending on the chosen algorithm and sorting type
        /// </summary>
        /// <param name="algorithm">The chosen algorithm</param>
        /// <param name="sorting">The chosen sorting type</param>
        /// <param name="numbers">The unsorted List with all inserted numbers</param>
        static private void SortList(string algorithm, string sorting, List<int> numbers)
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
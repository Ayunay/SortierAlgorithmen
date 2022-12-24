namespace SortierAlgorithmen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Preparation prep = new Preparation();

            // Choose everything
            List<int> numbers = prep.CreateList();
            string algorithm = prep.ChooseAlgorithm();
            string sorting = prep.ChooseSorting();

            // Write everything down ...
            prep.WriteColor(false, ConsoleColor.Blue, $"List: ");
            foreach (int number in numbers)
            {
                prep.WriteColor(false, ConsoleColor.Blue, $"{number} ");           // the list
            }
            prep.WriteColor(true, ConsoleColor.Blue, $"\nAlgorithm: {algorithm}"); // the algorithm
            
            prep.WriteColor(true, ConsoleColor.Blue, $"Sorting: {sorting}");       // the type of sorting

            Console.ReadKey();

            List<int> sortedList = new List<int>(numbers.Count);

            // Sort the List
            switch (algorithm)
            {
                case "Bubblesort":
                    Bubblesort bubble = new Bubblesort();
                    switch (sorting)
                    {
                        case "Ascending":
                            sortedList = bubble.Ascending(numbers);
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

                    /*case "Insertionsort":
                        Insertionsort insertion = new Insertionsort(numbers);
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
                    bubble.PrintSortedList(sortedList);
                        break;

                    case "..":
                        Bubblesort bubble = new Bubblesort(numbers);
                        switch (sorting)
                        {
                            case "Ascending":
                                sortedList = bubble.Ascending(numbers);
                                break;

                            case "Descending":
                                sortedList = bubble.Descending(numbers);
                                break;

                            case "Zigzag":
                                sortedList = bubble.Zigzag(numbers);
                                break;
                        }
                        bubble.PrintSortedList(sortedList);
                        break;*/
            }
        }
    }
}
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
            prep.WriteColor(false, ConsoleColor.DarkGreen, $"List: ");
            foreach (int number in numbers)
            {
                prep.WriteColor(false, ConsoleColor.DarkGreen, $"{number} ");           // the list
            }
            prep.WriteColor(true, ConsoleColor.DarkGreen, $"\nAlgorithm: {algorithm}"); // the algorithm
            prep.WriteColor(true, ConsoleColor.DarkGreen, $"Sorting: {sorting}");       // the type of sorting

            // Sort the List
            switch (algorithm)
            {
                case "Bubblesort":
                    Bubblesort bubble = new Bubblesort(numbers);
                    switch (sorting)
                    {
                        case "asc":
                            bubble.Ascending();
                            break;

                        case "desc":
                            bubble.Descending();
                            break;

                        case "zig":
                            bubble.Zigzag();
                            break;
                    }
                    break;

                /*case "...":
                    Bubblesort bubble = new Bubblesort(numbers);
                    switch (sorting)
                    {
                        case "asc":
                            bubble.Ascending();
                            break;

                        case "desc":
                            bubble.Descending();
                            break;

                        case "zig":
                            bubble.Zigzag();
                            break;
                    }
                    break;

                case "..":
                    Bubblesort bubble = new Bubblesort(numbers);
                    switch (sorting)
                    {
                        case "asc":
                            bubble.Ascending();
                            break;

                        case "desc":
                            bubble.Descending();
                            break;

                        case "zig":
                            bubble.Zigzag();
                            break;
                    }
                    break;*/
            }
        }
    }
}
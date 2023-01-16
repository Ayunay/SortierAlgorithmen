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
                CreateList create = new CreateList();
                ChooseMethod choose = new ChooseMethod();

                // Menu "Do you want to play the Game or exit?"
                gameFlow = outsorced.MenuSelector();

                if (gameFlow)
                {
                    // Choose everything (create a list of numbers and chose the algorithm and sorting type)
                    List<int> numbers = create.HowToCreateList();
                    string algorithm = choose.ChooseAlgorithm();
                    string sorting = choose.ChooseSorting();

                    // Write everything down ...
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.Write($"List: ");
                    foreach (int number in numbers)
                    {
                        Console.Write($"{number} ");                // the list
                    }
                    Console.WriteLine($"\nAlgorithm: {algorithm}"); // the algorithm
                    Console.WriteLine($"Sorting: {sorting}");       // the type of sorting

                    Console.ResetColor();
                    Console.ReadKey();

                    // Sort the List
                    choose.SortList(algorithm, sorting, numbers);
                }
                Console.Clear();
            }
        }
    }
}
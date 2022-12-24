using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class Preparation
    {
        /// <summary>
        /// Does the user want to insert the list by himself or should it be created random?
        /// </summary>
        /// <returns></returns>
        public List<int> CreateList()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("1. Do you want to insert the numbers of the List by your own or...\n" +
                              "2. Do you want to create a list with random numbers?");

            int selection = UserInput(2);

            switch (selection)
            {
                case 1:
                    numbers = EnterOwnList();
                    break;

                case 2:
                    numbers = RandomizeList();
                    break;

                default:
                    numbers = CreateList();
                    break;
            }

            return numbers;
        }

        /// <summary>
        /// User create a list with his own numbers
        /// </summary>
        /// <returns></returns>
        private List<int> EnterOwnList()
        {
            List<int> numbers = new List<int>();
            string insertion = "";
            bool validInput = true;

            while(true)
            {
                Console.Clear();

                Console.WriteLine("Enter several numbers you want to sort.\n" +
                                  "If you have entered all numbers, press 'f'.\n" +
                                  "If you want to remove the last number, press 'b'.\n");

                if (!validInput)
                {
                    WriteColor(true, ConsoleColor.Red, "This is no number, please enter a number or 'f' or 'b'.\n");
                    validInput = true;
                }
                else Console.Write("\n\n");

                WriteColor(false, ConsoleColor.DarkGreen, "Your List: ");
                for (int i = 1; i <= numbers.Count; i++)                     // Prints all numbers of the List
                {
                    if(i == numbers.Count && insertion != "b") 
                        WriteColor(false, ConsoleColor.Green, $"{numbers[i-1]} ");
                    else WriteColor(false, ConsoleColor.DarkGreen, $"{numbers[i-1]} "); 
                }

                insertion = Console.ReadLine();             // User Input: number

                switch (insertion)
                {
                    case "f":
                        return numbers;                     // Return the final List            

                    case "b":
                        numbers.RemoveAt(numbers.Count-1);      // Remove the last element of the List
                        break;

                    default:
                        int intNumber;

                        if (!int.TryParse(insertion, out intNumber))
                        {
                            validInput = false;
                            break;
                        }
                        else numbers.Add(intNumber);        // Add a new element to the List

                        break;
                }
            }
        }

        #region RandomList

        /// <summary>
        /// Create a list with random nmbers instead of letting the user insert some
        /// </summary>
        /// <returns></returns>
        private List<int> RandomizeList()
        {
            Random random = new Random();
            List<int> numbers = new List<int>();
            int minList, maxList, minNumber, maxNumber, amount;

            (minList, maxList) = randomListConsole("Create a random list with an amount of numbers between ");
            amount = random.Next(minList, maxList + 1);     // how many Numbers should be randomized (min-max)
            (minNumber, maxNumber) = randomListConsole("Randomize Numbers between ");

            Console.WriteLine($"List length between {minList} and {maxList}\n" +
                              $"Numbers between {minNumber} and {maxNumber}\n");

            WriteColor(false, ConsoleColor.DarkGreen, $"List: ");

            for (int i = 0; i <= amount; i++)
            {
                int number = random.Next(minNumber, maxNumber);
                numbers.Add(number);
                WriteColor(false, ConsoleColor.DarkGreen, $"{number} ");
            }

            WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to sort the list");
            Console.ReadKey(true);
            Console.Clear();

            return numbers;
        }

        /// <summary>
        /// RandomizeList() most Console.WriteLines for a better overview
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private (int, int) randomListConsole(string text)
        {
            int min, max;

            Console.Write(text);
            WriteColor(false, ConsoleColor.Blue, "_");
            Console.WriteLine(" and _");

            min = randomNumberInput(0);

            Console.Clear();
            Console.Write(text);
            WriteColor(false, ConsoleColor.Blue, $"{min}");
            Console.Write(" and ");
            WriteColor(true, ConsoleColor.Blue, "_");

            max = randomNumberInput(min);

            Console.Clear();
            Console.Write(text);
            WriteColor(false, ConsoleColor.Blue, $"{min}");
            Console.Write(" and ");
            WriteColor(true, ConsoleColor.Blue, $"{max}\n");

            Console.ReadKey(true);
            Console.Clear();

            return (min, max);
        }

        /// <summary>
        /// Part of the RandomizeList() -- the user should say how long the list should be and which numbers can be created
        /// </summary>
        /// <param name="min"></param>
        /// <returns></returns>
        private int randomNumberInput(int min)
        {
            int number = 0;

            while(number == 0)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out number))
                    WriteColor(true, ConsoleColor.Red, "This is no number, please enter a number.");
                else if (number < min)
                {
                    WriteColor(true, ConsoleColor.Red, "The maximal amount has to be greater then the minimal amount.");
                    number = 0;      // so that we stay in the loop
                }
            }

            return number;
        }

        #endregion

        /// <summary>
        /// The user should choose an Algorithm to sort the list
        /// </summary>
        /// <returns></returns>
        public string ChooseAlgorithm()
        {
            string algo = "";

            Console.WriteLine("Choose the Algorithm you want to sort the list with:" +
                              "1. Bubblesort\n" +
                              "2. Insertionsort\n" +
                              "3. ");

            int selection = UserInput(3);

            switch (selection)
            {
                case 1:
                    algo = "Bubblesort";
                    break;

                case 2:
                    algo = "Insertionsort";
                    break;

                case 3:
                    algo = "..";
                    break;
            }

            return algo;
        }

        /// <summary>
        /// The user should choose a type how to sort the list
        /// </summary>
        /// <returns></returns>
        public string ChooseSorting()
        {
            string sort = "";

            Console.WriteLine("Choose the way you want to sort your list:" +
                              "1. Ascending\n" +
                              "2. Descending\n" +
                              "3. Zigzag (e.g. 6  1  5  2  4  3)");

            int selection = UserInput(3);

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
        /// Checks if the User input is a number and is in the given range (amount of options)
        /// </summary>
        /// <param name="options">how many options are there to choose</param>
        /// <returns></returns>
        private int UserInput(int options)
        {
            int selection = 0;
            bool validInput = false;

            while (!validInput)     // Check if a number has been entered for the choice 
            {
                char input = Console.ReadKey(true).KeyChar;

                if (!int.TryParse(input.ToString(), out selection) || selection == 0 || selection > options)
                    WriteColor(true, ConsoleColor.Red, "Please pick one option from above.");
                else validInput = true;
            }

            Console.Clear();

            return selection;
        }

        /// <summary>
        /// Console.Write in Color
        /// </summary>
        /// <param name="line">true: Console.Write or false: Console.WriteLine</param>
        /// <param name="color"></param>
        /// <param name="text"></param>
        public void WriteColor(bool line, ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            if (line == true) Console.WriteLine(text);
            else Console.Write(text);
            Console.ResetColor();
        }
    }
}

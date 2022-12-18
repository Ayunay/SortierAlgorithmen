using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class Preparation
    {
        public List<int> CreateList()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("1. Do you want to insert the numbers of the List by your own or...\n" +
                              "2. Do you want to create a list with random numbers?");

            int selection = 0;
            bool validInput = false;

            while (!validInput)     // Check if a number has been entered for the choice 
            {
                char input = Console.ReadKey(true).KeyChar;

                if (!int.TryParse(input.ToString(), out selection))
                    WriteColor(true, ConsoleColor.Red, "Please pick one option from above.");
                else validInput = true;
            }

            Console.Clear();

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

        private List<int> RandomizeList()
        {
            List<int> numbers = new List<int>();
            int min = 5;
            int max = 20;

            Console.Write("Create a random list with an amount of numbers between ");
            WriteColor(false, ConsoleColor.Blue, "_");
            Console.Write(" and _");
            min = randomNumberInput(0);

            Console.Write("Create a random list with an amount of numbers between ");
            WriteColor(false, ConsoleColor.Blue, $"{min}");
            Console.Write(" and ");
            WriteColor(false, ConsoleColor.Blue, "_");

            Console.Write("Create a random list with an amount of numbers between ");
            WriteColor(false, ConsoleColor.Blue, $"{min}");
            Console.Write(" and ");
            WriteColor(false, ConsoleColor.Blue, $"{max}");

            Console.ReadLine();



            return numbers;
        }

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

        public string ChooseAlgorithm()
        {
            string algo = "";

            return algo;
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

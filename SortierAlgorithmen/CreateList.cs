﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class CreateList
    {
        Outsorced outsorced = new Outsorced();

        /// <summary>
        /// Does the user want to insert the list by himself or should it be created random?
        /// </summary>
        /// <returns>Returns the List</returns>
        public List<int> HowToCreateList()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("1. Do you want to insert the numbers of the List by your own or...\n" +
                              "2. Do you want to create a list with random numbers?");

            int selection = outsorced.UserInput(2);

            switch (selection)
            {
                case 1:
                    numbers = EnterOwnList();
                    break;

                case 2:
                    numbers = RandomizeList();
                    break;

                default:
                    numbers = HowToCreateList();
                    break;
            }

            return numbers;
        }

        /// <summary>
        /// User creates a list with his own numbers
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

                // possible error line
                if (!validInput)
                {
                    outsorced.WriteColor(true, ConsoleColor.Red, "This is no number, please enter a number or 'f' or 'b'.\n");
                    validInput = true;
                }
                else Console.Write("\n\n");

                // "Your List: ..." is kept up to date and adds every new inserted number
                outsorced.WriteColor(false, ConsoleColor.DarkGreen, "Your List: ");
                for (int i = 1; i <= numbers.Count; i++)
                {
                    if(i == numbers.Count && insertion != "b")
                        outsorced.WriteColor(false, ConsoleColor.Green, $"{numbers[i-1]} ");      // the last inserted number
                    else outsorced.WriteColor(false, ConsoleColor.DarkGreen, $"{numbers[i-1]} "); // all other numbers
                }

                // Uder Input: number
                insertion = Console.ReadLine();

                switch (insertion)
                {
                    case "f":
                        return numbers;                     // Return the final List            

                    case "b":
                        numbers.RemoveAt(numbers.Count-1);  // Remove the last element of the List
                        break;

                    default:
                        int intNumber;

                        if (!int.TryParse(insertion, out intNumber))
                        {
                            validInput = false;
                            break;
                        }
                        else numbers.Add(intNumber);        // if its a valid input: Add a new element to the List

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

            // User Input
            (minList, maxList) = randomListConsole("Create a random list with an amount of numbers between ");
            amount = random.Next(minList, maxList + 1);     // how many Numbers should be randomized (min-max)

            (minNumber, maxNumber) = randomListConsole("Randomize Numbers between ");

            // Write everything down
            Console.WriteLine($"List length between {minList} and {maxList}\n" +
                              $"Numbers between {minNumber} and {maxNumber}\n");

            outsorced.WriteColor(false, ConsoleColor.DarkGreen, $"List: ");

            for (int i = 0; i <= amount; i++)
            {
                int number = random.Next(minNumber, maxNumber);             // randomize numbers
                numbers.Add(number);
                outsorced.WriteColor(false, ConsoleColor.DarkGreen, $"{number} ");    // and write the list down
            }

            outsorced.WriteColor(true, ConsoleColor.DarkGray, "\nPress any key to sort the list");
            Console.ReadKey(true);
            Console.Clear();

            return numbers;
        }

        /// <summary>
        /// RandomizeList() most Console.WriteLines for a better overview
        /// </summary>
        /// <param name="text"></param>
        /// <returns>(Minimum, Maximum) values</returns>
        private (int, int) randomListConsole(string text)
        {
            int min, max;

            Console.Write(text);
            outsorced.WriteColor(false, ConsoleColor.Blue, "_");
            Console.WriteLine(" and _");

            min = randomNumberInput(0);

            Console.Clear();
            Console.Write(text);
            outsorced.WriteColor(false, ConsoleColor.Blue, $"{min}");
            Console.Write(" and ");
            outsorced.WriteColor(true, ConsoleColor.Blue, "_");

            max = randomNumberInput(min);

            Console.Clear();
            Console.Write(text);
            outsorced.WriteColor(false, ConsoleColor.Blue, $"{min}");
            Console.Write(" and ");
            outsorced.WriteColor(true, ConsoleColor.Blue, $"{max}\n");

            Console.ReadKey(true);
            Console.Clear();

            return (min, max);
        }

        /// <summary>
        /// Part of the RandomizeList() -- the user should say 1. how long the list should be and 2. which numbers can be created
        /// </summary>
        /// <param name="min">What is the minimum value, because the maximum cant be smaller - when there is no minimum yet, insert 0 for avoiding negative numbers</param>
        /// <returns>Minimum or Maximum value</returns>
        private int randomNumberInput(int min)
        {
            int number = 0;

            while(number == 0)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out number))   // if its no number
                    outsorced.WriteColor(true, ConsoleColor.Red, "This is no number, please enter a number.");
                else if (number < min)                  // else if the number is smaller than the minimum
                {
                    outsorced.WriteColor(true, ConsoleColor.Red, "The maximal amount has to be greater then the minimal amount.");
                    number = 0;      // reset number so that we stay in the loop if its an invalid input
                }
            }

            return number;
        }

        #endregion
    }
}

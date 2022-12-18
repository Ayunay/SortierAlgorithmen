using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class Preparation
    {
        public List<float> numbers = new List<float>();

        public void EnterNumbers()
        {
            string insertion;

            WriteColor(true, ConsoleColor.Blue, "Enter several numbers you want to sort.");
            WriteColor(true, ConsoleColor.DarkMagenta, "If you have entered all numbers, press 'f'.");

            while(true)
            {
                insertion = Console.ReadLine();

                if (insertion == "f") return;
                else
                {
                    float number;
                    int intNumber;

                    if (!int.TryParse(insertion, out intNumber))
                    {
                        WriteColor(true, ConsoleColor.Red, "This is no number, please enter a number or press f to end the Insertion.");
                        break;
                    }
                    else number = (float)intNumber;
                }
            }
        }

        public void ChooseAlgorithm()
        {

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

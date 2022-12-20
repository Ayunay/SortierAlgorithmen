using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortierAlgorithmen
{
    internal class Bubblesort : ASorting
    {
        List<int> numbers = new List<int>();

        public Bubblesort(List<int> numbers)
        {
            this.numbers = numbers;
        }

        public override void Ascending()
        {
            base.PrintSortedList(numbers);
        }

        public override void Descending()
        {
            base.PrintSortedList(numbers);
        }

        public override void Zigzag()
        {
            base.PrintSortedList(numbers);
        }
    }
}

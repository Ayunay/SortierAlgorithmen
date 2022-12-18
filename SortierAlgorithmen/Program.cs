namespace SortierAlgorithmen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Preparation prep = new Preparation();

            List<int> numbers = prep.CreateList();

            string algorithm = prep.ChooseAlgorithm();
        }
    }
}
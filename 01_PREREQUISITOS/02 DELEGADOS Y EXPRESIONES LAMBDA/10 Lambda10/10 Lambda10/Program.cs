class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> listPairs = numbers.FindAll(n => n % 2 == 0);

        foreach (int number in listPairs)
        {
            Console.WriteLine(number);
        }
    }
}
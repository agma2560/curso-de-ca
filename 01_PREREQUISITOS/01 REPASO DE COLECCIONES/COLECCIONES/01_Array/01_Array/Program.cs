class Program
{
    static void Main(string[] args)
    {
        int[] Numebers = {1,6,3,8,5,9,7,2,4,10};

        string[] Cats = {"Persa", "Ragdoll", "Angora"};

        string[] users = new string[5];

        for (int i = 0; i < users.Length; i++)
        {
            Console.Write($"Ingresa nombre de ususario {i} :");

            var usr = Console.ReadLine();

            users[i] = usr;
        }

        foreach (var item in users)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Lista de razas de gato");

        foreach(var cat in Cats)
        { 
            Console.WriteLine(cat); 
        }

        Array.Sort(Numebers);
        Console.WriteLine("Números ordenados");
        foreach (var number in Numebers)
        {
            Console.WriteLine(number);
        }
    }
}
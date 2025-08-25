using System;
using System.Threading; // Necesario para Thread.Sleep

class Program
{
    static string OrderPizza()
    {
        Console.WriteLine("Ordenando pizza...");
        Thread.Sleep(5000);
        return "Aquí está la Pizza";
    }

    static string SetTheTable()
    {
        Console.WriteLine("Preparando la mesa... ");
        Thread.Sleep(3000); 
        return "Mesa preparada para servir pizza y comer";
    }

    static void LetsEat()
    {
        Console.WriteLine("\nDemos gracias por la pizza...");
        Console.WriteLine("Comamos ...");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("¡Vamos a cenar!");

        string pizzaStatus = OrderPizza();
        Console.WriteLine(pizzaStatus);

        string tableStatus = SetTheTable();
        Console.WriteLine(tableStatus);

        LetsEat();

        Console.WriteLine("\n¡Cena terminada!");
    }
}
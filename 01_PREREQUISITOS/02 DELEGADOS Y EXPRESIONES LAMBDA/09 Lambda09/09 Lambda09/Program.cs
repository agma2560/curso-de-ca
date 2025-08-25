using System;

class Program
{
    static void Main(string[] args)
    {
        // Func<int,int> -> recibe un int y devuelve un int
        Func<int, int> square = x => x * x;
        int number = 7;
        Console.WriteLine($"El cuadrado de {number} es: {square(number)}");

        // Func<DateTime> -> no recibe nada y devuelve un DateTime
        Func<DateTime> getNow = () => DateTime.Now;
        Console.WriteLine($"La fecha y hora actual es: {getNow()}");

        // Action<string> -> recibe un string y no devuelve nada
        Action<string> printMessage = msg => Console.WriteLine(msg);
        printMessage("Hola desde una expresión lambda con Action<string>!");
    }
}

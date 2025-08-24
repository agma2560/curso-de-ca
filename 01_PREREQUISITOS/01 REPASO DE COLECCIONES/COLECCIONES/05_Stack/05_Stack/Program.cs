public class UndoManager
{
    public static void Main(string[] args)
    {
        Stack<string> operationHistory = new Stack<string>();

        Console.WriteLine("\nEscribiendo Hola Mundo");
        operationHistory.Push("1. Escribir texto 'Hola Mundo'");
        Thread.Sleep(1000);

        Console.WriteLine("Escribiendo texto \"Hola Mundo\"'");
        operationHistory.Push("2. Texto escrito \"Hola Mundo\"");
        Thread.Sleep(1000);

        Console.WriteLine("Dibujando círculo rojo'");
        operationHistory.Push("3. Circulo dibujado en rojo");
        Thread.Sleep(1000);

        Console.WriteLine("Poniendo título en negrita");
        operationHistory.Push("4. Poner en negrita un título");
        Thread.Sleep(1000);

        Console.WriteLine($"\nOperaciones en el historial: {operationHistory.Count}");

        if (operationHistory.Count > 0)
        {
            string lastOperation = operationHistory.Peek();
            Console.WriteLine($"\nLa última operación realizada fue: '{lastOperation}' (No se ha deshecho)");
        }

        Console.WriteLine("\nDeshaciendo operaciones:");
        while (operationHistory.Count > 0)
        {
            string undoneOperation = operationHistory.Pop(); 
            Console.WriteLine($"  - Deshaciendo: '{undoneOperation}'");
            Thread.Sleep( 1000 );
        }

        Console.WriteLine("\nTodas las operaciones han sido deshechas.");
        Console.WriteLine($"Operaciones restantes en el historial: {operationHistory.Count}");

        Console.WriteLine("\nPresiona cualquier tecla para salir.");
        Console.ReadKey();
    }
}
public class PrintManager
{
    public static void Main(string[] args)
    {
        Queue<string> printQueue = new Queue<string>();

        Console.WriteLine("--- Gestor de Impresión ---");

        Console.WriteLine("\nEnviando documentos a la impresora:");
        printQueue.Enqueue("Factura.pdf");
        Thread.Sleep(1000);
        Console.WriteLine("  - 'Factura.pdf' enviada");
        
        printQueue.Enqueue("Presentacion Marketing.pptx");
        Thread.Sleep(1000);
        Console.WriteLine("  - 'Presentacion Marketing.pptx' enviada");
        
        printQueue.Enqueue("Estadisticas.xlsx");
        Console.WriteLine("  - 'Estadisticas.xlsx' enviada");
        Thread.Sleep(1000);
        Console.WriteLine("  - 'Carta.docx' enviada");

        printQueue.Enqueue("Carta.dox");
        Thread.Sleep(1000);

        Console.WriteLine($"\nDocumentos en cola: {printQueue.Count}");

        if (printQueue.Count > 0)
        {
            string nextDocument = printQueue.Peek();
            Console.WriteLine($"\nEl siguiente documento a imprimir es: '{nextDocument}' (No se ha quitado de la cola)");
        }

        Console.WriteLine("\nIniciando impresión de documentos:");
        while (printQueue.Count > 0)
        {
            string currentDocument = printQueue.Dequeue(); 
            Console.WriteLine($"  - Imprimiendo: '{currentDocument}'");
            Thread.Sleep(1000);
        }

        Console.WriteLine("\nTodos los documentos han sido impresos.");
        Console.WriteLine($"Documentos restantes en cola: {printQueue.Count}");

        Console.WriteLine("\nPresiona cualquier tecla para salir.");
        Console.ReadKey();
    }
}
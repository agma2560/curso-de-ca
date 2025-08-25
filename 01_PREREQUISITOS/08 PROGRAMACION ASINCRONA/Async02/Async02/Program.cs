using System.Diagnostics;

class Program
{
    static async Task<string> OrderPizzaAsync()
    {
        Console.WriteLine("Ordenando pizza...");
        await Task.Delay(8000);
        return "Aquí está la Pizza";
    }

    static async Task<string> SetTheTableAsync()
    {
        Console.WriteLine("Preparando la mesa...");
        await Task.Delay(4000);
        return "Mesa preparada para servir pizza y comer";
    }

    static async Task LetsEatAsync()
    {
        Console.WriteLine("Demos gracias por la pizza...");
        await Task.Delay(3000); // Pequeña pausa simulada para comer
        Console.WriteLine("Comamos ...");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("¡Vamos a cenar!");

        // --- Escenario 1: Ejecutar tareas secuencialmente (pero de forma no bloqueante) ---
        // Aunque se ejecutan de forma asíncrona, el 'await' asegura que una termine antes de que la siguiente se inicie.
        Console.WriteLine("\n---.:. TAREAS ASINCRONAS PERO SECUENCIALES .:.");

        Stopwatch stopwatchSecuencial = new Stopwatch();
        stopwatchSecuencial.Start(); 

        string pizzaStatus = await OrderPizzaAsync();
        Console.WriteLine(pizzaStatus);

        string tableStatus = await SetTheTableAsync();
        Console.WriteLine(tableStatus);

        await LetsEatAsync();
        Console.WriteLine("¡Cena terminada de forma secuencial!");

        stopwatchSecuencial.Stop(); 
        Console.WriteLine($"Tiempo total (Secuencial): {stopwatchSecuencial.Elapsed.TotalSeconds:F2} segundos"); 
        Console.WriteLine("==========================================");


        // --- Escenario 2: Ejecutar tareas en paralelo ---
        Console.WriteLine("\n---.:. TAREAS CONCURRENTES ASINCRONAS .:.");

        Stopwatch stopwatchConcurrente = new Stopwatch();
        stopwatchConcurrente.Start();

        //Task<string> orderTask = OrderPizzaAsync();
        //Task<string> setTableTask = SetTheTableAsync();
        var orderTask = OrderPizzaAsync();
        var setTableTask = SetTheTableAsync();

        // Ahora esperamos por ambas tareas. Task.WhenAll espera hasta que todas las tareas en el array hayan terminado.
        // El programa NO bloqueará por 8 segundos + 4 segundos. Solo bloqueará por el tiempo de la tarea más larga (8 segundos).
        await Task.WhenAll(orderTask, setTableTask);

        Console.WriteLine(await orderTask);
        Console.WriteLine(await setTableTask);


        await LetsEatAsync(); 
        //LetsEatAsync();
        Console.WriteLine("¡Cena terminada de forma concurrente!");

        stopwatchConcurrente.Stop(); 
        Console.WriteLine($"Tiempo total (Concurrente): {stopwatchConcurrente.Elapsed.TotalSeconds:F2} segundos"); // Muestra el tiempo
        Console.WriteLine("==========================================");
    }
}
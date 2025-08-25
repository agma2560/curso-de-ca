using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    // Estas clases están intencionalmente vacías para fines de este ejemplo. 
    // Son simplemente clases marcadoras para demostración, no contienen propiedades
    // y no tienen otro propósito.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("el café está listo");

            // Iniciar todas las tareas de cocción en paralelo inmediatamente.
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2); // Usamos el método compuesto

            // Servir el jugo de naranja mientras lo demás se cocina.
            Juice oj = PourOJ();
            Console.WriteLine("el jugo de naranja está listo");

            // --- Control de Excepciones ---
            try
            {
                var toast = await toastTask; // Aquí es donde la excepción de la tostadora se propagará
                Console.WriteLine("las tostadas están listas");
            }
            catch (InvalidOperationException ex) // Capturamos la excepción específica de la tostadora
            {
                Console.WriteLine($"Error al preparar las tostadas: {ex.Message}");
                Console.WriteLine("¡El desayuno no tendrá tostadas, la tostadora se incendió!");
                // Aquí podrías decidir si el desayuno continúa o se detiene por completo.
                // Para este ejemplo, permitimos que el resto del desayuno (huevos y tocino) continúe.
            }
            // ---

            // Continuamos esperando por el resto de las tareas, si aún no han terminado.
            // Esto demuestra que una falla en una tarea no necesariamente detiene todas las demás.
            var eggs = await eggsTask;
            Console.WriteLine("los huevos están listos");

            var bacon = await baconTask;
            Console.WriteLine("el tocino está listo");

            Console.WriteLine("¡El desayuno está listo!");
        }

        // --- Composición de Tareas ---
        // Este método combina una operación asincrónica (tostar) con operaciones sincrónicas (untar).
        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            // El 'await' aquí esperará por la tarea de ToastBreadAsync. 
            // Si ToastBreadAsync lanza una excepción, esta se propagará a MakeToastWithButterAndJamAsync,
            // y luego a Main cuando se 'await'e 'toastTask'.
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Sirviendo jugo de naranja");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Poniendo mermelada en la tostada");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Poniendo mantequilla en la tostada");

        // --- Método con Simulación de Falla ---
        // Este método simula la falla de la tostadora lanzando una excepción.
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora");
            }
            Console.WriteLine("Comenzando a tostar...");
            await Task.Delay(2000); // Espera 2 segundos
            Console.WriteLine("¡Fuego! ¡La tostada está arruinada!");
            // ¡Aquí es donde se lanza la excepción de la tostadora!
            throw new InvalidOperationException("La tostadora está en llamas");
            // Las líneas de código después de 'throw' nunca se ejecutarán.
            // await Task.Delay(1000); 
            // Console.WriteLine("Sacando las tostadas de la tostadora");
            // return new Toast(); 
        }

        // --- Métodos Asíncronos para la Cocina ---
        // Estos métodos usan Task.Delay para simular operaciones que toman tiempo.
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"poniendo {slices} rebanadas de tocino en la sartén");
            Console.WriteLine("cocinando el primer lado del tocino...");
            await Task.Delay(3000); // Espera de forma no bloqueante
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("volteando una rebanada de tocino");
            }
            Console.WriteLine("cocinando el segundo lado del tocino...");
            await Task.Delay(3000); // Espera de forma no bloqueante
            Console.WriteLine("Poner el tocino en el plato");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Calentando la sartén para huevos...");
            await Task.Delay(3000); // Espera de forma no bloqueante
            Console.WriteLine($"rompiendo {howMany} huevos");
            Console.WriteLine("cocinando los huevos...");
            await Task.Delay(3000); // Espera de forma no bloqueante
            Console.WriteLine("Poner los huevos en el plato");

            return new Egg();
        }

        // --- Métodos Síncronos Rápidos ---
        // Estas operaciones son rápidas y no necesitan asincronía.
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Sirviendo café");
            return new Coffee();
        }
    }
}
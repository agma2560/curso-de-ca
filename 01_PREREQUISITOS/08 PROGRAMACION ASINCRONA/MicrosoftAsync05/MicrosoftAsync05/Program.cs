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
        // Marcamos Main como async Task para poder usar await dentro de él.
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("el café está listo");

            // Iniciar todas las tareas de cocción en paralelo inmediatamente.
            // La tarea de las tostadas ahora es una composición de asincrónico y sincrónico.
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2); // Usamos el nuevo método compuesto

            // Servir el jugo de naranja. Esta es una operación rápida que
            // puede ejecutarse mientras los demás platos se cocinan.
            Juice oj = PourOJ();
            Console.WriteLine("el jugo de naranja está listo");

            // Ahora, esperamos los resultados de las tareas.
            // No importa en qué orden se completen las tareas subyacentes,
            // el await detendrá la ejecución de Main hasta que el resultado esté listo.
            var eggs = await eggsTask;
            Console.WriteLine("los huevos están listos");

            var bacon = await baconTask;
            Console.WriteLine("el tocino está listo");

            var toast = await toastTask; // Aquí se esperan las tostadas (con mantequilla y mermelada)
            Console.WriteLine("las tostadas están listas");

            Console.WriteLine("¡El desayuno está listo!");
        }

        // Nuevo método para componer la tarea de tostar con el trabajo sincrónico.
        // Es async Task<Toast> porque internamente usa await y devuelve un Toast.
        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number); // Aquí se realiza la parte asíncrona
            ApplyButter(toast); // Trabajo sincrónico
            ApplyJam(toast);    // Trabajo sincrónico

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

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora");
            }
            Console.WriteLine("Comenzando a tostar...");
            await Task.Delay(3000); // Esperamos de forma no bloqueante
            Console.WriteLine("Sacando las tostadas de la tostadora");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"poniendo {slices} rebanadas de tocino en la sartén");
            Console.WriteLine("cocinando el primer lado del tocino...");
            await Task.Delay(3000); // Esperamos de forma no bloqueante
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("volteando una rebanada de tocino");
            }
            Console.WriteLine("cocinando el segundo lado del tocino...");
            await Task.Delay(3000); // Esperamos de forma no bloqueante
            Console.WriteLine("Poner el tocino en el plato");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Calentando la sartén para huevos...");
            await Task.Delay(3000); // Esperamos de forma no bloqueante
            Console.WriteLine($"rompiendo {howMany} huevos");
            Console.WriteLine("cocinando los huevos...");
            await Task.Delay(3000); // Esperamos de forma no bloqueante
            Console.WriteLine("Poner los huevos en el plato");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Sirviendo café");
            return new Coffee();
        }
    }
}
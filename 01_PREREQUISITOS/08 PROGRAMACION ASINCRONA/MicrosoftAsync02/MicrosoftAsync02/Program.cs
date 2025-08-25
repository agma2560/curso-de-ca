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

            // Ahora 'await'amos las tareas que toman tiempo.
            // Los nombres de los métodos cambian a 'Async' por convención.
            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("los huevos están listos");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("el tocino está listo");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("las tostadas están listas");

            Juice oj = PourOJ();
            Console.WriteLine("el jugo de naranja está listo");
            Console.WriteLine("¡El desayuno está listo!");
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

        // Convertimos este método a async Task<Toast> y usamos Task.Delay sin .Wait()
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora");
            }
            Console.WriteLine("Comenzando a tostar...");
            await Task.Delay(3000); // Ahora esperamos de forma no bloqueante
            Console.WriteLine("Sacando las tostadas de la tostadora");

            return new Toast();
        }

        // Convertimos este método a async Task<Bacon> y usamos Task.Delay sin .Wait()
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"poniendo {slices} rebanadas de tocino en la sartén");
            Console.WriteLine("cocinando el primer lado del tocino...");
            await Task.Delay(3000); // Ahora esperamos de forma no bloqueante
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("volteando una rebanada de tocino");
            }
            Console.WriteLine("cocinando el segundo lado del tocino...");
            await Task.Delay(3000); // Ahora esperamos de forma no bloqueante
            Console.WriteLine("Poner el tocino en el plato");

            return new Bacon();
        }

        // Convertimos este método a async Task<Egg> y usamos Task.Delay sin .Wait()
        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Calentando la sartén para huevos...");
            await Task.Delay(3000); // Ahora esperamos de forma no bloqueante
            Console.WriteLine($"rompiendo {howMany} huevos");
            Console.WriteLine("cocinando los huevos...");
            await Task.Delay(3000); // Ahora esperamos de forma no bloqueante
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
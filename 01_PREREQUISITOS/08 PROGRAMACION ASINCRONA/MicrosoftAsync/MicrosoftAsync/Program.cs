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
        static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("el café está listo");

            Egg eggs = FryEggs(2);
            Console.WriteLine("los huevos están listos");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("el tocino está listo");

            Toast toast = ToastBread(2);
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

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora");
            }
            Console.WriteLine("Comenzando a tostar...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Sacando las tostadas de la tostadora");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"poniendo {slices} rebanadas de tocino en la sartén");
            Console.WriteLine("cocinando el primer lado del tocino...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("volteando una rebanada de tocino");
            }
            Console.WriteLine("cocinando el segundo lado del tocino...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Poner el tocino en el plato");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Calentando la sartén para huevos...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"rompiendo {howMany} huevos");
            Console.WriteLine("cocinando los huevos...");
            Task.Delay(3000).Wait();
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

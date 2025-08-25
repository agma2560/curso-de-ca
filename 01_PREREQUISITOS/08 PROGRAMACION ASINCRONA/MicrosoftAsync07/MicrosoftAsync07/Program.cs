using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    // Estas clases están intencionalmente vacías para este ejemplo.
    // Son simplemente clases marcadoras para demostración, no contienen propiedades
    // y no tienen ningún otro propósito.
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
            Console.WriteLine("el café está listo"); // Mensaje traducido

            // Iniciar todas las tareas de cocción en paralelo.
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            // Crear una lista de tareas de desayuno para monitorear su finalización.
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

            // Mientras haya tareas pendientes en la lista...
            while (breakfastTasks.Count > 0)
            {
                // Esperar a que se complete cualquiera de las tareas.
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                // Comprobar qué tarea ha terminado y mostrar el mensaje correspondiente.
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("los huevos están listos"); // Mensaje traducido
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("el tocino está listo"); // Mensaje traducido
                }
                else if (finishedTask == toastTask)
                {
                    // Nota: 'finishedTask' es un Task<Toast>, pero aquí se compara con Task.
                    // Para obtener el resultado o propagar excepciones del Task<TResult>,
                    // aún es necesario 'await'arlo explícitamente más abajo.
                    Console.WriteLine("las tostadas están listas"); // Mensaje traducido
                }

                // Esperar explícitamente la tarea terminada para manejar posibles excepciones
                // y para asegurar que el resultado se "obtenga" (aunque no se use aquí directamente).
                await finishedTask;

                // Eliminar la tarea completada de la lista.
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("el jugo de naranja está listo"); // Mensaje traducido
            Console.WriteLine("¡El desayuno está listo!"); // Mensaje traducido
        }

        // Método para componer la tarea de tostar con la adición de mantequilla y mermelada.
        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            // Tostar el pan de forma asíncrona.
            var toast = await ToastBreadAsync(number);
            // Aplicar mantequilla (operación sincrónica).
            ApplyButter(toast);
            // Aplicar mermelada (operación sincrónica).
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Sirviendo jugo de naranja"); // Mensaje traducido
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Poniendo mermelada en la tostada"); // Mensaje traducido

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Poniendo mantequilla en la tostada"); // Mensaje traducido

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rebanada de pan en la tostadora"); // Mensaje traducido
            }
            Console.WriteLine("Comenzando a tostar..."); // Mensaje traducido
            await Task.Delay(3000);
            Console.WriteLine("Sacando las tostadas de la tostadora"); // Mensaje traducido

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"poniendo {slices} rebanadas de tocino en la sartén"); // Mensaje traducido
            Console.WriteLine("cocinando el primer lado del tocino..."); // Mensaje traducido
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("volteando una rebanada de tocino"); // Mensaje traducido
            }
            Console.WriteLine("cocinando el segundo lado del tocino..."); // Mensaje traducido
            await Task.Delay(3000);
            Console.WriteLine("Poner el tocino en el plato"); // Mensaje traducido

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Calentando la sartén para huevos..."); // Mensaje traducido
            await Task.Delay(3000);
            Console.WriteLine($"rompiendo {howMany} huevos"); // Mensaje traducido
            Console.WriteLine("cocinando los huevos ..."); // Mensaje traducido
            await Task.Delay(3000);
            Console.WriteLine("Poner los huevos en el plato"); // Mensaje traducido

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Sirviendo café"); // Mensaje traducido
            return new Coffee();
        }
    }
}
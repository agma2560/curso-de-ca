public class TaskManager
{
    static void Main(string[] args)
    {
        List<string> tasks = new List<string>();
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear(); 
            Console.WriteLine(".: Menú de Tareas Pendientes :.");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Agregar una nueva tarea");
            Console.WriteLine("2. Listar todas las tareas");
            Console.WriteLine("3. Marcar tarea como completada"); 
            Console.WriteLine("4. Salir del programa");
            Console.Write("\nElige una opción: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("\n¡Entrada no válida! Por favor, ingresa un número del 1 al 4.");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                continue; 
            }

            Console.WriteLine(); 

            switch (choice)
            {
                case 1:
                    AddTask(tasks);
                    break;
                case 2:
                    ListTasks(tasks);
                    break;
                case 3:
                    RemoveTask(tasks);
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa. ¡Hasta pronto!");
                    break;
                default: 
                    Console.WriteLine("¡Opción no reconocida! Por favor, elige un número del 1 al 4.");
                    break;
            }

            if (choice != 4)
            {
                Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                Console.ReadKey();
            }
        }
    }

    private static void AddTask(List<string> tasks)
    {
        Console.WriteLine("--- Agregar Nueva Tarea ---");
        Console.Write("Escribe el nombre de la tarea: ");
        string task = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task.Trim());
            Console.WriteLine($"Tarea '{task.Trim()}' agregada con éxito.");
        }
        else
        {
            Console.WriteLine("El nombre de la tarea no puede estar vacío.");
        }
    }

    private static void ListTasks(List<string> tasks)
    {
        Console.WriteLine("--- Tareas Pendientes ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No hay tareas pendientes en la lista.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    private static void RemoveTask(List<string> tasks)
    {
        Console.WriteLine("--- Marcar Tarea Como Completada ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No hay tareas para marcar como completadas.");
            return;
        }

        ListTasks(tasks);

        while (true)
        {
            Console.Write($"\nIngresa el número de la tarea a marcar como completada (0 para cancelar): ");
            int choiceIndex;

            if (!int.TryParse(Console.ReadLine(), out choiceIndex))
            {
                Console.WriteLine("¡Entrada inválida! Por favor, ingresa un número.");
                continue; 
            }

            if (choiceIndex == 0)
            {
                Console.WriteLine("Operación cancelada.");
                break;
            }

            int taskToRemoveIndex = choiceIndex - 1;

            if (taskToRemoveIndex >= 0 && taskToRemoveIndex < tasks.Count)
            {
                string removedTask = tasks[taskToRemoveIndex]; 
                tasks.RemoveAt(taskToRemoveIndex);
                Console.WriteLine($"Tarea '{removedTask}' marcada como completada y eliminada.");
                break; 
            }
            else
            {
                Console.WriteLine("Número de tarea fuera de rango. Por favor, intenta de nuevo.");
            }
        }
    }
}
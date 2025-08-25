// Solo aceptamos tipos que sean clases y que implementen una interfaz ILogger
// T debe ser una clase, implementar ILogger, y tener un constructor sin parámetros
public class Procesador<T> where T : class, ILogger, new() 
{
    public void Procesar(T item)
    {
        // Como sabemos que T es ILogger, podemos llamar a sus métodos
        item.Log("Procesando un elemento");
        // Como sabemos que T tiene un constructor sin parámetros, podemos crear una nueva instancia
        T nuevaInstancia = new T();
    }
}

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Generando Log en archivo {message}");
    }
}


// Ejemplo de uso
public class ConstraintExample
{
    public static void Main(string[] args)
    {
        Procesador<ConsoleLogger> procesador = new Procesador<ConsoleLogger>();
        procesador.Procesar(new ConsoleLogger());

        Procesador<FileLogger> file = new Procesador<FileLogger>();
        file.Procesar(new FileLogger());


        // Esto NO compilaría porque 'int' no es una clase, ni implementa ILogger, ni tiene un ctor sin parámetros
        //Procesador<int> otroProcesador = new Procesador<int>();
    }
}
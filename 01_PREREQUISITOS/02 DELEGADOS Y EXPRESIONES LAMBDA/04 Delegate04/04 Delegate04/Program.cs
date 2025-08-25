using System;

class Program
{
    static void Main()
    {
        // Action sin parámetros: registra inicio
        Action registrarInicio = () =>
        {
            Console.WriteLine($"[{DateTime.Now}] - Inicio del proceso");
            Thread.Sleep(1500);
        };

        // Action<string>: registra mensajes personalizados
        Action<string> registrarMensaje = mensaje =>
        {
            Console.WriteLine($"[{DateTime.Now}] - {mensaje}");
            Thread.Sleep(1500);
        };

        registrarInicio();
        registrarMensaje("Conectando a la base de datos...");
        registrarMensaje("Consulta ejecutada con éxito");
        registrarMensaje("Proceso finalizado");
    }
}

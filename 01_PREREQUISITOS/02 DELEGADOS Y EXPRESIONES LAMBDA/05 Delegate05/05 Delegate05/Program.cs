using System;
using System.Collections.Generic;

public class Notificador
{
    // Lista de acciones que se ejecutarán cuando haya una notificación
    private List<Action<string>> accionesNotificacion = new List<Action<string>>();

    public void Suscribir(Action<string> accion)
    {
        accionesNotificacion.Add(accion);
    }

    public void Notificar(string mensaje)
    {
        foreach (var accion in accionesNotificacion)
        {
            accion(mensaje); // Ejecuta cada acción suscrita
        }
    }
}

class Program
{
    static void Main()
    {
        Notificador notificador = new Notificador();

        // Suscribir diferentes acciones
        notificador.Suscribir(m => Console.WriteLine($"[LOG] {m}"));
        notificador.Suscribir(m => EnviarCorreo(m));
        notificador.Suscribir(m => MostrarEnPantalla(m));

        // Ejecutar notificación
        notificador.Notificar("Factura #125 generada y lista para envío.");
    }

    static void EnviarCorreo(string mensaje)
    {
        Console.WriteLine($"Correo enviado: {mensaje}");
    }

    static void MostrarEnPantalla(string mensaje)
    {
        Console.WriteLine($"Pantalla: {mensaje}");
    }
}

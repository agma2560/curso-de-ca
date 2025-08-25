using System.Diagnostics;
class Program
{
    public delegate void Notificacion();
    
    public class Proceso
    {
        public event Notificacion? ProcesoFinalizado;

        public void Ejecutar()
        {
            Console.WriteLine("Ejecutando...");
            ProcesoFinalizado?.Invoke();
        }
    }

    static void Main(string[] args)
    {
        Proceso p = new Proceso();
        p.ProcesoFinalizado += () => Console.WriteLine("Proceso terminado");
        p.ProcesoFinalizado += () => Console.WriteLine("=== FIN ===");
        p.Ejecutar();

    }
}

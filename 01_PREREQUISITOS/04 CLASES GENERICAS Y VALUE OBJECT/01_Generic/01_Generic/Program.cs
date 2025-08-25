public class Caja<T> // La 'T' es el parámetro de tipo. Puede ser cualquier letra, pero 'T' es la convención.
{
    public T Contenido { get; set; } // La propiedad 'Contenido' es del tipo 'T'

    public Caja(T contenido) // El constructor también usa 'T'
    {
        Contenido = contenido;
    }

    public void MostrarContenido()
    {
        Console.WriteLine($"La caja contiene: {Contenido} (Tipo: {Contenido.GetType().Name})");
    }
}

public class EjemploGenerico
{
    public static void Main(string[] args)
    {
        // Crear una instancia de Caja para un entero (T se convierte en int)
        Caja<int> cajaDeNumero = new Caja<int>(123);
        cajaDeNumero.MostrarContenido(); // Salida: La caja contiene: 123 (Tipo: Int32)

        // Crear una instancia de Caja para una cadena (T se convierte en string)
        Caja<string> cajaDeTexto = new Caja<string>("Mi Mensaje Secreto");
        cajaDeTexto.MostrarContenido(); // Salida: La caja contiene: Mi Mensaje Secreto (Tipo: String)

        // Crear una instancia de Caja para un booleano (T se convierte en bool)
        Caja<bool> cajaDeBooleano = new Caja<bool>(true);
        cajaDeBooleano.MostrarContenido(); // Salida: La caja contiene: True (Tipo: Boolean)

         // Acceso directo al contenido (sin casting necesario)
        int numeroExtraido = cajaDeNumero.Contenido;
        string textoExtraido = cajaDeTexto.Contenido;

        Console.WriteLine($"\nNumero extraído: {numeroExtraido}");
        Console.WriteLine($"Texto extraído: {textoExtraido}");
    }
} 
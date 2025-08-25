using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        // Definir cultura colombiana
        CultureInfo culturaCOP = new CultureInfo("es-CO");

        // Un Func que recibe un decimal (precio) y retorna un decimal (precio con IVA)
        Func<decimal, decimal> calcularIVA = precio => precio * 1.19m;

        // Un Func que recibe precio y descuento y retorna el precio final
        Func<decimal, decimal, decimal> aplicarDescuento = (precio, descuento) => precio - (precio * descuento / 100);

        decimal precioBase = 100000m;

        // Aplicar IVA
        decimal precioConIVA = calcularIVA(precioBase);
        Console.WriteLine($"Precio con IVA: {precioConIVA.ToString("C", culturaCOP)}");

        // Aplicar descuento del 10% al precio con IVA
        decimal precioFinal = aplicarDescuento(precioConIVA, 10);
        Console.WriteLine($"Precio final con descuento: {precioFinal.ToString("C", culturaCOP)}");
    }
}


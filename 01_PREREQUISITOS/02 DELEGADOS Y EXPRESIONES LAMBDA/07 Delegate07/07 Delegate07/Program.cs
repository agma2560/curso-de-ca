using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo copCulture = new CultureInfo("es-CO");

        // Lista de product prices
        List<decimal> productPrices = new List<decimal> { 50000m, 150000m, 300000m, 80000m, 120000m };

        // Predicate: check if the price > 100.000
        Predicate<decimal> isExpensive = price => price > 100000m;

        Console.WriteLine("=== Lista de precios ===");
        foreach (var price in productPrices)
        {
            Console.WriteLine(price.ToString("C0", copCulture));
        }

        Console.WriteLine("\n=== Filtrando precios caros (mayores a $100.000) ===");
        List<decimal> expensivePrices = productPrices.FindAll(isExpensive);

        foreach (var price in expensivePrices)
        {
            Console.WriteLine(price.ToString("C0", copCulture));
        }
    }
}

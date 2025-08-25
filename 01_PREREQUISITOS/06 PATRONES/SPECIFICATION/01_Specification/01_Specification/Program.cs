using _01_Specification;

public class Program
{
    public static void Main(string[] args)
    {
        // Crear algunos datos de ejemplo
        var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Alice", IsPremium = true, RegistrationDate = new DateTime(2023, 1, 1) },
            new Customer { Id = 2, Name = "Bob", IsPremium = false, RegistrationDate = new DateTime(2024, 6, 15) },
            new Customer { Id = 3, Name = "Charlie", IsPremium = true, RegistrationDate = new DateTime(2022, 11, 20) }
        };

        var products = new List<Product>
        {
            new Product { Id = 101, Name = "Laptop", Price = 1200, DiscountPercentage = 0, Stock = 50 },
            new Product { Id = 102, Name = "Mouse", Price = 25, DiscountPercentage = 0.10m, Stock = 100 },
            new Product { Id = 103, Name = "Keyboard", Price = 75, DiscountPercentage = 0.20m, Stock = 0 },
            new Product { Id = 104, Name = "Monitor", Price = 300, DiscountPercentage = 0, Stock = 30 }
        };

        // --- Uso de Especificaciones de Cliente ---
        Console.WriteLine("--- Clientes ---");
        var isPremium = new IsPremiumCustomerSpecification();

        Console.WriteLine("Clientes Premium:");
        foreach (var customer in customers.Where(c => isPremium.IsSatisfiedBy(c)))
        {
            Console.WriteLine($"- {customer.Name} (Premium: {customer.IsPremium})");
        }

        // Ejemplo de una especificación combinada para clientes
        // Clientes premium registrados antes de 2024
        var registeredBefore2024 = new RegisteredBeforeDateSpecification(new DateTime(2024, 1, 1));
        var premiumAndOldCustomer = (registeredBefore2024 as CompositeSpecification<Customer>).And(isPremium);

        Console.WriteLine("\nClientes Premium registrados antes de 2024:");
        foreach (var customer in customers.Where(c => premiumAndOldCustomer.IsSatisfiedBy(c)))
        {
            Console.WriteLine($"- {customer.Name} (Premium: {customer.IsPremium}, Reg: {customer.RegistrationDate.ToShortDateString()})");
        }


        // --- Uso de Especificaciones de Producto ---
        Console.WriteLine("\n--- Productos ---");
        var isOnSale = new IsOnSaleProductSpecification();
        var isInStock = new IsInStockProductSpecification(); 

        Console.WriteLine("Productos en Oferta:");
        foreach (var product in products.Where(p => isOnSale.IsSatisfiedBy(p)))
        {
            Console.WriteLine($"- {product.Name} (Oferta: {product.DiscountPercentage:P0})");
        }

        var onSaleAndInStock = (isOnSale as CompositeSpecification<Product>).And(isInStock);

        Console.WriteLine("\nProductos en Oferta Y en Stock:");
        foreach (var product in products.Where(p => onSaleAndInStock.IsSatisfiedBy(p)))
        {
            Console.WriteLine($"- {product.Name} (Oferta: {product.DiscountPercentage:P0}, Stock: {product.Stock})");
        }
    }
}
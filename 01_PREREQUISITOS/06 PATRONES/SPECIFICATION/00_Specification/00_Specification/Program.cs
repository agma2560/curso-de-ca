using _00_Specification;

public class Program
{
    public static void Main(string[] args)
    {
        var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Juan", IsPremium = false, RegistrationDate = new DateTime(2021,1,1) },
            new Customer { Id = 1, Name = "Ana", IsPremium = true, RegistrationDate = new DateTime(2023,1,1) },
            new Customer { Id = 1, Name = "Maria", IsPremium = false, RegistrationDate = new DateTime(2024,1,1) },
            new Customer { Id = 1, Name = "Jose", IsPremium = true, RegistrationDate = new DateTime(2023,1,1) }
        };

        var IsPremium = new IsPremumCustomerSpecification();

        foreach (var customer in customers.Where(c => IsPremium.IsSatisfiedBy(c)))
        {
            Console.WriteLine($"El cliente {customer.Name} es especial");
        }

        foreach (var customer in customers.Where(c => !IsPremium.IsSatisfiedBy(c)))
        {
            Console.WriteLine($"El cliente {customer.Name} nada que ver");
        }

        var RegsiteredBefore2024 = new RegisteredBeforeDateSpecification
            (
            new DateTime(2024, 1, 1)
            );

        foreach (var customer in customers.Where(c=> RegsiteredBefore2024.IsSatisfiedBy(c)))
        {
            Console.WriteLine($"El cliente {customer.Name} lo tengo antes del 2024");
        }
    }
}
using _08_Delegate08;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        CultureInfo copCulture = new CultureInfo("es-CO");

        const decimal TRANSPORT_ALLOWANCE_LIMIT = 2847000m;

        // Lista de empleados
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Carlos Pérez", Salary = 2500000m },
            new Employee { Id = 2, Name = "Ana Gómez",   Salary = 3200000m },
            new Employee { Id = 3, Name = "Luis Torres", Salary = 2800000m },
            new Employee { Id = 4, Name = "María Díaz",  Salary = 4000000m }
        };

        // Predicate para verificar derecho al auxilio de transporte
        Predicate<Employee> hasTransportAllowance = emp => emp.Salary <= TRANSPORT_ALLOWANCE_LIMIT;

        Console.WriteLine("=== Empleados con derecho a auxilio de transporte ===");
        List<Employee> eligibleEmployees = employees.FindAll(hasTransportAllowance);

        foreach (Employee emp in eligibleEmployees)
        {
            Console.WriteLine($"Nombre: {emp.Name}, Salario: {emp.Salary.ToString("C0", copCulture)}");
        }
    }
}
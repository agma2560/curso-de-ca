namespace _04_Generic
{
    // Empleado de tiempo completo
    public class FullTimeEmployee : EmployeeBase, ICalculateBonus
    {
        public decimal Salary { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Empleado de tiempo Completo] ID: {Id}, Nombre: {Name}, Salario: {Salary:C}");
        }

        public decimal CalculateBonus()
        {
            return Salary * 0.10m;
        }
    }
}

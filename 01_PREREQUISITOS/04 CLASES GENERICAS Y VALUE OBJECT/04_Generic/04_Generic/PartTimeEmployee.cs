namespace _04_Generic
{
    // Empleado de medio tiempo
    public class PartTimeEmployee : EmployeeBase, ICalculateBonus
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Empleado de medio tiempo] ID: {Id}, Nombre: {Name}, Horas: {HoursWorked}, Tarifa: {HourlyRate:C}");
        }

        public decimal CalculateBonus()
        {
            return HourlyRate * HoursWorked * 0.05m;
        }
    }
}

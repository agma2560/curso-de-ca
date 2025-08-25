namespace _04_Generic
{
    // Clase base para todos los empleados
    public abstract class EmployeeBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public abstract void DisplayInfo();
    }
}

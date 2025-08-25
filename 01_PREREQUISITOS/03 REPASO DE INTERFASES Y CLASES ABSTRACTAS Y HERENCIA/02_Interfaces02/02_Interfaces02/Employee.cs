namespace _02_Interfaces02
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Empleado: {Id} - {Name}";
        }
    }
}

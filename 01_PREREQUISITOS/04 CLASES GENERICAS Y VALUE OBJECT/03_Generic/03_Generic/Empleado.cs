namespace _03_Generic
{
    public  class Empleado
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Salary { get; set; }

        public Empleado(int id, string name, double salary) 
        { 
            Id = id;
            Name = name;
            Salary = salary;
        }
    }
}

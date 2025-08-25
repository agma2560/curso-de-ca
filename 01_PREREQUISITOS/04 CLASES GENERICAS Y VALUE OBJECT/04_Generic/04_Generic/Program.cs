namespace _04_Generic
{
    class Program
    {
        static void Main()
        {
            var repo = new EmployeeRepository<FullTimeEmployee>();

            var fullTime = new FullTimeEmployee
            {
                Id = 1,
                Name = "Juan Perez",
                Salary = 3000m
            };

            var partTime = new PartTimeEmployee
            {
                Id = 2,
                Name = "Maria Lopez",
                HourlyRate = 50000m,
                HoursWorked = 80
            };

            // Repositorio de tiempo completo
            repo.Add(fullTime);

            // Repositorio de medio tiempo
            var repo2 = new EmployeeRepository<PartTimeEmployee>();
            repo2.Add(partTime);

            // Mostrar
            repo.DisplayAll();
            repo2.DisplayAll();
        }
    }
}

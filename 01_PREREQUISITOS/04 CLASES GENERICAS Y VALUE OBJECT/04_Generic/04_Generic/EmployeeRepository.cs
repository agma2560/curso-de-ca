namespace _04_Generic
{
    /*
     * Repositorio genérico con restricciones
     * 
     */
    // EmployeeBase: T debe heredar(o ser) de la clase base EmployeeBase.
    //      Esto garantiza que T tenga al menos las propiedades y métodos definidos en EmployeeBase(por ejemplo, Id, Name).
    // ICalculateBonus: T debe implementar la interfaz ICalculateBonus.
    //      Esto asegura que T tenga el método CalculateBonus().
    // new (): T debe tener un constructor público sin parámetros.
    //      Esto permite que dentro del repositorio se pueda hacer new T() para crear instancias dinámicamente.

    public class EmployeeRepository<T> where T : EmployeeBase, ICalculateBonus, new()
    {
        private List<T> employees = new List<T>();

        public void Add(T employee)
        {
            employees.Add(employee);
            Console.WriteLine($"Empleado {employee.Name} agregado al repositorio.");
        }

        public void DisplayAll()
        {
            Console.WriteLine("\n--- Lista de Empleados ---");
            foreach (var emp in employees)
            {
                emp.DisplayInfo();
                Console.WriteLine($"Bono: {emp.CalculateBonus():C}");
            }
        }
    }
}

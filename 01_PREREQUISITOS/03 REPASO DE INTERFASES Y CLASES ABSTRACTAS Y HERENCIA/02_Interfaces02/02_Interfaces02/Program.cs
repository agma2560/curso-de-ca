using _02_Interfaces02;

public class Program
{
    public static void Main(string[] args)
    {
        IRepository<Employee> db = new DBRepository<Employee>();

        Employee employee1 = new Employee { Id = 1, Name = "Juancho Lopez"};
        Employee employee2 = new Employee { Id = 2, Name = "Jacob Martinez"};
        Employee employee3 = new Employee { Id = 3, Name = "Juli Martinez"};

        db.Add(employee1);
        db.Add(employee2);
        db.Add(employee3);

        foreach (var employee in db.GetAll())
        {
            Console.WriteLine(employee);
        }
    }

}
using Jwt.Models;

namespace Jwt.Constants
{
    public class ListEmployee
    {
        public static readonly List<Employee> listEmployees = new List<Employee>()
        {
            new Employee {FirstName = "Julieta", LastName = "Martinez", Email = "juli@gmail.com"},
            new Employee {FirstName = "Jacob", LastName = "Martinez", Email = "jaco@gmail.com"},
            new Employee {FirstName = "Ivan", LastName = "Martinez", Email = "ivan@gmail.com"},
            new Employee {FirstName = "Anibal", LastName = "Martinez", Email = "anibal@gmail.com"}
        };
    }
}

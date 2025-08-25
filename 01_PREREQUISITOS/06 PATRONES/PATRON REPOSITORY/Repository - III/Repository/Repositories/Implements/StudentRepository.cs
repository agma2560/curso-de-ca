using Repository.Data;
using Repository.Models;

namespace Repository.Repositories.Implements
{
    public class StudentRepository : GenericRepopsitory<Student>, IStudentRepository
    {

        public StudentRepository(SchoolContext schoolContext) : base(schoolContext) { }
    }
}

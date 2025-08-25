using Repository.Models;
using Repository.Repositories;

namespace Repository.Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository) 
        { 
            this.studentRepository = studentRepository;
        }
    }
}

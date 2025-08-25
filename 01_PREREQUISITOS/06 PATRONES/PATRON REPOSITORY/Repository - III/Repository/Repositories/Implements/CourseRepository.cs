using Repository.Data;
using Repository.Models;

namespace Repository.Repositories.Implements
{
    public class CourseRepository : GenericRepopsitory<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext schoolContext) : base(schoolContext) 
        { 
        }
    }
}

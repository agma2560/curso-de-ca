using Repository.Models;
using Repository.Repositories;

namespace Repository.Services.Implements
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository) : base(courseRepository) 
        {
            this.courseRepository = courseRepository;
        }
    }
}

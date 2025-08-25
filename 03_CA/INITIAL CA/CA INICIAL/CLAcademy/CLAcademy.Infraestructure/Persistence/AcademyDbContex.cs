using Microsoft.EntityFrameworkCore;
using CLAcademy.Domain.Entities;

namespace CLAcademy.Infrastructure.Persistence
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

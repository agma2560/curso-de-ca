using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Repository.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}

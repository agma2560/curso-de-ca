namespace CLAcademy.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}

namespace Repository.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstMidName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
    }
}

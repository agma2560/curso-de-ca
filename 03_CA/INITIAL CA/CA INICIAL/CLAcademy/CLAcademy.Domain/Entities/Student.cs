using CLAcademy.Domain.Enums;

namespace CLAcademy.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public StratumType Stratum { get; set; }
    }
}

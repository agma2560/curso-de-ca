using CLAcademy.Domain.Enums;

namespace CLAcademy.Application.DTOs
{
    public class CreateStudentDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public StratumType Stratum { get; set; }
    }
}

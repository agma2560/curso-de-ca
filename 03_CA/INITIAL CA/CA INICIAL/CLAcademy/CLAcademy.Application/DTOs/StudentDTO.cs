using CLAcademy.Domain.Enums;

namespace CLAcademy.Application.DTOs
{
    public class StudentDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public StratumType Stratum { get; set; }
    }
}

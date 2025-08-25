using CLAcademy.Application.DTOs;
using CLAcademy.Domain.Enums;
using System.Text.RegularExpressions;

namespace CLAcademy.Application.Validators
{
    public class CreateStudentValidator
    {
        public static List<string> Validate(CreateStudentDTO dto)
        {
            var errors = new List<string>();

            if(string.IsNullOrWhiteSpace(dto.FirstName) )
                 errors.Add("Nombre obligatorio.");
            

            if(string.IsNullOrWhiteSpace(dto.LastName) )
                errors.Add("Apellido obligatorio.");
            

            if (!string.IsNullOrWhiteSpace(dto.Email) &&
                !Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add($"Email {dto.Email} no válido.");


            if(!Enum.IsDefined(typeof(StratumType), dto.Stratum))
                errors.Add($"El estrato {dto.Stratum} no existe.");

            return errors;
        }
    }
}

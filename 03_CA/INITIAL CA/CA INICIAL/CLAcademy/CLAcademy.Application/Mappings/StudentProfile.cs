using AutoMapper;
using CLAcademy.Application.DTOs;
using CLAcademy.Domain.Entities;

namespace CLAcademy.Application.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Mapeo de Student a StudentDTO
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Mapeo inverso si lo deseas más adelante
            CreateMap<CreateStudentDTO, Student>();
        }
    }
}

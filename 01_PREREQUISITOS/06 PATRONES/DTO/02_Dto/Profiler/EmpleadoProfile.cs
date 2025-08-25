using _01_Dto.DTOs;
using _01_Dto.Models;
using AutoMapper;

namespace _01_Dto.Profiler
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(d => d.Cargo, o => o.MapFrom(s => s.Role));
        }
    }
}

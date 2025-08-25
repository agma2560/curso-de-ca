using _01_Dto.DTOs;
using _01_Dto.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _01_Dto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public EmpleadoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<EmpleadoDTO>> ObtenerEmpleado()
        {
            // Simulación de entidad (como si viniera de la base de datos)
            var empleados = new List<Empleado>
            {
                new Empleado
                {
                    Id = 1,
                    FullName = "Carlos Pérez",
                    Role = "Gerente de Proyectos",
                    Salary = 9500000
                },
                new Empleado
                {
                    Id = 2,
                    FullName = "Aníbal Martínez",
                    Role = "CEO",
                    Salary = 35000000
                },
                new Empleado
                {
                    Id = 3,
                    FullName = "José Lopez",
                    Role = "Ing. de Mantenimiento",
                    Salary = 8500000
                }
            };

            // Mapeamos a DTO
            var listaDto = _mapper.Map<List<EmpleadoDTO>>(empleados);

            return Ok(listaDto);
        }
    }
}

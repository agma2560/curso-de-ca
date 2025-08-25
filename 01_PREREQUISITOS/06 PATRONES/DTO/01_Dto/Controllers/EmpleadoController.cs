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
        public ActionResult<EmpleadoDTO> ObtenerEmpleado()
        {
            // Simulación de entidad (como si viniera de la base de datos)
            var empleado = new Empleado
            {
                Id = 1,
                FullName = "Carlos Pérez",
                Role = "Gerente de Proyectos",
                Salary = 9500000
            };

            // Mapeamos a DTO
            var dto = _mapper.Map<EmpleadoDTO>(empleado);

            return Ok(dto);
        }
    }
}

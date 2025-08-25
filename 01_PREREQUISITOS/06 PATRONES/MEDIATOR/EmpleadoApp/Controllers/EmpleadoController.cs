using EmpleadoApp.Features.Empleados.Commands;
using EmpleadoApp.Features.Empleados.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] CrearEmpleadoCommand command)
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            var empleados = await _mediator.Send(new ObtenerEmpleadosQuery());
            return Ok(empleados);
        }
    }
}

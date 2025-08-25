using EmpleadoApp.Features.Empleados.Queries;
using MediatR;

namespace EmpleadoApp.Features.Empleados.Handlers
{
    public class ObtenerEmpleadosHandler :
        IRequestHandler<ObtenerEmpleadosQuery, List<EmpleadoDto>>
    {
        public async Task<List<EmpleadoDto>> Handle(ObtenerEmpleadosQuery request, 
            CancellationToken cancellationToken)
        {
            var empleados = new List<EmpleadoDto>
            { 
                new EmpleadoDto 
                {Nombre="Perecejo Perez", Cargo="Plomero", Salario=1500000},
                new EmpleadoDto 
                {Nombre="Perecejo Perez", Cargo="Plomero", Salario=1500000},
                new EmpleadoDto 
                {Nombre="Perecejo Perez", Cargo="Plomero", Salario=1500000}
            };

            return await Task.FromResult(empleados);
        }
    }
}

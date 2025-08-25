using EmpleadoApp.Features.Empleados.Commands;
using MediatR;

namespace EmpleadoApp.Features.Empleados.Handlers
{
    public class CrearEmpleadoHandler : IRequestHandler<CrearEmpleadoCommand, string>
    {
        public async Task<string> Handle(CrearEmpleadoCommand request, 
            CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();
            request.Id = id;

            Console.WriteLine($"Empleado {request.Nombre} creado");
            return await Task.FromResult($"Empleado con ID {request.Id} creado");
        }
    }
}

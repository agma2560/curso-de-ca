using MediatR;

namespace EmpleadoApp.Features.Empleados.Commands
{
    public class CrearEmpleadoCommand : IRequest<string>
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty ;
        public decimal Salario { get; set; }
    }
}

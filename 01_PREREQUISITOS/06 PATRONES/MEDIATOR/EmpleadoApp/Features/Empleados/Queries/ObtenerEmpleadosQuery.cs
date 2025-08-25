using MediatR;

namespace EmpleadoApp.Features.Empleados.Queries
{
    public class ObtenerEmpleadosQuery : IRequest<List<EmpleadoDto>>
    {
    }

    public class EmpleadoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public decimal Salario { get; set; } 
    }
}

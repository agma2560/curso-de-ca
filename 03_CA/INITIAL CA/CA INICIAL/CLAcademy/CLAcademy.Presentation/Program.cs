using CLAcademy.Application.Mappings;
using CLAcademy.Application.Services;
using CLAcademy.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// AutoMapper
builder.Services.AddAutoMapper(typeof(StudentProfile).Assembly);

// Agregar infraestructura (DbContext + Repositorios)
builder.Services.AddInfrastructure(builder.Configuration);

// Agregar Swagger estándar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios de aplicación
builder.Services.AddScoped<StudentService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto genera /swagger/index.html
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

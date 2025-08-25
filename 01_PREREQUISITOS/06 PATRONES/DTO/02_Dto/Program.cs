using _01_Dto.Profiler;

var builder = WebApplication.CreateBuilder(args);

// Registrar AutoMapper y escanear el assembly que contiene los perfiles
builder.Services.AddAutoMapper(typeof(EmpleadoProfile));

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

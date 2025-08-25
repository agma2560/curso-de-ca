using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models; // 🆕 para Swagger

var builder = WebApplication.CreateBuilder(args);

// 🆕 Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Email API", Version = "v1" });
});

// Registrar el servicio de envío de correos como Singleton
//builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();
//builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();

var app = builder.Build();

// 🆕 Usar Swagger en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Email API v1");
    });
}

// Endpoint POST /api/email
//app.MapPost("/api/email", (EmailRequest request, IEmailSender emailSender) =>
//{
//    emailSender.SendEmail(request.To, request.Subject, request.Body);
//    return Results.Ok("Correo enviado.");
//});

// Nuevo EndPonit POS
app.MapPost("/api/email", (EmailRequest request, IServiceProvider serviceProvider) =>
{
    // 1. Resolvemos la primera instancia
    var emailSender1 = serviceProvider.GetRequiredService<IEmailSender>();
    Console.WriteLine($"Primera instancia de IEmailSender (Value: {((SmtpEmailSender)emailSender1).Value})");
    emailSender1.SendEmail(request.To, request.Subject, request.Body);

    // 2. Resolvemos una segunda instancia dentro de la MISMA petición
    var emailSender2 = serviceProvider.GetRequiredService<IEmailSender>();
    Console.WriteLine($"Segunda instancia de IEmailSender (Value: {((SmtpEmailSender)emailSender2).Value})");
    emailSender2.SendEmail(request.To, request.Subject, request.Body);
    
    return Results.Ok("Correo enviado.");
});
//----------------------

app.Run();

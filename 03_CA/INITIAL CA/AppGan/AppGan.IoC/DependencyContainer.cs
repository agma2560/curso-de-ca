using AppGan.Entities.Interfaces;
using AppGan.Repositories.EFCore.DataContext;
using AppGan.Repositories.EFCore.Repositories;
using AppGan.UseCases.Common.Behaviors;
using AppGan.UseCases.CreateOrder;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppGan.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAppGanServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<AppGanContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SoftGanDb")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddMediatR(typeof(CreateOrderInteractor));
            
            // MediatR v13 - correcta forma
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateOrderInteractor>();
            });

            //services.AddValidatorsFromAssemblies(typeof(CreateOrderValidator).Assembly);

            // FluentValidation v12+ - usando AssemblyScanner manualmente
            FluentValidation.AssemblyScanner
                .FindValidatorsInAssembly(typeof(CreateOrderValidator).Assembly)
                .ForEach(result =>
                {
                    services.AddScoped(result.InterfaceType, result.ValidatorType);
                });

            services.AddTransient(typeof(IPipelineBehavior<,>), 
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using AutoMapper;
using SmartSpaces.Application.Common.Behaviors; // Asegúrate de agregar este using

namespace SmartSpaces.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Registrar MediatR y conectarle el Behavior de validación
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);

            // CONECTAR EL PIPELINE DE VALIDACIÓN AQUÍ
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        // Registrar AutoMapper
        services.AddAutoMapper(cfg => cfg.AddMaps(assembly));

        // Registrar FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
namespace WebApplication1
{
    using System.Reflection;

    using FluentValidation;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using WebApplication1.Configurations;

    internal static class MediatrExtensions
    {
        internal static IServiceCollection AddMediatRAndConfigure(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => { services.AddScoped(result.InterfaceType, result.ValidatorType); });

            return services
                .AddMediatR(typeof(MediatrExtensions).GetTypeInfo().Assembly)
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
        }
    }
}

namespace WebApplication1.Configurations
{
    using Infrastructure.Data;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            return services.AddScoped<ISubjectRepository, SubjectRepository>()
                           .AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}

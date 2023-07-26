using Grupo3_Unapec.Application;
using Grupo3_Unapec.Application.Common.Interfaces;
using Grupo3_Unapec.Infrastructure.Persistence;
using Grupo3_Unapec.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Grupo3_Unapec.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        return services;
    }
}
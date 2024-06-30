using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("BaseDb"));
        var cn = configuration.GetSection("SeriLogConfigurations").
            GetSection("MsSqlConfiguration").
            GetSection("ConnectionString");
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(cn.Value, builder =>
        {
            builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(15), null);
        }));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        return services;
    }
}

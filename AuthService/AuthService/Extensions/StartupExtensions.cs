using AuthService.Persistence.Context;
using AuthService.Services.Interfaces;
using AuthService.Services;
using Microsoft.EntityFrameworkCore;
using AuthService.Persistence.Repositories.Interfaces;
using AuthService.Persistence.Repositories;

namespace AuthService.Extensions;

public static class StartupExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddAServices(this IServiceCollection services)
    {
        // Application service registrations
        services.AddScoped<UserService>();
        services.AddSingleton<IPasswordEncryptionService, PasswordEncryptionService>();
        services.AddSingleton<ITokenService, TokenService>();

        return services;
    }
}

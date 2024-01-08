using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ServerApp.Context;
using ServerApp.Models;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repository.Interfaces;
using ServerApp.Repository;
using ServerApp.Services;

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        TcpServer server = new TcpServer(3000, host.Services);
        server.Start();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                // Add EF Core context
                services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

                // Register repositories
                services.AddScoped<RoomRepository>();
                services.AddScoped<UserRoomLinkRepository>();
                services.AddScoped<MessageRepository>();
                services.AddScoped<TokenService>();

                // Register services
                services.AddScoped<DataService>();
            });
}

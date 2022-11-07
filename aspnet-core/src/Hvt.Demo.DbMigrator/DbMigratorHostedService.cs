using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hvt.Demo.Data;
using Serilog;
using Volo.Abp;
using System;

namespace Hvt.Demo.DbMigrator;

public class DbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;

    public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var application = await AbpApplicationFactory.CreateAsync<DemoDbMigratorModule>(options =>
        {
           options.Services.ReplaceConfiguration(_configuration);
           options.UseAutofac();
           options.Services.AddLogging(c => c.AddSerilog());
            // Add this line of code to make it possible read from appsettings.Staging.json
            options.Services.ReplaceConfiguration(BuildConfiguration());
        }))
        {
            await application.InitializeAsync();

            await application
                .ServiceProvider
                .GetRequiredService<DemoDbMigrationService>()
                .MigrateAsync();

            await application.ShutdownAsync();

            _hostApplicationLifetime.StopApplication();
        }
    }

    private IConfiguration BuildConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

        // Extra code block to make it possible to read from appsettings.Staging.json
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environmentName == "Staging")
        {
            configurationBuilder.AddJsonFile($"appsettings.{environmentName}.json", true);
        }

        return configurationBuilder
            .AddEnvironmentVariables()
            .Build();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

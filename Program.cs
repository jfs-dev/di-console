using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using di_console_implementations;
using di_console_interfaces;
using di_console_services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IExampleTransientService, ExampleTransientService>();
        services.AddScoped<IExampleScopedService, ExampleScopedService>();
        services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
        services.AddTransient<ServiceLifetimeReporter>();
    })
    .Build();

ExemplifyServiceLifetime(host.Services, "Requisição 1");
ExemplifyServiceLifetime(host.Services, "Requisição 2");

await host.RunAsync();

static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails($"{lifetime}: Chamada 1");

    Console.WriteLine();

    logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails($"{lifetime}: Chamada 2");

    Console.WriteLine();
}

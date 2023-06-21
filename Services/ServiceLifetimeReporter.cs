using di_console_interfaces;

namespace di_console_services;

internal sealed class ServiceLifetimeReporter
{
    private readonly IExampleTransientService _transientService;
    private readonly IExampleScopedService _scopedService;
    private readonly IExampleSingletonService _singletonService;

    public ServiceLifetimeReporter(IExampleTransientService transientService,
                                   IExampleScopedService scopedService,
                                   IExampleSingletonService singletonService) =>
                                  (_transientService, _scopedService, _singletonService) =
                                  (transientService, scopedService, singletonService);

    public void ReportServiceLifetimeDetails(string lifetimeDetails)
    {
        Console.ResetColor();
        Console.WriteLine(lifetimeDetails);
        Console.WriteLine("-----------------------");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Transient: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{_transientService.Id} ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Id sempre diferente");


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("   Scoped: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{_scopedService.Id} ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Id igual na mesma requisição e diferente em uma nova requisição");


        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Singleton: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{_singletonService.Id} ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Id sempre igual");
        Console.ResetColor();
    }
}

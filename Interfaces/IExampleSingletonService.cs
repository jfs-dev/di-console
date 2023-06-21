using Microsoft.Extensions.DependencyInjection;

namespace di_console_interfaces;

public interface IExampleSingletonService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
}

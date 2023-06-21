using Microsoft.Extensions.DependencyInjection;

namespace di_console_interfaces;

public interface IExampleScopedService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
}

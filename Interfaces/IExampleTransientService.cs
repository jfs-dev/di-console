using Microsoft.Extensions.DependencyInjection;

namespace di_console_interfaces;

public interface IExampleTransientService : IReportServiceLifetime
{
    ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
}

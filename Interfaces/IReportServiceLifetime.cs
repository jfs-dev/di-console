using Microsoft.Extensions.DependencyInjection;

namespace di_console_interfaces;

public interface IReportServiceLifetime
{
    Guid Id { get; }

    ServiceLifetime Lifetime { get; }
}

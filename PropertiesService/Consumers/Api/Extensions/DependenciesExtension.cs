using LogNLog;

namespace Api.Extensions;

public static class DependenciesExtension
{
    public static void LoadDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<Domain.Ports.ILogger, NLogLogger>();
    }
}

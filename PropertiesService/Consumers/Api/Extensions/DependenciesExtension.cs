using Application;
using Application.User;
using Application.User.Ports;
using Domain.Ports;
using IdentityAuth;
using IdentityAuth.Jwt;
using LogNLog;

namespace Api.Extensions;

public static class DependenciesExtension
{
    public static void LoadDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<Domain.Ports.ILogger, NLogLogger>();
        builder.Services.AddScoped<JwtGenerator>();
        builder.Services.AddTransient<IAuthenticationService, IdentityService>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserService>();
    }
}

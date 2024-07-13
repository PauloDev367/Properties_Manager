using DataEF;
using IdentityAuth;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ConfigureAppDbContextExtension
{
    public static void ConfigureAppDbContext(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("SqlServer");
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connString);
        });
    }
}

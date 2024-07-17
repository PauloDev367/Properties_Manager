using Api.Extensions;
using NLog;


var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration("nlog.config");

builder.Services.AddControllers();

builder.ConfigureAppDbContext();
builder.LoadDependencies();
builder.ConfigureAppAuth();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureSwagger();
var app = builder.Build();
app.UseStaticFiles();
app.ConfigureGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

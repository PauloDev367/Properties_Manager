using Api.Extensions;
using NLog;


var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration("nlog.config");

// Add services to the container.

builder.Services.AddControllers();

builder.ConfigureAppDbContext();
builder.LoadDependencies();
builder.ConfigureAppAuth();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
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

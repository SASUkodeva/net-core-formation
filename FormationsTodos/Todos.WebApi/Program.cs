using Todos.Infrastructure.CoreDi;
using Todos.Application.ApplicationDI;
using Microsoft.Extensions.Options;
using Todos.WebApi.SignalRHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Définition des Services Swagger API */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();
/***************************************/

/* Injection des Services */

builder.Services.AddTodosInfrastructureServices(builder.Configuration);
builder.Services.AddTodosApplicationServices();
builder.Services.AddSignalR();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UserTodosInfrastructureMigration();
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    // endpoints.MapControllers();
    endpoints.MapHub<SignalRhub>("ws/Signalr");
});
app.MapControllers();

app.Run();
